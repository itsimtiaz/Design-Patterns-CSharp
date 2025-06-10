using System;

namespace Design_Patterns_CSharp.StructuralPatterns;

record Icon(string name, string path);

class IconFactory
{
    static Dictionary<string, Icon> icons = new();

    public static Icon GetIcon(string name, string path)
    {
        if (!icons.TryGetValue(name, out var icon))
        {
            icon = new Icon(name, path);
            icons.Add(name, icon);
        }

        return icon;
    }
}

class Shape
{
    public string Name { get; set; } = null!;

    public Icon GetIcon() => IconFactory.GetIcon(Name, "app/default");
}

public class FlyWeightPatternDemo
{
    public static void Run()
    {
        List<Shape> shapes = new() { new Shape() { Name = "Circle" }, new Shape() { Name = "Rectangle" } };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Icon path for the shape {shape.Name}, {shape.GetIcon().path}");
        }
    }
}
