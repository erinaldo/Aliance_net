using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFNovaLocacao : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_cliente
        { get; set; }
        public string pNm_cliente
        { get; set; }
        public string pCd_endereco
        { get; set; }
        public string pDs_endereco
        { get; set; }
        public string pCd_vendedor
        { get; set; }
        public string pNm_vendedor
        { get; set; }
        public string pDt_locacao
        { get; set; }
        public string pTp_frete
        { get; set; }
        public decimal pVl_frete
        { get; set; }
        public string pId_pessoa
        { get; set; }
        public string pNm_pessoa
        { get; set; }
        public string pResponsavel
        { get; set; }
        public string pDs_obs
        { get; set; }
        public CamadaDados.Locacao.TList_ItensLocacao lItens
        { get; set; }
        public CamadaDados.Locacao.TRegistro_Locacao rLocacao
        {
            get
            {
                if (bsLocacao.Current != null)
                    return bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                else
                    return null;
            }
        }
        public TFNovaLocacao()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 2;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 2;
            //FRETE
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMPRESA", "E"));
            cbx.Add(new Utils.TDataCombo("CLIENTE", "C"));

            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p=> string.IsNullOrEmpty(p.Dt_prevdevstr)))
                {
                    MessageBox.Show("Obrigatório informar Dt.Prev.Devolução de todos os itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirDtPrevisao()
        {
            if (bsItens.Current != null)
            {
                using (TFAlterarData fAlterar = new TFAlterarData())
                {
                    fAlterar.pId_locacao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr;
                    fAlterar.pCd_produto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                    fAlterar.pDs_produto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                    fAlterar.pDt_locacaostr = pDt_locacao;
                    fAlterar.pNr_Patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                    fAlterar.pQuantidade = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_Patrimonio;
                    fAlterar.pQtd_Item = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem;
                    if (fAlterar.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fAlterar.pDt_prevdevstr))
                            try
                            {
                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr = fAlterar.pDt_prevdevstr;
                                bsItens.ResetCurrentItem();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void PreencherCampos()
        {
           Cd_empresa.Text = pCd_empresa;
           nm_empresa.Text = pNm_empresa;
           cd_clifor.Text = pCd_cliente;
           nm_clifor.Text = pNm_cliente;
           Cd_endereco.Text = pCd_endereco;
           Ds_endereco.Text = pDs_endereco;
           cd_vendedor.Text = pCd_vendedor;
           nm_vendedor.Text = pNm_vendedor;
           dt_loc.Text = pDt_locacao;
           dt_locacao.Text =pDt_locacao;
           tp_frete.Text = pTp_frete;
           vl_despesas.Value = pVl_frete;
           id_pessoa.Text = pId_pessoa;
           nm_pessoa.Text = pNm_pessoa;
           nm_responsavel.Text = pResponsavel;
           ds_observacao.Text = pDs_obs;
        }

        private void bb_dt_prevdev_Click(object sender, EventArgs e)
        {
            this.InserirDtPrevisao();
        }

        private void gItens_DoubleClick(object sender, EventArgs e)
        {
            this.InserirDtPrevisao();
        }

        private void TFNovaLocacao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsLocacao.AddNew();
            this.PreencherCampos();
            //Abrir como ENTREGUE
            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro = "2";
            lItens.ForEach(p => (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Add(p));
            bsLocacao.ResetCurrentItem();
        }

        private void TFNovaLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void id_pessoa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                                "a.id_pessoa|=|" + id_pessoa.Text + ";" +
                                "isnull(a.dt_autorizacao, GETDATE())|>=| '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd HH:mm:ss") + "'";
                FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_pessoa, nm_pessoa },
                    new CamadaDados.Financeiro.Cadastros.TCD_PessoasAutorizadas());
            }
        }

        private void bb_autorizada_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                string vColunas = "a.nm_pessoa|Nome|200;" +
                                  "a.id_pessoa|Código|80";
                string vParam = "a.cd_clifor|=|" + cd_clifor.Text.Trim() + ";" +
                                "isnull(a.dt_autorizacao, GETDATE())|>=| '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd HH:mm:ss") + "'";
                FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_pessoa, nm_pessoa },
                    new CamadaDados.Financeiro.Cadastros.TCD_PessoasAutorizadas(),
                   vParam);
            }
        }
    }
}
