namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDate = DateTime.Now;
            Console.WriteLine($"erstes Projekt am {currentDate}");
            Console.WriteLine($"first project at {currentDate}");

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

            
        }
    }
}