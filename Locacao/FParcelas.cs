using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFParcelas : Form
    {
        public decimal Vl_locacao
        { get; set; }
        private CamadaDados.Locacao.TRegistro_Locacao rlocacao;
        public CamadaDados.Locacao.TRegistro_Locacao rLocacao
        {
            get
            {
                if (bsLocacao.Current != null)
                    return bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                else
                    return null;
            }
            set { rlocacao = value; }
        }
        public bool St_bloquearValor
        { get; set; }
        public TFParcelas()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (BS_Parcelas.Count.Equals(decimal.Zero))
            {
                MessageBox.Show("Não existem parcelas calculadas!.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CalcularParcelas(bool st_recalcular)
        {
            //Buscar data calculo de parcelas
            object obj =
            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                                        "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + ") )order by a.DT_Vencto desc -- "
                                                        }
                                                    }, "a.DT_Vencto");
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_parcela = Convert.ToDateTime(obj);
            else
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_parcela = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacao;
            DateTime? dt_ini = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Where(p =>
                p.Tp_tabela.Equals("4")).Min(p => string.IsNullOrEmpty(p.Dt_retiradastr) ? p.Dt_locacao : p.Dt_retirada);
            DateTime? dt_fin = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Where(p =>
                p.Tp_tabela.Equals("4")).Max(p => string.IsNullOrEmpty(p.Dt_fechamentostr) ?
                                                 (p.Dt_prevdev < CamadaDados.UtilData.Data_Servidor() ? CamadaDados.UtilData.Data_Servidor() : p.Dt_prevdev) :
                                                 p.Dt_fechamento);
            TimeSpan ts = dt_fin.Value.Subtract(dt_ini.Value);

            //Calcular valor total
            decimal valor = decimal.Zero;
            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).SaldoFaturar > decimal.Zero)
                valor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).SaldoFaturar; 
            else
                valor = Math.Truncate(Math.Round(decimal.Parse(ts.TotalDays.ToString()), 2) / 30) * Vl_locacao + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p =>
                           p.Tp_tabela.Equals("4")).Sum(p => p.Vl_frete) - (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Vl_faturado; 
            decimal vl_parcela = decimal.Zero;
            if (st_ratearDespesas.Checked)
            {
                //Calcular valor vl.locação mensal
                vl_parcela = Vl_locacao + ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p =>
                               p.Tp_tabela.Equals("4")).Sum(p => p.Vl_frete) / (Math.Round(decimal.Parse(ts.TotalDays.ToString()), 2) / 30));
            }
            else
                vl_parcela = Vl_locacao;

            //Calcular QTD.Parcelas 
            decimal Qtd_parcFat = Math.Truncate(Math.Round(decimal.Parse(ts.TotalDays.ToString()), 2) / 30) - 
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lDup.Where(p=> p.St_registro.ToUpper().Equals("A")).Count();
            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc =
                CamadaNegocio.Locacao.TCN_Locacao.Calcula_Parcelas(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao,
                st_recalcular ? Parcelas.Value :  Qtd_parcFat, vl_parcela, valor, st_recalcular, st_ratearDespesas.Checked);
            vl_total.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p => p.Vl_parcela);
            if (!st_recalcular)
                Parcelas.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Count;
            vl_despesas.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p =>
                           p.Tp_tabela.Equals("4")).Sum(p => p.Vl_frete);
            bsLocacao.ResetCurrentItem();
        }

        private void afterCancela()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDT_Vencto_PreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.afterCancela();
        }


        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            if (BS_Parcelas.Current != null)
            {
                TimeSpan ts =
                    (Convert.ToDateTime(dt_vencto.Text).Subtract(Convert.ToDateTime((BS_Parcelas.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).Dt_locacao.Value.ToString("dd/MM/yyyy"))));
                (BS_Parcelas.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).DiasVencto = ts.Days;
                CamadaNegocio.Locacao.TCN_Locacao.RecalcDiaVencto(BS_Parcelas.List as CamadaDados.Locacao.TList_ParcelaLocacao, BS_Parcelas.Position);

                BS_Parcelas.ResetBindings(true);
            }
        }

        private void dt_vencto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dt_vencto_Leave(this, new EventArgs());
        }

        private void TFParcelas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_total.Enabled = !St_bloquearValor;
            bsLocacao.DataSource = new CamadaDados.Locacao.TList_Locacao { rlocacao };
            this.CalcularParcelas(false);
            //Busca Obs Cliente
            object obj =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                 new TpBusca[]
                 {
                     new TpBusca()
                     {
                         vNM_Campo = "a.cd_clifor",
                         vOperador = "=",
                         vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor.Trim() + "'"
                     }
                 }, "a.ds_observacao");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                ds_observacao.Text = obj.ToString();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            BS_Parcelas.MoveNext();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            BS_Parcelas.MovePrevious();
        }

        private void vl_total_Leave(object sender, EventArgs e)
        {
            if (BS_Parcelas.Count > 0)
            {
                if (!string.IsNullOrEmpty((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_vendedor))
                {
                    if (vl_total.Value > decimal.Zero)
                    {
                        //Buscar lista de descontos configuradas para o vendedor
                        CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                            CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_vendedor,
                                                                                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                        decimal vl_desconto = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p=> p.Vl_parcela) - vl_total.Value;
                        decimal pc_desconto = vl_desconto * 100 / (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p => p.Vl_parcela);
                        //Verificar se cliente possui desconto especial.
                        if (vl_desconto > decimal.Zero)
                            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_desconto) > decimal.Zero)
                            {
                                MessageBox.Show("Não é possível aplicar desconto porque cliente possui desconto especial!", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                vl_total.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p => p.Vl_parcela);
                                return;
                            }

                        //Desconto por vendedor e empresa
                        if (lDesc.Count > 0)
                        {
                            if (pc_desconto > lDesc[0].Pc_max_desconto)
                            {
                                MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                                    fLogin.Pc_desc = pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                    {
                                        vl_total.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p => p.Vl_parcela);
                                        return;
                                    }
                                }
                            }
                        }
                        CamadaNegocio.Locacao.TCN_Locacao.RatearDesconto(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, vl_desconto);
                        CamadaNegocio.Locacao.TCN_Locacao.RecalcularParc(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, vl_total.Value);
                        BS_Parcelas.ResetBindings(true);
                    }
                }
                else
                {
                    MessageBox.Show("Obrigatório informar vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_total.Value = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc.Sum(p => p.Vl_parcela);
                }
            }
            else
                MessageBox.Show("Obrigatório possuir parcelas para calculo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Parcelas_Leave(object sender, EventArgs e)
        {
            if (BS_Parcelas.Count > 0)
            {
                if (Parcelas.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Nº de parcelas não pode ser igual a zero!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Parcelas.Value = BS_Parcelas.Count;
                    return;
                }
                this.CalcularParcelas(true);
            }
        }

        private void st_ratearDespesas_CheckedChanged(object sender, EventArgs e)
        {
            this.CalcularParcelas(false);
        }
    }
}
