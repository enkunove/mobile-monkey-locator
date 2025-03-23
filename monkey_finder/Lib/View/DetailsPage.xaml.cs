using monkey_finder.Lib.Model;
using monkey_finder.ViewModel;

namespace monkey_finder.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(MonkeyDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}