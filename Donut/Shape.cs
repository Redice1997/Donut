using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{    
    public abstract class Shape : ICanRayMarch
    {
        public Vector3 Position { get; set; }
        abstract public double GetDist(Vector3 point);        
    }

    public class Sphere : Shape
    {
        public double Radius { get; set; }
        public override double GetDist(Vector3 point)
        {
            return (point - Position).Length - Radius;
        }
        public Vector3 GetNormal(Vector3 p)
        {
            double d = GetDist(p);
            Vector2 e = new Vector2(0.01, 0);
            Vector3 n = new Vector3
                (
                d - GetDist(new Vector3(p.x - e.x, p.y - e.y, p.z - e.y)),
                d - GetDist(new Vector3(p.x - e.y, p.y - e.x, p.z - e.y)),
                d - GetDist(new Vector3(p.x - e.y, p.y - e.y, p.z - e.x))
                );
            return n.Normalized();
        }

    }
    

}
