using System;
using System.Data;
using Componentes;
using Utils;
using System.Windows.Forms;

namespace FormBusca
{
    public class UtilPesquisa : Object
    {
        private static string modo = "N"; //NORMAL OU LISTA

        public static void BTN_BUSCALISTA(string vnm_colunas, EditDefault edit, CamadaDados.TDataQuery vclasse, string vParamFixo)
        {
            modo = "L";
              
            BTN_BUSCA(vnm_colunas, new EditDefault[] { edit }, vclasse, vParamFixo);

            modo = "N";        

        }

        public static DataRowView BTN_BUSCA(string vnm_colunas,
                                            EditDefault[] EditResult,
                                            CamadaDados.TDataQuery vclasse,
                                            string vParamFixo,
                                            string vParametroBusca)
        {
            TFBusca FBusca = new TFBusca();
            try
            {
                DataSet ds_config = new DataSet();
                try
                {

                    string vPath = Parametros.pubPathConfig;

                    if (!System.IO.Directory.Exists(vPath))                   
                        vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
                    if (vPath.Trim().Substring(vPath.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                        vPath += System.IO.Path.DirectorySeparatorChar.ToString();

                    if (System.IO.File.Exists(vPath + "configBusca.xml"))
                    {
                        ds_config.ReadXml(vPath + "configBusca.xml", XmlReadMode.ReadSchema);

                        if (EditResult != null)
                        {
                            object[] chave = new object[] { Parametros.pubLogin, EditResult[0].NM_CampoBusca };
                            DataRow linha = ds_config.Tables[0].Rows.Find(chave);
                            if (linha != null)
                            {
                                FBusca.Location = new System.Drawing.Point(Convert.ToInt32(linha["localx"].ToString().Trim()), Convert.ToInt32(linha["localy"].ToString().Trim()));
                                FBusca.Size = new System.Drawing.Size(Convert.ToInt32(linha["sizex"].ToString().Trim()), Convert.ToInt32(linha["sizey"].ToString().Trim()));
                                FBusca.campoBusca = linha["buscarpor"].ToString().Trim();
                                FBusca.nLinhas.Value = Convert.ToDecimal(linha["nlinhas"].ToString().Trim());
                            }
                            FBusca.login = Parametros.pubLogin;
                            FBusca.campoChave = EditResult[0].NM_CampoBusca;
                            FBusca.tb_configGrid = ds_config.Tables[1];
                        }
                    }
                }
                catch
                { }
                string[] vCampos = vnm_colunas.Split(new Char[] { ';' });
                FBusca.confBusca = new TpBusca[vCampos.Length];
                for (int i = 0; i < vCampos.Length; i++)
                {
                    string[] vPropriedades = vCampos[i].Split(new Char[] { '|' });
                    FBusca.confBusca[i].vNM_Campo = vPropriedades[0];
                    FBusca.confBusca[i].vNM_Caption = vPropriedades[1];
                    FBusca.confBusca[i].vWidth = Convert.ToInt16(vPropriedades[2]);
                    FBusca.confBusca[i].vOperador = "like";
                }
                if (!(vParamFixo == null))
                    if (vParamFixo.Length > 0)
                    {
                        vCampos = vParamFixo.Split(new char[] { ';' });
                        FBusca.aParamBusca = new TpBusca[vCampos.Length];
                        for (int i = 0; i < vCampos.Length; i++)
                        {
                            string[] vParam = vCampos[i].Split(new char[] { '|' });
                            FBusca.aParamBusca[i].vNM_Campo = vParam[0];
                            FBusca.aParamBusca[i].vVL_Busca = vParam[2];
                            FBusca.aParamBusca[i].vOperador = vParam[1];
                        }
                    }
                FBusca.NM_DatClass = vclasse;
                FBusca.pParametroBusca = vParametroBusca;
                if (FBusca.ShowDialog() == DialogResult.OK)
                {
                    if (modo == "N")
                    {
                        if (FBusca.gBusca.CurrentRow != null)
                            if (FBusca.gBusca.CurrentRow.Index > -1)
                            {
                                if (EditResult != null)
                                    for (int i = 0; i < EditResult.Length; i++)
                                        EditResult[i].Text = FBusca.gBusca["f" + EditResult[i].NM_CampoBusca,
                                                             FBusca.gBusca.CurrentRow.Index].Value.ToString().Trim();
                                return (FBusca.bSource.Current as DataRowView); 
                            }
                            else
                                return null; 
                        else
                            return null; 
                    }
                    else if (EditResult != null)
                    {
                        string t = string.Empty;
                        string v = string.Empty;
                        foreach (DataGridViewRow row in FBusca.gBusca.SelectedRows)
                        {
                            t += v + "'" + row.DataGridView["f" + EditResult[0].NM_CampoBusca, row.Index].Value.ToString().Trim() + "'";
                            v = ", ";
                        }
                        EditResult[0].Text = "(" + t + ")";
                        return null;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            finally
            {
                try
                {
                    DataSet ds = new DataSet();
                    string vPath = Parametros.pubPathConfig;
                    if (!System.IO.Directory.Exists(vPath))
                        vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
                    if (vPath.Trim().Substring(vPath.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                        vPath += System.IO.Path.DirectorySeparatorChar.ToString();
                    if (System.IO.File.Exists(vPath + "configBusca.xml"))
                        ds.ReadXml(vPath + "configBusca.xml");
                    else
                    {
                        DataTable dt_config = new DataTable("tb_config");
                        DataTable dt_configGrid = new DataTable("tb_configGrid");
                        ds.Tables.Add(dt_config);
                        ds.Tables.Add(dt_configGrid);
                        DataColumn vlogin = new DataColumn("login", Type.GetType("System.String"));
                        DataColumn codigo = new DataColumn("codigo", Type.GetType("System.String"));
                        DataColumn[] pk = new DataColumn[] { vlogin, codigo };
                        dt_config.Columns.Add(vlogin);
                        dt_config.Columns.Add(codigo);
                        dt_config.Columns.Add("localx", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("localy", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("sizex", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("sizey", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("buscarpor", Type.GetType("System.String"));
                        dt_config.Columns.Add("nlinhas", Type.GetType("System.Decimal"));
                        dt_config.PrimaryKey = pk;

                        DataColumn nLogin = new DataColumn("login", Type.GetType("System.String"));
                        DataColumn nCodigo = new DataColumn("codigo", Type.GetType("System.String"));
                        DataColumn nm_coluna = new DataColumn("nm_coluna", Type.GetType("System.String"));
                        DataColumn[] npk = new DataColumn[] { nLogin, nCodigo, nm_coluna };
                        dt_configGrid.Columns.Add(nLogin);
                        dt_configGrid.Columns.Add(nCodigo);
                        dt_configGrid.Columns.Add(nm_coluna);
                        dt_configGrid.PrimaryKey = npk;
                        dt_configGrid.Columns.Add("index", Type.GetType("System.Int32"));
                        dt_configGrid.Columns.Add("tamanho", Type.GetType("System.Int32"));
                    }
                    DataRow linha = linha = ds.Tables[0].NewRow();
                    linha["login"] = Parametros.pubLogin;
                    linha["codigo"] = EditResult != null ? EditResult[0].NM_CampoBusca : string.Empty;
                    linha["localx"] = FBusca.Location.X;
                    linha["localy"] = FBusca.Location.Y;
                    linha["sizex"] = FBusca.Size.Width;
                    linha["sizey"] = FBusca.Size.Height;
                    linha["buscarpor"] = FBusca.cbCampos.Text;
                    linha["nlinhas"] = FBusca.nLinhas.Value;
                    object[] chave = new object[] { Parametros.pubLogin, (EditResult != null ? EditResult[0].NM_CampoBusca : string.Empty) };
                    if (ds.Tables[0].Rows.Contains(chave))
                        ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(chave));
                    ds.Tables[0].Rows.Add(linha);

                    int cont = FBusca.gBusca.Columns.Count;
                    for (int i = 0; i < cont; i++)
                    {
                        linha = ds.Tables[1].NewRow();
                        linha["login"] = Parametros.pubLogin;
                        linha["codigo"] = EditResult != null ? EditResult[0].NM_CampoBusca.Trim() : string.Empty;
                        linha["nm_coluna"] = FBusca.gBusca.Columns[i].Name.Trim();
                        linha["index"] = FBusca.gBusca.Columns[i].DisplayIndex;
                        linha["tamanho"] = FBusca.gBusca.Columns[i].Width;
                        object[] nChave = new object[] { Parametros.pubLogin, (EditResult != null ? EditResult[0].NM_CampoBusca.Trim() : string.Empty), FBusca.gBusca.Columns[i].Name.Trim() };
                        if (ds.Tables[1].Rows.Contains(nChave))
                            ds.Tables[1].Rows.Remove(ds.Tables[1].Rows.Find(nChave));
                        ds.Tables[1].Rows.Add(linha);
                    }
                    ds.WriteXml(vPath + "configBusca.xml", XmlWriteMode.WriteSchema);
                }
                catch { }
                FBusca.Dispose();
            }
        }

        public static DataRowView BTN_BUSCA(string vnm_colunas, 
                                            EditDefault[] EditResult, 
                                            CamadaDados.TDataQuery vclasse, 
                                            string vParamFixo)
        {
            return BTN_BUSCA(vnm_colunas, EditResult, vclasse, vParamFixo, string.Empty);
        }
        
        public static DataRow EDIT_LEAVE(string vnm_colunas
            , EditDefault[] EditResult
            , CamadaDados.TDataQuery vclasse)
        {
            if (EditResult != null && (EditResult.Length > 0 ))
                if (EditResult[0].Text.Trim() != "")
                {
                    string[] vCampos = vnm_colunas.Split(new Char[] { ';' });
                    TpBusca[] vBusca = new TpBusca[vCampos.Length];
                    for (int i = 0; i < vCampos.Length; i++)
                    {
                        string[] vPropriedades = vCampos[i].Split(new Char[] { '|' });
                        vBusca[i].vNM_Campo = vPropriedades[0];
                        vBusca[i].vVL_Busca = vPropriedades[2];
                        vBusca[i].vOperador = vPropriedades[1];
                    }
                    DataTable tabela = vclasse.Buscar(vBusca, 1);
                    if (tabela != null)
                        if (tabela.Rows.Count > 0)
                        {
                            if (EditResult != null)
                                for (int i = 0; i < EditResult.Length; i++)
                                    EditResult[i].Text = tabela.Rows[0][EditResult[i].NM_CampoBusca].ToString().Trim();
                            return tabela.Rows[0];
                        }
                        else
                        {
                            if (EditResult != null)
                                for (int i = 0; i < EditResult.Length; i++)
                                    if (EditResult[i].Text.Trim() != "0")
                                        EditResult[i].Text = string.Empty;
                            return null;
                        }
                    else
                        return null;
                }
                else
                    return null;
            else
                return null;
        }

        public static void CarregarPanel(PanelDados vPanel, DataGridDefault vDataGrid, TTpModo vTpModo)
        {
            if (vDataGrid.DataSource != null)
                if ((vDataGrid.DataSource is BindingSource))
                {
                    if ((((vDataGrid.DataSource as BindingSource).DataSource as DataTable).Rows.Count > 0) &&
                        (vDataGrid.CurrentRow != null))
                        vPanel.CarregarRegistro(((vDataGrid.DataSource as BindingSource).DataSource as DataTable).Rows[vDataGrid.CurrentRow.Index], vTpModo);
                }
                else if (((vDataGrid.DataSource as DataTable).Rows.Count > 0) &&
                          (vDataGrid.CurrentRow != null))
                    vPanel.CarregarRegistro((vDataGrid.DataSource as DataTable).Rows[vDataGrid.CurrentRow.Index], vTpModo);
        }

        public static DataRowView BTN_BuscaProduto(EditDefault[] EditResult, 
                                                   string vParamFixo, 
                                                   string vParametroBusca)
        {
            string vColunas = "DS_Produto|Descrição Produto|350;" +
                              "CD_Produto|Cód. Produto|100;" +
                              "a.codigo_alternativo|Referencia|80;" +
                              "a.ds_tecnica|Descrição Tecnica|200;" +
                              "f.ds_Marca|Marca|100;" +
                              "b.ds_Unidade|Unidade|100;" +
                              "b.sigla_unidade|UND|80;" +
                              "c.ds_Grupo|Grupo|100;" +
                              "a.cd_condfiscal_produto|Cd. CondFiscal|80;" +
                              "d.ds_condfiscal_produto|Condição Fiscal|100";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") + "isnull(a.st_registro, 'A')|<>|'C'";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), vParamFixo, vParametroBusca);
        }

        public static DataRowView BTN_BuscaContratoGRO(EditDefault[] EditResult,
                                                       string vParamFixo)
        {
            string vColunas = "a.nr_contrato|Nº Contrato|80;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "f.nm_empresa|Empresa|150;" +
                              "a.cd_clifor|Cd. Clifor|80;" +
                              "d.nm_clifor|Cliente/Fornecedor|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "prod.ds_produto|Produto|200;" +
                              "a.tp_movimento|Tipo Movimento|80;" +
                              "a.nr_pedido|Nº Pedido|80;" +
                              "a.quantidade|Quantidade|80;" +
                              "a.vl_unitario|Vl. Unitario|80;" +
                              "a.vl_subtotal|Vl. SubTotal|80;" +
                              "prod.CD_Unidade|Unidade Produto|80;" +
                              "a.cd_unidade|Unidade Contrato|80;" +
                              "a.dt_abertura|Dt. Contrato|80;" +
                              "a.NR_CGCCPF|CNPJ/CPF Contratante|80;" +
                              "e.ds_endereco|Endereço|150;" +
                              "e.ds_cidade|Cidade|100;" +
                              "e.uf|UF|60;" +
                              "a.AnoSafra|Ano Safra|60;" +
                              "a.cd_local|Cd. Local|80;" +
                              "lArm.DS_Local|Local Armazenagem|150;" +
                              "a.cd_tabeladesconto|Cd. Tabela|80;" +
                              "b.ds_tabeladesconto|Tabela Desconto|200";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Graos.TCD_CadContrato(), vParamFixo);
        }

        public static DataRowView BTN_BuscaProduto(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "DS_Produto|Descrição Produto|350;" +
                              "CD_Produto|Cód. Produto|100;" +
                              "a.codigo_alternativo|Referencia|80;" +
                              "a.ds_tecnica|Descrição Tecnica|200;" +
                              "f.ds_Marca|Marca|100;" +
                              "a.cd_unidade|Cd. Unidade|80;" +
                              "b.ds_Unidade|Unidade|100;" +
                              "b.sigla_unidade|UND|80;" +
                              "c.ds_Grupo|Grupo|100;" +
                              "a.cd_condfiscal_produto|Cd. CondFiscal|80;" +
                              "d.ds_condfiscal_produto|Condição Fiscal|100;" +
                              "a.id_caracteristicaH|Id. Caracteristica|80";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") + "isnull(a.st_registro, 'A')|<>|'C'";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), vParamFixo);
        }

        public static DataRow EDIT_LEAVEProduto(string vCond, EditDefault[] EditResult, CamadaDados.TDataQuery vClasse)
        {
            vCond += ";isnull(a.st_registro, 'A')|<>|'C'";
            return EDIT_LEAVE(vCond, EditResult, vClasse);
        }

        public static DataRowView BTN_BuscaClifor(EditDefault[] EditResult, 
                                                  string vParamFixo,
                                                  string vParametroBusca)
        {
            string vColunas = "a.nm_clifor|Nome Clifor|300;" +
                              "a.cd_clifor|Código Clifor|90;" +
                              "a.nr_cgc|C.N.P.J|80;" +
                              "a.nr_cpf|C.P.F|80;" +
                              "a.nr_rg|R.G|80;" +
                              "a.tp_pessoa|Tipo Pessoa|80;" +
                              "a.nm_fantasia|Fantasia|100;" +
                              "a.cd_condfiscal_clifor|Condição Fiscal|80";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") + "isnull(a.st_registro, 'A')|<>|'C'";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParamFixo, vParametroBusca);
        }

        public static DataRowView BTN_BuscaClifor(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.nm_clifor|Nome Clifor|300;" +
                              "a.cd_clifor|Código Clifor|90;" +
                              "a.nr_cgc|C.N.P.J|80;" +
                              "a.nr_cpf|C.P.F|80;" +
                              "a.nr_rg|R.G|80;" +
                              "a.tp_pessoa|Tipo Pessoa|80;" +
                              "a.nm_fantasia|Fantasia|100;" +
                              "a.cd_condfiscal_clifor|Condição Fiscal|80";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") + "isnull(a.st_registro, 'A')|<>|'C'";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParamFixo);
        }

        //Utilizado para listar vendedores cancelados
        public static DataRowView BTN_BuscaCliforC(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.nm_clifor|Nome Clifor|300;" +
                              "a.cd_clifor|Código Clifor|90;" +
                              "a.nr_cgc|C.N.P.J|80;" +
                              "a.nr_cpf|C.P.F|80;" +
                              "a.nr_rg|R.G|80;" +
                              "a.tp_pessoa|Tipo Pessoa|80;" +
                              "a.nm_fantasia|Fantasia|100;" +
                              "a.cd_condfiscal_clifor|Condição Fiscal|80";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : "");
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParamFixo);
        }

        public static DataRowView BTN_BuscaContaGer(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Código|60";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") +
                          "|exists|(select 1 from tb_div_usuario_x_contager x " +
                          "where x.cd_contager = a.cd_contager " +
                          "and x.login = '" + Parametros.pubLogin.Trim() + "')";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
        }

        public static DataRow EDIT_LeaveContaGer(string vCond, EditDefault[] EditResult)
        {
            if (!string.IsNullOrEmpty(vCond))
                vCond += ";|exists|(select 1 from tb_div_usuario_x_contager x " +
                         "where x.cd_contager = a.cd_contager " +
                         "and x.login = '" + Parametros.pubLogin.Trim() + "')";
            return EDIT_LEAVE(vCond, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        public static DataRow EDIT_LeaveClifor(string vCond, EditDefault[] EditResult, CamadaDados.TDataQuery vClasse)
        {
            if(!string.IsNullOrEmpty(vCond))
                vCond += ";isnull(a.st_registro, 'A')|<>|'C'";
            return EDIT_LEAVE(vCond, EditResult, vClasse);
        }

        public static DataRow EDIT_LeaveCliforC(string vCond, EditDefault[] EditResult, CamadaDados.TDataQuery vClasse)
        {
            return EDIT_LEAVE(vCond, EditResult, vClasse);
        }

        public static DataRowView BTN_BuscaEmpresa(EditDefault[] EditResult,
                                                   string vParamFixo)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") +
                            "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        public static DataRow EDIT_LeaveEmpresa(string vCond, EditDefault[] EditResult)
        {
            if (!string.IsNullOrEmpty(vCond))
                vCond += ";|exists|(select 1 from tb_div_usuario_x_empresa x " +
                         "where x.cd_empresa = a.cd_empresa " +
                         "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return EDIT_LEAVE(vCond, EditResult, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        public static DataRowView BTN_BuscaTpPesagem(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.nm_tppesagem|Tipo Pesagem|200;" +
                              "a.tp_pesagem|TP. Pesagem|80";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") +
                            "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem(), vParamFixo);
        }

        public static DataRow EDIT_LeaveTpPesagem(string vCond, EditDefault[] EditResult)
        {
            if (!string.IsNullOrEmpty(vCond))
                vCond += "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                         "           where x.tp_pesagem = a.tp_pesagem " +
                         "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                         "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                         "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return EDIT_LEAVE(vCond, EditResult, new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem());
        }

        public static DataRowView BTN_BuscaTpDuplicata(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.DS_TpDuplicata|Tipo Duplicata|350;" +
                              "a.TP_Duplicata|TP. Duplicata|100;" +
                              "a.TP_Mov|Tipo Movimento|100;" +
                              "a.cd_contager_boletoauto|Cd. Conta|80;" +
                              "cg.ds_contager|Conta Gerencial|200";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") +
                            "|exists|(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                            "where x.tp_duplicata = a.tp_duplicata " +
                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParamFixo);
        }

        public static DataRow EDIT_LeaveTpDuplicata(string vCond, EditDefault[] EditResult)
        {
            if (!string.IsNullOrEmpty(vCond))
                vCond += "|EXISTS|(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                         "           where x.tp_duplicata = a.tp_duplicata " +
                         "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                         "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                         "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            return EDIT_LEAVE(vCond, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        public static CamadaDados.Estoque.Cadastros.TRegistro_CadProduto BuscarProduto(string filtro,
                                                                                       string Cd_empresa,
                                                                                       string Nm_empresa,
                                                                                       string Cd_tabelapreco,
                                                                                       EditDefault[] EditResult,
                                                                                       TpBusca[] vParamFixo)
        {
            using (TFBuscaProduto fBusca = new TFBuscaProduto())
            {
                try
                {
                    DataSet ds_config = new DataSet();
                    try
                    {

                        string vPath = Parametros.pubPathConfig;

                        if (!System.IO.Directory.Exists(vPath))
                            vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
                        if (vPath.Trim().Substring(vPath.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                            vPath += System.IO.Path.DirectorySeparatorChar.ToString();

                        if (System.IO.File.Exists(vPath + "configBusca.xml"))
                        {
                            ds_config.ReadXml(vPath + "configBusca.xml", XmlReadMode.ReadSchema);

                            if (EditResult != null)
                            {
                                object[] chave = new object[] { Parametros.pubLogin, "FBuscaProduto" };
                                DataRow linha = ds_config.Tables[0].Rows.Find(chave);
                                if (linha != null)
                                {
                                    fBusca.Location = new System.Drawing.Point(Convert.ToInt32(linha["localx"].ToString().Trim()), Convert.ToInt32(linha["localy"].ToString().Trim()));
                                    fBusca.Size = new System.Drawing.Size(Convert.ToInt32(linha["sizex"].ToString().Trim()), Convert.ToInt32(linha["sizey"].ToString().Trim()));
                                    fBusca.nLinhas.Value = Convert.ToDecimal(linha["nlinhas"].ToString().Trim());
                                }
                            }
                        }
                    }
                    catch
                    { }
                    fBusca.Cd_empresa = Cd_empresa;
                    fBusca.Nm_empresa = Nm_empresa;
                    fBusca.Cd_tabelapreco = Cd_tabelapreco;
                    fBusca.filtro = filtro;
                    fBusca.vParamFixo = vParamFixo;
                    if (vParamFixo == null)
                        vParamFixo = new TpBusca[0];
                    Array.Resize(ref vParamFixo, vParamFixo.Length + 1);
                    vParamFixo[vParamFixo.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                    vParamFixo[vParamFixo.Length - 1].vOperador = "<>";
                    vParamFixo[vParamFixo.Length - 1].vVL_Busca = "'C'";
                    if (fBusca.ShowDialog() == DialogResult.OK)
                        if (fBusca.rProd != null)
                        {
                            if (EditResult != null)
                                if (EditResult.Length > 0)
                                    foreach (EditDefault edt in EditResult)
                                    {
                                        Type tp = typeof(CamadaDados.Estoque.Cadastros.TRegistro_CadProduto);
                                        System.Reflection.PropertyInfo[] pi = tp.GetProperties();
                                        foreach (System.Reflection.PropertyInfo p in pi)
                                            if (p.Name.Trim().ToUpper().Equals(edt.NM_CampoBusca.Trim().ToUpper()))
                                            {
                                                object obj = p.GetValue(fBusca.rProd, null);
                                                if (obj != null)
                                                    edt.Text = obj.ToString();
                                            }
                                    }
                            return fBusca.rProd;
                        }
                        else
                            return null;
                    else
                        return null;
                }
                finally
                {
                    DataSet ds = new DataSet();
                    string vPath = Parametros.pubPathConfig;
                    if (!System.IO.Directory.Exists(vPath))
                        vPath = Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar;
                    if (vPath.Trim().Substring(vPath.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                        vPath += System.IO.Path.DirectorySeparatorChar.ToString();
                    if (System.IO.File.Exists(vPath + "configBusca.xml"))
                        ds.ReadXml(vPath + "configBusca.xml");
                    else
                    {
                        DataTable dt_config = new DataTable("tb_config");
                        DataTable dt_configGrid = new DataTable("tb_configGrid");
                        ds.Tables.Add(dt_config);
                        ds.Tables.Add(dt_configGrid);
                        DataColumn vlogin = new DataColumn("login", Type.GetType("System.String"));
                        DataColumn codigo = new DataColumn("codigo", Type.GetType("System.String"));
                        DataColumn[] pk = new DataColumn[] { vlogin, codigo };
                        dt_config.Columns.Add(vlogin);
                        dt_config.Columns.Add(codigo);
                        dt_config.Columns.Add("localx", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("localy", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("sizex", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("sizey", Type.GetType("System.Int32"));
                        dt_config.Columns.Add("buscarpor", Type.GetType("System.String"));
                        dt_config.Columns.Add("nlinhas", Type.GetType("System.Decimal"));
                        dt_config.PrimaryKey = pk;
                    }
                    DataRow linha = linha = ds.Tables[0].NewRow();
                    linha["login"] = Parametros.pubLogin;
                    linha["codigo"] = "FBuscaProduto";
                    linha["localx"] = fBusca.Location.X;
                    linha["localy"] = fBusca.Location.Y;
                    linha["sizex"] = fBusca.Size.Width;
                    linha["sizey"] = fBusca.Size.Height;
                    linha["nlinhas"] = fBusca.nLinhas.Value;
                    object[] chave = new object[] { Parametros.pubLogin, "FBuscaProduto" };
                    if (ds.Tables[0].Rows.Contains(chave))
                        ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(chave));
                    ds.Tables[0].Rows.Add(linha);
                    try
                    {
                        ds.WriteXml(vPath + "configBusca.xml", XmlWriteMode.WriteSchema);
                    }
                    catch { }
                }
            }
        }

        public static DataRowView BTN_BuscaEndereco(EditDefault[] EditResult, string vParamFixo)
        {
            string vColunas = "a.ds_endereco|Endereço|350;" +
                              "a.cd_endereco|Código|60;" +
                              "a.numero|Numero|60;" +
                              "a.bairro|Bairro|100;" +
                              "a.cep|CEP|50;" +
                              "a.ds_cidade|Cidade|100;" +
                              "a.ds_uf|Estado|30;" +
                              "a.UF|UF|20;" +
                              "a.cd_uf|Cd. UF|40;" +
                              "a.insc_estadual|Insc. Estadual|60;" +
                              "a.cd_cidade|Cd. Cidade|60;" +
                              "a.ds_complemento|Complemento|150";
            vParamFixo += (string.IsNullOrEmpty(vParamFixo) ? string.Empty : ";") +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            return BTN_BUSCA(vColunas, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParamFixo);
        }

        public static DataRow EDIT_LeaveEndereco(string vCond, EditDefault[] EditResult)
        {
            vCond += ";isnull(a.st_registro, 'A')|<>|'C'";
            return EDIT_LEAVE(vCond, EditResult, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        public static CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas BTN_BuscaContaCTB(TpBusca[] filtro)
        {
            using (TFBuscarContasContabeis fBusca = new TFBuscarContasContabeis())
            {
                fBusca.pFiltro = filtro;
                if (fBusca.ShowDialog() == DialogResult.OK)
                    return fBusca.rConta;
                else return null;
            }
        }
    }
}
