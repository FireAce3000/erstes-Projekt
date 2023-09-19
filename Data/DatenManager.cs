namespace HelloWorld
{
    class DatenManager
    {
        public static void DummyDatenLaden()
        {
            Person p1 = new Person() { vorname = "Max", nachname = "Mustermann", alter = 25 };
            Person p2 = new Person() { vorname = "Lisa", nachname = "Mustermann", alter = 35 };
            Person p3 = new Person() { vorname = "Markus", nachname = "Mustermann", alter = 75 };
            Person p4 = new Person() { vorname = "Patrick", nachname = "Mustermann", alter = 45 };
            Person p5 = new Person() { vorname = "Manuela", nachname = "Mustermann", alter = 19 };
        }
    }
}