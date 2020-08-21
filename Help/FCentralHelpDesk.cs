using CamadaDados.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Help
{
    public partial class TFCentralHelpDesk : Form
    {
        public string Id_ticket
        { get; set; }
        public string LoginCliente
        { get; set; }
        public string Id_cliente
        { get; set; }

        public TFCentralHelpDesk()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFTicket fTicket = new TFTicket())
            {
                fTicket.LoginCliente = LoginCliente;
                fTicket.Id_cliente = Id_cliente.SoNumero();
                fTicket.ShowDialog();
                afterBusca();
            }
        }

        private void afterBusca()
        {
            bsTicket.DataSource = ServiceRest.DataService.BuscarTicket(id_ticket.Text,
                                                                       ds_assunto.Text,
                                                                       rbAbertura.Checked ? "A" : rbEncerramento.Checked ? "E" : rbConclusao.Checked ? "C" : string.Empty,
                                                                       !string.IsNullOrEmpty(dt_ini.Text.SoNumero()) ? DateTime.Parse(dt_ini.Text).ToString("dd/MM/yyyy") : string.Empty,
                                                                       !string.IsNullOrEmpty(dt_ini.Text.SoNumero()) ? DateTime.Parse(dt_ini.Text).ToString("dd/MM/yyyy") : string.Empty,
                                                                       LoginCliente,
                                                                       rbConcluido.Checked ? "'L'" : rbEncerrado.Checked ? "'E'" : "'A'");
        }

        private void NovoHistorico()
        {
            if (bsEvolucao.Current != null)
            {
                if ((bsEvolucao.Current as Evolucao).Dt_finetapa.HasValue)
                {
                    MessageBox.Show("Não é permitido incluir histórico numa etapa concluida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEvoluirTicket fHistorico = new TFEvoluirTicket())
                {
                    if (fHistorico.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            HistEvolucao historico = new HistEvolucao();
                            historico.Id_evolucao = (bsEvolucao.Current as Evolucao).Id_evolucao;
                            historico.Id_ticket = (bsEvolucao.Current as Evolucao).Id_ticket;
                            historico.Logincliente = LoginCliente;
                            historico.Id_cliente = decimal.Parse(Id_cliente);
                            historico.Ds_historico = fHistorico.Ds_historico;
                            fHistorico.lAnexo.ForEach(p => historico.lAnexo.Add(p));
                            if (ServiceRest.DataService.GravarHistorico(historico))
                                bsEvolucao_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void TFCentralHelpDesk_Load(object sender, EventArgs e)
        {
            try
            {
                //Verificar login
                CamadaDados.Diversos.TList_CadUsuario lUser =
                    CamadaNegocio.Diversos.TCN_CadUsuario.Busca(Parametros.pubLogin, string.Empty, string.Empty, null);
                bool st_login = true;
                if (lUser.Count > 0)
                    if ((!string.IsNullOrEmpty(lUser[0].Login_BI)) && (!string.IsNullOrEmpty(lUser[0].Senha_BI)))
                    {
                        string ret = ServiceRest.DataService.ValidarLogin(
                                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null), 
                                        lUser[0].Login_BI, 
                                        lUser[0].Senha_BI);
                        if (!string.IsNullOrWhiteSpace(ret))
                        {
                            LoginCliente = lUser[0].Login_BI;
                            Id_cliente = ret;
                            st_login = false;
                        }
                    }
                if (st_login)
                    using (TFLoginHelpDesk fLogin = new TFLoginHelpDesk())
                    {
                        if (fLogin.ShowDialog() == DialogResult.OK)
                        {
                            LoginCliente = fLogin.Login;
                            Id_cliente = fLogin.Id_cliente;
                        }
                        else
                            Close();
                    }
                if (!string.IsNullOrEmpty(Id_ticket))
                {
                    id_ticket.Text = Id_ticket;
                    afterBusca();
                }
                //Verificar se o login tem acesso a tela de duplicatas
                if (Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                    bb_boleto.Visible = true;
                else
                    bb_boleto.Visible = new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "(a.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                            "exists(select 1 from tb_div_usuario_x_grupos x " +
                                                            "where x.logingrp = a.login " +
                                                            "and x.loginusr = '" + Parametros.pubLogin.Trim() + "')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_Menu",
                                                vOperador = "=",
                                                vVL_Busca = "'050700'"//Codigo Menu Tela Consulta Contas Pagar/Receber
                                            }
                                        }, "1") != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gTicket_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CONCLUIDO"))
                        gTicket.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gTicket.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gTicket.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gTicket.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void TFCentralHelpDesk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                NovoHistorico();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bb_novoticket_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void gAnexo_DoubleClick(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null)
            {
                if (!string.IsNullOrEmpty((bsAnexo.Current as Anexo).Tp_ext))
                {
                    byte[] arquivoBuffer = (bsAnexo.Current as Anexo).Imagem;
                    string extensao = (bsAnexo.Current as Anexo).Tp_ext; // retornar do banco tbm

                    string path = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                    System.IO.File.WriteAllBytes(
                        path,
                        arquivoBuffer);

                    // para abrir o arquivo para o usuario
                    System.Diagnostics.Process.Start(path);
                }
                else
                    using (TFAnexosHelpDesk fAnexo = new TFAnexosHelpDesk())
                    {
                        fAnexo.pDs_anexo = (bsAnexo.Current as Anexo).Ds_anexo;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        ms.Write((bsAnexo.Current as Anexo).Imagem, 0, (bsAnexo.Current as Anexo).Imagem.Length);
                        fAnexo.Img_anexo = Image.FromStream(ms);
                        fAnexo.ShowDialog();
                    }
            }
        }

        private void bsEvolucao_PositionChanged(object sender, EventArgs e)
        {
            if (bsEvolucao.Current != null)
            {
                //Buscar Historicos
                List<HistEvolucao> lHist = ServiceRest.DataService.BuscarHistorico((bsEvolucao.Current as Evolucao).Id_ticket.Value.ToString(),
                                                                                   (bsEvolucao.Current as Evolucao).Id_evolucao.Value.ToString());
                if (lHist != null)
                    bsHistEvolucao.DataSource = lHist.OrderByDescending(p => p.Dt_historico).ToList();
                //Buscar Anexos
                bsAnexo.DataSource = ServiceRest.DataService.BuscarAnexos((bsEvolucao.Current as Evolucao).Id_ticket.Value.ToString(),
                                                                          (bsEvolucao.Current as Evolucao).Id_evolucao.Value.ToString());
                bsEvolucao.ResetCurrentItem();
            }
        }

        private void bb_boleto_Click(object sender, EventArgs e)
        {
            //Buscar CNPJ das empresas ativas
            CamadaDados.Diversos.TList_CadEmpresa lEmp =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null);
            string emp = string.Empty;
            string virg = string.Empty;
            lEmp.ForEach(p =>
            {
                emp += virg + "'" + p.rClifor.Nr_cgc.SoNumero() + "'";
                virg = ",";
            });
            if (!string.IsNullOrEmpty(emp))
            {
                List<CamadaDados.Financeiro.Bloqueto.blTitulo> lTitulos = ServiceRest.DataService.BuscarBoletos(emp);
                using (TFBoletosAliance fb = new TFBoletosAliance())
                {
                    fb.lTitulos = lTitulos;
                    fb.ShowDialog();
                }
            }
            else MessageBox.Show("Obrigatório informar empresa para gerar boletos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbHistorico_Click(object sender, EventArgs e)
        {
            NovoHistorico();
        }

        private void gTicket_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTicket.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTicket.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new Ticket());
            TList_Ticket lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTicket.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTicket.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Ticket(lP.Find(gTicket.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTicket.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Ticket(lP.Find(gTicket.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTicket.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTicket.List as TList_Ticket).Sort(lComparer);
            bsTicket.ResetBindings(false);
            gTicket.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void tcTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcTickets.SelectedTab.Equals(tpEvolucao))
            {
                if (bsTicket.Current != null)
                {
                    bsEvolucao.DataSource = ServiceRest.DataService.BuscarEvolucao((bsTicket.Current as Ticket).Id_ticket.Value.ToString());
                    bsEvolucao_PositionChanged(this, new EventArgs());
                    bsTicket.ResetCurrentItem();
                }
                else
                {
                    bsEvolucao.Clear();
                    bsHistEvolucao.Clear();
                    bsAnexo.Clear();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bsHistEvolucao.Current != null)
                edHistorico.Text = (bsHistEvolucao.Current as HistEvolucao).Ds_historico;
        }
    }
}
