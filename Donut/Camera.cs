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

        public Camera()
        {
            Position = new Vector3(0);
            Diraction = new Vector3(0, 0, 1);
            xResolution = 120;
            yResolution = 30;
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
            char[] grad = { ' ', '.', ':', '!', '/', '(', 'l', '7', 'Z', '$', '@' };
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
            Vector2 uv = new Vector2(pCoord.x / yResolution, pCoord.y / yResolution);
            uv -= new Vector2(-0.5);

            Vector3 ro = new Vector3(0, 0, -2);
            Vector3 rd = new Vector3(uv, 0) - ro;

            Vector3 p = new Vector3(0, 0, 2);
            double d = Vector3.Distance(ro, rd, p);


            Intensity = d;            
        }
    }
}
