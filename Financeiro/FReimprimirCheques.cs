using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFReimprimirCheques : Form
    {
        private bool Altera_Relatorio = false;
        public TFReimprimirCheques()
        {
            InitializeComponent();
        }

        private void afterPrint()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_banco.Text))
            {
                MessageBox.Show("Obrigatorio informar banco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_banco.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_chequeini.Text))
            {
                MessageBox.Show("Obrigatorio informar numero cheque inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_chequeini.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_chequefin.Text))
            {
                MessageBox.Show("Obrigatorio informar numero cheque final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_chequefin.Focus();
                return;
            }
            //Buscar lista de cheques para imprimir
            CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques =
                new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_banco",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.nr_cheque",
                        vOperador = "between",
                        vVL_Busca = "'" + nr_chequeini.Text.Trim() + "'" + " and " + "'" +  nr_chequefin.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_titulo",
                        vOperador = "=",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.status_compensado, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, 0, string.Empty, "a.nr_cheque asc");
            if (lCheques.Count < 1)
            {
                MessageBox.Show("Não foi encontrado nenhum cheque para imprimir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lCheques.Count > 0)
                try
                {
                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(lCheques);
                    //Imprimir Cópia Cheques
                    if (MessageBox.Show("Deseja Imprimir a Cópia dos Cheques?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        this.ImprimirCopiaCheque(lCheques);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ImprimirCopiaCheque(CamadaDados.Financeiro.Titulo.TList_RegLanTitulo ListaTitulo)
        {
            if (ListaTitulo.Count  > decimal.Zero)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_cheque = new BindingSource();
                    bs_cheque.DataSource = ListaTitulo.OrderBy(p => p.Nr_cheque).ToList();
                    Rel.DTS_Relatorio = bs_cheque;
                    Rel.Ident = "TFCopiaCheque";
                    Rel.NM_Classe = "TFConsultaTitulo";
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "CÓPIA CHEQUE";
                    //Buscar Empresa
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(ListaTitulo[0].Cd_empresa, string.Empty, string.Empty, null);

                    //Buscar moeda para impressao dos cheques
                    ListaTitulo.ForEach(p =>
                    {
                        //Buscar moeda da conta gerencial
                        CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                            new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                            new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                                    "where x.cd_moeda = a.cd_moeda "+
                                                    "and x.cd_contager = '" + p.Cd_contager + "')"
                                    }
                                }, 1, string.Empty);
                        if (lMoeda.Count > 0)
                        {
                            p.Ds_moeda = lMoeda[0].Ds_moeda_singular;
                            p.Ds_moeda_plural = lMoeda[0].Ds_moeda_plural;
                        }
                    });
                    Rel.Adiciona_DataSource("BIMEMPRESA", BinEmpresa);
                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "CÓPIA CHEQUE",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
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
                                                    "CÓPIA CHEQUE",
                                                    fImp.pDs_mensagem);
                }
            }
        }

        private void TFReimprimirCheques_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome Empresa|150;a.CD_EMPRESA|Código|80"
                , new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_BANCO|Descrição|150;CD_BANCO|Código|80", 
                new Componentes.EditDefault[] { cd_banco, ds_banco }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), 
                string.Empty);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam
                                    , new Componentes.EditDefault[] { cd_banco, ds_banco }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void TFReimprimirCheques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterPrint();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
