using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Querys;
using Querys.Financeiro;

namespace Financeiro.Cadastros
{
    public partial class TFCadCondPgto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCondPgto()
        {
            InitializeComponent();
            
        }

        public override int buscarRegistros()
        {
            pDados.prepararBusca(pDados, ref this.vTP_Busca);
            TDatCondPgto qtb_busca = new TDatCondPgto();
            this.gCadastro.DataSource = qtb_busca.Buscar(this.vTP_Busca, 0);
            UtilPesquisa.CarregarPanel(this.pDados, this.gCadastro, Utils.TTpModo.tm_Standby);
            if (this.gCadastro.DataSource != null)
            {
                this.Tb_relatorio = (gCadastro.DataSource as DataTable);
                return (this.gCadastro.DataSource as DataTable).Rows.Count;
            }
            else
                return -1;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            base.afterNovo();
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert)||(this.vTP_Modo == Utils.TTpModo.tm_Edit))
            {
                QT_DIASDESDOBRO.Enabled = false;
                ST_VenctoEmFeriado.Enabled = false;
                ST_ComEntrada.Enabled = false;
                if (!(this.CD_CondPGTO.Focus()))
                    this.DS_CondPgto.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
            {
                QT_DIASDESDOBRO.Enabled = ((!ST_SolicitarDTVencto.Checked) || (QT_Parcelas.Value > 0));
                ST_ComEntrada.Enabled = (QT_Parcelas.Value > 1);
                ST_VenctoEmFeriado.Enabled = (QT_Parcelas.Value > 0);
                this.DS_CondPgto.Focus();
            }
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Descrição Portador|350;" +
                              "CD_Portador|Cód. Portador|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Portador, ds_portador },
                                    new TDatPortador(), "");
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            if (CD_Portador.Text.Trim() != "")
            {
                string vColunas = CD_Portador.NM_CampoBusca + "|=|'" + CD_Portador.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Portador, ds_portador },
                                        new TDatPortador());
            }
            else
                ds_portador.Clear();
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|350;" +
                              "CD_Moeda|Cód. Moeda|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                    new TDatMoeda(), "");
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            if (CD_Moeda.Text.Trim() != "")
            {
                string vColunas = CD_Moeda.NM_CampoBusca + "|=|'" + CD_Moeda.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                        new TDatMoeda());
            }
            else
                ds_moeda.Clear();
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Juro|Descrição Juro|350;" +
                              "CD_Juro|Cód. Juro|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Juro, ds_juro },
                                    new TDatJuro(), "");
        }

        private void CD_Juro_Leave(object sender, EventArgs e)
        {
            if (CD_Juro.Text.Trim() != "")
            {
                string vColunas = CD_Juro.NM_CampoBusca + "|=|'" + CD_Juro.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Juro, ds_juro },
                                        new TDatJuro());
            }
            else
                ds_juro.Clear();
        }

        private void gCadastro_CurrentCellChanged(object sender, EventArgs e)
        {
            UtilPesquisa.CarregarPanel(this.pDados, this.gCadastro, Utils.TTpModo.tm_Standby);
        }

        private void QT_Parcelas_ValueChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
            {
                QT_DIASDESDOBRO.Enabled = (QT_Parcelas.Value > 0);
                ST_ComEntrada.Enabled = (QT_Parcelas.Value > 1);
                ST_VenctoEmFeriado.Enabled = (QT_Parcelas.Value > 0);
                if (CD_Portador.Text.Trim() != "")
                {
                    Utils.TpBusca[] vBusca = new Utils.TpBusca[1];
                    vBusca[0].vNM_Campo = "CD_Portador";
                    vBusca[0].vVL_Busca = "'" + CD_Portador.Text.Trim() + "'";
                    vBusca[0].vOperador = "=";
                    DataTable tb_portador = new TDatPortador().Buscar(vBusca, 1);
                    if (tb_portador != null)
                        if (tb_portador.Rows.Count > 0)
                        {
                            decimal min = Convert.ToDecimal(tb_portador.Rows[0]["QT_Min_Parc"].ToString());
                            decimal max = Convert.ToDecimal(tb_portador.Rows[0]["QT_Max_Parc"].ToString());
                            if ((min > 0)&&(QT_Parcelas.Value < min))
                            {
                                MessageBox.Show("Quantidade de parcelas menor que o minimo exigido pelo portador.\r\n" +
                                                "Portador: " + CD_Portador.Text.Trim() + " - " + ds_portador.Text.Trim() + "\r\n" +
                                                "Nº Minimo Parcelas: " + min + "\r\n" +
                                                "Nº Maximo Parcelas: " + max + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                QT_Parcelas.Value = 0;
                                QT_Parcelas.Focus();
                                return;
                            }
                            if ((max > 0)&&(QT_Parcelas.Value > max))
                            {
                                MessageBox.Show("Quantidade de parcelas maior que o maximo exigido pelo portador.\r\n" +
                                                "Portador: " + CD_Portador.Text.Trim() + " - " + ds_portador.Text.Trim() + "\r\n" +
                                                "Nº Minimo Parcelas: " + min + "\r\n" +
                                                "Nº Maximo Parcelas: " + max + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                QT_Parcelas.Value = 0;
                                QT_Parcelas.Focus();
                                return;
                            }
                        }
                }
            }
        }
                
        private void ST_ComEntrada_EnabledChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
                if (!(ST_ComEntrada.Enabled))
                  ST_ComEntrada.Checked = false;
        }

        private void ST_VenctoEmFeriado_EnabledChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
                if (!(ST_VenctoEmFeriado.Enabled))
                    ST_VenctoEmFeriado.Checked = false;
        }

        public override void afterPrint()
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Altera_Relatorio = Altera_Relatorio;
            Relatorio.Nome_Relatorio = "TFCadCondPgto";
            BindingSource Bs_CondPagto = new BindingSource();
            Bs_CondPagto.DataSource = (gCadastro.DataSource as DataTable);
            Relatorio.DTS_Relatorio = Bs_CondPagto;
            Relatorio.Gera_Relatorio();
        }

        private void ST_SincronizarSite_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
                if (!(ST_SincronizarSite.Enabled))
                    ST_SincronizarSite.Checked = false;
        }
    }
}

