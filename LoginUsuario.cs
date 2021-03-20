using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TrabSistemaDeCaixaV1
{
    public class LoginUsuario
    {
        private string[] _usuario = { "Brenda", "Patrick", "Karen", "Carlos", "Lucão" };
        private string[] _senha = { "12345", "55555", "00000", "11111", "33333" };
        static string mainPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string _caminhoUsuario = Path.Join(UserPath.makeDirectory(), @"\Usuarios.txt");
        private string _caminhoSenha = Path.Join(UserPath.makeDirectory(),@"\Senhas.txt");
        public  string[] caminhofoto = {
            @"D:\Programação\Arquivos\Trabalhos\Senai\Programação de Aplicativos\TrabSistemaDeCaixaV4\Arquivos\Pessoas\Pessoa1.jpg",
            @"D:\Programação\Arquivos\Trabalhos\Senai\Programação de Aplicativos\TrabSistemaDeCaixaV4\Arquivos\Pessoas\Pessoa2.png",
            @"D:\Programação\Arquivos\Trabalhos\Senai\Programação de Aplicativos\TrabSistemaDeCaixaV4\Arquivos\Pessoas\Pessoa3.jpg",
            @"D:\Programação\Arquivos\Trabalhos\Senai\Programação de Aplicativos\TrabSistemaDeCaixaV4\Arquivos\Pessoas\Pessoa4.png",
            @"D:\Programação\Arquivos\Trabalhos\Senai\Programação de Aplicativos\TrabSistemaDeCaixaV4\Arquivos\Pessoas\Pessoa5.png"
            };

        private bool _verUsu, _verSen = false;
        private int _senhaUsuario;

        public LoginUsuario() { }//METODO CONSTRUTOR

        //METODOS GETTERS E SETTERS
        public string[] Get_usuario() { 

            return _usuario;
        }
        public string[] Get_senha() 
        {
            return _senha;
        }
        public string Get_caminhoUsuario()
        {
            return _caminhoUsuario;
        }
        public string Get_caminhoSenha()
        {
            return _caminhoSenha;
        }


        public void EscreCadastrado(string caminho, string[] cadastrar )//INICIA OS DADOS DENTRO DO BANCO DE DADOS(ARQUIVO .TXT)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(caminho))
                {
                    for (int i = 0; i < cadastrar.Length; i++)
                    {
                        streamWriter.WriteLine(cadastrar[i]);
                    }
                    streamWriter.Close();
                }
            }
            catch(IOException e)
            {
                MessageBox.Show("Erro encontrado: " + e);
            }
            

        }//FIM BANCO


        public bool LerUsuariosCadastrados(string login)//INICIA A LEITURA DO BANCO DE DADOS(ARQUIVO .TXT)
        {
            _verUsu = false;

            using (StreamReader streamReaderUsuario = new StreamReader(_caminhoUsuario))
            {
                for (int i = 0; i < _usuario.Length; i++)
                {
                    string teste = streamReaderUsuario.ReadLine();
                    if (teste == login)
                    {
                        _verUsu = true;
                    }
                }
                streamReaderUsuario.Close();
            }
            return _verUsu;
        }
        public void LerCadastrados(string login, string senha, out bool verificado)//INICIA A LEITURA DO BANCO DE DADOS(ARQUIVO .TXT)
        {
            verificado = false;
            _verSen = false;
            _verUsu = false;
            

            using (StreamReader streamReaderUsuario = new StreamReader(_caminhoUsuario))
            {
                for (int i = 0; i < _usuario.Length; i++)
                {
                    string teste = streamReaderUsuario.ReadLine();
                    if (teste == login)
                    {
                        _verUsu = true;
                        _senhaUsuario = i;
                    }
                }

                streamReaderUsuario.Close();
            }
            if (senha == _senha[_senhaUsuario])
            {
                _verSen = true;
            }

            if (_verUsu==true && _verSen == true)
            {
                verificado = true;
            }
            

        }//FIM DA LEITURA DO BANCO DE DADOS

        public Image CaminhoFoto(string login)// DEFINE A IMAGEM DA TELA DE LOGIN , CONFORME O LOGIN DIGITADO
        {
            Image caminho=null;
            string[] UsuarioAtual;
            for (int i = 0; i < _usuario.Length; i++)
            {
                UsuarioAtual = _usuario;
                if (login == UsuarioAtual[i])
                {
                    caminho = Image.FromFile(caminhofoto[i]);
                }
            }
            return caminho;
        }

    }

}

