using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ReRay3D.GUI;
using ReRay3D.Phisics;
using ReRay3D.UserClasses;
namespace ReRay3D
{
    class SceneManager
    {

        static public ExampleScene exampleScene = new();
      
       
       static public int ActiveScene = 0;
   

        static public void Update()
        {

            if (ActiveScene == 0) { exampleScene.Update(); } else { exampleScene.Stop();}
            




            






           
            

          


        }


        static public void UpdateGUI()
        {
            // Пока не используется 
        }



        static public void Init()
        {
            exampleScene.Init();
         






            
            




         
          
          
        }
    }
}
