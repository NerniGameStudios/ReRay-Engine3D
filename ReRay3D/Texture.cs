using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using StbImageSharp;
using System.IO;
using OpenTK.Mathematics;

namespace ReRay3D
{
    public class Texture
    {

        static public List<int> textures = new List<int>();
        static public int LoadFromFile(string path, bool filter)
        {
            
            

            int tex;
            if (!File.Exists(path))
            {
                if (!File.Exists("Config/errorTex.png"))
                {
                    path = "Config/errorTex.png";
                    filter = false;
                }
                else
                {
                    Debug.ExitError("Core: Файлы повреждены или не найдены! Ошибка C1.2");
                }
                
                
            }
            
            
           
               
          
            
            StbImage.stbi_set_flip_vertically_on_load(1);
            using (Stream stream = File.OpenRead(path))
            {
                
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

               
                
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
                
            
            }

            GL.GenTextures(1,out tex);  
            
          
           
           
            switch (filter)
            {
                case true:
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                break;


                case false:
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                break;

                
            } 
            

            GL.TexParameter(TextureTarget.Texture2D,TextureParameterName.TextureWrapS,(int)TextureParameterName.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureParameterName.ClampToEdge);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.GenerateTextureMipmap(tex);







            textures.Add(tex);
            Debug.Log("Loader: Файл загружен " + path);
            return tex;
        }

        

       
        
    }
}
