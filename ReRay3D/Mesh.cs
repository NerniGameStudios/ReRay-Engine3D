using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<Vector3> vertices = new List<Vector3>();
        private List<Vector3> normals = new List<Vector3>();
        private List<Vector2> texCoords = new List<Vector2>();
        private List<uint> indices = new List<uint>();
        private int vaoID, vboID, eboID;
        private int vertexCount;
        public List<String> dataObj = new List<String>();
        public List<String> dataind = new List<String>();

        public Mesh(string fileName)
        {
            LoadOBJ(fileName);
         
        }
        public void LoadOBJ(string path)
        {

            try
            {
                dataObj = LoaderConfFile.Load(path);

                foreach (string line in dataObj)
                {


                    if (line.ToLower().StartsWith("v "))
                    {
                        var vx = line.Split(' ')
                            .Skip(1)
                            .Select(v => float.Parse(v.Replace('.', ',')))
                            .ToArray();
                        vertices.Add(new Vector3(vx[0], vx[1], vx[2]));
                    }
                    else if (line.ToLower().StartsWith("vn "))
                    {
                        var vx = line.Split(' ')
                           .Skip(1)
                           .Select(v => float.Parse(v.Replace('.', ',')))
                           .ToArray();
                        normals.Add(new Vector3(vx[0], vx[1], vx[2]));
                    }
                    else if (line.ToLower().StartsWith("vt "))
                    {
                        var vx = line.Split(' ')
                           .Skip(1)
                           .Select(v => float.Parse(v.Replace('.', ',')))
                           .ToArray();
                        texCoords.Add(new Vector2(vx[0], vx[1]));
                    }
                    else if (line.ToLower().StartsWith("f "))
                    {
                        
                            var vx = line.Split(' ')
                           .Skip(1);

                            foreach (var item in vx)
                            {
                            string[] indd = item.Split('/') ;
                                
                               indices.Add(uint.Parse(indd[0]) - 1);
                           

                            }

                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach (var item in indices)
            {
                Debug.Log("" + item);
                
            }
            
            
        }
        public void Update()
            {


            

            Window.triangles += 2;
            GL.BindTexture(TextureTarget.Texture2D, texsture - 1);
            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotate.X, 1, 0, 0);
            GL.Rotate(rotate.Y, 0, 1, 0);
            GL.Rotate(rotate.Z, 0, 0, 1);
            GL.Scale(scale);


            GL.VertexPointer(3, VertexPointerType.Float, 0, vertices.ToArray());
            GL.EnableClientState(ArrayCap.VertexArray);

            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, texCoords.ToArray());
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            GL.Color4(color);
            GL.DrawElements(BeginMode.TriangleStripAdjacency,indices.Count,DrawElementsType.UnsignedInt,indices.ToArray());
            GL.DisableClientState(ArrayCap.VertexArray);


            // GL.DeleteTexture(texsture);

            GL.PopMatrix();


        }
    }
    
}
