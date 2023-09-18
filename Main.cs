using System;

public class Program
{
    public static void Main(string[] args)
    {
        // git add 'C# Code' -> git commit -m "test" -> git push
        // Test Montag morgen
        // Überschrift / Headlines 
        // branch erstellen und bearbeiten / create branch and update
        Console.WriteLine("erstes Projekt");
        Console.WriteLine("first project");

        Console.Write("Bitte geben Sie Ihr Alter ein: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int alter))
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

        Console.Write("--- Mananger ---")
        do {Console.Write($@"
Was wollen sie machen? / What do you want to do?
0 - Programm wird beendet / Program is ended
1 - Daten hinzufügen / add data
2 - Löschen der Daten / Data will be deleted
3 - 

AUSWAHL: ");
            string auswahl = Console.ReadLine();
            
            if (int.TryParse(input, out int auswahl))
            {
                switch (auswahl)
                {
                    case 0:
                        Console.WriteLine ($"auswahl / selection: {auswahl} Programm wird beendet / Program is ended");
                        break;
                    case 1:
                        Console.WriteLine ($"auswahl / selection: {auswahl}");
                        addData();
                        break;
                    case 2:
                        Console.WriteLine ($"auswahl / selection: {auswahl}");
                        deleteAllData();
                        break;
                    case 3:
                        Console.WriteLine ($"auswahl / selection: {auswahl}");
                        break;
                    default:
                        Console.WriteLine ($"auswahl / selection: {auswahl} die Zahl ist nicht die richtige. Versuche es nochmal. / The number is not the right one. Try it again.");
                        auswahl = -1;
                        break;
                }
            }
        }while(auswahl != 0);
    }

    public void deleteAllData()
    {
        Console.WriteLine ("*** Daten werden gelöscht / Data will be deleted ***");
    }

    public void addData()
    {
        Console.WriteLine ("*** Daten werden hinzugefügt / Data will be added ***");
    }
}
