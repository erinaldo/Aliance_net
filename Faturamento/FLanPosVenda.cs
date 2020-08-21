using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Diversos;
using FormBusca;
using Componentes;
using CamadaDados.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.PosVenda;
using CamadaDados.Faturamento.PosVenda;

namespace Faturamento
{
    public partial class TFLanPosVenda : Form
    {
        public TFLanPosVenda()
        {
            InitializeComponent();
        }

        private void TFLanQuestionario_Load(object sender, EventArgs e)
        {
            panelDados5.set_FormatZero();
            panelDados1.set_FormatZero();


            cbEmpresa.DataSource = new TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresaP.DataSource = new TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);

            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbEmpresaP.DisplayMember = "NM_Empresa";
            cbEmpresaP.ValueMember = "CD_Empresa";
        }

        private void bsQuestionario_PositionChanged(object sender, EventArgs e)
        {
            if (bsQuestionario.Current == null)
                return;

            (bsQuestionario.DataSource as IEnumerable<TRegistro_Questionario>).ToList().ForEach(r => r.Selecionado = false);
            (bsQuestionario.Current as TRegistro_Questionario).Selecionado = true;

            bsPerguntas.DataSource = TCN_Questionario_X_Pergunta.Buscar((bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr,
                                                                        string.Empty,
                                                                        null);
        }

        private void afterBuscarOrc()
        {
            bsOrcamento.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.BuscarPosVenda(nr_orcamento.Text,
                                                                                                      cbEmpresa.SelectedValue.ToString(),
                                                                                                      Cd_clifor.Text,
                                                                                                      nr_pedido.Text,
                                                                                                      DT_InicialP.Text,
                                                                                                      DT_FinalP.Text,
                                                                                                      rbSemPosVenda.Checked,
                                                                                                      rbComPosVenda.Checked,
                                                                                                      rbTodas.Checked,
                                                                                                      null);
            bsOrcamento.ResetBindings(true);
        }

        private void afterBuscarPos()
        {
            string st_registro = string.Empty;
            if (rbAberto.Checked)
                st_registro = "'A'";
            else if (rbEncerramento.Checked)
                st_registro = "'E'";
            else
                st_registro = "'C'";

            bsPosVendaProposta.DataSource = TCN_PosVenda.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                Id_posvenda.Text,
                                                                string.Empty,
                                                                editDefault1.Text,
                                                                string.Empty,
                                                                DT_InicialP.Text,
                                                                DT_FinalP.Text,
                                                                st_registro,
                                                                null);
            bsPosVendaProposta.ResetBindings(true);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
                afterBuscarOrc();
            else if (tabControl1.SelectedIndex.Equals(1))
                afterBuscarPos();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { Cd_clifor, nm_clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

            if (string.IsNullOrEmpty(Cd_clifor.Text))
                nm_clifor.Text = "";
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lItens =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                    false,
                    false,
                    null);

                bsOrcamento.ResetCurrentItem();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab.Text.Equals("Questionário"))
            {
                bsQuestionario.DataSource = TCN_CadQuestionario.Buscar(string.Empty, string.Empty, null, "0");
            }
        }

        private void bsPerguntas_PositionChanged(object sender, EventArgs e)
        {
            if (bsPerguntas.Current == null)
                return;

            bsRespostas.DataSource = TCN_Pergunta_X_Resposta.Buscar((bsPerguntas.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr,
                                                                    string.Empty,
                                                                    null);
        }

        private void BB_SalvarResposta_Click(object sender, EventArgs e)
        {
            if (bsPosVenda.Current == null)
            {
                MessageBox.Show("Erro ao salvar resposta selecionada, necessário ter cadastro de pós-venda para a proposta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (bsPerguntas.Current == null)
            {
                MessageBox.Show("Erro ao salvar resposta selecionada, necessário ter pergunta selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (bsQuestionario.Current == null)
            {
                MessageBox.Show("Erro ao salvar resposta selecionada, necessário ter questionário selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                TCN_PosVenda.Gravar(new TRegistro_PosVendaQuestionario()
                {
                    Cd_empresa = (bsPosVenda.Current as TRegistro_PosVenda).Cd_empresa,
                    Id_posvendastr = (bsPosVenda.Current as TRegistro_PosVenda).Id_posvendastr,
                    Id_perguntastr = (bsPerguntas.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr,
                    Id_respostastr = (bsRespostas.Current as TRegistro_Pergunta_x_Resposta).Id_respostastr,
                    Id_questionario = (bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr
                }, null);

                MessageBox.Show("A resposta do cliente foi salva com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bsPosVendaProposta_PositionChanged(object sender, EventArgs e)
        {
            if (bsPosVendaProposta.Current == null)
                return;

            //Buscar todos eventos da posvenda
            (bsPosVendaProposta.Current as TRegistro_PosVenda).lEventoPosVenda = TCN_PosVenda.Buscar((bsPosVendaProposta.Current as TRegistro_PosVenda).Cd_empresa,
                                                                                             (bsPosVendaProposta.Current as TRegistro_PosVenda).Id_posvendastr,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             null);

            //Buscar todos perguntas para o questionario
            (bsPosVendaProposta.Current as TRegistro_PosVenda).lPosVendaQuestionario = TCN_PosVenda.Busca((bsPosVendaProposta.Current as TRegistro_PosVenda).Cd_empresa,
                                                                                                  (bsPosVendaProposta.Current as TRegistro_PosVenda).Id_posvendastr,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);

            //Buscar todas propostas relacionadas a posvenda
            (bsPosVendaProposta.Current as TRegistro_PosVenda).lPosVendaProposta = TCN_PosVenda.Buscar((bsPosVendaProposta.Current as TRegistro_PosVenda).Cd_empresa,
                                                                                                       (bsPosVendaProposta.Current as TRegistro_PosVenda).Id_posvendastr,
                                                                                                       string.Empty,
                                                                                                       null);

            bsPosVendaProposta.ResetBindings(true);
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.ColumnIndex.Equals(0))
                return;

            if (!(bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().Exists(r => r.Selecionado))
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Selecionado = true;
                bsOrcamento.ResetCurrentItem();
            }
            else if ((bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().Find(r => r.Selecionado).Cd_clifor !=
                (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor)
            {
                (bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().ForEach(r => r.Selecionado = false);
                bsOrcamento.ResetBindings(true);
                (bsOrcamento.Current as TRegistro_Orcamento).Selecionado = true;
            }
            else if ((bsOrcamento.Current as TRegistro_Orcamento).Selecionado.Equals(false))
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Selecionado = true;
                bsOrcamento.ResetCurrentItem();
            }
            else
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Selecionado = false;
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void BB_NovaPostaVenda_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
                return;

            //Validar existencia de proposta selecionada
            if (!(bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().Exists(r => r.Selecionado))
            {
                MessageBox.Show("Nenhuma proposta selecionada.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Validar existencia de posvenda aberta para proposta selecionada
            bool parar = false;
            TpBusca[] tpBuscas = null;
            (bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().FindAll(p => p.Selecionado).ForEach(r =>
            {
                tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.nr_orcamento", r.Nr_orcamentostr);
                Estruturas.CriarParametro(ref tpBuscas, "isnull(a.st_registro, 'A')", "'C'", "<>");
                if (new TCD_PosVenda_X_Proposta().BuscarEscalar(tpBuscas, "1") != null)
                    parar = true;
            });

            if (parar)
            {
                MessageBox.Show("Orçamento já possui pós-venda.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FPosVenda fPosVenda = new FPosVenda())
            {
                fPosVenda.lOrcamento = (bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().FindAll(p => p.Selecionado);
                if (fPosVenda.ShowDialog() == DialogResult.OK)
                {
                    if (fPosVenda._PosVenda != null)
                    {
                        fPosVenda._PosVenda.lOrcamento = (bsOrcamento.DataSource as IEnumerable<TRegistro_Orcamento>).ToList().FindAll(p => p.Selecionado);
                        TCN_PosVenda.Gravar(fPosVenda._PosVenda, null);
                        MessageBox.Show("Pós-venda gravada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBuscarOrc();
                    }
                }
            }
        }

        private void BB_AlterarPosVenda_Click(object sender, EventArgs e)
        {
            if (bsPosVendaProposta.Current == null || bsProposta.Current == null)
                return;
            else if (!(bsPosVendaProposta.Current as TRegistro_PosVenda).St_registro.Equals("A"))
            {
                MessageBox.Show("Apenas é possível alterar pós-venda com Sts. ABERTO.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FPosVenda fPosVenda = new FPosVenda())
            {
                fPosVenda._PosVenda = (bsPosVendaProposta.Current as TRegistro_PosVenda);

                if (fPosVenda.ShowDialog() == DialogResult.OK)
                {
                    if (fPosVenda._PosVenda != null)
                    {
                        fPosVenda._PosVenda.lPosVendaProposta = (bsPosVendaProposta.Current as TRegistro_PosVenda).lPosVendaProposta;

                        TCN_PosVenda.Gravar(fPosVenda._PosVenda, null);
                        MessageBox.Show("Pós-venda gravada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBuscarPos();
                    }
                }
            }
        }

        private void BB_ExcluirPosVenda_Click(object sender, EventArgs e)
        {
            if (bsPosVendaProposta.Current == null)
                return;
            else if (!(bsPosVendaProposta.Current as TRegistro_PosVenda).St_registro.Equals("A"))
            {
                MessageBox.Show("Apenas é possível encerrar pós-venda com Sts. ABERTO.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TCN_PosVenda.Excluir((bsPosVendaProposta.Current as TRegistro_PosVenda), null);
            MessageBox.Show("Pós-venda excluída com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            afterBuscarPos();

        }

        private void CD_CliforP_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + editDefault1.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { editDefault1, editDefault2 },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

            if (string.IsNullOrEmpty(editDefault1.Text))
                editDefault2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { editDefault1, editDefault2 }, string.Empty);
        }

        private void BB_Encerrar_Click(object sender, EventArgs e)
        {
            if (bsPosVendaProposta.Current == null)
                return;
            else if (!(bsPosVendaProposta.Current as TRegistro_PosVenda).St_registro.Equals("A"))
            {
                MessageBox.Show("Apenas é possível encerrar pós-venda com Sts. ABERTO.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TCN_PosVenda.Encerrar((bsPosVendaProposta.Current as TRegistro_PosVenda), null);
            MessageBox.Show("Pós-venda encerrar com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            afterBuscarPos();
        }
    }
}