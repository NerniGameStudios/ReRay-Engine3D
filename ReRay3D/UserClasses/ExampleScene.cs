using OpenTK.Mathematics;
using ReRay3D.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D.UserClasses
{
    internal class ExampleScene
    {
      //Обязательная переменная
       public bool start = true;

        public Text text = new();
        public Text text2 = new();
        public Text text3 = new();

        public Text text4 = new();
        public Text textfps = new();

        public Cube cubeExample = new();
        public Cube cubeExample2 = new();
        public Cube cubeExample3 = new();

        float rotateFun;
        float rotateFun2;

        // Эта функция отвечает за прогрузку движка
        // Лучше всего здесь загружать текст и обьекты с текстурами 

        public void Init()
        {
            cubeExample.LoadText("Res/g.png", true);
            cubeExample2.LoadText("Res/g.png", true);
            cubeExample3.LoadText("Res/g.png", true);

            //                              Позиция                Размер   Покрутить       Не трогать   Отступ между буквами
            text.InstAndFont(new Vector2(-0.007f, 0.01f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            text.zpos = 0.00001f;
            text2.InstAndFont(new Vector2(-0.057f, 0.01f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            text2.zpos = 0.00001f;
            text3.InstAndFont(new Vector2(0.047f, 0.01f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            text3.zpos = 0.00001f;
            text4.InstAndFont(new Vector2(-0.017f, -0.040f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            text4.zpos = 0.00001f;
            textfps.InstAndFont(new Vector2(-0.072f, 0.040f), new Vector2(0.09f), 0, new Vector2(224, 224), 0.0014f);
            textfps.zpos = 0.00001f;
        }


        // Выполняется в первый активный кадр 
        public void Start()
        {
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

            text4.Update();
            text4.translate("F11 - Fullscreen    F10 - Vsync");


            cubeExample3.position = new Vector3(5, 0, -10);
            cubeExample3.rotate = new Vector3(rotateFun2);
            cubeExample3.Update();
            rotateFun2 += 50 *Time.DeltaTime;

            text3.Update();
            text3.translate("Time.DeltaTime");

            cubeExample.position = new Vector3(0,0,-10);
            cubeExample.rotate = new Vector3(rotateFun);
            cubeExample.Update();
            rotateFun++;

            text.Update();
            text.translate("Cube rotaion");




            cubeExample2.position = new Vector3(-5, 0, -10);
            cubeExample2.rotate = new Vector3(Window.MouseY * 360, -Window.MouseX * 360, 0);
            cubeExample2.Update();

            text2.Update();
            text2.translate("Cube mouse");



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
