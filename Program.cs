using System.Net.Mail;
using System.Security.Cryptography;
using ERSTES;
using System.Threading.Channels;
using System.Reflection.Metadata;

namespace ERSTES
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int auswahl;
            string test = "";
            do
            {
                Console.Clear(); // Hier wird der Bildschirm gelöscht
                Console.WriteLine("#### Produkte Verwalten ####");
                Console.WriteLine();
                Console.WriteLine("Bitte wählen Sie eine Option:");
                Console.WriteLine("0 - Beenden");
                Console.WriteLine("1 - ALLE - Alle Produkte auflisten");
                Console.WriteLine("2 - NEU - Neues Produkt erstellen");
                Console.WriteLine("3 - AKTUALISIEREN - Ein Produkt bearbeiten");
                Console.WriteLine("4 - LÖSCHEN - Ein Produkt löschen");
                Console.WriteLine("5 - DUMMY - Dummydaten laden");
                Console.WriteLine("6 - LADEN - Aus der Datei laden");
                Console.WriteLine("7 - SPEICHERN - In die Datei speichern");
                Console.WriteLine("8 - LEEREN - Aktuelle Liste leeren");
                Console.WriteLine("9 - DEFINITION - alle Daten mit Liter ausgeben");
                Console.WriteLine();
                Console.Write("AUSWAHL: ");

                if (int.TryParse(Console.ReadLine(), out auswahl))
                {
                    Console.WriteLine("----------------------------------");

                    switch (auswahl)
                    {
                        case 0:
                            Console.WriteLine("Programm wird beendet.");
                            break;
                        case 1:
                            // ALLE - Alle Produkte auflisten
                            ListAllProdukte();
                            break;
                        case 2:
                            // NEU - Neues Produkt erstellen
                            CreateNewProdukt();
                            break;
                        case 3:
                            // AKTUALISIEREN - Ein Produkt bearbeiten
                            UpdateProdukt();
                            break;
                        case 4:
                            // LÖSCHEN - Ein Produkt löschen
                            DeleteProdukt();
                            break;
                        case 5:
                            // DUMMY - Dummydaten laden
                            DatenManager.DummyDatenLaden();
                            Pause("Dummydaten geladen");
                            break;
                        case 6:
                            // LADEN - Aus der Datei laden
                            ProduktManager.LoadProdukteFromJSON();
                            Pause("Daten erfolgreich geladen.");
                            break;
                        case 7:
                            // SPEICHERN - In die Datei speichern
                            ProduktManager.SaveProdukteToJSON();
                            Pause("Daten erfolgreich gespeichert.");
                            break;
                        case 8:
                            // LEEREN - Aktuelle Liste leeren
                            ProduktManager.ClearProdukte();
                            Pause("Liste der Personen wurde geleert.");
                            break;
                        case 9:
                            // DEFINITION - alle Daten mit Liter ausgeben
                            Definition();
                            Pause("Daten wurden gefunden");
                            break;
                        default:
                            Pause("Ungültige Auswahl. Bitte erneut wählen.");
                            break;
                    }
                }
                else
                {
                    Pause("Bitte geben Sie eine gültige Nummer ein.");
                    auswahl = -1; // Durchlauf wiederholen
                }
            } while (auswahl != 0);
        }

        /// <summary>
        /// Die Methode 'Definition()' ist da zu da, um vom Produktmanager die Daten zuholen und dann Daten zu filtern und
        /// diese Daten mit der Methode 'ProduktAusgeben(List)' dann in die Konsole zu schreiben
        /// </summary>
        private static void Definition()
        {
            var definition = ProduktManager.Definition();
            ProduktAusgeben(definition);
        }

        /// <summary>
        /// Liste Ausgeben mit einem Übergabeparameter, für Methode verwendbar (verwendet in: Definituin())
        /// </summary>
        /// <param name="produktListe"></param>
        private static void ProduktAusgeben(List<Produkt> produktListe)
        {
            foreach (var p in produktListe)
            {
                Console.WriteLine($"ID: {p?.ProduktId}, Produktname: {p?.ProduktName}, Beschreibung: {p?.Beschreibung}");
            }
        }

        /// <summary>
        /// Ausgabe des strings der im Parameter übergeben wird und dann "--- Weiter mit ENTER ---" ausgibt und erst weiter macht, wenn eine Enter gedrückt wird
        /// </summary>
        /// <param name="message"></param>
        private static void Pause(string message = "")
        {
            Console.WriteLine();
            if (message != string.Empty) Console.WriteLine(message + "\n");
            Console.WriteLine("--- Weiter mit ENTER ---");
            Console.ReadLine();
        }

        /// <summary>
        /// Ausgabe aller Produkte in der Produktliste -> ID: ProduktId, Produktname: ProduktName, Beschreibung: Beschreibung
        /// </summary>
        static void ListAllProdukte()
        {
            Console.WriteLine(" *** Alle Einträge ***");
            Console.WriteLine();
            var produkte = ProduktManager.GetAllProdukte();

            foreach (var p in produkte)
            {
                Console.WriteLine($"ID: {p?.ProduktId}, Produktname: {p?.ProduktName}, Beschreibung: {p?.Beschreibung}");
            }
            Pause();
        }

        /// <summary>
        /// neues Produkt erstellen und in die Liste eintragen -> Name und Beschreibung per UserInput
        /// </summary>
        static void CreateNewProdukt()
        {
            Console.WriteLine(" *** Neuer Eintrag *** ");
            Console.WriteLine();
            Console.WriteLine("Bitte geben Sie den Produktnamen ein:");
            var produktName = Console.ReadLine();

            Console.WriteLine("Bitte geben Sie die Beschreibung ein:");
            var beschreibung = Console.ReadLine();

            var produkt = new Produkt { ProduktName = produktName, Beschreibung = beschreibung };
            // Hier könnte eine ID-Generierungsfunktion implementiert werden
            ProduktManager.AddProdukt(produkt);
            Pause("Produkt erfolgreich hinzugefügt.");
        }

        /// <summary>
        /// Updaten eines Produktes (per ID suchen, mit User Input)
        /// </summary>
        static void UpdateProdukt()
        {
            Console.WriteLine(" *** Eintrag Aktualisieren *** ");
            Console.WriteLine();
            Console.WriteLine("Bitte geben Sie die ID der zu bearbeitenden Produkt ein:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var produkt = ProduktManager.GetProduktById(id);
                if (produkt != null)
                {
                    Console.WriteLine($"Aktuelle Daten - Produktname: {produkt.ProduktName}, Beschreibung: {produkt.Beschreibung}");
                    Console.WriteLine("Bitte geben Sie den neuen Produktnamen ein:");
                    var produktNameNeu = Console.ReadLine();
                    Console.WriteLine("Bitte geben Sie die neue Beschreibung ein:");
                    var beschreibungNeu = Console.ReadLine();
                    ProduktManager.UpdateProdukt(id, produktNameNeu, beschreibungNeu);
                    Console.WriteLine("Produkt erfolgreich aktualisiert.");
                }
                else
                {
                    Console.WriteLine("Keine Produkt mit dieser ID gefunden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige ID.");
            }
        }

        /// <summary>
        /// Löschen eines Produktes (per ID suchen, mit User Input)
        /// </summary>
        static void DeleteProdukt()
        {
            Console.WriteLine(" *** Eintrag Löschen *** ");
            Console.WriteLine();
            Console.WriteLine("Bitte geben Sie die ID des zu löschenden Produktes ein:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var produkt = ProduktManager.GetProduktById(id);
                if (produkt != null)
                {
                    ProduktManager.DeleteProdukt(id);
                    Console.WriteLine("Produkt erfolgreich gelöscht.");
                }
                else
                {
                    Console.WriteLine("Kein Produkt mit dieser ID gefunden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige ID.");
            }
        }
    }
}