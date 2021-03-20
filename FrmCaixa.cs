using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrabSistemaDeCaixaV1
{
    public partial class FrmCaixa : Form
    {
        FrmLogin frmLogin = new FrmLogin();
        Produto produto = new Produto();

        
        public FrmCaixa() { 
        }

        public FrmCaixa(string usuarioLogado, DateTime data, Image imageUsuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuarioLogado;
            lblData.Text = Convert.ToString(data);
            ptbUsuarioProdutos.Image = imageUsuario;
        }
        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            produto.EscreProdutos(produto.Get_caminhoProduto(), produto.Get_frutas());
            produto.EscreProdutos(produto.Get_caminhoPreco(), produto.Get_precos());

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin.Show();
        }
        private void cmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ptbProduto.Image = produto.AcharFotoProduto(cmbCodigo.Text, produto.Get_caminhoFotos());
            txtProduto.Text = produto.AcharProduto(cmbCodigo.Text, produto.Get_frutas());
            txtTipo.Text = produto.EscolheTipo(cmbCodigo.Text);
            txtQuantidade.Focus();
            txtQuantidade.ResetText();
            txtSubTotal.ResetText();
            txtPrecoKilo.ResetText();
            txtPrecoUnitario.ResetText();
            decimal[] valor = produto.Get_precos();
            string change = txtTipo.Text;
            if (change == "Unitário")
            {
                txtPrecoUnitario.Text = Convert.ToString(valor[Convert.ToInt32(cmbCodigo.Text)]);
                txtPrecoKilo.Text = null;
            }
            if (change == "Kilo")
            {
                txtPrecoKilo.Text = Convert.ToString(valor[Convert.ToInt32(cmbCodigo.Text)]);
                txtPrecoUnitario.Text = null;
            }
            txtQuantidade.Text = "0";
            txtQuantidade.Focus();
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal[] precos = produto.Get_precos();
            produto._subTotal = precos[Convert.ToInt32(cmbCodigo.Text)] * Convert.ToDecimal(txtQuantidade.Text);
            txtSubTotal.Text = Convert.ToString(produto._subTotal.ToString("F2"));
            produto._total += produto._subTotal;
            txtTotal.Text = Convert.ToString(produto._total.ToString("F2"));
            lvwCompras.Items.Add(Convert.ToString(produto._subTotal));
            produto.EscreTotal(produto.Get_caminhoTotal(), Convert.ToString(produto._total), DateTime.Now,lblUsuario.Text);
        }


        

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cmbCodigo.ResetText();
            txtTipo.ResetText();
            txtPrecoKilo.Text = null;
            txtPrecoUnitario.Text= null;
            txtProduto.Text = null;
            txtQuantidade.Text = null;
            txtSubTotal.Text = null;
            ptbProduto.Image = null;
        }
        private void FrmCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtQuantidade_Validated(object sender, EventArgs e)
        {
            decimal[] precos = produto.Get_precos();
            txtSubTotal.Text = Convert.ToString((precos[Convert.ToInt32(cmbCodigo.Text)] * Convert.ToDecimal(txtQuantidade.Text)).ToString("F2"));
        }
    }
}
