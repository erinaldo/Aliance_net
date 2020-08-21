using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Querys;
using Querys.Financeiro;
using Querys.Fiscal;
using CamadaDados.Diversos;
using ReportViewer;



namespace CadFinanceiro.Relatorios
{
    public partial class FRel_Fin_Clifor : FormRelPadrao.FRelPadrao
    {
        public FRel_Fin_Clifor()
        {
            InitializeComponent();
        }
        public override void afterPrint()
        {
            FReportViewer Relatorio = new FReportViewer();
            Relatorio.Nome_rpt = "RClifor.rpt";
            TDatClifor Query = new TDatClifor();
            this.prepararBusca(pFiltro, ref vTP_Busca);
            Relatorio.Tb_relatorio = Query.Buscar(this.vTP_Busca, 0);
            Relatorio.Show();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                    new TDatClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Clifor|350;" +
                               "a.CD_Clifor|Cód. Clifor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                    new TDatClifor(), "");
        }

        private void ID_Regiao_Leave(object sender, EventArgs e)
        {
            string vColunas = iD_Regiao.NM_CampoBusca + "|=|'" + iD_Regiao.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { iD_Regiao, nM_Regiao },
                                    new TCD_CadRegiaoVenda()); 
        }

        private void bb_regiao_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_Regiao| Região Venda|350;" +
                  "ID_Regiao|Cód. Região Venda |100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { iD_Regiao, nM_Regiao },
                                    new TCD_CadRegiaoVenda(), "");
        }

        private void Cd_CondFiscal_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondFiscal_Clifor|=|'" + Cd_CondFiscal_Clifor.Text + "'"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal } , new TDatCondFiscalClifor());
        }

        private void bb_FiscalClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_CondFiscal|Descrição|200;CD_CondFiscal_Clifor|Cód. Fiscal|100"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal } , new TDatCondFiscalClifor(), null);
        }

        private void CD_Cidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_Cidade.Text + "'",
                new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TDatCidade());
        }

        private void BB_Cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                  "CD_Cidade|Cód. Cidade|100;" +
                  "Distrito|Distrito|200;" +
                  "a.UF|Sigla|60;" +
                  "a.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF, DS_Uf }, new TDatCidade(), null);
        }

        private void bb_uf_Click(object sender, EventArgs e)
        {
            string vColunas = "UF|Sigla|60;" +
                              "CD_UF|Código IBGE|80;" +
                              "DS_UF|Estado|300";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { UF, DS_Uf },
                                    new TDatUf(), "");
        }

        private void UF_Leave(object sender, EventArgs e)
        {
            if (UF.Text.Trim() != "")
            {
                string vColunas = UF.NM_CampoBusca + "|=|'" + UF.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { UF, DS_Uf },
                                        new TDatUf());
            }
            else
                DS_Uf.Clear();
        }

        private void CD_Banco_Leave(object sender, EventArgs e)
        {
            if (CD_Banco.Text.Trim() != "")
            {
                string vColunas = CD_Banco.NM_CampoBusca + "|=|'" + CD_Banco.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Banco, Ds_Banco },
                                        new TDatBanco());
            }
            else
                Ds_Banco.Clear();
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Banco|Descrição Banco|350;" +
                              "CD_Banco|Cód. Banco|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Banco, Ds_Banco },
                                    new TDatBanco(), "");
        }

        private void CB_FitroLimite_CheckedChanged(object sender, EventArgs e)
        {
            Vl_LimCred_Inic.Enabled = CB_FitroLimite.Checked;
            Vl_LimCred_Final.Enabled = CB_FitroLimite.Checked;
        }

        private void CB_FiltroBanco_CheckedChanged(object sender, EventArgs e)
        {
            CD_Banco.Enabled = CB_FiltroBanco.Checked;
            BB_Banco.Enabled = CB_FiltroBanco.Checked;
            Ds_Banco.Enabled = CB_FiltroBanco.Checked;
            Nr_Agencia.Enabled = CB_FiltroBanco.Checked;
        }

        private void rb_Fisica_CheckedChanged(object sender, EventArgs e)
        {
            pDados_PF.Visible = rb_Fisica.Checked;
        }

        private void rb_Juridica_CheckedChanged(object sender, EventArgs e)
        {
            pDados_PJ.Visible = rb_Juridica.Checked;
        }
        private void ST_EQUIPARADO_PJ_CheckedChanged(object sender, EventArgs e)
        {
            ST_AGROPECUARIA.Checked = (!ST_EQUIPARADO_PJ.Checked) && (false);
            ST_AGROPECUARIA.Enabled = !ST_EQUIPARADO_PJ.Checked;
        }

        private void ST_AGROPECUARIA_CheckedChanged(object sender, EventArgs e)
        {
            ST_EQUIPARADO_PJ.Checked = (!ST_AGROPECUARIA.Checked) && (false);
            ST_EQUIPARADO_PJ.Enabled = !ST_AGROPECUARIA.Checked;
        }

    }
}

