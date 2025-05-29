namespace Design_Patterns_CSharp.CreationalPatterns;

interface IElement { }

class LightButton : IElement { }

class LightTextbox : IElement { }

class DarkButton : IElement { }

class DarkTextbox : IElement { }

interface ITheme
{
    IElement CreateButton();
    IElement CreateTextbox();
}

class LightTheme : ITheme
{
    public IElement CreateButton()
    {
        return new LightButton();
    }

    public IElement CreateTextbox()
    {
        return new LightTextbox();
    }
}

class DarkTheme : ITheme
{
    public IElement CreateButton()
    {
        return new DarkButton();
    }

    public IElement CreateTextbox()
    {
        return new DarkTextbox();
    }
}

class ThemeManager
{
    IElement button, textbox;

    public ThemeManager(ITheme theme)
    {
        button = theme.CreateButton();
        textbox = theme.CreateTextbox();
    }
}

class AbstractFactoryDemo
{
    public static void Run()
    {
        ITheme theme = new DarkTheme();
        ThemeManager abstractFactory = new(theme);
    }
}