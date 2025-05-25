namespace Design_Patterns_CSharp.CreationalPatterns;

interface IShape { }

class Circle : IShape { }

class Rectangle : IShape { }

class ShapeFactory
{
    public static IShape GetShape(string input) => input switch
    {
        "circle" => new Circle(),
        "rectangle" => new Rectangle(),
        _ => throw new NotImplementedException()
    };
}

public class FactoryPatternDemo
{
    public static void Run()
    {
        var circleShape = ShapeFactory.GetShape("circle");

        var rectangleShape = ShapeFactory.GetShape("rectangle");
    }
}
