using System;
using System.Text;

namespace Donut
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sphere s1 = new Sphere();

            s1.Position = new Vector3(1, 1, 6);
            s1.Radius = 1;

            Sphere s2 = new Sphere();

            s2.Position = new Vector3(-1, 1, 6);
            s2.Radius = 1;

            Camera cam = new Camera();

            cam.Position = new Vector3(0, 1, 0);
            
            cam.Zoom = 3;

            cam.ShowImage(s1, s2);

            Console.ReadKey();
            
            

        }
    }
}
