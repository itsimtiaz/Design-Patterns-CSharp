namespace Design_Patterns_CSharp.CreationalPatterns;

interface ICalendarBase
{
    void MakeInvitation();
}

class TestCalender : ICalendarBase
{
    public void MakeInvitation()
    {
        Console.WriteLine($"Making invitation from test calender.");
    }
}

class AnotherCalender : ICalendarBase
{
    public void MakeInvitation()
    {
        Console.WriteLine($"Making invitation from another calender.");
    }
}

abstract class CalendarBase
{
    public void SendInvitation()
    {
        var calender = GetCalendar();
        calender.MakeInvitation();
    }

    protected abstract ICalendarBase GetCalendar();
}

class TestCalenderHandler : CalendarBase
{
    protected override ICalendarBase GetCalendar()
    {
        return new TestCalender();
    }
}

class AnotherCalenderHandler : CalendarBase
{
    protected override ICalendarBase GetCalendar()
    {
        return new AnotherCalender();
    }
}

public class FactoryMethodPatternDemo
{
    public static void Run()
    {
        CalendarBase calender = new TestCalenderHandler();
        calender.SendInvitation();
    }
}