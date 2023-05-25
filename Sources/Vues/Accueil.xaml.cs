using System.Windows.Input;

namespace Vues
{
    public partial class Accueil : ContentPage
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private async void Connection_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Connexion());
        }

        private async void Inscription_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inscription());
        }

        private async void Invite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchMob());
        }
    }
}