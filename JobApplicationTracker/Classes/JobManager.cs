public class JobManager
{
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
        // Om omvandlingen misslyckas skrivs detta ut.
        if (!DateTime.TryParse(applicationDateInput, out DateTime applicationDate))
        {
            Console.WriteLine("Ogiltigt datum.");
            return;
        }
        // Om datumet är före dagens datum körs detta.
        if(applicationDate.Date > DateTime.Today)
        {
            Console.WriteLine("Inskrivet datum kan INTE vara i framtiden.");
            return;
        }

        //Lön
        Console.WriteLine("Vilken lön önskar du? Ange i siffror:");
        string salaryExpectationInput = Console.ReadLine() ?? "";
        // TryParse retunerar true eller false.
        // Omvandlar till Heltal. Out skriver ett värde till variabeln salaryExpectation.
        // if körs om omvandlingen misslyckas.
        if (!int.TryParse(salaryExpectationInput, out int salaryExpectation))
        {
            Console.WriteLine("Ogiltig lön, ange i siffror.");
            return;
        }
        // Om angiven lön är mindre än 0 körs detta.
        if(salaryExpectation < 0)
        {
            Console.WriteLine("Önskad lön får inte vara negativ.");
            return;
        }

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
        // Kollar så att användarens tal kan omvandlas till heltal
        // Try.Parse retunerar true/false
        // Out skriver värde till variablen applicationNumber
        // int = heltal
        if (!int.TryParse(applicationNumberInput, out int applicationNumber))
        {
            Console.WriteLine("Ogiltigt nummer, försök igen.");
            return;
        }
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

    public void RemoveJob()
    {
        if (Applications.Count == 0)
        {
            Console.WriteLine("Det finns inga anökningar att ta bort.");
            return;
        }

        // Visar ansökningar med nummer så att användaren kan välja vilken som ska tas bort.
        // Listans index/positionsnummer börjar på 0, därför visas i + 1 som nummer.
        for (int i = 0; i < Applications.Count; i++)
        {
            // Skriver ut ansökningar
            Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
        }

        Console.WriteLine("Ange nummer på den ansökan du vill ta bort.");
        string applicationNumberInput = Console.ReadLine() ?? "";
        // Kollar så att användarens tal kan omvandlas till heltal
        // Try.Parse retunerar true/false
        // Out skriver värde till variablen applicationNumber
        // int = heltal
        if (!int.TryParse(applicationNumberInput, out int applicationNumber))
        {
            Console.WriteLine("Ogiltigt nummer, försök igen.");
            return;
        }
        // Översätter användarens nummer till listans index genom att ta bort ett.
        int index = applicationNumber - 1;

        // Kollar så valt index finns i listan
        if (index < 0 || index >= Applications.Count)
        {
            Console.WriteLine("Ogiltigt ansökningsnummer.");
            return;
        }

        // Tar bort ansökan på valt index/positionsnummer
        Applications.RemoveAt(index);
        Console.WriteLine("Ansökan har tagits bort.");
    }



    public void ShowStatistics()
    {
        // Skriver ut antal ansökningar
        Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");
        // LINQ metoden här räknar bara ansökningarna som uppfyller villkoret
        // dvs är den här ansökans status Interview
        int interviewCount = Applications.Count(a => a.Status == Status.Interview);
        Console.WriteLine($"Interview: {interviewCount}");

        int appliedCount = Applications.Count(a => a.Status == Status.Applied);
        Console.WriteLine($"Applied: {appliedCount}");

        int offerCount = Applications.Count(a => a.Status == Status.Offer);
        Console.WriteLine($"Offer: {offerCount}");

        int rejectedCount = Applications.Count(a => a.Status == Status.Rejected);
        Console.WriteLine($"Rejected: {rejectedCount}");

        // !=null säger att ett svarsdatum finns.
        var respondedApplications = Applications.Where(a => a.ResponseDate != null).ToList();
        if (respondedApplications.Count == 0)
        {
            Console.WriteLine("Finns ingen genomsnittlig svarstid då inga svar är registrerade.");
            return;
        }
        // Räknar ut genomsnitt för antal dagar mellan ansökan och första registrerat svar
        // Value hämtar datumet ifrån "DateTime?"
        // .Date jämför datum
        // TotalDays ger skillnaden i dagar
        double averageResponseTime = respondedApplications.Average(a => (a.ResponseDate.Value.Date - a.ApplicationDate).TotalDays);
        Console.WriteLine($"Genomsnittlig svarstid: {averageResponseTime} dagar");
    }


    public void ShowByStatus(Status selectedStatus)
    {
        // Om det är tomt, avsluta.
        if (Applications.Count == 0)
        {
            Console.WriteLine("Det finns inget att se här.");
            return;
        }
        // Where väljer ansökningar med den valda statusen.
        // ToList samlar resultatet i en ny lista.
        // a är en ansökan som LINQ undersöker
        // a.Status == selectedStatus kollar om ansökan har den valda statusen
        var filteredApplications = Applications.Where(a => a.Status == selectedStatus).ToList();

        if (filteredApplications.Count == 0)
        {
            Console.WriteLine($"Det finns inga ansökningar med status {selectedStatus}.");
            return;
        }

        // Skriver ut summeringen av matchande ansökan.
        foreach (JobApplication application in filteredApplications)
        {
            Console.WriteLine(application.GetSummary());
        }
    }



    public void ShowSortedByDate()
    {
        // Om det är tomt, avsluta.
        if (Applications.Count == 0)
        {
            Console.WriteLine("Det finns inget att se här.");
            return;
        }
        // Betyder att använd varje ansökans datum som sorteringsvärde.
        // OrderBy ger ut äldsta ansöknings datumet först.
        var sortedApplications = Applications.OrderBy(a => a.ApplicationDate).ToList();

        foreach (JobApplication application in sortedApplications)
        {
            Console.WriteLine(application.GetSummary());
        }
    }
}