using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace AlianceAtualiza
{
    public partial class TFConfig : Form
    {
        public TFConfig()
        {
            InitializeComponent();
        }

        private void bbSalvar_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists("C:\\Aliance.NET\\Versao"))
                System.IO.Directory.CreateDirectory("C:\\Aliance.NET\\Versao");
            if (!System.IO.File.Exists("C:\\Aliance.NET\\Versao\\ConectAlianceAtualiza.xml"))
            {
                XElement xml = new XElement("conexao",
                                            new XElement("usuario", new XAttribute("login", loginFTP.Text.Trim()), 
                                            new XElement("ftp",
                                                           new XAttribute("servidor", servidorFTP.Text.Trim()),
                                                           new XAttribute("loginftp", loginFTP.Text.Trim()),
                                                           new XElement("senhaftp", senhaFTP.Text.Trim()))));
                xml.Save("C:\\Aliance.NET\\Versao\\ConectAlianceAtualiza.xml");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XElement xml = XElement.Load("C:\\Aliance.NET\\Versao\\ConectAlianceAtualiza.xml");
                //Verificar se existe elemento para o usuario
                IEnumerable<XElement> usuario =
                    from x in xml.Elements("usuario")
                    where x.Attribute("login").Value.Trim().ToUpper().Equals(loginFTP.Text.Trim().ToUpper())
                    select x;
                if (usuario.Count() > 0)
                {
                    int i = 0;
                    foreach (XElement no in usuario)
                    {
                        //Verificar se ja existe configuracao para esta empresa
                        IEnumerable<XElement> emp =
                            from y in no.Elements("ftp")
                            where y.Attribute("servidor").Value.Trim().ToUpper().Equals(servidorFTP.Text.Trim())
                            select y;
                        if (i == 0)
                        {
                            i++;
                            if (emp.Count() > 0)
                                foreach (XElement ep in emp)
                                {
                                    ep.Element("loginftp").SetValue(loginFTP.Text.Trim());
                                    ep.Element("senhaftp").SetValue(senhaFTP.Text.Trim());
                                }
                            else
                                no.Add(new XElement("ftp",
                                                    new XAttribute("servidor", servidorFTP.Text.Trim()),
                                                    new XAttribute("loginftp", loginFTP.Text.Trim()),
                                                    new XElement("senhaftp", senhaFTP.Text.Trim())));
                        }
                    }
                    xml.Save("C:\\Aliance.NET\\Versao\\ConectAlianceAtualiza.xml");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    //Novo no usuario

                    XElement user = new XElement("conexao",
                                           new XElement("usuario", new XAttribute("login", loginFTP.Text.Trim()),
                                           new XElement("ftp",
                                                          new XAttribute("servidor", servidorFTP.Text.Trim()),
                                                          new XAttribute("loginftp", loginFTP.Text.Trim()),
                                                          new XElement("senhaftp", senhaFTP.Text.Trim()))));
                    xml.Add(user);
                    xml.Save("C:\\Aliance.NET\\Versao\\ConectAlianceAtualiza.xml");
                    this.DialogResult = DialogResult.OK;
                }
            }


            AlianceAtualiza.Properties.Settings.Default.Save();
            this.Close();
        }


    }
}
