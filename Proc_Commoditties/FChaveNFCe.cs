using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFChaveNFCe : Form
    {
        public TFChaveNFCe()
        {
            InitializeComponent();
        }

        private void TFChaveNFCe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbSerie.DataSource = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_modelo",
                                            vOperador = "=",
                                            vVL_Busca = "'65'"
                                        }
                                    }, 0, string.Empty);
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("Janeiro", "1"));
            cbx.Add(new TDataCombo("Fevereiro", "2"));
            cbx.Add(new TDataCombo("Março", "3"));
            cbx.Add(new TDataCombo("Abril", "4"));
            cbx.Add(new TDataCombo("Maio", "5"));
            cbx.Add(new TDataCombo("Junho", "6"));
            cbx.Add(new TDataCombo("Julho", "7"));
            cbx.Add(new TDataCombo("Agosto", "8"));
            cbx.Add(new TDataCombo("Setembro", "9"));
            cbx.Add(new TDataCombo("Outubro", "10"));
            cbx.Add(new TDataCombo("Novembro", "11"));
            cbx.Add(new TDataCombo("Dezembro", "12"));
            cbMes.DataSource = cbx;
            cbMes.DisplayMember = "Display";
            cbMes.ValueMember = "Value";
        }

        private void bbGerar_Click(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(cbSerie.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar série.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSerie.Focus();
                return;
            }
            if(cbMes.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar mês.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMes.Focus();
                return;
            }
            if(string.IsNullOrEmpty(id_cupomini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Id. Cupom Inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_cupomini.Focus();
                return;
            }
            if(string.IsNullOrEmpty(id_cupomfin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Id. Cupom Final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_cupomfin.Focus();
                return;
            }
            if(string.IsNullOrEmpty(nr_cupomini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Numero Cupom Inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_cupomini.Focus();
                return;
            }
            if(string.IsNullOrEmpty(nr_cupomfin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Numero Cupom Final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_cupomfin.Focus();
                return;
            }
            lbChave.Items.Clear();
            for (int i = int.Parse(nr_cupomini.Text); i <= int.Parse(nr_cupomfin.Text); i++)
            {
                for (int j = int.Parse(id_cupomini.Text); j <= int.Parse(id_cupomfin.Text); j++)
                {
                    string chave = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).rEndereco.Cd_uf.FormatStringEsquerda(2, '0') + //UF Emitente
                                   DateTime.Now.Year.ToString().FormatStringEsquerda(2, '0') + //Ano Emissao
                                   cbMes.SelectedValue.ToString().FormatStringEsquerda(2, '0') + //Mes Emissao
                                   (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).rClifor.Nr_cgc.SoNumero() + //CNPJ Emitente
                                   (cbSerie.SelectedItem as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo.FormatStringEsquerda(2, '0') + //Modelo NFe
                                   (cbSerie.SelectedItem as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).Nr_Serie.FormatStringEsquerda(3, '0') + //Serie NFe
                                   i.FormatStringEsquerda(9, '0') + //Numero Nota Fiscal
                                   "1" + //Tipo Emissao 1 - Normal 9 - OFFLine
                                   j.FormatStringEsquerda(8, '0'); //Numero Lancto Fiscal
                    chave += Estruturas.Mod11(Regex.Replace(chave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
                    lbChave.Items.Add(chave);
                }
            }
            lblTotChaves.Text = "Total Chaves: " + lbChave.Items.Count.ToString();
        }

        private void bbValidar_Click(object sender, EventArgs e)
        {
            lblChave.Text = string.Empty;
            if(lbChave.Items.Count.Equals(0))
            {
                MessageBox.Show("Obrigatório gerar chaves para validar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Buscar CfgNfe
            CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe =
                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null)[0];
            int total_validar = int.Parse(nr_cupomfin.Text) - int.Parse(nr_cupomini.Text) + 1;
            int validos = 0;
            for (int i = 0; i < lbChave.Items.Count; i++)
            {
                string ret = NFCe.ConsultaChave.TConsultaChave.ConsultaChave(lbChave.Items[i].ToString(),
                                                                             "1",
                                                                             rCfgNfe);
                if(!string.IsNullOrEmpty(ret))
                {
                    using (StreamWriter sw = File.AppendText("c:\\work\\chaves.txt"))
                    {
                        sw.WriteLine(lbChave.Items[i].ToString());
                        validos++;
                    }
                    lblChave.Text += "\r\n" + lbChave.Items[i].ToString();
                }
                if (validos >= total_validar)
                    break;
            }
            if (string.IsNullOrEmpty(lblChave.Text))
                lblChave.Text = "Não existe chave valida.";
        }
    }
}
