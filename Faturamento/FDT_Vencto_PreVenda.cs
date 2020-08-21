using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento
{
    public partial class TFDT_Vencto_PreVenda : Form
    {
        public string vCd_vendedor = string.Empty;
        private CamadaDados.Faturamento.PDV.TRegistro_PreVenda rprevenda;
        public CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPrevenda
        {
            get
            {
                if (bsPreVenda.Current != null)
                    return bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                else
                    return null;
            }
            set { rprevenda = value; }
        }
        public bool St_cartao
        { get; set; }

        public TFDT_Vencto_PreVenda()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_CondPGTO.Text))
            {
                MessageBox.Show("Obrigatorio informar condição de pagamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void afterCancela()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!St_cartao)
                 vParam = "isnull(b.TP_PortadorPDV, 'A') |=| 'P' ";
            else
                vParam = "b.ST_CartaoCredito |=| '0' ";
            //Verificar se condicao de pagamento para o vendedor
            object obj = null;
            if (!string.IsNullOrEmpty(vCd_vendedor))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + vCd_vendedor.Trim() + "')"
                            }
                        }, "1");
                    if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                             "          where x.cd_condpgto = a.cd_condpgto " +
                             "          and x.cd_vendedor = '" + vCd_vendedor.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;"+
                                   "a.QT_Parcelas|Quantidade Parcelas|40;" +
                                   "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;"+
                                   "a.ST_VenctoEmFeriado|Vence em Feriado|40;"+
                                   "a.cd_condPGTO|Código|100;"+
                                   "a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            CD_CondPGTO_Leave(this, new EventArgs()); 
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "';" +
                (!St_cartao ? "isnull(b.TP_PortadorPDV, 'A') |=| 'P' " : "b.ST_CartaoCredito |=| '0' ");
            object obj = null;
            if (!string.IsNullOrEmpty(vCd_vendedor))
               obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + vCd_vendedor.Trim() + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                          "             where x.cd_condpgto = a.cd_condpgto " +
                          "             and x.cd_vendedor = '" + vCd_vendedor.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO },
             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());

            string ds_juro = string.Empty;
            if (linha != null)
            {
                Parcelas.Value = Convert.ToDecimal(linha["qt_parcelas"].ToString());
                QT_DIASDESDOBRO.Value = Convert.ToDecimal(linha["qt_diasdesdobro"].ToString());
                ST_ComEntrada.Checked = linha["st_comentrada"].ToString().Trim().ToUpper().Equals("S");
                cd_juro_fin.Text = linha["cd_juro_fin"].ToString();
                ds_juro = linha["ds_juro_fin"].ToString();
                PC_JuroDiario_Atrazo.Value = linha["pc_juroDiario_atrazoFin"].ToString().Equals("") ? 0 : Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                tp_juro.Text = linha["tp_juro_fin"].ToString();
                if(bsPreVenda.Current != null)
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).ST_SolicitarDtVencto = linha["ST_SolicitarDtVencto"].ToString();
            }
            else
            {
                Parcelas.Value = decimal.Zero;
                QT_DIASDESDOBRO.Value = decimal.Zero;
                ST_ComEntrada.Checked = false;
                cd_juro_fin.Clear();
                PC_JuroDiario_Atrazo.Value = decimal.Zero;
                if(bsPreVenda.Current != null)
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).ST_SolicitarDtVencto = string.Empty;
            }
            CalcularValorPedidoItem();
            AjustarDadosFinanceiros();
            VL_Entrada.Value = decimal.Zero;
            BS_PARCELAS_PositionChanged(this, new EventArgs());

            if (St_cartao)
            {
                parcelasCartao.Text = BS_PARCELAS.Count + "x" + (PC_JuroDiario_Atrazo.Value > decimal.Zero ? " COM JUROS": " SEM JUROS");
                parcelasCartao.Visible = true;
            }
        }

        private void CalcularValorPedidoItem()
        {
            if (bsPreVenda.Current != null)
            {
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.CalcularValorJuroFin(
                                                                                                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto()
                                                                                                            {
                                                                                                                Pc_jurodiario_atrazoFin = PC_JuroDiario_Atrazo.Value,
                                                                                                                Tp_juro_fin = tp_juro.Text,
                                                                                                                Qt_diasdesdobro = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Parcelas_Dias_Desdobro,
                                                                                                                St_comentradabool = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_cometrada,
                                                                                                                Qt_parcelas = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).QTD_Parcelas
                                                                                                            },
                                                                                                            p.Vl_liquido));
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Vl_prevenda = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_subtotal + p.Vl_acrescimo + p.Vl_frete + p.Vl_juro_fin - p.Vl_desconto);
                //(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Vl_faturar = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => 
                //    (p.Quantidade - p.Qtd_faturada) * p.Vl_unitario + p.Vl_acrescimo - p.Vl_desconto + p.Vl_juro_fin + p.Vl_frete);
                bsPreVenda.ResetCurrentItem();
            }
        }

        private void AjustarDadosFinanceiros()
        {
            if (bsPreVenda.Current != null)
            {
                VL_Parcela.Enabled = true;
                Habilita_Data_Financeiro();
                if (!ST_ComEntrada.Checked)
                {
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto = CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Calcula_Parcelas(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, true);
                    vl_juro_fin.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_juro_fin);
                    vl_total.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Sum(p => p.Vl_parcela);
                }
                else if (ST_ComEntrada.Checked)
                {
                    VL_Entrada.Enabled = true;
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto = CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Calcula_Parcelas(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, true);
                    vl_juro_fin.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_juro_fin);
                    vl_total.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Sum(p => p.Vl_parcela);
                }

                else
                {
                    VL_Entrada.Enabled = false;
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.ForEach(p => (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_VentoDel.Add(p));
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Clear();
                }

                bsPreVenda.ResetCurrentItem();
            }
        }

        private void Habilita_Data_Financeiro()
        {
            if (bsPreVenda.Current != null)
            {
                if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S") &&
                    (ST_ComEntrada.Checked ? BS_PARCELAS.Position > 0 : true))
                {
                    diasvencimento.Enabled = true;
                    dt_vencto.Enabled = true;
                }
                else
                {
                    diasvencimento.Enabled = false;
                    dt_vencto.Enabled = false;
                }
            }
        }

        private void BS_PARCELAS_PositionChanged(object sender, EventArgs e)
        {
            if (BS_PARCELAS.Current != null)
            {
                if (ST_ComEntrada.Checked)
                {
                    if (BS_PARCELAS.Position.Equals(0))
                    {
                        diasvencimento.Enabled = false;
                        VL_Parcela.Enabled = false;
                    }
                    else
                    {
                        Habilita_Data_Financeiro();
                        VL_Parcela.Enabled = BS_PARCELAS.Position != (BS_PARCELAS.Count - 1); ;
                    }
                }
                else
                {
                    Habilita_Data_Financeiro();
                    VL_Parcela.Enabled = BS_PARCELAS.Position != (BS_PARCELAS.Count - 1);
                }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFDT_Vencto_PreVenda_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { rprevenda };
            vl_venda.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_subtotal + p.Vl_frete + p.Vl_acrescimo - p.Vl_desconto);
            vl_juro_fin.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_juro_fin);
            vl_devcred.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Vl_devcred;
            vl_total.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Sum(p => p.Vl_parcela);
            if (BS_PARCELAS.Count > 0)
                BB_CondPGTO.Select();
            //Buscar solicitação p/ alterar Dt.Vencto
            if (!string.IsNullOrEmpty(CD_CondPGTO.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.CD_CondPGTO",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_CondPGTO.Text.Trim() + "'"
                        }
                    }, "a.ST_SolicitarDTVencto");

                if (obj != null)
                {
                    if (obj.ToString().Equals("S"))
                    {
                        dt_vencto.Enabled = true;
                        diasvencimento.Enabled = true;
                    }
                }
            }
            //Verificar se Parcelas é a cartão
            if (St_cartao)
            {
                gDt_vencto.Visible = false;
                rgVencto.Visible = false;
                parcelasCartao.Location = new Point(6, 41);
            }
            else
                gId_parcela.Visible = false;
        }

        private void TFDT_Vencto_PreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                afterCancela();
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (BS_PARCELAS.Current != null)
            {
                (BS_PARCELAS.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto).Vl_parcela = VL_Parcela.Value;
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RecalculaParc(BS_PARCELAS.List as CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto,
                                                                         bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda,
                                                                         BS_PARCELAS.Position);
                BS_PARCELAS.ResetBindings(true);
                if (dt_vencto.Enabled)
                    dt_vencto.Focus();
            }
        }

        private void diasvencimento_Leave(object sender, EventArgs e)
        {
            if (BS_PARCELAS.Current != null)
            {
                (BS_PARCELAS.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto).DiasVencto = diasvencimento.Value;
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RecalcDiaVencto(BS_PARCELAS.List as CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto,
                                                                           QT_DIASDESDOBRO.Value,
                                                                           BS_PARCELAS.Position);
                BS_PARCELAS.ResetBindings(true);
                VL_Parcela.Focus();
            }
        }

        private void diasvencimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                diasvencimento_Leave(this, new EventArgs());
        }

        private void VL_Parcela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                VL_Parcela_Leave(this, new EventArgs());
        }

        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            if (BS_PARCELAS.Current != null)
            {
                TimeSpan ts = 
                    (Convert.ToDateTime(dt_vencto.Text).Subtract(Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"))));
                (BS_PARCELAS.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto).DiasVencto = ts.Days;
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RecalcDiaVencto(BS_PARCELAS.List as CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto,
                                                                           QT_DIASDESDOBRO.Value,
                                                                           BS_PARCELAS.Position);

                BS_PARCELAS.ResetBindings(true);
                diasvencimento.Focus();
            }
        }

        private void dt_vencto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dt_vencto_Leave(this, new EventArgs());
        }

        private void ST_ComEntrada_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_Entrada.Visible = ST_ComEntrada.Checked;
            VL_Entrada.Visible = ST_ComEntrada.Checked;
        }

        private void VL_Entrada_Leave(object sender, EventArgs e)
        {
            int position = 0;
            for (int x = 0; x < BS_PARCELAS.Count; x++)
            {
                if (x == 0)
                {
                    (BS_PARCELAS[x] as CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto).Vl_parcela = VL_Entrada.Value;
                    (BS_PARCELAS[x] as CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto).DiasVencto = decimal.Zero;
                    position = x;
                }
            }
            //Recalcular Parcelas
            CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RecalculaParc(BS_PARCELAS.List as CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto,
                                                                         bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda,
                                                                         position);
            //Recalcular Vencto
            CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RecalcDiaVencto(BS_PARCELAS.List as CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto,
                                                                           QT_DIASDESDOBRO.Value,
                                                                           position);

            BS_PARCELAS.ResetBindings(true);
        }
    }
}
