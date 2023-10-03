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
        /// <summary>
        /// Create: Hinzufügen ein neues Produktes zur Liste
        /// </summary>
        /// <param name="produkt"></param>
        public static void AddProdukt(Produkt produkt)
        {
            produkt.ProduktId = ++Counter; // Zuerst inkrementieren, dann verwenden
            ProduktList.Add(produkt);
        }

        // Read: Abrufen eines Produktes anhand seiner ID
        /// <summary>
        /// Read: Abrufen eines Produktes anhand seiner ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Produkt GetProduktById(int id)
        {
            return ProduktList.FirstOrDefault(p => p.ProduktId == id);
        }

        // Read: Abrufen aller Produkte
        /// <summary>
        /// Read: Abrufen aller Produkte
        /// </summary>
        /// <returns></returns>
        public static List<Produkt> GetAllProdukte()
        {
            return ProduktList;
        }

        // Read: Definition
        /// <summary>
        /// Read: Definition
        /// </summary>
        /// <returns></returns>
        public static List<Produkt> Definition()
        {
            var definition = ProduktList;
            definition = definition.Where(x => x.Beschreibung.Contains("Liter")).ToList();
            return definition;
        }

        // Update: Ändern der Details eines bestimmten Produktes
        /// <summary>
        /// Update: Ändern der Details eines bestimmten Produktes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produktName"></param>
        /// <param name="beschreibung"></param>
        /// <exception cref="ArgumentException"></exception>
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
                // Ein Fehler kann hier geworfen oder eine Nachricht zurückgegeben werden, dass das Produkt nicht gefunden wurde.
                throw new ArgumentException("Das Produkt wurde nicht gefunden");
            }
        }

        // Delete: Löschen eines bestimmten Produktes aus der Liste
        /// <summary>
        /// Delete: Löschen eines bestimmten Produktes aus der Liste
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void DeleteProdukt(int id)
        {
            var produkt = GetProduktById(id);
            if (produkt != null)
            {
                ProduktList.Remove(produkt);
            }
            else
            {
                // Ein Fehler kann hier geworfen oder eine Nachricht zurückgegeben werden, dass das Produkt nicht gefunden wurde.
                throw new ArgumentException("Das Produkt wurde nicht gefunden");
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