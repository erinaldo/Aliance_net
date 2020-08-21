using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFLiquidarDupTitulo : Form
    {
        private CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rch;
        public CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCh
        { 
            get { return BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo; }
            set { rch = value; }
        }
        public string Cd_contaliq { get { return cd_contaliq.Text; } }
        public decimal Vl_liquidar { get { return vl_liquidar.Value; } }
        public decimal Vl_desconto { get { return vl_desconto.Value; } }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc
        { get { return bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela; } }

        public TFLiquidarDupTitulo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pTitulo.validarCampoObrigatorio())
            {
                if (bsParcela.Count.Equals(0))
                {
                    MessageBox.Show("Obrigatorio selecionar parcela para liquidar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (vl_liquidar.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor liquidar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_liquidar.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cd_contaliq.Text))
                {
                    MessageBox.Show("Obrigatorio informar conta gerencial de liquidação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_contaliq.Focus();
                    return;
                }
                if (!vl_titulo.Value.Equals(vl_liquido.Value))
                {
                    MessageBox.Show("Valor do cheque deve ser igual ao total contas a pagar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirDuplicata()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            using (TFListaParcPagar fLista = new TFListaParcPagar())
            {
                fLista.pCd_empresa = CD_Empresa.Text;
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.lParc != null)
                    {
                        fLista.lParc.ForEach(p =>
                            {
                                if (bsParcela.Count > 0)
                                {
                                    if (!(bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Exists(v =>
                                        v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                        v.Nr_lancto.Value.Equals(p.Nr_lancto.Value) &&
                                        v.Cd_parcela.Value.Equals(p.Cd_parcela.Value)))
                                    {
                                        (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Add(p);
                                        bsParcela.ResetBindings(true);
                                    }
                                }
                                else
                                {
                                    bsParcela.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela() { p };
                                    bsParcela.ResetBindings(true);
                                }
                            });
                        vl_liquidar.Value = (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_atual);
                    }
            }
        }

        private void ExcluirDuplicata()
        {
            if(bsParcela.Current != null)
                if (MessageBox.Show("Confirma exclusão duplicata selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bsParcela.RemoveCurrent();
                    vl_liquidar.Value = (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_atual);
                }
        }

        private void afterBusca()
        {
            using (TFBuscarCheque fCheque = new TFBuscarCheque())
            {
                if (fCheque.ShowDialog() == DialogResult.OK)
                    if (fCheque.rTitulo != null)
                    {
                        rch = fCheque.rTitulo;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_empresa = fCheque.rTitulo.Cd_empresa;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nm_empresa = fCheque.rTitulo.Nm_empresa;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_banco = fCheque.rTitulo.Cd_banco;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Ds_banco = fCheque.rTitulo.Ds_banco;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_portador = fCheque.rTitulo.Cd_portador;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Ds_portador = fCheque.rTitulo.Ds_portador;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_contager = fCheque.rTitulo.Cd_contager;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nm_contager = fCheque.rTitulo.Nm_contager;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_historico = fCheque.rTitulo.Cd_historico;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Ds_historico = fCheque.rTitulo.Ds_historico;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_cheque = fCheque.rTitulo.Nr_cheque;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_lanctocheque = fCheque.rTitulo.Nr_lanctocheque;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_cgccpf = fCheque.rTitulo.Nr_cgccpf;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Tp_titulo = fCheque.rTitulo.Tp_titulo;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nomebanco = fCheque.rTitulo.Nomebanco;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Dt_emissao = fCheque.rTitulo.Dt_emissao;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Dt_vencto = fCheque.rTitulo.Dt_vencto;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Dt_compensacao = fCheque.rTitulo.Dt_compensacao;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nm_clifor_nominal = fCheque.rTitulo.Nm_clifor_nominal;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_impresso = fCheque.rTitulo.St_impresso;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Observacao = fCheque.rTitulo.Observacao;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Vl_titulo = fCheque.rTitulo.Vl_titulo;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Status_compensado = fCheque.rTitulo.Status_compensado;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Fone = fCheque.rTitulo.Fone;
                        (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nomeclifor = fCheque.rTitulo.Nomeclifor;

                        
                        pTitulo.Enabled = false;
                    }
                BS_Titulo.ResetCurrentItem();
            }
        }

        private void TFLiquidarDupTitulo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pTitulo.set_FormatZero();
            if (rch != null)
            {
                BS_Titulo.DataSource = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo() { rch };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                cd_banco.Enabled = false;
                BB_Banco.Enabled = false;
                CD_Portador.Enabled = false;
                BB_Portador.Enabled = false;
                CD_Conta.Enabled = false;
                BB_Conta.Enabled = false;
                CD_Historico.Enabled = false;
                BB_Historico.Enabled = false;
                nr_cheque.Enabled = false;
            }
            else
            {
                BS_Titulo.AddNew();
                (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Tp_titulo = "P";
                (BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            }
        }

        private void vl_liquidar_ValueChanged(object sender, EventArgs e)
        {
            vl_liquido.Value = vl_liquidar.Value - vl_desconto.Value;
        }

        private void vl_desconto_ValueChanged(object sender, EventArgs e)
        {
            if (vl_desconto.Value > vl_liquidar.Value)
            {
                MessageBox.Show("Desconto não pode ser maior que valor a liquidar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_desconto.Value = decimal.Zero;
            }
            else vl_liquido.Value = vl_liquidar.Value - vl_desconto.Value;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(CD_Conta.Text))
                vParam = "|exists|(select 1 from tb_fin_contager x " +
                         "          where x.cd_banco = a.cd_banco " +
                         "          and x.cd_contager = '" + CD_Conta.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_BANCO|Descrição|150;CD_BANCO|Código|80"
                , new Componentes.EditDefault[] { cd_banco, ds_banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), vParam);
            if (string.IsNullOrEmpty(CD_Conta.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FIN_Contager_X_Empresa x " +
                                                  "where a.cd_contager = x.cd_contager " +
                                                  "and x.cd_empresa = '" + CD_Empresa.Text + "')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Contager x " +
                                                    "where a.cd_contager = x.cd_contager " +
                                                    "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "a.cd_contager");
                if (obj != null)
                    CD_Conta.Text = obj.ToString();
            }
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_Conta.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager x " +
                          "         where x.cd_banco = a.cd_banco " +
                          "         and x.cd_contager = '" + CD_Conta.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam
                , new Componentes.EditDefault[] { cd_banco, ds_banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
            if (string.IsNullOrEmpty(CD_Conta.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FIN_Contager_X_Empresa x " +
                                                  "where a.cd_contager = x.cd_contager " +
                                                  "and x.cd_empresa = '" + CD_Empresa.Text + "')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Contager x " +
                                                    "where a.cd_contager = x.cd_contager " +
                                                    "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "a.cd_contager");
                if (obj != null)
                    CD_Conta.Text = obj.ToString();
            }
        }

        private void BB_Portador_Click(object sender, EventArgs e)
        {
            string vParamFixo = "isNull(ST_ControleTitulo,'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_Portador|Descrição|150;CD_Portador|Código|80"
                , new Componentes.EditDefault[] { CD_Portador, DS_Portador }, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParamFixo);
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("CD_Portador|=|'" + CD_Portador.Text + "';isNull(ST_ControleTitulo,'N')|=|'S'"
                , new Componentes.EditDefault[] { CD_Portador, DS_Portador }, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void BB_Conta_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                            "where k.CD_ContaGer = a.CD_ContaGer " +
                            "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                            ";a.ST_ContaCompensacao|=|'S';" +
                            "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { CD_Conta, DS_ContaGer }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void CD_Conta_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + CD_Conta.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                              ";a.st_contacompensacao|=|'S';" +
                              "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas
                , new Componentes.EditDefault[] { CD_Conta, DS_ContaGer }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'P'";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição|150;a.CD_Historico|Código|80"
                , new Componentes.EditDefault[] { CD_Historico, DS_Historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + CD_Historico.Text + "';" +
                              "a.TP_Mov|=|'P'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas
               , new Componentes.EditDefault[] { CD_Historico, DS_Historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void nr_cheque_Enter(object sender, EventArgs e)
        {
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_contager",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CD_Conta.Text.Trim() + "'"
                                }
                            }, "a.nr_cheque_seq");
            if (obj != null)
                try
                {
                    nr_cheque.Text = (Convert.ToDecimal(obj.ToString()) + 1).ToString();
                }
                catch
                { }
        }

        private void bsParcela_ListChanged(object sender, ListChangedEventArgs e)
        {
            CD_Empresa.Enabled = bsParcela.Count.Equals(0);
            BB_Empresa.Enabled = bsParcela.Count.Equals(0);
            vl_titulo.Enabled = bsParcela.Count.Equals(0);
        }

        private void vl_liquido_ValueChanged(object sender, EventArgs e)
        {
            if(rch == null)
                vl_titulo.Value = vl_liquido.Value;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirDuplicata();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirDuplicata();

        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLiquidarDupTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirDuplicata();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirDuplicata();
        }

        private void bb_contaliq_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                            "where k.CD_ContaGer = a.CD_ContaGer " +
                            "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                            ";a.ST_ContaCompensacao|<>|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { cd_contaliq, ds_contaliq }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contaliq_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + cd_contaliq.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                              ";a.st_contacompensacao|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas
                , new Componentes.EditDefault[] { cd_contaliq, ds_contaliq }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }
    }
}
