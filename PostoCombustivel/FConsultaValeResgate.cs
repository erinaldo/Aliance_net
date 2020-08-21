using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFConsultaValeResgate : Form
    {
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto rCfgPosto
        { get; set; }
        public string LoginPDV { get; set; }
        private bool Altera_Relatorio = false;

        public TFConsultaValeResgate()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if ((placa.Text.Trim().Length != 8) && (string.IsNullOrEmpty(CD_Clifor.Text)))
            {
                MessageBox.Show("Obrigatório informar placa ou cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                placa.Focus();
                return;
            }
                                    
            if (tcCentral.SelectedTab.Equals(tpVale))
                bsValeResgate.DataSource = CamadaNegocio.Faturamento.Fidelizacao.TCN_ValeResgate.Buscar(rCfgPosto.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        placa.Text,
                                                                                                        CD_Clifor.Text,
                                                                                                        dt_ini.Text,
                                                                                                        dt_fin.Text,
                                                                                                        "A",
                                                                                                        null);
            else
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                if (!string.IsNullOrWhiteSpace(placa.Text.Replace("-", string.Empty)))
                {
                    //Por placa
                    filtro[0].vNM_Campo = "replace(a.placa, '-', '')";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + placa.Text.Replace("-", string.Empty) + "'";
                }
                else
                {
                    //Por cliente
                    filtro[0].vNM_Campo = "a.cd_clifor";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + CD_Clifor.Text + "'";
                }
                //Saldo Pontos
                filtro[1].vNM_Campo = "a.qt_pontos - a.pontos_res";
                filtro[1].vOperador = ">";
                filtro[1].vVL_Busca = "0";
                //Não estar cancelado
                filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                if (tcCentral.SelectedTab.Equals(tpPontos))
                {
                    //Não estar expirado
                    filtro[3].vNM_Campo = string.Empty;
                    filtro[3].vOperador = string.Empty;
                    filtro[3].vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))";

                    if (dt_ini.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_registro)))";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (dt_fin.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_registro)))";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                    }
                    bsPontosFid.DataSource = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().Select(filtro, 0, string.Empty, "a.dt_validade desc");
                    tot_pontos_resgatar.Text = (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p => p.SD_Pontos).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                }
                else //Pontos Expirados
                {
                    filtro[3].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_validade, getdate()))))";
                    filtro[3].vOperador = "<";
                    filtro[3].vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))";
                    bsPontosExpirados.DataSource = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().Select(filtro, 0, string.Empty, "a.dt_validade desc");
                    totExpirados.Text = (bsPontosExpirados.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p => p.SD_Pontos).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
        }

        private void ExcluirItem()
        {
            if (bsValeResgate.Current != null)
            {
                if (MessageBox.Show("Confirma cancelamento do vale selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).St_impressobool)
                    {
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                (bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).Logincanc = fRegra.Login;
                            else return;
                        }
                    }
                    try
                    {
                        CamadaNegocio.Faturamento.Fidelizacao.TCN_ValeResgate.Excluir(bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate, null);
                        MessageBox.Show("Vale cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ImprimirVale(List<string> texto)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFEmiteValePontosFid";
            Relatorio.NM_Classe = "TFEmiteValePontosFid";
            Relatorio.Modulo = "PDV";
            Relatorio.Ident = "TFEmiteValePontosFid";
            Relatorio.Altera_Relatorio = Altera_Relatorio;


            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            if(!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
						                         1);
            Altera_Relatorio = false;
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void TFConsultaValeResgate_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            painel.set_FormatZero();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            if (bsValeResgate.Current != null)
            {
                if ((bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).St_impressobool)
                {
                    MessageBox.Show("Não é permitido reimprimir vale.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    try
                    {
                        //Imprimir Vale
                        List<string> Texto = new List<string>();
                        Texto.Add("                RESGATE PONTOS                 ");
                        Texto.Add("PLACA: " + (bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).Placa + 
                            "          VALE: " + (bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).Id_valestr);
                        Texto.Add("DATA EMISSAO: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss"));
                        //Buscar Convenio e clifor
                        CamadaDados.PostoCombustivel.TList_VendaCombustivel lVenda =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from VTB_FAT_PONTOSFIDELIDADE x " +
		                                             "inner join TB_FAT_ResgatePontos y " +
		                                             "on x.CD_Empresa = y.CD_Empresa " +
		                                             "and x.ID_Ponto = y.ID_Ponto " +
		                                             "where x.cd_empresa = a.CD_Empresa " +
		                                             "and x.Id_Cupom = a.Id_Cupom " +
		                                             "and y.ID_Vale = "+ (bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).Id_valestr + ")" 
                                    }
                                }, 1, string.Empty, string.Empty);
                        //Buscar Nº Dias Validade
                        if (rCfgPosto.diasValidadeVale > decimal.Zero)
                            Texto.Add("DT.VALIDADE: " + CamadaDados.UtilData.Data_Servidor().AddDays(int.Parse(rCfgPosto.diasValidadeVale.ToString())).ToString("dd/MM/yyyy"));
                        Texto.Add(string.Empty);
                        Texto.Add(string.Empty);
                        //Verificar se existe msg especifica para clifor do convenio                     
                        //Buscar msg
                        if (!string.IsNullOrEmpty(lVenda[0].Nm_clifor))
                        {
                            Texto.Add(lVenda[0].Nm_clifor);
                            Texto.Add(string.Empty);
                            Texto.Add(string.Empty);
                        }
                        string Ds_msgVale_Clifor =
                            new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().BuscarEscalar(
                                new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + lVenda[0].Cd_clifor.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_convenio",
                                vOperador = "=",
                                vVL_Busca = lVenda[0].Id_conveniostr
                            }
                        }, "a.ds_msgvale").ToString();
                        if (string.IsNullOrEmpty(Ds_msgVale_Clifor))
                            Texto.Add(rCfgPosto.Ds_msgvale.Trim().ToUpper());
                        else
                            Texto.Add(Ds_msgVale_Clifor);
                        Texto.Add(string.Empty);
                        Texto.Add(string.Empty);
                        object obj = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "replace(a.placa, '-', '')",
                                                vOperador = "=",
                                                vVL_Busca = "'" + placa.Text.Replace("-", string.Empty) + "'"
                                            }
                                        }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                        Texto.Add("PONTOS RESGATAR: " + (obj == null ? "0" : obj.ToString()));
                        ImprimirVale(Texto);
                        //Marcar vale como impresso
                        try
                        {
                            (bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate).St_impresso = "S";
                            CamadaNegocio.Faturamento.Fidelizacao.TCN_ValeResgate.Gravar(bsValeResgate.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    catch { }
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void TFConsultaValeResgate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_resgatar_Click(object sender, EventArgs e)
        {
            if (bsPontosFid.Count > 0)
            {
                if ((bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p => p.SD_Pontos) >= rCfgPosto.Qt_pontosvale_fid)
                    using (TFEmiteValePontosFid fVale = new TFEmiteValePontosFid())
                    {
                        fVale.rCfgPosto = rCfgPosto;
                        (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).ForEach(p => fVale.lPontos.Add(p));
                        fVale.pPlaca = placa.Text;
                        fVale.LoginPDV = LoginPDV;
                        fVale.pCd_clifor = (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Cd_clifor;
                        fVale.pNm_clifor = (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Nm_clifor;
                        fVale.ShowDialog();
                        afterBusca();
                    }
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((placa.Text.Trim().Length != 8) && (string.IsNullOrEmpty(CD_Clifor.Text)))
                return;
            afterBusca();
        }
    }
}
