public class ApplicationPrinter
{
       public void PrintApplication(JobApplication application)
    {
        switch (application.Status)
            {
                // skriver ut färger
                // Case blir Satus.____ för att Status är enum.
                case Status.Offer:
                Console.ForegroundColor = ConsoleColor.Green;
                break;

                case Status.Rejected:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

                default:
                //  Återställer färgerna 
                Console.ResetColor();
                break;
            }
            //Återställer färgerna & skriver ut Summary.
            Console.WriteLine(application.GetSummary());
            Console.ResetColor();
    }



    public void ShowNumberedApplications(List<JobApplication> applications)
    {
        // Visar ansökningar med nummer så att användaren kan välja vilken som ska tas bort.
        // Listans index/positionsnummer börjar på 0, därför visas i + 1 som nummer.
        for (int i = 0; i < applications.Count; i++)
        {
            // Skriver ut ansökningar
            Console.WriteLine($"{i + 1}. {applications[i].GetSummary()}");
        }
    }
}