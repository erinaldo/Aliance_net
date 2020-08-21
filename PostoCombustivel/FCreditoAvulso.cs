using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFCreditoAvulso : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        public string Cd_clifor
        { get { return cd_clifor.Text; } }
        public string Nm_clifor
        { get { return nm_clifor.Text;} }
        public string Cd_endereco
        { get { return CD_Endereco.Text; } }
        public decimal Vl_credito
        { get { return VL_Adiantamento.Value; } }
        public string Observacao
        { get { return ds_observacao.Text; } }

        public TFCreditoAvulso()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                    }
                                }, "a.cd_endereco");
                if (obj != null)
                    CD_Endereco.Text = obj.ToString();
            }
        }

        private void TFCreditoAvulso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            CD_Empresa.Text = Cd_empresa;
            NM_Empresa.Text = Nm_empresa;
            bool ident_clifor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", Cd_empresa, null).Trim().ToUpper().Equals("S");
            cd_clifor.ST_NotNull = ident_clifor;
            CD_Endereco.ST_NotNull = ident_clifor;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            this.BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEndereco();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|350;" +
                              "a.CD_Endereco|Cód. Endereço|80;" +
                              "a.UF|UF|80;" +
                              "a.DS_cidade|Cidade|100;" +
                              "a.CD_UF|Código|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, Cidade, UF },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "b.CD_CLIFOR|=|" + cd_clifor.Text);
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + CD_Endereco.Text + "';" + "b.cd_clifor|=|'" + cd_clifor.Text + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, Cidade, UF },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCreditoAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
