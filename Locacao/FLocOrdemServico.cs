using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using CamadaDados.Diversos;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Servicos.Cadastros;

namespace Locacao
{
    public partial class FLocOrdemServico : Form
    {
        private TRegistro_LanServico lanservico;
        public TRegistro_LanServico lanServico
        {
            get
            {
                if (bsOrdemServico != null)
                    return bsOrdemServico.Current as TRegistro_LanServico;
                else
                    return null;
            }
            set { lanservico = value; }
        }

        public FLocOrdemServico()
        {
            InitializeComponent();
        }

        private void BuscarItens()
        {
            if (string.IsNullOrEmpty(CD_Produto.Text))
                UtilPesquisa.BuscarProduto(string.Empty,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { CD_Produto, DS_Produto, Nr_patrimonio },
                                                     null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { CD_Produto, DS_Produto, Nr_patrimonio },
                                                     null);

            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                if (new TCD_LanServico().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_ProdutoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_finalizada",
                                vOperador = "is",
                                vVL_Busca = "null"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_os, 'AB')",
                                vOperador = "<>",
                                vVL_Busca = "'CA'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                            "where x.cd_patrimonio = a.CD_ProdutoOS " +
                                            "and x.quantidade > 1 ) "
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Existem manutenções não finalizadas para este Patrimônio!\r\n" +
                                    "Consulte a tela de Ordem de serviço e verifique para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    DS_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
                if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from VTB_LOC_LOCACAO x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_locacao = x.ID_Locacao " +
                                                        "and x.Status in ('DEVOLUCAO EXPIRADA', 'ENTREGUE', 'ENTREGA PARCIAL')) "
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                        "where x.cd_patrimonio = a.cd_produto " +
                                                        "and x.quantidade > 1 ) "
                                        }
                                    }, "1") != null)
                {
                    MessageBox.Show("Item está em locação!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    DS_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
                if (new TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca {vNM_Campo = "a.cd_patrimonio", vOperador = "=", vVL_Busca = "'" + CD_Produto.Text.Trim() + "'" },
                        new TpBusca {vNM_Campo = "isnull(a.st_controlehora, 'N')", vOperador = "=", vVL_Busca = "'S'" }
                    }, "1") != null)
                {
                    gbHorimetro.Visible = true;
                    horimetro.Value = 0;
                }
                else
                {
                    gbHorimetro.Visible = false;
                    horimetro.Value = 0;
                }
                if (!string.IsNullOrEmpty(CD_Produto.Text))
                {
                    //Buscar lengt cd_produto
                    TList_CadParamSys lParam =
                        TCN_CadParamSys.Busca("CD_PRODUTO",
                                              string.Empty,
                                              decimal.Zero,
                                              null);
                    if (lParam.Count > 0)
                        if (CD_Produto.Text.Trim().Length < lParam[0].Tamanho)
                            CD_Produto.Text = CD_Produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                }

            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new TCD_CadEmpresa());
            //ValidarNumeroOs();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
              , new TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
            //ValidarNumeroOs();
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_Ordem|=|" + TP_Ordem.Text, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new TCD_TpOrdem());
            //Verificar se o numero da os e automatico
            if (bsOrdemServico.Current != null)
            {
                id_os.Enabled = TCN_LanServico.SequenciaManual((bsOrdemServico.Current as TRegistro_LanServico), null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TipoOrdem|Tipo Ordem|300;a.tp_Ordem|Código|90"
            , new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new TCD_TpOrdem(), null);
            //Verificar se o numero da os e automatico
            if (bsOrdemServico.Current != null)
            {
                id_os.Enabled = TCN_LanServico.SequenciaManual((bsOrdemServico.Current as TRegistro_LanServico), null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            BuscarItens();
        }

        private void FLocOrdemServico_Load(object sender, EventArgs e)
        {
            if (lanservico != null)
            {
                bsOrdemServico.DataSource = lanservico;                   
            }
            else
                bsOrdemServico.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (panel1.validarCampoObrigatorio() && panel2.validarCampoObrigatorio())
            {
                if (gbHorimetro.Visible && horimetro.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar horimetro do patrimonio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    horimetro.Focus();
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void FLocOrdemServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                if (panel1.validarCampoObrigatorio() && panel2.validarCampoObrigatorio())
                    DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F6))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void DT_Prevista_TextChanged(object sender, EventArgs e)
        {
            if (DT_Prevista.Text.Length.Equals(10) && Convert.ToDateTime(DT_Prevista.Text) < Convert.ToDateTime(DT_Abertura.Text))
            {
                DT_Prevista.Text = "";
            }
        }

        private void ds_defeitocliente_TextChanged(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as TRegistro_LanServico).Ds_defeitocliente = ds_defeitocliente.Text.Trim();
        }

        private void CD_Produto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CD_Produto.Text.Trim()))
                return;


            if (new TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca {vNM_Campo = "a.cd_patrimonio", vOperador = "=", vVL_Busca = "'" + CD_Produto.Text.Trim() + "'" },
                        new TpBusca {vNM_Campo = "isnull(a.st_controlehora, 'N')", vOperador = "=", vVL_Busca = "'S'" }
                    }, "1") != null)
            {
                gbHorimetro.Visible = true;
                horimetro.Value = 0;
            }
            else
            {
                gbHorimetro.Visible = false;
                horimetro.Value = 0;
            }
        }
    }
}
