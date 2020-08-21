using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using FormPadrao;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using LeituraSerial;
using CamadaDados.Diversos;
using FormPesagemPadrao;

namespace Balanca.Classificacao
{
    public partial class TFCla_Cereais_Origem : Form
    {
        private TTpModo tpModo;
        private decimal peso_referencia = 0;

        public TFCla_Cereais_Origem()
        {
            InitializeComponent();
        }
                
        private void habilitaBotoes(bool vNovo, bool vGravar, bool vRefugar, bool vCancelar)
        {
            BB_Novo.Visible = vNovo;
            BB_Gravar.Visible = vGravar;
            BB_Refugar.Visible = vRefugar;
            BB_Cancelar.Visible = vCancelar;
        }

        private void modoBotoes()
        {
            if (tpModo == TTpModo.tm_Standby)
                habilitaBotoes(true, false, false, false);
            else if (tpModo == TTpModo.tm_Insert)
                habilitaBotoes(false, 
                               true,
                               CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR REFUGAR TICKET", null), 
                               true);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFCla_Cereais_Origem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pClassificacao.set_FormatZero();
            pConsulta.set_FormatZero();
            afterCancela();
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HabilitaCampos()
        {
            if (tpModo == TTpModo.tm_Standby)
            {
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                ID_Ticket.Enabled = false;
                Placa.Enabled = false;
                BB_Placa.Enabled = false;
                TP_Pesagem.Enabled = false;
                BB_TP_Pesagem.Enabled = false;
                CD_TabelaDesconto.Enabled = false;
                BB_TabelaDesconto.Enabled = false;
                CD_Moega.Enabled = false;
                BB_Moega.Enabled = false;

                Nr_Ticket.Text = "";
                Pesagem.Text = "";
                NMTPPesagem.Text = "";
                CDTabelaDesconto.Text = "";
                DSTabelaDesconto.Text = "";
                CDEmpresa.Text = "";
                NMEmpresa.Text = "";
                CDPLaca.Text = ""; 
                
                Edt_PercentualLocal.Enabled = false;
                Edt_PesoAmostra.Enabled = false;
                Edt_PesoReferencia.Enabled = false;
                BT_Classificacao.Enabled = false;
            }

            if (tpModo == TTpModo.tm_Insert)
            {
                CD_Empresa.Enabled = true;
                BB_Empresa.Enabled = true;
                ID_Ticket.Enabled = true;
                Placa.Enabled = true;
                BB_Placa.Enabled = true;
                TP_Pesagem.Enabled = true;
                BB_TP_Pesagem.Enabled = true;
                CD_TabelaDesconto.Enabled = true;
                BB_TabelaDesconto.Enabled = true;
                CD_Moega.Enabled = true;
                BB_Moega.Enabled = true;

                Nr_Ticket.Enabled = true;
                Pesagem.Enabled = true;
                BB_Pesagem.Enabled = true;
                CDTabelaDesconto.Enabled = true;
                CDEmpresa.Enabled = true;
                CDPLaca.Enabled = true;

                Edt_PercentualLocal.Enabled = false;
                Edt_PesoAmostra.Enabled = false;
                Edt_PesoReferencia.Enabled = false;
                BT_Classificacao.Enabled = false;
            }

            if (tpModo == TTpModo.tm_Edit)
            {
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                ID_Ticket.Enabled = false;
                Placa.Enabled = false;
                BB_Placa.Enabled = false;
                TP_Pesagem.Enabled = false;
                BB_TP_Pesagem.Enabled = false;
                CD_TabelaDesconto.Enabled = false;
                BB_TabelaDesconto.Enabled = false;
       
                Edt_PercentualLocal.Enabled = true;
                Edt_PesoAmostra.Enabled = true;
                Edt_PesoReferencia.Enabled = true;
                BT_Classificacao.Enabled = true;
            }

        }

        private void afterNovo()
        {
            if (tab_Classificacao.SelectedTab == Tab_Consulta)
            {
                tab_Classificacao.SelectedTab = Tab_Classificacao_Superior;
            }

            tpModo = TTpModo.tm_Insert;
            modoBotoes();
            HabilitaCampos();
            Placa.Focus();
            bs_PesagemGraos.AddNew();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_TP_Pesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_TPPesagem|Tipo Pesagem|350;" +
                              "a.TP_Pesagem|TP. Pesagem|100";
            string vParamFixo = "a.TP_Modo|=|'G';" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TPPesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem(), vParamFixo);
            if (linha != null)
                ID_Ticket.Enabled = linha["ST_SeqManual"].ToString().Trim().Equals("S");
        }

