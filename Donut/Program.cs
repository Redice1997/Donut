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

            Donut d1 = new Donut();
            d1.Position = new Vector3(0, 0, 0);
            d1.Axis = new Vector3(1, 1, 1);

            Capsule c1 = new Capsule();
            c1.Radius = 0.6;            
            c1.Length = 3;
            c1.Axis = new Vector3(1, 1, 1);

            Camera cam = new Camera(0, 1, 6);                   
            cam.Zoom = 3;
            cam.SetResolution(160, 50);
            cam.LookAt(0, 0, 0);            

            int t = 0;
            while (true)
            {
                cam.LightPos = new Vector3(-6 * Math.Sin(t * 0.05), 3, -6 * Math.Cos(t * 0.05));
                //cam.LightPos = new Vector3(cam.LightPos.x, cam.LightPos.y, cam.LightPos.z + t * 0.01);
                //cam.LightPos = new Vector3(0, 1000, 0);

                //cam.Position = new Vector3(cam.Position.x, cam.Position.y, cam.Position.z + t * 0.001);
                //cam.LightPos = cam.Position;
                //cam.LookAt(0, 0, 0);
                cam.Show(c1);
                t++;
            }
            Console.ReadKey();        
            

        }
    }
}
