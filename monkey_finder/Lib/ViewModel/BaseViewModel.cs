using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace monkey_finder.ViewModel;

[ObservableObject]
public partial class BaseViewModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;
    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;
}

