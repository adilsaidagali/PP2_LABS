using System;

public class Student
{
    public string name;
    public int age;
    public float gpa;
    public Student(string n, int a, float g)
    {
        name = n;
        age = a;
        gpa = g;
    }
    public override string ToString()
    {
        return name + " " + age + " " + gpa;
    }
}