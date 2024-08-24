using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace ReRay3D
{
    
    internal class Debug
    {

        public static bool gizmo = true;
      public static List<string> filer = new List<string>();
        static public void init()
        {
            
          filer = LoaderConfFile.Load("Config/Conf.txt");
            if (filer[3] == "Yes")
            {
                Debug.Log("\n ДиагConf:");
                for (int i = 0; i < filer.Count; i++)
            {

                Debug.Log(filer[i]);
            }
                Debug.Log("\n");
            }
            else if(filer[3] == "No")
                     {
                Debug.Log("Файл конфигурации загружен!");
                     }
            else
            {
                ExitError("RR3D: Файл конфигурации повреждён!\n Ошибка S4");
                Window.Exit();
            }
            
        }
        static public void Log(string message)
        {
            Console.WriteLine(message);
        }
        static public void ExitError(string message)
        {
            [DllImport("user32.dll")]
            static extern int MessageBox(IntPtr hWnd,String text,String caption, int options);
            MessageBox(IntPtr.Zero,message,"ReRay3D Error",0);
            
        }
        static public void DebugLines()
        {
            GL.PushMatrix();
            GL.BindTexture(TextureTarget.Texture2D,0);
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(1f, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0.01, 0, 0);
            GL.Color3(0, 1f, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0.01, 0);
            GL.Color3(0, 0, 1f);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 0.01);
            GL.End();
            GL.PopMatrix();
        }
        static public void DebugLinesGUI()
        {
            
        }
       static float[] vertices = new float[] {
               - 0.5f, -0.5f, 0.0f,
                 0.5f, -0.5f, 0.0f,
               - 0.5f,  0.5f, 0.0f,
                 0.5f,  0.5f, 0.0f

                    };
        static float[] colors = new float[] {
               1, 0, 0,1,
                 0, 1, 0,1,
               0, 0, 1,1,
                 0, 0, 0,1

                    };
        static public void TestTriang()
        {
            
           
            
            GL.PointSize(5);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(0,0,0);
            GL.End();
            GL.VertexPointer(3,VertexPointerType.Float,0,vertices);
            GL.EnableClientState(ArrayCap.VertexArray);
            
            GL.ColorPointer(4, ColorPointerType.Float, 0, colors);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.DrawArrays(PrimitiveType.TriangleStrip,0,4);
            GL.DisableClientState(ArrayCap.VertexArray);

            //Debug.Log("Test");
           
           
        }
    }
}
