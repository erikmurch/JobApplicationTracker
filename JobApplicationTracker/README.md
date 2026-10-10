# Job Application Tracker

## Projektbeskrivning: 
Detta är en C# console app där man kan lägga till jobb ansökningar och sedan följa dom samt uppdatera dom.
Ansökningarna sparas endast medans programmet är igång sedan när man avslutar programmet så försvinner ansökningarna.

## Hur man kör programmet:
Ladda ner Git.
Högerklicka på lokala mappen där du vill ha projektet och tryck på "Open git bash here"
Clonea ner repositoriet genom att skriva "git clone "URL". Alltså URL ifrån github repo. Denna länken är URL: https://github.com/erikmurch/JobApplicationTracker.git
Sedan öppnar projektet i Visual Studio Code genom att högerklicka på lokala mappen och tryck på VS code.
Sedan öppnar man terminalen i Program.cs och skriver dotnet run.
Därefter får man upp en meny där man väljer en siffra följt av enter på tangentbordet.
Man får upp olika saker beroende på vilken alternativ man valt i menyn.

## Reflektion:
1. LINQ förkortade koden, istället för att jag skulle behöva göra loopar jämförelser och andra beräkningar för varje uppgift.
T.ex här: int interviewCount = Applications.Count(a => a.Status == Status.Interview); så räknas ansökningar med status Interview utan att ha en egen loop. Koden blir mer lättläst och man slipper skriva onödigt mycket kod.

2. Det var mycket som var utmanande kände jag men det mest utmanande med detta var LINQ med tanke på att vi inte heller gått igenom det i skolan ännu, förstå hur det funka & man skulle använda det.
Löste det genom AI och Youtube som hjälpte mig förstå bättre så jag sedan kunde skriva koden.

### Erik Murch 2026/10/10