using ERSTES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERSTES
{
    public class ProduktManager

    {

        private static int Counter = 0; // Statischer Zähler

        private static List<Produkt> ProduktList = new List<Produkt>();

        private const string FileName = "produkt.json";

        // Create: Hinzufügen ein neues Produktes zur Liste

        public static void AddProdukt(Produkt produkt)

        {

            produkt.ProduktId = ++Counter; // Zuerst inkrementieren, dann verwenden

            ProduktList.Add(produkt);

        }

        // Read: Abrufen eines Produktes anhand seiner ID

        public static Produkt GetProduktById(int id)

        {

            return ProduktList.FirstOrDefault(p => p.ProduktId == id);

        }

        // Read: Abrufen aller Produkte

        public static List<Produkt> GetAllProdukte()

        {

            return ProduktList;

        }

        // Update: Ändern der Details eines bestimmten Produktes

        public static void UpdateProdukt(int id, string produktName, string beschreibung)

        {

            var produkt = GetProduktById(id);

            if (produkt != null)

            {

                // Leere Einträge werden übersprungen (unverändert gelassen)

                if (produktName != string.Empty) produkt.ProduktName = produktName;

                if (beschreibung != string.Empty) produkt.Beschreibung = beschreibung;

            }

            else

            {

                // Ein Fehler kann hier geworfen oder eine Nachricht zurückgegeben werden,

                // dass das Produkt nicht gefunden wurde.

            }

        }

        // Delete: Löschen eines bestimmten Produktes aus der Liste

        public static void DeleteProdukt(int id)

        {

            var produkt = GetProduktById(id);

            if (produkt != null)

            {

                ProduktList.Remove(produkt);

            }

            else

            {

                // Ein Fehler kann hier geworfen oder eine Nachricht zurückgegeben werden,

                // dass das Produkt nicht gefunden wurde.

            }

        }
        public static void SaveProdukteToJSON()

        {

            // using Newtonsoft.Json; EINTRAGEN - Für .NET Core 4 oder früher

            // var jsonString = JsonConvert.SerializeObject(PersonList, Formatting.Indented);

            // using System.Text.Json; EINTRAGEN - Für .NET Core 5 oder höher

            var jsonString = JsonSerializer.Serialize(ProduktList, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FileName, jsonString);

        }



        public static void LoadProdukteFromJSON()
        {

            if (File.Exists(FileName))

            {

                var jsonString = File.ReadAllText(FileName);

                // using Newtonsoft.Json; EINTRAGEN - Für .NET Core 4 oder früher

                // ProduktList = JsonConvert.DeserializeObject<List<Produkt>>(jsonString);

                // using System.Text.Json; EINTRAGEN - Für .NET Core 5 oder höher

                ProduktList = JsonSerializer.Deserialize<List<Produkt>>(jsonString);

            }

            else

            {

                Console.WriteLine($"Datei {FileName} wurde nicht gefunden.");

            }

        }

        public static void ClearProdukte()
        {

            ProduktList.Clear();

        }

    }
}