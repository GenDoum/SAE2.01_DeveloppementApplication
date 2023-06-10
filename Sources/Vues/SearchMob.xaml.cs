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
    private Conseil conseilSelectionne { get; set; }
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
            ConseilOptionModify.IsVisible = true;
            ConseilOptionDelete.IsVisible = true;
            dejaVuContainer.IsVisible = true;
            CheckDejaVu.IsChecked = false;
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
        AddConseilLayout.IsVisible = false;
        conseilSelectionne = null;
        if ((Application.Current as App).User != null)
        {
            foreach (Monstre m in (App.Current as App).User.monstresDejaVu)
            {
                if (m.Name.Equals((App.Current as App).MonstreSelectionne.Name))
                {
                    CheckDejaVu.IsChecked = true;
                    break;
                }
                else
                {
                    CheckDejaVu.IsChecked = false;
                }
            }
        }
        refreshScrollView();
    }
    private void OnAddConseilClicked(object sender, EventArgs e)
    {
        // Afficher les champs à remplir pour ajouter un conseil
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
            // Ajouter le nouveau conseil à la liste des conseils du monstre sélectionné
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
        // Inverse la valeur booléenne de IsVisible => Permet d'afficher ou non les boutons de filtrage
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

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //VerticalModifConseil.IsVisible = true; ABANDON je vais faire la collection
        
    }

    private async void CollectionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Collection());
    }

    private async void QuitClicked(object sender, EventArgs e)
    {
        (Application.Current as App).User = null;
        await Navigation.PopToRootAsync(); //Pour retourner à la page racine
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (CheckDejaVu.IsChecked)
        {
            if ((App.Current as App).User != null) 
            {
                CheckDejaVu.IsChecked = true;
                (Application.Current as App).User.monstresDejaVu.Add((Application.Current as App).MonstreSelectionne);
            }
        }
        else
        {
            if ((App.Current as App).User != null)
            {
                CheckDejaVu.IsChecked = false;
                (Application.Current as App).User.monstresDejaVu.Remove((Application.Current as App).MonstreSelectionne);
            }
        }
    }

    private void ConseilOptionDelete_Clicked(object sender, EventArgs e)
    {
        if (conseilSelectionne != null)
        {
            if ((App.Current as App).User.Pseudo.Equals(conseilSelectionne.Auteur.Pseudo))
            {
                (App.Current as App).MonstreSelectionne.ListConseils.Remove(conseilSelectionne);
                ConseilOptionModify.IsEnabled = false;
                ConseilOptionDelete.IsEnabled = false;
            }
        }
    }

    private void ConseilOptionModify_Clicked(object sender, EventArgs e)
    {
        if (!ModifyConseilLayout.IsVisible)
        {
            ModifyConseilLayout.IsVisible = true;
            conseilEditor.Text = conseilSelectionne.Texte;
            refreshScrollView();
        }
    }

    private void ListViewConseils_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if((App.Current as App).User != null)
        {
            conseilSelectionne = e.Item as Conseil;
            if (conseilSelectionne != null && (App.Current as App).User.Pseudo.Equals(conseilSelectionne.Auteur.Pseudo))
            {
                ConseilOptionModify.IsEnabled = true;
                ConseilOptionDelete.IsEnabled = true;
            }
            else
            {
                ConseilOptionModify.IsEnabled = false;
                ConseilOptionDelete.IsEnabled = false;
            }
        }
    }

    private void conseilEditor_TextChanged(object sender, TextChangedEventArgs e)
    {
        (ScrollLayoutThatNeedsToBeRefreshed as IView).InvalidateMeasure();
    }

    private void OnValiderModifConseilClicked(object sender, EventArgs e)
    {
        if (ModifyConseilLayout != null)
        {
            string texteConseil = conseilEditor.Text;
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(texteConseil) && !conseilSelectionne.Texte.Equals(texteConseil))
            {
                selectedMonstre.ListConseils.Remove(conseilSelectionne);
                selectedMonstre.ListConseils.Add(new Conseil((App.Current as App).User, texteConseil, selectedMonstre));
            }
            conseilEditor.Text = null;
            ModifyConseilLayout.IsVisible = false;
            ConseilOptionModify.IsEnabled = false;
            ConseilOptionDelete.IsEnabled = false;
        }
        refreshScrollView();
    }

    private void OnExitModifConseilClicked(object sender, EventArgs e)
    {
        conseilEditor.Text = null;
        ModifyConseilLayout.IsVisible = false;
    }
}