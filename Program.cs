using System;
using System.Collections;

namespace ERSTES
{
    public class Program
    {
        // delegate erstellen
        private delegate void Handy(string nachricht);

        public static void Main(string[] args)
        {
            System.Console.WriteLine("------------------------------------MT4Hashset--------------------------------------");

            // In C# ist ein HashSet eine Datenstruktur, die eine ungeordnete Sammlung von eindeutigen Elementen speichert.
            // Ein HashSet basiert auf der Hashtabelle und bietet eine effiziente Suche, Einfügung und Entfernung von Elementen.
            // Es gehört zur System.Collections.Generic-Namespace.
            // HashSet aufstellung erstellen
            HashSet<int> aufstellung = new HashSet<int>();

            // HashSet aufstellung befüllen
            aufstellung.Add(1);
            aufstellung.Add(2);
            aufstellung.Add(3);
            aufstellung.Add(4);

            // eintrag entfernen
            aufstellung.Remove(4);

            // überprüfung ob ein eintrag vorhanden ist oder nicht
            if(aufstellung.Contains(5))
            {
                System.Console.WriteLine("ist vorhanden");
            } else {
                System.Console.WriteLine("ist NICHT vorhanden");
            }

            // HashSet auflisten
            foreach(var eintrag in aufstellung)
            {
                System.Console.WriteLine(eintrag);
            }


            System.Console.WriteLine("-----------------------------------MT4Hashtable-------------------------------------");

            // In C# ist Hashtable eine ältere Datenstruktur, die in der .NET Framework-Klasse System.Collections definiert ist.
            // Eine Hashtable ist eine Datenstruktur, die Schlüssel-Wert-Paare speichert, wobei sie eine effiziente Zuordnung von Schlüsseln zu Werten ermöglicht.
            // Im Gegensatz zu Dictionary<TKey, TValue> (einer neueren Generics-basierten Datenstruktur) kann Hashtable beliebige Objekte als Schlüssel und Werte verwenden, da sie nicht generisch ist.
            // Hashtable erstellen
            Hashtable hashtable = new Hashtable();

            // Hashtable hashtable befüllen
            hashtable.Add("Peter",1);
            hashtable.Add("Markus",2);
            hashtable.Add("Erika",3);
            hashtable.Add("Lisa",4);

            // überprüfung ob ein key oder value vorhanden ist oder nicht
            if(hashtable.ContainsKey("Peter") || hashtable.ContainsValue(3))
            {
                System.Console.WriteLine("ist vorhanden");
            } else {
                System.Console.WriteLine("ist NICHT vorhanden");
            }

            // Hashtable hashtable auslesen
            foreach(var eintrag in hashtable)
            {
                System.Console.WriteLine($"Eintrag:{eintrag}");
            }

            System.Console.WriteLine("-----------------------------------MT4Dictionary-------------------------------------");

            // In C# ist eine Dictionary eine Datenstruktur, die Schlüssel-Wert-Paare speichert und einen schnellen Zugriff auf Werte über eindeutige Schlüssel ermöglicht.
            // Es gehört zur System.Collections.Generic-Namespace und basiert auf der generischen Klasse Dictionary<TKey, TValue>, wobei TKey den Typ des Schlüssels und TValue den Typ des Werts angibt.
            // erstellen eines Dictionarys
            Dictionary<string, int> datenbank = new Dictionary<string, int>(){};

            // Dictionary datenbank befüllen
            datenbank.Add("Peter", 12);
            datenbank.Add("Markus", 59);
            datenbank.Add("Erika", 37);
            datenbank.Add("Lisa", 42);

            // Dictionary datenbank einträge löschen (nur den schlüssel eintragen)
            datenbank.Remove("Lisa");

            // überprüfung ob ein key oder value vorhanden ist oder nicht
            if(datenbank.ContainsKey("Peter") || datenbank.ContainsValue(59))
            {
                Console.WriteLine("ist vorhanden");
            } else {
                System.Console.WriteLine("ist NICHT vorhanden");
            }

            // Dictionary datenbank auslesen
            foreach(var eintrag in datenbank)
            {
                System.Console.WriteLine($"DictionaryKey:{eintrag.Key},DictionaryValue:{eintrag.Value}");
            }

            System.Console.WriteLine("-------------------------------------MT4Stack----------------------------------------");

            // Ein Stack (Stapel) ist eine Datenstruktur in der Informatik, die nach dem Prinzip "Last In, First Out" (LIFO) funktioniert.
            // Das bedeutet, dass das zuletzt hinzugefügte Element als erstes entfernt wird. Denk dir einen Stapel von Büchern vor: Das Buch, das du zuletzt auf den Stapel legst, ist das erste, das du wieder wegnehmen kannst.
            // Genau so funktioniert auch ein Stack in der Programmierung.
            // ertellen eines Stack
            Stack<int> Stapel = new Stack<int>();

            // Stack Stapel befüllen
            Stapel.Push(1);
            Stapel.Push(2);
            Stapel.Push(3);
            Stapel.Push(4);

            // eintrag entfernen
            int eintragEntfernenS = Stapel.Pop();

            // eintrag anschauen
            int eintragAnschauenS = Stapel.Peek();

            // Stack Stapel ausgeben
            foreach (int eintrag in Stapel)
            {
                System.Console.WriteLine($"Wert:{eintrag}");
            }

            System.Console.WriteLine("-------------------------------------MT4Queue----------------------------------------");

            // Eine Queue (Warteschlange) ist eine Datenstruktur in der Informatik, die nach dem Prinzip "First In, First Out" (FIFO) funktioniert.
            // Das bedeutet, dass das zuerst hinzugefügte Element auch als erstes wieder entfernt wird.
            // Denk dir eine Warteschlange vor, wie zum Beispiel eine Schlange vor einer Kasse: Die Person, die zuerst ankommt, wird als erstes bedient, und diejenigen, die später kommen, müssen sich hinten anstellen.
            // erstellen eines Queue
            Queue<int> Warteschlange = new Queue<int>();

            // Queue Warteschlange befüllen
            Warteschlange.Enqueue(1);
            Warteschlange.Enqueue(2);
            Warteschlange.Enqueue(3);
            Warteschlange.Enqueue(4);

            // eintrag entfernen
            int eintragEntfernenW = Warteschlange.Dequeue();

            // eintrag anschauen
            int eintragAnschauenW = Warteschlange.Peek();

            // Queue Warteschlankge auslesen
            foreach(int eintrag in Warteschlange)
            {
                System.Console.WriteLine($"Eintrag:{eintrag}");
            }

            System.Console.WriteLine("------------------------------------MT4Action----------------------------------------");
            
            // In C# ist Action ein vordefinierter generischer Delegattyp, der auf Methoden ohne Rückgabewert (void) verweist.
            // Ein Delegat ist in C# eine Art Zeiger auf eine Methode, der es ermöglicht, Methoden als Argumente an andere Methoden zu übergeben oder sie in Variablen zu speichern.
            // Der Action-Delegattyp ist in der System-Namespace definiert.
            // Action erstellen (mit einem Parameter)
            Action<int> action = (x) => System.Console.WriteLine($"{x}");
            
            // Action action ausführen (mit einem Parameter)
            action(2);

            System.Console.WriteLine("------------------------------------MT4Function--------------------------------------");
            
            // n C# ist Func ein vordefinierter generischer Delegattyp, der auf Methoden mit einem Rückgabewert verweist.
            // Im Gegensatz zu Action, das auf Methoden ohne Rückgabewert verweist, ermöglicht Func die Verwendung von Methoden mit Rückgabewerten.
            // Der Func-Delegattyp ist in der System-Namespace definiert und kann eine variable Anzahl von generischen Typparametern haben.
            // Func funtion erstellen (2 Parameter und einem Output)
            Func<int, int, int> function = (x, y) => x + y;

            // Func function ausführen und ausgeben
            int f = function(3,4);
            System.Console.WriteLine(f);

            // Func direkt ausgeben
            System.Console.WriteLine(function(3,4));

            System.Console.WriteLine("------------------------------------MT4Delegate--------------------------------------");

            // In C# ist ein Delegate ein Typ, der die Verweise auf Methoden speichert.
            // Es ermöglicht, Methoden als Parameter an andere Methoden zu übergeben, was besonders nützlich ist, wenn du Funktionen als Argumente an eine andere Funktion übergeben oder Funktionen in Variablen speichern möchtest.
            // Delegate-Typen werden durch die delegate-Schlüsselwort erstellt.
            // instanzieren des Delegates und zu weisung von der Methode
            Handy neueNachricht = Nachricht;

            // Aufruf des Delegaten, aufruf der Methode
            neueNachricht("Test");
        }

        // Beispiel Methode für den Delegaten
        static void Nachricht(string nachricht) {
            System.Console.WriteLine("Meine neue Nachricht: " + nachricht);
        }
    }
}