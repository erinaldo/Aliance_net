using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Adiantamento;
using Utils;
using FormBusca;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Diversos;
using System.IO;

namespace Financeiro
{
    
    public partial class TFConsulta_Adiantamento : Form
    {
        public bool Altera_Relatorio = false;

        public TFConsulta_Adiantamento()
        {
            InitializeComponent();
           
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using (TFLan_Adiantamento Lan_Adiantamento = new TFLan_Adiantamento())
            {
                Lan_Adiantamento.BS_Adiantamento.AddNew();

                (Lan_Adiantamento.BS_Adiantamento.Current as TRegistro_LanAdiantamento).TP_Lancto = "F";

                if (Lan_Adiantamento.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        TCN_LanAdiantamento.Gravar((Lan_Adiantamento.BS_Adiantamento.Current as TRegistro_LanAdiantamento), null);
                        LimpaCampos();
                        id_adto.Text = (Lan_Adiantamento.BS_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString();
                        Busca(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                else
                    Lan_Adiantamento.BS_Adiantamento.CancelEdit();
            }
        }

        private void TotalizarAdto(TList_LanAdiantamento lista)
        {
            tot_adiantamento.Value = lista.Where(p=> p.ST_ADTO.Trim().ToUpper() != "C").Sum(p => p.Vl_adto);
            tot_quitado.Value = lista.Where(p=> p.ST_ADTO.Trim().ToUpper() != "C").Sum(p => p.VL_total_quitado);
            tot_saldoquitar.Value = lista.Where(p=> p.ST_ADTO.Trim().ToUpper() != "C").Sum(p => p.Vl_saldo_quitacao);
            tot_saldodevolver.Value = lista.Where(p=> p.ST_ADTO.Trim().ToUpper() != "C").Sum(p => p.Vl_total_devolver);
            tot_devolver_programado.Value = lista.Where(p => p.Dt_prevdevolucao != null && p.ST_ADTO.Trim().ToUpper() != "C").Sum(p => p.Vl_total_devolver);
        }

        private void Busca(int Aba)
        {
            string Tp_lancto = string.Empty;
            string virg = string.Empty;
            if (cck_Frota.Checked)
            {
                Tp_lancto = "'R'";
                virg = ",";
            }
            if (cck_Financeiro.Checked)
            {
                Tp_lancto += virg + "'F'";
                virg = ",";
            }
            if (cck_Pedido.Checked)
            {
                Tp_lancto += virg + "'P'";
                virg = ",";
            }

            string Tp_movimento = string.Empty;
            virg = string.Empty;
            if (cbRecebido.Checked)
            {
                Tp_movimento = "'R'";
                virg = ",";
            }
            if (cbConcedido.Checked)
                Tp_movimento += virg + "'C'";
            
            TList_LanAdiantamento lista = TCN_LanAdiantamento.Buscar(id_adto.Text, 
                                                                     CD_Empresa.Text, 
                                                                     cd_clifor.Text, 
                                                                     DS_Adiantamento.Text,
                                                                     Tp_movimento, 
                                                                     string.Empty, 
                                                                     0, 
                                                                     DT_Inicial.Text, 
                                                                     DT_Final.Text, 
                                                                     VL_Inicial.Value,
                                                                     VL_Final.Value,
                                                                     cck_Encerrado.Checked, 
                                                                     cck_Aberto.Checked, 
                                                                     cck_Fechado.Checked, 
                                                                     Tp_lancto,
                                                                     cck_Cancelado.Checked, 
                                                                     false,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     0, 
                                                                     string.Empty, 
                                                                     null);
            if ((lista != null) && (lista.Count > 0))
            {
                this.TotalizarAdto(lista);
                bsAdiantamento.DataSource = lista;
                BS_Consulta_Adiantamento_PositionChanged(this, new EventArgs());
            }
            else
                bsAdiantamento.Clear();
            TC_Consulta_Adiantamento.SelectedIndex = Aba;
        }

        private void LimpaCampos()
        {
            DT_Inicial.Clear();
            DT_Final.Clear();
            id_adto.Clear();
            CD_Empresa.Clear();
            NM_Empresa.Clear();
            cd_clifor.Clear();
            nm_clifor.Clear();
            DS_Adiantamento.Clear();
            cck_Aberto.Checked = false;
            cck_Cancelado.Checked = false;
            cck_Encerrado.Checked = false;
            cck_Fechado.Checked = false;
            cck_Financeiro.Checked = false;
            cck_Frota.Checked = false;
            cck_Pedido.Checked = false;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca(0);
        }
               
        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsAdiantamento.Current != null)
                if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).ST_ADTO != "C")
                {
                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao > 0)
                    {
                        TList_ConfigAdto Lista_CFG = TCN_CadConfigAdto.Buscar((bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              null);
                        if (Lista_CFG.Count > 0)
                        {
                            bool st_cheque = false;
                            st_cheque = MessageBox.Show("Quitar adiantamento concedido utilizando cheque?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes;
                            if (st_cheque)
                            {
                                (bsAdiantamento.Current as TRegistro_LanAdiantamento).lCheques.Clear();
                                while (st_cheque)
                                {
                                    using (TFLanTitulo LanctoTitulo = new TFLanTitulo())
                                    {
                                        LanctoTitulo.BS_Titulo.AddNew();
                                        LanctoTitulo.pVl_saldo = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao -
                                                                 (bsAdiantamento.Current as TRegistro_LanAdiantamento).lCheques.Sum(p => p.Vl_titulo);
                                        LanctoTitulo.St_bloquearTroco = true;
                                        LanctoTitulo.Tp_titulo = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Tp_movimento.Trim().ToUpper().Equals("C") ? "P" : "R";
                                        LanctoTitulo.tp_titulo.Enabled = false;
                                        LanctoTitulo.Cd_empresa = Lista_CFG[0].Cd_empresa;
                                        LanctoTitulo.Cd_clifor = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_clifor;
                                        LanctoTitulo.cd_clifor_nominal.Text = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_clifor;
                                        LanctoTitulo.nm_clifor_nominal.Text = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Nm_clifor;
                                        if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Tp_movimento == "C")
                                        {
                                            LanctoTitulo.Cd_historico = Lista_CFG[0].Cd_historico_ADTO_C;
                                            LanctoTitulo.Ds_historico = Lista_CFG[0].Ds_historico_ADTO_C;
                                        }
                                        else
                                        {
                                            LanctoTitulo.Cd_historico = Lista_CFG[0].Cd_historico_ADTO_R;
                                            LanctoTitulo.Ds_historico = Lista_CFG[0].Ds_historico_ADTO_R;
                                        }
                                        LanctoTitulo.Observacao = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Ds_adto;
                                        LanctoTitulo.CD_Empresa.Enabled = false;
                                        LanctoTitulo.BB_Empresa.Enabled = false;
                                        LanctoTitulo.CD_Clifor.Enabled = false;
                                        LanctoTitulo.BB_Clifor.Enabled = false;
                                        LanctoTitulo.NM_Clifor.Enabled = false;
                                        if (LanctoTitulo.ShowDialog() == DialogResult.OK)
                                        {
                                            if (LanctoTitulo.BS_Titulo.Current != null)
                                                (bsAdiantamento.Current as TRegistro_LanAdiantamento).lCheques.Add(
                                                    (LanctoTitulo.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo));
                                            if (((bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao -
                                                                 (bsAdiantamento.Current as TRegistro_LanAdiantamento).lCheques.Sum(p => p.Vl_titulo)) == 0)
                                                st_cheque = false;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar cheques para quitar adiantamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                try
                                {
                                    TCN_LanAdiantamentoXCaixa.Quitar_AdiantamentoCheque(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                                    MessageBox.Show("Adiantamento quitado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimpaCampos();
                                    id_adto.Text = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString();
                                    Busca(1);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro quitar adiantamento: " + ex.Message);
                                }
                            }
                            else
                            {
                                using (TFLanCaixa Lan_Caixa = new TFLanCaixa())
                                {
                                    Lan_Caixa.dsLanCaixa.Clear();
                                    Lan_Caixa.dsLanCaixa.DataSource = (bsAdiantamento.Current as TRegistro_LanAdiantamento).List_Caixa;
                                    Lan_Caixa.dsLanCaixa.AddNew();

                                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Tp_movimento == "C")
                                    {
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_Historico = Lista_CFG[0].Cd_historico_ADTO_C;
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Ds_historico = Lista_CFG[0].Ds_historico_ADTO_C;
                                    }
                                    else
                                    {
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_Historico = Lista_CFG[0].Cd_historico_ADTO_R;
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Ds_historico = Lista_CFG[0].Ds_historico_ADTO_R;
                                    }


                                    (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_Empresa = Lista_CFG[0].Cd_empresa;
                                    (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Nm_empresa = Lista_CFG[0].Nm_empresa;

                                    (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).ComplHistorico = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Ds_adto;

                                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Tp_movimento == "C")
                                    {
                                        Lan_Caixa.RB_Pagar.Checked = true;
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao;
                                        Lan_Caixa.VL_Pagar.Maximum = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao;

                                    }
                                    else
                                    {
                                        Lan_Caixa.RB_Receber.Checked = true;
                                        (Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao;
                                        Lan_Caixa.VL_Receber.Maximum = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao;

                                    }

                                    Lan_Caixa.RB_Receber.Enabled = false;
                                    Lan_Caixa.RB_Pagar.Enabled = false;
                                    Lan_Caixa.CD_Empresa.Enabled = false;
                                    Lan_Caixa.CD_Historico.Enabled = false;
                                    Lan_Caixa.BB_Empresa.Enabled = false;
                                    Lan_Caixa.BB_Historico.Enabled = false;

                                    if (Lan_Caixa.ShowDialog() == DialogResult.OK)
                                    {

                                        if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Tp_movimento == "C")
                                        {
                                            if ((Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR <= (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao)
                                            {
                                                try
                                                {
                                                    TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                                                    LimpaCampos();
                                                    //  id_adto.Text = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString();
                                                    //  Busca(0);
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show("Erro: " + ex.Message); }

                                            }
                                            else
                                                MessageBox.Show("O Valor do Lançamento não corresponde ao saldo disponível para Quitar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                                        }
                                        else
                                        {
                                            if ((Lan_Caixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER <= (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao)
                                            {
                                                try
                                                {
                                                    TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                                                    LimpaCampos();
                                                    id_adto.Text = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString();
                                                    Busca(0);
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show("Erro: " + ex.Message); }

                                            }
                                            else
                                                MessageBox.Show("O Valor do Lançamento não corresponde ao saldo disponível para Quitar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                        }
                                    }
                                    else
                                        Lan_Caixa.dsLanCaixa.CancelEdit();
                                };
                            }
                        }
                        else
                            MessageBox.Show("Não existe configuração de adiantamento para a empresa " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa.Trim() + "\r\n" +
                                                        "Localize a tela de cadastro de configuração de adiantamento no menu do sistema e efetue o cadastro.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void TFConsulta_Adiantamento_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 113) && (BB_Novo.Visible))
                this.BB_Novo_Click(sender, e);
            else if ((e.KeyValue == 114) && (BB_Alterar.Visible))
                this.BB_Alterar_Click(sender, e);
            else if ((e.KeyValue == 115) && (BB_DEVOLVER.Visible))
                this.BB_DEVOLVER_Click(sender, e);
            else if ((e.KeyValue == 116) && (BB_Excluir.Visible))
                this.BB_Excluir_Click(sender, e);
            else if ((e.KeyValue == 118) && (BB_Buscar.Visible))
                this.BB_Buscar_Click(sender, e);
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
           if (bsAdiantamento.Count > 0)
           {
                if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).ST_ADTO != "C")
                {
                    if (MessageBox.Show("Deseja Cancelar o Adiantamento?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanAdiantamento.Excluir(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                            LimpaCampos();
                            Busca(0);
                        }
                        catch(Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message); }
                    }
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                                          "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), "");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, String.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                    new TCD_CadClifor());
        }
        
        private void cck_Encerrado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Encerrado.Checked == true)
            {
                cck_Aberto.Checked = false;
                cck_Fechado.Checked = false;
            }
        }

        private void cck_Aberto_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Aberto.Checked == true)
            {
                cck_Fechado.Checked = false;
                cck_Encerrado.Checked = false;
                cck_Cancelado.Checked = false;
            }
        }

        private void cck_Fechado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Fechado.Checked == true)
            {
                cck_Aberto.Checked = false;
                cck_Encerrado.Checked = false;
            }
        }

        private void cck_Listar_Estornos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsAdiantamento.Current != null)
            {
                (bsAdiantamento.Current as TRegistro_LanAdiantamento).List_Caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               0,
                                                                                                                                               0,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               true,
                                                                                                                                               string.Empty,
                                                                                                                                               (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto,
                                                                                                                                               false,
                                                                                                                                               null);
                bsAdiantamento.ResetCurrentItem();
            }
        }

        private void BB_DEVOLVER_Click(object sender, EventArgs e)
        {
            if (bsAdiantamento.Current != null)
            {
                if (new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                            "where x.Id_Adto = a.Id_Adto " +
                                            "and x.Id_adto = " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ") "
                            }
                        }, "1") == null)
                {
                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).ST_ADTO.Trim().ToUpper() != "C")
                    {
                        if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_total_devolver > 0)
                            using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                            {
                                fValor.Casas_decimais = 2;
                                fValor.Vl_saldo = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_total_devolver;
                                fValor.Vl_default = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_total_devolver;
                                fValor.Ds_label = "Valor Devolver";
                                if (fValor.ShowDialog() == DialogResult.OK)
                                    try
                                    {
                                        //Escolher em qual conta gerencial devolver
                                        Componentes.EditDefault cd = new Componentes.EditDefault();
                                        cd.NM_Campo = "cd_contager";
                                        cd.NM_CampoBusca = "cd_contager";
                                        string vColunas = "a.ds_contager|Conta|350;" +
                                        "a.CD_ContaGer|Cód. Conta|100;" +
                                        "a.vl_limite|Vl. LIS|80;" +
                                        "a.PC_JuroLimite|% Juro LIS|80";

                                        string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                                       "where x.cd_contager = a.cd_contager " +
                                                       "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
                                        if (!string.IsNullOrEmpty((bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa))
                                            vCond = "|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa.Trim() + "' )|";

                                        DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
                                        if (linha != null)
                                            (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_contagerDev = linha["cd_contager"].ToString();
                                        else
                                        {
                                            MessageBox.Show("Obrigatório informar conta gerencial!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_devolver = fValor.Quantidade;
                                        TCN_LanAdiantamento.DevolverAdto(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                                        MessageBox.Show("Adiantamento devolvido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.LimpaCampos();
                                        this.Busca(0);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }

                        else
                            MessageBox.Show("Não existe saldo para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Não é permitido fazer devolução de adiantamento cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Não é permitido fazer devolução de adiantamento de origem locação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Necessario selecionar adiantamento para gerar devolução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFConsulta_Adiantamento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            Utils.ShapeGrid.RestoreShape(this, g_Consulta);
            Utils.ShapeGrid.RestoreShape(this, g_Lancamento_Caixa);
            Utils.ShapeGrid.RestoreShape(this, dG_Titulo);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Consulta.set_FormatZero();
            g_Lancamento_Caixa.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Lancamento_Caixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Consulta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Consulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void ImprimirRelatorio()
        {
            if (bsAdiantamento.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsAdiantamento;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Ident = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + this.Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void ImprimirExtrato()
        {
            if (bsAdiantamento.Current != null)
            {
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
                if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                {
                    object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                    {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                    }
                                                    }, "porta_imptick");
                    if (porta != null)
                        if (!string.IsNullOrEmpty(porta.ToString()))
                        {
                            FileInfo f = null;
                            StreamWriter w = null;
                            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "CreditoAvulso.txt");
                            w = f.CreateText();
                            try
                            {
                                w.WriteLine(" =========================================");
                                w.WriteLine("              EXTRATO ADTO             ");
                                w.WriteLine(" =========================================");
                                w.WriteLine(" Nº Credito: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString());
                                w.WriteLine(" Cliente: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_clifor.Trim() + "-" + 
                                    (bsAdiantamento.Current as TRegistro_LanAdiantamento).Nm_clifor.Trim().ToUpper());
                                w.WriteLine(" Data: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Dt_lanctostring);
                                w.WriteLine(" Valor: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                w.WriteLine(" Saldo a Devolver: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                w.WriteLine(" Obs: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Ds_adto);

                                w.Write(Convert.ToChar(12));
                                w.Write(Convert.ToChar(27));
                                w.Write(Convert.ToChar(109));
                                w.Flush();
                                f.CopyTo(porta.ToString());
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro impressão Extrato Credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            finally
                            {
                                w.Dispose();
                                f = null;
                            }
                        }
                }
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("G")))
                {
                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).ST_ADTO.Trim().ToUpper() != "C")
                    {
                        if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_total_devolver > decimal.Zero)
                        {
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                Rel.Altera_Relatorio = Altera_Relatorio;
                                BindingSource bs = new BindingSource();
                                bs.DataSource = new TList_LanAdiantamento() { bsAdiantamento.Current as TRegistro_LanAdiantamento };
                                Rel.DTS_Relatorio = bs;
                                Rel.Nome_Relatorio = "FRel_Extrato_Adiantamento";
                                Rel.NM_Classe = this.Name;
                                Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                                Rel.Ident = "FRel_Extrato_Adiantamento";
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = string.Empty;
                                fImp.pMensagem = "RELATORIO EXTRATO ADIANTAMENTO";

                                if (Altera_Relatorio)
                                {
                                    Rel.Gera_Relatorio(string.Empty,
                                                       fImp.pSt_imprimir,
                                                       fImp.pSt_visualizar,
                                                       fImp.pSt_enviaremail,
                                                       fImp.pSt_exportPdf,
                                                       fImp.Path_exportPdf,
                                                       fImp.pDestinatarios,
                                                       null,
                                                       "RELATORIO EXTRATO ADIANTAMENTO",
                                                       fImp.pDs_mensagem);
                                    Altera_Relatorio = false;
                                }
                                else
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Rel.Gera_Relatorio(string.Empty,
                                                       fImp.pSt_imprimir,
                                                       fImp.pSt_visualizar,
                                                       fImp.pSt_enviaremail,
                                                       fImp.pSt_exportPdf,
                                                       fImp.Path_exportPdf,
                                                       fImp.pDestinatarios,
                                                       null,
                                                       "RELATORIO EXTRATO ADIANTAMENTO",
                                                       fImp.pDs_mensagem);
                            }
                        }
                        else
                            MessageBox.Show("Adiantamento não possui saldo para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                {
                    List<string> Texto = new List<string>();
                    Texto.Add("                EXTRATO CREDITO                 ");
                    Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Id_adto.ToString());
                    Texto.Add(" Cliente: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_clifor.Trim() + "-" +
                                    (bsAdiantamento.Current as TRegistro_LanAdiantamento).Nm_clifor.Trim().ToUpper());
                    Texto.Add("Data: ".FormatStringDireita(38, ' ') + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_lanctostring);
                    Texto.Add("Valor: ".FormatStringDireita(38, ' ') + 
                        (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                    Texto.Add(" Saldo a Devolver: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                    Texto.Add(" Obs: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Ds_adto);

                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_CredAvulso";
                    Relatorio.NM_Classe = "TFLanVendaRapida_CredAvulso";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_CredAvulso";
                    Relatorio.Altera_Relatorio = this.Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);

                    string text = string.Join(Environment.NewLine, Texto.ToArray());
                    Relatorio.Parametros_Relatorio.Add("TEXTO", text);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    //Verificar se existe Impressora padrão para o PDV
                    object objIMP = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.impressorapadrao");
                    string print = string.Empty;
                    print = objIMP == null ? string.Empty : objIMP.ToString();
                    if (string.IsNullOrEmpty(print))
                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                        {
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                    print = fLista.Impressora;

                        }
                    //Imprimir
                    if (!string.IsNullOrEmpty(print))
                        Relatorio.ImprimiGraficoReduzida(print,
                                                         true,
                                                         false,
                                                         null,
                                                         string.Empty,
                                                         string.Empty,
                                                         1);
                    this.Altera_Relatorio = false;
                }
            }
        }

        private void ImprimirRecibo()
        {
            if (bsAdiantamento.Current != null)
            {
                if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Status.ToUpper().Equals("ABERTO"))
                {
                    MessageBox.Show("O Adiantamento Nº " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString().Trim() + " não está QUITADO!");
                    return;
                }
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                              new Utils.TpBusca[]
                                                               {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                               }, "a.tp_imporcamento");
                if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                {
                    List<string> Texto = new List<string>();
                    Texto.Add("                EXTRATO CREDITO                 ");
                    Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Id_adto.ToString());
                    Texto.Add("Data: ".FormatStringDireita(38, ' ') + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_lanctostring);
                    Texto.Add("Valor: ".FormatStringDireita(38, ' ') + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_CredAvulso";
                    Relatorio.NM_Classe = "TFLanVendaRapida_CredAvulso";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_CredAvulso";
                    Relatorio.Altera_Relatorio = this.Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);

                    string text = string.Join(Environment.NewLine, Texto.ToArray());
                    Relatorio.Parametros_Relatorio.Add("TEXTO", text);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    //Verificar se existe Impressora padrão para o PDV
                    object objIMP = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                    {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                    }, "a.impressorapadrao");
                    string print = string.Empty;
                    print = objIMP == null ? string.Empty : objIMP.ToString();
                    if (string.IsNullOrEmpty(print))
                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                        {
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                    print = fLista.Impressora;

                        }
                    //Imprimir
                    if (!string.IsNullOrEmpty(print))
                        Relatorio.ImprimiGraficoReduzida(print,
                                                         true,
                                                         false,
                                                         null,
                                                         string.Empty,
                                                         string.Empty,
                                                         1);
                    this.Altera_Relatorio = false;
                }
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("G")))
                {
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        //Preencher dados empresa da duplicata
                        BindingSource Empresa = new BindingSource();
                        Empresa.DataSource = TCN_CadEmpresa.Busca((bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_empresa, string.Empty, string.Empty, null);
                        decimal valor = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_adto;
                        string Valor_Extenso = string.Empty;
                        string transf = string.Empty;
                        //Buscar Moeda da Conta Gerencial
                        TList_Moeda lMoeda =
                            new TCD_Moeda().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_contager x "+
                                                "where x.cd_moeda = a.cd_moeda "+
                                                "and x.cd_contager = '" + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_contager_qt.Trim() + "')"
                                }
                            }, 1, string.Empty);
                        if (lMoeda.Count > 0)
                            Valor_Extenso = new Extenso().ValorExtenso(valor, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
                        else
                            Valor_Extenso = new Extenso().ValorExtenso(valor, "Real", "Reais");
                        //Criar objeto Relatório
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource Bin = new BindingSource();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Bin.DataSource = new TList_LanAdiantamento() { bsAdiantamento.Current as TRegistro_LanAdiantamento };
                        Rel.DTS_Relatorio = Bin;
                        Rel.Nome_Relatorio = "TFConsulaAdiant_Recibo";
                        Rel.NM_Classe = this.Name;
                        Rel.Ident = "TFConsulaAdiant_Recibo";
                        Rel.Modulo = "FIN";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        BindingSource moeda = new BindingSource();
                        moeda.DataSource = lMoeda[0];
                        Rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso);
                        Rel.Parametros_Relatorio.Add("VALOR", valor);
                        Rel.Adiciona_DataSource("MOEDA", moeda);
                        if (Empresa.Count > 0)
                            if ((Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        Rel.Adiciona_DataSource("EMPRESA", Empresa);
                        fImp.pMensagem = "RECIBO DE ADIANTAMENTO CAIXA";

                        if (Altera_Relatorio)
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RECIBO DE ADIANTAMENTO CAIXA",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                        }
                        else
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RECIBO DE ADIANTAMENTO CAIXA",
                                               fImp.pDs_mensagem);
                    }
                }
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                {
                    object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                        new TpBusca[]
                                                    {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                    }
                                                    }, "porta_imptick");
                    if (porta != null)
                        if (!string.IsNullOrEmpty(porta.ToString()))
                        {
                            FileInfo f = null;
                            StreamWriter w = null;
                            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "CreditoAvulso.txt");
                            w = f.CreateText();
                            try
                            {
                                w.WriteLine(" =========================================");
                                w.WriteLine("              EXTRATO CREDITO             ");
                                w.WriteLine(" =========================================");
                                w.WriteLine(" Nº Credito: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString());
                                w.WriteLine(" Cliente: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Cd_clifor.Trim() + "-" +
                                    (bsAdiantamento.Current as TRegistro_LanAdiantamento).Nm_clifor.Trim().ToUpper());
                                w.WriteLine(" Data: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Dt_lanctostring);
                                w.WriteLine(" Valor: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                w.WriteLine(" Obs: " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Ds_adto);

                                w.Write(Convert.ToChar(12));
                                w.Write(Convert.ToChar(27));
                                w.Write(Convert.ToChar(109));
                                w.Flush();
                                f.CopyTo(porta.ToString());
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro impressão Extrato Credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            finally
                            {
                                w.Dispose();
                                f = null;
                            }
                        }
                }
            }
        }
        
        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio();
        }

        private void g_Consulta_DoubleClick(object sender, EventArgs e)
        {
            if (bsAdiantamento.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.BS_Consulta_Adiantamento.Add(this.bsAdiantamento.Current as TRegistro_LanAdiantamento);
                    fRastrear.TRastrear = TP_Rastrear.tm_adiantamento;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void cck_Cancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (cck_Cancelado.Checked)
                cck_Aberto.Checked = false;
        }

        private void TC_Consulta_Adiantamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TC_Consulta_Adiantamento.SelectedTab.Equals(tp_Lancamento_Caixa))
                BS_Lancamento_Caixa_PositionChanged(this, new EventArgs());
        }

        private void g_Consulta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ABERTO"))
                    {
                        DataGridViewRow linha = g_Consulta.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("QUITADO"))
                    {
                        DataGridViewRow linha = g_Consulta.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Teal;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = g_Consulta.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                    {
                        DataGridViewRow linha = g_Consulta.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
        }

        private void g_Lancamento_Caixa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("SIM"))
                    {
                        DataGridViewRow linha = g_Lancamento_Caixa.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = g_Lancamento_Caixa.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BS_Lancamento_Caixa_PositionChanged(object sender, EventArgs e)
        {
            if (bsCaixa.Current != null && TC_Consulta_Adiantamento.SelectedTab.Equals(tp_Lancamento_Caixa))
            {
                bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_liquidacao x "+
                                        "inner join tb_fin_liquidacao_x_adto_caixa y "+
                                        "on x.cd_empresa = y.cd_empresa "+
                                        "and x.nr_lancto = y.nr_lancto "+
                                        "and x.cd_parcela = y.cd_parcela "+
                                        "and x.id_liquid = y.id_liquid "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lancto = a.nr_lancto "+
                                        "and x.cd_parcela = a.cd_parcela "+
                                        "and y.id_adto = " + (bsAdiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Id_adto.ToString() + " " +
                                        "and y.cd_lanctocaixa = " + (bsCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + " " +
                                        "and y.cd_contager = '" + (bsCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_ContaGer.Trim() + "')"
                        }
                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            }
        }

        private void gParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Nr_lancto.Value.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_parcela",
                                vOperador = "=",
                                vVL_Busca = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_parcela.Value.ToString()
                            }
                        }, 1, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    fRastrear.TRastrear = TP_Rastrear.tm_parcela;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void BS_Consulta_Adiantamento_PositionChanged(object sender, EventArgs e)
        {
            if(bsAdiantamento.Current != null)
            {
                //Buscar Caixa Adiantamento
                (bsAdiantamento.Current as TRegistro_LanAdiantamento).List_Caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               0,
                                                                                                                                               0,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               false,
                                                                                                                                               string.Empty,
                                                                                                                                               (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto,
                                                                                                                                               false,
                                                                                                                                               null);
                //Buscar Cheques Adiantamento
                (bsAdiantamento.Current as TRegistro_LanAdiantamento).lChequesBusca = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x "+
                                        "inner join tb_fin_adiantamento_x_caixa y "+
                                        "on x.cd_contager = y.cd_contager "+
                                        "and x.cd_lanctocaixa = y.cd_lanctocaixa "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.cd_banco = a.cd_banco "+
                                        "and x.nr_lanctocheque = a.nr_lanctocheque "+
                                        "and y.id_adto = " + (bsAdiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")"
                        }
                    }, 0, string.Empty, "a.nr_cheque");
                bsAdiantamento.ResetCurrentItem();
                BS_Lancamento_Caixa_PositionChanged(this, new EventArgs());
            }
        }

        private void g_Consulta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_Consulta.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAdiantamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanAdiantamento());
            TList_LanAdiantamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_Consulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_Consulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanAdiantamento(lP.Find(g_Consulta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_Consulta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanAdiantamento(lP.Find(g_Consulta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_Consulta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAdiantamento.DataSource as TList_LanAdiantamento).Sort(lComparer);
            bsAdiantamento.ResetBindings(false);
            g_Consulta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void dG_Titulo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dG_Titulo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_Titulo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo());
            CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo(lP.Find(dG_Titulo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in dG_Titulo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo(lP.Find(dG_Titulo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in dG_Titulo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_Titulo.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Sort(lComparer);
            BS_Titulo.ResetBindings(false);
            dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void g_Lancamento_Caixa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_Lancamento_Caixa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCaixa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanCaixa());
            TList_LanCaixa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_Lancamento_Caixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_Lancamento_Caixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanCaixa(lP.Find(g_Lancamento_Caixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_Lancamento_Caixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanCaixa(lP.Find(g_Lancamento_Caixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_Lancamento_Caixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCaixa.DataSource as TList_LanCaixa).Sort(lComparer);
            bsCaixa.ResetBindings(false);
            g_Lancamento_Caixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFConsulta_Adiantamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gParcelas);
            ShapeGrid.SaveShape(this, g_Consulta);
            ShapeGrid.SaveShape(this, g_Lancamento_Caixa);
            ShapeGrid.SaveShape(this, dG_Titulo);
        }

        private void listagemOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImprimirRelatorio();
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImprimirExtrato();
        }

        private void reciboAdiantamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImprimirRecibo();
        }
    }
}
