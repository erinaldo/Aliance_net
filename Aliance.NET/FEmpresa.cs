using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aliance.NET
{
    public partial class TFEmpresa : Form
    {
        public string Login
        { get; set; }
        public string LembrarSenha
        { get; set; }
        public string Senha
        { get; set; }
        public string DSEmpresa
        { get; set; }
        public string DSBanco
        { get; set; }
        public string DSServidor
        { get; set; }

        public TFEmpresa()
        {
            InitializeComponent();
        }

        private void TFEmpresa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            txtBancoDados.Text = DSBanco;
            txtServidor.Text = DSServidor;
            txtEmpresa.Text = DSEmpresa;
            if (!string.IsNullOrEmpty(DSEmpresa))
                bb_deletar.Visible = true;
            else
                txtEmpresa.Enabled = true;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
   

            if (string.IsNullOrEmpty(txtEmpresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtServidor.Text))
            {
                MessageBox.Show("Obrigatorio informar endereço servidor banco dados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServidor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBancoDados.Text))
            {
                MessageBox.Show("Obrigatorio informar nome banco dados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBancoDados.Focus();
                return;
            }
            if (!System.IO.Directory.Exists("C:\\Aliance.NET"))
                System.IO.Directory.CreateDirectory("C:\\Aliance.NET");
            if (!System.IO.File.Exists("C:\\Aliance.NET\\ConectAliance.xml"))
            {
                XElement xml = new XElement("conexao",
                                            new XElement("usuario", new XAttribute("login", Login.Trim()), new XAttribute("lembrarsenha", LembrarSenha.Trim()), new XAttribute("senha", Utils.Estruturas.CalcChaveAcesso(Senha)),
                                            new XElement("empresa", 
                                                           new XAttribute("id", txtEmpresa.Text.Trim()),
                                                           new XAttribute("qtd_conect", 0),
                                                           new XElement("servidor", txtServidor.Text.Trim()),
                                                           new XElement("banco", txtBancoDados.Text.Trim()))));
                xml.Save("C:\\Aliance.NET\\ConectAliance.xml");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
                //Verificar se existe elemento para o usuario
                IEnumerable<XElement> usuario =
                    from x in xml.Elements("usuario")
                    where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Trim().ToUpper())
                    select x;
                if (usuario.Count() > 0)
                {
                    int i = 0;
                    foreach (XElement no in usuario)
                    {
                        no.Attribute("lembrarsenha").SetValue(LembrarSenha.Trim());
                        no.Attribute("senha").SetValue(Utils.Estruturas.CalcChaveAcesso(Senha));
                        //Verificar se ja existe configuracao para esta empresa
                        IEnumerable<XElement> emp =
                            from y in no.Elements("empresa")
                            where y.Attribute("id").Value.Trim().ToUpper().Equals(txtEmpresa.Text.Trim())
                            select y;
                        if (i == 0)
                        {
                            i++;
                            if (emp.Count() > 0)
                                foreach (XElement ep in emp)
                                {
                                    ep.Element("servidor").SetValue(txtServidor.Text.Trim());
                                    ep.Element("banco").SetValue(txtBancoDados.Text.Trim());
                                }
                            else
                                no.Add(new XElement("empresa",
                                                    new XAttribute("id", txtEmpresa.Text.Trim()),
                                                    new XAttribute("qtd_conect", 0),
                                                    new XElement("servidor", txtServidor.Text.Trim()),
                                                    new XElement("banco", txtBancoDados.Text.Trim())));
                        }
                    }
                    xml.Save("C:\\Aliance.NET\\ConectAliance.xml");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    //Novo no usuario
                    XElement user = new XElement("usuario", new XAttribute("login", Login.Trim()), new XAttribute("lembrarsenha", LembrarSenha.Trim()), new XAttribute("senha", Utils.Estruturas.CalcChaveAcesso(Senha)),
                                                 new XElement("empresa", 
                                                                new XAttribute("id", txtEmpresa.Text.Trim()),
                                                                new XAttribute("qtd_conect", 0),
                                                                new XElement("servidor", txtServidor.Text.Trim()),
                                                                new XElement("banco", txtBancoDados.Text.Trim())));
                    xml.Add(user);
                    xml.Save("C:\\Aliance.NET\\ConectAliance.xml");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void bb_conexao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServidor.Text))
            {
                MessageBox.Show("Obrigatorio informar servidor para testar conexão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServidor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBancoDados.Text))
            {
                MessageBox.Show("Obrigatorio informar banco dados para testar conexão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBancoDados.Focus();
                return;
            }
            try
            {
                BancoDados.TObjetoBanco banco = new BancoDados.TObjetoBanco();
                banco.CriarConexao(Login.Trim(), txtServidor.Text, txtBancoDados.Text);
                banco.Conexao.Open();
                if (banco.Conexao.State == ConnectionState.Open)
                {
                    MessageBox.Show("Conexão aberta com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    banco.Conexao.Close();
                }
                else
                    MessageBox.Show("Erro abrir conexão. Verifique nome do servidor ou banco de dados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show("Erro teste conexão: " + ex.Message.Trim()); }
        }

        private void afterDeletar()
        {

            XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
            //Verificar se existe elemento para o usuario
            IEnumerable<XElement> usuario =
                from x in xml.Elements("usuario")
                where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Trim().ToUpper())
                select x;
            if (usuario.Count() > 0)
            {
                foreach (XElement no in usuario)
                {
                    no.Attribute("lembrarsenha").SetValue(LembrarSenha.Trim());
                    no.Attribute("senha").SetValue(Utils.Estruturas.CalcChaveAcesso(Senha));
                    //Verificar se ja existe configuracao para esta empresa
                    IEnumerable<XElement> emp =
                        from y in no.Elements("empresa")
                        where y.Attribute("id").Value.Trim().ToUpper().Equals(txtEmpresa.Text.Trim())
                        select y;
                    if (emp.Count() > 0)
                        foreach (XElement ep in emp)
                        {
                            ep.Remove();
                        }
                }
                xml.Save("C:\\Aliance.NET\\ConectAliance.xml");
                this.DialogResult = DialogResult.OK;
            }
        }


        private void bb_deletar_Click(object sender, EventArgs e)
        {
            afterDeletar();
            this.DialogResult = DialogResult.OK;


            
        }
    }
}
