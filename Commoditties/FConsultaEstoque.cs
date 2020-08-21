using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Commoditties
{
    public partial class TFConsultaEstoque : Form
    {
        public TFConsultaEstoque()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            //Buscar Estoque Geral
            TpBusca[] filtro = new TpBusca[0];
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (CD_Produto.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
            }
            bsGeral.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintetico(filtro, string.Empty, "b.ds_produto");

            //Buscar Estoque Depósito
            TpBusca[] filtroD = new TpBusca[1];
            //Depósito
            filtroD[0].vNM_Campo = "ISNULL(c.ST_Deposito, 'N')";
            filtroD[0].vOperador = "=";
            filtroD[0].vVL_Busca = "'S'";
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroD, filtroD.Length + 1);
                filtroD[filtroD.Length - 1].vNM_Campo = "a.cd_empresa";
                filtroD[filtroD.Length - 1].vOperador = "=";
                filtroD[filtroD.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (CD_Produto.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroD, filtroD.Length + 1);
                filtroD[filtroD.Length - 1].vNM_Campo = "a.cd_produto";
                filtroD[filtroD.Length - 1].vOperador = "=";
                filtroD[filtroD.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
            }
            if (nr_contrato.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroD, filtroD.Length + 1);
                filtroD[filtroD.Length - 1].vNM_Campo = "a.nr_contrato";
                filtroD[filtroD.Length - 1].vOperador = "=";
                filtroD[filtroD.Length - 1].vVL_Busca = "'" + nr_contrato.Text.Trim() + "'";
            }
            bsDeposito.DataSource = new CamadaDados.Graos.TCD_SaldoContrato().Select(filtroD);

            //Buscar Saldo à Fixar
            TpBusca[] filtroF = new TpBusca[1];
            //Fixar
            filtroF[0].vNM_Campo = "ISNULL(c.ST_ValoresFixos, 'N')";
            filtroF[0].vOperador = "<>";
            filtroF[0].vVL_Busca = "'S'";
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroF, filtroF.Length + 1);
                filtroF[filtroF.Length - 1].vNM_Campo = "a.cd_empresa";
                filtroF[filtroF.Length - 1].vOperador = "=";
                filtroF[filtroF.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (CD_Produto.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroF, filtroF.Length + 1);
                filtroF[filtroF.Length - 1].vNM_Campo = "a.cd_produto";
                filtroF[filtroF.Length - 1].vOperador = "=";
                filtroF[filtroF.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
            }
            if (nr_contrato.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtroF, filtroF.Length + 1);
                filtroF[filtroF.Length - 1].vNM_Campo = "a.nr_contrato";
                filtroF[filtroF.Length - 1].vOperador = "=";
                filtroF[filtroF.Length - 1].vVL_Busca = "'" + nr_contrato.Text.Trim() + "'";
            }
            bsFixar.DataSource = new CamadaDados.Graos.TCD_SaldoContrato().Select(filtroF);

            //Saldo Contrato
            CamadaDados.Balanca.TList_PedidoAplicacao lista =
                       CamadaNegocio.Balanca.TCN_PedidoAplicacao.Buscar(cd_empresa.Text,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        cd_clifor.Text,
                                                                        string.Empty,
                                                                        false,
                                                                        nr_contrato.Text,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        false,
                                                                        string.Empty,
                                                                        false,
                                                                        false,
                                                                        rbEntrada.Checked ? "E" : rbSaida.Checked ? "S" : string.Empty,
                                                                        false,
                                                                        false,
                                                                        0);

            BS_AplicacaoPedido.DataSource = lista;
        }

        private void TFConsultaEstoque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto }, string.Empty);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
             UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { CD_Produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor },
               "|exists|(select 1 from vtb_gro_contrato x " +
               "           where x.cd_clifor = a.cd_clifor)");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                                         "|exists|(select 1 from vtb_gro_contrato x " +
                                         "         where x.cd_clifor = a.cd_clifor)",
               new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFConsultaEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
