using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{    
    public abstract class Shape : IHavePos
    {
        public Shape() { }
        public Shape(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
        }
        public Vector3 Position { get; set; }
        public abstract double GiveDist(Vector3 point);
        public virtual Vector3 GetNormal(Vector3 p)
        {
            double d = GiveDist(p);
            double e = 0.001;
            Vector3 n = new Vector3
                (
                d - GiveDist(new Vector3(p.x - e, p.y, p.z)),
                d - GiveDist(new Vector3(p.x, p.y - e, p.z)),
                d - GiveDist(new Vector3(p.x, p.y, p.z - e))
                );
            return n.Normalized();
        }
    }

    public class Sphere : Shape
    {
        public Sphere() : base() { }
        public Sphere(double x, double y, double z) : base(x, y, z) { }
        public double Radius { get; set; } = 1;
        public override double GiveDist(Vector3 point) => (point - Position).Length - Radius;        
        public override Vector3 GetNormal(Vector3 p) => (p - Position).Normalized();    

    }
    public class Plane : Shape
    {
        public Plane() : base() { }
        public Plane(double x, double y, double z) : base(x, y, z) { }

        private Vector3 normal = new Vector3(0, 1, 0);
        public Vector3 Normal
        {
            get { return normal; }
            set { normal = value.Normalized(); }
        }
        public override double GiveDist(Vector3 point) => (point - Position) * Normal;        
        public override Vector3 GetNormal(Vector3 p) => Normal;
        
    }
    public class Donut : Shape
    {
        public override double GiveDist(Vector3 point)
        {
            throw new NotImplementedException();
        }
    }

}
