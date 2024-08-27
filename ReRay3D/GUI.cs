using OpenTK.Compute.OpenCL;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D.GUI
{
    
    class ImageGUI
    {
        public bool filter = false;
        Quad quad = new Quad();
       public Vector3 position;
        public Vector2 scl;
      public  Vector4 color = new Vector4(255);
        
        float rot;
        
        public void Inst(string imagePath , Vector2 pos, Vector2 scale,float rotz) 
        {

            rot = rotz;
            quad.LoadText(imagePath,filter);
            position.X = pos.X;
            position.Y = pos.Y;
            scl = scale;

        }
        public void Update()
          {
            GL.Disable(EnableCap.Lighting);
            GL.PushMatrix();
            Matrix4 GUi = Matrix4.LookAt(0, 0, 0.1001f
                          , 0,  0, 0
                            , 0, 1, 0
                );
            GL.LoadMatrix(ref GUi);
            quad.color = color;
            quad.position = new Vector3((Window.aspect * position.X * 0.01f), (Window.aspect * position.Y * 0.01f), position.Z);
            quad.rotate = new Vector3(0, 0, rot);
            quad.scale = new Vector3(scl.X * 0.01f, scl.Y * 0.01f, 1);
            quad.Update();

            GL.PopMatrix();
            
            GL.Enable(EnableCap.Lighting);
        }
        public void translate(Vector3 pos, Vector2 scale)
        {
            position = pos;
            scl = scale;
        }
    }
    class Text
    {
        
        Quad quad = new Quad();
       public Vector4 color;
       public Vector2 position;
        public float zpos;
        Vector2 scl;
        Vector2 Wh;
        Vector2 poschar;
        Vector4 postexchar;
        Vector2 postexcharint;
        Vector2 texfontwh;
        string deftext = "text";
        string text;
        public  List<string> load = new List<string>();
        public  char[] charsLoad;
        public  char[] chars;
        float rot;
        float rast;

        public void InstAndFont(string imagePath, string dataPath, Vector2 pos, Vector2 scale, float rotz, Vector2 WH, float otst)
        {
            rast = otst;
            chars = deftext.ToCharArray();
            Wh = WH;
            rot = rotz;
            quad.LoadText(imagePath, false);
            position = pos;
            scl = scale;
            load = LoaderConfFile.Load(dataPath);
            texfontwh = new Vector2(int.Parse(load[0]), int.Parse(load[1]));
            
                charsLoad = load[2].ToCharArray();
           

        }
        public void InstAndFont(Vector2 pos, Vector2 scale, float rotz, Vector2 WH, float otst)
        {
            rast = otst;
            chars = deftext.ToCharArray();
            Wh = WH;
            rot = rotz;
            quad.LoadText("Config/fontrus.png", false);
            position = pos;
            scl = scale;
            load = LoaderConfFile.Load("Config/fontrusData.txt");
            texfontwh = new Vector2(int.Parse(load[0]), int.Parse(load[1]));

            charsLoad = load[2].ToCharArray();


        }

        public void Update()
        {

            GL.Disable(EnableCap.Lighting);
            poschar = new Vector2();
            GL.PushMatrix();
            GL.Color4(color);
            Matrix4 GUi = Matrix4.LookAt(0, 0, 0.1001f
                          , 0, 0, 0
                            , 0, 1, 0
                );
            GL.LoadMatrix(ref GUi);
            for (int i = 0; i < chars.Length; i++)
            {
                postexchar = new Vector4(0,224,14,224-16);
                postexcharint.X = 0;
                postexcharint.Y = 0;
                
                for (int j = 0; j < charsLoad.Length; j++)
                {
                   
                
                    
                    if (chars[i] == charsLoad[j])
                    {
                       
                        for (int y = 0; y < j; y++)
                        {
                           
                            
                            if (postexcharint.X != texfontwh.X)
                            {
                            postexcharint.X++;
                            postexchar.X += 14;
                            postexchar.Z += 14;
                                
                            }
                            else
                            {
                                
                                if (postexcharint.Y != texfontwh.Y)
                                {
                                    postexcharint.Y++;
                                    postexchar.Y -= 16;
                                    postexchar.W -= 16;
                                }
                                else
                                {
                                    postexchar.Y = 224;
                                    postexchar.W = 224 - 16;
                                    postexcharint.Y = 0;
                                }
                                postexchar.X = 0;
                                postexchar.Z = 14;
                                postexcharint.X = 0;
                            }
                            
                            
                            
                           
                                
                             
                            
                              

                            
                            
                        }
                        
                        
                           
                    
                    }
                        
                }

                quad.position = new Vector3((Window.aspect * position.X + poschar.X), (Window.aspect * position.Y + poschar.Y), zpos);
                quad.rotate = new Vector3(0, 0, rot + 180);
                quad.scale = new Vector3(scl.X * 0.01f, scl.Y * 0.01f,1);
                quad.Update( postexchar, Wh) ;
                poschar.X += rast;
                
                
                    
                
            }
            

            GL.PopMatrix();
            GL.Enable(EnableCap.Lighting);
        }
        public void translate(string text,Vector2 pos, Vector2 scale)
        {
            
            chars = text.ToCharArray(0,1);
            position = pos;
            scl = scale;
        }
        public void translate(string text)
        {

            chars = text.ToCharArray();
           
        }
    }
    class Button
    {
       
        public bool active = true;
        public Vector2 position = new Vector2(0f);
        public Vector2 scale = new Vector2(0.1f);
        public bool pressed;
        public bool isHover()
        {


            if (active)
            {
                if (Window.MouseX > position.X && Window.MouseY > position.Y && Window.MouseX < position.X + scale.X && Window.MouseY < position.Y + scale.Y)
            {
            
               // Debug.Log("button");
                return true;
            }
            else
            {
                return false;
            }
            }
            else
            {
                return false;
            }
            

            
        }
        public bool isDown()
        { 
            
            if (isHover())
            {
                if (Window.mtk.IsButtonDown(MouseButton.Left))
                {
                    
                    if (!pressed)
                    {
                        pressed = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    

                }
                else
                {
                   pressed = false;
                    return false;
                }

            }
            else
            {
                return false;
            }
            
        }

        public void init() 
        {
            

           
            
        }






    }
    
}
