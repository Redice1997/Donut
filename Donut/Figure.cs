using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    abstract class Figure
    {
        protected Vector3 position;               

        public Figure(Vector3 position)
        {
            this.position = position;            
        }

        public void Move(Vector3 direction)
        {
            position += direction;
        }          


    }

    class Sphere : Figure
    {
        protected float radius;       
        
        public Sphere(Vector3 position, float radius) : base(position)
        {
            this.radius = radius;
        }
        
        private void CreateCollider()
        {
           
        }
    }
}
