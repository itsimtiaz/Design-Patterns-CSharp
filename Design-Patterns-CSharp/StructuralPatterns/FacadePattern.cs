namespace Design_Patterns_CSharp.StructuralPatterns;

interface IEmail
{
    void Send();
}

class EmailService : IEmail
{
    public void Send()
    {
        Console.WriteLine($"Sending an email from the app service.");
    }
}

class GoogleServiceHandler : IEmail
{
    private readonly GoogleAuth auth;
    private readonly GoogleService service;

    public GoogleServiceHandler(GoogleAuth auth, GoogleService service)
    {
        this.auth = auth;
        this.service = service;
    }
    public void Send()
    {
        service.Connect();
        auth.Auth();
        service.Send();
        service.Disconnect();
    }
}

class GoogleAuth
{
    public void Auth() { }
}

class GoogleService
{
    public void Connect() { }
    public void Send()
    {
        Console.WriteLine($"Sending an email from Google.");
    }
    public void Disconnect() { }
}

public class FacadePatternDemo
{
    public static void Run()
    {
        IEmail appEmail = new EmailService();
        appEmail.Send();

        IEmail googleEmail = new GoogleServiceHandler(new GoogleAuth(), new GoogleService());
        googleEmail.Send();
    }
}
