using CamadaDados.Producao.Producao;
using CamadaNegocio.Producao.Producao;
using System;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFLanApontamentoProducao : Form
    {
        public TFLanApontamentoProducao()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {

        }

        private void afterNovo()
        {
            using (TFApontamentoProducao fApontamento = new TFApontamentoProducao())
            {
                if(fApontamento.ShowDialog() == DialogResult.OK)
                    if (fApontamento.rApontamento != null)
                        try
                        {
                            TCN_ApontamentoProducao.Gravar(fApontamento.rApontamento, 
                                                           //false, 
                                                           null);
                            MessageBox.Show("Apontamento Produção gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_apontamento_busca.Text = fApontamento.rApontamento.Id_apontamentostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            bsApontamentoProducao.DataSource =
                TCN_ApontamentoProducao.Buscar(id_apontamento_busca.Text,
                                               cd_empresa_busca.Text,
                                               nr_lote_busca.Text,
                                               id_turno.Text,
                                               id_ordem.Text,
                                               string.Empty,
                                               string.Empty,
                                               rgData.NM_Valor,
                                               DT_Inicial.Text,
                                               DT_Final.Text,
                                               string.Empty,
                                               0,
                                               string.Empty,
                                               null);
            bsApontamentoProducao_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsApontamentoProducao.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_ApontamentoProducao.Deletar(bsApontamentoProducao.Current as TRegistro_ApontamentoProducao, null);
                        MessageBox.Show("Apontamento de produção excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_apontamento_busca.Text = (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).Id_apontamentostr;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar apontamento de produção para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarFormulaApontamento()
        {
            if (bsApontamentoProducao.Current != null)
            {
                TCN_FormulaApontamento.BuscarFormula(bsApontamentoProducao.Current as TRegistro_ApontamentoProducao, null);
                bsApontamentoProducao.ResetCurrentItem();
            }
        }

        private void CalcularCustoMPD()
        {
            if (bsApontamentoProducao.Current != null)
            {
                TCN_ApontamentoProducao.CalcularCustoMPD(bsApontamentoProducao.Current as TRegistro_ApontamentoProducao, null);
                bsApontamentoProducao.ResetCurrentItem();
            }
        }

        private void CalcularCustoFixo()
        {
            if (bsApontamentoProducao.Current != null)
            {
                try
                {
                    TCN_ApontamentoProducao.CalcularCustoFixo(bsApontamentoProducao.Current as TRegistro_ApontamentoProducao, null);
                    bsApontamentoProducao.ResetCurrentItem();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.Trim());
                }
            }
        }

        private void VerificarDisponibilidadeMPrima()
        {
            using (Proc_Commoditties.TFDisponibilidadeMPrima fDisponibilidade = new Proc_Commoditties.TFDisponibilidadeMPrima())
            {
                fDisponibilidade.ShowDialog();
            }
        }

        private void TFLanApontamentoProducao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault9);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }
                
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bsApontamentoProducao_PositionChanged(object sender, EventArgs e)
        {
            if (bsApontamentoProducao.Current != null)
            {
                //Buscar estoque apontamento
                (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).LApontamentoEstoque =
                    TCN_Apontamento_Estoque.Buscar((bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).Id_apontamentostr,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    0,
                                                    string.Empty,
                                                    null);
                //Buscar custo fixo apontamento
                (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).LCustoFixo =
                    TCN_Apontamento_CustoFixo.Buscar(
                    (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).Id_apontamentostr,
                    string.Empty,
                    0,
                    string.Empty,
                    null);
                //Buscar Materia Prima Apontamento
                (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).lMPrimaApontamento =
                    TCN_Apontamento_MPrima.Buscar(
                    (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).Id_apontamentostr, null);
                //Buscar Ordem Producao
                (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).lOrdem =
                    TCN_OrdemProducao_X_Apontamento.BuscarOrdem(
                    (bsApontamentoProducao.Current as TRegistro_ApontamentoProducao).Id_apontamentostr, null);
                
                bsApontamentoProducao.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void dt_apontamento_Leave(object sender, EventArgs e)
        {
            CalcularCustoMPD();
            CalcularCustoFixo();
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa_busca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_busca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa_busca.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_lote_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_loteproducao|Lote Produção|200;" +
                              "a.nr_loteproducao|Nº Lote|80;" +
                              "a.cd_loteid|Cd. LoteId|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_lote_busca },
                                            new CamadaDados.Producao.Cadastros.TCD_CadLote(), string.Empty);            
        }

        private void nr_lote_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_loteproducao|=|" + nr_lote_busca.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_lote_busca },
                                            new CamadaDados.Producao.Cadastros.TCD_CadLote());
        }
        
        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLanApontamentoProducao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                VerificarDisponibilidadeMPrima();
        }

        private void bb_turno_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_turno|Turno|200;" +
                              "a.id_turno|Id. Turno|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_turno },
                                new CamadaDados.Producao.Cadastros.TCD_Turno(), string.Empty);
        }

        private void id_turno_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_turno|=|" + id_turno.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_turno },
                                new CamadaDados.Producao.Cadastros.TCD_Turno());
        }

        private void bb_disponibilidade_Click(object sender, EventArgs e)
        {
            VerificarDisponibilidadeMPrima();
        }

        private void TFLanApontamentoProducao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault9);
        }
    }
}
