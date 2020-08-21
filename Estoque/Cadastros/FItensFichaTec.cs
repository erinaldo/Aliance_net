using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFItensFichaTec : Form
    {
        public string pCd_produto { get; set; }
        private CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto rficha;
        public CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto rFicha
        {
            get
            {
                if (bsFichaTec.Current != null)
                    return bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto;
                else
                    return null;
            }
            set { rficha = value; }
        }

        public TFItensFichaTec()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (Quantidade.Focused)
                (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Quantidade = Quantidade.Value;
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFItensFichaTec_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rficha != null)
            {
                bsFichaTec.DataSource = new CamadaDados.Estoque.Cadastros.TList_FichaTecProduto() { rficha };
                CD_Produto.Enabled = false;
                BB_Produto.Enabled = false;
                vl_custoservico.Enabled = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(rficha.Cd_item);
                Quantidade.Focus();
            }
            else
            {
                bsFichaTec.AddNew();
                CD_Produto.Focus();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(pCd_produto))
                vParam = "a.cd_produto|<>|'" + pCd_produto.Trim() + "'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, vParam);
            if (linha != null)
            {
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
                vl_custoservico.Enabled = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string cond = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(pCd_produto))
                cond += ";a.cd_produto|<>|'" + pCd_produto.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(cond
                    , new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null)
            {
                SG_Unidade_Estoque.Text = linha["sigla_Unidade"].ToString();
                vl_custoservico.Enabled = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFItensFichaTec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void vl_custoservico_EnabledChanged(object sender, EventArgs e)
        {
            if (!vl_custoservico.Enabled)
            {
                vl_custoservico.Value = vl_custoservico.Minimum;
                bsFichaTec.ResetCurrentItem();
            }
        }
    }
}
