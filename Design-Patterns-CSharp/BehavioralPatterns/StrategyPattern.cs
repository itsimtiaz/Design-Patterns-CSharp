namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IPayment
{
    void ProcessPayment();
}

class BankingPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine($"Payment is processed through Bank.");
    }
}

class CreditCardPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine($"Payment is processed through Credit Card.");
    }
}

class PaymentHandler
{
    private readonly IPayment payment;

    public PaymentHandler(IPayment payment)
    {
        this.payment = payment;
    }

    public void Debit() => payment.ProcessPayment();
}

public class StrategyPatternDemo
{
    public static void Run()
    {
        PaymentHandler paymentHandler = new(new CreditCardPayment());

        paymentHandler.Debit();
    }
}
