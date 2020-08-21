using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;

namespace Proc_Commoditties
{
    public partial class TFLanCompDevol_NF : Form
    {
        public TList_LanFat_ComplementoDevolucao ListaCompDev { get; set; }

        public TList_LanFat_ComplementoDevolucao lCompDevMemoria { get; set; }
                
        public string Nr_pedido
        {
            get;
            set;
        }
        public string Cd_empresa
        {
            get;
            set;
        }
        public string Cd_produto
        {
            get;
            set;
        }
        public string Cd_clifor
        {
            get;
            set;
        }
        public string Tp_operacao
        {
            get;
            set;
        }
        public string Tp_movimento
        {
            get;
            set;
        }
        public decimal Quantidade
        {
            get;
            set;
        }
        public decimal Valor
        {
            get;
            set;
        }
        public decimal Tot_quantidade
        {
            get;
            set;
        }
        public decimal Tot_valor
        {
            get;
            set;
        }
        public bool St_vldevNfOrigem
        { get; set; }
        public bool St_devContratoFixar
        { get; set; }

        public TFLanCompDevol_NF()
        {
            InitializeComponent();
            St_vldevNfOrigem = false;
            lCompDevMemoria = new TList_LanFat_ComplementoDevolucao();
        }

        private decimal totalQtdCompDev()
        {
            decimal retorno = 0;
            bsCompDev.Position = 0;
            for (int i = 0; i < bsCompDev.Count; i++)
                retorno += (bsCompDev[i] as TRegistro_LanFat_ComplementoDevolucao).Qtd_lancto;
            Tot_quantidade = retorno;
            return retorno;
        }

        private decimal totalVlCompDev()
        {
            decimal retorno = 0;
            bsCompDev.Position = 0;
            for (int i = 0; i < bsCompDev.Count; i++)
                retorno += (bsCompDev[i] as TRegistro_LanFat_ComplementoDevolucao).Vl_lancto;
            Tot_valor = retorno;
            return retorno;
        }

