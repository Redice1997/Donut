using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    class Graphics
    {
        public int height { get; }
        public int width { get; }
        public float aspect { get; }
        public float pixelAspect { get; }
        public float multiplier { get; }
        public char[] buffer { get; private set; }
        public Graphics(int height, int width, float multiplier)
        {
            this.height = height;
            this.width = width;
            this.multiplier = multiplier;
            aspect = (float)width / height;
            pixelAspect = 11.0f / 24.0f;
            buffer = new char[width * height];            
        }

        private void Reset()
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    buffer[i + j * width] = ' ';
        }

        public void Begin()
        {
            Reset();
            Console.SetCursorPosition(0, 0);
        }

        public void Draw()
        {         
            
            
            Console.Write(buffer);     

        }


    }

}
