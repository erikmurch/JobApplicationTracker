// Skapar objekt jobManager.
JobManager jobManager = new JobManager();

// Om denna är true fortsätter programmet att köras.
bool isRunning = true;
// Skapar objekt av menyn
MenuHelper menuHelper = new MenuHelper();

while (isRunning)
{
    // Anropar
    menuHelper.ShowMenu();
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
        ShowStatusFilterMenu();
        break;


        case "4":
        jobManager.ShowSortedByDate();
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
        jobManager.ShowUnansweredOlderThan14Days();
        break;


        case "9":
        isRunning = false;
        break;
    default:
        Console.WriteLine("Ogiltigt val, välj något av ovanstående alternativ.");
        break;

    }

}
// Metod för case 3
void ShowStatusFilterMenu()
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