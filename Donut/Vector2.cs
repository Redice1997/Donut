using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    public struct Vector2
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double Length { get; private set; }

        public Vector2(double value)
        {
            x = value;
            y = value;
            Length = Math.Sqrt(x * x + y * y);
        }
       
        public Vector2(double x, double y) 
        {
            this.x = x;
            this.y = y;
            Length = Math.Sqrt(x * x + y * y);
        }
        public void Normalized()
        {
            this = new Vector2(x / Length, y / Length);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);      
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);        
        public static Vector2 operator *(Vector2 v, double value) => new Vector2(v.x * value, v.y * value);
        public static double operator *(Vector2 a, Vector2 b) => a.x * b.x + a.y * b.y;
        public static Vector2 operator /(Vector2 v, double value) => new Vector2(v.x / value, v.y / value);
        
    }
}
