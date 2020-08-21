using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFTrocaEspecie : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pId_caixa
        { get; set; }
        public string pCd_contager
        { get; set; }
        public string pDs_contager
        { get; set; }
        public string pCd_historico
        { get; set; }
        public string pDs_historico
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie rTroca
        { get { return bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie; } }

        public TFTrocaEspecie()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque == null &&
                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura == null &&
                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete == null)
            {
                MessageBox.Show("Obrigatorio informar especie para realizar troca.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFTrocaEspecie_Load(object sender, EventArgs e)
        {
            bsTrocaEspecie.AddNew();
            cd_empresa.Text = pCd_empresa;
            nm_empresa.Text = pNm_empresa;
            id_caixa.Text = pId_caixa;
            (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Cd_contager = pCd_contager;
            (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Cd_historico = pCd_historico;
        }

        private void bb_cheque_Click(object sender, EventArgs e)
        {
            using (Financeiro.TFLanTitulo fTitulo = new Financeiro.TFLanTitulo())
            {
                fTitulo.Cd_empresa = pCd_empresa;
                fTitulo.Tp_titulo = "R";
                fTitulo.Cd_contager = pCd_contager;
                fTitulo.Ds_contager = pDs_contager;
                fTitulo.Cd_historico = pCd_historico;
                fTitulo.Ds_historico = pDs_historico;
                fTitulo.CD_Empresa.Enabled = false;
                fTitulo.BB_Empresa.Enabled = false;
                fTitulo.tp_titulo.Enabled = false;
                if(fTitulo.ShowDialog() == DialogResult.OK)
                    if (fTitulo.BS_Titulo.Current != null)
                    {
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura = null;
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete = null;
                        bb_cartao.Text = "Trocar Cartão";
                        bb_cartafrete.Text = "Trocar Carta Frete";
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque =
                            fTitulo.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo;
                        //Calcular taxa administrativa
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "isnull(a.pc_txtroca, 0)");
                        if (obj != null)
                            if (decimal.Parse(obj.ToString()) > decimal.Zero)
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin = 
                                    Math.Round(decimal.Divide(decimal.Multiply((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque.Vl_titulo, decimal.Parse(obj.ToString())), 100), 2);
                        if((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.Equals(decimal.Zero))
                            using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                            {
                                fValor.Casas_decimais = 2;
                                fValor.Vl_saldo = (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque.Vl_titulo;
                                fValor.Ds_label = "Taxa Administrativa";
                                if (fValor.ShowDialog() == DialogResult.OK)
                                    (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin = fValor.Quantidade;
                            }
                        bb_cheque.Text = bb_cheque.Text + "\r\n" + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("en-US")) +
                            ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin > decimal.Zero ? 
                            "\r\nTaxa Adm.: " + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.ToString("N2", new System.Globalization.CultureInfo("en-US")) : string.Empty);
                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                        {
                            fTroco.Cd_empresa = pCd_empresa;
                            fTroco.Id_caixaPDV = pId_caixa;
                            fTroco.Vl_troco = (fTitulo.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Vl_titulo - 
                                              (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin;
                            fTroco.St_desativarCred = true;
                            if (fTroco.ShowDialog() == DialogResult.OK)
                            {
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_trocoD = fTroco.Vl_trocoDinheiro;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHP = fTroco.lChTroco;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHT = fTroco.lChRepasse;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar valor total troco para especie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque = null;
                                bb_cheque.Text = "Trocar Cheque";
                            }
                        }
                    }
            }
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            using (Financeiro.TFFaturaCartao fFatura = new Financeiro.TFFaturaCartao())
            {
                fFatura.Cd_empresa = pCd_empresa;
                fFatura.Tp_movimento = "R";
                if(fFatura.ShowDialog() == DialogResult.OK)
                    if (fFatura.lFatura != null)
                    {
                        fFatura.lFatura[0].Cd_contager = pCd_contager;
                        fFatura.lFatura[0].Cd_historico = pCd_historico;
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque = null;
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete = null;
                        bb_cheque.Text = "Trocar Cheque";
                        bb_cartafrete.Text = "Trocar Carta Frete";
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura = fFatura.lFatura[0];
                        //Calcular taxa administrativa
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.st_cartaocredito",
                                                vOperador = "=",
                                                vVL_Busca = "0"
                                            }
                                        }, "isnull(a.pc_txtroca, 0)");
                        if (obj != null)
                            if (decimal.Parse(obj.ToString()) > decimal.Zero)
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin =
                                    Math.Round(decimal.Divide(decimal.Multiply((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque.Vl_titulo, decimal.Parse(obj.ToString())), 100), 2);
                        if ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.Equals(decimal.Zero))
                            using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                            {
                                fValor.Casas_decimais = 2;
                                fValor.Vl_saldo = (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura.Vl_fatura;
                                fValor.Ds_label = "Taxa Administrativa";
                                if (fValor.ShowDialog() == DialogResult.OK)
                                    (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin = fValor.Quantidade;
                            }
                        bb_cartao.Text = bb_cartao.Text + "\r\n" + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura.Vl_fatura.ToString("C2", new System.Globalization.CultureInfo("en-US")) +
                            ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin > decimal.Zero ?
                            "\r\nTaxa Adm.: " + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.ToString("N2", new System.Globalization.CultureInfo("en-US")) : string.Empty);
                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                        {
                            fTroco.Cd_empresa = pCd_empresa;
                            fTroco.Id_caixaPDV = pId_caixa;
                            fTroco.Vl_troco = (fFatura.lFatura[0] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Vl_fatura -
                                              (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin;
                            fTroco.St_desativarCred = true;
                            if (fTroco.ShowDialog() == DialogResult.OK)
                            {
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_trocoD = fTroco.Vl_trocoDinheiro;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHP = fTroco.lChTroco;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHT = fTroco.lChRepasse;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar valor total troco para especie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura = null;
                                bb_cartao.Text = "Trocar Cartão";
                            }
                        }
                    }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTrocaEspecie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cartafrete_Click(object sender, EventArgs e)
        {
            using (TFCartaFrete fCFrete = new TFCartaFrete())
            {
                fCFrete.Cd_empresa = pCd_empresa;
                fCFrete.Nm_empresa = pNm_empresa;
                if (fCFrete.ShowDialog() == DialogResult.OK)
                    if (fCFrete.rCF != null)
                    {
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque = null;
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rFatura = null;
                        bb_cheque.Text = "Trocar Cheque";
                        bb_cartao.Text = "Trocar Cartão";
                        (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete = fCFrete.rCF;
                        //Calcular taxa administrativa
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "a.pc_txtroca");
                        if (obj != null)
                            if (decimal.Parse(obj.ToString()) > decimal.Zero)
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin =
                                    Math.Round(decimal.Divide(decimal.Multiply((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCheque.Vl_titulo, decimal.Parse(obj.ToString())), 100), 2);
                        if ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.Equals(decimal.Zero))
                            using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                            {
                                fValor.Casas_decimais = 2;
                                fValor.Vl_saldo = (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete.Vl_documento;
                                fValor.Ds_label = "Taxa Administrativa";
                                if (fValor.ShowDialog() == DialogResult.OK)
                                    (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin = fValor.Quantidade;
                            }
                        bb_cartafrete.Text = bb_cartafrete.Text + "\r\n" + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete.Vl_documento.ToString("C2", new System.Globalization.CultureInfo("en-US")) +
                            ((bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin > decimal.Zero ?
                            "\r\nTaxa Adm.: " + (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin.ToString("N2", new System.Globalization.CultureInfo("en-US")) : string.Empty);
                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                        {
                            fTroco.Cd_empresa = pCd_empresa;
                            fTroco.Id_caixaPDV = pId_caixa;
                            fTroco.Vl_troco = fCFrete.rCF.Vl_documento - (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_TaxaFin;
                            fTroco.St_desativarCred = true;
                            if (fTroco.ShowDialog() == DialogResult.OK)
                            {
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).Vl_trocoD = fTroco.Vl_trocoDinheiro;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHP = fTroco.lChTroco;
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).lTrocoCHT = fTroco.lChRepasse;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar valor total troco para especie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsTrocaEspecie.Current as CamadaDados.Faturamento.PDV.TRegistro_TrocaEspecie).rCartaFrete = null;
                                bb_cartafrete.Text = "Trocar Carta Frete";
                            }
                        }
                    }
            }
        }
    }
}
