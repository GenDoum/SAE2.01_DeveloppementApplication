using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modèle
{
    public class Apparence
    {
        public string Nom { get; set; }

        public string ImageLink { get; init; }
        public Apparence(string name) {
            Nom = name;
            ImageLink = name.ToLower() + ".png";
        }
    }
}
