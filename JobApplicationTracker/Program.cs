// Skapar objekt jobManager.
using System.Threading.Tasks.Dataflow;

JobManager jobManager = new JobManager();

// Om denna är true fortsätter programmet att köras.
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n =====Välkommen till Menyn!===== ");
    Console.WriteLine("1) Lägg till ny ansökan");
    Console.WriteLine("2) Visa alla ansökningar");
    Console.WriteLine("3) Filtrera efter status");
    Console.WriteLine("4) Sortera efter datum");
    Console.WriteLine("5) Visa statistik");
    Console.WriteLine("6) Uppdatera status");
    Console.WriteLine("7) Ta bort ansökan");
    Console.WriteLine("8) Avsluta");
    Console.Write("Välj: ");
    string menuChoice = Console.ReadLine()?? "";


    switch (menuChoice)
    {
        case "1":
        jobManager.AddJob();
        break;


        case "2":
        jobManager.ShowAll();
        break;


        case "3":
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
        break;


        case "4":
        // Comming soon
        break;


        case "5":
        jobManager.ShowStatistics();
        break;


        case "6":
        jobManager.UpdateStatus();
        break;


        case "7":
        jobManager.RemoveJob();
        break;


        case "8":
        isRunning = false;
        break;
    default:
        Console.WriteLine("Ogiltigt val, välj något av ovanstående alternativ.");
        break;
    }

}