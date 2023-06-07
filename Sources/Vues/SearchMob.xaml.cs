using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
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

    public void refreshScrollView()
    {
        ScrollLayoutThatNeedsToBeRefreshed.IsVisible = false;
        ScrollLayoutThatNeedsToBeRefreshed.IsVisible = true;
    }
	public void OnClick(object sender, ItemTappedEventArgs e)
	{
		(App.Current as App).MonstreSelectionne = e.Item as Monstre;
        imageCollection.Source = imageLinkConverter((App.Current as App).MonstreSelectionne.AppearanceList.First());
        refreshScrollView();
    }
    private void OnAddConseilClicked(object sender, EventArgs e)
    {
        // Afficher les champs � remplir pour ajouter un conseil
        if (!AddConseilLayout.IsVisible)
        {
            AddConseilLayout.IsVisible = true;
            texteConseilEntry.Text = null;
            refreshScrollView();
        }
    }

    private void OnValiderConseilClicked(object sender, EventArgs e)
    {
        if (AddConseilLayout != null)
        {
            string texteConseil = texteConseilEntry.Text;
            // Ajouter le nouveau conseil � la liste des conseils du monstre s�lectionn�
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(texteConseil))
            {
                var nouveauConseil = new Conseil((App.Current as App).User, texteConseil, selectedMonstre);
                selectedMonstre.ListConseils.Add(nouveauConseil);
            }
            texteConseilEntry.Text = null;
            AddConseilLayout.IsVisible = false;
        }
        refreshScrollView();
    }

    private void OnExitConseilClicked(object sender, EventArgs e)
    {
        texteConseilEntry.Text = null;
        AddConseilLayout.IsVisible = false;
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

    private void FilterClicked(object sender, EventArgs e)
    {
        // Inverse la valeur bool�enne de IsVisible => Permet d'afficher ou non les boutons de filtrage
        HorizonFilterClicked.IsVisible = !HorizonFilterClicked.IsVisible;
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

    private void texteConseilEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (ScrollLayoutThatNeedsToBeRefreshed as IView).InvalidateMeasure(); //Permet de recalculer la taille de la scrollView
    }
}