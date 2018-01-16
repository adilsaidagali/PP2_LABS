using System;

public class Rectangle
{
    public int Width, Length, Area, Perimetr;
    public float FindArea(int w, int l)
    {
        return w * l;
    }
    public int FindPerimetr(int w, int l)
    {
        return w + l + w + l;
    }
    public Rectangle()
    {
        Width = 0;
        Length = 0;
    }
    public Rectangle(int w, int l)
    {
        Width = w;
        Length = l;
        Area = FindArea(w, l);
        Perimetr = FindPerimetr(w, l);
    }
    public override string ToString()
    {
        return Width + " " + Length + " " + Perimetr + " " + Area;
    }
}
