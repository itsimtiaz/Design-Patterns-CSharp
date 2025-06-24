namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IChatClient
{
    void SendMessage(string message);
    void ReceivedMessage(string message);
}

interface IChatServer
{
    void AddClient(IChatClient client);
    void SendMessage(string message, IChatClient sender);
}

class ChatServer : IChatServer
{
    readonly List<IChatClient> clients;
    public ChatServer()
    {
        clients = new List<IChatClient>();
    }

    public void AddClient(IChatClient client)
    {
        clients.Add(client);
    }

    public void SendMessage(string message, IChatClient sender)
    {
        foreach (var client in clients)
        {
            if (client == sender)
                continue;

            client.ReceivedMessage(message);
        }
    }
}

class ChatClient : IChatClient
{
    private readonly IChatServer chatServer;

    public ChatClient(IChatServer chatServer)
    {
        this.chatServer = chatServer;
        chatServer.AddClient(this);
    }

    public void ReceivedMessage(string message)
    {
        Console.WriteLine($"Message Received: {message}");
    }

    public void SendMessage(string message)
    {
        chatServer.SendMessage(message, this);
    }
}

public class MediatorPatternDemo
{
    public static void Run()
    {
        IChatServer chatServer = new ChatServer();

        IChatClient firstClient = new ChatClient(chatServer);
        IChatClient secondClient = new ChatClient(chatServer);

        firstClient.SendMessage("Hello from the first client.");
        secondClient.SendMessage("Hello from the second client.");
    }
}
