using System.Net.Mail;
using System.Security.Cryptography;
using HelloWorld;
using System.Threading.Channels;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int auswahl;

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

        private static void Pause(string message = "")

        {

            Console.WriteLine();

            if (message != string.Empty) Console.WriteLine(message + "\n");

            Console.WriteLine("--- Weiter mit ENTER ---");

            Console.ReadLine();

        }

        static void ListAllProdukte()

        {

            Console.WriteLine(" *** Alle Einträge ***");

            Console.WriteLine();

            var produkte = ProduktManager.GetAllProdukte();

            foreach (var produkt in produkte)

            {

                Console.WriteLine($"ID: {produkt.ProduktId}, Produktname: {produkt.ProduktName}, Beschreibung: {produkt.Beschreibung}");

            }

            Pause();

        }

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