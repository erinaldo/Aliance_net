using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Estoque;
using CamadaDados.Faturamento.Pedido;
using FormBusca;
using CamadaNegocio.Graos;
using CamadaDados.Estoque.Cadastros;

namespace Proc_Commoditties
{
    public partial class TFDevAquisicao : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public decimal pQuantidade
        { get; set; }

        public CamadaDados.Graos.TRegistro_DevAquisicao rDevAquisicao
        {
            get
            {
                if (bsDevAquisicao.Current != null)
                    return bsDevAquisicao.Current as CamadaDados.Graos.TRegistro_DevAquisicao;
                else
                    return null;
            }
        }

        public TFDevAquisicao()
        {
            InitializeComponent();
            this.pQuantidade = decimal.Zero;
            this.pCd_empresa = string.Empty;
            this.pCd_produto = string.Empty;
        }

        private void TFDevAquisicao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Origem.set_FormatZero();
            pnl_Destino.set_FormatZero();
            bsDevAquisicao.AddNew();
            bsDevolucao.AddNew();
            bsAquisicao.AddNew();
            NR_Pedido.Focus();
            QTD_Transferir.Value = pQuantidade;
            VL_Sub_Total_Destino.Enabled = pQuantidade.Equals(0);
            VL_Sub_Total_Origem.Enabled = pQuantidade.Equals(0);
            CD_Produto.Enabled = string.IsNullOrEmpty(this.pCd_produto);
            BB_Produto.Enabled = string.IsNullOrEmpty(this.pCd_produto);
            CD_Produto_Destino.Enabled = string.IsNullOrEmpty(this.pCd_produto);
            BB_Produto_Destino.Enabled = string.IsNullOrEmpty(this.pCd_produto);
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void afterGrava()
        {
            if (pnl_Origem.validarCampoObrigatorio() &&
                pnl_Destino.validarCampoObrigatorio() &&
                pDados.validarCampoObrigatorio())
            {
                if (Convert.ToDecimal(Saldo_Origem.Text) <= 0)
                {
                    MessageBox.Show("Não existe saldo no local de origem para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convert.ToDecimal(Saldo_Origem.Text) < QTD_Transferir.Value)
                {
                    MessageBox.Show("A quantidade adquirida não pode ser maior que Saldo no Local de Origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) < QTD_Transferir.Value)
                {
                    MessageBox.Show("A quantidade adquirida não pode ser maior que Saldo do  Contrato de Origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if ((TCN_Transferencia.Confere_Saldo(NR_Contrato_Destino.Text, null)) == true)
                {
                    if (QTD_Transferir.Value > (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text)))
                    {
                        MessageBox.Show("A quantidade adquirida deve ser igual ou menor ao Saldo do Pedido de Destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Valores_Fixos()
        {
            if (!string.IsNullOrEmpty(NR_Pedido.Text))
            {
                VL_Unitario_Transf.Enabled = !TCN_Transferencia.Verifica_Valores_Fixos(NR_Pedido.Text, null);
                VL_Unitario_Destino_Transf.Enabled = !TCN_Transferencia.Verifica_Valores_Fixos(NR_Pedido.Text, null);
            }
        }

        private void Busca_Saldo_Contrato_Origem()
        {
            Saldo_Contrato_Origem.Text = Convert.ToString(TCN_Transferencia.Saldo_Contrato(NR_Contrato.Text, CD_Produto.Text, true));
        }

        private void Busca_Saldo_Contrato_Destino()
        {
            Saldo_Contrato_Destino.Text = Convert.ToString(TCN_Transferencia.Saldo_Contrato(NR_Contrato_Destino.Text, CD_Produto_Destino.Text, true));
        }

        private void BB_Pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                              "n.CD_Empresa|Cód. Empresa|80;" +
                              "n.NM_Empresa|Empresa |100;" +
                              "a.NR_Pedido|NRº Pedido|80;" +
                              "n.DT_Pedido|Data|80;" +
                              "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "clifor.NM_Clifor|Nome Clifor|150;" +
                              "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                              "endereco.ds_endereco|Endereço|100;" +
                              "endereco.ds_cidade|Cidade|100;" +
                              "endereco.UF|UF|40;" +
                              "a.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|150;" +
                              "a.CD_Local|Cód. Local|80;" +
                              "d.DS_Local|Local Armazenagem|150;" +
                              "a.VL_Unitario|Valor Unitário|90;" +
                              "sg_unidade_valor|Unidade Valor|40;" +
                              "cd_unidade_valor|Cód. Unidade Valor|80;" +
                              "a.Quantidade|Quantidade|90;" +
                              "sg_unidade_est|Unidade Estoque|40;" +
                              "cd_unidade_est|Cód. Unidade Estoque|80";


            string vParamFixo =
                //O Tipo de pedido tem que ser Deposito
                                "cfgped.ST_Deposito|=|'S';" +
                                "n.st_pedido|=|'F';" + //Pedido Fechado
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from vtb_gro_contrato x " +
                                 "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem); " +
                // Configuracao fiscal de devolucao
                               "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                              "where x.cfg_pedido = n.cfg_pedido and x.TP_Fiscal = 'DV') ";
            if (!string.IsNullOrEmpty(this.pCd_empresa))
                vParamFixo += ";n.cd_empresa|=|'" + this.pCd_empresa.Trim() + "'";
            if (!string.IsNullOrEmpty(this.pCd_produto))
                vParamFixo += ";a.cd_produto|=|'" + this.pCd_produto.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Pedido,
               NR_Contrato,
               DT_Pedido,
               TP_Movimento,
               CD_Empresa,
               NM_Empresa,
               CD_Clifor,
               NM_Clifor,
               CPF,
               DS_Endereco,
               DS_Cidade,
               UF,
               CD_Produto,
               DS_Produto,
               CD_Local,
               DS_Local,
               VL_Unitario,
               QTD_Origem,
            CD_Unidade_Origem_Est,
            CD_Unidade_Origem_VL,
            Unidade_Origem_Est,
            Unidade_Origem_VL,
            }, new TCD_LanPedido_Item(), vParamFixo);

            if (NR_Pedido.Text.Trim().Equals(string.Empty))
            {
                NR_Pedido.Clear();
                NR_Contrato.Clear();
                DT_Pedido.Clear();
                TP_Movimento.Clear();
                CD_Empresa.Clear();
                NM_Empresa.Clear();
                CD_Clifor.Clear();
                NM_Clifor.Clear();
                CPF.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                CD_Produto.Clear();
                DS_Produto.Clear();
                CD_Local.Clear();
                DS_Local.Clear();
                Saldo_Origem.Clear();
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = 0;
                VL_Unitario_Transf.Value = 0;
                QTD_Transferir.Value = 0;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));
                Busca_Saldo_Contrato_Origem();
                Valores_Fixos();


                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                    try
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                                if(QTD_Transferir.Enabled)
                                    QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                        }
                    }
                    catch{ }
                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch{ }
                NR_Contrato_Destino.Clear();
                NR_Contrato_Destino.Clear();
                DT_Contrato_Destino.Clear();
                TP_Movimento_Destino.Clear();
                CD_Empresa_Destino.Clear();
                NM_Empresa_Destino.Clear();
                CD_Clifor_Destino.Clear();
                NM_Clifor_Destino.Clear();
                CPF_Destino.Clear();
                DS_Endereco_Destino.Clear();
                DS_Cidade_Destino.Clear();
                UF_Destino.Clear();
                CD_Produto_Destino.Clear();
                DS_Produto_Destino.Clear();
                CD_Local_Destino.Clear();
                DS_Local_Destino.Clear();
                Saldo_Destino.Clear();
                VL_Unitario_Destino.Clear();

                VL_Sub_Total_Destino.Value = 0;
                VL_Unitario_Destino_Transf.Value = 0;

                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }
        }

        private void NR_Pedido_Leave(object sender, EventArgs e)
        {
            string vParamFixo = "a.NR_Pedido|=|" + NR_Pedido.Text + ";" +
                // O Tipo de Pedido tem que ser deposito
                                "cfgped.ST_Deposito|=|'S';" +
                                "n.st_pedido|=|'F';" + //Pedido Fechado
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from vtb_gro_contrato x " +
                                 "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem); " +
                // Configuracao fiscal de devolucao
                                 "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                                "where x.cfg_pedido = n.cfg_pedido and x.TP_Fiscal = 'DV') ";
            if (!string.IsNullOrEmpty(this.pCd_empresa))
                vParamFixo += ";n.cd_empresa|=|'" + this.pCd_empresa.Trim() + "'";
            if (!string.IsNullOrEmpty(this.pCd_produto))
                vParamFixo += ";a.cd_produto|=|'" + this.pCd_produto.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParamFixo, new Componentes.EditDefault[]
                                    {
                                       NR_Pedido,
                                       NR_Contrato,
                                       DT_Pedido,
                                       TP_Movimento,
                                       CD_Empresa,
                                       NM_Empresa,
                                       CD_Clifor,
                                       NM_Clifor,
                                       CPF,
                                       DS_Endereco,
                                       DS_Cidade,
                                       UF,
                                       CD_Produto,
                                       DS_Produto,
                                       CD_Local,
                                       DS_Local,
                                       VL_Unitario,
                                       QTD_Origem,
                                        CD_Unidade_Origem_Est,
                                        CD_Unidade_Origem_VL,
                                        Unidade_Origem_Est,
                                        Unidade_Origem_VL
                                    }, new TCD_LanPedido_Item());

            if (NR_Pedido.Text.Trim().Equals(string.Empty))
            {
                NR_Pedido.Clear();
                NR_Contrato.Clear();
                DT_Pedido.Clear();
                TP_Movimento.Clear();
                CD_Empresa.Clear();
                NM_Empresa.Clear();
                CD_Clifor.Clear();
                NM_Clifor.Clear();
                CPF.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                CD_Produto.Clear();
                DS_Produto.Clear();
                CD_Local.Clear();
                DS_Local.Clear();
                Saldo_Origem.Clear();
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = 0;
                VL_Unitario_Transf.Value = 0;
                QTD_Transferir.Value = QTD_Transferir.Enabled ? decimal.Zero : QTD_Transferir.Value;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));
                Busca_Saldo_Contrato_Origem();
                Valores_Fixos();
                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                    try
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                                if(QTD_Transferir.Enabled)
                                    QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                        }
                    }
                    catch{ }
                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch{ }

                NR_Contrato_Destino.Clear();
                NR_Contrato_Destino.Clear();
                DT_Contrato_Destino.Clear();
                TP_Movimento_Destino.Clear();
                CD_Empresa_Destino.Clear();
                NM_Empresa_Destino.Clear();
                CD_Clifor_Destino.Clear();
                NM_Clifor_Destino.Clear();
                CPF_Destino.Clear();
                DS_Endereco_Destino.Clear();
                DS_Cidade_Destino.Clear();
                UF_Destino.Clear();
                CD_Produto_Destino.Clear();
                DS_Produto_Destino.Clear();
                CD_Local_Destino.Clear();
                DS_Local_Destino.Clear();
                Saldo_Destino.Clear();
                VL_Unitario_Destino.Clear();

                VL_Sub_Total_Destino.Value = 0;
                VL_Unitario_Destino_Transf.Value = 0;

                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "b.DS_Produto|Descrição Produto|350;" +
                                  "a.CD_Produto|Cód. Produto|100;" +
                                  "a.Quantidade|Quantidade|80;" +
                                   "sg_unidade_est|Unidade Estoque|40;" +
                              "cd_unidade_est|Cód. Unidade Estoque|80;" +
                                  "a.VL_Unitario|Valor Unitário|100;" +
                "sg_unidade_valor|Unidade Valor|40;" +
                "cd_unidade_valor|Cód. Unidade Valor|80";
                string vParamFixo = "n.nr_Pedido|=|" + NR_Pedido.Text;

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, QTD_Origem, VL_Unitario, 
                CD_Unidade_Origem_Est,
                CD_Unidade_Origem_VL,
                Unidade_Origem_Est,
                Unidade_Origem_VL,
                }, new TCD_LanPedido_Item(), vParamFixo);

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));
                Busca_Saldo_Contrato_Origem();

                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                    try
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                                if(QTD_Transferir.Enabled)
                                    QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                        }
                    }
                    catch{ }
                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch{ }
            }
            else
                CD_Produto.Clear();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Produto|=|'" + CD_Produto.Text + "';" +
                                        "n.nr_Pedido|=|" + NR_Pedido.Text,
                new Componentes.EditDefault[] { CD_Produto, DS_Produto, QTD_Origem, VL_Unitario,
                CD_Unidade_Origem_Est,
                CD_Unidade_Origem_VL,
                Unidade_Origem_Est,
                Unidade_Origem_VL,
                },
                new TCD_LanPedido_Item());

                Busca_Saldo_Contrato_Origem();
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));

                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                    try
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                                if(QTD_Transferir.Enabled)
                                    QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                        }
                    }
                    catch{ }
                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch{ }
            }
            else
                CD_Produto.Clear();
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "a.DS_Local|Local de Armazenagem|350;" +
                                 "a.CD_Local|Cód. Local|100";
                string vParamFixo = "";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                        new TCD_CadLocalArm(), vParamFixo);

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));
            }
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text + "'",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new TCD_CadLocalArm());

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, null));
            }
        }

        private void BB_Contrato_Destino_Click(object sender, EventArgs e)
        {
            if ((!(NR_Pedido.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                                "n.CD_Empresa|Cód. Empresa|80;" +
                                "n.NM_Empresa|Empresa |100;" +
                                "a.NR_Pedido|NRº Pedido|80;" +
                                "n.DT_Pedido|Data|80;" +
                                "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                                "a.CD_Clifor|Cód. Clifor|80;" +
                                "clifor.NM_Clifor|Nome Clifor|150;" +
                                "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                                "endereco.ds_endereco|Endereço|100;" +
                                "endereco.ds_cidade|Cidade|100;" +
                                "endereco.UF|UF|40;" +
                                "a.CD_Produto|Cód. Produto|80;" +
                                "d.DS_Produto|Descrição Produto|150;" +
                                "a.CD_Local|Cód. Local|80;" +
                                "d.DS_Local|Local Armazenagem|150;" +
                                "a.VL_Unitario|VL. Unitário|90;" +
                                "sg_unidade_valor|Unidade Valor|40;" +
                                "cd_unidade_valor|Cód. Unidade Valor|80;" +
                                "a.Quantidade|Quantidade|90;" +
                                "sg_unidade_est|Unidade Estoque|40;" +
                                "cd_unidade_est|Cód. Unidade Estoque|80";


                string vParamFixo =
                    // O Tipo De pedido tem que permitir transferência
                                    "a.NR_pedido|<>|" + NR_Pedido.Text.Trim() + ";" +
                                    "a.cd_produto = " + CD_Produto.Text + " or |EXISTS|(select 1 from tb_gro_ProdFixo_AFixar x where x.Cd_Produto_Fixo = " + CD_Produto.Text + ");" +
                                    "n.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                                    "cfgped.ST_Deposito|<>|'S';" + //Nao pode ser deposito
                                    "n.st_pedido|=|'F';" + //Pedido Fechado
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = n.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Pedido tem que estar amarrado a um contrato
                                     "|EXISTS|(select 1 from vtb_gro_contrato x " +
                                     "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem ";
                if (!string.IsNullOrEmpty(this.pCd_empresa))
                    vParamFixo += ";n.cd_empresa|=|'" + this.pCd_empresa.Trim() + "'";
                if (!string.IsNullOrEmpty(this.pCd_produto))
                    vParamFixo += ";a.cd_produto|=|'" + this.pCd_produto.Trim() + "'";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Contrato_Destino,
               NR_Contrato_Destino,
               DT_Contrato_Destino,
               TP_Movimento_Destino,
               CD_Empresa_Destino,
               NM_Empresa_Destino,
               CD_Clifor_Destino,
               NM_Clifor_Destino,
               CPF_Destino,
               DS_Endereco_Destino,
               DS_Cidade_Destino,
               UF_Destino,
               CD_Produto_Destino,
               DS_Produto_Destino,
               CD_Local_Destino,
               DS_Local_Destino,
               VL_Unitario_Destino,
               QTD_Destino,
               CD_Unidade_Destino_Est,
               CD_Unidade_Destino_VL,
               Unidade_Destino_Est,
               Unidade_Destino_VL}, new TCD_LanPedido_Item(), vParamFixo);



                if (NR_Contrato_Destino.Text.Trim().Equals(string.Empty))
                {
                    NR_Contrato_Destino.Clear();
                    NR_Contrato_Destino.Clear();
                    DT_Contrato_Destino.Clear();
                    TP_Movimento_Destino.Clear();
                    CD_Empresa_Destino.Clear();
                    NM_Empresa_Destino.Clear();
                    CD_Clifor_Destino.Clear();
                    NM_Clifor_Destino.Clear();
                    CPF_Destino.Clear();
                    DS_Endereco_Destino.Clear();
                    DS_Cidade_Destino.Clear();
                    UF_Destino.Clear();
                    CD_Produto_Destino.Clear();
                    DS_Produto_Destino.Clear();
                    CD_Local_Destino.Clear();
                    DS_Local_Destino.Clear();
                    Saldo_Destino.Clear();
                    VL_Unitario_Destino.Clear();

                    VL_Sub_Total_Destino.Value = 0;
                    VL_Unitario_Destino_Transf.Value = 0;


                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));

                    if (TCN_Transferencia.Confere_Saldo(NR_Contrato_Destino.Text, null))
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));

                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                            if(QTD_Transferir.Enabled)
                                QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);
                    }

                    if ((VL_Unitario_Destino.Text.Trim() != "") && (VL_Unitario_Destino.Text.Trim() != "0"))
                        try
                        {
                            VL_Unitario_Destino_Transf.Value = Convert.ToDecimal(VL_Unitario_Destino.Text);

                            if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                                VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value, 2, null);
                            else
                                VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);

                            if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                            else
                                VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        }
                        catch{ }
                }
            }
            else
            {
                MessageBox.Show("É necessário informar o Contrato de Origem com seu respectivo Produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void NR_Contrato_Destino_Leave(object sender, EventArgs e)
        {
            if ((!(NR_Pedido.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                string vParamFixo = "a.NR_Pedido|=|" + NR_Contrato_Destino.Text + ";" +
                                        "a.NR_pedido|<>|" + NR_Pedido.Text.Trim() + ";" +
                                        "n.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                                        "n.st_pedido|=|'F';" + //Pedido Fechado
                    //Nao pode ser contrato de deposito
                                        "cfgped.ST_Deposito|<>|'S';" +
                                        "a.cd_produto = " + CD_Produto.Text + " or |EXISTS|(select 1 from tb_gro_ProdFixo_AFixar x where x.Cd_Produto_Fixo = " + CD_Produto.Text + ");" +
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = n.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Pedido tem que estar amarrado a um contrato
                                     "|EXISTS|(select 1 from vtb_gro_contrato x " +
                                     "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem ";
                if (!string.IsNullOrEmpty(this.pCd_empresa))
                    vParamFixo += ";n.cd_empresa|=|'" + this.pCd_empresa.Trim() + "'";
                if (!string.IsNullOrEmpty(this.pCd_produto))
                    vParamFixo += ";a.cd_produto|=|'" + this.pCd_produto.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(
                    vParamFixo
                , new Componentes.EditDefault[] { 
               NR_Contrato_Destino,
               NR_Contrato_Destino,
               DT_Contrato_Destino,
               TP_Movimento_Destino,
               CD_Empresa_Destino,
               NM_Empresa_Destino,
               CD_Clifor_Destino,
               NM_Clifor_Destino,
               CPF_Destino,
               DS_Endereco_Destino,
               DS_Cidade_Destino,
               UF_Destino,
               CD_Produto_Destino,
               DS_Produto_Destino,
               CD_Local_Destino,
               DS_Local_Destino,
               VL_Unitario_Destino,
               QTD_Destino,
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL}, new TCD_LanPedido_Item());

                if (NR_Contrato_Destino.Text.Trim().Equals(string.Empty))
                {
                    NR_Contrato_Destino.Clear();
                    NR_Contrato_Destino.Clear();
                    DT_Contrato_Destino.Clear();
                    TP_Movimento_Destino.Clear();
                    CD_Empresa_Destino.Clear();
                    NM_Empresa_Destino.Clear();
                    CD_Clifor_Destino.Clear();
                    NM_Clifor_Destino.Clear();
                    CPF_Destino.Clear();
                    DS_Endereco_Destino.Clear();
                    DS_Cidade_Destino.Clear();
                    UF_Destino.Clear();
                    CD_Produto_Destino.Clear();
                    DS_Produto_Destino.Clear();
                    CD_Local_Destino.Clear();
                    DS_Local_Destino.Clear();
                    Saldo_Destino.Clear();
                    VL_Unitario_Destino.Clear();

                    VL_Sub_Total_Destino.Value = 0;
                    VL_Unitario_Destino_Transf.Value = 0;

                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));

                    if (TCN_Transferencia.Confere_Saldo(NR_Contrato_Destino.Text, null))
                    {
                        if(QTD_Transferir.Enabled)
                            QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));

                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                            if(QTD_Transferir.Enabled)
                                QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);   
                    }

                    if ((VL_Unitario_Destino.Text.Trim() != "") && (VL_Unitario_Destino.Text.Trim() != "0"))
                        try
                        {
                            VL_Unitario_Destino_Transf.Value = Convert.ToDecimal(VL_Unitario_Destino.Text);

                            if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                                VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value, 2, null);
                            else
                                VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);

                            if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                            else
                                VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        }
                        catch{ }
                }
            }
            else
            {
                NR_Contrato_Destino.Clear();
            }
        }

        private void BB_Produto_Destino_Click(object sender, EventArgs e)
        {
            if ((!(NR_Contrato_Destino.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                string vColunas = "b.DS_Produto|Descrição Produto|350;" +
                                  "a.CD_Produto|Cód. Produto|100;" +
                                  "a.Quantidade|Quantidade|80;" +
                                  "sg_unidade_est|Unidade Estoque|40;" +
                                  "cd_unidade_est|Cód. Unidade Estoque|80;" +
                                  "a.VL_Unitario|Valor Unitário|100;" +
                                  "sg_unidade_valor|Unidade Valor|40;" +
                                  "cd_unidade_valor|Cód. Unidade Valor|80";


                string vParamFixo = "n.nr_Pedido|=|" + NR_Contrato_Destino.Text +
                                    ";a.cd_produto = '" + CD_Produto.Text + "' or |EXISTS|(select top 1 1 from tb_gro_prodfixo_Afixar x where x.cd_produto_Afixar = a.cd_produto and x.cd_produto_Fixo = " + CD_Produto.Text + ")";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto_Destino, DS_Produto_Destino, QTD_Destino, VL_Unitario_Destino, 
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL
            }, new TCD_LanPedido_Item(), vParamFixo);

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));
            }
        }

        private void CD_Produto_Destino_Leave(object sender, EventArgs e)
        {
            if (!(NR_Contrato_Destino.Text.Trim().Equals(string.Empty)) && !(CD_Produto.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Produto|=|'" + CD_Produto_Destino.Text + "';" +
                                        "n.nr_Pedido|=|" + NR_Contrato_Destino.Text +
                                        ";a.cd_produto = '" + CD_Produto.Text + "' or |EXISTS|(select top 1 1 from tb_gro_prodfixo_Afixar x where x.cd_produto_Afixar = a.cd_produto and x.cd_produto_Fixo = " + CD_Produto.Text + ")",
                new Componentes.EditDefault[] { CD_Produto_Destino, DS_Produto_Destino, QTD_Destino, VL_Unitario_Destino,
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL},
                new TCD_LanPedido_Item());

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));
            }
            else
            {
                CD_Produto_Destino.Clear();
            }
        }

        private void BB_Local_Destino_Click(object sender, EventArgs e)
        {
            if (!(NR_Contrato_Destino.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "a.DS_Local|Local de Armazenagem|350;" +
                                 "a.CD_Local|Cód. Local|100";
                string vParamFixo = "";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local_Destino, DS_Local_Destino },
                                        new TCD_CadLocalArm(), vParamFixo);

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));
            }
            else
            {
                CD_Local_Destino.Clear();
            }
        }

        private void CD_Local_Destino_Leave(object sender, EventArgs e)
        {
            if (!(NR_Contrato_Destino.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local_Destino.Text + "'",
                new Componentes.EditDefault[] { CD_Local_Destino, DS_Local_Destino },
                new TCD_CadLocalArm());

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text, null));
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDevAquisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
