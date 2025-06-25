namespace Design_Patterns_CSharp.BehavioralPatterns;

interface IExpression
{
    int Interpreter();
}

class ConstantExpression : IExpression
{
    private readonly int item;

    public ConstantExpression(int item)
    {
        this.item = item;
    }

    public int Interpreter() => item;
}

class SumExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public SumExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    public int Interpreter() => _left.Interpreter() + _right.Interpreter();
}

public class InterpreterDemo
{
    public static void Run()
    {
        var firstNumber = new ConstantExpression(1);
        var secondNumber = new ConstantExpression(2);

        var result = new SumExpression(firstNumber, secondNumber);
        Console.WriteLine(result.Interpreter());
    }
}
