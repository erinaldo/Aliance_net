using System;
using System.Windows.Forms;
using Utils;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;

namespace Faturamento
{
    public partial class TFLanPedidoECommerce : Form
    {
        TRegistro_CfgECommerce rCfg { get; set; }
        public TFLanPedidoECommerce()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsPedido.DataSource = new TCD_Pedido().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfg.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cfg_pedido",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfg.Cfg_pedido.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_pedido, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                        "where x.nr_pedido = a.nr_pedido)"
                                        }
                                    }, 0, string.Empty);

        }

        private bool PermissaoCancelar(string log)
        {
            //verifica se usuario tem permissão para cancelar
            if (new CamadaDados.Diversos.TCD_Usuario_RegraEspecial().BuscarEscalar(
                new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.Login",
                            vOperador = "=",
                            vVL_Busca = "'"+log+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ds_regra",
                            vOperador = "=",
                            vVL_Busca = "'PERMITIR CANCELAR PEDIDO'"
                        }
                    }, "1") != null)
                return true;
            else
                return false;
        }

        private void Exclui()
        {

            //motivo do cancelamento
            InputBox iB = new InputBox();
            iB.Text = "Motivo do cancelamento";
            (bsPedido.Current as TRegistro_Pedido).dsCancelmento = iB.ShowDialog();
            if (string.IsNullOrEmpty((bsPedido.Current as TRegistro_Pedido).dsCancelmento))
            {
                MessageBox.Show("Obrigatório informar descrição", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //verifica se usuario pode cancelar pedido, se nao:  chama tela de login 
            if (!PermissaoCancelar(Utils.Parametros.pubLogin))
            {
                using (Proc_Commoditties.TFLanSessaoPDV fLog = new Proc_Commoditties.TFLanSessaoPDV())
                {
                    do
                    {
                        fLog.ShowDialog();
                        if (fLog.DialogResult == DialogResult.Cancel)
                            return;
                        (bsPedido.Current as TRegistro_Pedido).LoginCancelamento = fLog.Usuario;
                        if (!PermissaoCancelar((bsPedido.Current as TRegistro_Pedido).LoginCancelamento))
                            MessageBox.Show("Usuário não pode cancelar pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } while (!PermissaoCancelar((bsPedido.Current as TRegistro_Pedido).LoginCancelamento));
                }
            }
            if ((bsPedido != null) && (bsPedido.Count > 0))
            {
                if ((bsPedido.Current as TRegistro_Pedido).St_Commodittiesbool)
                {
                    MessageBox.Show("Não é permitido CANCELAR pedido commoditties pela tela de faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsPedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    if (TCN_Pedido.Verifica_Disponibilidade_Pedido((bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        MessageBox.Show("Não é permitido CANCELAR um pedido FECHADO que tenha FATURAMENTO", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (TCN_Pedido.Verifica_Pedido_Contrato((bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        MessageBox.Show("Não é permitido CANCELAR pedido FECHADO que tenha CONTRATO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if ((bsPedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido CANCELAR um pedido ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsPedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("O Pedido já se encontra CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se pedido possui duplicata ativa
                if (new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.nr_pedido = " + (bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Pedido possui duplicata em aberto.\r\n" +
                                    "Entre em contato com o responsável pelo financeiro para realizar o cancelamento da duplicata.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se o pedido integra ordem de servico com status <DEVOLVIDA>
                object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedidointegra",
                            vOperador = "=",
                            vVL_Busca = (bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_os, 'AB')",
                            vOperador = "=",
                            vVL_Busca = "'DV'"
                        }
                    }, "1");
                string msg = string.Empty;
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                        msg = "Pedido integra ordem serviço com status <DEVOLVIDA>.\r\n" +
                              "Ao cancelar o pedido as ordens de serviços voltarão para o status <PROCESSADA>.\r\n";
                //Verificar se o pedido integra taxas armazenagem
                obj = new CamadaDados.Graos.TCD_Taxa_X_PedidoItem().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_GRO_Taxa_X_PedidoItem x "+
                                        "where x.nr_pedido = a.nr_pedido)"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        }
                    }, "1");
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                        msg += "Pedido integra taxas de armazenagem de produtos em deposito.\r\n" +
                               "Ao cancelar o pedido as taxas voltarão para o status <ABERTA>.\r\n";
                //Verificar se o pedido integra orcamento
                if ((bsPedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p => p.Nr_orcamento != null))
                    msg += "Pedido integra orçamento. Ao cancelar o pedido o orçamento voltara para o status <ABERTO>\r\n";
                if (MessageBox.Show(msg.Trim() + "Deseja Realmente CANCELAR o PEDIDO", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_Pedido.Deleta_Pedido(bsPedido.Current as TRegistro_Pedido, null);
                        MessageBox.Show("O Pedido foi CANCELADO com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void FaturarPedido()
        {
            if (bsPedido.Current != null)
            {
                    
                //Verificar se o pedido tem configuracao fiscal para emitir nota
                object obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfg.Cfg_pedido.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    }
                                }, "1");
                if (obj == null ? true : obj.ToString().Trim() != "1")
                {
                    MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + rCfg.Cfg_pedido.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TRegistro_LanFaturamento rFat =
                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(bsPedido.Current as TRegistro_Pedido, false, decimal.Zero);
                    TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                    if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                           rFat.Nr_lanctofiscalstr,
                                                                           null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    //Encerrar Pedido
                    (bsPedido.Current as TRegistro_Pedido).ST_Pedido = "P";
                    (bsPedido.Current as TRegistro_Pedido).ST_Registro = "P";
                    TRegistro_Pedido rPed = bsPedido.Current as TRegistro_Pedido;
                    TCN_Pedido.Grava_Pedido(bsPedido.Current as TRegistro_Pedido, null);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatório selecionar pedido para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanPedidoECommerce_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_cfgecommerce x " +
                                                        "where x.cd_empresa = a.cd_empresa)"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
                rCfg = TCN_CfgECommerce.Buscar((cbEmpresa.SelectedItem as TRegistro_CadEmpresa).Cd_empresa, null)[0];
        }

        private void bsPedido_PositionChanged(object sender, EventArgs e)
        {
            if(bsPedido.Current != null)
            {
                (bsPedido.Current as TRegistro_Pedido).Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               (bsPedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               false,
                                                                                               null);
                bsPedido.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bbFaturar_Click(object sender, EventArgs e)
        {
            FaturarPedido();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanPedidoECommerce_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                Exclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                FaturarPedido();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            Exclui();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            using (TFImportPedLojaVirtual fImport = new TFImportPedLojaVirtual())
            {
                fImport.ShowDialog();
                afterBusca();
            }
        }
    }
}
