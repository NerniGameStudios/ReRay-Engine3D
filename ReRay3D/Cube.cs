using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D
{
    internal class Cube
    {

        int texsture = 0;
        int texsturebk = 0;
        int texsturebt = 0;
        int texstureft = 0;
        int texsturelf = 0;
        int texsturert = 0;
        int texsturetp = 0;
        public Vector3 position;
        public Vector3 rotate;
        public Vector3 scale = new Vector3(1);
        public Vector4 color = new Vector4(1);
        public void LoadText(string path, bool filtr)
        {
            texsture = Texture.LoadFromFile(path, filtr);

        }
        public void LoadText(string[] path, bool filtr)
        {
           texsturebk = Texture.LoadFromFile(path[0], filtr);
            texsturebt = Texture.LoadFromFile(path[1], filtr);
            texstureft = Texture.LoadFromFile(path[2], filtr);
            texsturelf = Texture.LoadFromFile(path[3], filtr);
            texsturert = Texture.LoadFromFile(path[4], filtr);
            texsturetp = Texture.LoadFromFile(path[5], filtr);

        }
        public void Update(Vector3 position, Vector3 rotate, Vector3 scale)
        {
            Window.triangles += 12;
           
            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.BindTexture(TextureTarget.Texture2D, texsture -1);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1f,1f,1f);

            // передняя
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, 0.5, 0.5);
            //задняя
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            //левая
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            //правая
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, -0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, 0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, -0.5, 0.5);

            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, 0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, -0.5);

            GL.TexCoord2(0, 1); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, -0.5, -0.5);

            GL.End();

          
            GL.PopMatrix();


        }
        public void Update()
        {
            Window.triangles += 12;

            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(color);

            // передняя
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, 0.5, 0.5);
            //задняя
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            //левая
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            //правая
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, -0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, 0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, -0.5, 0.5);

            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, 0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, -0.5);

            GL.TexCoord2(0, 1); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, -0.5, -0.5);

            GL.End();


            GL.PopMatrix();


        }
        public void UpdateCubemap(Vector3 position, Vector3 rotate, Vector3 scale)
        {
            Window.triangles += 12;

            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);


            GL.BindTexture(TextureTarget.Texture2D, texstureft - 1);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1f, 1f, 1f);
            
            // передняя
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, 0.5, 0.5);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texsturebk - 1);
            //задняя
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texsturelf - 1);
            //левая
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texsturert - 1);
            //правая
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1); GL.Vertex3(0.5, 0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5,- 0.5, -0.5);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, 0.5, -0.5);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texsturetp - 1);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, 0.5,- 0.5);
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, 0.5, -0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, 0.5, 0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, 0.5, 0.5);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texsturebt - 1);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(1, 1); GL.Vertex3(0.5, -0.5, 0.5);
            GL.TexCoord2(0, 1); GL.Vertex3(-0.5, -0.5, 0.5);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5, -0.5, -0.5);
            GL.TexCoord2(1, 0); GL.Vertex3(0.5, -0.5, -0.5);

            GL.End();


            GL.PopMatrix();


        }
    }
}

