FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install -g redth.net.maui.check
RUN apt-get update
RUN apt install -y default-jdk
#RUN apt-get install openjdk
USER root
ENV ANDROID_HOME="/opt/android-sdk" \
    ANDROID_NDK="/opt/android-ndk" \
    FLUTTER_HOME="/opt/flutter" \
    JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64/
# Get the latest version from https://developer.android.com/studio/index.html
ENV ANDROID_SDK_TOOLS_VERSION="7302050_latest"
# nodejs version
RUN apt-get clean && apt-get update -qq && apt-get install -qq -y apt-utils locales && locale-gen $LANG
ENV DEBIAN_FRONTEND="noninteractive" \
    TERM=dumb \
    DEBIAN_FRONTEND=noninteractive
# Variables must be references after they are created
ENV ANDROID_SDK_ROOT="$ANDROID_HOME"
ENV PATH="$PATH:$ANDROID_SDK_ROOT/emulator:$ANDROID_SDK_ROOT/cmdline-tools/latest/bin:$ANDROID_SDK_ROOT/tools:$ANDROID_SDK_ROOT/platform-tools:$ANDROID_NDK:$FLUTTER_HOME/bin:$FLUTTER_HOME/bin/cache/dart-sdk/bin"
WORKDIR /tmp
# Installing packages
RUN apt-get update -qq > /dev/null && \
    apt-get install -qq locales > /dev/null && \
    locale-gen "$LANG" > /dev/null && \
    apt-get install -qq --no-install-recommends \
        android-tools-adb \
        build-essential \
        autoconf \
        curl \
        git \
        gpg-agent \
        lib32stdc++6 \
        lib32z1 \
        lib32z1-dev \
        lib32ncurses6 \
        libc6-dev \
        libgmp-dev \
        libmpc-dev \
        libmpfr-dev \
        libssl-dev \
        libxslt-dev \
        libxml2-dev \
        m4 \
        ncurses-dev \
        ocaml \
        openjdk-11-jdk \
        openssh-client \
        pkg-config \
        software-properties-common \
        ruby-full \
        software-properties-common \
        unzip \
        vim \
        wget \
        zip \
        zlib1g-dev > /dev/null && \
    apt-get clean > /dev/null && \
    rm -rf /var/lib/apt/lists/ && \
    rm -rf /tmp/* /var/tmp/*
RUN cd /opt \
    && wget -q "https://dl.google.com/android/repository/commandlinetools-linux-${ANDROID_SDK_TOOLS_VERSION}.zip" -O android-commandline-tools.zip \
    && mkdir -p "$ANDROID_SDK_ROOT/cmdline-tools" \
    && unzip -q android-commandline-tools.zip -d /tmp/ \
    && mv /tmp/cmdline-tools/ "$ANDROID_SDK_ROOT/cmdline-tools/latest" \
    && rm android-commandline-tools.zip && ls -la "$ANDROID_SDK_ROOT/cmdline-tools/latest/"
# Install SDKs
# Please keep these in descending order!
# The `yes` is for accepting all non-standard tool licenses.
RUN mkdir --parents "$ANDROID_HOME/.android/" && \
    echo '### User Sources for Android SDK Manager' > \
        "$ANDROID_HOME/.android/repositories.cfg" && \
    yes | sdkmanager --licenses > /dev/null && \
    echo "Installing platforms" && \
    yes | sdkmanager \
        "platforms;android-31" \
        "platforms;android-30" \
        "platforms;android-29" > /dev/null && \
    echo "Installing platform tools " && \
    yes | sdkmanager \
        "platform-tools" > /dev/null && \
    echo "Installing build tools " && \
    yes | sdkmanager \
        "build-tools;30.0.3" \
        "build-tools;30.0.0" > /dev/null && \
    echo "Installing extras " && \
    yes | sdkmanager \
        "extras;android;m2repository" \
        "extras;google;m2repository" > /dev/null && \
    echo "Installing play services " && \
    yes | sdkmanager \
        "extras;google;google_play_services" \
        "extras;m2repository;com;android;support;constraint;constraint-layout;1.0.2" \
        "extras;m2repository;com;android;support;constraint;constraint-layout;1.0.1" > /dev/null && \
    echo "Installing Google APIs" && \
    yes | sdkmanager \
        "add-ons;addon-google_apis-google-24" \
        "add-ons;addon-google_apis-google-23" > /dev/null
RUN echo "Installing kotlin" && \
    wget --quiet -O sdk.install.sh "https://get.sdkman.io" && \
    bash -c "bash ./sdk.install.sh > /dev/null && source ~/.sdkman/bin/sdkman-init.sh && sdk install kotlin" && \
    rm -f sdk.install.sh

# Copy sdk license agreement files.
RUN mkdir -p mkdir "$ANDROID_HOME/licenses" || true \
    && echo "24333f8a63b6825ea9c5514f83c2829b004d1fee" > "$ANDROID_HOME/licenses/android-sdk-license"
RUN chmod 777 $ANDROID_HOME/.android
RUN dotnet workload install maui-android