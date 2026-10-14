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

    public void ShowStatusFilterMenu(JobManager jobManager)
{
    Console.WriteLine("1) Applied");
        Console.WriteLine("2) Interview");
        Console.WriteLine("3) Offer");
        Console.WriteLine("4) Rejected");
        Console.WriteLine("Vilken status vill du filtrera efter?");
        string filterChoice = Console.ReadLine()?? "";
        
        switch (filterChoice)
            {
                case "1":
                jobManager.ShowByStatus(Status.Applied);
                break;


                case"2":
                jobManager.ShowByStatus(Status.Interview);
                break;


                case "3":
                jobManager.ShowByStatus(Status.Offer);
                break;


                case "4":
                jobManager.ShowByStatus(Status.Rejected);
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;

            }
}
}