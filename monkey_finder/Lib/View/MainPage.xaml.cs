using monkey_finder.ViewModel;

namespace monkey_finder
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MonkeysViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
