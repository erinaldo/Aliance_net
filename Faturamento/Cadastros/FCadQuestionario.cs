using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using Utils;

namespace Faturamento.Cadastros
{
    public partial class TFCadQuestionario : Form
    {
        private string desc = string.Empty;

        public TFCadQuestionario()
        {
            InitializeComponent();
        }

        private void bsQuestionario_PositionChanged(object sender, EventArgs e)
        {
            if (bsQuestionario.Current == null)
                return;
            atualizarPerguQuest();
        }

        private void atualizarPerguQuest()
        {
            bsQuestPergun.DataSource = TCN_Questionario_X_Pergunta.Buscar((bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr, string.Empty, null);
        }

        private void bsPerguntas_PositionChanged(object sender, EventArgs e)
        {
            if (bsPerguntas.Current == null)
                return;
            bsPerguntas.DataSource = TCN_Pergunta.Buscar(string.Empty, string.Empty, null);
        }

        private void FCadQuestionario_Load(object sender, EventArgs e)
        {
            atualizarQuestionario();

            atualizarPerguntas();

            atualizarRespostas();
        }

        private void atualizarQuestionario()
        {
            bsQuestionario.DataSource = TCN_CadQuestionario.Buscar(string.Empty, string.Empty, null);
        }

        private void atualizarRespostas()
        {
            bsRespostas.DataSource = TCN_Resposta.Buscar(string.Empty, string.Empty, null);
        }

        private void atualizarPerguntas()
        {
            bsPerguntas.DataSource = TCN_Pergunta.Buscar(string.Empty, string.Empty, null);
            bsPerguntas.ResetBindings(true);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (((ToolStripLabel)sender).Name.Equals("BB_NovoQuest"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                TCN_CadQuestionario.Gravar(new TRegistro_Questionario() { Ds_questionario = desc }, null);
                desc = string.Empty;
                atualizarQuestionario();
            }
            else if(bsQuestionario.Current == null)
                return;
            else if (((ToolStripLabel)sender).Name.Equals("BB_AlterarQuest"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                (bsQuestionario.Current as TRegistro_Questionario).Ds_questionario = desc;
                TCN_CadQuestionario.Gravar((bsQuestionario.Current as TRegistro_Questionario), null);
                desc = string.Empty;
                atualizarQuestionario();
            }
            else if (((ToolStripLabel)sender).Name.Equals("BB_ExcluirQuest"))
            {
                try
                {
                    TCN_CadQuestionario.Excluir((bsQuestionario.Current as TRegistro_Questionario), null);
                    MessageBox.Show("Excluído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc = string.Empty;
                    atualizarQuestionario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Questionario_X_Pergunta
            else if (bsQuestPergun.Current == null)
                return;
            else if (((ToolStripLabel)sender).Name.Equals("BB_ExcluirQPerg"))
            {
                try
                {
                    TCN_Questionario_X_Pergunta.Excluir((bsQuestPergun.Current as TRegistro_Questionario_X_Pergunta), null);
                    MessageBox.Show("Excluído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc = string.Empty;
                    atualizarPerguQuest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Pergunta_x_Resposta
            else if (bsPerguRespos.Current == null)
                return;
            else if (((ToolStripLabel)sender).Name.Equals("BB_ExcluirPResp"))
            {
                try
                {
                    TCN_Pergunta_X_Resposta.Excluir((bsPerguRespos.Current as TRegistro_Pergunta_x_Resposta), null);
                    MessageBox.Show("Excluído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc = string.Empty;
                    atualizarPergunResp();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void atualizarPergunResp()
        {
            bsPerguRespos.DataSource = TCN_Pergunta_X_Resposta.Buscar((bsQuestPergun.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr, string.Empty, null);
            bsPerguRespos.ResetBindings(true);
        }

        private string novoDescr()
        {
            InputBox inputBox = new InputBox(string.Empty, "Informe a descrição:");
            desc = inputBox.Show();
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Necessário informar descrição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            return desc;
        }

        private void bsQuestPergun_PositionChanged(object sender, EventArgs e)
        {
            if (bsQuestPergun.Current == null)
                return;

            bsPerguRespos.DataSource = TCN_Pergunta_X_Resposta.Buscar((bsQuestPergun.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr, string.Empty, null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_NovoP_Click(object sender, EventArgs e)
        {
            if (((ToolStripLabel)sender).Name.Equals("BB_NovoP"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                TCN_Pergunta.Gravar(new TRegistro_Pergunta() { Ds_pergunta = desc }, null);
                desc = string.Empty;
                atualizarPerguntas();
            }
            else if(bsPerguntas.Current == null)
                return;
            else if (((ToolStripLabel)sender).Name.Equals("BB_AlterarP"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                (bsPerguntas.Current as TRegistro_Pergunta).Ds_pergunta = desc;
                TCN_Pergunta.Gravar((bsPerguntas.Current as TRegistro_Pergunta), null);
                desc = string.Empty;
                atualizarPerguntas();
            }
            else if (((ToolStripLabel)sender).Name.Equals("BB_ExcluirP"))
            {
                try
                {
                    TCN_Pergunta.Excluir((bsPerguntas.Current as TRegistro_Pergunta), null);
                    MessageBox.Show("Excluído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc = string.Empty;
                    atualizarPerguntas();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (((ToolStripLabel)sender).Name.Equals("BB_AdicionarP") && bsQuestionario.Current != null)
            {
                try
                {
                    TCN_Questionario_X_Pergunta.Gravar(new TRegistro_Questionario_X_Pergunta() { Id_questionariostr = (bsQuestionario.Current as TRegistro_Questionario).Id_questionariostr, Id_perguntastr = (bsPerguntas.Current as TRegistro_Pergunta).Id_perguntastr }, null);
                    atualizarPerguQuest();
                    MessageBox.Show("Adicionado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_NovoR_Click(object sender, EventArgs e)
        {
            if (((ToolStripLabel)sender).Name.Equals("BB_NovoR"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                TCN_Resposta.Gravar(new TRegistro_Resposta() { Ds_resposta = desc }, null);
                desc = string.Empty;
                atualizarRespostas();
            }
            else if(bsRespostas.Current == null)
                return;
            else if (((ToolStripLabel)sender).Name.Equals("BB_AlterarR"))
            {
                if (string.IsNullOrEmpty(novoDescr()))
                    return;
                (bsRespostas.Current as TRegistro_Resposta).Ds_resposta = desc;
                TCN_Resposta.Gravar((bsRespostas.Current as TRegistro_Resposta), null);
                desc = string.Empty;
                atualizarRespostas();
            }
            else if (((ToolStripLabel)sender).Name.Equals("BB_ExcluirR"))
            {
                try
                {
                    TCN_Resposta.Excluir((bsRespostas.Current as TRegistro_Resposta), null);
                    MessageBox.Show("Excluído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc = string.Empty;
                    atualizarRespostas();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (((ToolStripLabel)sender).Name.Equals("BB_AdicionarR") && bsQuestPergun.Current != null)
            {
                try
                {
                    TCN_Pergunta_X_Resposta.Gravar(new TRegistro_Pergunta_x_Resposta() { Id_perguntastr = (bsQuestPergun.Current as TRegistro_Questionario_X_Pergunta).Id_perguntastr, Id_respostastr = (bsRespostas.Current as TRegistro_Resposta).Id_respostastr }, null);
                    atualizarPergunResp();
                    MessageBox.Show("Adicionado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
