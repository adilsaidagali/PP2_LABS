using System;

public class Circle
{
    public float Radius, Area, Length;
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
    public Circle(float r)
    {
        Radius = r;
        Area = FindArea(r);
        Length = FindLength(r);
    }
    public override string ToString()
    {
        return Radius + " " + Area + " " + Length;
    }
}
