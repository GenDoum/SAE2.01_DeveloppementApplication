using Model;

namespace Vues;

public partial class Connexion : ContentPage
{
    string id;
    string mdp;

    public Connexion()
	{
		InitializeComponent();
        BindingContext = (Application.Current as App).userManager;
    }

	public async void ValiderClicked(object sender, EventArgs e)
	{
        id = IdEntry.Text;
        mdp = PsswEntry.Text;
        foreach (User u in (Application.Current as App).userManager.ListUsers)
        {
            if ((Application.Current as App).userManager.checkIfExists(id, mdp) && u.verifyPssw(mdp))
            {
                (Application.Current as App).User = u;
                await Navigation.PushAsync(new SearchMob());
                return;
            }
        }
        resultLabel.IsVisible = true;
        return;
    }

    private void IdEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        resultLabel.IsVisible = false;
    }

    /*
    private void Id_Entry_Completed(object sender, EventArgs e)
    {
        id = ((Entry)sender).Text;
    }

    private void Mdp_Entry_Completed(object sender, EventArgs e)
    {
        mdp = ((Entry)sender).Text;
    }*/
}