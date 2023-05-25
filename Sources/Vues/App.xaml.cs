using Model;
using Persistance;
using System.ComponentModel;

namespace Vues
{
    public partial class App : Application
    {
        public MonsterManager monsterManager { get; private set; } = new MonsterManager(new LoaderStub());
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
        private Monstre monstreSelectionne;
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}