using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Faturamento.PosVenda;
using CamadaNegocio.Faturamento.PosVenda;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.Orcamento;
using FormBusca;

namespace Faturamento
{
    public partial class FPosVenda : Form
    {
        private bool alterandoEvento;
        private bool novaPosVenda = false;

        private TRegistro_PosVenda rPosVenda { get; set; }
        public TRegistro_PosVenda _PosVenda
        {
            get
            {
                if (bsPosVenda.Current == null)
                    return null;
                else
                    return (bsPosVenda.Current as TRegistro_PosVenda);
            }
            set
            {
                rPosVenda = value;
            }
        }
        public IEnumerable<TRegistro_Orcamento> lOrcamento { get; set; }

        public FPosVenda()
        {
            InitializeComponent();
        }

        private void bsPosVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsPosVenda.Current == null)
                return;
            else if (novaPosVenda)
                return;

            //Buscar todos eventos da posvenda
            (bsPosVenda.Current as TRegistro_PosVenda).lEventoPosVenda = TCN_PosVenda.Buscar((bsPosVenda.Current as TRegistro_PosVenda).Cd_empresa,
                                                                                             (bsPosVenda.Current as TRegistro_PosVenda).Id_posvendastr,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             null);
            //Buscar todos perguntas para o questionario
            (bsPosVenda.Current as TRegistro_PosVenda).lPosVendaQuestionario = TCN_PosVenda.Busca((bsPosVenda.Current as TRegistro_PosVenda).Cd_empresa,
                                                                                                  (bsPosVenda.Current as TRegistro_PosVenda).Id_posvendastr,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
        }

