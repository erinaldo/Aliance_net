using System;
using System.Data;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Bloqueto;

namespace Financeiro
{
    public partial class TFLan_Bloqueto : Form
    {
        public TFLan_Bloqueto()
        {
            InitializeComponent();
        }

        private void TFLan_Bloqueto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltros.set_FormatZero();
            pDados.set_FormatZero();
        }
        
        private void afterBusca()
        {
            if(string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            TpBusca[] filtro = new TpBusca[5];
            //Somente duplicatas ativas
            filtro[0].vNM_Campo = "isNull(dup.ST_Registro, 'A')";
            filtro[0].vVL_Busca = "'A'";
            filtro[0].vOperador = "=";
            //Somente contas a receber
            filtro[1].vNM_Campo = "a.TP_Mov";
            filtro[1].vVL_Busca = "'R'";
            filtro[1].vOperador = "=";
            //Somente parcelas em aberto ou parcial
            filtro[2].vNM_Campo = "isNull(a.ST_Registro, 'A')";
            filtro[2].vVL_Busca = "('A', 'P')";
            filtro[2].vOperador = "in";
            //Filtro por empresa
            filtro[3].vNM_Campo = "a.CD_Empresa";
            filtro[3].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            filtro[3].vOperador = "=";
            //Somente parcelas sem bloqueto
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.nr_lancto = a.nr_lancto " +
                                  "and x.cd_parcela = a.cd_parcela " +
                                  "and isnull(x.st_registro, 'A') <> 'C')";
            filtro[4].vOperador = "NOT EXISTS";

            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(NR_Docto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Docto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_Docto.Text.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rgData.NM_Valor.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + "'";
            }
            if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rgData.NM_Valor.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + "'";
            }
            bsParcelas.DataSource = new TCD_LanParcela().Select(filtro, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(id_config.Text))
            {
                MessageBox.Show("Obrigatório Informar configuração para gerar boleto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_config.Focus();
                return;
            }
            if (bsParcelas.Count <= 0)
            {
                MessageBox.Show("Não existe parcelas para gerar boleto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(bsParcelas.DataSource as TList_RegLanParcela).Exists(p => p.St_bloquetobool))
            {
                MessageBox.Show("Não existe parcela selecionado para gerar boleto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //Gerar Boleto Bancario
            try
            {
                blListaTitulo lTitulo = TCN_Titulo.GerarBloqueto(id_config.Text, 
                                                                 (bsParcelas.DataSource as TList_RegLanParcela).FindAll(p=> p.St_bloquetobool), 
                                                                 null);
                MessageBox.Show("Bloquetos gravados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                new TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor },
                                    new TCD_CadClifor());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.DataSource as TList_RegLanParcela).ForEach(p => p.St_bloquetobool = cbTodos.Checked);
                bsParcelas.ResetBindings(true);
            }
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsParcelas.Current as TRegistro_LanParcela).St_bloquetobool =
                    !(bsParcelas.Current as TRegistro_LanParcela).St_bloquetobool;
                bsParcelas.ResetCurrentItem();
            }
        }

        private void TFLan_Bloqueto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLan_Bloqueto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Codigo|60;" +
                              "a.cd_banco|Cd. Banco|60;" +
                              "b.ds_banco|Banco|100;" +
                              "a.cd_contager|Cd. Conta|60;" +
                              "e.ds_contager|Conta Gerencial|100;" +
                              "a.tp_cobranca|Tipo Cobrança|80;" +
                              "a.ds_instrucoes|Instruções|200";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, 
                                                       new Componentes.EditDefault[] { id_config, ds_config, cd_banco,
                                                       ds_banco, cd_contager, ds_contager, ds_instrucoes},
                                new TCD_CadCFGBanco(), "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'");
            if (linha != null)
                tp_cobranca.Text = linha["tp_cobranca"].ToString().Trim().Equals("CR") ? "COM REGISTRO" : "SEM REGISTRO";
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[]{id_config, ds_config,
                                                    cd_banco, ds_banco, cd_contager, ds_contager, ds_instrucoes},
                                                    new TCD_CadCFGBanco());
            if (linha != null)
                tp_cobranca.Text = linha["tp_cobranca"].ToString().Trim().Equals("CR") ? "COM REGISTRO" : "SEM REGISTRO";
        }
    }
}
