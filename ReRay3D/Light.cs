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
    internal class Light
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 color = new(1);
        public float intensity = 1;
        public float size = 1f;



        public void Directional()
        {
            Window.LightBuildin(position, rotation, color, intensity);
        }

        public void Point()
        {
            
            Window.LightBuildinPoint(position, rotation, color,size,intensity);
           
        }

        public void Point2()
        {

            Window.LightBuildinPoint2(position, rotation, color, size, intensity);

        }
        public static void Ambient(Vector3 colorAmbient)
        {
            float[] param = {colorAmbient.X, colorAmbient.Y, colorAmbient.Z, 0};
            GL.LightModel(LightModelParameter.LightModelAmbient, param);
        }

    }
}
