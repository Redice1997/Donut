using System;
using System.Text;

namespace Donut
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sphere s1 = new Sphere();

            s1.Position = new Vector3(2, 1, 0);
            s1.Radius = 1;

            Sphere s2 = new Sphere();

            s2.Position = new Vector3(-2, 1, 0);
            s2.Radius = 1;

            Plane p1 = new Plane();

            Camera cam = new Camera();

            cam.Position = new Vector3(0, 1, -6);            
            cam.Zoom = 3;
            cam.SetResolution(160, 60);

            cam.LookAt(0, 1, 10);            

            int t = 0;
            while (true)
            {
                cam.LightPos = new Vector3(20 * Math.Sin(t * 0.02), 20, 20 * Math.Cos(t * 0.02));                
                cam.ShowImage(s1, s2);
                t++;
            }


            Console.ReadKey();
            
            

        }
    }
}
