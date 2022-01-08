using System;
using System.Text;

namespace Donut
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 120;
            int height = 30;
            float aspect = (float)width / height;
            float pixelAspect = 0.5f;
            char[] screen = new char[height * width];            

            Console.CursorVisible = false;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float x = (float)i / width * 2.0f - 1.0f;
                    float y = (float)j / height * 2.0f - 1.0f;
                    x *= aspect * pixelAspect;                    
                    char pixel = ' ';
                    if (MathF.Pow(y, 2) + MathF.Pow(x, 2) <= 0.2)
                    {
                        pixel = '.';                        
                    }                    
                    screen[i + j * width] = pixel;
                }
            }

            Console.Write(screen);
            Console.SetCursorPosition(0, 0);

            Console.ReadKey();
            

        }
    }
}
