using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace TrabSistemaDeCaixaV1
{ 
    public class Produto
    {

        private string _caminhoProduto = Path.Combine(UserPath.makeDirectory(),"Produtos.txt");
        private string _caminhoPreco = Path.Combine(UserPath.makeDirectory(),"Precos.txt");
        private string[] _caminhoFotos =
            {
                UserPath.pathImageProducts("Abacaxi.png"),
                UserPath.pathImageProducts("Banana.png"),
                UserPath.pathImageProducts("Coco.png"),
                UserPath.pathImageProducts("Limão.png"),
                UserPath.pathImageProducts("Maçã.png"),
                UserPath.pathImageProducts("Manga.png"),
                UserPath.pathImageProducts("Melancia.jpg"),
                UserPath.pathImageProducts("Melão.png"),
                UserPath.pathImageProducts("Morango.png"),
                UserPath.pathImageProducts("Uva.png")
            };

        private string _caminhoTotal = Path.Combine(UserPath.makeDirectory(), "Compras.txt");
        private string[] _frutas = { "Abacaxi", "Banana", "Coco", "Limao", "Maçã", "Manga", "Melancia", "Melão", "Morango", "Uva" };
        private decimal[] _precos = { 3.50M, 3.75M, 3.99M, 4.99M, 5.28M, 2.50M, 2.50M, 2.50M, 5.99M, 6.80M };
        public decimal _total {  get; set; }
        public decimal _subTotal { get; set; }
        
        //      METODOS GETTER E SETTER
        public string Get_caminhoTotal()
        {
            return _caminhoTotal;
        }
        
        public string Get_caminhoPreco()
        {
            return _caminhoPreco;
        }
        public string Get_caminhoProduto()
        {
            return _caminhoProduto;
        }
        public string[] Get_caminhoFotos()
        {
            return _caminhoFotos;
        }
        public string[] Get_frutas()
        {
            return _frutas;
        }
        public decimal[] Get_precos()
        {
            return _precos;
        }
        //      FIM GETTERS E SETTERS

        public string EscolheTipo(string codigo)
        {
            string tipo;
            switch (Convert.ToInt32(codigo))
            {
                case 0:
                case 2:
                case 7:
                case 8:
                case 9:
                    tipo = "Unitário";
                    break;
                case 1:
                case 3:
                case 4:
                case 5:
                case 6:
                    tipo = "Kilo";
                    break;
                default:
                    tipo = "Inválido";
                    break;
            }
            return tipo;
        }

        
        public void EscreProdutos(string caminho, string cadastrar)//ESCREVE A INFORMAÇÃO EM UM BLOCO  DE NOTAS
        {
            using(StreamWriter streamWriterProd = new StreamWriter(caminho))
            {
  
                streamWriterProd.WriteLine(cadastrar);
               
                streamWriterProd.Close();
            }
        }
        public void EscreProdutos(string caminho, decimal[] cadastrar)//ESCREVE O PREÇO DOS PRODUTOS EM UM BLOCO  DE NOTAS
        {
            using (StreamWriter streamWriterProd = new StreamWriter(caminho))
            {
                for (int i = 0; i < cadastrar.Length; i++)
                {
                    streamWriterProd.WriteLine(cadastrar[i]);
                }
                streamWriterProd.Close();
            }
        }
        public void EscreProdutos(string caminho, string[] cadastrar)//ESCREVE A INFORMAÇÃO EM UM BLOCO  DE NOTAS 
        {
            using (StreamWriter streamWriterProd = new StreamWriter(caminho))
            {
                for (int i = 0; i < cadastrar.Length; i++)
                {
                    streamWriterProd.WriteLine(cadastrar[i]);
                }
                streamWriterProd.Close();
            }
        }
        public void EscreTotal(string caminho, string cadastrar, DateTime hora, string usuario)//ESCREVE O TOTAL DAS COMPRAS EM UM BLOCO DE NOTAS
        {
            using (StreamWriter streamWriterProd = new StreamWriter(caminho,true))
            {
                
                streamWriterProd.WriteLine("Compra:{0}; Data e Hora:{1} ;Usuário:{2}",cadastrar, hora, usuario);
                
                streamWriterProd.Close();
            }
        }

        public string AcharProduto(string codigo, string[] vetor)//PROCURA A INFORMAÇÃO DENTRO DE UM VETOR
        {
            return vetor[Convert.ToInt32(codigo)];
        }

        public decimal AcharProduto(string codigo, decimal[] vetor)//PROCURA A INFORMAÇÃO DENTRO DE UM VETOR
        {
            return vetor[Convert.ToInt32(codigo)];
        }
        public Image AcharFotoProduto(string codigo, string[] caminho)//PROCURA A FOTO DENTRO DE UM ARQUIVO
        {
            return Image.FromFile(caminho[Convert.ToInt32(codigo)]);
        }
    }
}
