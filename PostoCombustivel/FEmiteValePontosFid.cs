using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFEmiteValePontosFid : Form
    {
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto rCfgPosto { get; set; }
        public CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lPontos { get; set; }
        public string pPlaca { get; set; }
        public string pId_Convenio { get; set; }
        public string pCpf_motorista { get; set; }
        public string pNm_motorista { get; set; }
        public string pCd_clifor { get; set; }
        public string pNm_clifor { get; set; }
        public string LoginPDV { get; set; }
        private bool Altera_Relatorio = false;

        public TFEmiteValePontosFid()
        {
            InitializeComponent();
            lPontos = new CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade();
        }

        private void BuscarValesDia()
        {
            if (rCfgPosto.Qt_maxvaledia > decimal.Zero)
            {
                TpBusca[] filtro = new TpBusca[3];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'";
                filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[1].vOperador = "<>";
                filtro[1].vVL_Busca = "'C'";
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "exists";
                filtro[2].vVL_Busca = "(select 1 from tb_fat_pontosfidelidade x " +
                                      "inner join tb_fat_resgatepontos y " +
                                      "on x.cd_empresa = y.cd_empresa " +
                                      "and x.id_ponto = y.id_ponto " +
                                      "where y.cd_empresa = a.cd_empresa " +
                                      "and y.id_vale = a.id_vale " +
                                      "and convert(datetime, floor(convert(decimal(30,10), y.dt_resgate))) = convert(datetime, floor(convert(decimal(30,10), getdate()))) " +
                                      "and " + (pPlaca.Trim().Length.Equals(8) ? "replace(x.placa, '-', '') = '" + pPlaca.Replace("-", string.Empty) + "')" :
                                      !string.IsNullOrEmpty(pCpf_motorista.SoNumero()) ? "x.cpf_cliente = '" + pCpf_motorista.Trim() + "')" :
                                      "a.cd_clifor = '" + pCd_clifor.Trim() + "')");
                object obj = new CamadaDados.Faturamento.Fidelizacao.TCD_ValeResgate().BuscarEscalar(filtro, "count(*)");
                if (obj != null)
                    vales_impressos.Value = decimal.Parse(obj.ToString());
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

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCfgPosto.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);

            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
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

        private void TFEmiteValePontosFid_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            placa.Text = pPlaca;
            CdCliente.Text = pCd_clifor;
            NmCliente.Text = pNm_clifor;
            pontos_resgatar.Value = lPontos.Sum(p => p.SD_Pontos);
            BuscarValesDia();
        }

        private void bb_resgatar_Click(object sender, EventArgs e)
        {
            if (lPontos.Sum(p => p.SD_Pontos) < rCfgPosto.Qt_pontosvale_fid)
            {
                MessageBox.Show("Saldo de pontos insuficiente para emitir VALE<Pontos necessários por vale: " + rCfgPosto.Qt_pontosvale_fid.ToString() + ">.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string loginautoriza = string.Empty;
            if(rCfgPosto.Qt_maxvaledia > decimal.Zero)
                if(rCfgPosto.Qt_maxvaledia <= vales_impressos.Value)
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "AUTORIZA EMISSÃO VALE PONTOS FIDELIZAÇÃO";
                        if (fRegra.ShowDialog() == DialogResult.OK)
                            loginautoriza = fRegra.Login;
                        else return;
                    }
            CamadaDados.Faturamento.Fidelizacao.TRegistro_ValeResgate rVale = null;
            try
            {
                rVale = CamadaNegocio.PostoCombustivel.TCN_Convenio_Clifor.ResgatarPontosFid(lPontos, rCfgPosto.Qt_pontosvale_fid, LoginPDV, loginautoriza, null);
                lPontos.RemoveAll(p => p.SD_Pontos.Equals(decimal.Zero));
                pontos_resgatar.Value = lPontos.Sum(p => p.SD_Pontos);
                BuscarValesDia();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            try
            {
                //Imprimir Vale
                List<string> Texto = new List<string>();
                Texto.Add("                RESGATE PONTOS                 ");
                Texto.Add("VALE Nr.: " + rVale.Id_valestr);
                if (!string.IsNullOrWhiteSpace(pPlaca.Replace("-", string.Empty)))
                    Texto.Add("PLACA: " + pPlaca.Trim() + "          VALE: " + rVale.Id_valestr);
                else Texto.Add("CLIENTE: " + pCd_clifor.Trim() + "-" + pNm_clifor.Trim());
                Texto.Add("DATA EMISSAO: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss"));
                //Buscar Nº Dias Validade
                if (rCfgPosto.diasValidadeVale > decimal.Zero)
                    Texto.Add("DT.VALIDADE: " + CamadaDados.UtilData.Data_Servidor().AddDays(int.Parse(rCfgPosto.diasValidadeVale.ToString())).ToString("dd/MM/yyyy"));
                Texto.Add(string.Empty);
                Texto.Add(string.Empty);
                Texto.Add(string.Empty);
                //Verificar se existe msg especifica para clifor do convenio
                string Ds_msgVale_Clifor = string.Empty;
                if (!string.IsNullOrEmpty(pId_Convenio))
                {
                    object obj = new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "a.cd_clifor = '" + pCd_clifor.Trim() + 
                                                        "' or exists(select 1 from TB_PDC_Convenio_X_Placa x " +
                                                                    "where a.id_convenio = x.id_convenio " +
                                                                    "and a.cd_empresa = x.cd_empresa " +
                                                                    "and a.cd_clifor = x.cd_clifor " +
                                                                    "and a.cd_endereco = x.cd_endereco " +
                                                                    "and a.cd_produto = x.cd_produto " +
                                                                    "and x.placa = '" + pPlaca.Trim() + "')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_convenio",
                                            vOperador = "=",
                                            vVL_Busca = pId_Convenio
                                        }
                                    }, "a.ds_msgvale");
                    Ds_msgVale_Clifor = obj == null ? string.Empty : obj.ToString();
                }
                else
                {
                    object obj = new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "a.cd_clifor = '" + pCd_clifor.Trim() + 
                                                        "' or exists(select 1 from TB_PDC_Convenio_X_Placa x " +
                                                                    "where a.id_convenio = x.id_convenio " +
                                                                    "and a.cd_empresa = x.cd_empresa " +
                                                                    "and a.cd_clifor = x.cd_clifor " +
                                                                    "and a.cd_endereco = x.cd_endereco " +
                                                                    "and a.cd_produto = x.cd_produto " +
                                                                    "and x.placa = '" + pPlaca.Trim() + "')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.ds_msgvale, '')",
                                            vOperador = "<>",
                                            vVL_Busca = "''"
                                        }
                                    }, "a.ds_msgvale");
                    Ds_msgVale_Clifor = obj == null ? string.Empty : obj.ToString();
                }
                if (string.IsNullOrEmpty(Ds_msgVale_Clifor))
                    Texto.Add(rCfgPosto.Ds_msgvale.Trim().ToUpper());
                else
                    Texto.Add(Ds_msgVale_Clifor);
                Texto.Add(string.Empty);
                Texto.Add(string.Empty);
                Texto.Add("PONTOS RESGATAR: " + lPontos.Sum(p => p.SD_Pontos).ToString());
                ImprimirVale(Texto);
                //Marcar vale como impresso
                try
                {
                    rVale.St_impresso = "S";
                    CamadaNegocio.Faturamento.Fidelizacao.TCN_ValeResgate.Gravar(rVale, null);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch { }
        }

        private void TFEmiteValePontosFid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
