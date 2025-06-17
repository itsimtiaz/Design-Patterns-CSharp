namespace Design_Patterns_CSharp.BehavioralPatterns;

abstract class WindowBase
{
    public void Close()
    {
        OnClosing();
        OnClosed();
    }

    protected abstract void OnClosing();
    protected virtual void OnClosed()
    {
        Console.WriteLine($"Window is closed.");
    }
}

class ApplicationWindow : WindowBase
{
    protected override void OnClosing()
    {
        Console.WriteLine($"Windows is about to close.");
    }
}

public class TemplatePatternDemo
{
    public static void Run()
    {
        WindowBase window = new ApplicationWindow();
        window.Close();
    }
}
