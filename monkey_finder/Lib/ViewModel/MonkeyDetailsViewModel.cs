using CommunityToolkit.Mvvm.ComponentModel;
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

        public MonkeyDetailsViewModel()
        {
        }
    }

