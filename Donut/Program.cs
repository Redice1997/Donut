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
            float pixelAspect = 11.0f / 24.0f;
            char[] screen = new char[height * width + 1];
            screen[width * height] = '\0';

            for (int t = 0; t < 10000; t++) {
                for (int i = 0; i < width;  i++)                
                    for (int j = 0; j < height; j++)
                    {
                        float x = (float)i / width * 2.0f - 1.0f;
                        float y = (float)j / height * 2.0f - 1.0f;
                        x *= aspect * pixelAspect;
                        x += MathF.Sin(t * 0.001f);
                        char pixel = ' ';                    
                        if (x * x + y * y < 0.5) pixel = '@';
                        screen[i + j * width] = pixel;
                    }
                
                Console.Write(screen);

            }

            Console.ReadKey();

        }
    }
}
