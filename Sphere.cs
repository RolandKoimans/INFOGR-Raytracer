using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    class Sphere : Primitive
    {
        public Vector3 spherePos;

        public int rad;
        float posX, posY, posZ;

        public Sphere(int radius, float posx, float posy, float posz)
        {

            rad = radius;
            posX = posx;
            posY = posy;
            posZ = posz;
            spherePos = new Vector3(posX, posY, posZ);
           
        }


        public override Intersection Intersect(Ray ray)
        {
            Vector3 c = this.spherePos - ray.Origin; 
                
            float t = Vector3.Dot(c, ray.Direction);

            Vector3 q = c - t * ray.Direction;

            float p2 = Vector3.Dot(q, q);

            
            if (p2 > (rad * rad)) return null;
            
            t -= (float)Math.Sqrt(rad * rad - p2);

            if (t > 0)
            {
  
                Vector3 intersP = new Vector3((ray.Origin + t * ray.Direction) - this.spherePos);
                Vector3 normal = new Vector3(Vector3.Normalize(intersP));                

                return new Intersection(t, ray, normal, this);
            }

            return null;

        }
    }
}
