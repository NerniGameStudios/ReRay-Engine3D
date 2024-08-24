using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ReRay3D.Phisics
{
    
    class Collider
    {
        public Vector3 pos = new Vector3(0,0,0);
        public Vector3 rot = new Vector3(0, 90, 0);
        public Vector3 scale = new Vector3(1, 1, 1);
        public void Box()
        {

        }
        public void Qaud()
        {
            GL.PushMatrix();
            GL.Translate(pos);
            GL.Rotate(rot.X, 1, 0, 0);
            GL.Rotate(rot.Y, 0, 1, 0);
            GL.Rotate(rot.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(0, 1f, 0);

            GL.Vertex3(-1, -1, 0);
            GL.Vertex3(-1, 1f, 0);
            GL.Vertex3(1, 1, 0);
            
            GL.Vertex3(1, -1, 0);

            GL.End();
            GL.PopMatrix();
        }


    }
    class Rigitbudy
    {
       static public Vector3 gravity = new Vector3(0, -9.8f, 0);
        public Vector3 Impuls = new Vector3(0, 0, 0);
        Vector3 zero = new Vector3(0, 0, 0);
        public Vector3 speed;
        Vector3 posp;
        Vector3 post;
        public bool collision;
        public bool isKinematic = false;
        public float mass = 1;
        public bool acceleration = true;

        public Vector3 Update(Vector3 position)
        {
            if(!isKinematic){
                posp = position;
            if (Impuls != zero)
            {
                if (Impuls.X > 0) Impuls.X -= Time.DeltaTime * 10;
                if (Impuls.X < 0) Impuls.X += Time.DeltaTime * 10;
                if (Impuls.Y > 0) Impuls.Y -= Time.DeltaTime * 10;
                if (Impuls.Y < 0) Impuls.Y += Time.DeltaTime * 10;
                if (Impuls.Z > 0) Impuls.Z -= Time.DeltaTime * 10;
                if (Impuls.Z < 0) Impuls.Z += Time.DeltaTime * 10;

            }
            if (!collision)
            {
                position += speed + (gravity * mass)   * Time.DeltaTime / 30;
            }
            
           
            position += Impuls * Time.DeltaTime;
          
            post = position;
                if (acceleration)
                {
                    speed.Y = (post.Y - posp.Y);
                }
            

            }
            else
            {
                speed = zero;
            }
            
            return position;
        }

    }
}
