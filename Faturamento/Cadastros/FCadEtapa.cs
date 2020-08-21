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
    public partial class TFCadEtapa : Form
    {
        public TFCadEtapa()
        {
            InitializeComponent();
        }

        private void FCadEtapa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        public void afterBusca()
        {
            bsEtapa.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Busca(string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null
                                                                                  );

            bsEtapa.ResetCurrentItem();
            bsEtapa_PositionChanged(this, new EventArgs());

        }

        private void bbInserirEtapa_Click(object sender, EventArgs e)
        {
            bsEtapa.AddNew();

            using (FEtapa fEtapa = new FEtapa())
            {
                if (fEtapa.ShowDialog() == DialogResult.OK)
                    if (fEtapa.rEtapa != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Gravar(fEtapa.rEtapa, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            afterBusca();
        }
        private void afterExcluiEtapa()
        {
            if (bsEtapa.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Deseja excluir esta etapa.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Excluir(bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa, null);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bbInserirProcesso_Click(object sender, EventArgs e)
        {

            bsProcessor.AddNew();
            Utils.InputBox iB = new Utils.InputBox();
            iB.Text = "Processo:";
            CamadaDados.Faturamento.Cadastros.TRegistro_ProcessoEtapa rProcesso = new CamadaDados.Faturamento.Cadastros.TRegistro_ProcessoEtapa();

            rProcesso.Id_etapa = (bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapa;
            rProcesso.DS_Processo = iB.ShowDialog();
            if (string.IsNullOrEmpty(rProcesso.DS_Processo))
            {
                MessageBox.Show("Obrigatório informar descrição da Processo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CamadaNegocio.Faturamento.Cadastros.TCN_CadProcessoEtapa.Gravar(rProcesso, null);

                MessageBox.Show("Processo Gravado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bsEtapa_PositionChanged(this, new EventArgs());
        }

        private void bbExcluirEtapa_Click(object sender, EventArgs e)
        {
            this.afterExcluiEtapa();
        }

        private void bbExcluirProcesso_Click(object sender, EventArgs e)
        {
            
        
            if (bsProcessor.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Deseja excluir este processo.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        (bsProcessor.Current as CamadaDados.Faturamento.Cadastros.TRegistro_ProcessoEtapa).Id_etapa =
                            (bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapa;

                        CamadaNegocio.Faturamento.Cadastros.TCN_CadProcessoEtapa.Excluir(bsProcessor.Current as CamadaDados.Faturamento.Cadastros.TRegistro_ProcessoEtapa, null);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar processo para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bbAlterarEtapa_Click(object sender, EventArgs e)
        {

            using (FEtapa fEtapa = new FEtapa())
            {
                fEtapa.rEtapa = bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa;

                if (fEtapa.ShowDialog() == DialogResult.OK)
                    if (fEtapa.rEtapa != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Gravar(fEtapa.rEtapa, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            afterBusca();
        }

        private void bsEtapa_PositionChanged(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                (bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).lprocesso =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadProcessoEtapa.Busca(
                        (bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapastr,
                        string.Empty,
                        string.Empty, null
                    );
                bsEtapa.ResetCurrentItem();
            }

        }

        private void bbAlterarProcesso_Click(object sender, EventArgs e)
        {
            bbExcluirProcesso_Click(this, new EventArgs());
            bbInserirProcesso_Click(this, new EventArgs());
        }

        private void bb_cima_Click(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                if (bsEtapa.Position - 1 < 0)
                    return;
                try
                {
                    CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa rItem =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Busca((bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapastr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa rItemAnt =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Busca((bsEtapa[bsEtapa.Position - 1] as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapastr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];

                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.MoverRegistros(rItem, rItemAnt, null);
                    this.afterBusca();
                    bsEtapa.MovePrevious();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_baixo_Click(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                if (bsEtapa.Position + 1 > bsEtapa.Count - 1)
                    return;
                try
                {
                    CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa rItem =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Busca((bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapastr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa rItemAnt =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.Busca((bsEtapa[bsEtapa.Position + 1] as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).Id_etapastr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];

                    CamadaNegocio.Faturamento.Cadastros.TCN_CadEtapa.MoverRegistros(rItem, rItemAnt, null);
                    this.afterBusca();
                    bsEtapa.MovePrevious();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        

        
    }
}
