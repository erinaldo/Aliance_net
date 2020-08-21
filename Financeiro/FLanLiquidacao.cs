using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Titulo;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Diversos;
using Utils;
using FormBusca;
using CamadaNegocio.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFLanLiquidacao : Form
    {
        private CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc
        { get; set; }
        private string pCd_operador
        { get; set; }
        private bool st_histquitacao = false;
        private TTpModo TPModo = TTpModo.tm_Standby;
        private bool vST_lancarCheque = false;
        private bool vSt_cartaocredito = false;

        public decimal? Id_caixaoperacional
        { get; set; }
        public List<TRegistro_LanParcela> LParcela
        { get; set; }
        public string vTp_mov = string.Empty;
        public string vCd_empresa = string.Empty;
        public string vCd_clifor = string.Empty;
        public string vCd_moeda = string.Empty;
        public string vCd_moeda_padrao = string.Empty;
        public string vCd_historico = string.Empty;
        public string Loginpdv = string.Empty;

        public List<string> Texto = null;

        public TFLanLiquidacao()
        {
            InitializeComponent();
        }

        private void DevolverCredito()
        {
            if (bsLiquidacao.Current != null)
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCred = null;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = decimal.Zero;
                using (TFSaldoCreditos fSaldo = new TFSaldoCreditos())
                {
                    fSaldo.Cd_empresa = CD_Empresa.Text;
                    fSaldo.Cd_clifor = CD_Clifor.Text;
                    fSaldo.Vl_financeiro = vl_pagar_receber.Value;
                    fSaldo.Tp_mov = RB_TpTitulo_Emitidos.Checked ? "'C'" : "'R'";
                    if (fSaldo.ShowDialog() == DialogResult.OK)
                        if (fSaldo.lSaldo != null)
                        {
                            (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCred = fSaldo.lSaldo;
                            (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                            bsLiquidacao.ResetCurrentItem();
                            vl_pagar_receber.Value = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
                        }
                        else
                            bsLiquidacao.ResetCurrentItem();
                    else
                        bsLiquidacao.ResetCurrentItem();
                }
            }
        }

        private void PreparaBotoes(TTpModo pModo)
        {
            if (pModo == TTpModo.tm_Standby)
            {
                BB_Novo.Visible = true;
                BB_Cancelar.Visible = false;
                BB_Gravar.Visible = false;
            }
            else if (pModo == TTpModo.tm_Insert)
            {
                BB_Novo.Visible = false;
                BB_Cancelar.Visible = true && (Tag == null ? false : Tag.ToString().Trim().ToUpper().Equals("S"));
                BB_Gravar.Visible = true;
            }
            else if (pModo == TTpModo.tm_Edit)
            {
                BB_Novo.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = true;
            }
            else if (pModo == TTpModo.tm_busca)
            {
                BB_Novo.Visible = true;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = false;
            }

        }

        private void VisualizarBloquetos()
        {
            if (bsParcelas.Current != null)
            {
                if ((bsParcelas.Current as TRegistro_LanParcela).St_bloquetobool)
                {
                    if (!tcGrid.TabPages.Contains(tpBloquetos))
                        tcGrid.TabPages.Add(tpBloquetos);
                }
                else
                {
                    if (tcGrid.TabPages.Contains(tpBloquetos))
                        tcGrid.TabPages.Remove(tpBloquetos);
                }
            }
        }

        private bool BuscarHistQuitacao()
        {
            //Buscar Historico Cliente
            TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(vCd_clifor, null);
            if (rClifor != null)
            {
                if (vTp_mov.Trim().ToUpper().Equals("P") && !string.IsNullOrEmpty(rClifor.Cd_historicopag))
                {
                    cd_historico.Text = rClifor.Cd_historicopag;
                    ds_historico.Text = rClifor.Ds_historicopag;
                    return true;
                }
                if (vTp_mov.Trim().ToUpper().Equals("R") && !string.IsNullOrEmpty(rClifor.Cd_historicorec))
                {
                    cd_historico.Text = rClifor.Cd_historicorec;
                    ds_historico.Text = rClifor.Ds_historicorec;
                    return true;
                }
            }
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "a.cd_Historico";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_historico_busca.Text.Trim() + "'";
            TList_CadHistorico lHist = new TCD_CadHistorico().Select(filtro, 1, string.Empty);
            if (lHist.Count > 0)
            {
                cd_historico.Text = lHist[0].CD_Historico_Quitacao;
                ds_historico.Text = lHist[0].DS_Historico_Quitacao;
                return true;
            }
            return false;
        }

        private void RecalcularParcelas()
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.List as List<TRegistro_LanParcela>).ForEach(p =>
                    {
                        System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
                        hs.Add("@P_CD_EMPRESA", p.Cd_empresa);
                        hs.Add("@P_NR_LANCTO", p.Nr_lancto);
                        hs.Add("@P_CD_PARCELA", p.Cd_parcela);
                        hs.Add("@P_DATA_ATUAL", DT_Pgto.Data);
                        hs.Add("@P_ST_CALCMOEDAPADRAO", "N");
                        try
                        {
                            p.Vl_atual = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(new CamadaDados.TDataQuery().executarProc("STP_FIN_CALC_ATUAL", hs), "@@VL_RET"));
                            p.cVl_atual = p.Vl_atual;
                        }
                        catch
                        { }
                    });
                bsParcelas.ResetBindings(true);
            }
        }   

        private void TotalizarParcelas()
        {
            if (bsParcelas.Count > 0)
            {
                if ((bsParcelas.List as List<TRegistro_LanParcela>).Exists(p => p.St_processar))
                {
                    Vlr_Nominal.Value = (bsParcelas.List as List<TRegistro_LanParcela>).FindAll(p => p.St_processar).Sum(p => p.Vl_parcela);
                    Vl_Liquidado.Value = (bsParcelas.List as List<TRegistro_LanParcela>).FindAll(p => p.St_processar).Sum(p => p.Vl_liquidado);
                    Vl_Atual.Value = (bsParcelas.List as List<TRegistro_LanParcela>).FindAll(p => p.St_processar).Sum(p => p.Vl_atual);
                    Vlr_Juro_Mora.Value = (bsParcelas.List as List<TRegistro_LanParcela>).FindAll(p => p.St_processar).Where(p=> p.Vl_juro > decimal.Zero).Sum(p => p.Vl_juro);
                }
                else
                {
                    Vlr_Nominal.Value = (bsParcelas.List as List<TRegistro_LanParcela>).Sum(p => p.Vl_parcela);
                    Vl_Liquidado.Value = (bsParcelas.List as List<TRegistro_LanParcela>).Sum(p => p.Vl_liquidado);
                    Vl_Atual.Value = (bsParcelas.List as List<TRegistro_LanParcela>).Sum(p => p.Vl_atual);
                    Vlr_Juro_Mora.Value = (bsParcelas.List as List<TRegistro_LanParcela>).Where(p=> p.Vl_juro > decimal.Zero).Sum(p => p.Vl_juro);
                }
            }
            Vlr_Desconto_Concedido.Value = decimal.Zero;
            Vlr_LiquidarPadrao.Value = Vl_Atual.Value;
            bsLiquidacao.ResetCurrentItem();
        }

        private void BuscarParcelas()
        {
            if ((rgMovimento.NM_Valor.Trim() != string.Empty) &&
                (cd_moeda.Text.Trim() != string.Empty) &&
                (CD_Clifor.Text.Trim() != string.Empty) &&
                (CD_Empresa.Text.Trim() != string.Empty))
            {
                TpBusca[] filtro = new TpBusca[6];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Clifor
                filtro[1].vNM_Campo = "a.cd_clifor";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
                //Moeda
                filtro[2].vNM_Campo = "a.cd_moeda";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'" + cd_moeda.Text.Trim() + "'";
                //Movimento
                filtro[3].vNM_Campo = "a.tp_mov";
                filtro[3].vOperador = "=";
                filtro[3].vVL_Busca = "'" + rgMovimento.NM_Valor.Trim().ToUpper() + "'";
                //Parcelas em Aberto
                filtro[4].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[4].vOperador = "in";
                filtro[4].vVL_Busca = "('A', 'P')";
                //Duplicata nao cancelada
                filtro[5].vNM_Campo = "isnull(dup.st_registro, 'A')";
                filtro[5].vOperador = "<>";
                filtro[5].vVL_Busca = "'C'";
                if (!string.IsNullOrEmpty(nr_lancto.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_lancto.Text;
                }

                bsParcelas.DataSource = new TCD_LanParcela().Select(filtro, 0, string.Empty, string.Empty, string.Empty).OrderBy(p => p.Dt_vencto).ToList();

                st_histquitacao = BuscarHistQuitacao();
                if (DT_Pgto.Text.Trim() != "/  /")
                    RecalcularParcelas();
                TotalizarParcelas();
                //BuscarCotacao();
                VisualizarBloquetos();
            }
        }

        private void afterNovo()
        {
            if (LParcela == null)
                pFiltro.Enabled = true;
            TPModo = TTpModo.tm_Insert;
            HabilitarCampos(true);
            PreparaBotoes(TPModo);

            bsParcelas.Clear();
            bsLiquidacao.Clear();

            pFiltro.LimparRegistro();
            pLiquid.LimparRegistro();
            pn_vlrcalc.LimparRegistro();

            bsLiquidacao.AddNew();
            RB_TpTitulo_Emitidos.Focus();
        }

        private void afterCancela()
        {
            TPModo = TTpModo.tm_Standby;
            HabilitarCampos(false);
            PreparaBotoes(TPModo);
            bsLiquidacao.CancelEdit();

            bsParcelas.Clear();
            bsLiquidacao.Clear();

            pFiltro.LimparRegistro();
            pLiquid.LimparRegistro();
            pn_vlrcalc.LimparRegistro();
        }

        private bool VerificarTotDesconto(decimal tot_desconto)
        {
            if (lDesc.Count > 0)
            {
                //Desconto por vendedor e empresa
                decimal pc_descontoOp = tot_desconto * 100 / Vl_Atual.Value;
                if (pc_descontoOp > lDesc[0].Pc_max_desconto)
                {
                    MessageBox.Show("Usuário está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                    {
                        fLogin.Cd_empresa = CD_Empresa.Text;
                        fLogin.Pc_desc = pc_descontoOp;
                        if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return false;
                        else
                            return true;
                    }
                }
                else return true;
            }
            else
            {
                Vlr_Desconto_Concedido.Enabled = false;
                return true;
            }
        }

        private void bb_Portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Portador|350;" +
                  "CD_Portador|Cód. Portador|100;" +
                  "ST_TituloTerceiro|Utilizar Titulo Terceiro|100";
            string vParam = "isnull(a.st_devcredito, 'N')|<>|'S'";
            if (RB_TpTitulo_Recebidos.Checked)
                vParam += ";isnull(st_tituloterceiro, 'N')|<>|'S'";
            if (Id_caixaoperacional != null)
                vParam += ";a.tp_portadorPDV|=|'A'";
            DataRowView reg = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Portador, DS_Portador, st_tituloterceiro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
            if (reg != null)
            {
                vST_lancarCheque = reg["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
                vSt_cartaocredito = string.IsNullOrEmpty(reg["st_cartaocredito"].ToString()) ? false : !Convert.ToBoolean(reg["st_cartaocredito"].ToString());
            }
            else
            {
                vST_lancarCheque = false;
                vSt_cartaocredito = false;
            }
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            st_tituloterceiro.Clear();
            string vColunas = "CD_Portador|=|'" + CD_Portador.Text + "';" +
                              "isnull(a.st_devcredito, 'N')|<>|'S'";
            if (RB_TpTitulo_Recebidos.Checked)
                vColunas += ";isnull(st_tituloterceiro, 'N')|<>|'S'";
            if (Id_caixaoperacional != null)
                vColunas += ";a.tp_portadorPDV|=|'A'";
            DataRow reg = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Portador, DS_Portador, st_tituloterceiro },
                               new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
            if (reg != null)
            {
                vST_lancarCheque = reg["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
                vSt_cartaocredito = string.IsNullOrEmpty(reg["st_cartaocredito"].ToString()) ? false : !Convert.ToBoolean(reg["st_cartaocredito"].ToString());
            }
            else
            {
                vST_lancarCheque = false;
                vSt_cartaocredito = false;
            }
        }

        private void CD_Conta_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + CD_ContaGer.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if (Id_caixaoperacional != null)
                vColunas += ";a.st_contaCF|=|0";
            else
            {
                vColunas += ";a.st_contaCF|=|1";
                if (rgMovimento.NM_Valor.Trim().ToUpper().Equals("P"))
                {
                    if (vST_lancarCheque)
                        vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                    else
                        vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
                }
                else if (rgMovimento.NM_Valor.Trim().ToUpper().Equals("R"))
                    vColunas += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
                if (vSt_cartaocredito)
                    vColunas += ";a.st_contacartao|=|0";
                else
                    vColunas += ";a.st_contacartao|<>|0";
            }

                UtilPesquisa.EDIT_LEAVE(vColunas,
                  new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                  new TCD_CadContaGer());
            if ((!string.IsNullOrEmpty(CD_ContaGer.Text)) && 
                (!string.IsNullOrEmpty(DT_Pgto.Text)) && 
                (DT_Pgto.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!TCN_LanCaixa.DataCaixa(CD_ContaGer.Text, Convert.ToDateTime(DT_Pgto.Text), null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + CD_ContaGer.Text + "\r\n Data: " + DT_Pgto.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterCancela();
                }
            }
        }

        private void bb_Conta_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                "where k.CD_ContaGer = a.CD_ContaGer " +
                                "and k.cd_Empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa + "' )";
            if (Id_caixaoperacional != null)
                vParamFixo += ";a.st_contaCF|=|0";
            else
            {
                vParamFixo += ";a.st_contaCF|=|1";
                if (rgMovimento.NM_Valor.Trim().ToUpper().Equals("P"))
                {
                    if (vST_lancarCheque)
                        vParamFixo += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                    else
                        vParamFixo += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
                }
                else if (rgMovimento.NM_Valor.Trim().ToUpper().Equals("R"))
                    vParamFixo += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
                if (vSt_cartaocredito)
                    vParamFixo += ";a.st_contacartao|=|0";
                else
                    vParamFixo += ";a.st_contacartao|<>|0";
            }
            UtilPesquisa.BTN_BUSCA(vColunas,
                new Componentes.EditDefault[] { CD_ContaGer,  DS_ContaGer },
                new TCD_CadContaGer(), vParamFixo);
            if ((!string.IsNullOrEmpty(CD_ContaGer.Text)) && 
                (!string.IsNullOrEmpty(DT_Pgto.Text)) && 
                (DT_Pgto.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!TCN_LanCaixa.DataCaixa(CD_ContaGer.Text, Convert.ToDateTime(DT_Pgto.Text), null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + CD_ContaGer.Text + "\r\n Data: " + DT_Pgto.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterCancela();
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new TCD_CadEmpresa(), vParam );
            BuscarParcelas();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                new TCD_CadEmpresa());
            BuscarParcelas();
        }
        
        private void TFLanLiquidacao_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gLiquidaLancFin);
            ShapeGrid.RestoreShape(this, tList_LanAdiantamentoDataGridDefault);
            ShapeGrid.RestoreShape(this, gBloquetos);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            if (LParcela != null)
            {
                afterNovo();
                LParcela = LParcela.OrderBy(p => p.Dt_vencto).ToList();
                bsParcelas.DataSource = LParcela;
                TotalizarParcelas();
                //BuscarCotacao();
                VisualizarBloquetos();
                string vir = string.Empty;
                LParcela.ForEach(p =>
                    {
                        (bsLiquidacao.Current as TRegistro_LanLiquidacao).ComplHistorico += vir + p.complHistorico.Trim();
                        vir = ";";
                    });
                Vlr_LiquidarPadrao_Enter(this, new EventArgs());
            }
            RB_TpTitulo_Emitidos.Checked = vTp_mov.Trim().ToUpper().Equals("P");
            RB_TpTitulo_Recebidos.Checked = vTp_mov.Trim().ToUpper().Equals("R");
            CD_Empresa.Text = vCd_empresa;
            CD_Clifor.Text = vCd_clifor;
            CD_Clifor_Leave(this, new EventArgs());
            cd_moeda.Text = vCd_moeda;
            cd_historico_busca.Text = vCd_historico;
            BuscarHistQuitacao();
            DT_Pgto.Text = DateTime.Now.ToString("ddMMyyyy");
            DT_Pgto_Leave(this, new EventArgs());
            if (bsLiquidacao.Current != null)
                cd_moeda_Leave(this, new EventArgs());
            pFiltro.set_FormatZero();
            pLiquid.set_FormatZero();
            //Buscar Codigo Operador amarrado ao login
            object obj_operador =
            new TCD_CadClifor().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.loginvendedor",
                        vOperador = "=",
                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                    }
                }, "a.cd_clifor");
            if (obj_operador != null)
                pCd_operador = obj_operador.ToString();
            else
                Vlr_Desconto_Concedido.Enabled = false;

            if (!string.IsNullOrEmpty(pCd_operador))
            {
                lDesc =
                  CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(pCd_operador,
                                                                                  CD_Empresa.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
            }
        }
        
        private void HabilitarCampos(bool val)
        {
            rgMovimento.Enabled = val;
            CD_Empresa.Enabled = val;
            BB_Empresa.Enabled = val;
            cd_moeda.Enabled = val;
            bb_moeda.Enabled = val;
            cd_historico_busca.Enabled = val;
            bb_historico_busca.Enabled = val;
            CD_Clifor.Enabled = val;
            bb_clifor.Enabled = val;
            nr_lancto.Enabled = val;
            bb_duplicata.Enabled = val;
            CD_ContaGer.Enabled = val;
            BB_ContaGer.Enabled = val;
            CD_Portador.Enabled = val;
            NrDoc.Enabled = val;
            BB_Portador.Enabled = val;
            cd_historico.Enabled = val;
            bb_historico.Enabled = val;
            DT_Pgto.Enabled = val;
            Compl_Historico.Enabled = val;
            vl_pagar_receber.Enabled = val && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR LIQUIDAÇÃO PARCIAL", null);
            Vlr_Desconto_Concedido.Enabled = val;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (CD_ContaGer.Focused)
                CD_Conta_Leave(this, new EventArgs());
            if (Vlr_Desconto_Concedido.Focused)
                Vlr_Desconto_Concedido_Leave(this, new EventArgs());
            if (bsParcelas.Count <= 0)
            {
                MessageBox.Show("Obrigatorio informar parcelas a serem liquidadas.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            if (DateTime.Parse(DT_Pgto.Text).Date > dt_atual.Date)
            {
                //Verificar se o usuario tem permissao para liquidar com data superior a data corrente
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR LIQUIDAR COM DATA SUPERIOR ATUAL", null))
                {
                    MessageBox.Show("Usuario não tem permissão para liquidar com data superior a data corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DT_Pgto.Text = dt_atual.ToString("dd/MM/yyyy");
                    DT_Pgto.Focus();
                }
            }
            //Montar lista de parcelas
            List<TRegistro_LanParcela> lParcelas = new List<TRegistro_LanParcela>();
            decimal saldo = Vlr_LiquidarPadrao.Value;
            decimal juro = decimal.Zero;
            if ((bsParcelas.List as List<TRegistro_LanParcela>).Exists(p => p.St_processar))
                (bsParcelas.List as List<TRegistro_LanParcela>).FindAll(p => p.St_processar).OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                    {
                        if (saldo > decimal.Zero)
                        {
                            if (p.cVl_atual < saldo)
                                juro += p.Vl_juro;
                            else if (p.cVl_atual - p.Vl_juro < saldo)
                                juro += saldo - (p.cVl_atual - p.Vl_juro);
                            lParcelas.Add(p);
                            saldo -= p.cVl_atual;
                        }
                    });
            else
                (bsParcelas.List as List<TRegistro_LanParcela>).OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                {
                    if (saldo > decimal.Zero)
                    {
                        if (p.cVl_atual < saldo)
                            juro += p.Vl_juro;
                        else if (p.cVl_atual - p.Vl_juro < saldo)
                            juro += saldo - (p.cVl_atual - p.Vl_juro);
                        lParcelas.Add(p);
                        saldo -= p.cVl_atual;
                    }
                });
            if(saldo > decimal.Zero)
                juro += saldo;
            string msg = string.Empty;
            lParcelas.ForEach(p =>
            {
                object obj = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cob_lote_x_titulo x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lancto = a.nr_lancto "+
                                        "and x.cd_parcela = a.cd_parcela "+
                                        "and x.id_cobranca = a.id_cobranca "+
                                        "and a.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                        "and a.nr_lancto = " + p.Nr_lanctostr + " " +
                                        "and a.cd_parcela = " + p.Cd_parcelastr.ToString() + ")"
                        }
                    }, "1");
                if (obj != null)
                    msg += "Duplicata: " + p.Nr_lanctostr.ToString() + "/" + p.Cd_parcelastr + "\r\n";
            });
            if (msg.Trim() != string.Empty)
                if (MessageBox.Show("Existe duplicata(s) descontadas.\r\nAs duplicatas que pertencerem a lotes em aberto serão excluidas do lote.\r\n\r\n" + msg.Trim() + "\r\n" +
                                   "Confirma liquidação mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
            if (!pLiquid.validarCampoObrigatorio())
                return;
            if (Vlr_LiquidarPadrao.Value.Equals(0))
            {
                MessageBox.Show("Obrigatório informar valor para liquidar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if((bsLiquidacao.Current as TRegistro_LanLiquidacao).lCred == null)
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", CD_Empresa.Text, null).Trim().ToUpper().Equals("S"))
                    if (CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                         CD_Empresa.Text,
                                                                                         CD_Clifor.Text,
                                                                                         string.Empty,
                                                                                         "'R'",
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         false,
                                                                                         false,
                                                                                         true,
                                                                                         string.Empty,
                                                                                         false,
                                                                                         true,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         0,
                                                                                         string.Empty,
                                                                                         null).Count > 0)
                        DevolverCredito();
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Id_caixaoperacional = Id_caixaoperacional;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_juroliquidar = juro;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao = Vlr_LiquidarPadrao.Value;
            if ((Vlr_Desconto_Concedido.Focused) && (Vlr_Desconto_Concedido.Value != (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_descontoconcedido))
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_descontoconcedido = Vlr_Desconto_Concedido.Value;
            if (vl_adiantamento.Focused)
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = vl_adiantamento.Value;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cd_empresa = (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cd_clifor = (bsParcelas.Current as TRegistro_LanParcela).Cd_clifor;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cd_historico_desc = (bsParcelas.Current as TRegistro_LanParcela).Cd_historico_desconto;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cd_historico_juro = (bsParcelas.Current as TRegistro_LanParcela).Cd_historico_juro;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cd_historico_trocoCH = (bsParcelas.Current as TRegistro_LanParcela).Cd_historico_troco;

            if ((bsLiquidacao.Current as TRegistro_LanLiquidacao).Nr_docto.Trim() == string.Empty)
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).Nr_docto = (bsParcelas.Current as TRegistro_LanParcela).Nr_docto;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Nr_lancto = (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto;
            (bsLiquidacao.Current as TRegistro_LanLiquidacao).Tp_mov = (bsParcelas.Current as TRegistro_LanParcela).Tp_mov;
            //Informar cheques 
            if (vST_lancarCheque && (!st_tituloterceiro.Text.Trim().ToUpper().Equals("S")) &&
                ((bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao -
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_descontoconcedido -
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento > decimal.Zero))
            {
                TRegistro_DadosBloqueio rDados = new TRegistro_DadosBloqueio();
                if(TCN_DadosBloqueio.VerificarBloqueioCredito((bsParcelas.Current as TRegistro_LanParcela).Cd_clifor,
                                                              decimal.Zero,
                                                              false,
                                                              ref rDados,
                                                              null))
                    using (TFLan_BloqueioCredito fBloq = new TFLan_BloqueioCredito())
                    {
                        fBloq.St_liquidacao = true;
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
                        fBloq.ShowDialog();
                        if (!fBloq.St_desbloqueado)
                            return;
                    }
                TList_RegLanTitulo lCheques = new TList_RegLanTitulo();
                using (TFLanListaCheques fListaCheques = new TFLanListaCheques())
                {
                    fListaCheques.Tp_mov = (bsParcelas.Current as TRegistro_LanParcela).Tp_mov;
                    fListaCheques.Cd_empresa = CD_Empresa.Text;
                    fListaCheques.Cd_contager = CD_ContaGer.Text;
                    fListaCheques.Ds_contager = DS_ContaGer.Text;
                    fListaCheques.Cd_clifor = (bsParcelas.Current as TRegistro_LanParcela).Cd_clifor;
                    fListaCheques.Cd_historico = cd_historico.Text;
                    fListaCheques.Ds_historico = ds_historico.Text;
                    fListaCheques.Cd_portador = CD_Portador.Text;
                    fListaCheques.Ds_portador = DS_Portador.Text;
                    fListaCheques.Nm_clifor = (bsParcelas.Current as TRegistro_LanParcela).Nm_clifor;
                    fListaCheques.Dt_emissao = (bsLiquidacao.Current as TRegistro_LanLiquidacao).Dt_Liquidacao;
                    fListaCheques.Vl_totaltitulo = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
                    if (fListaCheques.ShowDialog() == DialogResult.OK)
                    {
                        lCheques = fListaCheques.lCheques;
                        if ((bsParcelas.Current as TRegistro_LanParcela).Tp_mov.Trim().ToUpper().Equals("R") &&
                        fListaCheques.lCheques.Count > 0)
                        {
                            if ((Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value) <
                                fListaCheques.lCheques.Sum(p => p.Vl_titulo))
                            {
                                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR GERAR CREDITO NO TROCO", null))
                                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).St_AdtoTrocoCH = false;
                                else
                                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).St_AdtoTrocoCH =
                                    MessageBox.Show("Duplicata esta sendo liquidada com cheque no valor maior que o valor da duplicata.\r\n" +
                                                       "Deseja gerar adiantamento no valor do troco?",
                                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                                if((bsLiquidacao.Current as TRegistro_LanLiquidacao).St_AdtoTrocoCH)
                                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_adto =
                                        fListaCheques.lCheques.Sum(p => p.Vl_titulo) -
                                        (Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value);
                                else
                                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_trocoCH =
                                        fListaCheques.lCheques.Sum(p => p.Vl_titulo) -
                                        (Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada! ");
                        return;
                    }
                }
                //Gravar liquidacao
                ThreadEspera tEspera = new ThreadEspera("Inicio do processo gravar liquidação...");
                try
                {
                    TCN_LanLiquidacao.GravarLiquidacao(lParcelas,
                                                       (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                       lCheques,
                                                       null,
                                                       null,
                                                       tEspera,
                                                       null);
                    MessageBox.Show("Liquidação Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chamar tela de impressao para o cheque
                    //somente se for contas a pagar e for com cheque
                    try
                    {
                        if (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") && (lCheques != null) &&
                            vST_lancarCheque && (!st_tituloterceiro.Text.Trim().ToUpper().Equals("S")))
                            if (lCheques.Count > 0)
                                if(MessageBox.Show("Imprimir cheques emitidos?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    try
                                    {
                                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(lCheques);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro imprimir lista de cheques: " + ex.Message.Trim());
                    }
                    try
                    {
                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDuplic = TCN_LanDuplicata.Busca((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                                                                (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString(),
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                0,
                                                                                                                string.Empty,
                                                                                                                null);
                        //Impressao do recibo
                        string referente = string.Empty;
                        string virg = string.Empty;
                        lParcelas.ForEach(p =>
                        {
                            referente += virg + p.Nr_docto.Trim() + "/" + p.Cd_parcelastr + (p.St_registro.Trim().ToUpper().Equals("P") ? "(PARCIAL)" : string.Empty);
                            virg = ", ";
                        });
                            object obj = new TCD_CadTerminal().BuscarEscalar(
                                   new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                        if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        {
                            if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                   (bsLiquidacao.Current as TRegistro_LanLiquidacao));
                            }
                        }
                        else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                        {
                            if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                   (bsLiquidacao.Current as TRegistro_LanLiquidacao));
                            }
                        }
                        else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                        {
                            FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                          referente,
                                                                          (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                                          lDuplic);
                        }
                        else
                        {
                            FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                          referente,
                                                                          (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                                          lDuplic);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro imprimir recibos liquidação com cheques: " + ex.Message.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                    if ((LParcela != null) || (Id_caixaoperacional != null))
                        Close();
                    else
                        afterCancela();
                }
            }
            else
            {
                List<TRegistro_LanTitulo> lTitulosTerceiros = null;
                CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
                if (vSt_cartaocredito &&
                    ((bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao -
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_descontoconcedido -
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento > decimal.Zero))
                {
                    using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                    {
                        if (fD_C.ShowDialog() == DialogResult.OK)
                            //Buscar dados fatura cartao credito
                            using (TFFaturaCartao fFatura = new TFFaturaCartao())
                            {
                                fFatura.Cd_empresa = CD_Empresa.Text;
                                fFatura.Tp_movimento = (bsParcelas.Current as TRegistro_LanParcela).Tp_mov;
                                fFatura.Dt_fatura = (bsLiquidacao.Current as TRegistro_LanLiquidacao).Dt_Liquidacao;
                                fFatura.Vl_nominal = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
                                fFatura.Vl_juro = decimal.Zero;
                                fFatura.D_C = fD_C.D_C;
                                if (fFatura.ShowDialog() == DialogResult.OK)
                                    if (fFatura.lFatura != null)
                                        lFatura = fFatura.lFatura;
                                    else
                                    {
                                        MessageBox.Show("Fatura cartão não foi lançada.\r\nLiquidação não sera efetivada.");
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Fatura cartão não foi lançada.\r\nLiquidação não sera efetivada.");
                                    return;
                                }
                            }
                        else
                        {
                            MessageBox.Show("Fatura cartão não foi lançada.\r\nLiquidação não sera efetivada.");
                            return;
                        }
                    }
                }
                else if (st_tituloterceiro.Text.Trim().ToUpper().Equals("S"))
                {
                    using(TFConsultaTitulosRecebidos fTitulosRecebidos = new TFConsultaTitulosRecebidos())
                    {
                        fTitulosRecebidos.Cd_empresa = vCd_empresa;
                        fTitulosRecebidos.Cd_contager = CD_ContaGer.Text;
                        fTitulosRecebidos.Vl_conciliar = (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_liquidarLiquido;
                        if (fTitulosRecebidos.ShowDialog() == DialogResult.OK)
                        {
                            lTitulosTerceiros = fTitulosRecebidos.lChRepasse;
                            //Calcular Crédito
                            if (lTitulosTerceiros.Sum(p => p.Vl_titulo) - (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_liquidarLiquido > decimal.Zero)
                                (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_adto = lTitulosTerceiros.Sum(p => p.Vl_titulo) - (bsLiquidacao.Current as TRegistro_LanLiquidacao).Vl_liquidarLiquido;
                            if (lTitulosTerceiros.Sum(p => p.Vl_titulo) < vl_pagar_receber.Value)
                            {
                                vl_pagar_receber.Value = lTitulosTerceiros.Sum(p => p.Vl_titulo);
                                vl_pagar_receber_Leave(this, new EventArgs());
                            }

                            if (lTitulosTerceiros == null ? false : lTitulosTerceiros.Count.Equals(0))
                            {
                                MessageBox.Show("Obrigatorio informar lista de cheques de terceiros para repasse.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CD_Portador.Focus();
                                return;
                            }
                            gChequesTerceiros.DataSource = lTitulosTerceiros;
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar lista de cheques de terceiros para repasse.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Portador.Focus();
                            return;
                        }
                    }
                }
                //Gravar liquidacao
                ThreadEspera tEspera = new ThreadEspera("Inicio do processo gravar liquidação...");
                try
                {
                    TCN_LanLiquidacao.GravarLiquidacao(lParcelas,
                                                       (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                       lTitulosTerceiros,
                                                       lFatura,
                                                       null,
                                                       tEspera,
                                                       null);
                    MessageBox.Show("Liquidação Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Impressao do recibo
                    string referente = string.Empty;
                    string virg = string.Empty;
                    try
                    {
                        //valor adiantamento zerado no metodo gravar liquidacao, rotornar valor para poder imprimir no recibo
                        (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = vl_adiantamento.Value;
                        TList_RegLanDuplicata lDuplic = TCN_LanDuplicata.Busca((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                                                                (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString(),
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                0,
                                                                                                                string.Empty,
                                                                                                                null);
                        virg = string.Empty;
                        lParcelas.ForEach(p =>
                            {
                                referente += virg + p.Nr_docto.Trim() + "/" + p.Cd_parcelastr + (p.St_registro.Trim().ToUpper().Equals("P") ? "(PARCIAL)" : string.Empty);
                                virg = ", ";
                            });
                            object obj = new TCD_CadTerminal().BuscarEscalar(
                                   new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                        if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        {
                            if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                               == DialogResult.Yes)
                            {
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                   (bsLiquidacao.Current as TRegistro_LanLiquidacao));
                            }
                        }
                        else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                        {
                            if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                   (bsLiquidacao.Current as TRegistro_LanLiquidacao));
                            }
                        }
                        else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                        {
                            FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                          referente,
                                                                          (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                                          lDuplic);
                        }
                        else
                        {
                            FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                          referente,
                                                                          (bsLiquidacao.Current as TRegistro_LanLiquidacao),
                                                                          lDuplic);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro imprimir recibos: " + ex.Message.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                    if ((LParcela != null) || (Id_caixaoperacional != null))
                        Close();
                    else
                        afterCancela();
                }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanLiquidacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && (BB_Novo.Visible))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && (BB_Gravar.Visible))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6) && (BB_Cancelar.Visible))
                afterCancela();
        }

        private void DT_Pgto_Leave(object sender, EventArgs e)
        {
            if(DT_Pgto.Text.Trim() != "/  /")
            {
                DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                if (DateTime.Parse(DT_Pgto.Text).Date > dt_atual.Date)
                {
                    //Verificar se o usuario tem permissao para liquidar com data superior a data corrente
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR LIQUIDAR COM DATA SUPERIOR ATUAL", null))
                    {
                        MessageBox.Show("Usuario não tem permissão para liquidar com data superior a data corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DT_Pgto.Text = dt_atual.ToString("dd/MM/yyyy");
                        DT_Pgto.Focus();
                    }
                }
                if(!string.IsNullOrEmpty(CD_ContaGer.Text))
                    //testar data de fechamento de caixa se esta aberto para esta data 
                    if (!TCN_LanCaixa.DataCaixa(CD_ContaGer.Text, Convert.ToDateTime(DT_Pgto.Text), null))
                    {
                        MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + CD_ContaGer.Text + "\r\n Data: " + DT_Pgto.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DT_Pgto.Clear();
                        DT_Pgto.Focus();
                    }
                RecalcularParcelas();
                TotalizarParcelas();
            }
        }

        private void Vlr_Desconto_Concedido_Enter(object sender, EventArgs e)
        {
            Vlr_Desconto_Concedido.Select(0,15);
        }
            
        private void Vlr_LiquidarPadrao_Enter(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                if ((bsParcelas.DataSource as List<TRegistro_LanParcela>).Exists(p => p.St_processar))
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao = (bsParcelas.DataSource as List<TRegistro_LanParcela>).Where(p => p.St_processar).Sum(p => p.cVl_atual);
                else
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao = (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_Atual;
                bsLiquidacao.ResetCurrentItem();
                Vlr_LiquidarPadrao.Select(0, Vlr_LiquidarPadrao.ToString().Length);
            }
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|200;" +
                              "CD_Moeda|Cd. Moeda|80;" +
                              "Sigla|Sigla|60";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "");
            if (linha != null)
                if (bsLiquidacao.Current != null)
                {
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = linha["CD_Moeda"].ToString();
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = linha["DS_Moeda_Singular"].ToString();
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = linha["Sigla"].ToString();
                }
                else
                {
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = string.Empty;
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = string.Empty;
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = string.Empty;
                }
            else
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = string.Empty;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = string.Empty;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = string.Empty;
            }
            BuscarParcelas();
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Moeda|=|'" + cd_moeda.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla }, new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
            if (linha != null)
                if (bsLiquidacao.Current != null)
                {
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = linha["CD_Moeda"].ToString();
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = linha["DS_Moeda_Singular"].ToString();
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = linha["Sigla"].ToString();
                }
                else
                {
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = string.Empty;
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = string.Empty;
                    (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = string.Empty;
                }
            else
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda = string.Empty;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Ds_moeda = string.Empty;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Sigla = string.Empty;
            }
            if(LParcela == null)
                BuscarParcelas();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
            BuscarParcelas();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor },
                                    new TCD_CadClifor());
            if(LParcela == null)
                BuscarParcelas();
        }

        private void RB_TpTitulo_Emitidos_Click(object sender, EventArgs e)
        {
            BuscarParcelas();
        }

        private void RB_TpTitulo_Recebidos_Click(object sender, EventArgs e)
        {
            BuscarParcelas();
        }

        private void bb_duplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nr_Lancto|Cód. Lançamento|100;" +
                              "a.TP_Duplicata|Cód. Duplicata|100;" +
                              "g.DS_TPDuplicata|Duplicata|200;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "c.DS_Historico|Histórico|200;" +
                              "d.NM_Clifor|CLIFOR|100;" +
                              "a.CD_Clifor|Cód. CLIFOR|200";

            string vParamFixo = "|EXISTS|(Select 1 From TB_FIN_Parcela x " +
                                "Where a.CD_Empresa = x.CD_Empresa and a.NR_Lancto = x.NR_Lancto " +
                                "and x.ST_Registro in ('A', 'P'))";
            if (CD_Empresa.Text.Trim() != string.Empty)
                vParamFixo += ";a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            if (rgMovimento.NM_Valor.Trim() != string.Empty)
                vParamFixo += ";g.TP_Mov|=|'" + rgMovimento.NM_Valor.Trim() + "'";
            if (cd_moeda.Text.Trim() != string.Empty)
                vParamFixo += ";a.CD_Moeda|=|'" + cd_moeda.Text.Trim() + "'";
            if (CD_Clifor.Text.Trim() != string.Empty)
                vParamFixo += ";a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_lancto },
                                    new TCD_LanDuplicata(), vParamFixo);
            nr_lancto_Leave(this, new EventArgs());
        }

        private void nr_lancto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Lancto|=|" + nr_lancto.Text + ";" +
                                "|EXISTS|(Select 1 From TB_FIN_Parcela x " +
                                "Where a.CD_Empresa = x.CD_Empresa and a.NR_Lancto = x.NR_Lancto " +
                                "and x.ST_Registro in ('A', 'P'))";
            if (rgMovimento.NM_Valor.Trim() != string.Empty)
                vColunas += ";g.TP_Mov|=|'" + rgMovimento.NM_Valor.Trim() + "'";
            if (CD_Empresa.Text.Trim() != string.Empty)
                vColunas += ";a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            if (cd_moeda.Text.Trim() != string.Empty)
                vColunas += ";a.CD_Moeda|=|'" + cd_moeda.Text.Trim() + "'";
            if (CD_Clifor.Text.Trim() != string.Empty)
                vColunas += ";a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_lancto },
                                                    new TCD_LanDuplicata());
            if (linha != null)
            {
                rgMovimento.NM_Valor = linha["TP_Mov"].ToString().Trim();
                CD_Empresa.Text = linha["CD_Empresa"].ToString();
                cd_moeda.Text = linha["CD_Moeda"].ToString();
                cd_moeda_Leave(this, new EventArgs());
                CD_Clifor.Text = linha["CD_Clifor"].ToString();
                BuscarParcelas();
            }
        }

        private void tcGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcGrid.SelectedIndex == 0)
                BuscarParcelas();
            else if (tcGrid.SelectedTab.Equals(tpBloquetos))
            {
                if(bsParcelas.Current != null)
                    dsBloqueto.DataSource = TCN_Titulo.Buscar((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                               (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.Value,
                                                               (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.Value,
                                                               decimal.Zero,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               decimal.Zero,
                                                               decimal.Zero,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty, 
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               false,
                                                               0, 
                                                               null);
            }
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|" + (RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : string.Empty);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text.Trim() + "';" +
                               "a.TP_Mov|=|" + (RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : string.Empty);
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new TCD_CadHistorico());
        }

        private void TFLanLiquidacao_Shown(object sender, EventArgs e)
        {
            if (LParcela != null)
                DT_Pgto.Focus();
        }

        private void Vlr_LiquidarPadrao_ValueChanged(object sender, EventArgs e)
        {
            

        }
        
        private void bb_historico_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|" + (RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : "");
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_busca },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_busca.Text.Trim() + "';" +
                               "a.TP_Mov|=|";
            vColunas += RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : "";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_busca },
                                    new TCD_CadHistorico());
        }

        private void bsDuplicata_PositionChanged(object sender, EventArgs e)
        {
            VisualizarBloquetos();           
        }

        private void cd_historico_TextChanged(object sender, EventArgs e)
        {
            cd_historico.Enabled = (!st_histquitacao) || (cd_historico.Text.Trim().Equals(string.Empty));
            bb_historico.Enabled = (!st_histquitacao) || (cd_historico.Text.Trim().Equals(string.Empty));
        }

        private void RB_TpTitulo_Emitidos_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_TpTitulo_Emitidos.Checked)
            {
                lblClifor.Text = "Fornecedor:";
                lblPagarReceber.Text = "Vl. Pagar";
            }
        }

        private void RB_TpTitulo_Recebidos_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_TpTitulo_Recebidos.Checked)
            {
                lblClifor.Text = "Cliente:";
                lblPagarReceber.Text = "Vl. Receber";
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.DataSource as List<TRegistro_LanParcela>).ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcelas.ResetBindings(true);
                TotalizarParcelas();
                if (!Vlr_LiquidarPadrao.Focus())
                {
                    Vlr_LiquidarPadrao_Enter(this, new EventArgs());
                    DT_Pgto.Focus();
                }
                string virg = string.Empty;
                string comp = string.Empty;
                (bsParcelas.DataSource as List<TRegistro_LanParcela>).ForEach(p =>
                    {
                        comp += virg + p.complHistorico.Trim();
                        virg = ";";
                    });
                Compl_Historico.Text = comp;
            }
        }

        private void gLiquidaLancFin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsParcelas.Current as TRegistro_LanParcela).St_processar =
                    !(bsParcelas.Current as TRegistro_LanParcela).St_processar;
                bsParcelas.ResetCurrentItem();
                TotalizarParcelas();
                if (!Vlr_LiquidarPadrao.Focus())
                {
                    Vlr_LiquidarPadrao_Enter(this, new EventArgs());
                    DT_Pgto.Focus();
                }
                string virg = string.Empty;
                string comp = string.Empty;
                (bsParcelas.DataSource as List<TRegistro_LanParcela>).ForEach(p =>
                {
                    comp += virg + p.complHistorico.Trim();
                    virg = ";";
                });
                Compl_Historico.Text = comp;
            }
        }

        private void vl_pagar_receber_Leave(object sender, EventArgs e)
        {
            if (bsLiquidacao.Current != null)
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCred = null;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = decimal.Zero;
                bsLiquidacao.ResetCurrentItem();
            }
            if (vl_pagar_receber.Value >= Vl_Atual.Value)
                Vlr_LiquidarPadrao.Value = vl_pagar_receber.Value;
            else Vlr_LiquidarPadrao.Value = vl_pagar_receber.Value + vl_adiantamento.Value + Vlr_Desconto_Concedido.Value;
        }

        private void vl_pagar_receber_Enter(object sender, EventArgs e)
        {
            Vlr_LiquidarPadrao.Value = Vl_Atual.Value;
            bsLiquidacao.ResetCurrentItem();
            vl_pagar_receber.Value = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
            vl_pagar_receber.Select(0, vl_pagar_receber.ToString().Trim().Length);
        }

        private void Vlr_Desconto_Concedido_Leave(object sender, EventArgs e)
        {
            if (bsLiquidacao.Current != null)
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCred = null;
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_adiantamento = decimal.Zero;
                bsLiquidacao.ResetCurrentItem();
                if (!VerificarTotDesconto(Vlr_Desconto_Concedido.Value) && RB_TpTitulo_Recebidos.Checked)
                {
                    Vlr_Desconto_Concedido.Value = decimal.Zero;
                    Vlr_Desconto_Concedido.Focus();
                }
            }
            vl_pagar_receber.Value = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
        }

        private void TFLanLiquidacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gLiquidaLancFin);
            ShapeGrid.SaveShape(this, tList_LanAdiantamentoDataGridDefault);
            ShapeGrid.SaveShape (this, gBloquetos);
        }

        private void bb_devcredito_Click(object sender, EventArgs e)
        {
            DevolverCredito();
        }

        private void Vlr_LiquidarPadrao_Leave(object sender, EventArgs e)
        {
            if (bsLiquidacao.Current != null)
            {
                (bsLiquidacao.Current as TRegistro_LanLiquidacao).Cvl_aliquidar_padrao = Vlr_LiquidarPadrao.Value;
                if ((bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moeda.Trim()
                    != (bsLiquidacao.Current as TRegistro_LanLiquidacao).lCotacao.Cd_moedaresult.Trim())
                    if ((bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_Atual < Vlr_LiquidarPadrao.Value)
                    {
                        (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_juroliquidar = Vlr_LiquidarPadrao.Value - (bsLiquidacao.Current as TRegistro_LanLiquidacao).cVl_Atual;
                        vl_pagar_receber.Value = Vlr_LiquidarPadrao.Value - Vlr_Desconto_Concedido.Value - vl_adiantamento.Value;
                        bsLiquidacao.ResetCurrentItem();
                    }
            }
        }
    }
}