using System;

public class Rectangle
{
    public int Width, Length;
    public Rectangle(int w, int l)
    {
        Width = w;
        Length = l;
    }
    public static float FindArea(int w, int l)
    {
        return w * l;
    }
    public static int FindPerimetr(int w, int l)
    {
        return w + l + w + l;
    }
    public Rectangle()
    {
        Width = 0;
        Length = 0;
    }
    public override string ToString()
    {
        return Width + " " + Length;
    }
}
