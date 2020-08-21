using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;

namespace Compra
{
    public partial class TFLanPrazoEntrega : Form
    {
        public bool St_detalhe
        { get; set; }
        public CamadaDados.Compra.Lancamento.TRegistro_PrazoEntrega rPrazo
        {
            get
            {
                if (bsPrazoEntrega.Current != null)
                    return bsPrazoEntrega.Current as CamadaDados.Compra.Lancamento.TRegistro_PrazoEntrega;
                else
                    return null;
            }
            set
            {
                bsPrazoEntrega.Add(value);
            }
        }

        public TFLanPrazoEntrega()
        {
            InitializeComponent();
            this.St_detalhe = false;
        }

        private void BuscarEnd()
        {
            if (cd_transportadora.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'"+cd_transportadora.Text.Trim()+"'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    cd_endtransportadora.Text = obj.ToString();
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanPrazoEntrega_Load(object sender, EventArgs e)
        {
            pFrete.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (this.St_detalhe)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_transportadora.Enabled = false;
                bb_transportadora.Enabled = false;
                prazo_entrega.Enabled = false;
                tp_frete.Enabled = false;
                BB_Gravar.Visible = false;
            }
            else
            {
                pDados.set_FormatZero();
                bsPrazoEntrega.AddNew();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new TCD_CadEmpresa(),
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
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanPrazoEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora, nm_transportadora }, "isnull(a.st_registro, 'A')|<>|'C';isnull(a.st_transportadora, 'N')|=|'S'");
            this.BuscarEnd();
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEnd();
        }

        private void bb_endtransportadora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_endtransportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endtransportadora.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }
    }
}
