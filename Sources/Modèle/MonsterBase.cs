using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Cette classe permet d'initialiser une base de données de monstres, en appelant pour le
    /// moment le stub. Elle permet également de manipuler les données des monstres.
    /// </summary>
    public class MonsterBase : IRechercheMonstre
    {
        public List<Monstre> ListMonsters
        {
            get
            {
                return monsters;
            }
            private set
            {
                monsters = value;
            }
        }
        private List<Monstre> monsters = null!;

        public MonsterBase()
        {
            ListMonsters = new Stub().loadMonsters();
        }

        public List<Monstre> search(string texte, MonsterBase mb)
        {
            List<Monstre> lm = new List<Monstre>();

            foreach (Monstre m in mb.ListMonsters)
            {
                if (m.Name.Contains(texte, System.StringComparison.CurrentCultureIgnoreCase))
                   lm.Add(m);
            }
            return lm;
        }
    }
}