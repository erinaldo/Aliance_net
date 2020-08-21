using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLanDevolucaoVenda : Form
    {
        private bool Altera_Relatorio;

        public TFLanDevolucaoVenda()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsDevolucao.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Devolucao.Buscar(cd_empresa.Text,
                                                                                        id_devolucao.Text,
                                                                                        id_cupom.Text,
                                                                                        cd_produto.Text,
                                                                                        DT_Inicial.Text,
                                                                                        DT_Final.Text,
                                                                                        false,
                                                                                        null);
            bsDevolucao_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsDevolucao.Current != null)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Faturamento.PDV.TList_Devolucao() { bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "FRel_Devolucao";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_Devolucao";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pMensagem = "DEVOLUÇÃO DE COMPRAS";

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
                                           "DEVOLUÇÃO DE COMPRAS",
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
                                               "DEVOLUÇÃO DE COMPRAS",
                                               fImp.pDs_mensagem);
                }
        }

        private void TFLanDevolucaoVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'", new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsDevolucao_PositionChanged(object sender, EventArgs e)
        {
            if (bsDevolucao.Current != null)
            {
                //Buscar itens
                (bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).lItensDev =
                    CamadaNegocio.Faturamento.PDV.TCN_ItensDevolvidos.Buscar((bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Cd_empresa,
                                                                             (bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Id_devolucaostr,
                                                                             string.Empty,
                                                                             null);
                //Buscar Adto
                if((bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Id_adto.HasValue)
                    (bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).lAdto =
                        CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar((bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Id_adtostr,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         false,
                                                                                         false,
                                                                                         false,
                                                                                         string.Empty,
                                                                                         false,
                                                                                         false,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         0,
                                                                                         string.Empty,
                                                                                         null);
                //Buscar Parcelas
                (bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).lDevFin =
                    CamadaNegocio.Faturamento.PDV.TCN_DevolucaoFIN.Buscar((bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Cd_empresa,
                                                                          (bsDevolucao.Current as CamadaDados.Faturamento.PDV.TRegistro_Devolucao).Id_devolucaostr,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                bsDevolucao.ResetCurrentItem();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLanDevolucaoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }
    }
}
