using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadGrupoCF : FormCadPadrao.FFormCadPadrao
    {
        public TFCadGrupoCF()
        {
            InitializeComponent();
            this.DTS = bsGrupoCF;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("FIXO", "F"));
            cbx.Add(new TDataCombo("VARIAVEL", "V"));
            tp_custo.DataSource = cbx;
            tp_custo.ValueMember = "Value";
            tp_custo.DisplayMember = "Display";
        }

        public override int buscarRegistros()
        {
            TList_CadGrupoCF lista = TCN_CadGrupoCF.Buscar(string.Empty,
                                                           DS_GrupoCF.Text,
                                                           CD_GrupoCF_Pai.Text,
                                                           ST_Sintetico.Checked ? "S" : string.Empty,
                                                           string.Empty,
                                                           0,
                                                           string.Empty,
                                                           null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsGrupoCF.DataSource = lista;
                    bsGrupoCF_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                    bsGrupoCF.Clear();
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
                bsGrupoCF.AddNew();
                base.afterNovo();
                tp_custo.Enabled = true;
                btn_Inserir_Item.Enabled = true;
                btn_Deleta_Item.Enabled = true;
                DS_GrupoCF.Focus();
            }
        }

        public override void afterAltera()
        {
            if (bsGrupoCF.Current != null)
            {
                (bsGrupoCF.Current as TRegistro_CadGrupoCF).Ds_grupocf = (bsGrupoCF.Current as TRegistro_CadGrupoCF).Ds_grupocf.Trim();
                //Habilitar tp_ccusto
                if ((bsGrupoCF.Current as TRegistro_CadGrupoCF).St_sinteticobool)
                {
                    object retorno = new TCD_CadGrupoCF().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_grupocf_pai",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_GrupoCF_Pai.Text.Trim() + "'"
                            }
                        }, "1");
                    base.afterAltera();
                    if (retorno != null)
                        ST_Sintetico.Enabled = !(retorno.ToString().Trim().Equals("1"));
                }
                else
                    base.afterAltera();
                btn_Deleta_Item.Enabled = true;
                btn_Inserir_Item.Enabled = true;
                this.DS_GrupoCF.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            btn_Inserir_Item.Enabled = false;
            btn_Deleta_Item.Enabled = false;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return TCN_CadGrupoCF.Gravar(bsGrupoCF.Current as TRegistro_CadGrupoCF, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    if (bsGrupoCF.Current != null)
                    {
                        try
                        {
                            TList_CadGrupoCF qtFilhos = new TCD_CadGrupoCF().Select(new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = " a.cd_grupocf_pai",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsGrupoCF.Current as TRegistro_CadGrupoCF).Cd_grupocf + "' "
                                }
                            },0,string.Empty);
                            if (qtFilhos.Count > 0)
                            {
                                MessageBox.Show("Não foi possível excluir, pois o registro corrente possui " + qtFilhos.Count + " "+ (qtFilhos.Count > 1 ? "relacionados.": "relacionado."), 
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            TCN_CadGrupoCF.Excluir(bsGrupoCF.Current as TRegistro_CadGrupoCF, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        bsGrupoCF.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void InserirHistorico()
        {
            if (bsGrupoCF.Current != null)
            {
                if ((bsGrupoCF.Current as TRegistro_CadGrupoCF).St_sinteticobool)
                {
                    MessageBox.Show("Não é permitido inserir historico em despesas SINTETICAS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFListaHistoricos fList = new TFListaHistoricos())
                {
                    fList.Tp_mov = "P";
                    if (fList.ShowDialog() == DialogResult.OK)
                        if (fList.lHist != null)
                        {
                            fList.lHist.ForEach(p =>
                                {
                                    if (!(bsGrupoCF.Current as TRegistro_CadGrupoCF).lHistorico.Exists(v => v.Cd_historico.Trim().Equals(p.Cd_historico.Trim())))
                                        (bsGrupoCF.Current as TRegistro_CadGrupoCF).lHistorico.Add(p);
                                });
                            bsGrupoCF.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirHistorico()
        {
            if (bsHistorico.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsGrupoCF.Current as TRegistro_CadGrupoCF).lHistDel.Add(
                        bsHistorico.Current as TRegistro_CadHistorico);
                    bsHistorico.RemoveCurrent();
                }
        }

        private void bb_grupocf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_GrupoCf|Grupo Custo Fixo|350;" +
                              "a.CD_GrupoCF|Cód. GrupoCF|100";
            string vParamFixo = "isNull(a.ST_Sintetico, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_GrupoCF_Pai, DS_GrupoCf_Pai },
                                    new TCD_CadGrupoCF(), vParamFixo);
            controleTipoCusto();
        }

        private void CD_GrupoCF_Pai_Leave(object sender, EventArgs e)
        {
            if (CD_GrupoCF_Pai.Text.Trim() != "")
            {
                string vColunas = "a." + CD_GrupoCF_Pai.NM_CampoBusca + "|=|'" + CD_GrupoCF_Pai.Text + "';" +
                                  "isNull(a.ST_Sintetico, 'N')|=|'S'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_GrupoCF_Pai, DS_GrupoCf_Pai },
                                        new TCD_CadGrupoCF());
            }
            else
                DS_GrupoCf_Pai.Clear();
            controleTipoCusto();
        }

        private void controleTipoCusto()
        {
            if (!string.IsNullOrEmpty(CD_GrupoCF_Pai.Text))
            {
                TList_CadGrupoCF lCadGrupoCF = new TCD_CadGrupoCF().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_grupocf",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_GrupoCF_Pai.Text.Trim() + "'"
                            }
                        }, 1, string.Empty);
                if (lCadGrupoCF.Count > 0)
                {
                    if (lCadGrupoCF[0].Tp_custo.Equals("F"))
                        (bsGrupoCF.Current as TRegistro_CadGrupoCF).Tp_custo = "F";
                    else
                        (bsGrupoCF.Current as TRegistro_CadGrupoCF).Tp_custo = "V";
                    bsGrupoCF.ResetCurrentItem();
                }
                tp_custo.Enabled = false;
                ST_Sintetico.Enabled = false;
            }
        }

        private void TFCadGrupoCF_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void bsGrupoCF_PositionChanged(object sender, EventArgs e)
        {
            if (bsGrupoCF.Current != null)
                if (!string.IsNullOrEmpty((bsGrupoCF.Current as TRegistro_CadGrupoCF).Cd_grupocf))
                {
                    (bsGrupoCF.Current as TRegistro_CadGrupoCF).lHistorico =
                        TCN_CadHistorico.Buscar(string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                (bsGrupoCF.Current as TRegistro_CadGrupoCF).Cd_grupocf,
                                                0,
                                                string.Empty);
                    bsGrupoCF.ResetCurrentItem();
                }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirHistorico();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirHistorico();
        }

        private void TFCadGrupoCF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.F10) && btn_Inserir_Item.Enabled)
                this.InserirHistorico();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && btn_Deleta_Item.Enabled)
                this.ExcluirHistorico();
        }

        private void TFCadGrupoCF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

    }
}

