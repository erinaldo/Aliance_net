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
    public partial class TFTransfContrato : Form
    {
        private string Cd_unid_autoriz = string.Empty;

        public CamadaDados.Graos.TRegistro_Transferencia rTransf
        {
            get
            {
                if (BS_Transferencia.Current != null)
                    return BS_Transferencia.Current as CamadaDados.Graos.TRegistro_Transferencia;
                else
                    return null;
            }
        }

        public TFTransfContrato()
        {
            InitializeComponent();
        }

        private void Busca_Saldo_Contrato_Origem()
        {
            Saldo_Contrato_Origem.Text = TCN_Transferencia.Saldo_Contrato(nr_contrato_origem.Text, CD_Produto.Text, true).ToString();
        }

        private void Busca_Saldo_Contrato_Destino()
        {
            Saldo_Contrato_Destino.Text = TCN_Transferencia.Saldo_Contrato(nr_contrato_destino.Text, CD_Produto_Destino.Text, false).ToString();
        }

        private void afterGrava()
        {
            if (pnl_Origem.validarCampoObrigatorio() &&
                pnl_Destino.validarCampoObrigatorio() &&
                pDados.validarCampoObrigatorio())
            {
                if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) < QTD_Transferir.Value)
                {
                    MessageBox.Show("A quantidade transferida não pode ser maior que Saldo do  Contrato de Origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(cd_autoriz.Text))
                    if (CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(Cd_unid_autoriz, CD_Unidade_Origem_Est.Text, qtd_sdautoriz.Value, 3, null) < QTD_Transferir.Value)
                    {
                        MessageBox.Show("A quantidade transferida não pode ser maior que Saldo da autorização retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                //Verificar se o contrato de origem exige autorizacao retida
                if (string.IsNullOrEmpty(cd_autoriz.Text))
                {
                    object obj = new CamadaDados.Graos.TCD_CadContrato().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.nr_contrato",
                                            vOperador = "=",
                                            vVL_Busca = nr_contrato_origem.Text
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_exigirautorizretirada, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        MessageBox.Show("Contrato Origem exige Autorização retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_autoriz.Focus();
                        return;
                    }
                }
                if (TCN_Transferencia.Confere_Saldo(nr_contrato_destino.Text, null))
                {
                    if (QTD_Transferir.Value > (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text)))
                    {
                        MessageBox.Show("A quantidade transferida deve ser igual ou menor ao Saldo do Pedido de Destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFTransfContrato_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Origem.set_FormatZero();
            pnl_Destino.set_FormatZero();
            BS_Transferencia.AddNew();
            BS_Transf_Destino.AddNew();
            BS_Transf_Origem.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTransfContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void QTD_Transferir_Leave(object sender, EventArgs e)
        {
            if (QTD_Transferir.Value > 0)
            {
                if ((!string.IsNullOrEmpty(nr_contrato_origem.Text)) && (!string.IsNullOrEmpty(nr_contrato_destino.Text)))
                {
                    if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                        VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 3, null);
                    else
                        VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);

                    if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                        VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value, 3,  null);
                    else
                        VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                }
            }
            else
            {
                VL_Unitario_Transf.Value = decimal.Zero;
                VL_Unitario_Destino_Transf.Value = decimal.Zero;
                VL_Sub_Total_Origem.Value = decimal.Zero;
                VL_Sub_Total_Destino.Value = decimal.Zero;
            }
        }
        
        private void bb_autoriz_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_autoriz|Id. Autoriz.|80;" +
                              "a.nr_pedido|Nº Pedido|80;" +
                              "a.nr_contrato|Nº Contrato|80;" +
                              "e.cd_produto|Cd. Produto|80;" +
                              "b.ds_produto|Produto Retirar|200;" +
                              "a.qtd_retirar|Qtd. Retirar|80;" +
                              "saldo_retirar|Saldo Retirar|80";
            string vParam = "a.nr_contrato|=|" + nr_contrato_origem.Text + ";" +
                            "(a.qtd_retirar - a.qtd_retirada)|>|0 ";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_autoriz },
                                                        new CamadaDados.Graos.TCD_Autoriz_RetDeposito(), vParam);
            if (linha != null)
            {
                qtd_sdautoriz.Value = Convert.ToDecimal(linha["saldo_retirar"].ToString());
                Cd_unid_autoriz = linha["cd_unidade"].ToString();
            }
            else
            {
                qtd_sdautoriz.Value = decimal.Zero;
                Cd_unid_autoriz = string.Empty;
            }
        }

        private void cd_autoriz_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_autoriz|=|" + cd_autoriz.Text + ";" +
                            "a.nr_contrato|=|" + nr_contrato_origem.Text + ";" +
                            "(a.qtd_retirar - a.qtd_retirada)|>|0";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_autoriz },
                                    new CamadaDados.Graos.TCD_Autoriz_RetDeposito());
            if (linha != null)
            {
                qtd_sdautoriz.Value = Convert.ToDecimal(linha["saldo_retirar"].ToString());
                Cd_unid_autoriz = linha["cd_unidade"].ToString();
            }
            else
            {
                qtd_sdautoriz.Value = decimal.Zero;
                Cd_unid_autoriz = string.Empty;
            }
        }

        private void bb_contrato_origem_Click(object sender, EventArgs e)
        {
            string vParamFixo =
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                                "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                //Contrato de Deposito ou a Fixar
                                "||isnull(cfgped.ST_Deposito, 'N') = 'S' or isnull(cfgped.ST_ValoresFixos, 'N') <> 'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = a.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                // Configuracao fiscal de devolucao
                               "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                              "where x.cfg_pedido = cfgped.cfg_pedido and x.TP_Fiscal = 'TF') ";
            DataRowView linha = UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] 
                                { nr_contrato_origem,
                                  dt_contrato_origem,
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
                                  VL_Unitario,
                                  QTD_Origem}, vParamFixo);
            if (linha != null)
            {
                CD_Unidade_Origem_Est.Text = linha["cd_unid_produto"].ToString();
                CD_Unidade_Origem_VL.Text = linha["CD_Unidade"].ToString();
                Unidade_Origem_Est.Text = linha["sigla_unid_produto"].ToString();
                Unidade_Origem_VL.Text = linha["Sigla_Unidade"].ToString();
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Nr_pedido = decimal.Parse(linha["nr_pedido"].ToString());
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Id_pedidoitem = decimal.Parse(linha["id_pedidoitem"].ToString());
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Cd_condfiscal_produto = linha["cd_condfiscal_produto"].ToString();
            }

            if (string.IsNullOrEmpty(nr_contrato_origem.Text))
            {
                nr_contrato_origem.Clear();
                dt_contrato_origem.Clear();
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
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = decimal.Zero;
                VL_Unitario_Transf.Value = decimal.Zero;
                QTD_Transferir.Value = decimal.Zero;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Busca_Saldo_Contrato_Origem();
                if (string.IsNullOrEmpty(Saldo_Contrato_Origem.Text) ? false : decimal.Parse(Saldo_Contrato_Origem.Text) > decimal.Zero)
                    try
                    {
                        QTD_Transferir.Value = decimal.Parse(Saldo_Contrato_Origem.Text);
                    }
                    catch { }
                else
                {
                    MessageBox.Show("Contrato origem não possui saldo disponivel para realizar transferência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_contrato_origem.Clear();
                    nr_contrato_origem.Focus();
                }

                if (string.IsNullOrEmpty(VL_Unitario.Text) ? false : decimal.Parse(VL_Unitario.Text) > decimal.Zero)
                    try
                    {
                        VL_Unitario_Transf.Value = decimal.Parse(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch { }

                nr_contrato_destino.Clear();
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
                VL_Unitario_Destino.Clear();

                VL_Sub_Total_Destino.Value = decimal.Zero;
                VL_Unitario_Destino_Transf.Value = decimal.Zero;

                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }
        }

        private void nr_contrato_origem_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.nr_contrato|=|" + nr_contrato_origem.Text + ";" +
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Contrato de Deposito ou a Fixar
                                "||isnull(cfgped.ST_Deposito, 'N') = 'S' or isnull(cfgped.ST_ValoresFixos, 'N') <> 'S';" +
                                "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = a.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                // Configuracao fiscal de devolucao
                                 "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido and x.TP_Fiscal = 'TF') "

            , new Componentes.EditDefault[] { 
               nr_contrato_origem,
               dt_contrato_origem,
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
               VL_Unitario,
               QTD_Origem}, new CamadaDados.Graos.TCD_CadContrato());
            if (linha != null)
            {
                CD_Unidade_Origem_Est.Text = linha["cd_unid_produto"].ToString();
                CD_Unidade_Origem_VL.Text = linha["CD_Unidade"].ToString();
                Unidade_Origem_Est.Text = linha["sigla_unid_produto"].ToString();
                Unidade_Origem_VL.Text = linha["Sigla_Unidade"].ToString();
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Nr_pedido = decimal.Parse(linha["nr_pedido"].ToString());
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Id_pedidoitem = decimal.Parse(linha["id_pedidoitem"].ToString());
                (BS_Transf_Origem.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Cd_condfiscal_produto = linha["cd_condfiscal_produto"].ToString();
            }
            if (string.IsNullOrEmpty(nr_contrato_origem.Text))
            {
                nr_contrato_origem.Clear();
                dt_contrato_origem.Clear();
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
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = decimal.Zero;
                VL_Unitario_Transf.Value = decimal.Zero;
                QTD_Transferir.Value = decimal.Zero;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Busca_Saldo_Contrato_Origem();
                if (string.IsNullOrEmpty(Saldo_Contrato_Origem.Text) ? false : decimal.Parse(Saldo_Contrato_Origem.Text) > decimal.Zero)
                    try
                    {
                        QTD_Transferir.Value = decimal.Parse(Saldo_Contrato_Origem.Text);
                    }
                    catch { }
                else
                {
                    MessageBox.Show("Contrato origem não possui saldo disponivel para realizar transferência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_contrato_origem.Clear();
                    nr_contrato_origem.Focus();
                }
                if (string.IsNullOrEmpty(VL_Unitario.Text) ? false : decimal.Parse(VL_Unitario.Text) > decimal.Zero)
                    try
                    {
                        VL_Unitario_Transf.Value = decimal.Parse(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value, 2, null);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch { }
                nr_contrato_destino.Clear();
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
                VL_Unitario_Destino.Clear();

                VL_Sub_Total_Destino.Value = decimal.Zero;
                VL_Unitario_Destino_Transf.Value = decimal.Zero;

                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }
        }

        private void bb_contrato_destino_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_contrato_origem.Text))
            {
                string vParamFixo =
                    // O Tipo De pedido tem que permitir transferência
                                    "a.NR_contrato|<>|" + nr_contrato_origem.Text.Trim() + ";" +
                                    "a.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                                    "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                                    "a.cd_produto|=|'" + CD_Produto.Text + "';" +
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = cfgped.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
                //Verificar se o usuario tem acesso a transferencia entre empresas diferentes
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR TRANSF. ENTRE CONTRATOS DE EMPRESAS DIFERENTES", null))
                    vParamFixo += ";a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";

                DataRowView linha = UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] 
                {nr_contrato_destino,
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
                 VL_Unitario_Destino,
                 QTD_Destino}, vParamFixo);
                if (linha != null)
                {
                    CD_Unidade_Destino_Est.Text = linha["cd_unid_produto"].ToString();
                    CD_Unidade_Destino_VL.Text = linha["CD_Unidade"].ToString();
                    Unidade_Destino_Est.Text = linha["sigla_unid_produto"].ToString();
                    Unidade_Destino_VL.Text = linha["Sigla_Unidade"].ToString();
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Nr_pedido = decimal.Parse(linha["nr_pedido"].ToString());
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Id_pedidoitem = decimal.Parse(linha["id_pedidoitem"].ToString());
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Cd_condfiscal_produto = linha["cd_condfiscal_produto"].ToString();
                }

                if (string.IsNullOrEmpty(nr_contrato_destino.Text))
                {
                    nr_contrato_destino.Clear();
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
                    VL_Unitario_Destino.Clear();

                    VL_Sub_Total_Destino.Value = decimal.Zero;
                    VL_Unitario_Destino_Transf.Value = decimal.Zero;

                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Busca_Saldo_Contrato_Destino();

                    if (TCN_Transferencia.Confere_Saldo(nr_contrato_destino.Text, null))
                    {
                        QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));
                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);
                    }

                    if ((!string.IsNullOrEmpty(VL_Unitario_Destino.Text)) && (VL_Unitario_Destino.Text.Trim() != "0"))
                    {
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
                        catch { }
                    }
                }
            }
            else
                MessageBox.Show("É necessário informar o Contrato de Origem com seu respectivo Produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void nr_contrato_destino_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_contrato_origem.Text))
            {
                string vParam = "a.NR_Contrato|=|" + nr_contrato_destino.Text + ";" +
                                        "a.NR_Contrato|<>|" + nr_contrato_origem.Text.Trim() + ";" +
                                        "a.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                                        "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                                        "a.cd_produto|=|'" + CD_Produto.Text + "';" +
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = cfgped.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
                //Verificar se o usuario tem acesso a transferencia entre empresas diferentes
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR TRANSF. ENTRE CONTRATOS DE EMPRESAS DIFERENTES", null))
                    vParam += ";a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";

                DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { 
                                        nr_contrato_destino,
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
                                        VL_Unitario_Destino,
                                        QTD_Destino}, new CamadaDados.Graos.TCD_CadContrato());
                if (linha != null)
                {
                    CD_Unidade_Destino_Est.Text = linha["cd_unid_produto"].ToString();
                    CD_Unidade_Destino_VL.Text = linha["CD_Unidade"].ToString();
                    Unidade_Destino_Est.Text = linha["sigla_unid_produto"].ToString();
                    Unidade_Destino_VL.Text = linha["Sigla_Unidade"].ToString();
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Nr_pedido = decimal.Parse(linha["nr_pedido"].ToString());
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Id_pedidoitem = decimal.Parse(linha["id_pedidoitem"].ToString());
                    (BS_Transf_Destino.Current as CamadaDados.Graos.TRegistro_Transf_X_Contrato).Cd_condfiscal_produto = linha["cd_condfiscal_produto"].ToString();
                }
                if (string.IsNullOrEmpty(nr_contrato_destino.Text))
                {
                    nr_contrato_destino.Clear();
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
                    VL_Unitario_Destino.Clear();

                    VL_Sub_Total_Destino.Value = decimal.Zero;
                    VL_Unitario_Destino_Transf.Value = decimal.Zero;

                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Busca_Saldo_Contrato_Destino();
                    if (TCN_Transferencia.Confere_Saldo(nr_contrato_destino.Text, null))
                    {
                        QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));
                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);
                    }

                    if ((!string.IsNullOrEmpty(VL_Unitario_Destino.Text)) && (VL_Unitario_Destino.Text.Trim() != "0"))
                    {
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
                        catch
                        { }
                    }
                }
            }
            else
                nr_contrato_destino.Clear();
        }
    }
}
