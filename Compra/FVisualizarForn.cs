using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFVisualizarForn : Form
    {
        public string Cd_grupo
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Id_requisicao
        { get; set; }
        public TFVisualizarForn()
        {
            InitializeComponent();
        }

        private void InserirCotacao()
        {
            if (bsClifor.Current == null)
            {
                MessageBox.Show("Obrigatório selecionar FORNECEDOR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFCotacao fCot = new TFCotacao())
            {
                fCot.pCd_empresa = Cd_empresa;
                fCot.pCd_fornecedor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                if (fCot.ShowDialog() == DialogResult.OK)
                {
                    if (fCot.lRequisicao != null)
                        if (fCot.lRequisicao.Count > 0)
                            try
                            {
                                fCot.lRequisicao.ForEach(p =>
                                {
                                    p.lCotacoes.ForEach(x =>
                                    {
                                        x.Id_requisicao = p.Id_requisicao;
                                        x.Qtd_atendida = p.Qtd_atendida;
                                        x.Vl_unitario_cotado = p.Vl_unitCotacao;
                                        x.Vl_ipi = p.Vl_ipi;
                                        x.Vl_icmssubst = p.Vl_icmssubst;
                                        x.Pc_icms = p.Pc_icms;
                                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.GravarCotacao(x, null);
                                    });
                                });
                                MessageBox.Show("Cotação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
            }
        }

        private void BuscarFornec()
        {
            //Buscar Fornecedores
            bsClifor.DataSource =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                            "where x.CD_Clifor = a.CD_Clifor " +
                                            "and x.CD_Grupo = '" + Cd_grupo.Trim() + "')"
                            }
                        }, 0, string.Empty);
        }

        private void InserirFornec(string cd_clifor)
        {
            if (!string.IsNullOrEmpty(Cd_grupo) && !string.IsNullOrEmpty(cd_clifor))
            {
                //Gravar Fornecedor X Grupo produto
                CamadaNegocio.Compra.TCN_Cad_Fornecedor_X_GrupoItem.GravaFornecedor_X_GrupoItem(
                    new CamadaDados.Compra.TRegistro_Cad_Fornecedor_X_GrupoItem()
                    {
                        CD_Clifor = cd_clifor,
                        CD_Grupo = Cd_grupo
                    }, null);
                BuscarFornec();
                //Selecionar linha do grid do fornecedor cadastrado
                DataGridViewRow linha = gClifor.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pCd_Clifor"].Value.ToString().Contains(cd_clifor)).First();
                if (linha != null)
                {
                    gClifor.Rows[linha.Index].Selected = true;
                    bsClifor.Position = linha.Index;
                }
                InserirCotacao();
            }
        }

        private void TFVisualizarForn_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Cd_grupo))
                lblFornecedor.Text = "FORNECEDORES GRUPO PRODUTO - " +
                                        new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_grupo",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Cd_grupo.Trim() + "'"
                                                }
                                            }, "LTrim(RTrim(a.ds_grupo))");
            BuscarFornec();
        }

        private void bsClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lEndereco =
                    TCN_CadEndereco.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           0,
                                           null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lContato =
                    TCN_CadContatoCliFor.Buscar(string.Empty,
                                                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                false,
                                                false,
                                                false,
                                                string.Empty,
                                                0,
                                                null);
                bsClifor.ResetCurrentItem();
            }
        }

        private void ts_btn_Inserir_Cotacao_Click(object sender, EventArgs e)
        {
            InserirCotacao();
        }

        private void TFVisualizarForn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                Close();
        }

        private void btn_cotacaoForn_Click(object sender, EventArgs e)
        {
            Componentes.EditDefault cd_clifor = new Componentes.EditDefault();
            cd_clifor.NM_Campo = "CD_CLIFOR";
            cd_clifor.NM_CampoBusca = "CD_CLIFOR";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, vParam);

            InserirFornec(cd_clifor.Text);
        }

        private void btn_NovoFornec_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            InserirFornec(fClifor.rClifor.Cd_clifor);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }
    }
}
