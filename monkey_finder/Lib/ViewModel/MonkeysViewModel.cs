using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using monkey_finder.Lib.Model;
using monkey_finder.Lib.Services;
using monkey_finder.View;

namespace monkey_finder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly MonkeyService _monkeyService;
    private readonly IConnectivity _connectivity;
    private readonly IGeolocation _geolocation;

    public ObservableCollection<MonkeyModel> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkeys Finder";
        _monkeyService = monkeyService;
        _connectivity = connectivity;
        _geolocation = geolocation;
    }

    [RelayCommand]
    public async Task GetClosestMonkeyAsync()
    {
        if (IsBusy || Monkeys.Count == 0)
            return;
        try 
        {
            var location = await _geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await _geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    }
                    );
            }
            if (location == null)
                return;
            var first = Monkeys.OrderBy(m => location.CalculateDistance(m.Latitude, m.Longtitude, DistanceUnits.Kilometers)).FirstOrDefault();
            if (first is null)
                return;
            await Shell.Current.DisplayAlert("Closest monkey", $"{first.Name} in {first.Location}", "OK");

        }
        catch
        {
            await Shell.Current.DisplayAlert("Error", "Unable to find closest monkey", "OK");
        }
        finally
        {

        }
    }

    [RelayCommand]
    public async Task GoToDetailsAsync(MonkeyModel monkey)
    {
        if (monkey is null)
            return;
        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, dynamic>() {
            { "Monkey", monkey}
        });
    }

    [RelayCommand]
    public async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error", "No Internet connection", "OK");
                return;
            }
            IsBusy = true;

            var monkeys = await _monkeyService.GetMonkeys();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Monkeys.Clear();
                foreach (var m in monkeys)
                {
                    Monkeys.Add(m);
                }
            });
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await Shell.Current.DisplayAlert("Error", "Unable to get monkeys", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
