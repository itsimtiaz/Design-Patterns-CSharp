namespace Design_Patterns_CSharp.BehavioralPatterns;

class EditorService
{
    private string _title = string.Empty;
    private string _content = string.Empty;

    public string Title => _title;
    public string Content => _content;

    public void SetTitle(string title) => _title = title;

    public void SetContent(string content) => _content = content;
}

interface ICommand
{
    void Execute();
}

interface IUndoCommand : ICommand
{
    void Undo();
}

class CommandInvoker
{
    private ICommand _command;

    public CommandInvoker(ICommand command)
    {
        _command = command;
    }

    public void SetCommand(ICommand command) => _command = command;

    public void Execute() => _command.Execute();
}

class CommandsHistory
{
    readonly Stack<IUndoCommand> undoCommands = new();
    readonly Stack<IUndoCommand> redoCommands = new();

    public void Push(IUndoCommand undoCommand) => undoCommands.Push(undoCommand);

    public IUndoCommand Undo()
    {
        var command = undoCommands.Pop();
        redoCommands.Push(command);
        return command;
    }

    public IUndoCommand Redo()
    {
        var command = redoCommands.Pop();
        undoCommands.Push(command);
        return command;
    }

    public bool CanUndo => undoCommands.Any();
    public bool CanRedo => redoCommands.Any();

}

class UndoCommandInvoker
{
    private readonly CommandsHistory commandsHistory;

    public UndoCommandInvoker(CommandsHistory commandsHistory)
    {
        this.commandsHistory = commandsHistory;
    }

    public void Undo()
    {
        if (commandsHistory.CanUndo)
            commandsHistory.Undo().Undo();
    }

    public void Redo()
    {
        if (commandsHistory.CanRedo)
            commandsHistory.Redo().Execute();
    }
}

class SetTitleCommand : IUndoCommand
{
    private readonly EditorService editorService;
    private readonly CommandsHistory commandsHistory;
    private readonly string title;
    private string previousTitle = string.Empty;
    public SetTitleCommand(EditorService editorService, CommandsHistory commandsHistory, string title)
    {
        this.editorService = editorService;
        this.commandsHistory = commandsHistory;
        this.title = title;
    }
    public void Execute()
    {
        previousTitle = editorService.Title;

        editorService.SetTitle(title);

        commandsHistory.Push(this);
    }

    public void Undo()
    {
        editorService.SetTitle(previousTitle);
    }
}

class SetContentCommand : IUndoCommand
{
    private readonly EditorService editorService;
    private readonly CommandsHistory commandsHistory;
    private readonly string content;
    private string previousContent = string.Empty;
    public SetContentCommand(EditorService editorService, CommandsHistory commandsHistory, string content)
    {
        this.editorService = editorService;
        this.commandsHistory = commandsHistory;
        this.content = content;
    }
    public void Execute()
    {
        previousContent = editorService.Content;
        editorService.SetContent(content);
        commandsHistory.Push(this);
    }

    public void Undo()
    {
        editorService.SetContent(previousContent);
    }
}

public class CommandPatternDemo
{
    public static void Run()
    {
        CommandsHistory commandsHistory = new();
        EditorService editorService = new();

        CommandInvoker commandInvoker = new(new SetTitleCommand(editorService, commandsHistory, "First Title"));
        commandInvoker.Execute();
        PrintStatus(editorService);

        commandInvoker.SetCommand(new SetContentCommand(editorService, commandsHistory, "First Content"));
        commandInvoker.Execute();
        PrintStatus(editorService);

        commandInvoker.SetCommand(new SetTitleCommand(editorService, commandsHistory, "Second Title"));
        commandInvoker.Execute();
        PrintStatus(editorService);

        Console.WriteLine($"\n----------- Undoing Commands -----------\n");

        UndoCommandInvoker undoCommandInvoker = new(commandsHistory);
        undoCommandInvoker.Undo();
        PrintStatus(editorService);

        undoCommandInvoker.Undo();
        PrintStatus(editorService);

        undoCommandInvoker.Undo();
        PrintStatus(editorService);

        Console.WriteLine($"\n----------- Redo Commands -----------\n");

        undoCommandInvoker.Redo();
        PrintStatus(editorService);

        undoCommandInvoker.Redo();
        PrintStatus(editorService);

        undoCommandInvoker.Redo();
        PrintStatus(editorService);
    }

    static void PrintStatus(EditorService editorService)
    {
        Console.WriteLine($"Title: {editorService.Title}");
        Console.WriteLine($"Content: {editorService.Content}");
    }
}
