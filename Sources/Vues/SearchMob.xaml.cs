using Model;

namespace Vues;

public partial class SearchMob : ContentPage
{
	public SearchMob()
	{
		InitializeComponent();
		BindingContext = (App.Current as App).mnstrMngr;

    }
}