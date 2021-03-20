using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TrabSistemaDeCaixaV1
{
    class UserPath
    {
        static private string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static private string pathSolution = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Arquivos");

        static public string makeDirectory()
        {
            string endPath = Path.Combine(pathDesktop, "Arquivos","BancoTrabalho"); ;
            if (!Directory.Exists(Path.Combine(pathDesktop, "Arquivos", "BancoTrabalho")))
            {
                Directory.CreateDirectory(Path.Combine(pathDesktop, "Arquivos", "BancoTrabalho"));
            }
            return endPath; 
        }
        
        static public string pathImageProducts(string name)
        {
            string image = Path.Combine(pathSolution, "Produtos", name);
            return image;
        }

        static public string pathImagePessoas(string name)
        {
            string image = Path.Combine(pathSolution, "Pessoas", name);
            return image;
        }

    }
}
