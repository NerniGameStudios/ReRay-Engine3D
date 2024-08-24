using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D
{
    internal class Quad
    {
        int texsture;
        public bool billboard;
        public Vector3 position = new Vector3();
        public Vector3 rotate = new Vector3();
        public Vector3 scale = new Vector3(1,1,1);
        public Vector4 color = new Vector4(1, 1, 1, 1);
        public void LoadText(string path,bool filtr)
        {
            texsture = Texture.LoadFromFile(path,filtr);
           
        }

        public void Update()
        {
            Window.triangles += 2;
             GL.BindTexture(TextureTarget.Texture2D,texsture-1);

           

            GL.Light(LightName.Light0, LightParameter.Specular, new Vector4(0, 1, 0, 0));
            if (billboard)
            {
                if (Window.vievCam.Z < 0)
                {
                    GL.PushMatrix();
                    GL.Translate(position);

                    GL.Rotate(-Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(Window.vievCam.Y * 90, 1, 0, 0);

                    GL.PushMatrix();
                    GL.Translate(0,0,0);



                    GL.Rotate(0, 0, 1, 0);

                    GL.Scale(scale);
                    GL.Begin(PrimitiveType.Quads);

                    GL.Color4 (color);
                    GL.Normal3(0, 0,- 1);
                    GL.TexCoord2(0, 1); GL.Vertex3(-1, 1, 0);
                    GL.TexCoord2(0, 0); GL.Vertex3(-1, -1, 0);
                    GL.TexCoord2(1, 0); GL.Vertex3(1, -1, 0);
                    GL.TexCoord2(1, 1); GL.Vertex3(1, 1, 0);
                    GL.End();
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }
                else
                {
                    GL.PushMatrix();

                    GL.Translate(position);
                    GL.Rotate(Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(-Window.vievCam.Y * 90, 1, 0, 0);
                    GL.PushMatrix();
                    GL.Translate(0,0,0);


                   
                    GL.Rotate(180, 0, 1, 0);
                    
                    GL.Scale(scale);
                    GL.Begin(PrimitiveType.Quads);

                    GL.Color4(color);
                    GL.Normal3(0, 0, -1);
                    GL.TexCoord2(0, 1); GL.Vertex3(-1, 1, 0);
                    GL.TexCoord2(0, 0); GL.Vertex3(-1, -1, 0);
                    GL.TexCoord2(1, 0); GL.Vertex3(1, -1, 0);
                    GL.TexCoord2(1, 1); GL.Vertex3(1, 1, 0);
                    GL.End();
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }



            }
            else
            {
                GL.PushMatrix();
                GL.Translate(position);

            
            GL.Rotate(rotate.X,1, 0,0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.Begin(PrimitiveType.Quads);

                GL.Color4(color);
                GL.Normal3(0, 0, -1);
                GL.TexCoord2(0, 1); GL.Vertex3(-1 ,1  ,0 );
            GL.TexCoord2(0, 0); GL.Vertex3(-1, -1  , 0) ;
            GL.TexCoord2(1, 0); GL.Vertex3(1 , -1 , 0 );
            GL.TexCoord2(1, 1); GL.Vertex3(1 , 1 , 0 );
            GL.End();
            // GL.DeleteTexture(texsture);
            
            GL.PopMatrix();
            }
            
           


        }
        public void Update(Vector4 texcoords, Vector2 WH)
        {
            Window.triangles += 2;
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(color);
            GL.Normal3(0, 0, -1);
            GL.TexCoord2(( texcoords.Z) / WH.X, (texcoords.W) / WH.Y); GL.Vertex3(-1, 1, 0);
            GL.TexCoord2(( texcoords.Z) / WH.X, (texcoords.Y) / WH.Y); GL.Vertex3(-1, -1, 0);
            GL.TexCoord2(( texcoords.X) / WH.X, (texcoords.Y) / WH.Y); GL.Vertex3(1, -1, 0);
            GL.TexCoord2(( texcoords.X) / WH.X, (texcoords.W) / WH.Y); GL.Vertex3(1, 1, 0);
            GL.End();
            // GL.DeleteTexture(texsture);

            GL.PopMatrix();


        }
         
        public void Update(bool VA)
        {
            float[] vertices = new float[] {
               - 1, 1, 0.0f,
                 -1, -1, 0.0f,
               1,  -1, 0.0f,
                 1,  1f, 0.0f

                    };
            float[] normal = new float[] {
               -1, -1, 3,
                 1, -1,3,
               1,  1, 3,
                 -1,  1, 3

                    };
            float[] Texcords = new float[] {
               0,  1,
                 0, 0,
               1,  0,
                 1,  1

                    };

            Window.triangles += 2;
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            


            // GL.DeleteTexture(texsture);

            GL.PopMatrix();

            if (billboard)
            {
                if (Window.vievCam.Z < 0)
                {
                    GL.PushMatrix();
                    GL.Translate(position);

                    GL.Rotate(-Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(Window.vievCam.Y * 90, 1, 0, 0);

                    GL.PushMatrix();
                    GL.Translate(0, 0, 0);



                    GL.Rotate(0, 0, 1, 0);

                    GL.Scale(scale);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
                    
                    GL.EnableClientState(ArrayCap.VertexArray);
                    GL.EnableClientState(ArrayCap.NormalArray);
                    GL.NormalPointer(NormalPointerType.Float,0,normal);

                    GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, Texcords);
                    GL.EnableClientState(ArrayCap.TextureCoordArray);

                    GL.Color4(color);
                    GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                    GL.DisableClientState(ArrayCap.VertexArray);
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }
                else
                {
                    GL.PushMatrix();

                    GL.Translate(position);
                    GL.Rotate(Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(-Window.vievCam.Y * 90, 1, 0, 0);
                    GL.PushMatrix();
                    GL.Translate(0, 0, 0);



                    GL.Rotate(180, 0, 1, 0);

                    GL.Scale(scale);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
                   
                    GL.EnableClientState(ArrayCap.VertexArray);
                    GL.EnableClientState(ArrayCap.NormalArray);
                    GL.NormalPointer(NormalPointerType.Float, 0, normal);
                    GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, Texcords);
                    GL.EnableClientState(ArrayCap.TextureCoordArray);

                    GL.Color4(color);
                    GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                    GL.DisableClientState(ArrayCap.VertexArray);
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }



            }
            else
            {
                Window.triangles += 2;
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);


            GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
          
                GL.EnableClientState(ArrayCap.VertexArray);
                GL.EnableClientState(ArrayCap.NormalArray);
                GL.NormalPointer(NormalPointerType.Float, 0, normal);
                GL.TexCoordPointer(2,TexCoordPointerType.Float, 0,Texcords);
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            GL.Color4(color);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            GL.DisableClientState(ArrayCap.VertexArray);


            // GL.DeleteTexture(texsture);

            GL.PopMatrix();
            }
        }
        public void Update(Vector3 position, Vector3 rotate, Vector3 scale)
        {
            float[] vertices = new float[] {
               - 1, 1, 0.0f,
                 -1, -1, 0.0f,
               1,  -1, 0.0f,
                 1,  1f, 0.0f

                    };
            float[] normal = new float[] {
               -1, -1, 3,
                 1, -1,3,
               1,  1, 3,
                 -1,  1, 3

                    };
            float[] Texcords = new float[] {
               0,  1,
                 0, 0,
               1,  0,
                 1,  1

                    };

            Window.triangles += 2;
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);



            // GL.DeleteTexture(texsture);

            GL.PopMatrix();

            if (billboard)
            {
                if (Window.vievCam.Z < 0)
                {
                    GL.PushMatrix();
                    GL.Translate(position);

                    GL.Rotate(-Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(Window.vievCam.Y * 90, 1, 0, 0);

                    GL.PushMatrix();
                    GL.Translate(0, 0, 0);



                    GL.Rotate(0, 0, 1, 0);

                    GL.Scale(scale);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
                  
                    GL.EnableClientState(ArrayCap.VertexArray);
                    GL.EnableClientState(ArrayCap.NormalArray);
                    GL.NormalPointer(NormalPointerType.Float, 0, normal);

                    GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, Texcords);
                    GL.EnableClientState(ArrayCap.TextureCoordArray);

                    GL.Color4(color);
                    GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                    GL.DisableClientState(ArrayCap.VertexArray);
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }
                else
                {
                    
                    GL.PushMatrix();

                    GL.Translate(position);
                    GL.Rotate(Window.vievCam.X * 95, 0, 1, 0);
                    GL.Rotate(-Window.vievCam.Y * 90, 1, 0, 0);
                    GL.PushMatrix();
                    GL.Translate(0, 0, 0);



                    GL.Rotate(180, 0, 1, 0);

                    GL.Scale(scale);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
                    GL.Normal3(0, 0, -1);
                    GL.EnableClientState(ArrayCap.VertexArray);

                    GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, Texcords);
                    GL.EnableClientState(ArrayCap.TextureCoordArray);

                    GL.Color4(color);
                    GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                    GL.DisableClientState(ArrayCap.VertexArray);
                    // GL.DeleteTexture(texsture);

                    GL.PopMatrix();


                    GL.PopMatrix();
                }



            }
            else
            {
                Window.triangles += 2;
                GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
                GL.PushMatrix();
                GL.Translate(position);
                GL.Rotate(rotate.X, 1, 0, 0);
                GL.Rotate(rotate.Y, 0, 1, 0);
                GL.Rotate(rotate.Z, 0, 0, 1);
                GL.Scale(scale);

                GL.LineWidth(4);
                GL.Begin(PrimitiveType.Lines);



                GL.Color3(1, 1, 1f);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 1);
                GL.End();
                GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
               
               
                GL.EnableClientState(ArrayCap.VertexArray);
 
                GL.NormalPointer(NormalPointerType.Float, 0, normal);
                GL.EnableClientState(ArrayCap.NormalArray); 
               



                GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, Texcords);
                GL.EnableClientState(ArrayCap.TextureCoordArray);

                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Quads, 0, 4);
                GL.DisableClientState(ArrayCap.VertexArray);
                GL.DisableClientState(ArrayCap.NormalArray);
                GL.DisableClientState(ArrayCap.TextureCoordArray);


                // GL.DeleteTexture(texsture);

                GL.PopMatrix();
            }
        }

    }
}

