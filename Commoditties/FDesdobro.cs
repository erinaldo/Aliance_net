using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFDesdobro : Form
    {
        private CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial rdesd;
        public CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial rDesd
        {
            get
            {
                if (bsDesdobro.Current != null)
                    return bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial;
                else
                    return null;
            }
            set { rdesd = value; }
        }

        public string pCd_produto
        { get; set; }
        public string pCd_empresa
        { get; set; }

        public TFDesdobro()
        {
            InitializeComponent();
            this.pCd_produto = string.Empty;
            this.pCd_empresa = string.Empty;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (valor_desdobro.Focused)
                    (bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial).Valor_desdobro = valor_desdobro.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FDesdobro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pValor.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pDados.set_FormatZero();

            if (rdesd != null)
            {
                id_tpdesdobro.Enabled = false;
                bb_tpdesdobro.Enabled = false;
                nr_contratodest.Enabled = false;
                bb_contratodest.Enabled = false;
                bsDesdobro.DataSource = new CamadaDados.Graos.TList_Contrato_X_DesdEspecial() { rdesd };
                valor_desdobro.Focus();
            }
            else
            {
                bsDesdobro.AddNew();
                id_tpdesdobro.Focus();
            }
        }

        private void bb_tpdesdobro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdesdobro|Tipo Desdobro|200;" +
                              "a.id_tpdesdobro|TP. Desdobro|80;" +
                              "a.tp_calcpeso|Base Calculo|80;" +
                              "a.pc_desdobro|% Desdobro|80";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpdesdobro, ds_tpdesdobro },
                                            new CamadaDados.Balanca.Cadastros.TCD_TpDesdobroEspecial(),
                                            string.Empty);
            if (linha != null)
                valor_desdobro.Value = Convert.ToDecimal(linha["pc_desdobro"].ToString());
        }

        private void id_tpdesdobro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpdesdobro|=|" + id_tpdesdobro.Text;
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpdesdobro, ds_tpdesdobro },
                                        new CamadaDados.Balanca.Cadastros.TCD_TpDesdobroEspecial());
            if (linha != null)
                valor_desdobro.Value = Convert.ToDecimal(linha["pc_desdobro"].ToString());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDesdobro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_contratodest_Click(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + pCd_empresa.Trim() + "';" +
                            "a.cd_produto|=|'" + pCd_produto.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[]{nr_contratodest, 
                                                                                      CD_Empresa, 
                                                                                      NM_Empresa,
                                                                                      CD_Clifor,
                                                                                      NM_Clifor,
                                                                                      cd_produtodest,
                                                                                      ds_produtodest}, vParam);
        }

        private void nr_contratodest_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contratodest.Text + ";" +
                            "a.cd_empresa|=|'" + pCd_empresa.Trim() + "';" +
                            "a.cd_produto|=|'" + pCd_produto.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam,
                new Componentes.EditDefault[]{nr_contratodest,
                                                CD_Empresa,
                                                NM_Empresa,
                                                CD_Clifor,
                                                NM_Clifor,
                                                cd_produtodest,
                                                ds_produtodest}, new CamadaDados.Graos.TCD_CadContrato());
        }
    }
}
