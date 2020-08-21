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
    public partial class TFLanIntervencaoTecECF : Form
    {
        public TFLanIntervencaoTecECF()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_equipamento.Clear();
            id_intervencao.Clear();
            motivo_intervencao.Clear();
            nr_ose.Clear();
            dt_fin.Clear();
            dt_ini.Clear();
        }

        private void afterNovo()
        {
            using (TFIntervencaoTecECF fIntervencao = new TFIntervencaoTecECF())
            {
                if(fIntervencao.ShowDialog() == DialogResult.OK)
                    if(fIntervencao.rIntervencao != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_IntervencaoTec.Gravar(fIntervencao.rIntervencao, null);
                            MessageBox.Show("Intervenção tecnica gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_intervencao.Text = fIntervencao.rIntervencao.Id_intervencaostr;
                            id_equipamento.Text = fIntervencao.rIntervencao.Id_equipamentostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsIntervencao.Current != null)
                using (TFIntervencaoTecECF fIntervencao = new TFIntervencaoTecECF())
                {
                    fIntervencao.rIntervencao = bsIntervencao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_IntervencaoTec;
                    if(fIntervencao.ShowDialog() == DialogResult.OK)
                        if(fIntervencao.rIntervencao != null)
                            try
                            {
                                CamadaNegocio.Faturamento.Cadastros.TCN_IntervencaoTec.Gravar(fIntervencao.rIntervencao, null);
                                MessageBox.Show("Intervenção tecnica alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                id_intervencao.Text = fIntervencao.rIntervencao.Id_intervencaostr;
                                id_equipamento.Text = fIntervencao.rIntervencao.Id_equipamentostr;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterBusca()
        {
            bsIntervencao.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_IntervencaoTec.Buscar(id_equipamento.Text,
                                                                                                     id_intervencao.Text,
                                                                                                     nr_ose.Text,
                                                                                                     dt_ini.Text,
                                                                                                     dt_fin.Text,
                                                                                                     motivo_intervencao.Text,
                                                                                                     null);
        }

        private void afterExclui()
        {
            if(bsIntervencao.Current != null)
                if(MessageBox.Show("Confirma exclusão da intervenção selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_IntervencaoTec.Excluir(bsIntervencao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_IntervencaoTec, null);
                        MessageBox.Show("Intervenção tecnica excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanIntervencaoTecECF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_equipamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_equipamento|ECF|200;" +
                              "a.id_equipamento|Codigo|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_equipamento },
                                            new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF(), vParam);
        }

        private void id_equipamento_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_equipamento|=|" + id_equipamento.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_equipamento },
                                            new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanIntervencaoTecECF_KeyDown(object sender, KeyEventArgs e)
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
    }
}
