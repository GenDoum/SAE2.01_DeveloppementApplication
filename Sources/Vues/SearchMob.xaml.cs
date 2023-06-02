using Microsoft.Maui.Controls;
using Model;

namespace Vues;

public partial class SearchMob : ContentPage
{
    
    string appearanceSelected { get; set; } = string.Empty;
    public SearchMob()
	{
		InitializeComponent();
		BindingContext = (Application.Current as App).monsterManager;
        imageCollection.BindingContext = this;
    }

	public void OnClick(object sender, ItemTappedEventArgs e)
	{
		(App.Current as App).MonstreSelectionne = e.Item as Monstre;
        imageCollection.Source = imageLinkConverter((App.Current as App).MonstreSelectionne.AppearanceList.First());
    }
    private void OnAddConseilClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedConseil = button?.BindingContext as Conseil;

        // Afficher les champs � remplir pour ajouter un conseil
        var addConseilLayout = button?.Parent?.FindByName<StackLayout>("AddConseilLayout");
        if (addConseilLayout != null)
        {
            addConseilLayout.IsVisible = true;
        }
    }

    private void OnValiderConseilClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var addConseilLayout = button?.Parent?.FindByName<StackLayout>("AddConseilLayout");

        if (addConseilLayout != null)
        {
            // r�cup�re les valeurs des champs pour ajouter un conseil
            var texteConseil = texteConseilEntry.Text;

            // Ajouter le nouveau conseil � la liste des conseils du monstre s�lectionn�
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(texteConseil))
            {
                var nouveauConseil = new Conseil((App.Current as App).User, texteConseil, selectedMonstre);
                selectedMonstre.ListConseils.Add(nouveauConseil);
            }

            // R�initialiser les champs et masquer la section d'ajout de conseil
            texteConseilEntry.Text = string.Empty;
            addConseilLayout.IsVisible = false;

        }
    }


    private void OnExitConseilClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var addConseilLayout = button?.Parent?.FindByName<StackLayout>("AddConseilLayout");
        var texteConseilEntry = addConseilLayout.Children[1] as Editor;
        texteConseilEntry.Text = string.Empty;
        addConseilLayout.IsVisible = false;
    }

    private string imageLinkConverter(string imageLink)
    {
        imageLink = String.Concat(imageLink.Where(c => !Char.IsWhiteSpace(c)));
        imageLink = "collection" + imageLink.ToLower() + ".png";
        return imageLink;
    }

    private void ListAppearance_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        appearanceSelected = e.Item as string;
        imageCollection.Source = imageLinkConverter(appearanceSelected);

    }

    private void FilterClicked(object sender, EventArgs e) // Afficher les filtres
    {
        var button = sender as Button;
        var afficherFiltres = button?.Parent?.FindByName<HorizontalStackLayout>("HorizonFilterClicked");
        if (afficherFiltres.IsVisible)
        {
            afficherFiltres.IsVisible = false;
        }
        else
        {
            afficherFiltres.IsVisible |= true;
        }
        /*
        if (afficherFiltres != null)
        {
            afficherFiltres.IsVisible = true;
        }*/
    }

    private void passive_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void hostile_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void boss_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}