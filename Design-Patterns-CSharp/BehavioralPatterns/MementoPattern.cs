namespace Design_Patterns_CSharp.BehavioralPatterns;

record EditorProperties(string Title, string Content);

class EditorHistory
{
    readonly Stack<EditorProperties> history = new();

    public void Push(EditorProperties properties) => history.Push(properties);

    public EditorProperties Pop() => history.Pop();

    public bool HasHistory() => history.Any();
}

class Editor
{
    private string _title = string.Empty;
    private string _content = string.Empty;

    public void SetTitle(string title) => _title = title;

    public void SetContent(string content) => _content = content;

    public EditorProperties CreateSession() => new(_title, _content);

    public void Restore(EditorProperties properties)
    {
        _title = properties.Title;
        _content = properties.Content;
    }

    public string Title => _title;
    public string Content => _content;
}

public class MementoPatternDemo
{
    public static void Run()
    {
        Editor editor = new();
        EditorHistory history = new();

        editor.SetTitle("Editor Title");
        editor.SetContent("Some Random Content.");

        history.Push(editor.CreateSession());

        editor.SetTitle("Editor Title Updated");

        if (history.HasHistory())
            editor.Restore(history.Pop());

        Console.WriteLine($"Editor Title: {editor.Title}");
        Console.WriteLine($"Editor Content: {editor.Content}");
    }
}
