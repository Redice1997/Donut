using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut
{
    abstract class Shape
    {
        protected Vector2 position;
        protected bool[] collider;        

        public Shape(Vector2 position)
        {
            this.position = position;            
        }

        public void Move(Vector2 direction)
        {
            position += direction;
        }          


    }

    class Circle : Shape
    {
        protected float radius;       
        
        public Circle(Vector2 position, float radius) : base(position)
        {
            this.radius = radius;
        }
        
        private void CreateCollider()
        {
           
        }
    }
}
