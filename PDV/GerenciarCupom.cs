using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace PDV
{
    public class TDadosCupom
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItens
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_Sessao rSessao
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador> lPortador
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string CpfCgc
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Endereco
        { get; set; }
        public string Mensagem
        { get; set; }
        public bool St_cupomavulso
        { get; set; }
        public bool St_vendacombustivel
        { get; set; }
        public bool St_convenio
        { get; set; }
        public bool St_faturardireto
        { get; set; }
        public string Nr_requisicao
        { get; set; }
        public string Placa
        { get; set; }
        public decimal Km
        { get; set; }
        public decimal Km_maximo
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Cpf_motorista
        { get; set; }
        public bool St_agruparProduto
        { get; set; }
        public string MsgRetorno
        { get; set; }
        public bool St_pedirCliente { get; set; } = true;
        public bool St_abastItens { get; set; } = false;
    }

    public class TGerenciarCupom
    {
        public static void ProcessarCupom(ref TDadosCupom dados)
        {
            if (dados.lItens.Count < 1)
                throw new Exception("Não existe item para processar cupom fiscal.");
            if (!dados.St_convenio)
            {
                if (dados.St_vendacombustivel)
                    using (TFClienteCupom fCliente = new TFClienteCupom())
                    {
                        fCliente.Nm_clifor = dados.Nm_clifor;
                        if ((!string.IsNullOrEmpty(dados.Cd_clifor)) &&
                            string.IsNullOrEmpty(dados.CpfCgc))
                        {
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'"
                                                }
                                            }, "isnull(a.nr_cgc, a.nr_cpf)");
                            if (obj != null)
                                fCliente.Nr_cgccpf = obj.ToString();
                        }
                        else
                            fCliente.Nr_cgccpf = dados.CpfCgc;
                        fCliente.Placa = dados.Placa;
                        fCliente.Nome_motorista = dados.Nm_motorista;
                        fCliente.Height = 270;
                        fCliente.St_avulso = dados.St_cupomavulso;
                        string aux = string.Empty;
                        if (fCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            dados.St_pedirCliente = false;
                            if (dados.Nm_clifor.Trim().ToUpper() != fCliente.Nm_clifor.Trim().ToUpper())
                                dados.Cd_clifor = string.Empty;
                            dados.Nm_clifor = fCliente.Nm_clifor;
                            dados.CpfCgc = fCliente.Nr_cgccpf;
                            dados.Nm_motorista = fCliente.Nome_motorista;
                            dados.Cpf_motorista = fCliente.Cpf_motorista;
                            dados.Nr_requisicao = fCliente.pNr_requisicao;
                            if ((!string.IsNullOrEmpty(fCliente.Placa)) &&
                                (fCliente.Placa.Trim() != "-"))
                                aux = "Placa: " + fCliente.Placa.Trim();
                            if (fCliente.Km > decimal.Zero)
                                aux += "\r\nKM: " + fCliente.Km.ToString("N0", new System.Globalization.CultureInfo("pt-BR"));

                            //Calcular Media
                            if ((!string.IsNullOrEmpty(fCliente.Placa)) &&
                                (fCliente.Placa.Trim() != "-") &&
                                (fCliente.Km > decimal.Zero) &&
                                dados.lItens.Exists(p => new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto)))
                            {
                                //Buscar Ultimo Km da Placa
                                object obj_km = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + fCliente.Placa.Replace("-", "") + "'"
                                                        }
                                                    }, "a.KM_Atual", string.Empty, "a.dt_abastecimento desc", null);
                                if (obj_km != null)
                                {
                                    decimal volume = decimal.Zero;
                                    dados.lItens.ForEach(p =>
                                    {
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto))
                                            volume += p.Quantidade;
                                    });
                                    if (volume > decimal.Zero)
                                        if (fCliente.Km_maximo > decimal.Zero)
                                            aux += "\r\nMedia: " + Math.Round((fCliente.Km_maximo - decimal.Parse(obj_km.ToString()) + fCliente.Km) / volume, 3) + " KM/LT";
                                        else
                                            aux += "\r\nMedia: " + Math.Round(((fCliente.Km - decimal.Parse(obj_km.ToString())) / volume), 3) + " KM/LT";
                                }
                            }
                            if (!string.IsNullOrEmpty(fCliente.Nome_motorista))
                                aux += "\r\nMotorista: " + fCliente.Nome_motorista.Trim();
                            if (!string.IsNullOrEmpty(fCliente.Cpf_motorista))
                                aux += "\r\nCPF: " + fCliente.Cpf_motorista.Trim();
                            dados.Mensagem += (string.IsNullOrEmpty(dados.Mensagem) ? string.Empty : "\r\n") + aux;

                            if (dados.St_cupomavulso && (!string.IsNullOrEmpty(fCliente.Ds_portador)))
                                dados.lPortador.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador() { Ds_portador = fCliente.Ds_portador });
                        }
                        dados.Placa = fCliente.Placa;
                        dados.Km = fCliente.Km;
                    }
                else
                    using (TFClienteCupom fCliente = new TFClienteCupom())
                    {
                        fCliente.Nm_clifor = dados.Nm_clifor;
                        if ((!string.IsNullOrEmpty(dados.Cd_clifor)) &&
                            string.IsNullOrEmpty(dados.CpfCgc))
                        {
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'"
                                                }
                                            }, "isnull(a.nr_cgc, a.nr_cpf)");
                            if (obj != null)
                                fCliente.Nr_cgccpf = obj.ToString();
                        }
                        else
                            fCliente.Nr_cgccpf = dados.CpfCgc;

                        if (dados.St_cupomavulso)
                        {
                            //fCliente.Height = 178;
                            fCliente.St_avulso = true;
                        }
                        string aux = string.Empty;

                        if (fCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor _CadClifor =
                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[] { new TpBusca() { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = dados.Cd_clifor } }, 1, string.Empty)[0];
                            _CadClifor.Email = fCliente.Email;
                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Gravar(_CadClifor);

                            dados.St_pedirCliente = false;
                            if (dados.Nm_clifor.Trim().ToUpper() != fCliente.Nm_clifor.Trim().ToUpper())
                                dados.Cd_clifor = string.Empty;
                            dados.Nm_clifor = fCliente.Nm_clifor;
                            dados.CpfCgc = fCliente.Nr_cgccpf;
                            dados.Nm_motorista = fCliente.Nome_motorista;
                            dados.Cpf_motorista = fCliente.Cpf_motorista;

                            if ((!string.IsNullOrEmpty(fCliente.Placa)) &&
                                fCliente.Placa.Trim() != "-")
                                aux = "Placa: " + fCliente.Placa.Trim();
                            if (fCliente.Km > decimal.Zero)
                                aux += "\r\nKM: " + fCliente.Km.ToString("N0", new System.Globalization.CultureInfo("pt-BR"));

                            //Calcular Media
                            if ((!string.IsNullOrEmpty(fCliente.Placa)) &&
                                (fCliente.Placa.Trim() != "-") &&
                                (fCliente.Km > decimal.Zero) &&
                                dados.lItens.Exists(p => new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto)))
                            {
                                //Buscar Ultimo Km da Placa
                                object obj_km = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + fCliente.Placa.Replace("-", "") + "'"
                                                        }
                                                    }, "a.KM_Atual", string.Empty, "a.dt_abastecimento desc", null);
                                if (obj_km != null)
                                {
                                    decimal volume = decimal.Zero;
                                    dados.lItens.ForEach(p =>
                                    {
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto))
                                            volume += p.Quantidade;
                                    });
                                    if (volume > decimal.Zero)
                                        if (fCliente.Km_maximo > decimal.Zero)
                                            aux += "\r\nMedia: " + Math.Round((fCliente.Km_maximo - decimal.Parse(obj_km.ToString()) + fCliente.Km) / volume, 3) + " KM/LT";
                                        else
                                            aux += "\r\nMedia: " + Math.Round(((fCliente.Km - decimal.Parse(obj_km.ToString())) / volume), 3) + " KM/LT";
                                }
                            }
                            if (!string.IsNullOrEmpty(fCliente.Nome_motorista))
                                aux += "\r\nMotorista: " + fCliente.Nome_motorista.Trim();
                            if (!string.IsNullOrEmpty(fCliente.Cpf_motorista))
                                aux += "\r\nCPF Mot.: " + fCliente.Cpf_motorista.Trim();
                            dados.Mensagem += (string.IsNullOrEmpty(dados.Mensagem) ? string.Empty : "\r\n") + aux;
                            if (dados.St_cupomavulso && (!string.IsNullOrEmpty(fCliente.Ds_portador)))
                                dados.lPortador.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador() { Ds_portador = fCliente.Ds_portador });
                        }
                        dados.Placa = fCliente.Placa;
                        dados.Km = fCliente.Km;
                    }
                if (!string.IsNullOrWhiteSpace(dados.Cd_clifor))
                {
                    //Verificar se cliente possui pontos resgatar
                    object obj_pontos = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'" },
                            new TpBusca { vNM_Campo = "isnull(a.ST_Registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                        }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                    if (obj_pontos != null)
                        dados.Mensagem += (string.IsNullOrWhiteSpace(dados.Mensagem) ? string.Empty : "\r\n\r\n") + "PONTOS RESGATAR: " + obj_pontos.ToString();
                }
            }
        }

        public CamadaDados.Faturamento.PDV.TRegistro_NFCe GerarNFCe(TDadosCupom dados, bool St_exigirCPF, bool St_delivery = false)
        {
            if (St_exigirCPF)
                using (TFClienteCupom fCliente = new TFClienteCupom())
                {
                    fCliente.Cd_clifor = dados.Cd_clifor;
                    fCliente.Nm_clifor = dados.Nm_clifor;
                    fCliente.Nr_cgccpf = dados.CpfCgc;
                    if (fCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dados.Cd_clifor = fCliente.Cd_clifor;
                        dados.Nm_clifor = fCliente.Nm_clifor;
                        dados.CpfCgc = fCliente.Nr_cgccpf;
                    }
                }

            CamadaDados.Faturamento.PDV.TRegistro_NFCe rCupom = null;
            CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaCombustivel = null;
            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lan = null;

            //Buscar configuracao cupom fiscal
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(dados.lItens[0].Cd_empresa, null);
            if (lCfg.Count < 1)
                throw new Exception("Erro gerar NFCe: Não existe configuração emitir cupom fiscal na empresa " + dados.lItens[0].Cd_empresa);
            //Criar objeto cupom fiscal
            rCupom = new CamadaDados.Faturamento.PDV.TRegistro_NFCe();
            rCupom.Dt_emissao = CamadaDados.UtilData.Data_Servidor(null);
            rCupom.Cd_clifor = dados.Cd_clifor;
            rCupom.Nm_clifor = dados.Nm_clifor;
            rCupom.Nr_cgc_cpf = dados.CpfCgc;
            rCupom.Cd_endereco = dados.Cd_endereco;
            rCupom.Cd_empresa = dados.lItens[0].Cd_empresa;
            if (dados.rSessao != null)
            {
                rCupom.Id_pdv = dados.rSessao.Id_pdv;
                rCupom.Id_sessao = dados.rSessao.Id_sessao;
            }
            rCupom.Nr_serie = lCfg[0].Nr_serienfce;
            rCupom.Cd_modelo = lCfg[0].Cd_modelonfce;
            rCupom.Cd_movimentacao = lCfg[0].Cd_movimentacao;
            rCupom.Placa = dados.Placa;
            rCupom.Nr_requisicao = dados.Nr_requisicao;
            object obj_cont = new CamadaDados.Faturamento.PDV.TCD_ContingenciaNFCeOFF(null).BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pdv",
                                            vOperador = "=",
                                            vVL_Busca = rCupom.Id_pdvstr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'F'"
                                        }
                                }, "a.id_contingencia");
            if (obj_cont != null)
                rCupom.Id_contingencia = decimal.Parse(obj_cont.ToString());
            dados.lItens.ForEach(p =>
            {
                if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto))
                {
                    //Verificar se o item nao existe na lista
                    if (dados.St_agruparProduto && rCupom.lItem.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())))
                    {
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Quantidade += p.Quantidade;
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_desconto += p.Vl_desconto;
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_acrescimo += p.Vl_acrescimo;
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_subtotal += p.Vl_subtotal;
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_unitario =
                            Math.Round(decimal.Divide(rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_subtotal, rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Quantidade), 5, MidpointRounding.AwayFromZero);
                        rCupom.lItem.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).lItemVR.Add(p);
                    }
                    else
                    {
                        //Procurar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (!CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rCupom.Cd_movimentacaostr,
                                                                            p.Cd_condfiscal_produto,
                                                                            "D",
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            ref rCfop,
                                                                            null))
                            throw new Exception("Não existe CFOP cadastrado para a movimentação " + rCupom.Cd_movimentacaostr.Trim() + "\r\n" +
                                                "Condição fiscal produto " + p.Cd_condfiscal_produto.Trim());
                        //Buscar Imposto Aproximado
                        object obj_imp = new CamadaDados.Fiscal.TCD_CadNCM().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.ncm",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + p.Ncm.Trim() + "'"
                                                    }
                                            }, "isnull(a.Pc_Aliquota, 0)");
                        //Buscar % Aliquota Simples Nacional
                        object obj_sn = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                    }
                                            }, "isnull(i.pc_aliquota, 0)");
                        rCupom.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Cd_unidade = p.Cd_unidade,
                            Ds_unidade = p.Ds_unidade,
                            Sigla_unidade = p.Sigla_unidade,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Cd_cfop = rCfop.CD_CFOP,
                            Ds_cfop = rCfop.DS_CFOP,
                            Pc_imposto_Aprox = obj_imp == null ? decimal.Zero : decimal.Parse(obj_imp.ToString()),
                            Pc_aliquotasimples = obj_sn == null ? decimal.Zero : decimal.Parse(obj_sn.ToString()),
                            Quantidade = p.Quantidade,
                            Vl_desconto = p.Vl_desconto,
                            Vl_acrescimo = p.Vl_acrescimo,
                            Vl_subtotal = p.Vl_subtotal,
                            Vl_unitario = p.Vl_unitario,
                            lAbastItens = p.lAbastItens
                        });
                        if (!dados.St_abastItens)
                            rCupom.lItem[rCupom.lItem.Count - 1].lItemVR.Add(p);
                    }
                    if (!dados.St_convenio)
                    {
                        //Verificar se item teve origem em uma abastecida
                        if (p.Cd_empresa != null && p.Id_vendarapida.HasValue && p.Id_lanctovenda.HasValue)
                            lVendaCombustivel = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_cupom",
                                                        vOperador = "=",
                                                        vVL_Busca = p.Id_vendarapida.Value.ToString()
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = p.Id_lanctovenda.Value.ToString()
                                                    }
                                                }, 0, string.Empty, string.Empty);
                    }
                }
            });
            if (rCupom.lItem.Count.Equals(0))
                throw new Exception("Itens da Venda não podem gerar NFC-e!");
            if (string.IsNullOrEmpty(rCupom.Cd_empresa))
                rCupom.Cd_empresa = lCfg[0].Cd_empresa;
            //Buscar estado da empresa
            object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                }
                        }, "c.cd_uf");
            //Verificar condicao fiscal cupom
            rCupom.lItem.ForEach(p =>
            {
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rCupom.Cd_empresa,
                                                                                                      obj != null ? obj.ToString() : string.Empty,
                                                                                                      obj != null ? obj.ToString() : string.Empty,
                                                                                                      rCupom.Cd_movimentacaostr,
                                                                                                      "S",
                                                                                                      lCfg[0].Cd_condfiscal_clifor,
                                                                                                      p.Cd_condfiscal_produto,
                                                                                                      p.Vl_subtotalliquido,
                                                                                                      p.Quantidade,
                                                                                                      ref vObsFiscal,
                                                                                                      rCupom.Dt_emissao,
                                                                                                      p.Cd_produto,
                                                                                                      "P",
                                                                                                      rCupom.Nr_serie,
                                                                                                      null);
                if (lImp.Count > 0)
                {
                    p.Cd_icms = lImp.First().Cd_imposto;
                    p.Cd_st_icms = lImp.First().Cd_st;
                    p.Pc_aliquotaICMS = lImp.First().Pc_aliquota;
                    p.Vl_icms = lImp.First().Vl_impostocalc;
                    p.Vl_basecalcICMS = lImp.First().Vl_basecalc;
                    p.St_gerarCredito = lImp.First().St_gerarcreditobool;
                    p.Tp_situacao = lImp.First().Tp_situacao;
                    p.Tp_modbasecalc = lImp.First().Tp_modbasecalc;
                    p.Tp_modbasecalcST = lImp.First().Tp_modbasecalcST;
                }
                else
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                "Tipo Movimento: SAIDA" + "\r\n" +
                                                "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                                "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "UF Origem: " + (obj != null ? obj.ToString() : string.Empty) + "\r\n" +
                                                "UF Destino: " + (obj != null ? obj.ToString() : string.Empty));
                //Procurar impostos sobre os itens da nota fiscal de destino
                lImp = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lCfg[0].Cd_condfiscal_clifor,
                                                                                                                  p.Cd_condfiscal_produto,
                                                                                                                  rCupom.Cd_movimentacaostr,
                                                                                                                  "S",
                                                                                                                  lCfg[0].Tp_pessoa,
                                                                                                                  rCupom.Cd_empresa,
                                                                                                                  rCupom.Nr_serie,
                                                                                                                  string.Empty,
                                                                                                                  string.Empty,
                                                                                                                  rCupom.Dt_emissao,
                                                                                                                  decimal.Zero,
                                                                                                                  p.Vl_subtotalliquido,
                                                                                                                  "P",
                                                                                                                  string.Empty,
                                                                                                                  null);
                if (lImp.Count > 0)
                {
                    //Procurar PIS
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPIS = lImp.Find(x => x.Imposto.St_PIS);
                    if (rPIS == null)
                        throw new Exception("Erro: Não existe condição fiscal do PIS.\r\n" +
                                            "Tipo Movimento: SAIDA" + "\r\n" +
                                            "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                            "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Tipo Pessoa: " + (lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F") ? "FISICA" : "JURIDICA"));
                    else
                    {
                        p.Cd_pis = rPIS.Cd_imposto;
                        p.Cd_st_pis = rPIS.Cd_st;
                        p.Id_tpcontribuicaoPIS = rPIS.Id_tpcontribuicao;
                        p.Id_detrecisentaPIS = rPIS.Id_detrecisenta;
                        p.Id_receitaPIS = rPIS.Id_receita;
                        p.Pc_aliquotaPIS = rPIS.Pc_aliquota;
                        p.Vl_pis = rPIS.Vl_impostocalc;
                        p.Vl_basecalcPIS = rPIS.Vl_basecalc;
                        p.St_gerarCredito = rPIS.St_gerarcreditobool;
                    }
                    //Procurar COFINS
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCofins = lImp.Find(x => x.Imposto.St_Cofins);
                    if (rPIS == null)
                        throw new Exception("Erro: Não existe condição fiscal do COFINS.\r\n" +
                                            "Tipo Movimento: SAIDA" + "\r\n" +
                                            "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                            "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Tipo Pessoa: " + (lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F") ? "FISICA" : "JURIDICA"));
                    else
                    {
                        p.Cd_cofins = rCofins.Cd_imposto;
                        p.Cd_st_cofins = rCofins.Cd_st;
                        p.Id_tpcontribuicaoCOFINS = rCofins.Id_tpcontribuicao;
                        p.Id_detrecisentaCofins = rCofins.Id_detrecisenta;
                        p.Id_receitaCofins = rCofins.Id_receita;
                        p.Pc_aliquotaCofins = rCofins.Pc_aliquota;
                        p.Vl_cofins = rCofins.Vl_impostocalc;
                        p.Vl_basecalcCofins = rCofins.Vl_basecalc;
                        p.St_gerarCredito = rCofins.St_gerarcreditobool;
                    }
                }
            });
            //Buscar duplicata venda origem
            if (!string.IsNullOrEmpty(dados.lItens[0].Cd_empresa.Trim()) && !string.IsNullOrEmpty(dados.lItens[0].Id_vendarapida.Value.ToString()))
            {
                lan = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.cd_empresa = '" + dados.lItens[0].Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = "  + dados.lItens[0].Id_vendarapida.Value.ToString() + ")"
                            }
                        }, 0, string.Empty);

            }
            //Criar transacao banco dados
            BancoDados.TObjetoBanco banco = new BancoDados.TObjetoBanco();
            banco.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
            banco.CriarComando();
            banco.Conexao.Open();
            banco.Start_Tran(System.Data.IsolationLevel.ReadCommitted);
            banco.Comando.Transaction = banco.Transac;
            try
            {
                if (lVendaCombustivel != null)
                    lVendaCombustivel.ForEach(v =>
                    {
                        v.Placaveiculo = dados.Placa;
                        v.Km_atual = dados.Km;
                        v.Nm_motorista = dados.Nm_motorista;
                        v.Cpf_motorista = dados.Cpf_motorista;
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(v, banco);
                    });
                //Incrementar Nº NFCe
                new CamadaDados.Faturamento.PDV.TCD_NFCe(banco).incSeqNFCe(rCupom);
                //Gravar cupom no banco de dados
                if (St_delivery)
                {
                    if (rCupom.lPagto.Count.Equals(0))
                    {
                        rCupom.lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                        {
                            Tp_portador = "01",
                            Vl_recebido = rCupom.lItem.Sum(p => p.Vl_subtotal)
                        });
                    }
                    CamadaNegocio.Faturamento.PDV.TCN_NFCe.GerarCupomDelivery(rCupom, banco);
                }
                else CamadaNegocio.Faturamento.PDV.TCN_NFCe.GerarCupomVendaRapida(rCupom, banco);
                if (lan != null)
                    lan.ForEach(p =>
                    {
                        p.Nr_docto = "NFCe" + rCupom.NR_NFCestr.Trim();
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.AlterarDuplicata(p, banco);
                    });
                banco.Commit_Tran();
                return rCupom;
            }
            catch (Exception ex)
            {
                banco.RollBack_Tran();
                throw new Exception("Erro gerar NFCe: " + ex.Message.Trim());
            }
            finally
            {
                if (banco.Conexao.State == System.Data.ConnectionState.Open)
                    banco.Conexao.Close();
                banco = null;
            }
        }

        public CamadaDados.Faturamento.PDV.TRegistro_NFCe GerarNFCe(CamadaDados.Servicos.TRegistro_LanServico rOs)
        {
            if (string.IsNullOrEmpty(rOs.Nr_cnpj_cpf.SoNumero()))
                using (TFClienteCupom fCliente = new TFClienteCupom())
                {
                    fCliente.Height = 155;
                    fCliente.Nm_clifor = rOs.Nm_clifor;
                    if (fCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        rOs.Nr_cnpj_cpf = fCliente.Nr_cgccpf;
                }
            //Buscar configuracao cupom fiscal
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rOs.Cd_empresa, null);
            if (lCfg.Count < 1)
                throw new Exception("Não existe configuração emitir cupom fiscal na empresa " + rOs.Cd_empresa);
            //Criar objeto cupom fiscal
            CamadaDados.Faturamento.PDV.TRegistro_NFCe rCupom = new CamadaDados.Faturamento.PDV.TRegistro_NFCe();
            rCupom.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rCupom.Cd_clifor = rOs.Cd_clifor;
            rCupom.Nm_clifor = rOs.Nm_clifor;
            rCupom.Nr_cgc_cpf = rOs.Nr_cnpj_cpf;
            rCupom.Cd_endereco = rOs.Cd_endereco;
            rCupom.Cd_empresa = rOs.Cd_empresa;
            rCupom.Nr_serie = lCfg[0].Nr_serienfce;
            rCupom.Cd_modelo = lCfg[0].Cd_modelonfce;
            rCupom.Cd_movimentacao = lCfg[0].Cd_movimentacao;
            rCupom.Placa = rOs.Placaveiculo;
            object obj_cont = new CamadaDados.Faturamento.PDV.TCD_ContingenciaNFCeOFF().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pdv",
                                            vOperador = "=",
                                            vVL_Busca = rCupom.Id_pdvstr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'F'"
                                        }
                                }, "a.id_contingencia");
            if (obj_cont != null)
                rCupom.Id_contingencia = decimal.Parse(obj_cont.ToString());
            rOs.lPecas.ForEach(p =>
            {
                if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto))
                {
                    //Procurar cfop do item
                    CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                    if (!CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rCupom.Cd_movimentacaostr,
                                                                        p.Cd_condfiscal_produto,
                                                                        "D",
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        ref rCfop,
                                                                        null))
                        throw new Exception("Não existe CFOP cadastrado para a movimentação " + rCupom.Cd_movimentacaostr.Trim() + "\r\n" +
                                            "Condição fiscal produto " + p.Cd_condfiscal_produto.Trim());
                    //Buscar Imposto Aproximado
                    object obj_imp = new CamadaDados.Fiscal.TCD_CadNCM().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.ncm",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Ncm.Trim() + "'"
                                                }
                                        }, "isnull(a.Pc_Aliquota, 0)");
                    //Buscar % Aliquota Simples Nacional
                    object obj_sn = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                }
                                        }, "isnull(i.pc_aliquota, 0)");
                    rCupom.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_produto = p.Cd_produto,
                        Ds_produto = p.Ds_produto,
                        Cd_unidade = p.Cd_unidproduto,
                        Ds_unidade = p.Ds_unidproduto,
                        Sigla_unidade = p.Sigla_unidproduto,
                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                        Cd_cfop = rCfop.CD_CFOP,
                        Ds_cfop = rCfop.DS_CFOP,
                        Pc_imposto_Aprox = obj_imp == null ? decimal.Zero : decimal.Parse(obj_imp.ToString()),
                        Pc_aliquotasimples = obj_sn == null ? decimal.Zero : decimal.Parse(obj_sn.ToString()),
                        Quantidade = p.Quantidade,
                        Vl_desconto = p.Vl_desconto,
                        Vl_acrescimo = p.Vl_acrescimo,
                        Vl_subtotal = p.Vl_subtotal,
                        Vl_unitario = p.Vl_unitario
                    });
                    rCupom.lItem[rCupom.lItem.Count - 1].lPecasOS.Add(p);
                }
            });
            if (rCupom.lItem.Count.Equals(0))
                throw new Exception("Ordem Serviço não possui peças para gerar NFC-e!");
            //Buscar estado da empresa
            object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                            {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                    }
                            }, "c.cd_uf");
            //Verificar condicao fiscal cupom
            rCupom.lItem.ForEach(p =>
            {
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rCupom.Cd_empresa,
                                                                                                      obj != null ? obj.ToString() : string.Empty,
                                                                                                      obj != null ? obj.ToString() : string.Empty,
                                                                                                      rCupom.Cd_movimentacaostr,
                                                                                                      "S",
                                                                                                      lCfg[0].Cd_condfiscal_clifor,
                                                                                                      p.Cd_condfiscal_produto,
                                                                                                      p.Vl_subtotalliquido,
                                                                                                      p.Quantidade,
                                                                                                      ref vObsFiscal,
                                                                                                      rCupom.Dt_emissao,
                                                                                                      p.Cd_produto,
                                                                                                      "P",
                                                                                                      rCupom.Nr_serie,
                                                                                                      null);
                if (lImp.Count > 0)
                {
                    p.Cd_icms = lImp.First().Cd_imposto;
                    p.Cd_st_icms = lImp.First().Cd_st;
                    p.Pc_aliquotaICMS = lImp.First().Pc_aliquota;
                    p.Vl_icms = lImp.First().Vl_impostocalc;
                    p.Vl_basecalcICMS = lImp.First().Vl_basecalc;
                    p.St_gerarCredito = lImp.First().St_gerarcreditobool;
                    p.Tp_situacao = lImp.First().Tp_situacao;
                    p.Tp_modbasecalc = lImp.First().Tp_modbasecalc;
                    p.Tp_modbasecalcST = lImp.First().Tp_modbasecalcST;
                }
                else
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                "Tipo Movimento: SAIDA" + "\r\n" +
                                                "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                                "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "UF Origem: " + (obj != null ? obj.ToString() : string.Empty) + "\r\n" +
                                                "UF Destino: " + (obj != null ? obj.ToString() : string.Empty));
                //Procurar impostos sobre os itens da nota fiscal de destino
                lImp = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lCfg[0].Cd_condfiscal_clifor,
                                                                                                                  p.Cd_condfiscal_produto,
                                                                                                                  rCupom.Cd_movimentacaostr,
                                                                                                                  "S",
                                                                                                                  lCfg[0].Tp_pessoa,
                                                                                                                  rCupom.Cd_empresa,
                                                                                                                  rCupom.Nr_serie,
                                                                                                                  string.Empty,
                                                                                                                  string.Empty,
                                                                                                                  rCupom.Dt_emissao,
                                                                                                                  decimal.Zero,
                                                                                                                  p.Vl_subtotalliquido,
                                                                                                                  "P",
                                                                                                                  string.Empty,
                                                                                                                  null);
                if (lImp.Count > 0)
                {
                    //Procurar PIS
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPIS = lImp.Find(x => x.Imposto.St_PIS);
                    if (rPIS == null)
                        throw new Exception("Erro: Não existe condição fiscal do PIS.\r\n" +
                                            "Tipo Movimento: SAIDA" + "\r\n" +
                                            "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                            "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Tipo Pessoa: " + (lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F") ? "FISICA" : "JURIDICA"));
                    else
                    {
                        p.Cd_pis = rPIS.Cd_imposto;
                        p.Cd_st_pis = rPIS.Cd_st;
                        p.Id_tpcontribuicaoPIS = rPIS.Id_tpcontribuicao;
                        p.Id_detrecisentaPIS = rPIS.Id_detrecisenta;
                        p.Id_receitaPIS = rPIS.Id_receita;
                        p.Pc_aliquotaPIS = rPIS.Pc_aliquota;
                        p.Vl_pis = rPIS.Vl_impostocalc;
                        p.Vl_basecalcPIS = rPIS.Vl_basecalc;
                        p.St_gerarCredito = rPIS.St_gerarcreditobool;
                        p.Tp_situacao = rPIS.Tp_situacao;
                    }
                    //Procurar COFINS
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCofins = lImp.Find(x => x.Imposto.St_Cofins);
                    if (rPIS == null)
                        throw new Exception("Erro: Não existe condição fiscal do COFINS.\r\n" +
                                            "Tipo Movimento: SAIDA" + "\r\n" +
                                            "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                            "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + p.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Tipo Pessoa: " + (lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F") ? "FISICA" : "JURIDICA"));
                    else
                    {
                        p.Cd_cofins = rCofins.Cd_imposto;
                        p.Cd_st_cofins = rCofins.Cd_st;
                        p.Id_tpcontribuicaoCOFINS = rCofins.Id_tpcontribuicao;
                        p.Id_detrecisentaCofins = rCofins.Id_detrecisenta;
                        p.Id_receitaCofins = rCofins.Id_receita;
                        p.Pc_aliquotaCofins = rCofins.Pc_aliquota;
                        p.Vl_cofins = rCofins.Vl_impostocalc;
                        p.Vl_basecalcCofins = rCofins.Vl_basecalc;
                        p.St_gerarCredito = rCofins.St_gerarcreditobool;
                        p.Tp_situacao = rCofins.Tp_situacao;
                    }
                }
            });
            //Criar transacao banco dados
            BancoDados.TObjetoBanco banco = new BancoDados.TObjetoBanco();
            banco.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
            banco.CriarComando();
            banco.Conexao.Open();
            banco.Start_Tran(System.Data.IsolationLevel.ReadCommitted);
            banco.Comando.Transaction = banco.Transac;
            try
            {
                //Incrementar Nº NFCe
                new CamadaDados.Faturamento.PDV.TCD_NFCe(banco).incSeqNFCe(rCupom);
                //Gravar cupom no banco de dados
                CamadaNegocio.Faturamento.PDV.TCN_NFCe.GerarCupomVendaRapida(rCupom, banco);
                //Comitar banco dados
                banco.Commit_Tran();
                return rCupom;
            }
            catch (Exception ex)
            {
                //Rolback banco dados
                banco.RollBack_Tran();
                throw new Exception("Erro gerar NFCe: " + ex.Message.Trim());
            }
            finally
            {
                if (banco.Conexao.State == System.Data.ConnectionState.Open)
                    banco.Conexao.Close();
                banco = null;
            }
        }
    }
}
