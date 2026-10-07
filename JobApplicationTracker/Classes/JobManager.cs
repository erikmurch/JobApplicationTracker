public class JobManager
{
    //Attributer/egenskaper
    // Skapar en lista av typen JobApplication
    // Den fylls på när använaren lägger till ansökningar
    // get; låter mig hämta listan
    // set; låter mig ersätta listan, lite onödigt här.
    public List<JobApplication> Applications { get; set;} = new List<JobApplication>();


    //Metoder
    public void AddJob()
    {
        // Enbart lokala variabler här som använder uppgifterna innan ansökningsobjektet skapas.
        // ?? "" hanterar null/inget
        // om använaren bara trycker enter blir svaret en tom string.
        // Företag
        Console.WriteLine("Vilket företag har du sökt till?");
        string companyName = Console.ReadLine() ?? "";

        // Tjänst typ
        Console.WriteLine("Vilken tjänst har du sökt?");
        string positionTitle = Console.ReadLine() ?? "";

        //Datum
        Console.WriteLine("Vilket datum skickade du ansökan? Ange ÅÅÅÅ-MM-DD:");
        string applicationDateInput = Console.ReadLine() ?? "";
        // Omvandlar användarens datumtext till ett DateTime värde. 
        DateTime applicationDate = DateTime.Parse(applicationDateInput);

        //Lön
        Console.WriteLine("Vilken lön önskar du? Ange i siffror:");
        string salaryExpectationInput = Console.ReadLine() ?? "";
        //Omvandlar string till int som kan ta emot siffror
        int salaryExpectation = int.Parse(salaryExpectationInput);

        // Skapar ett objet och tilldelar den värden.
        JobApplication application = new JobApplication();
        application.CompanyName = companyName;
        application.PositionTitle = positionTitle;
        application.ApplicationDate = applicationDate;
        application.SalaryExpectation = salaryExpectation;
        application.Status = Status.Applied;
        application.ResponseDate = null;

        //Lägger till objektet i listan
        Applications.Add(application);
        Console.WriteLine("Ansökan har lagts till.");



    }

    public void UpdateStatus()
    {   
        // Om Applications(listan) är tom 
        if (Applications.Count == 0)
        {
            // Skriv ut detta
            Console.WriteLine("Det finns inga ansökningar att uppdatera.");
            return;
        }
        // Visar ansökningar med nummer så att användaren kan välja vilken som ska uppdateras.
        // Listans index/positionsnummer börjar på 0, därför visas i + 1 som nummer.
        for (int i = 0; i < Applications.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
        }

        Console.WriteLine("Ange numret på ansökan du vill updatera:");
        string applicationNumberInput = Console.ReadLine() ?? "";
        // Omvandlar string till int och döper den till applicationNumber
        int applicationNumber = int.Parse(applicationNumberInput);
        // Översätter användarens nummer till listans index genom att ta bort ett.
        int index = applicationNumber -1;

        // Gör att valet är ogitligt om index är negativt 
        // eller lika stort som listans antal eller större.
        if (index < 0 || index >= Applications.Count)
        {
            Console.WriteLine("Ogiltigt ansökningsnummer.");
            return;
        }
        //Hämtar den valda ansökan och visar möjliga val för status.
        JobApplication application = Applications[index];
        Console.WriteLine("1) Applied ");
        Console.WriteLine("2) Interview ");
        Console.WriteLine("3) Offer ");
        Console.WriteLine("4) Rejected ");
        Console.Write("Välj ny status: ");
        string statusChoice = Console.ReadLine() ?? "";

        switch (statusChoice)
        {
            case "1":
                application.Status = Status.Applied;
                // Applied betyder att ansökan väntar på svar, så svarsdatumet tas bort.
                application.ResponseDate = null;
                Console.WriteLine("Status uppdaterad till Applied.");
                break;
            case "2":
                application.Status = Status.Interview;
                // Registrerar dagens datum som första svarsdatum om inget datum finns sedan tidigare.
                if (application.ResponseDate == null)
                {
                    application.ResponseDate = DateTime.Today;
                }
                Console.WriteLine("Status uppdaterad till Interview.");
                break;
            case "3":
                application.Status = Status.Offer;
                if (application.ResponseDate == null)
                {
                    application.ResponseDate = DateTime.Today;
                }
                Console.WriteLine("Status uppdaterad till Offer.");
                break;
            case "4":
                application.Status = Status.Rejected;
                if (application.ResponseDate == null)
                {
                    application.ResponseDate = DateTime.Today;
                }
                Console.WriteLine("Status uppdaterad till Rejected.");
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
    }

    public void ShowAll()
    {
        // Om listan är tom
        if (Applications.Count == 0)
        {
            // Skriv ut detta
            Console.WriteLine("Det finns inga ansökningar.");
            return;
        } 


        // Detta block säger för varje application i listan(Applications), get summary och skriv ut den.
        foreach (JobApplication application in Applications)
        {
            Console.WriteLine(application.GetSummary());
        }
    }
}