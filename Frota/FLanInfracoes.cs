using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFLanInfracoes : Form
    {
        public TFLanInfracoes()
        {
            InitializeComponent();
        }

        private void TFLanInfracoes_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void LimparRegistro()
        {
            id_infracao.Clear();
            cd_empresa.Clear();
            id_veiculo.Clear();
            id_viagem.Clear();
            cd_motorista.Clear();
            id_despesa.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFInfracoes fInfracao = new TFInfracoes())
            {
                if(fInfracao.ShowDialog() == DialogResult.OK)
                    if (fInfracao.rInfracoes != null)
                    {
                        //Buscar config abast
                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fInfracao.rInfracoes.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                        if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vCd_empresa = fInfracao.rInfracoes.Cd_empresa;
                                fDup.vNm_empresa = fInfracao.rInfracoes.Nm_empresa;
                                if (lCfg.Count > 0)
                                {
                                    fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                    fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                    fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                    fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                    fDup.vTp_mov = "P";
                                    fDup.vCd_historico = lCfg[0].Cd_historico;
                                    fDup.vDs_historico = lCfg[0].Ds_historico;
                                    fDup.vDt_emissao = fInfracao.rInfracoes.Dt_infracaostr;
                                    fDup.vVl_documento = fInfracao.rInfracoes.Vl_infracao;
                                    fDup.vNr_docto = fInfracao.rInfracoes.Cd_infracao;
                                    fDup.vSt_ecf = true;
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            fInfracao.rInfracoes.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                            }
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Gravar(fInfracao.rInfracoes, null);
                            MessageBox.Show("Infração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparRegistro();
                            id_infracao.Text = fInfracao.rInfracoes.Id_infracaostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if(bsInfracoes.Current != null)
                using (TFInfracoes fInfracao = new TFInfracoes())
                {
                    fInfracao.rInfracoes = bsInfracoes.Current as CamadaDados.Frota.Cadastros.TRegistro_Infracoes;
                    if(fInfracao.ShowDialog() == DialogResult.OK)
                        if(fInfracao.rInfracoes != null)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Gravar(fInfracao.rInfracoes, null);
                                MessageBox.Show("Infração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparRegistro();
                                id_infracao.Text = fInfracao.rInfracoes.Id_infracaostr;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsInfracoes.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Excluir(bsInfracoes.Current as CamadaDados.Frota.Cadastros.TRegistro_Infracoes, null);
                        MessageBox.Show("Infração excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparRegistro();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsInfracoes.DataSource = CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Buscar(id_veiculo.Text,
                                                                                        id_infracao.Text,
                                                                                        id_viagem.Text,
                                                                                        cd_empresa.Text,
                                                                                        cd_motorista.Text,
                                                                                        id_despesa.Text,
                                                                                        rbInfracao.Checked ? "I" : "V",
                                                                                        dt_ini.Text,
                                                                                        dt_fin.Text,
                                                                                        0,
                                                                                        null);
            tot_infracao.Value = (bsInfracoes.List as CamadaDados.Frota.Cadastros.TList_Infracoes).Sum(p => p.Vl_infracao);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Viagem|200;" +
                              "a.id_viagem|Id. Viagem|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem },
                                             new CamadaDados.Frota.TCD_Viagem(), string.Empty);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|" + id_viagem.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem },
                                            new CamadaDados.Frota.TCD_Viagem());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, "isnull(a.st_motorista, 'N')|=|'S';isnull(a.ST_AtivoMot, 'N')|=|'S'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                                                    "isnull(a.st_motorista, 'N')|=|'S';" +
                                                    "isnull(a.ST_AtivoMot, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_motorista },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Id. Despesa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(),
                                            string.Empty);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanInfracoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gInfracoes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gInfracoes.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsInfracoes.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_Infracoes());
            CamadaDados.Frota.Cadastros.TList_Infracoes lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gInfracoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gInfracoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_Infracoes(lP.Find(gInfracoes.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gInfracoes.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_Infracoes(lP.Find(gInfracoes.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gInfracoes.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsInfracoes.List as CamadaDados.Frota.Cadastros.TList_Infracoes).Sort(lComparer);
            bsInfracoes.ResetBindings(false);
            gInfracoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
