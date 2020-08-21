using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFDadosDuplicata : Form
    {
        public string pCd_empresa
        { get; set; }
        public string vTp_Duplicata
        { get { return tp_duplicata.Text; } }
        public string vCondPagto
        { get { return cd_condpgto.Text; } }
        public string vCd_historico
        { get { return cd_historico.Text; } }
        public string vTp_docto
        { get { return tp_docto.Text; } }
        public string vCd_centroresult
        { get { return cd_ccusto.Text; } }
        public TFDadosDuplicata()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Duplicata|=|'" + tp_duplicata.Text + "'";
                vColunas += ";a.TP_Mov|=|'P'";
            DataRow linha = UtilPesquisa.EDIT_LeaveTpDuplicata(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov });
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov }, vParamFixo);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CondPgto|=|'" + cd_condpgto.Text + "';" +
                              "a.qt_parcelas|=|1";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{ cd_condpgto, ds_condpagto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100;" +
                              "d.CD_Juro|Cód. Juro|100;" +
                              "d.DS_Juro|Descrição Juro|350";
            string vParam = "a.qt_parcelas|=|1";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpagto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text + "';" +
                              "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100;" +
                              "a.cd_Historico_Quitacao|Cd. Quitação|80;" +
                              "e.DS_Historico|Historico Quitação|200";
            string vParamFixo = "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Docto|=|'" + tp_docto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                             "TP_Docto|TP. Docto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), "");
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFDadosDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFDadosDuplicata_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }

        private void cd_ccusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|'" + cd_ccusto.Text.Trim() + "';" +
                "isnull(a.st_sintetico, 'N')|<>|'S';";
                vParam += "||(a.tp_registro = 'D') or (a.tp_registro = 'R' and isnull(a.st_deducao, 'N') = 'S')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ccusto, ds_ccusto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_ccusto_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                string vParam = "'D' or (a.tp_registro = 'R' and isnull(a.st_deducao, 'N') = 'S')";
                fBusca.Tp_registro = vParam;
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_ccusto.Text = fBusca.Cd_centro;
                        ds_ccusto.Text = fBusca.Ds_centro;
                    }
            }
        }
    }
}
