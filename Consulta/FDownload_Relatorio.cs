using System;
using System.Windows.Forms;
using Utils;
using System.Collections;
using CamadaDados.Diversos;
using CamadaDados.Consulta.Cadastro;
using BancoDados;
using CamadaNegocio.Consulta.Cadastro;
using CamadaNegocio.Diversos;
using System.Collections.Generic;

namespace Consulta
{
    public partial class TFDownload_Relatorio : Form
    {
        public string vURLWebService = "";
        public string vSistema = "AL";

        public TFDownload_Relatorio()
        {
            InitializeComponent();
            this.Icon = ResourcesUtils.TecnoAliance_ICO;

            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("Almoxarifado", "AMX"));
            cbx.Add(new TDataCombo("Balança", "BAL"));
            cbx.Add(new TDataCombo("Compras", "CMP"));
            cbx.Add(new TDataCombo("Consulta", "CON"));
            cbx.Add(new TDataCombo("Contabilidade", "CTB"));
            cbx.Add(new TDataCombo("Empreendimento", "EMP"));
            cbx.Add(new TDataCombo("Parametros", "DIV"));
            cbx.Add(new TDataCombo("Estoque", "EST"));
            cbx.Add(new TDataCombo("Produção", "PRD"));
            cbx.Add(new TDataCombo("Faturamento", "FAT"));
            cbx.Add(new TDataCombo("Fazenda", "FAZ"));
            cbx.Add(new TDataCombo("Financeiro", "FIN"));
            cbx.Add(new TDataCombo("Fiscal", "FIS"));
            cbx.Add(new TDataCombo("Frente Caixa", "PDV"));
            cbx.Add(new TDataCombo("Frota", "FRT"));
            cbx.Add(new TDataCombo("Grãos", "GRO"));
            cbx.Add(new TDataCombo("Mudança", "MUD"));
            cbx.Add(new TDataCombo("Locação", "LOC"));
            cbx.Add(new TDataCombo("Ordem Serviço", "OSE"));
            cbx.Add(new TDataCombo("Posto Combustivel", "POC"));
            cbx.Add(new TDataCombo("Sementes", " SEM"));

            cbModulo.DataSource = cbx;
            cbModulo.DisplayMember = "Display";
            cbModulo.ValueMember = "Value";
        }

        #region "BOTÕES DA TOOL STRIP"

            private void BB_Limpar_Click(object sender, EventArgs e)
            {
                pDadosFiltros.LimparRegistro();
                cbModulo.Focus();
            }

            private void BB_Buscar_Click(object sender, EventArgs e)
            {
                buscarRegistros();
            }

            private void BB_Relatorio_Click(object sender, EventArgs e)
            {
                if (BS_Download.Current != null)
                {
                    CamadaDados.WS_RDC.TRegistro_Cad_RDC lista = ServiceRest.DataService.BuscarDetalhesRDC((BS_Download.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).ID_RDC);
                    if (lista != null)
                    {
                        (BS_Download.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report = lista.Code_Report;
                        BS_Download.ResetCurrentItem();
                        //o rel já esta cadastrado diretamente
                        TRegistro_Cad_Report Cad_Report = FormRelPadrao.AtualizarRDC.ConvertRDCparaReport(lista);

                        Query_Report relatorio = new Query_Report();
                        relatorio.Homologacao = true;
                        relatorio.MontaFormRelatorio(Cad_Report, null);
                    }
                }
                else
                    MessageBox.Show("Atenção é necessário selecionar um RDC!", "Mensagem");
            }

            private void BB_Fechar_Click(object sender, EventArgs e)
            {
                this.Dispose();
            }

            private void BB_Download_Click(object sender, EventArgs e)
            {
                if (BS_Download.Current != null)
                {
                    try
                    {
                        object obj = new TCD_Cad_Report().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.ID_RDC",
                                        vOperador = "=",
                                        vVL_Busca = "'"+(BS_Download.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).ID_RDC + "'"
                                    }
                                }, "1");
                        if (obj != null)
                            if (obj.ToString().Trim().ToUpper().Equals("1"))
                                throw new Exception("Atenção, este relatório já esta cadastrado!");

                        //FAZ O DOWNLOAD DO MESMO RELATORIO
                        TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
                        try
                        {
                            qtb_Report.CriarBanco_Dados(true);
                            TObjetoBanco banco = qtb_Report.Banco_Dados;

                            //BUSCA O RELATORIO SELECIONADO
                            CamadaDados.WS_RDC.TRegistro_Cad_RDC lista = ServiceRest.DataService.BuscarDetalhesRDC((BS_Download.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).ID_RDC);

                            if (lista != null)
                            {
                                (BS_Download.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report = lista.Code_Report;
                                BS_Download.ResetCurrentItem();
                            }
                            else
                                throw new Exception("Atenção, houve erro ao fazer o download do relatório, por favor tente novamente!");

                            //o rel já esta cadastrado diretamente
                            TRegistro_Cad_Report Cad_Report = FormRelPadrao.AtualizarRDC.ConvertRDCparaReport(lista);

                            //GRAVA O RELATORIO
                            string retorno = TCN_Cad_Report.GravarReportConsulta(Cad_Report, banco);
                            Cad_Report.ID_Report = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_REPORT"));

                            //GRAVA O MENU
                            TFEscolha_Menu fMenu = new TFEscolha_Menu();
                            fMenu.Cad_Report = Cad_Report;
                            fMenu.banco = banco;

                            if (fMenu.ShowDialog() == DialogResult.OK)
                            {
                                string retornomenu = TCN_Cad_Report.GravarReportXMenu(Cad_Report, fMenu.Reg_CadMenu, banco);
                                
                                //GRAVA ACESSO PARA O USUARIO
                                TRegistro_CadAcesso regAcesso = new TRegistro_CadAcesso();
                                regAcesso.Id_menu = fMenu.Reg_CadMenu.id_menu;
                                regAcesso.Login = Parametros.pubLogin;

                                TCN_CadAcesso.GravarAcesso(regAcesso, banco);
                            }
                            else
                                throw new Exception("Atenção, é necessário informar o menu!");

                            qtb_Report.Banco_Dados.Commit_Tran();

                            //CARREGA NOVAMENTE O MENU
                            Type t = Application.OpenForms["FMenuPrin"].GetType();
                            t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { "MASTER", true });
                        }
                        catch (Exception ex)
                        {
                            qtb_Report.Banco_Dados.RollBack_Tran();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            qtb_Report.deletarBanco_Dados();
                        }

                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Mensagem");
                    }
                }
            }

        #endregion

        #region "AÇÕES DA CAMADA DE DADOS"

            public void buscarRegistros()
            {
                try
                {
                    List<CamadaDados.WS_RDC.TRegistro_Cad_RDC> lista = ServiceRest.DataService.BuscarRDC(string.Empty, DS_RDC.Text, cbModulo.SelectedValue.ToString(), "P", false, true);
                    if (lista != null)
                        if (lista.Count > 0)
                            BS_Download.DataSource = lista;
                        else
                            BS_Download.Clear();
                    else
                        BS_Download.Clear();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Mensagem");
                }
            }

        #endregion

            private void TFDownload_Relatorio_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }

    }
}
