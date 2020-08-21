using CamadaDados.Faturamento.AgendaVendedor;
using CamadaNegocio.Faturamento.AgendaVendedor;
using System;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFAgendaVendedor : Form
    {
        private DateTime dt_atual;
        public TFAgendaVendedor()
        {
            InitializeComponent();
        }

        private void TFAgendaVendedor_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            dt_atual = CamadaDados.UtilData.Data_Servidor();
            bsAgendaAtual.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                                 Utils.Parametros.pubLogin,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 dt_atual.ToString("dd/MM/yyyy"),
                                                                 "'0'",
                                                                 null);
            bsAgenda.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                            Utils.Parametros.pubLogin,
                                                            string.Empty,
                                                            calendario.SelectionStart.ToString("dd/MM/yyyy"),
                                                            calendario.SelectionEnd.ToString("dd/MM/yyyy"),
                                                            "'0'",
                                                            null);
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            bsAgenda.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                            Utils.Parametros.pubLogin,
                                                            string.Empty,
                                                            calendario.SelectionStart.ToString("dd/MM/yyyy"),
                                                            calendario.SelectionEnd.ToString("dd/MM/yyyy"),
                                                            "'0'",
                                                            null);
        }

        private void bbNovo_Click(object sender, EventArgs e)
        {
            using (TFCRMOrcamento fCRM = new TFCRMOrcamento())
            {
                fCRM.Dt_agendamento = calendario.SelectionRange.Start;
                if (fCRM.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TRegistro_AgendaVendedor rCRM = new TRegistro_AgendaVendedor();
                        rCRM.Cd_clifor = fCRM.pCd_clifor;
                        rCRM.Nm_clifor = fCRM.pNm_clifor;
                        rCRM.Login = Utils.Parametros.pubLogin;
                        rCRM.Ds_historico = fCRM.pDs_historico;
                        rCRM.Dt_contato = CamadaDados.UtilData.Data_Servidor();
                        rCRM.Dt_agendamento = DateTime.Parse(fCRM.pDt_evento);
                        if (!string.IsNullOrEmpty(fCRM.pHr_evento.SoNumero()))
                        {
                            TimeSpan teste;
                            TimeSpan.TryParse(fCRM.pHr_evento, out teste);
                            rCRM.Hr_agendamento = teste;
                        }
                        rCRM.Nm_contato = fCRM.pNm_contato;
                        rCRM.Fone_contato = fCRM.pFone;
                        TCN_AgendaVendedor.Gravar(rCRM, null);
                        MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Atualizar Agenda
                        bsAgenda.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                                        Utils.Parametros.pubLogin,
                                                                        string.Empty,
                                                                        calendario.SelectionStart.ToString("dd/MM/yyyy"),
                                                                        calendario.SelectionEnd.ToString("dd/MM/yyyy"),
                                                                        "'0'",
                                                                        null);
                        //Atualizar Agenda do dia
                        bsAgendaAtual.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                                             Utils.Parametros.pubLogin,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             dt_atual.ToString("dd/MM/yyyy"),
                                                                             "'0'",
                                                                             null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro gravar registro: " + ex.Message.Trim()); }
            }
        }

        private void bbConcluir_Click(object sender, EventArgs e)
        {
            if(bsAgendaAtual.Current != null)
                if(MessageBox.Show("Confirma CONCLUSÃO do compromisso selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        (bsAgendaAtual.Current as TRegistro_AgendaVendedor).St_registro = "2";
                        TCN_AgendaVendedor.Gravar(bsAgendaAtual.Current as TRegistro_AgendaVendedor, null);
                        MessageBox.Show("Compromisso concluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsAgendaAtual.DataSource = TCN_AgendaVendedor.Buscar(string.Empty,
                                                                             Utils.Parametros.pubLogin,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             dt_atual.ToString("dd/MM/yyyy"),
                                                                             "'0'",
                                                                             null);
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro concluir compromisso: " + ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
