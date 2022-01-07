using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    struct Vector2
    {
        public float x { get; private set; }
        public float y { get; private set; }

        Vector2(float value)
        {
            x = value;
            y = value;
            
        }
       
        Vector2(float x, float y) 
        {
            this.x = x;
            this.y = y;
            
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
    }
}
