using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
    public interface IRechercheMonstre
    {
        public List<Monstre> search(string texte, MonsterBase mb);
    }
}
