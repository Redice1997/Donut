using System;
using System.Linq;
using System.Collections.Generic;

namespace Donut
{

    public class Camera
    {
        public Camera() { }
        public Camera(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
            LightPos = Position;
        }

        private const double PIXEL_ASPECT = 0.5;
        private const int MAX_STEPS = 100;
        private const double MAX_DIST = 100;
        private const double SURF_DIST = 0.01;

        public double Zoom { get; set; } = 1;
        public Vector3 Position { get; set; }        
        public Vector3 LightPos { get; set; }

        private Vector3 front = new Vector3(0, 0, 1);
        private Vector3 Front
        {
            get
            {
                return front;
            }
            set
            {
                front = value.Normalized();
            }
        }

        private Vector3 Up { get => Vector3.Cross(Right, Front); }
        private Vector3 Right { get => Vector3.Cross(new Vector3(0, 1, 0), Front); }

        private Vector3 direction;
        private Vector3 Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value.Normalized();
            }
        }        

        private int xres = 120;
        private int xResolution 
        { 
            get => xres; 
            set => xres = Math.Clamp(value, 10, 200); 
        }
        private int yres = 30;
        private int yResolution 
        {
            get => yres;
            set => yres = Math.Clamp(value, 5, 100);
        }       
               

        public void SetPosition(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
        }
        public void LookAt(Vector3 point)
        {
            Front = point - Position;
        }
        public void LookAt(double x, double y, double z)
        {
            Front = new Vector3(x,y,z) - Position;
        }
        public void SetResolution(int width, int height)
        {
            xResolution = width;
            yResolution = height;
        }


        public void ShowImage(params Shape[] shapes)
        {
            char[] image = new char[xResolution * yResolution];
            char[] grad = { ' ', '.', ':', '!', '/', '(', 'l', '1', 'Z', 'H', '9', '9', 'W', '8', '$', '@' };
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(xResolution, yResolution);
            Console.SetBufferSize(xResolution, yResolution);
            Console.CursorVisible = false;

            for (int i = 0; i < xResolution; i++)
            {
                for (int j = 0; j < yResolution; j++)
                {
                    GeneratePixel(out double Intensity, new Vector2(i, j), shapes);
                    Intensity = Math.Clamp(Intensity, 0, 1);
                    image[i + j * xResolution] = grad[(int)(Intensity * (grad.Length - 1))];
                }
            }

            Console.Write(image);
            Console.SetCursorPosition(0, 0);
        }        

        private void GeneratePixel(out double Intensity, in Vector2 pCoord, params Shape[] shapes)
        {
            // Преобразование координат
            double x = pCoord.x / xResolution * 2 - 1;
            double y = pCoord.y / yResolution * 2 - 1;
            x *= (double)xResolution / yResolution * PIXEL_ASPECT;            
            Vector2 uv = new Vector2(x, y);
            Direction = Front * Zoom + Right * uv.x + Up * uv.y;
            // Преобразование координат         

            Intensity = SetLight(shapes);        
        }

        private double SetLight(Shape[] shapes)
        {
            double d0 = 0;
            int index = 0;

            for (int i = 0; i < MAX_STEPS; i++)
            {
                Vector3 point = Position + Direction * d0;
                List<double> steps = new List<double>();

                foreach (var shape in shapes)
                {
                    steps.Add(shape.GetDist(point));
                }
                double dS = steps.Min();
                index = steps.IndexOf(dS);
                d0 += dS;
                if (d0 > MAX_DIST) break;
                else if (dS < SURF_DIST)
                {
                    Vector3 p = Position + Direction * d0;
                    Vector3 l = (LightPos - p).Normalized();
                    //Vector3 l = new Vector3(1, 1, 0).Normalized();
                    Vector3 n = shapes[index].GetNormal(p);

                    double diff = l * n;

                    return Math.Clamp(diff, 0, 1);
                }                 
            }
            return 0;                                 
        }
        public void ShowImage()
        {
            char[] image = new char[xResolution * yResolution];
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(xResolution, yResolution);
            Console.SetBufferSize(xResolution, yResolution);
            Console.CursorVisible = false;

            Console.Write(image);
            Console.SetCursorPosition(0, 0);
        }

    }
}
