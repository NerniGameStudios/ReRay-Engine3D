using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using StbImageSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assimp;
using Assimp.Unmanaged;
using static OpenTK.Graphics.OpenGL.GL;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace ReRay3D
{
    internal class Mesh
    {
        int texsture;
     

        public Vector3 position = new Vector3();
        public Vector3 rotate = new Vector3();
        public Vector3 scale = new Vector3(1, 1, 1);
        public Vector4 color = new Vector4(1, 1, 1, 1);
        public void LoadText(string path, bool filtr)
        {
            texsture = Texture.LoadFromFile(path, filtr);
            

        }
       

        private List<float> vertices = new List<float>();
        private List<float> normals = new List<float>();
        private List<float> texCoords = new List<float>();
        private List <uint> indices = new List<uint>();

    
        public Mesh(string fileName)
        {
            LoadOBJ(fileName);
         
        }
        public Mesh(string fileName , string texturename)
        {
            LoadOBJ(fileName);
            LoadText(texturename,true);

        }


        public void LoadOBJ(string path)
        {

            try
            {

             var Model = new AssimpContext();
                var _mesh = Model.ImportFile(path, PostProcessSteps.Triangulate  | PostProcessSteps.GenerateSmoothNormals | PostProcessSteps.JoinIdenticalVertices);


                

                    foreach (var _Mesh in _mesh.Meshes)
                {
                    


                    foreach (var Vertex in _Mesh.Vertices)
                    {
                        vertices.Add(Vertex.X);
                        vertices.Add(Vertex.Y);
                        vertices.Add(Vertex.Z);

                    }

                
                    foreach (var TextureCoord in _Mesh.TextureCoordinateChannels[0])
                    {
                        texCoords.Add(TextureCoord.X);
                        texCoords.Add(TextureCoord.Y);

                    }


                    foreach (var Normal in _Mesh.Normals)
                    {
                        normals.Add(Normal.X);
                        normals.Add(Normal.Y);
                        normals.Add(Normal.Z);

                    }
                    foreach (uint ind in _Mesh.GetIndices())
                    {
                        indices.Add(ind);

                    }


                    

                }
 
              

           


                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            
        }

     
        public void Update()
            {


            

         
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);
            GL.Color4(color);
           // GL.BindVertexArray(vaoID);
           // GL.DrawArrays(OpenTK.Graphics.OpenGL.PrimitiveType.LineStrip, 0, indices.Count);
           // GL.BindVertexArray(0);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, vertices.ToArray());
            
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, texCoords.ToArray());
            
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.NormalPointer(NormalPointerType.Float, 0, normals.ToArray());
            

            
            GL.DrawElements(BeginMode.Triangles, indices.Count, DrawElementsType.UnsignedInt, indices.ToArray());

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
            GL.DisableClientState(ArrayCap.NormalArray);

            

            GL.PopMatrix();


        }
    }
    
}
