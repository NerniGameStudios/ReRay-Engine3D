using OpenTK.Mathematics;
using ReRay3D.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ReRay3D.UserClasses
{
    internal class ExampleScene
    {
      //Обязательная переменная
       public bool start = true;

        Mesh magaz = new("Res/Magazin_besplatno.fbx", "Res/supermarket040123.jpg");
        Mesh bochka = new("Res/uiujbcxva_LOD0.fbx", "Res/uiujbcxva_2K_Albedo.jpg");

        Mesh ground = new("Res/plane.fbx");
        Mesh shar = new("Res/shar.fbx", "Res/viejdi1_2K_Albedo.jpg");

        FreeCam freeCam = new();
        AudioSource sound = new();

      

        public Text text4 = new();
        public Text textfps = new();


        float rot;

        int rotate;

        Vector3 posx = new();

        Light point = new();
        Light point2 = new();

        // Эта функция отвечает за прогрузку движка
        // Лучше всего здесь загружать текст и обьекты с текстурами 

        public void Init()

        {
            freeCam.init();
            sound.looped = true;

          

            //                              Позиция                Размер   Покрутить       Не трогать   Отступ между буквами
            
            text4.InstAndFont(new Vector2(-0.017f, -0.040f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            text4.zpos = 0.00001f;
            textfps.InstAndFont(new Vector2(-0.072f, 0.040f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            textfps.zpos = 0.00001f;
        }


        // Выполняется в первый активный кадр 
        public void Start()
        {
            Light.Ambient(new(0.0f));
            bochka.materialShininess = 50;
            bochka.materialSpecular = new(5,5,5,0);

            shar.materialShininess = 50;
            shar.materialSpecular = new(5, 5, 5, 0);
    
            //shar.color = new(0.61f, 0.13f, 0.75f, 0.3f); ;

            sound.Volume = 0.2f;
            sound.Play("Res/ophelia.mp3");
            Debug.Log(" Лучшая сцена ");
        }
        // Выполняется каждый кадр
        public void Update()
        {
            if (start)
            {
                Start();
                start = false;
            }

            rotate++;
            

            

            text4.Update();
            text4.translate("F11 - Fullscreen    F10 - Vsync");

            magaz.position = new Vector3(0, 0, 0);
            magaz.scale = new Vector3(0.15f);
            magaz.rotate = new Vector3(-90, 0, 90);
            magaz.Update();

            magaz.position = new Vector3(10, 0, 6);
            
            magaz.Update();

            bochka.position = new Vector3(1, -1, 5);
            bochka.scale = new Vector3(0.01f);
            bochka.rotate = new Vector3(  0,rotate,0);
            bochka.Update();


            ground.position = new Vector3(10, -1, 10);
            ground.scale = new Vector3(10);
            ground.rotate = new Vector3(-90, 0, 0);
            ground.Update();


            shar.position = new Vector3(3, 0, 3);
            shar.scale = new Vector3(1f);
            shar.rotate = new Vector3(0, 0, 0);
            shar.Update();







            point2.intensity = 7f;
            point2.color = new(1, 0, 0);
            point2.position = new(5, 0.2f, 7);
            point2.Point2();

            rot += 1;

            point.color = new(1,0.93f, 0.55f);
            point.intensity = 1f;
            point.position  = new(10, 0, 10);
            point.rotation = new(rot, rot, 0);
            point.Directional();

            point.intensity = 4f;
            point.color = new(1, 1, 1);

            if (Window.stk.IsKeyDown(Keys.Up))
            {
               posx.X += 0.1f;
            }
            if (Window.stk.IsKeyDown(Keys.Down))
            {
                posx.X -= 0.1f;
            }
            if (Window.stk.IsKeyDown(Keys.Left))
            {
                posx.Z += 0.1f;
            }
            if (Window.stk.IsKeyDown(Keys.Right))
            {
                posx.Z -= 0.1f;
            }


            point.position = posx;
          //  point.Point();


            




            freeCam.Update();

            textfps.Update();
            textfps.translate("FPS " + Time.FPS);

        }
        // Выполняется при переключениии в scenemanager
        public void Stop()
        {
            start = true;
        }
    }
}
