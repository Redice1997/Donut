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
    }

    //public class Cube : Shape

}
