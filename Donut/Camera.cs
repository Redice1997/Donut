﻿using System;

namespace Donut
{

    public class Camera
    {
        private const int MAX_STEPS = 100;
        private const double MAX_DIST = 100;
        private const double SURF_DIST = 0.01;
        public Vector3 Position { get; set; }
        public double Zoom { get; set; } = 1;

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

        private const double PIXEL_ASPECT = 0.5;        

        public Camera()
        {
            Position = new Vector3(0);            
        }
        public Camera(Vector3 position)
        {
            Position = position;
        }

        public void MoveTo(Vector3 direction)
        {
            Position += direction;
        }
        public void LookAt(Vector3 point)
        {
            Front = point - Position;
        }
        public void SetResolution(int width, int height)
        {
            xResolution = width;
            yResolution = height;
        }


        public void ShowImage(params Shape[] shape)
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
                    GeneratePixel(out double Intensity, new Vector2(i, j), shape);
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
            Vector2 uv = new Vector2(x, -y);
            Direction = Front * Zoom + Right * uv.x + Up * uv.y;
            // Преобразование координат

            double min = RayMarch(shapes[0]);

            for (int i = 1; i < shapes.Length; i++)
            {
                double a = RayMarch(shapes[i]);
                if (a < min) min = a;
            }

            Intensity = min / 6;            
        }

        private double RayMarch(Shape shape)
        {
            double d0 = 0;

            for (int i = 0; i < MAX_STEPS; i++)
            {
                Vector3 point = Position + Direction * d0;
                double dS = shape.GetDist(point);
                d0 += dS;
                if (d0 > MAX_DIST || dS < SURF_DIST) break;
            }
            return d0;
        }
        
    }
}
