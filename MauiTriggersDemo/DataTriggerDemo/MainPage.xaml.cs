namespace DataTriggerDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTextSaved(object sender, EventArgs e)
        {
            savedText.Text = $"Currently saved text: {entry.Text}";

            SemanticScreenReader.Announce(savedText.Text);
        }
    }
}