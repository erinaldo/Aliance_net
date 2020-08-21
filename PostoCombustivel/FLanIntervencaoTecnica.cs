using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFLanIntervencaoTecnica : Form
    {
        public TFLanIntervencaoTecnica()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_intervencao.Clear();
            id_bomba.Clear();
            cd_empresa.Clear();
            cd_cliforintervencao.Clear();
            nr_intervencao.Clear();
            ds_motivo.Clear();
            nm_tecnico.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFIntervencaoTecnica fIntervencao = new TFIntervencaoTecnica())
            {
                if(fIntervencao.ShowDialog() == DialogResult.OK)
                    if(fIntervencao.rIntervencao != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_IntervencaoTecnica.Gravar(fIntervencao.rIntervencao, null);
                            MessageBox.Show("Intervenção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_intervencao.Text = fIntervencao.rIntervencao.Id_intervencaostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterAltera()
        {
            if(bsIntervencao.Current != null)
                using (TFIntervencaoTecnica fIntervencao = new TFIntervencaoTecnica())
                {
                    fIntervencao.rIntervencao = bsIntervencao.Current as CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica;
                    if(fIntervencao.ShowDialog() == DialogResult.OK)
                        if(fIntervencao.rIntervencao != null)
                            try
                            {
                                CamadaNegocio.PostoCombustivel.TCN_IntervencaoTecnica.Gravar(fIntervencao.rIntervencao, null);
                                MessageBox.Show("Intervenção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_intervencao.Text = fIntervencao.rIntervencao.Id_intervencaostr;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsIntervencao.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.TCN_IntervencaoTecnica.Excluir(bsIntervencao.Current as CamadaDados.PostoCombustivel.TRegistro_IntervencaoTecnica, null);
                        MessageBox.Show("Intervenção excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsIntervencao.DataSource = CamadaNegocio.PostoCombustivel.TCN_IntervencaoTecnica.Buscar(id_intervencao.Text,
                                                                                                    id_bomba.Text,
                                                                                                    cd_empresa.Text,
                                                                                                    cd_cliforintervencao.Text,
                                                                                                    nr_intervencao.Text,
                                                                                                    ds_motivo.Text,
                                                                                                    nm_tecnico.Text,
                                                                                                    dt_ini.Text,
                                                                                                    dt_fin.Text,
                                                                                                    null);
        }

        private void TFLanIntervencaoTecnica_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pPeriodo.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFLanIntervencaoTecnica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_bomba_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bomba|Id. Bomba|80;" +
                              "a.ds_modelo|Modelo|200;" +
                              "a.nr_serie|Nº Serie|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bomba },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BombaAbastecimento(), string.Empty);
        }

        private void id_bomba_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bomba|=|" + id_bomba.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_bomba },
                                              new CamadaDados.PostoCombustivel.Cadastros.TCD_BombaAbastecimento());
        }

        private void bb_cliforintervencao_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforintervencao }, "a.tp_pessoa|=|'J'");
        }

        private void cd_cliforintervencao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforintervencao.Text.Trim() + "';a.tp_pessoa|=|'J'",
                                                    new Componentes.EditDefault[] { cd_cliforintervencao },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFLanIntervencaoTecnica_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
