using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFTrocoPDV : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Cd_historioTroco
        { get; set; }
        public string Ds_historicoTroco
        { get; set; }
        public string Id_caixaPDV
        { get; set; }
        public decimal Vl_troco
        { get; set; }
        public bool St_desativarCred
        { get; set; }

        public decimal Vl_trocoDinheiro
        { get; set; }
        public decimal Vl_trocoCredito
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lChRepasse
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lChTroco
        { get; set; }

        public TFTrocoPDV()
        {
            InitializeComponent();
        }

        private void TrocoDinheiro()
        {
            if (vl_saldo.Value > decimal.Zero)
                using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                {
                    fValor.Casas_decimais = 2;
                    fValor.Vl_saldo = vl_saldo.Value;
                    fValor.Vl_default = vl_saldo.Value;
                    if (fValor.ShowDialog() == DialogResult.OK)
                    {
                        Vl_trocoDinheiro = fValor.Quantidade;
                        bb_dinheiro.Text = "(F1)\nDINHEIRO\nR$" + Vl_trocoDinheiro.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        vl_saldo.Value = Vl_troco - Vl_trocoDinheiro - Vl_trocoCredito - 
                            (lChRepasse != null ? lChRepasse.Sum(p => p.Vl_titulo) : decimal.Zero) -
                            (lChTroco != null ? lChTroco.Sum(p => p.Vl_titulo) : decimal.Zero);
                        if (vl_saldo.Value.Equals(decimal.Zero))
                            this.DialogResult = DialogResult.OK;
                    }
                }
        }

        private void TrocoCredito()
        {
            if (vl_saldo.Value > decimal.Zero)
                using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                {
                    fValor.Casas_decimais = 2;
                    fValor.Vl_saldo = vl_saldo.Value;
                    fValor.Vl_default = vl_saldo.Value;
                    if (fValor.ShowDialog() == DialogResult.OK)
                    {
                        Vl_trocoCredito = fValor.Quantidade;
                        bb_credito.Text = "(F2)\nCREDITO\nR$" + Vl_trocoCredito.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        vl_saldo.Value = Vl_troco - Vl_trocoDinheiro - Vl_trocoCredito - 
                            (lChRepasse != null ? lChRepasse.Sum(p => p.Vl_titulo) : decimal.Zero) -
                            (lChTroco != null ? lChTroco.Sum(p => p.Vl_titulo) : decimal.Zero);
                        if (vl_saldo.Value.Equals(decimal.Zero))
                            this.DialogResult = DialogResult.OK;
                    }
                }
        }

        private void TrocoChTerceiro()
        {
            if(vl_saldo.Value > decimal.Zero)
                using (Financeiro.TFConsultaTitulosRecebidos fCh = new Financeiro.TFConsultaTitulosRecebidos())
                {
                    fCh.Id_caixaPDV = this.Id_caixaPDV;
                    fCh.Cd_empresa = this.Cd_empresa;
                    fCh.Cd_contager = this.Cd_contager;
                    fCh.Vl_conciliar = vl_saldo.Value;
                    if(fCh.ShowDialog() == DialogResult.OK)
                        if(fCh.lChRepasse != null)
                            if (fCh.lChRepasse.Count > 0)
                            {
                                lChRepasse = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
                                fCh.lChRepasse.ForEach(p => lChRepasse.Add(p));
                                bb_chTerceiro.Text = "(F3)\nCH TERCEIRO\nR$" + lChRepasse.Sum(p => p.Vl_titulo).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                                vl_saldo.Value = Vl_troco - Vl_trocoDinheiro - Vl_trocoCredito - lChRepasse.Sum(p => p.Vl_titulo) - 
                                    (lChTroco != null ? lChTroco.Sum(p => p.Vl_titulo) : decimal.Zero);
                                if (vl_saldo.Value.Equals(decimal.Zero))
                                    this.DialogResult = DialogResult.OK;
                            }
                }
        }

        private void TrocoChProprio()
        {
            if (vl_saldo.Value > decimal.Zero)
            {
                if(new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_chtrocodireto, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") == null)
                    using (TFListaChTroco fCh = new TFListaChTroco())
                    {
                        fCh.Cd_empresa = Cd_empresa;
                        fCh.Vl_troco = vl_saldo.Value;
                        if (fCh.ShowDialog() == DialogResult.OK)
                            if (fCh.lCh != null)
                                if (fCh.lCh.Count > 0)
                                {
                                    lChTroco = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
                                    fCh.lCh.ForEach(p => lChTroco.Add(p));
                                    bb_ChTroco.Text = "(F4)\nCH TROCO\nR$" + lChTroco.Sum(p => p.Vl_titulo).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                                    vl_saldo.Value = Vl_troco - Vl_trocoDinheiro - Vl_trocoCredito -
                                        (lChRepasse != null ? lChRepasse.Sum(p => p.Vl_titulo) : decimal.Zero) -
                                        lChTroco.Sum(p => p.Vl_titulo);
                                    if (vl_saldo.Value.Equals(decimal.Zero))
                                        this.DialogResult = DialogResult.OK;
                                }
                    }
                else
                    using (Financeiro.TFLanTitulo fCheque = new Financeiro.TFLanTitulo())
                    {
                        fCheque.CD_Empresa.Enabled = false;
                        fCheque.BB_Empresa.Enabled = false;
                        fCheque.tp_titulo.Enabled = false;
                        fCheque.nr_lanctocheque.Enabled = false;
                        fCheque.DT_Pgto.Enabled = false;

                        //SETAR AS PROPRIEDADES NAO EDITAVEIS PELO USUARIO
                        fCheque.Cd_empresa = this.Cd_empresa;
                        fCheque.Cd_historico = this.Cd_historioTroco;
                        fCheque.Ds_historico = this.Ds_historicoTroco;
                        fCheque.Vl_titulo = vl_saldo.Value;
                        fCheque.pVl_saldo = vl_saldo.Value;
                        fCheque.Tp_titulo = "P";
                        fCheque.St_bloquearTroco = true;
                        fCheque.pIndexCheque = lChTroco == null ? decimal.Zero : lChTroco.Count;
                        if (fCheque.ShowDialog() == DialogResult.OK)
                            if (fCheque.BS_Titulo.Current != null)
                            {
                                if (lChTroco == null)
                                    lChTroco = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
                                lChTroco.Add(fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
                                bb_ChTroco.Text = "(F4)\nCH TROCO\nR$" + lChTroco.Sum(p => p.Vl_titulo).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                                vl_saldo.Value = Vl_troco - Vl_trocoDinheiro - Vl_trocoCredito -
                                    (lChRepasse != null ? lChRepasse.Sum(p => p.Vl_titulo) : decimal.Zero) -
                                    lChTroco.Sum(p => p.Vl_titulo);
                                if (vl_saldo.Value.Equals(decimal.Zero))
                                    this.DialogResult = DialogResult.OK;
                            }
                    }
            }
        }

        private void TFTrocoPDV_Load(object sender, EventArgs e)
        {
            this.vl_troco.Value = Vl_troco;
            this.vl_saldo.Value = Vl_troco;
            bb_credito.Enabled = !St_desativarCred;
        }

        private void bb_dinheiro_Click(object sender, EventArgs e)
        {
            this.TrocoDinheiro();
        }

        private void bb_credito_Click(object sender, EventArgs e)
        {
            this.TrocoCredito();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_chTerceiro_Click(object sender, EventArgs e)
        {
            this.TrocoChTerceiro();
        }

        private void bb_ChTroco_Click(object sender, EventArgs e)
        {
            this.TrocoChProprio();
        }

        private void TFTrocoPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
                this.TrocoDinheiro();
            else if (e.KeyCode.Equals(Keys.F2) && bb_credito.Enabled)
                this.TrocoCredito();
            else if (e.KeyCode.Equals(Keys.F3))
                this.TrocoChTerceiro();
            else if (e.KeyCode.Equals(Keys.F4))
                this.TrocoChProprio();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
