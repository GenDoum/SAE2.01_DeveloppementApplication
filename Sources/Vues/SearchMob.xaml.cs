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
        User user = new User("Moi", "Monchanin", "Liam", "feur", new List<Monstre> { });
        
        if (addConseilLayout != null)
        {
            var auteurEntry = addConseilLayout.Children[0] as Entry;
            var texteConseilEntry = addConseilLayout.Children[1] as Entry;

            // R�cup�rer les valeurs des champs pour ajouter un conseil
            var auteur = auteurEntry?.Text;
            var texteConseil = texteConseilEntry?.Text;

            // Ajouter le nouveau conseil � la liste des conseils du monstre s�lectionn�
            var selectedMonstre = (App.Current as App).MonstreSelectionne;
            if (selectedMonstre != null && !string.IsNullOrWhiteSpace(auteur) && !string.IsNullOrWhiteSpace(texteConseil))
            {
                var nouveauConseil = new Conseil(user, texteConseil, selectedMonstre);
                selectedMonstre.ListConseils.Add(nouveauConseil);
            }

            // R�initialiser les champs et masquer la section d'ajout de conseil
            auteurEntry.Text = string.Empty;
            texteConseilEntry.Text = string.Empty;
            addConseilLayout.IsVisible = false;
        }
    }
}	