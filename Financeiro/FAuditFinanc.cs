using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using Utils;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFAuditFinanc : Form
    {
        public TFAuditFinanc()
        {
            InitializeComponent();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TList_RegLanDuplicata lDup = TCN_LanDuplicata.BuscaAudit(CD_Empresa.Text,
                                                                        NR_Docto.Text,
                                                                        nr_lancto.Text,
                                                                        CD_Clifor.Text,
                                                                        cd_moeda.Text,
                                                                        CD_Historico.Text,
                                                                        cd_condpgto.Text,
                                                                        Tp_Dup.Text,
                                                                        VL_Inicial.Value,
                                                                        VL_Final.Value,
                                                                        DT_Inicial.Text,
                                                                        DT_Final.Text,
                                                                        null);
                //Buscr Centro Resultado
                //lDup.ForEach(p => p.lCustoLancto = TCN_DuplicataXCCusto.BuscarCusto(p.Cd_empresa, p.Nr_lancto.ToString(), null));
                lDup.ForEach(r => r.St_liquidar = false);
                BS_Duplicata.DataSource = lDup;
            }
            else
            {
                if (cbContaGer.SelectedItem != null)
                {
                    bsCaixa.DataSource = TCN_LanCaixa.BuscaAudit(cbContaGer.SelectedValue.ToString(),
                                                                string.Empty,
                                                                string.Empty,
                                                                nr_doctoCaixa.Text,
                                                                cd_historicoCaixa.Text,
                                                                string.Empty,
                                                                Dt_iniCaixa.Text,
                                                                Dt_finCaixa.Text,
                                                                0,
                                                                0,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                false,
                                                                string.Empty,
                                                                0,
                                                                true,
                                                                null);
                    (bsCaixa.DataSource as TList_LanCaixa).ForEach(r => r.St_conciliar = false);
                    bsCaixa.ResetBindings(true);
                }
                else MessageBox.Show("Obrigatório informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (!(BS_Duplicata.List as IEnumerable<TRegistro_LanDuplicata>).ToList().Exists(r => r.St_liquidar))
                {
                    MessageBox.Show("Nenhum registro selecionado para auditar.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (MessageBox.Show("Confirma auditar todos registros selecionados, está opção não poderá ser desfeita.",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                TList_RegLanDuplicata _LanDuplicatas = new TList_RegLanDuplicata();
                (BS_Duplicata.List as IEnumerable<TRegistro_LanDuplicata>).ToList().FindAll(r => r.St_liquidar).ForEach(p =>
                {
                    _LanDuplicatas.Add(p);
                });

                try
                {
                    TCN_LanDuplicata.AuditarDuplicatas(_LanDuplicatas, null);
                    MessageBox.Show("Auditado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (BS_Duplicata.DataSource as TList_RegLanDuplicata).RemoveAll(r => r.St_liquidar = true);
                    BS_Duplicata.ResetBindings(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(bsCaixa.List as IEnumerable<TRegistro_LanCaixa>).ToList().Exists(r => r.St_conciliar))
                {
                    MessageBox.Show("Nenhum registro selecionado para auditar.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (MessageBox.Show("Confirma auditar todos registros selecionados, está opção não poderá ser desfeita.",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                TList_LanCaixa _LanCaixas = new TList_LanCaixa();
                (bsCaixa.List as IEnumerable<TRegistro_LanCaixa>).ToList().FindAll(r => r.St_conciliar).ForEach(p =>
                {
                    _LanCaixas.Add(p);
                });

                try
                {
                    TCN_LanCaixa.AuditarCaixa(_LanCaixas, null);
                    MessageBox.Show("Auditado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (bsCaixa.DataSource as TList_LanCaixa).RemoveAll(r => r.St_conciliar);
                    bsCaixa.ResetBindings(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BS_Duplicata.Current == null)
                return;
            else if (e.ColumnIndex.Equals(0))
            {
                (BS_Duplicata.Current as TRegistro_LanDuplicata).St_liquidar = !(BS_Duplicata.Current as TRegistro_LanDuplicata).St_liquidar;
                BS_Duplicata.ResetCurrentItem();
            }
        }

        private void TFAuditFinanc_Load(object sender, EventArgs e)
        {
            cbContaGer.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_contacf",
                                            vOperador = "<>",
                                            vVL_Busca = "0"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_contacartao",
                                            vOperador = "<>",
                                            vVL_Busca = "0"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty);
            cbContaGer.DisplayMember = "DS_ContaGer";
            cbContaGer.ValueMember = "CD_ContaGer";
            if (cbContaGer.Items.Count > 0)
                cbContaGer.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Historico|250;" +
                              "a.CD_Historico|Cd. Historico|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoCaixa },
                                   new TCD_CadHistorico(), string.Empty);
        }

        private void cd_historicoCaixa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historicoCaixa.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoCaixa },
                                    new TCD_CadHistorico());
        }

        private void dataGridDefault3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {
                if (bsCaixa.Current == null)
                    return;

                (bsCaixa.Current as TRegistro_LanCaixa).St_conciliar = !(bsCaixa.Current as TRegistro_LanCaixa).St_conciliar;
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxDefault1_Click(object sender, EventArgs e)
        {
            if (checkBoxDefault1.Checked)
                (bsCaixa.List as IEnumerable<TRegistro_LanCaixa>).ToList().ForEach(r => r.St_conciliar = true);
            else (bsCaixa.List as IEnumerable<TRegistro_LanCaixa>).ToList().ForEach(r => r.St_conciliar = false);

            bsCaixa.ResetBindings(true);
        }

        private void checkBoxDefault2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDefault2.Checked)
                (BS_Duplicata.List as IEnumerable<TRegistro_LanDuplicata>).ToList().ForEach(r => r.St_liquidar = true);
            else (BS_Duplicata.List as IEnumerable<TRegistro_LanDuplicata>).ToList().ForEach(r => r.St_liquidar = false);

            BS_Duplicata.ResetBindings(true);
        }
    }
}
