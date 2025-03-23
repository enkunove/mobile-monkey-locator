using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using monkey_finder.Lib.Model;
using monkey_finder.Lib.Services;

namespace monkey_finder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly MonkeyService _monkeyService;

    public ObservableCollection<MonkeyModel> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkeys Finder";
        _monkeyService = monkeyService;
    }

    [RelayCommand]
    public async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
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
