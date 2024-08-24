using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRay3D
{
    internal class LoaderConfFile
    {

      static public List<string> Load(string path) 
        {
            if (!File.Exists(path))
            {
                Debug.ExitError($"Loader: Файл по пути {path} не обнаружен");
                Window.Exit();
            }
            List<string> Conf = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line =  reader.ReadLine()) != null)
                {
                    Conf.Add(line);
                }
            }
            Debug.Log("Load: " + path);
            return Conf;
            
        }


    }
}
