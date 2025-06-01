namespace Design_Patterns_CSharp.StructuralPatterns;

interface ITv
{
    void On();
    void Off();
    void SwitchChannel(int channel);
}

class SonyTv : ITv
{
    public void Off()
    {
        Console.WriteLine($"Turning off sony tv.");
    }

    public void On()
    {
        Console.WriteLine($"Turning on sony tv.");
    }

    public void SwitchChannel(int channel)
    {
        Console.WriteLine($"Switching channel to {channel} on sony tv.");
    }
}

class LgTv : ITv
{
    public void Off()
    {
        Console.WriteLine($"Turning off lg tv.");
    }

    public void On()
    {
        Console.WriteLine($"Turning on lg tv.");
    }

    public void SwitchChannel(int channel)
    {
        Console.WriteLine($"Switching channel to {channel} on lg tv.");
    }
}

abstract class RemoteBase
{
    protected readonly ITv tv;

    public RemoteBase(ITv tv)
    {
        this.tv = tv;
    }

    public void TurnOn() => tv.On();

    public void TurnOff() => tv.Off();
}

class BasicRemote : RemoteBase
{
    public BasicRemote(ITv tv) : base(tv)
    {
    }
}

class AdvanceRemote : RemoteBase
{
    public AdvanceRemote(ITv tv) : base(tv)
    {
    }

    public void SwitchChannel(int channel) => tv.SwitchChannel(channel);
}

public class BridgePatternDemo
{
    public static void Run()
    {
        BasicRemote basicRemote = new(new SonyTv());
        basicRemote.TurnOn();
        basicRemote.TurnOff();
    }
}
