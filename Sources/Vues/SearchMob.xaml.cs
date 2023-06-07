using Microsoft.Maui.Controls;
using Model;
using Persistance;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;


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
            if (searchText == "")
            {
                MnstrTemp = (Application.Current as App).monsterManager.ListMonsters;
            }
            else MnstrTemp = (Application.Current as App).monsterManager.search(searchText);
            UpdateAffichMobs();
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
        if ((Application.Current as App).User != null)
        {
            ButtonAddConseil.IsVisible = true;
        }
    }

	public void OnClick(object sender, ItemTappedEventArgs e)
	{
		(App.Current as App).MonstreSelectionne = e.Item as Monstre;
        imageCollection.Source = imageLinkConverter((App.Current as App).MonstreSelectionne.AppearanceList.First());
    }
    private void OnAddConseilClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        // Afficher les champs à remplir pour ajouter un conseil
        //FAIRE UN FUCKING X:NAME :>
        var addConseilLayout = button?.Parent?.FindByName<StackLayout>("AddConseilLayout");
        if (addConseilLayout != null)
        {
            ScrollLayoutThatNeedsToBeRefreshed.IsVisible = false;
            addConseilLayout.IsVisible = true;
            ScrollLayoutThatNeedsToBeRefreshed.IsVisible = true;
        }
    }

    private void OnValiderConseilClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        //FAIRE UN FUCKING ICI AUSSI X:NAME :>
        var addConseilLayout = button?.Parent?.FindByName<StackLayout>("AddConseilLayout");

        if (addConseilLayout != null)
        {
            var texteConseil = texteConseilEntry.Text;
            // Ajouter le nouveau conseil à la liste des conseils du monstre sélectionné
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(texteConseil))
            {
                var nouveauConseil = new Conseil((App.Current as App).User, texteConseil, selectedMonstre);
                selectedMonstre.ListConseils.Add(nouveauConseil);
            }
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
    }

    private void UpdateAffichMobs()
    {
        var filtreMobs = MnstrTemp.Where(Monstre =>
            (boss.IsChecked && Monstre.Dangerosite == "BOSS") ||
            (hostile.IsChecked && Monstre.Dangerosite == "hostile") ||
            (passive.IsChecked && Monstre.Dangerosite == "passif"));

        ListViewMonsters.ItemsSource = filtreMobs.ToList();
    }
    private void passive_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateAffichMobs();
    }

    private void hostile_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateAffichMobs();
    }

    private void boss_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateAffichMobs();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchText = e.NewTextValue;
    }

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        //ConseilOptions.IsVisible = true;
    }
}