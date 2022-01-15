using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{    
    public abstract class Shape
    {
        public Shape() { }
        public Shape(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
        }
        public Vector3 Position { get; set; }
        public abstract double GiveDist(Vector3 p);
        public virtual Vector3 GiveNormal(Vector3 p)
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
        public override double GiveDist(Vector3 p) => (p - Position) * Normal;
        public override Vector3 GiveNormal(Vector3 p) => Normal;

    }
    public class Sphere : Shape
    {
        public Sphere() : base() { }
        public Sphere(double x, double y, double z) : base(x, y, z) { }
        public double Radius { get; set; } = 1;
        public override double GiveDist(Vector3 p) => (p - Position).Length - Radius;        
        public override Vector3 GiveNormal(Vector3 p) => (p - Position).Normalized();    

    }
    
    public class Capsule : Sphere
    {  
        public double Length { get; set; }        

        private Vector3 axis = new Vector3(0, 1, 0);
        public Vector3 Axis
        {
            get => axis;
            set => axis = value.Normalized();
        }          


        public Capsule() : base() { }
        public Capsule(double x, double y, double z) : base(x, y, z) { }        

        public override double GiveDist(Vector3 p)
        {
            Vector3 PO = p - Position;
            double t = PO * Axis;
            Vector3 C = Position + Axis * Math.Clamp(t, -Length / 2, Length / 2);
            return (p - C).Length - Radius;
        }
        public override Vector3 GiveNormal(Vector3 p)
        {
            Vector3 PO = p - Position;
            double t = PO * Axis;
            Vector3 C = Position + Axis * Math.Clamp(t, -Length / 2, Length / 2);
            return (p - C).Normalized();
        }
    }
    public class Donut : Shape
    {
        public double Thickness { get; set; } = 0.5;
        public double Radius { get; set; } = 1;

        private Vector3 axis = new Vector3(0, 1, 0);
        public Vector3 Axis
        {
            get => axis;
            set => axis = value.Normalized();
        }

        public Donut() : base() { }
        public Donut(double x, double y, double z) : base(x, y, z) { }

        public override double GiveDist(Vector3 p)
        {
            Vector3 p1 = Position + Axis * ((p - Position) * Axis);
            Vector3 t = Position + (p - p1).Normalized() * Radius;

            return (p - t).Length - Thickness;            
        }
    }
    public class Cube : Shape
    {
        public override double GiveDist(Vector3 point)
        {
            throw new NotImplementedException();
        }
    }

}
