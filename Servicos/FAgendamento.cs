using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFAgendamento : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pData_agendamento
        { get; set; }
        private CamadaDados.Servicos.TRegistro_Agendamento ragenda;
        public CamadaDados.Servicos.TRegistro_Agendamento rAgenda
        { 
            get 
            {
                if (bsAgendamento.Current != null)
                    return bsAgendamento.Current as CamadaDados.Servicos.TRegistro_Agendamento;
                else return null;
            }
            set { ragenda = value; }
        }

        public TFAgendamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_Clifor.Text) && string.IsNullOrEmpty(NM_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(data_agendamento.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data_agendamento.Focus();
                return;
            }
            if (string.IsNullOrEmpty(hora_agendamento.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar hora agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hora_agendamento.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_servico.Text))
            {
                MessageBox.Show("Obrigatorio informar serviço a ser realizado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_servico.Focus();
                return;
            }
            (bsAgendamento.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa = this.pCd_empresa;
            (bsAgendamento.Current as CamadaDados.Servicos.TRegistro_Agendamento).Dt_agendamento =
                DateTime.Parse(data_agendamento.Text + " " + hora_agendamento.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void TFAgendamento_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            if (ragenda != null)
                bsAgendamento.DataSource = new CamadaDados.Servicos.TList_Agendamento() { ragenda };
            else
            {
                bsAgendamento.AddNew();
                data_agendamento.Text = pData_agendamento;
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                    fone_clifor.Text = lEnd[0].Fone;
                }
                //Buscar Historico Cliente
                bsServico.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + this.pCd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "os.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                            }
                                        }, 0, string.Empty, "os.dt_abertura desc");
                bsServico_PositionChanged(this, new EventArgs());
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                    fone_clifor.Text = lEnd[0].Fone;
                }
                //Buscar Historico Cliente
                bsServico.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + this.pCd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "os.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                            }
                                        }, 0, string.Empty, "os.dt_abertura desc");
                bsServico_PositionChanged(this, new EventArgs());
            }
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFClifor fClifor = new Financeiro.Cadastros.TFClifor())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        fone_clifor.Text = fClifor.rClifor.lEndereco[0].Fone;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_tecnico, nm_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void cd_tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_tecnico, nm_tecnico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { cd_endereco, ds_endereco }, "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEndereco("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                                      "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'",
                                                      new Componentes.EditDefault[] { cd_endereco, ds_endereco });
        }

        private void bb_servico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_servico, ds_servico }, "isnull(e.st_servico, 'N')|=|'S'");
        }

        private void cd_servico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_servico.Text.Trim() + "';isnull(e.st_servico, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_servico, ds_servico }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void fone_clifor_TextChanged(object sender, EventArgs e)
        {
            if (fone_clifor.Text.SoNumero().Length.Equals(10))
            {
                fone_clifor.Text = "(" + fone_clifor.Text.SoNumero().Substring(0, 2) + ")" + fone_clifor.Text.SoNumero().Substring(2, 4) + "-" + fone_clifor.Text.SoNumero().Substring(6, 4);
                fone_clifor.SelectionStart = fone_clifor.Text.Length;
            }
            else if (fone_clifor.Text.SoNumero().Length.Equals(11))
                if (fone_clifor.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    fone_clifor.Text = "(" + fone_clifor.Text.SoNumero().Substring(0, 3) + ")" + fone_clifor.Text.SoNumero().Substring(3, 4) + "-" + fone_clifor.Text.SoNumero().Substring(7, 4);
                    fone_clifor.SelectionStart = fone_clifor.Text.Length;
                }
                else
                {
                    fone_clifor.Text = "(" + fone_clifor.Text.SoNumero().Substring(0, 2) + ")" + fone_clifor.Text.SoNumero().Substring(2, 5) + "-" + fone_clifor.Text.SoNumero().Substring(7, 4);
                    fone_clifor.SelectionStart = fone_clifor.Text.Length;
                }
            else if (fone_clifor.Text.SoNumero().Length.Equals(12))
            {
                fone_clifor.Text = "(" + fone_clifor.Text.SoNumero().Substring(0, 3) + ")" + fone_clifor.Text.SoNumero().Substring(3, 5) + "-" + fone_clifor.Text.SoNumero().Substring(8, 4);
                fone_clifor.SelectionStart = fone_clifor.Text.Length;
            }
        }

        private void CD_Clifor_TextChanged(object sender, EventArgs e)
        {
            NM_Clifor.Enabled = string.IsNullOrEmpty(CD_Clifor.Text);
            fone_clifor.Enabled = string.IsNullOrEmpty(CD_Clifor.Text);
        }

        private void bsServico_PositionChanged(object sender, EventArgs e)
        {
            if (bsServico.Current != null)
            {
                (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS =
                    CamadaNegocio.Servicos.TCN_FichaTecOS.Buscar((bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_empresa,
                                                                 (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_osstr,
                                                                 (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_pecastr,
                                                                 string.Empty,
                                                                 null);
                bsServico.ResetCurrentItem();
            }
        }
    }
}
