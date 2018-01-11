using System;

public class Circle
{
    public int Radius, Area;
	public Circle(int r)
	{
        Radius = r;
	}
    public Circle()
    {
        Radius = 0;
    }
    public static float FindArea(int r)
    {
        return Math.PI * r * r;
    }
    public override string ToString()
    {
        return Radius;
    }
}
