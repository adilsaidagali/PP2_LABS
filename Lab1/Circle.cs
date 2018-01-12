using System;

public class Circle
{
    public float Radius;
    public Circle(float r)
    {
        Radius = r;
    }
    public Circle()
    {
        Radius = 0;
    }
    public static float FindArea(float r)
    {
        return Math.PI * r * r;
    }
    public static float FindLength(float r)
    {
        return Math.PI * 2 * r;
    }
    public override string ToString()
    {
        return Radius;
    }
}
