using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    abstract class Shape
    {
        public Vector2 position;
        public char[] texture;

        public Shape(Vector2 position, char[] texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public void Move(Vector2 direction)
        {
            position += direction;
        }

    }
}
