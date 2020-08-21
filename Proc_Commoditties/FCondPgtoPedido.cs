using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFCondPgtoPedido : Form
    {
        private CamadaDados.Faturamento.Pedido.TRegistro_Pedido rped;
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed
        {
            get
            {
                if (bsPedido.Current != null)
                    return bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido;
                else
                    return null;
            }
            set { rped = value; }
        }

        public TFCondPgtoPedido()
        {
            InitializeComponent();
        }

        private void Habilita_Data_Financeiro()
        {
            edtDt_Vencto.Enabled = (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S") &&
                (ST_ComEntrada.Checked ? BS_Parcelas.Position > 0 : true);
        }

        private void AjustarDadosFinanceiros()
        {
            Habilita_Data_Financeiro();
            if (!ST_ComEntrada.Checked)
            {
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Calcula_Parcelas(bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido);
                bsPedido.ResetCurrentItem();
                BS_Parcelas_PositionChanged(this, new EventArgs());
            }
            else
            {
                BS_Parcelas.Clear();
                bsPedido.ResetCurrentItem();
            }
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se condicao de pagamento para o vendedor
            object obj = null;
            if (!string.IsNullOrEmpty((bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam = "|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                         "          where x.cd_condpgto = a.cd_condpgto " +
                         "          and x.cd_vendedor = '" + (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;a.QT_Parcelas|Quantidade Parcelas|40;" +
            "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;a.ST_VenctoEmFeriado|Vence em Feriado|40;a.cd_condPGTO|Código|100;a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            CD_CondPGTO_Leave(this, new EventArgs());            
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "'";
            object obj = null;
            if (!string.IsNullOrEmpty((bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                          "             where x.cd_condpgto = a.cd_condpgto " +
                          "             and x.cd_vendedor = '" + (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Cd_vendedor + "')";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO },
             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Parcelas_Dias_Desdobro = decimal.Parse(linha["qt_diasdesdobro"].ToString());
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Parcelas_Entrada = linha["st_comentrada"].ToString();
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Parcelas_Feriado = linha["ST_VenctoEmFeriado"].ToString();
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).ST_SolicitarDtVencto = linha["ST_SolicitarDtVencto"].ToString();
                Parcelas.Value = Convert.ToDecimal(linha["qt_parcelas"].ToString());
                QT_DIASDESDOBRO.Value = Convert.ToDecimal(linha["qt_diasdesdobro"].ToString());
                ST_ComEntrada.Checked = linha["st_comentrada"].ToString().Trim().ToUpper().Equals("S");
                cd_juro_fin.Text = linha["cd_juro_fin"].ToString();
                ds_juro_fin.Text = linha["ds_juro_fin"].ToString();
                PC_JuroDiario_Atrazo.Value = linha["pc_juroDiario_atrazoFin"].ToString().Equals("") ? 0 : Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                tp_juro.Text = linha["tp_juro"].ToString();
            }
            else
            {
                Parcelas.Value = 0;
                QT_DIASDESDOBRO.Value = 0;
                ST_ComEntrada.Checked = false;
                cd_juro_fin.Clear();
                ds_juro_fin.Clear();
                PC_JuroDiario_Atrazo.Value = 0;
            }
            this.AjustarDadosFinanceiros();
        }

        private void TFCondPgtoPedido_Load(object sender, EventArgs e)
        {
            this.pCondPgto.set_FormatZero();
            bsPedido.DataSource = new CamadaDados.Faturamento.Pedido.TList_Pedido() { rped };
        }

        private void BS_Parcelas_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Parcelas.Current != null)
            {
                if (ST_ComEntrada.Checked)
                {
                    if (BS_Parcelas.Position.Equals(0))
                    {
                        edtDt_Vencto.Enabled = false;
                        VL_Parcela.Enabled = false;
                    }
                    else
                    {
                        Habilita_Data_Financeiro();
                        VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1); ;
                    }
                }
                else
                {
                    Habilita_Data_Financeiro();
                    VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1);
                }
            }
        }

        private void VL_Entrada_Leave(object sender, EventArgs e)
        {
            decimal _VL_Entrada = VL_Entrada.Value;

            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Calcula_Parcelas(bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido);

            for (int x = 0; x < (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedidos_DT_Vencto.Count; x++)
            {
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Entrada = VL_Entrada.Value;
                if (x == 0)
                    (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Parcela = VL_Entrada.Value;
            }

            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Recalcula_Parcelas(bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, 0);
            bsPedido.ResetCurrentItem();
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedidos_DT_Vencto[BS_Parcelas.Position].VL_Parcela = VL_Parcela.Value;
            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Recalcula_Parcelas(bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, BS_Parcelas.Position);
            bsPedido.ResetCurrentItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFCondPgtoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
        }
    }
}
