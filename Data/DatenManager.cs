using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class DatenManager
    {
        public static void DummyDatenLaden()
        {
            ProduktManager.AddProdukt(new Produkt { ProduktId = 1, ProduktName = "Laptop", Beschreibung = "15 Zoll, Intel i7, 16GB RAM" });
            ProduktManager.AddProdukt(new Produkt { ProduktId = 2, ProduktName = "Smartphone", Beschreibung = "6 Zoll, 128GB Speicher, Dual Kamera" });
            ProduktManager.AddProdukt(new Produkt { ProduktId = 3, ProduktName = "Kaffeemaschine", Beschreibung = "1 Liter, schwarz, mit Timer" });
            ProduktManager.AddProdukt(new Produkt { ProduktId = 4, ProduktName = "Kühlschrank", Beschreibung = "200 Liter, weiß, Energieklasse A++" });
            ProduktManager.AddProdukt(new Produkt { ProduktId = 5, ProduktName = "Staubsauger", Beschreibung = "Beutellos, 800 Watt, rot" });
        }
    }
}