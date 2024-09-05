using System;

using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace ReRay3D
{
    internal class Engine
    {
        

        static void Main(string[] args)
        {
            bool error= false;
            Debug.Log("Инициализация Ядра");
            
            Debug.init();
            try {
                int.Parse(Debug.filer[0]);
                int.Parse(Debug.filer[1]);
                } 
            catch 
            { 
                error = true;
                Debug.ExitError("Core: Ошибка работы. Ошибка R1"); 
            } 
            
            var nativeWinSettings = new NativeWindowSettings()
            {
                
                Size = new Vector2i(int.Parse( Debug.filer[0]), int.Parse(Debug.filer[1])),
                Location = new Vector2i(370, 300),
                WindowBorder = WindowBorder.Resizable,
                WindowState = WindowState.Normal,
                Title = Debug.filer[2],
               
                Flags = ContextFlags.Debug,
                APIVersion = new Version(4,2),
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL,
                


            NumberOfSamples = 0
            };
            


            using (Window game = new Window(GameWindowSettings.Default, nativeWinSettings))
            {
                if (!error)
                {
                Debug.Log("Запуск окна");
                game.Run();
                }
                
               
            }
        }
    }
}
