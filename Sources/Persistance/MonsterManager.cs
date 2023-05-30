﻿using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class MonsterManager : IMonsterDataManager
    {
        public IMonsterDataManager Pers { get; set; }

        private ObservableCollection<Monstre> monsters = null!;
        public ObservableCollection<Monstre> ListMonsters
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
        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            Pers.saveMonsters(monstres);
        }

        ObservableCollection<Monstre> IMonsterDataManager.loadMonsters()
        {
            return Pers.loadMonsters();
        }

        public List<Monstre> search(string texte)
        {
            return (from Monstre m in ListMonsters
                    where m.Name.Contains(texte, System.StringComparison.CurrentCultureIgnoreCase)
                    select m).ToList(); // LINQ
        }

        public MonsterManager(IMonsterDataManager dataMngr)
        {
            Pers = dataMngr;
            ListMonsters = new LoaderStub().loadMonsters();
        }
    }
}
