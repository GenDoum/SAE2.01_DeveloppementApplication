using Model;
using Persistance;
using System.ComponentModel;

namespace Vues
{
    public partial class App : Application
    {
        public MonsterManager monsterManager { get; private set; } = new MonsterManager(new LoaderStub());
        public UserManager userManager { get; private set; } = new UserManager(new LoaderXml());

        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private Monstre monstreSelectionne;
        public Monstre MonstreSelectionne {
            get
            {
                return monstreSelectionne;
            }
            set
            {
                monstreSelectionne = value;
                OnPropertyChanged("MonstreSelectionne");
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}