        private void FPosVenda_Load(object sender, EventArgs e)
        {
            if (rPosVenda == null)
            {
                rPosVenda = new TRegistro_PosVenda()
                {
                    Cd_empresa = lOrcamento.ElementAt(0).Cd_empresa,
                    Nm_empresa = lOrcamento.ElementAt(0).Nm_empresa,
                    Cd_clifor = lOrcamento.ElementAt(0).Cd_clifor,
                    Nm_clifor = lOrcamento.ElementAt(0).Nm_clifor
                };
                novaPosVenda = true;
                bsPosVenda.Add(rPosVenda);
            }
            else
                bsPosVenda.Add(rPosVenda);

            (bsPosVenda.Current as TRegistro_PosVenda).Login = Utils.Parametros.pubLogin;
            bsQuestionario.DataSource = TCN_CadQuestionario.Buscar(string.Empty,
                                                                   string.Empty,
                                                                   null,
                                                                   Cancelado: "0");

            bsPosVenda.ResetBindings(true);
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
            if (bsQuestionario.Current == null)
            {
                MessageBox.Show("Nenhum questionário selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (bsPerguntas.Current == null)
            {
                MessageBox.Show("Nenhuma pergunta selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (bsRespostas.Current == null)
            {
                MessageBox.Show("Nenhuma resposta selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(edt_questionario.Text))
            {
                edt_questionario.Text = (bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr;
            }
            else if (!string.IsNullOrEmpty(edt_questionario.Text) &&
                !(bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr.Equals(edt_questionario.Text))
            {
                MessageBox.Show("Na aba de pós-venda foi informado o questionário de Id. " + edt_questionario.Text +
                    ". Não é possível informar outro diferente desse. Selecionado atual " + (bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr + ".",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((bsPosVenda.Current as TRegistro_PosVenda).lPosVendaQuestionario
               .Exists(r =>
               r.Id_perguntastr.Equals((bsPerguntas.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr)))
            {
                MessageBox.Show("A pergunta selecionada já possui com resposta na pós-venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            (bsPosVenda.Current as TRegistro_PosVenda).lPosVendaQuestionario.Add(
                new TRegistro_PosVendaQuestionario()
                {
                    Cd_empresa = (bsPosVenda.Current as TRegistro_PosVenda).Cd_empresa,
                    Id_posvendastr = (bsPosVenda.Current as TRegistro_PosVenda).Id_posvendastr,
                    Id_perguntastr = (bsPerguntas.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr,
                    Id_respostastr = (bsRespostas.Current as TRegistro_Pergunta_x_Resposta).Id_respostastr,
                    Ds_pergunta = (bsPerguntas.Current as TRegistro_Questionario_X_Pergunta).ds_pergunta,
                    Ds_resposta = (bsRespostas.Current as TRegistro_Pergunta_x_Resposta).ds_resposta,
                    Id_questionario = (bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr
                });

            tabControl1.SelectedIndex = 0;
            bsPosVendaQuestionario.ResetBindings(true);
        }

        private void BB_SalvarEvento_Click(object sender, EventArgs e)
        {
            if (!edt_dtevento.Text.Trim().SoNumero().Length.Equals(8))
            {
                MessageBox.Show("Obrigatório informar do data evento válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(edt_dsevento.Text))
            {
                MessageBox.Show("Obrigatório informar descrição do evento para salvar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (alterandoEvento && bsEvento.Current != null)
            {
                (bsEvento.Current as TRegistro_EventoPosVenda).Ds_evento = edt_dsevento.Text.Trim();
                (bsEvento.Current as TRegistro_EventoPosVenda).Dt_eventostr = edt_dtevento.Text.Trim();
                alterandoEvento = false;
                BB_CancelarEvento.Enabled = false;
            }
            else
            {
                (bsPosVenda.Current as TRegistro_PosVenda).lEventoPosVenda.Add(
                new TRegistro_EventoPosVenda()
                {
                    Cd_empresa = (bsPosVenda.Current as TRegistro_PosVenda).Cd_empresa,
                    Id_posvendastr = (bsPosVenda.Current as TRegistro_PosVenda).Id_posvendastr,
                    Login = edt_login1.Text,
                    Ds_evento = edt_dsevento.Text.Trim(),
                    Dt_eventostr = edt_dtevento.Text
                });
            }

            tabControl1.SelectedIndex = 0;
            edt_dsevento.Text = "";
            edt_dtevento.Text = "";
            bsEvento.ResetBindings(true);
        }

        private void BB_ExcluirEvento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current == null)
                return;
            (bsPosVenda.Current as TRegistro_PosVenda).DelEventoPosVenda.Add((bsEvento.Current as TRegistro_EventoPosVenda));
            bsEvento.RemoveCurrent();
        }

        private void BB_ExcluirResQuest_Click(object sender, EventArgs e)
        {
            if (bsPosVendaQuestionario.Current == null)
                return;
            (bsPosVenda.Current as TRegistro_PosVenda).DelPosVendaQuestionario.Add((bsPosVendaQuestionario.Current as TRegistro_PosVendaQuestionario));
            bsPosVendaQuestionario.RemoveCurrent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edt_questionario_Leave(object sender, EventArgs e)
        {
            string cond = "a.id_questionario |=| '" + edt_questionario.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(cond, new Componentes.EditDefault[] { edt_questionario }, new TCD_Questionario());
        }

        private void BB_Questionario_Click(object sender, EventArgs e)
        {
            string colunas = "a.id_questionario|Id. Questionário|60;" +
                             "a.ds_questionario|Ds. Questionário|200";
            UtilPesquisa.BTN_BUSCA(colunas, new Componentes.EditDefault[] { edt_questionario }, new TCD_Questionario(), string.Empty);
        }

        private void BB_AlterarEvento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current == null)
                return;

            alterandoEvento = true;
            BB_CancelarEvento.Enabled = true;

            edt_dsevento.Text = (bsEvento.Current as TRegistro_EventoPosVenda).Ds_evento;
            edt_dtevento.Text = (bsEvento.Current as TRegistro_EventoPosVenda).Dt_eventostr;

            tabControl1.SelectedIndex = 2;
        }

        private void BB_CancelarEvento_Click(object sender, EventArgs e)
        {
            alterandoEvento = false;
            BB_CancelarEvento.Enabled = false;
            edt_dsevento.Text = "";
            edt_dtevento.Text = "";
        }

        private void bsPosVendaQuestionario_PositionChanged(object sender, EventArgs e)
        {
            if (bsPosVendaQuestionario.Current == null)
            {
                edt_questionario.Text = "";
                return;
            }

            edt_questionario.Text = (bsPosVendaQuestionario.Current as TRegistro_PosVendaQuestionario).Id_questionario.ToString();
        }

        private void dataGridDefault3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {
                if (bsPosVendaQuestionario.Count > 0 && !(bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr.Equals(edt_questionario.Text))
                {
                    (bsQuestionario.Current as TRegistro_Questionario).Selecionado = false;
                }
                else
                {
                    (bsQuestionario.Current as TRegistro_Questionario).Selecionado = true;
                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados2.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }
    }
}
