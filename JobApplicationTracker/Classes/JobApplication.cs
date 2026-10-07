public class JobApplication
{
    //Attributer/egenskaper
    public string CompanyName { get; set; } = "";
    public string PositionTitle { get; set; } = "";
    public Status Status { get; set; }
    public DateTime ApplicationDate { get; set; } // Datum när ansökan skickades
    public DateTime? ResponseDate { get; set; } // Datum svar togs emot
    public int SalaryExpectation { get; set; } //Önskad lön i KR


    // Metod
    public int GetDaysSinceApplied()
    {
        //Räknar ut skillnaden mellan dagens datum och ansökningsdatumet
        // och skickar tillbaka antal dagar.
        return (DateTime.Today - ApplicationDate.Date).Days;
    }

    // Metod
    public string GetSummary()
    {
        // Retunerar som skrivit nedan
        // ingen Console.WriteLine(); för att metoden ska ge tillbaka en string
        // och inte skrvia ut text på skärmen. 
        // Den ger texten till den som anropar värdet sen.
        return $"{CompanyName} - {PositionTitle} - {Status}";

    }

}
// Enumen definierar ansökans möjliga statusar. 
// Den ligger utanför klassen som en egen typ
// för att det inte ska bli konflikt med namnen i JobApplication.
    public enum Status
    {
        Applied,
        Interview,
        Offer,
        Rejected
    }