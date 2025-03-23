using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using monkey_finder.Lib.Model;
using monkey_finder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkey_finder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    MonkeyModel monkey;

    private readonly IMap _map;

    public MonkeyDetailsViewModel(IMap map)
    {
        _map = map;
    }

    [RelayCommand]

    public async Task OpenMapAsync()
    {
        try
        {
            await _map.OpenAsync(Monkey.Latitude, Monkey.Longtitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch
        {
            await Shell.Current.DisplayAlert("Error", "Unable to open map", "OK");

        }
        finally
        {

        }
    }
}

