using Model;

namespace Vues;

public partial class SearchMob : ContentPage
{
	public SearchMob()
	{
		InitializeComponent();
		BindingContext = (Application.Current as App).monsterManager;

    }

	public void OnClick(object sender, ItemTappedEventArgs e)
	{
		(App.Current as App).MonstreSelectionne = e.Item as Monstre;
	}
}