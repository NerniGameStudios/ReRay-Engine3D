using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using IrrKlang;


using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace ReRay3D
{
    internal class AudioSource
    {
        static Quad quad = new Quad();
        public Vector3 Position;
        static bool gizmos;
        public bool looped = false;
        public string name = "BallastHumMedium2.wav";
        ISoundEngine Aengine = new ISoundEngine();
        public float Volume =1f;
        [STAThread]
        static public void Init()
        {
          
           
        }
        public void Play(string path)
        {
          
            if (File.Exists(path))
            {
                Debug.Log("Loader: "+ path);
                Aengine.Play2D(path,looped);
                Aengine.SoundVolume = Volume;

            }
            else
            {
                Debug.ExitError("AL_NGS: Файл не найден или повреждён! ошибка A1");
            }
           
        }
        public void Play()
        {


           




        }
        public void Play(string path,Vector3 pos)
        {
            
            Position = pos;
            if (File.Exists(path))
            {
                Debug.Log("Loader: " + path);
                Aengine.Play3D(path,pos.X,pos.Y,pos.Z,looped);
                Aengine.SoundVolume = Volume;

            }
            else
            {
                Debug.ExitError("AL_NGS: Файл не найден или повреждён! ошибка A1");
            }
            
        }
        public void Stop()
        {
            Aengine.StopAllSounds();
        }
        static public void Gizmo(bool active)
        {

            quad.LoadText("Config/ICONAS.png", true);
            gizmos = true;
        }
        public void Update(Vector3 rot)
        {
            Aengine.SoundVolume = Volume;
            Aengine.Update();
            
            if (Window.vievCam.Z > 0)
            {
                Aengine.SetListenerPosition(Camera.activeCampos.X, Camera.activeCampos.Y, Camera.activeCampos.Z, Window.vievCam.X * -Camera.activeCampos.Z, Window.vievCam.Y, 0);
            }
            else
            {
                Aengine.SetListenerPosition(Camera.activeCampos.X, Camera.activeCampos.Y, Camera.activeCampos.Z, -Window.vievCam.X * Camera.activeCampos.Z, Window.vievCam.Y, 0);
            }
           

            if (gizmos)
            {
                if (Window.vievCam.Z < 0)
                {
                    GL.PushMatrix();
                    GL.Translate(Position.X, Position.Y, Position.Z);

                    GL.Rotate(-Window.vievCam.X * 90, 0, 1, 0);
                    GL.Rotate(Window.vievCam.Y * 90, 1, 0, 0);

                    quad.scale = new Vector3(0.2f, 0.2f, 0.2f);
                    quad.rotate = new Vector3(0, 0, 0);
                    quad.Update();


                    GL.PopMatrix();
                }
                else
                {
                    GL.PushMatrix();
                    GL.Translate(Position.X, Position.Y, Position.Z);

                    GL.Rotate(Window.vievCam.X * 90, 0, 1, 0);
                    GL.Rotate(-Window.vievCam.Y * 90, 1, 0, 0);

                    quad.scale = new Vector3(0.2f, 0.2f, 0.2f);
                    quad.rotate = new Vector3(0, 180, 0);
                    quad.Update();


                    GL.PopMatrix();
                }
                
              

            }
        }
    }
}