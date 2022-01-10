using System;

namespace Donut
{

    public class Camera
    {
        
        public Vector3 Position { get; set; }
        public Vector3 Diraction { get; set; }        

        private Vector3 Front;
        private Vector3 Up;
        private Vector3 Right;
        
        public double zoom { get; set; }
        

        private int xResolution;
        private int yResolution;

        private const double PIXEL_ASPECT = 0.5;        

        public Camera()
        {
            Position = new Vector3(0);
            Diraction = new Vector3(0, 0, 1);
            xResolution = 160;
            yResolution = 60;            
        }
        public Camera(Vector3 position, Vector3 Lookat, int xResolution = 120, int yResolution = 30)
        {
            Position = position;
            Diraction = (Lookat - Position).Normalized();
            this.xResolution = xResolution;
            this.yResolution = yResolution;
        }


        public void Move(Vector3 direction)
        {
            Position += direction;
        }
        public void Rotate(Vector3 axis, double angle)
        {

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

        private void GeneratePixel(out double Intensity, in Vector2 pCoord, params Shape[] shape)
        {
            // Преобразование координат
            double x = pCoord.x / xResolution * 2 - 1;
            double y = pCoord.y / yResolution * 2 - 1;
            x *= (double)xResolution / yResolution * PIXEL_ASPECT;            
            Vector2 uv = new Vector2(x, -y);
            // Преобразование координат

            double d = 1 - uv.Length;

            

            Intensity = d;            
        }
    }
}
