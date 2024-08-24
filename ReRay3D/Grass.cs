using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D
{
    internal class Grass
    {
        public Vector3 Position = new Vector3(-10,0,10);
        public float rotateY = 0;
        public Vector2 scalearea = new Vector2(200,100);

        public float scaleRandomMin = 1;
        public float scaleRandomMax = 1;

        public float quantity = 1f;
        public Vector2 posix;
        public int x;
        public int z;

        public Quad grass = new Quad();

        
        public void LoadText(string path, bool filtr)
        {
            grass.billboard = true;
            grass.LoadText(path, filtr);
        
        }
        public void Update()
        {
            x = 0;
            z = 0;
            posix = new Vector2();
            for (int i = 0; i < scalearea.X * scalearea.Y; i++)
            {

                posix.X += quantity;
                grass.Update(true);
                x++;

                if (x > scalearea.X)
                {
                    x = 0;
                    z++;
                    posix.X = 0;
                    posix.Y += quantity;

                }
                grass.position.X = posix.X;
                grass.position.Z = posix.Y;


            }




        }
    }
}
