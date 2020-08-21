using CamadaDados.Faturamento.PDV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFLanAbastItens : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanAbastItens()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFAbastPatrimonio fAbast = new TFAbastPatrimonio())
            {
                fAbast.ShowDialog();
                afterBusca();
            }
        }

        private void afterBusca()
        {
            bsAbastItens.DataSource = CamadaNegocio.Locacao.TCN_AbastItens.buscar(string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  cd_buscapatrimonio.Text,
                                                                                  cd_buscaproduto.Text,
                                                                                  DT_Inicial.Text,
                                                                                  DT_Final.Text,
                                                                                  null);
        }

        private void GerarNFCe()
        {
            using (TFVendaItensCargaAvulsa fGerar = new TFVendaItensCargaAvulsa())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                        if (fGerar.lItens.Count > 0)
                        {
                            try
                            {
                                //Processar cupom fiscal
                                PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                //Buscar dados PDV
                                object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                }, "a.id_pdv");
                                if (obj == null)
                                {
                                    MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (new TCD_Sessao().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_pdv",
                                                vOperador = "=",
                                                vVL_Busca = obj.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                            }
                                    }, "1") == null)
                                    CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                                        new TRegistro_Sessao()
                                        {
                                            Id_pdvstr = obj.ToString(),
                                            Login = Utils.Parametros.pubLogin
                                        }, null);
                                //Buscar sessao aberta
                                dados.rSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(obj.ToString(),
                                                                                                string.Empty,
                                                                                                Utils.Parametros.pubLogin,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                "'A'",
                                                                                                1,
                                                                                                null)[0];
                                //Buscar Local Arm
                                object LocalArm = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fGerar.Cd_empresa.Trim() + "'"
                                            }
                                                        }, "a.CD_Local");
                                if (LocalArm == null)
                                    throw new Exception("Não existe Local de armazenagem configurado para Empresa" + fGerar.Cd_empresa.Trim() + "!");
                                //Montar Itens Cupom
                                dados.lItens = new List<TRegistro_VendaRapida_Item>();
                                fGerar.lItens.ForEach(p =>
                                    dados.lItens.Add(new TRegistro_VendaRapida_Item
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_local = LocalArm.ToString(),
                                        Cd_produto = p.Cd_produto,
                                        Ds_produto = p.Ds_produto,
                                        Cd_unidade = p.Cd_unidade,
                                        Ds_unidade = p.Ds_unidade,
                                        Sigla_unidade = p.Sigla,
                                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                        Quantidade = p.Quantidade,
                                        Vl_subtotal = p.Vl_subtotal,
                                        Vl_unitario = p.Vl_unitario,
                                        lAbastItens = new CamadaDados.Locacao.TList_AbastItens() { p }
                                    }));
                                dados.Cd_clifor = string.Empty;
                                dados.Nm_clifor = string.Empty;
                                dados.CpfCgc = string.Empty;
                                dados.Endereco = string.Empty;
                                dados.Mensagem = string.Empty;
                                dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                dados.St_vendacombustivel = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = false;
                                dados.St_abastItens = true;

                                TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                if (rNFCe != null)
                                    if (!rNFCe.St_contingencia)
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                              rNFCe.Id_nfcestr,
                                                                                                              null);
                                            fGerNfe.ShowDialog();
                                        }
                                    else
                                    {
                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                        Rel.Altera_Relatorio = Altera_Relatorio;
                                        BindingSource dts = new BindingSource();
                                        dts.DataSource = new TList_NFCe_Item();
                                        Rel.DTS_Relatorio = dts;// bsItens;
                                                                //DTS Cupom
                                        BindingSource bsNFCe = new BindingSource();
                                        bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                          string.Empty,
                                                                                                          rNFCe.Cd_empresa,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          decimal.Zero,
                                                                                                          decimal.Zero,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          1,
                                                                                                          null);
                                        (bsNFCe.Current as TRegistro_NFCe).lItem =
                                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                               (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                               string.Empty,
                                                                                               null);
                                        NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
                                        Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                        //Buscar Empresa
                                        BindingSource bsEmpresa = new BindingSource();
                                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);
                                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                        //Forma Pagamento
                                        BindingSource bsPagto = new BindingSource();
                                        List<TRegistro_MovCaixa> lPagto = new List<TRegistro_MovCaixa>();
                                        new TCD_CaixaPDV().SelectMovCaixa(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                    "and x.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                    }
                                            }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                (aux, venda) =>
                                                                    new
                                                                    {
                                                                        tp_portador = aux,
                                                                        Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                        Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                        Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                    }).ToList().ForEach(x => lPagto.Add(new TRegistro_MovCaixa()
                                                                    {
                                                                        Tp_portador = x.tp_portador,
                                                                        Vl_recebido = x.Vl_recebido,
                                                                        Vl_troco_ch = x.Vl_troco_ch,
                                                                        Vl_troco_dh = x.Vl_troco_dh
                                                                    }));
                                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                        }
                                                }, 1, string.Empty);
                                        if (lDup.Count > 0)
                                            lPagto.Add(new TRegistro_MovCaixa()
                                            {
                                                Tp_portador = "05",
                                                Vl_recebido = lDup[0].Vl_documento
                                            });
                                        bsPagto.DataSource = lPagto;
                                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                        //Parametros
                                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                        obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.id_lote = a.id_lote " +
                                                                        "and x.status = '100')"
                                                        }
                                                }, "a.tp_ambiente");
                                        Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                        string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                              (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                              null);
                                        if (!string.IsNullOrEmpty(dadoscf))
                                        {
                                            string[] linhas = dadoscf.Split(new char[] { ':' });
                                            string placa = string.Empty;
                                            string km = string.Empty;
                                            string frota = string.Empty;
                                            string requisicao = string.Empty;
                                            string nm_motorista = string.Empty;
                                            string cpf_motorista = string.Empty;
                                            string media = string.Empty;
                                            string virg = string.Empty;
                                            foreach (string s in linhas)
                                            {
                                                string[] colunas = s.Split(new char[] { '/' });
                                                placa += virg + colunas[0];
                                                km += virg + colunas[1];
                                                frota += virg + colunas[2];
                                                requisicao += virg + colunas[3];
                                                nm_motorista += virg + colunas[4];
                                                cpf_motorista += virg + colunas[5];
                                                media += virg + colunas[6];
                                                virg = ",";
                                            }
                                            if (!string.IsNullOrEmpty(placa))
                                                Rel.Parametros_Relatorio.Add("PLACA", placa);
                                            if (!string.IsNullOrEmpty(km))
                                                Rel.Parametros_Relatorio.Add("KM", km);
                                            if (!string.IsNullOrEmpty(media))
                                                Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                            if (!string.IsNullOrEmpty(frota))
                                                Rel.Parametros_Relatorio.Add("FROTA", frota);
                                            if (!string.IsNullOrEmpty(requisicao))
                                                Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                            if (!string.IsNullOrEmpty(nm_motorista))
                                                Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                            if (!string.IsNullOrEmpty(cpf_motorista))
                                                Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                        }
                                        Rel.Nome_Relatorio = "DANFE_NFCE";
                                        Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                        Rel.Modulo = "FAT";
                                        Rel.Ident = "DANFE_NFCE";
                                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                        {
                                            BindingSource bsItens = new BindingSource();
                                            bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                            Rel.DTS_Relatorio = bsItens;
                                        }
                                        if (rNFCe.Id_contingencia.HasValue)
                                            if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                            else
                                                Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                        //Verificar se existe Impressora padrão para o PDV
                                        obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                }, "a.impressorapadrao");
                                        string print = obj == null ? string.Empty : obj.ToString();
                                        if (string.IsNullOrEmpty(print))
                                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                            {
                                                if (fLista.ShowDialog() == DialogResult.OK)
                                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                                        print = fLista.Impressora;

                                            }
                                        //Imprimir
                                        if (!string.IsNullOrEmpty(print))
                                        {
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                            if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                                (bsNFCe.Current as TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                Rel.ImprimiGraficoReduzida(print,
                                                                           true,
                                                                           false,
                                                                           null,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           1);
                                        }
                                    }
                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                            MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterExclui()
        {
            if(bsAbastItens.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_AbastItens.Excluir(bsAbastItens.Current as CamadaDados.Locacao.TRegistro_AbastItens, null);
                        MessageBox.Show("Abastecimento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanAbastItens_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bbBuscaPatrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Patrimonio|200;" +
                              "a.cd_produto|Código|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_buscapatrimonio },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), "|exists|(select 1 from tb_est_patrimonio x where x.cd_patrimonio = a.cd_produto)");
        }

        private void cd_buscapatrimonio_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_patrimonio|=|'" + cd_buscapatrimonio.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_buscapatrimonio },
                new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio());
        }

        private void bbBuscaProduto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_buscaproduto }, string.Empty);
        }

        private void cd_buscaproduto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_buscaproduto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_buscaproduto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFLanAbastItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void miNfVenda_Click(object sender, EventArgs e)
        {
            GerarNFCe();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }
    }
}
