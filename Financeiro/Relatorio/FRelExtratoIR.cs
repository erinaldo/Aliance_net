using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Relatorio
{
    public partial class TFRelExtratoIR : Form
    {
        private bool Altera_relatorio = false;

        public TFRelExtratoIR()
        {
            InitializeComponent();
            //Preencher combo ano
            for (int i = -10; i < 11; i++)
                cbAno.Items.Add(DateTime.Now.Year + i);
            cbAno.Text = DateTime.Now.Year.ToString();
        }

        private void afterPrint()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatório selecionar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            List<CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR> lExtrato =
                new CamadaDados.Financeiro.Duplicata.TCD_ExtratoIR().Select(cbEmpresa.SelectedValue.ToString(),
                                                                            CD_Clifor.Text,
                                                                            cbAno.Text);
            if (lExtrato.Count > 0)
            {
                //Janeiro
                if (!lExtrato.Exists(p => p.Mes.Equals(1)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 1;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(0, reg);
                }
                //Fevereiro
                if (!lExtrato.Exists(p => p.Mes.Equals(2)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 2;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(1, reg);
                }
                //Março
                if (!lExtrato.Exists(p => p.Mes.Equals(3)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 3;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(2, reg);
                }
                //Abril
                if (!lExtrato.Exists(p => p.Mes.Equals(4)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 4;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(3, reg);
                }
                //Maio
                if (!lExtrato.Exists(p => p.Mes.Equals(5)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 5;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(4, reg);
                }
                //Junho
                if (!lExtrato.Exists(p => p.Mes.Equals(6)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 6;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(5, reg);
                }
                //Julho
                if (!lExtrato.Exists(p => p.Mes.Equals(7)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 7;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(6, reg);
                }
                //Agosto
                if (!lExtrato.Exists(p => p.Mes.Equals(8)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 8;
                    reg.Vl_recebido = decimal.Zero;
                    reg.Vl_pago = decimal.Zero;
                    lExtrato.Insert(7, reg);
                }
                //Setembro
                if (!lExtrato.Exists(p => p.Mes.Equals(9)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 9;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(8, reg);
                }
                //Outubro
                if (!lExtrato.Exists(p => p.Mes.Equals(10)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 10;
                    reg.Vl_recebido = decimal.Zero;
                    reg.Vl_pago = decimal.Zero;
                    lExtrato.Insert(9, reg);
                }
                //Novembro
                if (!lExtrato.Exists(p => p.Mes.Equals(11)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 11;
                    reg.Vl_pago = decimal.Zero;
                    reg.Vl_recebido = decimal.Zero;
                    lExtrato.Insert(10, reg);
                }
                //Dezembro
                if (!lExtrato.Exists(p => p.Mes.Equals(12)))
                {
                    CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR reg = new CamadaDados.Financeiro.Duplicata.TRegistro_ExtratoIR().Copy(lExtrato[0]);
                    reg.Mes = 12;
                    reg.Vl_recebido = decimal.Zero;
                    reg.Vl_pago = decimal.Zero;
                    lExtrato.Insert(11, reg);
                }
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = lExtrato;
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_relatorio;
                Rel.DTS_Relatorio = bs;
                Rel.Nome_Relatorio = "REL_FIN_EXTRATO_IR";
                Rel.NM_Classe = "REL_FIN_EXTRATO_IR";
                Rel.Modulo = "FIN";
                Rel.Parametros_Relatorio.Add("PERIODO", cbAno.Text);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "EXTRATO DECLARAÇÃO IMPOSTO RENDA";

                if (Altera_relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "EXTRATO DECLARAÇÃO IMPOSTO RENDA",
                                       fImp.pDs_mensagem);
                    Altera_relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "EXTRATO DECLARAÇÃO IMPOSTO RENDA",
                                           fImp.pDs_mensagem);
            }
        }

        private void TFRelExtratoIR_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
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

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, nm_clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRelExtratoIR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_relatorio = true;
            }
        }
    }
}
