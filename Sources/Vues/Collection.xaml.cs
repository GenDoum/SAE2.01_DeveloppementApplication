using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Vues;

public partial class Collection : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Monstre> MnstrTemp = (Application.Current as App).monsterManager.ListMonsters;
    public ObservableCollection<Monstre> MonstresDejaVu { get; set; }

    public Collection()
    {
        InitializeComponent();
        User toto = (Application.Current as App).User;
        MonstresDejaVu = new ObservableCollection<Monstre>(toto.monstresDejaVu);
        var MnstrTemp = new ObservableCollection<Monstre> { };
        MnstrTemp = new ObservableCollection<Monstre>((Application.Current as App).monsterManager.ListMonsters.Except(MonstresDejaVu));
        ListViewMonsters.BindingContext = this;
    }
    
    private void UpdateListMobs(ObservableCollection<Monstre> Monstres) // /!\ Qd on décoche Monstre déjà vu et re coche ils ne veulent pas réapparaître sauf si on clique aussi sur monstre pas vu
    {
        var monstresDejaVu = Monstres.Where(monstre => (Application.Current as App).User.monstresDejaVu.Contains(monstre)).ToList();
        var monstresPasVu = (Application.Current as App).monsterManager.ListMonsters.Except(monstresDejaVu).ToList();
        Monstres.Clear();
        if (CheckboxdejaVu.IsChecked && CheckboxpasVu.IsChecked)
        {
            foreach (var monstre in monstresDejaVu.Concat(monstresPasVu))
            {
                Monstres.Add(monstre);
            }
        }
        // Si monstres déjà vu checked et monstres pas vu pas checked alors on l'ajoute à la collection et on supprime les monstres pas vu
        else if (CheckboxdejaVu.IsChecked && !CheckboxpasVu.IsChecked)
        {
            foreach (var monstre in monstresDejaVu)
            {
                Monstres.Add(monstre);
            }
        }
        // Si monstres pas vu checked alors on l'ajoute à la collection
        else if (CheckboxpasVu.IsChecked && !CheckboxdejaVu.IsChecked)
        {
            foreach (var monstre in monstresPasVu)
            {
                if (!monstresDejaVu.Contains(monstre))
                {
                    Monstres.Add(monstre);
                }
            }
        }

    }

    private void CheckedVu(object sender, CheckedChangedEventArgs e)
    {
        UpdateListMobs(MonstresDejaVu);
    }

    private void CheckedPasVu(object sender, CheckedChangedEventArgs e)
    {
        UpdateListMobs(MonstresDejaVu);
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}