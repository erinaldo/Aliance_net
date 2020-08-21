using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadCentroResultado : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCentroResultado()
        {
            InitializeComponent();
            this.DTS = bsCentroResult;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("RECEITA", "R"));
            cbx.Add(new Utils.TDataCombo("DESPESA", "D"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
        }

        public override int buscarRegistros()
        {
            TList_CentroResultado lista = TCN_CentroResultado.Buscar(cd_centroresult.Text,
                                                                     ds_centroresultado.Text,
                                                                     cd_centroresult_pai.Text,
                                                                     null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCentroResult.DataSource = lista;
                    bsCentroResult_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCentroResult.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsCentroResult.AddNew();
                base.afterNovo();
                bb_hist.Enabled = true;
                bb_excluirHist.Enabled = true;
                if (!cd_centroresult.Focus())
                    ds_centroresultado.Focus();
            }
        }

        public override void afterAltera()
        {
            if (bsCentroResult.Current != null)
            {
                //Habilitar tp_ccusto
                if ((bsCentroResult.Current as TRegistro_CentroResultado).St_sinteticobool)
                {
                    object retorno = new TCD_CadGrupoCF().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_centroresult_pai",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_centroresult.Text.Trim() + "'"
                            }
                        }, "1");
                    base.afterAltera();
                    if (retorno != null)
                        ST_Sintetico.Enabled = !(retorno.ToString().Trim().Equals("1"));
                }
                else
                    base.afterAltera();
                cd_centroresult_pai.Enabled = false;
                bb_grupocf.Enabled = false;
                bb_hist.Enabled = true;
                bb_excluirHist.Enabled = true;
                ds_centroresultado.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            bb_hist.Enabled = false;
            bb_excluirHist.Enabled = false;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    if ((!(bsCentroResult.Current as TRegistro_CentroResultado).St_sinteticobool) &&
                        string.IsNullOrEmpty((bsCentroResult.Current as TRegistro_CentroResultado).Tp_registro))
                        throw new Exception("Obrigatorio informar tipo de Movimento para registro Analitico.");
                    bb_hist.Enabled = false;
                    bb_excluirHist.Enabled = false;
                    return TCN_CentroResultado.Gravar(bsCentroResult.Current as TRegistro_CentroResultado, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bb_hist.Enabled = true;
                    bb_excluirHist.Enabled = true;
                    return string.Empty;
                }
            else
            {
                bb_hist.Enabled = true;
                bb_excluirHist.Enabled = true;
                return string.Empty;
            }
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                //Verificar se centro possui filhos para proteger antes da exclusão.
                if (new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_CentroResult_Pai",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsCentroResult.Current as TRegistro_CentroResultado).Cd_centroresult.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Centro de resultado possui filhos, não é possível efetuar a exclusão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CentroResultado.Excluir(bsCentroResult.Current as TRegistro_CentroResultado, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    bsCentroResult.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_grupocf_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResultado fBusca = new FormBusca.TFBuscaCentroResultado())
            {
                fBusca.St_sintetico = true;
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_pai.Text = fBusca.Cd_centro;
                        ds_centroresult_pai.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_pai_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_centroresult|=|'" + cd_centroresult_pai.Text.Trim() + "';" +
                              "isNull(a.ST_Sintetico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_centroresult_pai, ds_centroresult_pai },
                                              new TCD_CentroResultado());
        }

        private void gCentroResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsCentroResult[e.RowIndex] as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_sinteticobool)
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                    }
            }
        }

        private void bb_hist_Click(object sender, EventArgs e)
        {
            if (bsCentroResult.Current != null)
            {
                if ((bsCentroResult.Current as TRegistro_CentroResultado).St_sinteticobool)
                {
                    MessageBox.Show("Não é possível incluir Histórico em Centro Resultado Sintético!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string vColunas = "a.DS_Historico|Des. Histórico|350;" +
                                  "a.CD_Historico|Cód. Histórico Quitção|100";
                string vParamFixo = "|NOT EXISTS|(select 1 from TB_FIN_CentroResult_X_Historico x " +
                                                  "where x.cd_historico = a.cd_historico " +
                                                  "and x.cd_centroresult = '" + (bsCentroResult.Current as TRegistro_CentroResultado).Cd_centroresult.Trim() + "') ";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                                        new TCD_CadHistorico(), vParamFixo);

                if (linha != null)
                {
                    (bsCentroResult.Current as TRegistro_CentroResultado).lHist.Add(
                        new TRegistro_CadHistorico()
                        {
                            Cd_historico = linha["cd_historico"].ToString(),
                            Ds_historico = linha["ds_historico"].ToString()
                        });
                    bsCentroResult.ResetCurrentItem();
                    tlpCentro.ColumnStyles[1].Width = (bsCentroResult.Current as TRegistro_CentroResultado).lHist.Count > 0 ? 361 : 0;
                }
            }
        }

        private void bb_excluirHist_Click(object sender, EventArgs e)
        {
            if (bsHist.Current != null)
            {
                if (MessageBox.Show("Confirma a exclusão do histórico selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCentroResult.Current as TRegistro_CentroResultado).lHistDel.Add(bsHist.Current as TRegistro_CadHistorico);
                    bsHist.RemoveCurrent();
                    bsCentroResult.ResetCurrentItem();
                    tlpCentro.ColumnStyles[1].Width = (bsCentroResult.Current as TRegistro_CentroResultado).lHist.Count > 0 ? 361 : 0;
                }
            }
        }

        private void bsCentroResult_PositionChanged(object sender, EventArgs e)
        {
            if (bsCentroResult.Current != null)
            {
                if (!(bsCentroResult.Current as TRegistro_CentroResultado).St_sinteticobool &&
                      !string.IsNullOrEmpty((bsCentroResult.Current as TRegistro_CentroResultado).Cd_centroresult))
                {
                    //Buscar Hist
                    (bsCentroResult.Current as TRegistro_CentroResultado).lHist =
                        new TCD_CadHistorico().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FIN_CentroResult_X_Historico x " +
                                                "where x.cd_historico = a.cd_historico " +
                                                "and x.cd_centroresult = '" + (bsCentroResult.Current as TRegistro_CentroResultado).Cd_centroresult.Trim() + "') "
                                }
                            }, 0, string.Empty);
                    bsCentroResult.ResetCurrentItem();
                    tlpCentro.ColumnStyles[1].Width = (bsCentroResult.Current as TRegistro_CentroResultado).lHist.Count > 0 ? 361 : 0;
                }
                else
                {
                    (bsCentroResult.Current as TRegistro_CentroResultado).lHist.Clear();
                    tlpCentro.ColumnStyles[1].Width = 0;
                }
                //Buscar Arvore
                string aux = (bsCentroResult.Current as TRegistro_CentroResultado).Cd_centroresult;
                string cond = "'";
                int i = 0, j = 1, k = 0, l = aux.Length - 2;
                while (l > 0)
                {
                    while (k < l)
                    {
                        cond += aux[i].ToString() + aux[j].ToString();
                        i += 2;
                        j += 2;
                        k += 2;
                    }
                    if (l > 2)
                    {
                        cond += "', '";
                    }
                    k = 0;
                    l -= 2;
                    i = 0;
                    j = 1;

                }
                cond += "'";
                bsArvore.DataSource = new TCD_CentroResultado().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca
                                            {
                                                vNM_Campo = "a.CD_CentroResult",
                                                vOperador = "in",
                                                vVL_Busca = "(" + cond + ")"
                                            }
                                        }, 0, string.Empty);
            }
        }

        private void TFCadCentroResultado_Load(object sender, EventArgs e)
        {
            tlpCentro.ColumnStyles[1].Width = 0;
        }

        private void tlpCentro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gCentroResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
