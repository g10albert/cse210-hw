using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("--- Polymorphism with Abstract Base Class ---");

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));
        shapes.Add(new Rectangle("Yellow", 10.0, 2.0));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Type: {shape.GetType().Name}, Color: {shape.GetColor()}, Calculated Area: {shape.GetArea():F2}");
        }
    }
}