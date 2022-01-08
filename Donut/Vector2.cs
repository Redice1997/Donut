using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    struct Vector2
    {
        public double x { get; private set; }
        public double y { get; private set; }

        public Vector2(double value)
        {
            x = value;
            y = value;            
        }
       
        public Vector2(double x, double y) 
        {
            this.x = x;
            this.y = y;            
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
        public static Vector2 operator *(Vector2 v, double value) => new Vector2(v.x * value, v.y * value);
        public static Vector2 operator /(Vector2 v, double value) => new Vector2(v.x / value, v.y / value);

        public void Rotate(double angle)
        {

        }
        public double Modul() => Math.Sqrt(x * x + y * y);        
    }
}
