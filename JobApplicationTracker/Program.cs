// Skapar objekt jobManager.
JobManager jobManager = new JobManager();

// Skapar objekt och lägger in metoden.
ExampleData exampleData = new ExampleData();
exampleData.Testers(jobManager);

// Om denna är true fortsätter programmet att köras.
bool isRunning = true;
// Skapar objekt av menyn
MenuHelper menuHelper = new MenuHelper();

while (isRunning)
{
    Console.Clear();
    // Anropar
    menuHelper.ShowMenu();
    string menuChoice = Console.ReadLine()?? "";
    Console.Clear();


    switch (menuChoice)
    {
        case "1":
        jobManager.AddJob();
        break;


        case "2":
        jobManager.ShowAll();
        break;


        case "3":
        menuHelper.ShowStatusFilterMenu(jobManager);
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

    if (isRunning)
    {
        Console.WriteLine("Tryck Enter för att återgå till Menyn.");
        Console.ReadLine();
    }

}
