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
    public partial class TFDevolverLocacao : Form
    {
        private CamadaDados.Faturamento.Locacao.TRegistro_Locacao rlocacao;
        public CamadaDados.Faturamento.Locacao.TRegistro_Locacao rLocacao
        {
            get
            {
                if (bsLocacao.Current != null)
                    return bsLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_Locacao;
                else
                    return null;
            }
            set { rlocacao = value; }
        }

        public CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda
        { get; set; }

        public TFDevolverLocacao()
        {
            InitializeComponent();
        }

        private void TFDevolverLocacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensLocacao);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pLocacao.set_FormatZero();
            if (rlocacao != null)
            {
                bsLocacao.DataSource = new CamadaDados.Faturamento.Locacao.TList_Locacao() { rlocacao };
                id_locacao.Enabled = false;
                bb_locacao.Enabled = false;
                id_locacao.Text = rlocacao.Id_locacaostr;
                edtDevolver.Focus();
            }
            else
                id_locacao.Focus();
        }

        private void bb_locacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_locacao|Id. Locação|80;" +
                              "a.cd_clifor|Cd. Cliente|80;" +
                              "b.nm_clifor|Nome Cliente|200;" +
                              "a.cd_empresa|Cd. Empresa|80";
            string vParam = "isnull(a.st_registro, 'A')|=|'R'";
            if (rPreVenda != null)
                vParam += ";a.cd_empresa|=|'" + rPreVenda.Cd_empresa.Trim() + "';" +
                          "a.cd_clifor|=|'" + rPreVenda.Cd_clifor.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_locacao, cd_empresa },
                                            new CamadaDados.Faturamento.Locacao.TCD_Locacao(), vParam);
            if (!string.IsNullOrEmpty(id_locacao.Text))
            {
                CamadaDados.Faturamento.Locacao.TList_Locacao lLocacao =
                 CamadaNegocio.Faturamento.Locacao.TCN_Locacao.buscar(cd_empresa.Text,
                                                                      id_locacao.Text,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'R'",
                                                                      null);
                lLocacao.ForEach(p => p.lItens = CamadaNegocio.Faturamento.Locacao.TCN_ItensLocacao.buscar(p.Cd_empresa,
                                                                                                          p.Id_locacaostr,
                                                                                                          null));
                bsLocacao.DataSource = lLocacao;
            }
        }

        private void id_locacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_locacao|=|" + id_locacao.Text + ";" +
                            "isnull(a.st_registro, 'A')|=|'R'";
            if (rPreVenda != null)
                vParam += ";a.cd_empresa|=|'" + rPreVenda.Cd_empresa.Trim() + "';" +
                          "a.cd_clifor|=|'" + rPreVenda.Cd_clifor.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_locacao, cd_empresa },
                                            new CamadaDados.Faturamento.Locacao.TCD_Locacao());
            if (!string.IsNullOrEmpty(id_locacao.Text))
            {
                CamadaDados.Faturamento.Locacao.TList_Locacao lLocacao =
                 CamadaNegocio.Faturamento.Locacao.TCN_Locacao.buscar(cd_empresa.Text,
                                                                      id_locacao.Text,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'R'",
                                                                      null);
                lLocacao.ForEach(p => p.lItens = CamadaNegocio.Faturamento.Locacao.TCN_ItensLocacao.buscar(p.Cd_empresa,
                                                                                                          p.Id_locacaostr,
                                                                                                          null));
                bsLocacao.DataSource = lLocacao;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFDevolverLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void edtDevolver_Leave(object sender, EventArgs e)
        {
            if ((bsItensLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).Quantidade < edtDevolver.Value)
                edtDevolver.Value = (bsItensLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).Quantidade;
            (bsItensLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).Qtd_devolver = edtDevolver.Value;
            bsItensLocacao.ResetCurrentItem();
            total_custo.Value = (bsItensLocacao.List as CamadaDados.Faturamento.Locacao.TList_ItensLocacao).Sum(p => p.Vl_custoPagar);
        }

        private void bsItensLocacao_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensLocacao.Count > 0)
                edtDevolver.Value = (bsItensLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).Qtd_devolver;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsItensLocacao.MoveNext();
            edtDevolver.Focus();
        }

        private void TFDevolverLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensLocacao);
        }
    }
}