        private void TP_Pesagem_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.tp_pesagem|=|'" + TP_Pesagem.Text.Trim() + "';" +
                              "a.TP_Modo|=|'G';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            DataRow retorno = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TPPesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem());
            if (retorno != null)
                ID_Ticket.Enabled = retorno["ST_SeqManual"].ToString().Trim().Equals("S");
        }

        private void Pesagem_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Pesagem|=|'" + Pesagem.Text.Trim() + "';" +
                              "a.TP_Modo|=|'G';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Pesagem, NMTPPesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem());
            
            afterBusca();
        }

        private void BB_Pesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_TPPesagem|Tipo Pesagem|350;" +
                              "a.TP_Pesagem|TP. Pesagem|100";
            string vParamFixo = "a.TP_Modo|=|'G';" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Pesagem, NMTPPesagem },
                                    new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem(), null);

            afterBusca();
        }

        private void BB_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela de Desconto|350;" +
                              "CD_TabelaDesconto|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, DS_TabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto(), null);

            if ((tpModo == TTpModo.tm_Insert) && (CD_TabelaDesconto.Text.Trim() != string.Empty))
            {
                (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                TCN_LanClassificacao.buscarDadosClassif(CD_TabelaDesconto.Text,
                                                        Utils.Parametros.pubLogin);

                BT_Classificacao.Enabled = true;
                bs_Classificacao_PositionChanged(this, new EventArgs());
            }

        }

        private void BB_CDTabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela de Desconto|350;" +
                              "CD_TabelaDesconto|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CDTabelaDesconto, DSTabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto(), null);

            afterBusca();
        }

        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_TabelaDesconto|=|'" + CD_TabelaDesconto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, DS_TabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto());

            if ((tpModo == TTpModo.tm_Insert) && (!string.IsNullOrEmpty(CD_TabelaDesconto.Text.Trim())))
            {
                (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                TCN_LanClassificacao.buscarDadosClassif(CD_TabelaDesconto.Text,
                                                        Utils.Parametros.pubLogin);
                BT_Classificacao.Enabled = true;
                bs_Classificacao_PositionChanged(this, new EventArgs());
            }
        }

        private void CDTabelaDesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_TabelaDesconto|=|'" + CDTabelaDesconto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CDTabelaDesconto, DSTabelaDesconto },
                                    new CamadaDados.Graos.TCD_TabelaDesconto());

            afterBusca();
        }

        private void BB_Moega_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moega|Moega|350;" +
                              "CD_Moega|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMoega(), null);
        }

        private void CD_Moega_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Moega|=|'" + CD_Moega.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMoega());
        }

        private void BB_Placa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.placaCarreta|Placa|80;" +
                      "a.NM_TPPesagem|TP. Pesagem|150;" +
                      "l.DS_TabelaDesconto|Tab. Desconto|150;" +
                      "a.ID_Ticket|Id. Ticket|80;" +          
                      "a.NM_Empresa|Cód. Empresa|150;" +
                      "b.DS_Moega|Cód. Moega|150";                      
            string vParamFixo = "isnull(a.ST_Registro, 'A')|in|('A', 'R');" +//Aberto ou Refugado
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Placa }, new TCD_LanPesagemGraos(),
                                    vParamFixo);

            Placa_Leave(this, e);

        }

        private void BB_Avancar_Click(object sender, EventArgs e)
        {
            if ((bs_Classificacao.Count - 1) >= bs_Classificacao.Position)
            {
                if(Edt_PercentualLocal.Value > 0)
                    if (!TCN_LanClassificacao.ValidaIndiceClassif(CD_TabelaDesconto.Text,
                                                            (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                            Edt_PercentualLocal.Value))
                    {
                        MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + CD_TabelaDesconto.Text.Trim() + ", " +
                                        "amostra " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Edt_PercentualLocal.Value = decimal.Zero;
                        Edt_PercentualLocal.Focus();
                        return;
                    }
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Pc_resultado_local = Edt_PercentualLocal.Value;
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Ps_amostra = Edt_PesoAmostra.Value;
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Ps_referencia = Edt_PesoReferencia.Value;
                bs_Classificacao.ResetCurrentItem();
                string msg = string.Empty;
                if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque > decimal.Zero)
                    if (Edt_PercentualLocal.Value >= (bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque)
                        msg = "Deve ser menor que " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque + ".\r\n";
                if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque > decimal.Zero)
                    if (Edt_PercentualLocal.Value <= (bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque)
                        msg += "Deve ser maior que " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque + ".";
                if (msg.Trim() != string.Empty)
                {
                    //Verificar se o usuario tem permissao para gravar classificacao com indice fora do intervalo previsto
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", null))
                        if (MessageBox.Show("O resultado da amostra <" + (bs_Classificacao.Current as TRegistro_LanClassificacao).Ds_amostra.Trim().ToUpper() + ">.\r\n" + msg.Trim() +
                                           "\r\nDeseja corrigir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            Edt_PercentualLocal.Value = 0;
                        else
                            bs_Classificacao.MoveNext();
                    else
                        bs_Classificacao.MoveNext();
                }
                else
                    bs_Classificacao.MoveNext();
            }
        }

        private void BB_Voltar_Click(object sender, EventArgs e)
        {
            if (bs_Classificacao.Position >= 0)
            {
                if(Edt_PercentualLocal.Value > 0)
                    if (!TCN_LanClassificacao.ValidaIndiceClassif(CD_TabelaDesconto.Text,
                                                            (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                            Edt_PercentualLocal.Value))
                    {
                        MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + CD_TabelaDesconto.Text.Trim() + ", " +
                                        "amostra " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Edt_PercentualLocal.Value = decimal.Zero;
                        Edt_PercentualLocal.Focus();
                        return;
                    }
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Pc_resultado_local = Edt_PercentualLocal.Value;
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Ps_amostra = Edt_PesoAmostra.Value;
                (bs_Classificacao.Current as TRegistro_LanClassificacao).Ps_referencia = Edt_PesoReferencia.Value;
                bs_Classificacao.ResetCurrentItem();
                string msg = string.Empty;
                if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque > decimal.Zero)
                    if (Edt_PercentualLocal.Value >= (bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque)
                        msg = "Deve ser menor que " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Menorque + ".\r\n";
                if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque > decimal.Zero)
                    if (Edt_PercentualLocal.Value <= (bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque)
                        msg += "Deve ser maior que " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Maiorque + ".";
                if (msg.Trim() != string.Empty)
                {
                    //Verificar se o usuario tem permissao para gravar classificacao com indice fora do intervalo previsto
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", null))
                        if (MessageBox.Show("O resultado da amostra <" + (bs_Classificacao.Current as TRegistro_LanClassificacao).Ds_amostra.Trim().ToUpper() + ">.\r\n" + msg.Trim() +
                                           "\r\nDeseja corrigir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            Edt_PercentualLocal.Value = 0;
                        else
                            bs_Classificacao.MovePrevious();
                    else
                        bs_Classificacao.MovePrevious();
                }
                else
                    bs_Classificacao.MovePrevious();
            }
         }
 
        private void Edt_PercentualLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                BB_Avancar_Click(this, new EventArgs());
                if (Edt_PercentualLocal.Enabled)
                    Edt_PercentualLocal.Select(0, Edt_PercentualLocal.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                BB_Voltar_Click(this, new EventArgs());
                if (Edt_PercentualLocal.Enabled)
                    Edt_PercentualLocal.Select(0, Edt_PercentualLocal.Text.Length);
            }
        }

        private void Edt_PesoAmostra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                BB_Avancar_Click(this, new EventArgs());
                if (Edt_PesoAmostra.Enabled)
                    Edt_PesoAmostra.Select(0, Edt_PesoAmostra.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                BB_Voltar_Click(this, new EventArgs());
                if (Edt_PesoAmostra.Enabled)
                    Edt_PesoAmostra.Select(0, Edt_PesoAmostra.Text.Length);
            }
        }

        private void Edt_PesoReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                BB_Avancar_Click(this, new EventArgs());
                if (Edt_PesoReferencia.Enabled)
                    Edt_PesoReferencia.Select(0, Edt_PesoReferencia.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                BB_Voltar_Click(this, new EventArgs());
                if (Edt_PesoReferencia.Enabled)
                    Edt_PesoReferencia.Select(0, Edt_PesoReferencia.Text.Length);
            }
        }

        private void bs_Classificacao_PositionChanged(object sender, EventArgs e)
        {
            if (bs_Classificacao.Current != null)
            {
                if (gClassificacao.Rows == null)
                    return;
                if (gClassificacao.Rows.Count.Equals(0))
                    return;
                if (peso_referencia > 0)
                    (bs_Classificacao.Current as TRegistro_LanClassificacao).Ps_referencia = peso_referencia;
                if ((bs_Classificacao.Current as TRegistro_LanClassificacao).InformarR_P.ToUpper().Trim().Equals("R"))
                {
                    if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Capturapeso.Trim().ToUpper().Equals("S"))
                    {
                        bool st_capturar = true;
                        if (Edt_PercentualLocal.Value > 0)
                            if (!(MessageBox.Show("Ja existe % Desconto capturado. Deseja capturar novo percentual?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes))
                                st_capturar = false;
                        Edt_PercentualLocal.Enabled = false;
                        if (st_capturar)
                        {
                            TFLeituraSerial fSerial = new TFLeituraSerial();
                            try
                            {
                                fSerial.Cd_protocolo = (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_protocolopeso;
                                fSerial.ds_valor = "% Local:";
                                fSerial.ds_amostra = (bs_Classificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    Edt_PercentualLocal.Value = fSerial.vl_capturado;
                                    BB_Avancar_Click(this, new EventArgs());
                                    gClassificacao.Refresh();
                                }
                            }
                            finally
                            {
                                fSerial.Dispose();
                            }
                        }
                    }
                    else
                        Edt_PercentualLocal.Enabled = true;
                    Edt_PesoAmostra.Enabled = false;
                    Edt_PesoReferencia.Enabled = false;
                    Edt_PercentualLocal.Focus();
                }
                else if ((bs_Classificacao.Current as TRegistro_LanClassificacao).InformarR_P.ToUpper().Trim().Equals("P"))
                {
                    //Peso Referencia
                    if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Capturareferencia.Trim().ToUpper().Equals("S"))
                    {
                        bool st_capturar = true;
                        if (Edt_PesoReferencia.Value > 0)
                            if (!(MessageBox.Show("Ja existe peso referencia capturado. Deseja capturar novo peso referencia?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes))
                                st_capturar = false;
                        Edt_PesoReferencia.Enabled = false;
                        if (st_capturar)
                        {
                            TFLeituraSerial fSerial = new TFLeituraSerial();
                            try
                            {
                                fSerial.Cd_protocolo = (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_protocoloreferencia;
                                fSerial.ds_valor = "Peso Referência:";
                                fSerial.ds_amostra = (bs_Classificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    Edt_PesoReferencia.Value = fSerial.vl_capturado;
                                    peso_referencia = Edt_PesoReferencia.Value;
                                }
                                gClassificacao.Refresh();
                            }
                            finally
                            {
                                fSerial.Dispose();
                            }
                        }
                    }
                    else
                        Edt_PesoReferencia.Enabled = true;
                    //Peso Amostra
                    if ((bs_Classificacao.Current as TRegistro_LanClassificacao).Capturapeso.Trim().ToUpper().Equals("S"))
                    {
                        bool st_capturar = true;
                        if (Edt_PesoAmostra.Value > 0)
                            if (!(MessageBox.Show("Ja existe peso amostra capturado. Deseja capturar novo peso amostra?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes))
                                st_capturar = false;
                        if (st_capturar)
                        {
                            TFLeituraSerial fSerial = new TFLeituraSerial();
                            try
                            {
                                fSerial.Cd_protocolo = (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_protocolopeso;
                                fSerial.ds_valor = "Peso Amostra:";
                                fSerial.ds_amostra = (bs_Classificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    Edt_PesoAmostra.Value = fSerial.vl_capturado;
                                    BB_Avancar_Click(this, new EventArgs());
                                    gClassificacao.Refresh();
                                }
                            }
                            finally
                            {
                                fSerial.Dispose();
                            }
                        }
                    }
                    else
                        Edt_PesoAmostra.Enabled = true;

                    Edt_PercentualLocal.Enabled = false;
                    Edt_PesoAmostra.Focus();
                }
            }
        }

        private void afterGrava()
        {
            if (tab_Classificacao.SelectedTab == Tab_Consulta)
                tab_Classificacao.SelectedTab = Tab_Classificacao_Superior;

            if (ValidaCampos())
            {
                try
                {
                    (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento = "E";
                    TCN_LanPesagemGraos.Gravar((bs_PesagemGraos.Current as TRegistro_LanPesagemGraos), null);
                    if ((bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("R"))
                        MessageBox.Show("Pesagem Refugada por conter classificação fora dos padrões aceitaveis.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Classificação processada com Sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimparFiltros();
                    Nr_Ticket.Text = (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString();
                    this.afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO processar Classificação: " + ex.Message);
                }
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void Placa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Placa.Text))
            {
                TList_RegLanPesagemGraos ListaPlaca = TCN_LanPesagemGraos.Busca(string.Empty, 
                                                                                string.Empty, 
                                                                                string.Empty, 
                                                                                Placa.Text, "'A', 'R'", 
                                                                                string.Empty, 
                                                                                Utils.Parametros.pubLogin, 
                                                                                string.Empty, 
                                                                                0,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1, 
                                                                                string.Empty, 
                                                                                null);

                if (ListaPlaca.Count > 0)
                {
                    //Buscar Classificacao
                    ListaPlaca[0].Classificacao = TCN_LanClassificacao.Buscar(ListaPlaca[0].Cd_empresa,
                                                                              ListaPlaca[0].Id_ticket.ToString(),
                                                                              ListaPlaca[0].Tp_pesagem,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              null);
                    bs_PesagemGraos.DataSource = ListaPlaca;
                    tpModo = TTpModo.tm_Edit;
                    HabilitaCampos();
                    CD_TabelaDesconto_Leave(this, e);
                }
            }
        }

        private void afterCancela()
        {
            bs_Classificacao.Clear();
            bs_PesagemGraos.Clear();
            bs_Classificacao.Clear();
            tpModo = TTpModo.tm_Standby;
            modoBotoes();
            HabilitaCampos();
        }

        private void afterRefuga()
        {
            if (tab_Classificacao.SelectedTab == Tab_Consulta)
                tab_Classificacao.SelectedTab = Tab_Classificacao_Superior;
            if (ValidaCampos())
            {
                try
                {
                    if (MessageBox.Show("Confirma Refugo da Pesagem?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                         (bs_PesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro = "R";
                         TCN_LanPesagemGraos.Gravar((bs_PesagemGraos.Current as TRegistro_LanPesagemGraos), null);
                        MessageBox.Show("Pesagem refugada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterCancela();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro refugar pesagem: " + ex.Message); }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private bool ValidaCampos()
        {
            bool Retorno = true;
            string Mensagem = "Os seguintes campos necessitam de verificação: \r\n";
            
            if (CD_TabelaDesconto.Text.Trim() == "")
            {
                Mensagem += "\r\n" + "          - O campo Classificação é Obrigatório";
                CD_TabelaDesconto.Focus();
                Retorno = false;
            }

            if (TP_Pesagem.Text.Trim() == "")
            {
                Mensagem += "\r\n" + "          - O campo Pesagem é Obrigatório";
                TP_Pesagem.Focus();
                Retorno = false;
            }

            if (CD_Empresa.Text.Trim() == "")
            {
                Mensagem += "\r\n" + "          - O campo Empresa é Obrigatório";
                CD_Empresa.Focus();
                Retorno = false;
            }

            if (Placa.Text.Trim() == "")
            {
                Mensagem += "\r\n" + "          - O campo Placa é Obrigatório ";
                Placa.Focus();
                Retorno = false;
            }

            if (Mensagem != "Os seguintes campos necessitam de verificação: \r\n")
            {
               MessageBox.Show(Mensagem, "Mensagem",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return Retorno;
        }

        private void TFCla_Cereais_Origem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible.Equals(true))
                    afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible.Equals(true))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible.Equals(true))
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Refugar.Visible.Equals(true))
                afterRefuga();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible.Equals(true))
                afterBusca();
        }

        private void LimparFiltros()
        {
            Nr_Ticket.Clear();
            CDPLaca.Clear();
            CDEmpresa.Clear();
            NMEmpresa.Clear();
            Pesagem.Clear();
            NMTPPesagem.Clear();
            CDTabelaDesconto.Clear();
            DSTabelaDesconto.Clear();
        }

        private void afterBusca()
        {
            if (tab_Classificacao.SelectedTab == Tab_Consulta)
                Busca();
            else
            {
                afterCancela();
                tab_Classificacao.SelectedTab = Tab_Consulta;
                Busca();
                Nr_Ticket.Focus();
            }
        }

        private void Busca()
        {
            bs_PesagemGraos.DataSource = TCN_LanPesagemGraos.Busca(CDEmpresa.Text, 
                                                                   Nr_Ticket.Text, 
                                                                   Pesagem.Text, 
                                                                   CDPLaca.Text, 
                                                                   "'A', 'R'", 
                                                                   CDTabelaDesconto.Text, 
                                                                   Utils.Parametros.pubLogin, 
                                                                   string.Empty, 
                                                                   0, 
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   0, 
                                                                   string.Empty, 
                                                                   null);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void CDEmpresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CDEmpresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CDEmpresa, NMEmpresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            afterBusca();
        }

        private void BBEmpresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CDEmpresa, NMEmpresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
            afterBusca();
        }

        private void Nr_Ticket_Leave(object sender, EventArgs e)
        {
            afterBusca();
        }
        
        private void BB_Refugar_Click(object sender, EventArgs e)
        {
            afterRefuga();
        }

        private void CDPLaca_Leave(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void Tab_Classificacao_Superior_Enter(object sender, EventArgs e)
        {
            if (Tab_Consulta.Focus() == true)
                afterCancela();
        }

        private void label20_TextChanged(object sender, EventArgs e)
        {
            if (label20.Text.Trim().ToUpper().Equals("ABERTO"))
                label20.ForeColor = Color.Blue;
            else if (label20.Text.Trim().ToUpper().Equals("REFUGADO"))
                label20.ForeColor = Color.Red;
        }

        private void Edt_PercentualLocal_Leave(object sender, EventArgs e)
        {
            if(Edt_PercentualLocal.Value > 0)
                if (!TCN_LanClassificacao.ValidaIndiceClassif(CD_TabelaDesconto.Text,
                                                            (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                            Edt_PercentualLocal.Value))
                {
                    MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + CD_TabelaDesconto.Text.Trim() + ", " +
                                    "amostra " + (bs_Classificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Edt_PercentualLocal.Value = decimal.Zero;
                    Edt_PercentualLocal.Focus();
                }
        }

        private void gClassificacao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gClassificacao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bs_Classificacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanClassificacao());
            TList_RegLanClassificacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gClassificacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gClassificacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanClassificacao(lP.Find(gClassificacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gClassificacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanClassificacao(lP.Find(gClassificacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gClassificacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bs_Classificacao.List as TList_RegLanClassificacao).Sort(lComparer);
            bs_Classificacao.ResetBindings(false);
            gClassificacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gConsulta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gConsulta.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bs_PesagemGraos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemGraos());
            TList_RegLanPesagemGraos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gConsulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gConsulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gConsulta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gConsulta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gConsulta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gConsulta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bs_PesagemGraos.List as TList_RegLanPesagemGraos).Sort(lComparer);
            bs_PesagemGraos.ResetBindings(false);
            gConsulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
