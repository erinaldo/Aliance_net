using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFExportDominio : Form
    {
        public TFExportDominio()
        {
            InitializeComponent();
        }

        private void Exportar()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ini.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_fin.Focus();
                return;
            }
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    CamadaDados.Contabil.TList_LanContabil lContabil = new CamadaDados.Contabil.TCD_LanctosCTB().SelectImportDominio(cbEmpresa.SelectedValue.ToString(),
                                                                                                                                     DateTime.Parse(dt_ini.Text),
                                                                                                                                     DateTime.Parse(dt_fin.Text));
                    if(lContabil.Count > 0)
                    {
                        StringBuilder str = new StringBuilder();
                        string linha = "@DATA;@DEBITO;@CREDITO;@VALOR;@HISTORICO;";
                        decimal? loteOld = lContabil[0].ID_LoteCTB;
                        lContabil.ForEach(p =>
                            {
                                if (loteOld != p.ID_LoteCTB)
                                {
                                    loteOld = p.ID_LoteCTB;
                                    str.AppendLine(linha);
                                    linha = "@DATA;@DEBITO;@CREDITO;@VALOR;@HISTORICO;";
                                }
                                //Data
                                linha = linha.Replace("@DATA", p.Data.Value.ToString("dd/MM/yyyy"));
                                //Conta Debito
                                if(p.D_c.Trim().ToUpper().Equals("D"))
                                    linha = linha.Replace("@DEBITO", p.Cd_conta_ctbstr);
                                //Conta Credito
                                if (p.D_c.Trim().ToUpper().Equals("C"))
                                    linha = linha.Replace("@CREDITO", p.Cd_conta_ctbstr);
                                //Valor
                                linha = linha.Replace("@VALOR", p.Valor.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero());
                                //Historico
                                linha = linha.Replace("@HISTORICO", p.Ds_compl_historico.Trim());
                            });
                        if (linha.Trim().ToUpper() != "@DATA;@DEBITO;@CREDITO;@VALOR;@HISTORICO;")
                            str.AppendLine(linha);
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fbd.SelectedPath +
                                                                                      System.IO.Path.DirectorySeparatorChar.ToString() +
                                                                                      dt_ini.Text.SoNumero() + "_" + dt_fin.Text.SoNumero() + ".txt",
                                                                                      false,
                                                                                      System.Text.Encoding.Default))
                        {
                            sw.Write(str.ToString());
                            sw.Close();
                            MessageBox.Show("Arquivo gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else MessageBox.Show("Obrigatório selecionar PATH para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TFExportDominio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.Exportar();
        }

        private void TFExportDominio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.Exportar();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
