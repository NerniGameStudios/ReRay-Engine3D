using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ReRay3D
{
    
    class Camera
    {
        static int IDcam;
        static int activCam;
        public int thiscam;
       static Quad quad = new Quad();
        bool str;
      static  bool gizmos;
        public Vector3 Position;
        static public Vector3 activeCampos;
        static public Vector3 activeCamrot;
        private float _pitch;
        private float _yaw = -MathHelper.PiOver2;
        static Vector3 f;
        static float u;
        static float p;
        private Vector3 _front = -Vector3.UnitZ;

        private Vector3 _up = Vector3.UnitY;

        private Vector3 _right = Vector3.UnitX;
        public Vector3 Front => _front;

        public Vector3 Up => _up;

        public Vector3 Right => _right;
        public void Update(Vector3 position)
        {
            Position = position;
            if (!str)
            {
                str = true;
                Start();
            }
            if (activCam == thiscam)
            {

                activeCampos = position;
                Window.posCam = position;

            }
            if (gizmos)
            {
               
                
               

                if (activCam != thiscam)
                {
                GL.BindTexture(TextureTarget.Texture2D, 0);
                GL.LineWidth(5);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(1f, 0, 0);
                GL.Vertex3(position);
                GL.Vertex3(f + position);
                
                GL.End();
                    if (f.Z < 0)
                    {
                GL.PushMatrix();
                    GL.Translate(position.X, position.Y, position.Z);
                    
                    GL.Rotate(-f.X * 90, 0, 1, 0);
                    GL.Rotate(f.Y * 90,1,0,0);
                        quad.scale = new Vector3(0.2f, 0.2f, 0.2f);
                        quad.rotate = new Vector3(0, 0, 0);
                        quad.Update();
                   

                    GL.PopMatrix();
                    }
                    else
                    {
                    GL.PushMatrix();
                    GL.Translate(position.X, position.Y, position.Z);

                    GL.Rotate(f.X * 90, 0, 1, 0);
                    GL.Rotate(-f.Y * 90, 1, 0, 0);

                        quad.scale = new Vector3(0.2f, 0.2f, 0.2f);
                        quad.rotate = new Vector3(0, 180, 0);
                        quad.Update();


                    GL.PopMatrix();
                    }
                    
                    
                }
                
            }
        }
        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set
            {

                if (activCam == thiscam)
                {

                   
            var angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
                }
                
            }
        }
        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(_yaw);
            set
            {
                if (activCam == thiscam)
                {

                    _yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();

                }
               
            }
        }

        private void UpdateVectors()
        {
            if (activCam == thiscam)
            {
                
               Window.vievCam.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
            Window.vievCam.Y = MathF.Sin(_pitch);
            Window.vievCam.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);

               
            
            Window.vievCam = Vector3.Normalize(Window.vievCam);
            
            _front.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
            _front.Y = MathF.Sin(_pitch);
            _front.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);
            _front = Vector3.Normalize(_front);
            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));
                f = Vector3.Normalize(_front);
            }
            else
            {
                
            }
            

        }
        static public void Gizmo(bool active)
        {
            
          quad.LoadText("Config/ICONCamera.png", true);
            gizmos = true;
        }
        public void Start()
        {
           
                
            
            IDcam++;
            thiscam = IDcam;
        }
        public void main()
        {
            Window.vievCam = new Vector3(0,0,-1);
            activCam = thiscam;
        }
        public void main(Vector3 lookat)
        {
            
            Window.vievCam =lookat;
            activCam = thiscam;
            activeCamrot = Window.vievCam;
        }

    }
}
