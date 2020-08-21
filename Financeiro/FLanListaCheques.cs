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
    public partial class TFLanListaCheques : Form
    {
        public string Tp_mov
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public decimal Vl_totaltitulo
        { get; set; }
        public bool St_bloquearTroco
        { get; set; }
        public bool St_pdv
        { get; set; }

        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques
        { get; set; }

        public TFLanListaCheques()
        {
            InitializeComponent();
            this.lCheques = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }

        private void afterNovo()
        {
            if (vl_saldo.Value > 0)
            {
                using (TFLanTitulo fCheque = new TFLanTitulo())
                {
                    fCheque.CD_Empresa.Enabled = false;
                    fCheque.BB_Empresa.Enabled = false;
                    if (this.Tp_mov.Trim().ToUpper().Equals("P"))
                    {
                        fCheque.CD_Clifor.Enabled = false;
                        fCheque.BB_Clifor.Enabled = false;
                        fCheque.NM_Clifor.Enabled = false;
                    }
                    fCheque.CD_Conta.Enabled = false;
                    fCheque.BB_Conta.Enabled = false;
                    fCheque.CD_Portador.Enabled = false;
                    fCheque.DS_Portador.Enabled = false;
                    fCheque.CD_Portador.Enabled = false;
                    fCheque.BB_Portador.Enabled = false;
                    fCheque.ds_banco.Enabled = false;
                    fCheque.DT_Pgto.Enabled = false;
                    fCheque.tp_titulo.Enabled = false;
                    fCheque.nr_lanctocheque.Enabled = false;

                    //SETAR AS PROPRIEDADES NAO EDITAVEIS PELO USUARIO
                    fCheque.Cd_empresa = this.Cd_empresa;
                    fCheque.Cd_contager = this.Cd_contager;
                    fCheque.Ds_contager = this.Ds_contager;

                    fCheque.Cd_clifor = this.Cd_clifor;

                    fCheque.Cd_historico = this.Cd_historico;
                    fCheque.Ds_historico = this.Ds_historico;

                    fCheque.Cd_portador = this.Cd_portador;
                    fCheque.Ds_portador = this.Ds_portador;

                    fCheque.pNm_clifor_nominal = this.Nm_clifor;

                    fCheque.Dt_emissao = this.Dt_emissao;
                    fCheque.Vl_titulo = vl_saldo.Value;
                    fCheque.pVl_saldo = vl_saldo.Value;
                    fCheque.Tp_titulo = this.Tp_mov;
                    if (bsCheque.Count > 0)
                        fCheque.Nr_chequeLista = decimal.Parse((bsCheque.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).OrderByDescending(p => p.Nr_cheque).First().Nr_cheque);
                    fCheque.St_bloquearTroco = this.St_bloquearTroco;
                    if (fCheque.ShowDialog() == DialogResult.OK)
                        if (fCheque.BS_Titulo.Current != null)
                        {
                            (bsCheque.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Add(fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
                            bsCheque.ResetBindings(false);
                            bsCheque_PositionChanged(this, new EventArgs());
                        }
                }
            }
            else
                MessageBox.Show("Não existe mais saldo para lançar novo cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsCheque.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do cheque?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    bsCheque.RemoveCurrent();
                    bsCheque_PositionChanged(this, new EventArgs());
                }
            }
            else
                MessageBox.Show("Não existe cheque selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterGrava()
        {
            if ((vl_saldo.Value > 0) && (!St_pdv))
                MessageBox.Show("Ainda existe saldo liquidação para lançar em cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanListaCheques_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheque);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_totalliquidar.Value = Vl_totaltitulo;
            bsCheque.DataSource = lCheques;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void vl_totalliquidar_ValueChanged(object sender, EventArgs e)
        {
            vl_saldo.Value = vl_totalliquidar.Value - vl_totcheques.Value;
        }

        private void vl_totcheques_ValueChanged(object sender, EventArgs e)
        {
            vl_saldo.Value = vl_totalliquidar.Value - vl_totcheques.Value;
        }

        private void bsCheque_PositionChanged(object sender, EventArgs e)
        {
            if(lCheques != null)
                vl_totcheques.Value = lCheques.Sum(p => p.Vl_titulo);
        }

        private void TFLanListaCheques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanListaCheques_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCheque);
        }
    }
}
