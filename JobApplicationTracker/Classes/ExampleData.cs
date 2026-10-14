public class ExampleData
{
    public void Testers (JobManager jobManager)
    {
// Exempeldata för att testa filter, sortering, statistik och färger.
    jobManager.Applications.AddRange(new List<JobApplication>
    {
    new JobApplication
    {
        CompanyName = "Företag A",
        PositionTitle = "Utvecklare",
        Status = Status.Applied,
        ApplicationDate = DateTime.Today.AddDays(-20),
        ResponseDate = null,
        SalaryExpectation = 35000
    },
    new JobApplication
    {
        CompanyName = "Företag B",
        PositionTitle = "Testare",
        Status = Status.Applied,
        ApplicationDate = DateTime.Today.AddDays(-5),
        ResponseDate = null,
        SalaryExpectation = 32000
    },
    new JobApplication
    {
        CompanyName = "Företag C",
        PositionTitle = "Backendutvecklare",
        Status = Status.Interview,
        ApplicationDate = DateTime.Today.AddDays(-10),
        ResponseDate = DateTime.Today.AddDays(-3),
        SalaryExpectation = 38000
    },
    new JobApplication
    {
        CompanyName = "Företag D",
        PositionTitle = "Frontendutvecklare",
        Status = Status.Offer,
        ApplicationDate = DateTime.Today.AddDays(-15),
        ResponseDate = DateTime.Today.AddDays(-5),
        SalaryExpectation = 36000
    },
    new JobApplication
    {
        CompanyName = "Företag E",
        PositionTitle = "IT-support",
        Status = Status.Rejected,
        ApplicationDate = DateTime.Today.AddDays(-8),
        ResponseDate = DateTime.Today.AddDays(-2),
        SalaryExpectation = 30000
    }
});
    }
}