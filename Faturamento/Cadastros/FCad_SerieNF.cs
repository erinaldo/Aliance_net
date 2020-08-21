using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFCad_SerieNF : Form
    {
        public TFCad_SerieNF()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFSerieNF fSerie = new TFSerieNF())
            {
                if(fSerie.ShowDialog() == DialogResult.OK)
                    if(fSerie.rSerie != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(fSerie.rSerie, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nr_serie.Clear();
                            CD_Modelo.Clear();
                            ds_serienf.Clear();
                            nr_serie.Text = fSerie.rSerie.Nr_Serie;
                            CD_Modelo.Text = fSerie.rSerie.CD_Modelo;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsSerie.Current != null)
                using (TFSerieNF fSerie = new TFSerieNF())
                {
                    fSerie.rSerie = bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF;
                    if(fSerie.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(fSerie.rSerie, null);
                            MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsSerie.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Excluir(bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsSerie.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(nr_serie.Text,
                                                                                          CD_Modelo.Text,
                                                                                          ds_serienf.Text,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
            bsSerie_PositionChanged(this, new EventArgs());
        }

        private void InserirSequencia()
        {
            if(bsSerie.Current != null)
                using (TFSequenciaNF fSeq = new TFSequenciaNF())
                {
                    if(fSeq.ShowDialog() == DialogResult.OK)
                        if(fSeq.rSeq != null)
                            try
                            {
                                fSeq.rSeq.Nr_Serie = (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).Nr_Serie;
                                fSeq.rSeq.Cd_modelo = (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo;
                                CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(fSeq.rSeq, null);
                                MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsSequenciaNf.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(fSeq.rSeq.Nr_Serie,
                                                                                                                        fSeq.rSeq.Cd_modelo,
                                                                                                                        string.Empty,
                                                                                                                        null);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void AlterarSequencia()
        {
            if(bsSequenciaNf.Current != null)
                using (TFSequenciaNF fSeq = new TFSequenciaNF())
                {
                    fSeq.rSeq = bsSequenciaNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF;
                    if(fSeq.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(fSeq.rSeq, null);
                            MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    bsSequenciaNf.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(fSeq.rSeq.Nr_Serie,
                                                                                                            fSeq.rSeq.Cd_modelo,
                                                                                                            string.Empty,
                                                                                                            null);
                }
        }

        private void ExcluirSequencia()
        {
            if(bsSequenciaNf.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Excluir(bsSequenciaNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsSequenciaNf.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFCad_SerieNF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            TS_ItensPedido.Visible = true;
        }

        private void BB_Modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo|200;" +
                              "a.cd_modelo|Codigo|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), string.Empty);
        }

        private void CD_Modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'" + CD_Modelo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF());
        }

        private void bsSerie_PositionChanged(object sender, EventArgs e)
        {
            if (bsSerie.Current != null)
            {
                bsSequenciaNf.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca((bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).Nr_Serie,
                                                                                                        (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo,
                                                                                                        string.Empty,
                                                                                                        null);
                bsSeqInut.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_SeqInutNFe.Buscar(string.Empty,
                                                                                                 (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).Nr_Serie,
                                                                                                 (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo,
                                                                                                 null);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirSequencia();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarSequencia();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirSequencia();
        }

        private void TFCad_SerieNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirSequencia();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarSequencia();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirSequencia();
        }
    }
}
