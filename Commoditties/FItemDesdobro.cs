using System;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFItemDesdobro : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pCd_tabeladesconto
        { get; set; }
        public string pDs_tabeladesconto
        { get; set; }
        public string pTp_movimento
        { get; set; }
        private decimal? pnr_contratodest;
        public decimal? Nr_contratodest
        { get 
            {
                try
                {
                    return decimal.Parse(nr_contrato_dest.Text);
                }
                catch { return null; }
            } 
            set { pnr_contratodest = value; } }
        private string nr_nfprodutor;
        public string Nr_nfprodutor
        { get { return nr_notaprodutor.Text; } set { nr_nfprodutor = value; } }
        private DateTime? pdt_emissaonfprodutor;
        public DateTime? pDt_emissaonfprodutor
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaonfprodutor.Text);
                }
                catch { return null; }
            }
            set { pdt_emissaonfprodutor = value; }
        }
        private decimal qtd_nfprodutor;
        public decimal Qtd_nfprodutor
        { get { return qt_nfprodutor.Value; } set { qtd_nfprodutor = value; } }
        private decimal pvl_nfprodutor;
        public decimal pVl_nfprodutor
        { get { return vl_nfprodutor.Value; } set { pvl_nfprodutor = value; } }
        private string ptp_pesodesdobro;
        public string Tp_pesodesdobro
        { get { return st_psbruto.Checked ? "B" : "L"; } set { ptp_pesodesdobro = value; } }
        private decimal pqtd_desdobro;
        public decimal Qtd_desdobro
        { get { return vl_desdobro.Value; } set { pqtd_desdobro = value; } }
        private string ptp_percvalor;
        public string Tp_percvalor
        { get { return cbQtdPerc.SelectedIndex.Equals(0) ? "P" : "Q"; } set { ptp_percvalor = value; } }
        private string pcd_contratante_dest;
        public string pCd_contratante_dest
        { get { return cd_contratante_dest.Text; }  set { pcd_contratante_dest = value; } }
        private string pnm_contratante_dest;
        public string pNm_contratante_dest
        { get { return nm_contratante_dest.Text; } set { pnm_contratante_dest = value; } }

        public TFItemDesdobro()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(nr_contrato_dest.Text) &&
                string.IsNullOrEmpty(cd_contratante_dest.Text) &&
                string.IsNullOrEmpty(nm_contratante_dest.Text))
            {
                MessageBox.Show("Obrigatorio informar contrato ou contratante destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_contrato_dest.Focus();
                return;
            }
            if (vl_desdobro.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade desdobro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_desdobro.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFItemDesdobro_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pDados.set_FormatZero();
            cd_empresa_dest.Text = pCd_empresa;
            nm_empresa_dest.Text = pNm_empresa;
            cd_produto_dest.Text = pCd_produto;
            ds_produto_dest.Text = pDs_produto;
            cd_tabela_dest.Text = pCd_tabeladesconto;
            ds_tabela_dest.Text = pDs_tabeladesconto;
            if (pnr_contratodest.HasValue)
            {
                nr_contrato_dest.Text = pnr_contratodest.Value.ToString();
                nr_contrato_dest_Leave(this, new EventArgs());
            }
            if (!string.IsNullOrEmpty(ptp_pesodesdobro))
            {
                st_psbruto.Checked = ptp_pesodesdobro.Trim().ToUpper().Equals("B");
                st_psliquido.Checked = ptp_pesodesdobro.Trim().ToUpper().Equals("L");
            }
            if (!string.IsNullOrEmpty(ptp_percvalor))
                cbQtdPerc.SelectedIndex = ptp_percvalor.Trim().ToUpper().Equals("P") ? 0 : 1;
            else cbQtdPerc.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(pcd_contratante_dest))
                cd_contratante_dest.Text = pcd_contratante_dest;
            if (!string.IsNullOrEmpty(pnm_contratante_dest))
                nm_contratante_dest.Text = pnm_contratante_dest;
            if (!string.IsNullOrEmpty(nr_nfprodutor))
                nr_notaprodutor.Text = nr_nfprodutor;
            if (!string.IsNullOrEmpty(pdt_emissaonfprodutor.ToString()))
                dt_emissaonfprodutor.Text = pdt_emissaonfprodutor.ToString();
            if (qtd_nfprodutor > decimal.Zero)
                qt_nfprodutor.Value = qtd_nfprodutor;
            if (pVl_nfprodutor > decimal.Zero)
                vl_nfprodutor.Value = pVl_nfprodutor;
            if (pqtd_desdobro > decimal.Zero)
                vl_desdobro.Value = pqtd_desdobro;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbQtdPerc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQtdPerc.SelectedIndex.Equals(0))
                vl_desdobro.Maximum = 100;
            else vl_desdobro.Maximum = 999999999999999;
        }

        private void bb_Contrato_dest_Click(object sender, EventArgs e)
        {
            string vParamFixo = "isnull(a.st_registro, 'A')|=|'A';" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                "a.cd_tabeladesconto|=|'" + pCd_tabeladesconto.Trim() + "';" +
                                "a.tp_movimento|=|'" + pTp_movimento.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato_dest, 
                                                                                        cd_contratante_dest, 
                                                                                        nm_contratante_dest, 
                                                                                        cd_empresa_dest,
                                                                                        nm_empresa_dest,
                                                                                        cd_produto_dest,
                                                                                        ds_produto_dest,
                                                                                        cd_tabela_dest,
                                                                                        ds_tabela_dest}, vParamFixo);
            if (!string.IsNullOrEmpty(nr_contrato_dest.Text))
            {
                cd_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
                bb_contratante.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
                nm_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
            }
            else
            {
                cd_contratante_dest.Enabled = true;
                bb_contratante.Enabled = true;
            }
        }

        private void nr_contrato_dest_Leave(object sender, EventArgs e)
        {
            string vParamFixo = "a.nr_contrato|=|" + nr_contrato_dest.Text + ";" +
                                "isnull(a.st_registro, 'A')|=|'A';" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                "a.cd_tabeladesconto|=|'" + pCd_tabeladesconto.Trim() + "';" +
                                "a.tp_movimento|=|'" + pTp_movimento.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParamFixo, new Componentes.EditDefault[] { nr_contrato_dest, 
                                                                                          cd_contratante_dest, 
                                                                                          nm_contratante_dest, 
                                                                                          cd_empresa_dest,
                                                                                          nm_empresa_dest,
                                                                                          cd_produto_dest,
                                                                                          ds_produto_dest,
                                                                                          cd_tabela_dest,
                                                                                          ds_tabela_dest},
                                            new CamadaDados.Graos.TCD_CadContrato());
            if (!string.IsNullOrEmpty(nr_contrato_dest.Text))
            {
                cd_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
                bb_contratante.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
                nm_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
            }
            else
            {
                cd_contratante_dest.Enabled = true;
                bb_contratante.Enabled = true;
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItemDesdobro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_contratante_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_contratante_dest, nm_contratante_dest }, string.Empty);
            nm_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
        }

        private void cd_contratante_dest_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_contratante_dest.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contratante_dest, nm_contratante_dest },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            nm_contratante_dest.Enabled = string.IsNullOrEmpty(cd_contratante_dest.Text);
        }
    }
}
