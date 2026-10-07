using System.Security.Cryptography.X509Certificates;

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
        
    }

    public void ShowAll()
    {
        
    }
}