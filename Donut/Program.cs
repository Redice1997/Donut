using System;
using System.Text;

namespace Donut
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sphere s1 = new Sphere();

            s1.Position = new Vector3(1.2, 1, 0);
            s1.Radius = 1;

            Sphere s2 = new Sphere();

            s2.Position = new Vector3(-1.2, 1, 0);
            s2.Radius = 1;

            Camera cam = new Camera();

            cam.Position = new Vector3(0, 1, -6);
            
            cam.Zoom = 3;

            Vector3 point = new Vector3(0, 1, 0);            
            
            int t = 0;
            while (true)
            {
                cam.Position = new Vector3(-6 * Math.Sin(t * 0.01), 1, -6 * Math.Cos(t * 0.01));                
                cam.LookAt(point);
                cam.ShowImage(s1, s2);
                t++;
            }

            

            Console.ReadKey();
            
            

        }
    }
}
