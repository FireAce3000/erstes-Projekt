using System.Net.Mail;
using System.Security.Cryptography;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            var currentDate = DateTime.Now;
            Console.WriteLine($"erstes Projekt am {currentDate}");
            Console.WriteLine($"first project at {currentDate}");

            int alter;
            string input = "";
            do{
                Console.Write("Bitte geben Sie Ihr Alter ein: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out alter))
                {
                    if (alter >= 18)
                    {
                        Console.WriteLine("Sie sind 18 Jahre oder älter. / You are 18 years or older");
                    }
                    else
                    {
                        Console.WriteLine("Sie sind jünger als 18 Jahre. / You are yunger than 18 years old");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine ganze Zahl für Ihr Alter ein. / Invalid input. Pleas enter a qhole number for your age.");
                }
            } while (alter > 18);
            List <Person> PersonenListe = new List <Person> ();

            Person p1 = new Person() { vorname = "Max", nachname = "Mustermann", alter = 25 };
            PersonenListe.Add(p1);

            DatenAusgeben(PersonenListe);
        }

        public static void DatenAusgeben (List <Person> PersonenListe)
        {
            foreach( var p in PersonenListe)
            {
                System.Console.WriteLine($"Vorname: {p.vorname}, Nachname: {p.nachname}, alter {p.alter}");
            }
        }
    }
}