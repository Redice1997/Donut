using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    public abstract class Shape
    {
        protected Vector3 position;               

        public Shape(Vector3 position)
        {
            this.position = position;            
        }

        public void Move(Vector3 direction)
        {
            position += direction;
        }  

    }

    public class Sphere : Shape
    {
        protected double radius;       
        
        public Sphere(Vector3 position, double radius) : base(position)
        {
            this.radius = radius;
        }        
        
    }
}
