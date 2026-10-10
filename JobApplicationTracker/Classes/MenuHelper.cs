public class MenuHelper
{
    public void ShowMenu()
    {
        Console.WriteLine("\n =====Välkommen till Menyn!===== ");
        Console.WriteLine("1) Lägg till ny ansökan");
        Console.WriteLine("2) Visa alla ansökningar");
        Console.WriteLine("3) Filtrera efter status");
        Console.WriteLine("4) Sortera efter datum");
        Console.WriteLine("5) Visa statistik");
        Console.WriteLine("6) Uppdatera status");
        Console.WriteLine("7) Ta bort ansökan");
        Console.WriteLine("8) Visa obesvarade ansökningar äldre än 14 dagar");
        Console.WriteLine("9) Avsluta");
        Console.Write("Välj: ");
    }
}