namespace Design_Patterns_CSharp.BehavioralPatterns;

abstract class WebServerBase
{
    private readonly WebServerBase? _next;

    public WebServerBase(WebServerBase? next)
    {
        _next = next;
    }

    public void Handle(string file)
    {
        if (!HasHandle(file))
        {
            if (_next is not null)
                _next.Handle(file);
            else
                throw new ArgumentException("File type is not supported.");
        }

    }

    protected abstract bool HasHandle(string file);
    protected abstract IEnumerable<string> AllowedFileExtensions { get; }
}

class TextFileHandler : WebServerBase
{
    public TextFileHandler(WebServerBase? next) : base(next)
    {
    }

    protected override IEnumerable<string> AllowedFileExtensions => [".txt"];

    protected override bool HasHandle(string file)
    {
        if (AllowedFileExtensions.Contains(Path.GetExtension(file)))
        {
            Console.WriteLine($"File handled in the {nameof(TextFileHandler)}.");
            return true;
        }

        return false;
    }
}

class PDFFileHandler : WebServerBase
{
    public PDFFileHandler(WebServerBase? next) : base(next)
    {
    }

    protected override IEnumerable<string> AllowedFileExtensions => [".pdf"];

    protected override bool HasHandle(string file)
    {
        if (AllowedFileExtensions.Contains(Path.GetExtension(file)))
        {
            Console.WriteLine($"File handled in the {nameof(PDFFileHandler)}.");
            return true;
        }

        return false;
    }
}

class FileServer
{
    private readonly WebServerBase _webServer;

    public FileServer(WebServerBase webServer)
    {
        _webServer = webServer;
    }

    public void HandleFile(string file)
    {
        try
        {
            _webServer.Handle(file);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

}

public class ChainOfResponsibilityDemo
{
    public static void Run()
    {
        var textFileHandler = new TextFileHandler(null);
        var pdfFileHandler = new PDFFileHandler(textFileHandler);

        var fileHandler = new FileServer(pdfFileHandler);
        fileHandler.HandleFile("file.jpeg");
    }
}
