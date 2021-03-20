using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabSistemaDeCaixaV1
{
    public partial class FrmLogin : Form
    {
        
        public string Usuario;
        public string Senha;

        LoginUsuario loginIniciar = new LoginUsuario();


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            loginIniciar.EscreCadastrado(loginIniciar.Get_caminhoUsuario(), loginIniciar.Get_usuario());
            loginIniciar.EscreCadastrado(loginIniciar.Get_caminhoSenha(), loginIniciar.Get_senha());
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            bool logado ;
            Usuario = txtLogin.Text;
            Senha = txtSenha.Text;
            loginIniciar.LerCadastrados(Usuario, Senha, out logado);

            if(logado == true)
            {
                MessageBox.Show("Usuario Logado com sucesso");
                FrmCaixa caixa = new FrmCaixa(Usuario,DateTime.Now,ptbLogin.Image);
                caixa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario não encontrado");
                txtLogin.Text = null;
                txtSenha.Text = null;
                ptbLogin.Image = null;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Text = null;
            txtSenha.Text = null;
            ptbLogin.Image = null;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            ptbLogin.Image = loginIniciar.CaminhoFoto(txtLogin.Text);

        }


        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
