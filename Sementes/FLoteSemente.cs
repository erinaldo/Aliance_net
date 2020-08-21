using System;
using System.Windows.Forms;
using FormBusca;

namespace Sementes
{
    public partial class TFLoteSemente : Form
    {
        public Utils.TTpModo vModo
        { get; set; }

        private CamadaDados.Sementes.TRegistro_LoteSemente rsementes;
        public CamadaDados.Sementes.TRegistro_LoteSemente rSementes
        {
            get
            {
                if (bsLoteSemente.Current != null)
                    return (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente);
                else
                    return null;
            }
            set
            { rsementes = value; }
        }

        public TFLoteSemente()
        {
            InitializeComponent();
            vModo = Utils.TTpModo.tm_Insert;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void BuscarAnalises()
        {
            CamadaDados.Sementes.Cadastros.TList_TipoAnalise lAnalises = 
                CamadaNegocio.Sementes.Cadastros.TCN_TipoAnalise.Buscar(string.Empty,
                                                                        string.Empty,
                                                                        0,
                                                                        string.Empty,
                                                                        null);
            if (bsLoteSemente.Current != null)
                (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lAnalise.ForEach(p =>
                    {
                        lAnalises.Find(v => v.Id_analise.Value.Equals(p.Id_analise.Value)).St_utilizarlote = true;
                    });
            bsAnalise.DataSource = lAnalises;
        }

        private void TFLoteSemente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAnalises);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (vModo == Utils.TTpModo.tm_Insert)
            {
                bsLoteSemente.AddNew();
                cd_empresa.Focus();
                pAnalise.Visible = false;
            }
            else
            {
                pAnalise.Visible = rsementes.St_registro.Trim().ToUpper().Equals("P");
                bsLoteSemente.Add(rsementes);
                bsLoteSemente.ResetCurrentItem();
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_amostra.Enabled = false;
                bb_amostra.Enabled = false;
                cd_amostra.Focus();
            }
            BuscarAnalises();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.sigla_unidade|Sigla Unidade|80";
            string vParam = "|exists|(select 1 from tb_est_tpproduto x " +
                            "           where a.tp_produto = x.tp_produto " +
                            "           and isnull(x.st_mprimasemente, 'N') = 'S')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_amostra, ds_amostra, sigla_unidamostra },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_amostra.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_tpproduto x " +
                            "where a.tp_produto = x.tp_produto " +
                            "and isnull(x.st_mprimasemente, 'N') = 'S')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_amostra, ds_amostra, sigla_unidamostra },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Ano Safra|200;" +
                              "a.anosafra|Cd. Ano|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFLoteSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_produto_Click_1(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.sigla_unidade|Sigla Unidade|80";
            string vParam = "|exists|(select 1 from tb_est_tpproduto x " +
                            "           where a.tp_produto = x.tp_produto " +
                            "           and isnull(x.st_semente, 'N') = 'S')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), vParam);
        }

        private void cd_produto_Leave_1(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'"+cd_produto.Text.Trim()+"';"+
                            "|exists|(select 1 from tb_est_tpproduto x " +
                            "           where a.tp_produto = x.tp_produto " +
                            "           and isnull(x.st_semente, 'N') = 'S')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_laboratorio_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_laboratorio, nm_laboratorio }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_laboratorio_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_laboratorio.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[]{cd_laboratorio, nm_laboratorio},
                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_tecnico, nm_tecnico }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_tecnico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_tecnico.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tecnico, nm_tecnico },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gAnalises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(bsLoteSemente.Current != null)
                if (e.ColumnIndex == 0)
                    if ((bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).St_utilizarlote)
                    {
                        //Remover item para a lista a excluir
                        if (!(bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lLoteXAnaliseDel.Exists(p => p.Id_analise.Value.Equals(
                            (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).Id_analise.Value)))
                            (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lLoteXAnaliseDel.Add(
                                new CamadaDados.Sementes.TRegistro_LoteSemente_X_TipoAnalise()
                                {
                                    Id_analise = (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).Id_analise
                                });
                        //Remover item da lista 
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lLoteXAnalise.RemoveAll(p => p.Id_analise.Value.Equals(
                            (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).Id_analise.Value));
                        //Desmarcar item 
                        (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).St_utilizarlote = false;
                    }
                    else
                    {
                        //Adicionar item a lista de analises
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lLoteXAnalise.Add(
                            new CamadaDados.Sementes.TRegistro_LoteSemente_X_TipoAnalise()
                            {
                                Id_analise = (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).Id_analise
                            });
                        //Marcar item
                        (bsAnalise.Current as CamadaDados.Sementes.Cadastros.TRegistro_TipoAnalise).St_utilizarlote = true;
                    }
        }

        private void TFLoteSemente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAnalises);
        }
    }
}
