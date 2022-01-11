using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    public struct Vector3
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }
        public double Length { get; private set; }

        public Vector3(double value)
        {
            x = value;
            y = value;
            z = value;
            Length = Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3(Vector2 v, double z)
        {
            x = v.x;
            y = v.y;
            this.z = z;
            Length = Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Length = Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalized() => Length != 0 ? (this / Length) : this;          

        public static Vector3 Cross(Vector3 a, Vector3 b) => new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);

        public static double Distance(Vector3 lineStart, Vector3 lineEnd, Vector3 dot)
        {
            return Vector3.Cross(lineEnd - lineStart, dot - lineStart).Length / (lineEnd - lineStart).Length;
        }
        


        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        public static Vector3 operator *(Vector3 v, double value) => new Vector3(v.x * value, v.y * value, v.z * value);
        public static Vector3 operator /(Vector3 v, double value) => new Vector3(v.x / value, v.y / value, v.z / value);
    }
}
