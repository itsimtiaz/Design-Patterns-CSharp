using System;

namespace Design_Patterns_CSharp.BehavioralPatterns;

interface ISignal
{
    void SwitchSignal(SignalHandler signalHandler);
    string GetStatus();
}

class GreenSignal : ISignal
{
    public string GetStatus() => "Green";

    public void SwitchSignal(SignalHandler signalHandler)
    {
        signalHandler.SetSignal(new YellowSignal());
    }
}

class YellowSignal : ISignal
{
    public string GetStatus() => "Yellow";

    public void SwitchSignal(SignalHandler signalHandler)
    {
        signalHandler.SetSignal(new RedSignal());
    }
}

internal class RedSignal : ISignal
{
    public string GetStatus() => "Red";

    public void SwitchSignal(SignalHandler signalHandler)
    {
        signalHandler.SetSignal(new GreenSignal());
    }
}

class SignalHandler
{
    private ISignal _signal;

    public SignalHandler(ISignal signal)
    {
        this._signal = signal;
    }

    public void SetSignal(ISignal signal) => _signal = signal;

    public void ChangeSignal() => _signal.SwitchSignal(this);

    public string GetStatus() => _signal.GetStatus();
}

public class StatePatternDemo
{
    public static void Run()
    {
        SignalHandler signalHandler = new(new GreenSignal());
        PrintSignalStatus(signalHandler);

        signalHandler.ChangeSignal();
        PrintSignalStatus(signalHandler);

        signalHandler.ChangeSignal();
        PrintSignalStatus(signalHandler);
    }

    private static void PrintSignalStatus(SignalHandler signalHandler) =>
            Console.WriteLine($"Signal Status: {signalHandler.GetStatus()}");

}
