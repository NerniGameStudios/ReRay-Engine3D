using Assimp;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D.UserClasses
{
    internal class FreeCam
    {
        Vector3 position = new Vector3(0, 0, 0);
        float speed = 10;
        static private Vector2 _lastPos;
        static private bool _firstMove = true;

       static public Camera camera = new Camera();

        public void init()
        {
            
        }
        public void Update()
        {

          

            if (Window.stk.IsKeyDown(Keys.W))
            {
                position += camera.Front * speed * Time.DeltaTime;
            }

            if (Window.stk.IsKeyDown(Keys.S))
            {
                position -= camera.Front * speed * Time.DeltaTime; ;
            }

            if (Window.stk.IsKeyDown(Keys.A))
            {
                position -= camera.Right * speed * Time.DeltaTime;
            }

            if (Window.stk.IsKeyDown(Keys.D))
            {
                position += camera.Right * speed * Time.DeltaTime;
            }
            if (Window.stk.IsKeyDown(Keys.LeftShift))
            {
                position.Y -= speed * Time.DeltaTime;
            }

            if (Window.stk.IsKeyDown(Keys.Space))
            {
                position.Y += speed * Time.DeltaTime;
            }
            if (Window.stk.IsKeyDown(Keys.Escape))
            {
                Window.Exit();
            }





            
            camera.Update(position);
            camera.main();
            

        }

        static public void Updatemouse()
        {
            const float sensitivity = 0.15f;
            if (_firstMove)
            {
                _lastPos = new Vector2(Window.mtk.X, Window.mtk.Y);
                _firstMove = false;
            }
            else
            {

                var deltaX = Window.mtk.X - _lastPos.X;
                var deltaY = Window.mtk.Y - _lastPos.Y;
                _lastPos = new Vector2(Window.mtk.X, Window.mtk.Y);


                camera.Yaw += deltaX * sensitivity;
                camera.Pitch -= deltaY * sensitivity;
            }
        } 
    }
}
