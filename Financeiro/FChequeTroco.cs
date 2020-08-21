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
    public partial class TFChequeTroco : Form
    {
        public TFChequeTroco()
        {
            InitializeComponent();
        }

        private void GerarNumeroCheque()
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
                nr_cheque.Text = (Convert.ToDecimal(obj.ToString()) + 1).ToString();
        }

        private bool ValidarNumeroCheque()
        {
            bool retorno = true;
            if((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_banco.Text)) &&
                (!string.IsNullOrEmpty(nr_cheque.Text)))
            {
                object obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cheque",
                                        vOperador = "=",
                                        vVL_Busca = "'" + nr_cheque.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.status_compensado, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_titulo",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    }

                                }, "1");
                if (obj != null)
                {
                    MessageBox.Show("Cheque Nº " + nr_cheque.Text.Trim() + " ja se encontra emitido para a \r\n" +
                                    "Empresa: " + cd_empresa.Text.Trim() + "\r\n" +
                                    "Banco: " + cd_banco.Text.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_cheque.Clear();
                    nr_cheque.Focus();
                    retorno = false;
                }
            }
            return retorno;
        }

        private void GerarCheque()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_titulo.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não é permitido gerar cheque com valor ZERO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCh = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
                for (int i = 0; i < qtd_cheque.Value; i++)
                {
                    CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCh = new CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo();
                    rCh.Cd_empresa = cd_empresa.Text;
                    rCh.Cd_banco = cd_banco.Text;
                    rCh.Nr_cheque = (decimal.Parse(nr_cheque.Text) + i).ToString();
                    rCh.Tp_titulo = "P";
                    rCh.Nomebanco = ds_banco.Text;
                    rCh.Dt_emissao = DT_Pgto.Data;
                    rCh.Vl_titulo = vl_titulo.Value;
                    rCh.Status_compensado = "T";//Cheque Troco
                    rCh.Cd_portador = CD_Portador.Text;
                    rCh.Cd_historico = CD_Historico.Text;
                    rCh.Cd_contager = CD_Conta.Text;
                    rCh.St_lancarcaixa = true;
                    lCh.Add(rCh);
                }
                try
                {
                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(lCh, null);
                    if (MessageBox.Show("Cheques gravados com sucesso.\r\n" +
                                        "Deseja imprimir os cheques?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(lCh);
                    this.Close();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFChequeTroco_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            //Buscar vl multiplo
            object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                }
                            }, "a.vl_multiplochtroco");
            if (obj != null)
            {
                vl_multchtroco.Value = decimal.Parse(obj.ToString());
                vl_titulo.Value = vl_multchtroco.Value * vl_multiplo.Value;
            }
            vl_multchtroco.Enabled = vl_multchtroco.Value.Equals(decimal.Zero);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            //Buscar vl multiplo
            object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                }
                            }, "a.vl_multiplochtroco");
            if (obj != null)
            {
                vl_multchtroco.Value = decimal.Parse(obj.ToString());
                vl_titulo.Value = vl_multchtroco.Value * vl_multiplo.Value;
            }
            vl_multchtroco.Enabled = vl_multchtroco.Value.Equals(decimal.Zero);
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_banco|Banco|200;" +
                              "a.cd_banco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco, ds_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_banco, ds_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void BB_Conta_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                            "where k.CD_ContaGer = a.CD_ContaGer " +
                            "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "' );" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                            ";a.ST_ContaCompensacao|=|'S';" +
                            "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80", 
                                            new Componentes.EditDefault[] { CD_Conta, DS_ContaGer }, 
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void CD_Conta_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + CD_Conta.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                              ";a.st_contacompensacao|=|'S';" +
                              "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Conta, DS_ContaGer }, 
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Portador_Click(object sender, EventArgs e)
        {
            string vParamFixo = "isNull(ST_ControleTitulo,'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_Portador|Descrição|150;CD_Portador|Código|80", 
                                            new Componentes.EditDefault[] { CD_Portador, DS_Portador }, 
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParamFixo);
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("CD_Portador|=|'" + CD_Portador.Text + 
                                              "';isNull(ST_ControleTitulo,'N')|=|'S'", 
                                              new Componentes.EditDefault[] { CD_Portador, DS_Portador }, 
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'P'";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição|150;a.CD_Historico|Código|80", 
                                             new Componentes.EditDefault[] { CD_Historico, DS_Historico }, 
                                             new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + CD_Historico.Text + "';" +
                              "a.TP_Mov|=|'P'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico }, 
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void nr_cheque_Enter(object sender, EventArgs e)
        {
            this.GerarNumeroCheque();
        }

        private void nr_cheque_Leave(object sender, EventArgs e)
        {
            this.ValidarNumeroCheque();
        }

        private void vl_multchtroco_ValueChanged(object sender, EventArgs e)
        {
            vl_titulo.Value = vl_multchtroco.Value * vl_multiplo.Value;
        }

        private void vl_multiplo_ValueChanged(object sender, EventArgs e)
        {
            vl_titulo.Value = vl_multchtroco.Value * vl_multiplo.Value;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.GerarCheque();
        }

        private void TFChequeTroco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarCheque();
        }
    }
}
