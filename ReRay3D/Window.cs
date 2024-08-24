using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ReRay3D.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReRay3D
{
    
    public class Window : GameWindow
    {
        static public int _width;
        static public int _height;
        static public float MouseX;
        static public float MouseY;
        static  bool exit;
        private float frameTime = 0.0f;
        private int fps;
        public static KeyboardState stk;
        public static MouseState mtk;
        public static int triangles;
        public static float aspect;
        static bool VSyncYN;
        int tex2;
        public static Vector3 posCam = new Vector3(0,0,0);
        public static Vector3 vievCam = new Vector3(0, 0, -10);
        bool Lighting = false;
        bool isfullscreen  = false;
        static ImageGUI logo = new();
        static ImageGUI I327 = new();
        static float alphalogo;
        static float alphalogon = 0;
        static float animlogo;
        static Text text = new Text();
        bool logonloaded;

        bool logonl = true;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Debug.Log(GL.GetString(StringName.Version));
            Debug.Log(GL.GetString(StringName.Renderer));
            if (isfullscreen)
            {
                WindowState = WindowState.Fullscreen;
                VSync = VSyncMode.On;

            }
            if (Debug.filer[4] == "Yes")
            {
                VSync = VSyncMode.On;
                VSyncYN = true;
            }
            else if (Debug.filer[4] == "No")
            {
                VSync = VSyncMode.Off;
                VSyncYN = false;
            }
            else
            {
                Debug.ExitError("RR3D: Файл конфигурации повреждён!\n Ошибка S5");
                Window.Exit();
            }
            
            

        }

        protected override void OnLoad()
        {

            //CursorGrabbed = true;

            base.OnLoad();
        
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.CullFace);
           GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.AlphaTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.ColorMaterial); 
           // GL.Enable(EnableCap.Lighting);
          //  GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Normalize);
            GL.CullFace(CullFaceMode.Back);
            GL.AlphaFunc(AlphaFunction.Greater ,0);
            GL.BlendFunc(BlendingFactor.SrcAlpha,BlendingFactor.OneMinusSrcAlpha);
            GL.BlendEquation(BlendEquationMode.FuncAdd);
           
        var error =  Texture.LoadFromFile("Config/errorTex.png",false);
            
          SceneManager.Init();
            logo.Inst("Config/Image328.png", new Vector2(0, 0), new Vector2(1, 1), 0);
            text.InstAndFont(new Vector2(-0.072f, -0.040f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0011f);
            // I327.Inst("Config/Image327.png", new Vector2(0, 0), new Vector2(8f, 4.5f), 0);
            Camera.Gizmo(Debug.gizmo);
            AudioSource.Gizmo(Debug.gizmo);
            AudioSource.Init();

            
            logo.position.Z = 0.00001f;
            I327.position.Z = 0.000002f;
            // GL.PolygonMode(MaterialFace.Front,PolygonMode.Line);

        }
        public static void LightBuildin(Vector3 position)
        {
            Quad gizmolight = new Quad();
            GL.PushMatrix();
            GL.Translate(position);
            GL.Light(LightName.Light0, LightParameter.Position,new Vector4(0,1,0,0));
        
            gizmolight.Update(position,new Vector3(0,0,0),new Vector3(1));
           
            GL.PopMatrix();
           
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
           
           

            GL.Viewport(0, 0, e.Width, e.Height);
            _height = e.Height;
            _width = e.Width;
            try
            {
                aspect = e.Width / e.Height;
            }
            catch
            {
                Debug.Log("Приложение свернуто");
            }
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            
          
            // GL.Ortho(0, e.Width, 0, e.Height, 0,1000);
            
            try
            {
                Matrix4 perspectiveMatrix;
                 Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), e.Width /(float) e.Height, 0.1f,1000 ,out perspectiveMatrix);
                GL.LoadMatrix(ref perspectiveMatrix);
            }
            catch
            {
            Debug.ExitError("OpenGL: Ошибка соотношения сторон");
                Window.Exit();
            }

            
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {

           
            // GL.LightModel(LightModelParameter.LightModelAmbient,0f);
            // GL.ClearColor(Color4.LightBlue);

            Window.stk = KeyboardState;
            Window.mtk = MouseState;
          




            if (!stk.IsKeyReleased(Keys.F11))
            {
                if (stk.IsKeyPressed(Keys.F11))
                {
                    isfullscreen = !isfullscreen;
                    if (!isfullscreen) { WindowState = WindowState.Fullscreen; }
                   else { WindowState = WindowState.Normal; }


                }
            }

            if (!stk.IsKeyReleased(Keys.F10))
            {
                if (stk.IsKeyPressed(Keys.F10))
                {
                  VSyncYN = !VSyncYN;
                    


                }
            }


            if (VSyncYN)
            {
                VSync = VSyncMode.On;

            }
            else if (!VSyncYN)
            {
                VSync = VSyncMode.Off;

            }




            Time.DeltaTime = (float)args.Time * Time.Scale;
            
            base.OnUpdateFrame(args);
            
            if (exit)
            {
                Close();
            }
            
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            MouseX = mtk.PreviousX / _width;
            MouseY = mtk.PreviousY / _height;

            // GL.LineWidth(1);


            GL.LoadIdentity();
          
           Matrix4 camera = Matrix4.LookAt(posCam.X,posCam.Y,posCam.Z
                          , posCam.X + vievCam.X, posCam.Y + vievCam.Y, posCam.Z + vievCam.Z
                            , 0,1,0
                );
            GL.LoadMatrix(ref camera);




            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );

            if (logonloaded)
            {
                SceneManager.Update();
            }

            if (!logonloaded)
            {
                //I327.Update();
                text.Update();
                text.translate("Engine ver 0.1");
                if (logonl)
                {
                    if (alphalogon < 1)
                    {
                        alphalogon += 0.5f * Time.DeltaTime;

                    }

                    if (alphalogo < 0.5)
                    {
                        alphalogo += 0.15f * Time.DeltaTime;

                    }
                    else
                    {
                        logonl = false;
                    }
                }
                else
                {
                    if (alphalogon > 0)
                    {
                        alphalogon -= 1f * Time.DeltaTime;


                    }

                    if (alphalogo > 0)
                    {
                        alphalogo -= 0.1f * Time.DeltaTime;


                    }
                    if (alphalogon > 0.2)
                    {

                        logonloaded = true;

                    }

                }
                    logo.color = new Vector4(1, 1, 1, alphalogo);

                logo.Update();
                logo.scl = new Vector2(alphalogo + 1);
                









            }

           

           
             
    
             SwapBuffers();









            if (Debug.filer[5] == "Yes")
            {
                frameTime += (float)args.Time;
                fps++;
                if (frameTime >= 1)
                {
                    Time.FPS = fps;
                    Title = Debug.filer[2] + " FPS - " + fps + " Triangles - " + triangles;
                    fps = 0;
                    frameTime = 0;
                    

                }
            }
            else if (Debug.filer[5] == "No")
            {

            }
            else
            {
                Debug.ExitError("RR3D: Файл конфигурации повреждён!\n Ошибка S6");
                Window.Exit();
            }
            triangles = 0;
            base.OnRenderFrame(args);

            
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }
        public static void Exit()
        {
            exit = true;
        }

    }


}
