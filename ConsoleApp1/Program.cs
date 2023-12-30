using GeoWall_E;


using System.Runtime.CompilerServices;
public class Program
{
    public static void Main()
    {
        Link link = new Link("point p1; draw p1; point p2; draw p2; draw line(p1,p2);");
        var a = link.ToDraw;
        int b = 5;
    }
}
