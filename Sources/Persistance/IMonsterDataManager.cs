using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface IMonsterDataManager
    {
        public void saveMonsters(List<Monstre> monstres);
        public List<Monstre> loadMonsters();
    }
}