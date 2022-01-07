using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    struct Vector3
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }

        Vector3(float value)
        {
            x = value;
            y = value;
            z = value;
        }
        Vector3(Vector2 v, float z)
        {
            x = v.x;
            y = v.y;
            this.z = z;
        }
        Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }
}
