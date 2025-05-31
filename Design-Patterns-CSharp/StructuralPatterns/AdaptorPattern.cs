namespace Design_Patterns_CSharp.StructuralPatterns;

interface IEmailService
{
    void Download();
}

class Outlook : IEmailService
{
    public void Download()
    {
        Console.WriteLine($"Downloading emails from Outlook.");
    }
}

class Yahoo : IEmailService
{
    public void Download()
    {
        Console.WriteLine($"Downloading emails from Yahoo.");
    }
}

class Google
{
    public void Connect() { }
    public void Download() { }
    public void Disconnect() { }
}

class GoogleHandler : IEmailService
{
    private readonly Google service;

    public GoogleHandler(Google service)
    {
        this.service = service;
    }

    public void Download()
    {
        service.Connect();

        Console.WriteLine("Downloading emails via adapted Google service.");
        service.Download();

        service.Disconnect();
    }
}

public class AdaptorPatternDemo
{
    public static void Run()
    {
        IEmailService emailService = new Outlook();
        emailService.Download();

        emailService = new GoogleHandler(new Google());
        emailService.Download();
    }
}
