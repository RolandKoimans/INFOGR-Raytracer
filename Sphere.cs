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
        //double x, y, z;        
        //int theta, phi;
        public int rad;
        float posX, posY, posZ;

        public Sphere(int radius, float posx, float posy, float posz)
        {
            //theta = 0;
            //phi = 0;
            rad = radius;
            posX = posx;
            posY = posy;
            posZ = posz;
            spherePos = new Vector3(posX, posY, posZ);
           
        }


        public override Intersection Intersect(Ray ray)
        {
            Vector3 c = this.spherePos - ray.Origin; //vector from vector origin to center of sphere           
                
            float t = Dot(c, ray.Direction);
            //Console.WriteLine("direction " + ray.Direction.X.ToString() + " y " + ray.Direction.Y.ToString() + " z " + ray.Direction.Z.ToString());
            Vector3 q = c - t * ray.Direction;
            //Console.WriteLine("vector q is " + q.X.ToString() + " y " +  q.Y.ToString() +  " z " + q.Z.ToString());
            float p2 = Dot(q, q);
            //while (p2 < rad * rad)
            //{
            //    Console.WriteLine("p2 is " + p2.ToString());
            //}
            
            if (p2 > (rad * rad)) return null;
            
            t -= (float)Math.Sqrt(rad * rad - p2);

            if (/*(t < ray.t) &&*/ (t > 0))
            {
                //subject to change for lights
                Vector3 normal = new Vector3(0,0,0);
                

                return new Intersection(t, ray, normal, this);
            }

            return null;
            //Console.WriteLine("this is t " + t.ToString());
            // or: ray.t = min( ray.t, max( 0, t ) );
        }
    }
}
