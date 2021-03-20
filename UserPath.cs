using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TrabSistemaDeCaixaV1
{
    class UserPath
    {
        static private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static public string makeDirectory()
        {
            string endPath = Path.Join(path, @"/Arquivos/BancoTrabalho"); ;
            if (!Directory.Exists(Path.Join(path, @"/Arquivos/BancoTrabalho")))
            {
                Directory.CreateDirectory(Path.Join(path, @"/Arquivos/BancoTrabalho"));
            }
            return endPath; 
        }
        
        static public string pathImage(string name)
        {
            string image = Path.Join(makeDirectory(),name);
            return image;
        }


    }
}
