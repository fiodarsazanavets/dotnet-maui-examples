using DynamicData.Binding;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Realms;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiReactiveUiExample.Models;
using MongoDB.Bson;
using CommunityToolkit.Mvvm.Input;

namespace MauiReactiveUiExample.ViewModels;

public partial class AppViewModel : ObservableObject
{
    private readonly SourceCache<Animal, ObjectId> _AnimalNames;
    private ReadOnlyObservableCollection<Animal> _sortedAnimalNames;
    private readonly Realm realm;

    [ObservableProperty]
    private string query;

    [ObservableProperty]
    private Animal selectedAnimal;

    [ObservableProperty]
    private string newAnimal;

    public ReadOnlyObservableCollection<Animal> AnimalNames => _sortedAnimalNames;

    public AppViewModel()
    {
        realm = Realm.GetInstance();
        IQueryable<Animal> allNames = realm.All<Animal>();
        allNames.SubscribeForNotifications((sender, changes, error) =>
        {
            _AnimalNames.AddOrUpdate(allNames);
        });
        _AnimalNames = new SourceCache<Animal, ObjectId>(company => company.Id);
        _AnimalNames.AddOrUpdate(allNames);

        IObservable<PropertyValue<AppViewModel, string>>? refreshObs = this.WhenPropertyChanged(t => t.Query).Throttle(TimeSpan.FromMilliseconds(5));

        IObservable<IChangeSet<Animal, ObjectId>>? dataConnection = _AnimalNames.Connect();


        dataConnection
       .AutoRefreshOnObservable(_ => refreshObs)
       .ObserveOn(RxApp.MainThreadScheduler)
       .Filter(m => Query == null || m.Name.IndexOf(Query, StringComparison.CurrentCultureIgnoreCase) >= 0)
       .Bind(out _sortedAnimalNames)
       .Subscribe();


    }

    [RelayCommand]
    public Task AddAnimal()
    {
        if (!string.IsNullOrWhiteSpace(NewAnimal))
        {
            realm.Write(() => realm.Add(new Animal { Name = NewAnimal }));
            NewAnimal = "";
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task DeleteAnimal(Animal Animal)
    {
        _AnimalNames.Remove(Animal);
        realm.Write(() => realm.Remove(Animal));

        return Task.CompletedTask;
    }
}
