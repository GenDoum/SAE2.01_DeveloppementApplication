using Microsoft.Maui.Controls;
using Model;
using Persistance;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Vues;

public partial class SearchMob : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Monstre> MnstrTemp { get; set; }
    private string searchText;
    public string SearchText
    {
        get
        {
            return searchText;
        }
        set
        {
            searchText = value;
            MnstrTemp = (Application.Current as App).monsterManager.search(searchText);
            if (searchText == "")
            {
                MnstrTemp = (Application.Current as App).monsterManager.ListMonsters;
            }
            OnPropertyChanged(nameof(MnstrTemp));
        }
    }
    string appearanceSelected { get; set; } = string.Empty;
    public SearchMob()
	{
		InitializeComponent();
		BindingContext = (Application.Current as App).monsterManager;
        MnstrTemp = (Application.Current as App).monsterManager.ListMonsters;
        ListViewMonsters.BindingContext = this;
        searchBar.BindingContext = this;
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

        // Afficher les champs à remplir pour ajouter un conseil
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
            // récupère les valeurs des champs pour ajouter un conseil
            var texteConseil = texteConseilEntry.Text;

            // Ajouter le nouveau conseil à la liste des conseils du monstre sélectionné
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(texteConseil))
            {
                var nouveauConseil = new Conseil((App.Current as App).User, texteConseil, selectedMonstre);
                selectedMonstre.ListConseils.Add(nouveauConseil);
            }

            // Réinitialiser les champs et masquer la section d'ajout de conseil
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

    private void passive_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    public void FilterClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var afficherFiltres = button?.Parent?.FindByName<HorizontalStackLayout>("Filter");

    }

    private void passive_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}