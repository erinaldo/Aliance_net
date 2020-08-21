using System;
using System.Data;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Estoque.Cadastros;

namespace Restaurante.Cadastro
{
    public partial class FCadProduto : Form
    {

        private TRegistro_CadProduto cProduto { get; set; } = new TRegistro_CadProduto();
        public TRegistro_CadProduto rProduto { get { return bsProduto.Current as TRegistro_CadProduto; } set { cProduto = value; } }

        public FCadProduto()
        {
            InitializeComponent();
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new TCD_CadGrupoProduto(), vParamFixo);
        }

        private void FCadProduto_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (cProduto != null)
            {
                bsProduto.Add(cProduto);
                CD_Produto.Enabled = false;
                DS_Produto.Focus();
            }
            else
            {
                bsProduto.AddNew();
                CD_Produto.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Produto");
            }
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new TCD_CadGrupoProduto());
        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80;" +
                              "ST_RegAnvisa|Farmacêutico|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new TCD_CadTpProduto(), string.Empty);
            
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new TCD_CadTpProduto());
           
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade},
                                    new TCD_CadUnidade());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade},
                                    new TCD_CadUnidade(), "");
        }

        private void ncm_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ncm.Text))
            {
                Componentes.EditDefault cadNcm = new Componentes.EditDefault();
                cadNcm.Text = ncm.Text;
                string vColunas = "a.ncm|=|'" + ncm.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ncm, ds_ncm },
                                        new CamadaDados.Fiscal.TCD_CadNCM());
                if (linha == null)
                {
                    if (cadNcm.Text.SoNumero().Trim().Length != 8)
                    {
                        MessageBox.Show("NCM incorreto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InputBox ibp = new InputBox();
                    ibp.Text = "NCM";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatorio informar descrição NCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(
                            new CamadaDados.Fiscal.TRegistro_CadNCM()
                            {
                                NCM = cadNcm.Text,
                                Ds_NCM = ds
                            });
                        MessageBox.Show("NCM gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ncm.Text = cadNcm.Text;
                        ds_ncm.Text = ds;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void bb_ncm_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ncm|Descrição NCM|250;" +
                              "a.ncm|NCM|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ncm, ds_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM(), String.Empty);
        }

        private void FCadProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F6))
            {
                bb_cancelar_Click(this, new EventArgs());
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CD_Unidade_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Unidade.Text))
            {
                TList_CadUnidade lunid = new TCD_CadUnidade().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_unidade",
                            vOperador = "=",
                            vVL_Busca = CD_Unidade.Text
                        }
                    }, 1,string.Empty);
                if (lunid.Count > 0)
                    editFloat1.DecimalPlaces = Convert.ToInt32(lunid[0].CasasDecimais.ToString()) == 0 ? 2: Convert.ToInt32(lunid[0].CasasDecimais.ToString());
                else
                    editFloat1.DecimalPlaces = 2;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_localImp|Local imp|250;" +
                              "a.id_localimp|Código|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault1 },
                                    new CamadaDados.Restaurante.Cadastro.TCD_LocalImp(), String.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_localimp|=|'" + editDefault1.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { editDefault1  },
                                    new CamadaDados.Restaurante.Cadastro.TCD_LocalImp());

        }

        private void BB_CondFiscalProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondFiscal_Produto|Condição Fiscal|350;" +
                              "CD_CondFiscal_Produto|Cód. Cond. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), "");
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_CondFiscal_Produto|=|'" + CD_CondFiscal_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }
    }
}
