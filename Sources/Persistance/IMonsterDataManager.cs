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
        void saveMonsters(List<Monstre> monstres);
        List<Monstre> loadMonsters();
    }
}