        private bool Contains(TRegistro_LanFat_ComplementoDevolucao val)
        {
            for (int i = 0; i < bsCompDev.Count; i++)
                if (((bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Cd_empresa == val.Cd_empresa) &&
                   ((bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Nr_lanctofiscal_origem == val.Nr_lanctofiscal_origem))
                    return true;
            return false;
        }

        private void validarQtdCompDev()
        {
            if (Tp_operacao.Trim().Equals("D"))
            {
                //Validar se quantidade não é maior que o saldo da nota a devolver
                if (qtd_lancto.Value > (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtddevolver)
                    qtd_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtddevolver;
                //Validar se quantidade não é maior que o saldo restante a devolver/complementar
                if (saldo_quantidade.Value == 0)
                    qtd_lancto.Value = 0;
                else
                    if (qtd_lancto.Value > saldo_quantidade.Value)
                        qtd_lancto.Value = saldo_quantidade.Value;
            }
            else if (Tp_operacao.Trim().Equals("E"))
            {
                if (qtd_lancto.Value > (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtentregafutura)
                    qtd_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtentregafutura;
                //Validar se quantidade não é maior que o saldo restante a devolver/complementar
                if (saldo_quantidade.Value == 0)
                    qtd_lancto.Value = 0;
                else
                    if (qtd_lancto.Value > saldo_quantidade.Value)
                        qtd_lancto.Value = saldo_quantidade.Value;
            }
        }

        private void validarVlCompDev()
        {
            if (Tp_operacao.Trim().Equals("D"))
            {
                //Validar se valor não é maior que o saldo da nota a devolver
                if (vl_lancto.Value > (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vldevolver)
                    vl_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vldevolver;
                if (!St_vldevNfOrigem)
                {
                    //Validar se valor não é maior que o saldo restante a devolver/complementar
                    if (saldo_valor.Value == 0)
                        vl_lancto.Value = 0;
                    else
                        if (vl_lancto.Value > saldo_valor.Value)
                            vl_lancto.Value = saldo_valor.Value;
                }
            }
            else if(Tp_operacao.Trim().Equals("E"))
            {
                if (vl_lancto.Value > (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vlentregaturura)
                    vl_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vlentregaturura;
                //Validar se quantidade não é maior que o saldo restante a devolver/complementar
                if (saldo_valor.Value == 0)
                    vl_lancto.Value = 0;
                else
                    if (vl_lancto.Value > saldo_valor.Value)
                        vl_lancto.Value = saldo_valor.Value;
            }
        }

        private void FLanCompDevol_NF_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCompDev);
            Utils.ShapeGrid.RestoreShape(this, gNotasCompDev);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            bb_autocompletar.Enabled = Tp_operacao.Trim().ToUpper().Equals("D") || Tp_operacao.Trim().ToUpper().Equals("E");
            List<TRegistro_NFCompDev> ret = TCN_LanFat_ComplementoDevolucao.Buscar(Cd_empresa, 
                                                                                   Nr_pedido, 
                                                                                   Cd_produto, 
                                                                                   Cd_clifor, 
                                                                                   Tp_movimento, 
                                                                                   Tp_operacao, 
                                                                                   St_devContratoFixar,
                                                                                   0, 
                                                                                   string.Empty, 
                                                                                   null);
            lCompDevMemoria.ForEach(x =>
            {
                var obj = ret.FirstOrDefault(v => v.Cd_empresa.Trim().Equals(x.Cd_empresa.Trim()) &&
                                             v.Nr_lanctofiscal.Equals(x.Nr_lanctofiscal_origem) &&
                                             v.Id_nfitem.Equals(x.Id_nfitem_origem));
                if (obj != null)
                {
                    ret.FirstOrDefault(v => v.Cd_empresa.Trim().Equals(x.Cd_empresa.Trim()) &&
                                             v.Nr_lanctofiscal.Equals(x.Nr_lanctofiscal_origem) &&
                                             v.Id_nfitem.Equals(x.Id_nfitem_origem)).Qtd_entregafutura += x.Qtd_lancto;

                    ret.FirstOrDefault(v => v.Cd_empresa.Trim().Equals(x.Cd_empresa.Trim()) &&
                                             v.Nr_lanctofiscal.Equals(x.Nr_lanctofiscal_origem) &&
                                             v.Id_nfitem.Equals(x.Id_nfitem_origem)).Vl_entregafutura += x.Vl_lancto;
                }
            });
            if (Tp_operacao.Trim().ToUpper().Equals("D"))
                bsNotasCompDev.DataSource = ret.Where(x => x.Sd_qtddevolver > decimal.Zero);
            else if (Tp_operacao.Trim().ToUpper().Equals("E"))
                bsNotasCompDev.DataSource = ret.Where(x => x.Sd_qtentregafutura > decimal.Zero);
            else bsNotasCompDev.DataSource = ret;
            QTD_CompDev.Value = Quantidade;
            Vl_CompDev.Value = Valor;
            saldo_quantidade.Value = Quantidade;
            saldo_valor.Value = Valor;
            qtd_lancto.Value = Quantidade;
            vl_lancto.Value = Valor;
            cbFiltro.SelectedIndex = 0;
            if (ListaCompDev == null)
                ListaCompDev = new TList_LanFat_ComplementoDevolucao();
            bsCompDev.DataSource = ListaCompDev;
            total_quantidade.Value = totalQtdCompDev();
            total_valor.Value = totalVlCompDev();
            
            bsNotasCompDev_PositionChanged(this, new EventArgs());
        }

        private void edtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(edtFiltro.Text))
                {
                    if (cbFiltro.SelectedIndex == 0)
                        bsNotasCompDev.Filter = "NR_NotaFiscal = " + edtFiltro.Text;
                    else if (cbFiltro.SelectedIndex == 1)
                        bsNotasCompDev.Filter = "CD_Clifor = " + edtFiltro.Text;
                }
                else
                    bsNotasCompDev.Filter = string.Empty;
                try
                {
                    qtd_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtddevolver;
                    vl_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vldevolver;
                }
                catch
                { }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bsNotasCompDev_PositionChanged(object sender, EventArgs e)
        {
            if(Tp_operacao.Trim().ToUpper().Equals("D"))
                try
                {
                    qtd_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtddevolver;
                    vl_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vldevolver;
                }
                catch
                { }
            else if(Tp_operacao.Trim().ToUpper().Equals("E"))
                try
                {
                    qtd_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_qtentregafutura;
                    vl_lancto.Value = (bsNotasCompDev.Current as TRegistro_NFCompDev).Sd_vlentregaturura;
                }
                catch
                { }
        }
        
        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            if ((qtd_lancto.Value == 0) && (vl_lancto.Value == 0))
            {
                MessageBox.Show("Obrigatório informar quantidade ou valor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bsNotasCompDev.Count == 0)
            {
                MessageBox.Show("Não existe nota fiscal para " + (Tp_operacao.Trim().ToUpper().Equals("D") ? "devolver" : Tp_operacao.Trim().ToUpper().Equals("C") ? "complementar" : "entrega futura") + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Validar Quantidade
            if ((qtd_lancto.Value > 0) && (saldo_quantidade.Value == 0))
            {
                MessageBox.Show("Não existe mais saldo de quantidade para " + (Tp_operacao.Trim().ToUpper().Equals("D") ? "devolver" : Tp_operacao.Trim().ToUpper().Equals("C") ? "complementar" : "entrega futura") + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Validar Valor
            if ((!St_vldevNfOrigem) && (vl_lancto.Value > 0) && (saldo_valor.Value == 0))
            {
                MessageBox.Show("Não existe mais saldo de valor para " + (Tp_operacao.Trim().ToUpper().Equals("D") ? "devolver" : Tp_operacao.Trim().ToUpper().Equals("C") ? "complementar" : "entrega futura") + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Verificar se ja existe devolução/complemento gravado para a nota fiscal de origem
            TRegistro_LanFat_ComplementoDevolucao regCompDev = new TRegistro_LanFat_ComplementoDevolucao();
            regCompDev.Cd_empresa = (bsNotasCompDev.Current as TRegistro_NFCompDev).Cd_empresa;
            regCompDev.Nr_lanctofiscal_origem = (bsNotasCompDev.Current as TRegistro_NFCompDev).Nr_lanctofiscal;
            if (Contains(regCompDev))
            {
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Qtd_lancto = qtd_lancto.Value;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Vl_lancto = vl_lancto.Value;
            }
            else
            {
                bsCompDev.AddNew();
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Cd_empresa = (bsNotasCompDev.Current as TRegistro_NFCompDev).Cd_empresa;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Nr_notafiscal_origem = (bsNotasCompDev.Current as TRegistro_NFCompDev).Nr_notafiscal;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Nr_serie_origem = (bsNotasCompDev.Current as TRegistro_NFCompDev).Nr_serie;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Nr_lanctofiscal_origem = (bsNotasCompDev.Current as TRegistro_NFCompDev).Nr_lanctofiscal;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Id_nfitem_origem = (bsNotasCompDev.Current as TRegistro_NFCompDev).Id_nfitem;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Qtd_lancto = qtd_lancto.Value;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Vl_lancto = vl_lancto.Value;
                (bsCompDev.Current as TRegistro_LanFat_ComplementoDevolucao).Tp_operacao = Tp_operacao;
            }
            bsCompDev.EndEdit();
            total_quantidade.Value = totalQtdCompDev();
            total_valor.Value = totalVlCompDev();
            bsNotasCompDev.MoveNext();
            qtd_lancto.Value = saldo_quantidade.Value;
            vl_lancto.Value = saldo_valor.Value;
        }

        private void total_quantidade_ValueChanged(object sender, EventArgs e)
        {
            saldo_quantidade.Value = QTD_CompDev.Value - total_quantidade.Value;
        }

        private void total_valor_ValueChanged(object sender, EventArgs e)
        {
            saldo_valor.Value = ((Vl_CompDev.Value - total_valor.Value) > saldo_valor.Minimum ? Vl_CompDev.Value - total_valor.Value : saldo_valor.Minimum);
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            bsCompDev.RemoveCurrent();
            total_quantidade.Value = totalQtdCompDev();
            total_valor.Value = totalVlCompDev();
            qtd_lancto.Value = saldo_quantidade.Value;
            vl_lancto.Value = saldo_valor.Value;
        }

        private void qtd_lancto_ValueChanged(object sender, EventArgs e)
        {
            validarQtdCompDev();
        }

        private void vl_lancto_ValueChanged(object sender, EventArgs e)
        {
            validarVlCompDev();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFLanCompDevol_NF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
        }

        private void bb_autocompletar_Click(object sender, EventArgs e)
        {
            bsCompDev.Clear();
            total_quantidade.Value = totalQtdCompDev();
            total_valor.Value = totalVlCompDev();
            bsNotasCompDev.MoveFirst();
            int i = 0;
            do
            {
                if ((saldo_quantidade.Value <= 0) && (saldo_valor.Value <= 0))
                    break;
                bb_adicionar_Click(this, new EventArgs());
            }
            while (i++ < (bsNotasCompDev.Count - 1));
        }

        private void TFLanCompDevol_NF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCompDev);
            Utils.ShapeGrid.SaveShape(this, gNotasCompDev);
            if (Tp_operacao.Trim().Equals("D") || Tp_operacao.Trim().Equals("E"))
            {
                if (saldo_quantidade.Value > 0)
                {
                    if (MessageBox.Show("Ainda existe saldo quantidade para " + (Tp_operacao.Trim().ToUpper().Equals("D") ? "devolver" : "entrega futura") + ".\r\nDeseja processar saldo restante?\r\n\r\nSe não a nota fiscal não sera gravada.", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                        DialogResult = DialogResult.Cancel;
                }
                if (saldo_valor.Value > 0)
                {
                    if (MessageBox.Show("Ainda existe saldo valor para " + (Tp_operacao.Trim().ToUpper().Equals("D") ? "devolver" : "entrega futura") + ".\r\nDeseja processar saldo restante?\r\n\r\nSe não a nota fiscal não sera gravada.", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                        DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}