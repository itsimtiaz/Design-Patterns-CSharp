namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IEditorAction
{
    void Apply(HeaderElement headerElement);
    void Apply(ParagraphElement paragraphElement);
}

class BoldAction : IEditorAction
{
    public void Apply(HeaderElement headerElement)
    {
        Console.WriteLine($"Applying bold action on header element.");
    }

    public void Apply(ParagraphElement paragraphElement)
    {
        Console.WriteLine($"Applying bold action on paragraph element.");
    }
}

class ItalicAction : IEditorAction
{
    public void Apply(HeaderElement headerElement)
    {
        Console.WriteLine($"Applying italic action on header element.");
    }

    public void Apply(ParagraphElement paragraphElement)
    {
        Console.WriteLine($"Applying italic action on paragraph element.");
    }
}

interface IElement
{
    void Accept(IEditorAction action);
}

class HeaderElement : IElement
{
    public void Accept(IEditorAction action)
    {
        action.Apply(this);
    }
}

class ParagraphElement : IElement
{
    public void Accept(IEditorAction action)
    {
        action.Apply(this);
    }
}

public class VisitorPatternDemo
{
    public static void Run()
    {

        IElement headerElement = new HeaderElement();
        IElement paragraphElement = new ParagraphElement();

        headerElement.Accept(new BoldAction());
        paragraphElement.Accept(new ItalicAction());

    }
}
