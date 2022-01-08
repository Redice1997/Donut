using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    struct Vector3
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }

        public Vector3(double value)
        {
            x = value;
            y = value;
            z = value;
        }
        public Vector3(Vector2 v, double z)
        {
            x = v.x;
            y = v.y;
            this.z = z;
        }
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        public static Vector3 operator *(Vector3 v, double value) => new Vector3(v.x * value, v.y * value, v.z * value);
        public static Vector3 operator /(Vector3 v, double value) => new Vector3(v.x / value, v.y / value, v.z / value);
    }
}
