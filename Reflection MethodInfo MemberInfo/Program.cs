using System;
using System.Reflection;

//ref link:https://www.youtube.com/watch?v=T51j0DaBynE&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=25
// Dynamic Reflection
// ORM (Object relational mapping)

class Vector
{
    public float X { get; set; }
    public float Y { get; set; }
    public override string ToString()
    {
        return "{ X: " + X + ", Y: " + Y + " }";
    }
}

class MainClass
{
    static void Main()
    {
        //Vector vec = new Vector { X = 4, Y = 9 };
        Vector vec = new Vector();
        vec.X = 4;
        vec.Y = 9;
        Console.WriteLine(vec.ToString());

        // ----Dynamic Reflection----
        Type vecType = typeof(Vector); // + - * /
        Vector vec2 = Activator.CreateInstance(vecType) as Vector;
        PropertyInfo xPropInfo = vecType.GetProperty("X");
        PropertyInfo yPropInfo = vecType.GetProperty("Y");
        xPropInfo.SetValue(vec2, 4, null); 
        yPropInfo.SetValue(vec2, 9, null);
        MethodInfo toStringInfo = vecType.GetMethod("ToString");
        string result = toStringInfo.Invoke(vec2, null) as String;
        MethodInfo writeLineInfo = typeof(Console).GetMethod("WriteLine", 
            new[] { typeof(string) });
            //new[] { typeof(string), typeof(int), typeof(char) });
        writeLineInfo.Invoke(null, new[] { result });
        //writeLineInfo.Invoke(null, new object[] { 4.5f });
    }
}