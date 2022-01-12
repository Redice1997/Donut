using System;
using System.Text;

namespace Donut
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sphere s1 = new Sphere(0, 1, 0);

            Sphere s2 = new Sphere(-2, 1, 0);           
        
            Plane p1 = new Plane();
            p1.Normal = new Vector3(0, 1, 0);

            Camera cam = new Camera(0, 1, -6);                   
            cam.Zoom = 3;
            cam.SetResolution(160, 50);
            cam.LookAt(0, 1, 10);            

            int t = 0;
            while (true)
            {
                //cam.LightPos = new Vector3(-6 * Math.Sin(t * 0.1), 10, -6 * Math.Cos(t * 0.1));
                //cam.LightPos = new Vector3(cam.LightPos.x, cam.LightPos.y, cam.LightPos.z + t * 0.01);
                cam.LightPos = new Vector3(0, 1000, 0);
                cam.ShowImage(p1, s1);
                t++;
            }
            Console.ReadKey();        
            

        }
    }
}
