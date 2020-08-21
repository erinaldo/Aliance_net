using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Mudanca;
using Utils;
using FormBusca;
using CamadaDados.Mudanca.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace Mudanca
{
    public partial class TFMudanca : Form
    {
        public bool St_aprovada
        { get; set; }
        public TRegistro_Orcamento rOrcamento
        { get; set; }
        private TRegistro_LanMudanca rmudanca;
        public TRegistro_LanMudanca rMudanca
        {
            get
            {
                if (bsMudanca.Current != null)
                    return bsMudanca.Current as TRegistro_LanMudanca;
                else
                    return null;
            }
            set { rmudanca = value; }
        }


        private TList_LanItensMud litens;
        public TList_LanItensMud lItens
        {
            set { litens = value; }
        }
        private decimal qtd_parc
        { get; set; }
        private decimal qtd_diasDesdobro
        { get; set; }

        public TFMudanca()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("RESIDENCIAL", "0"));
            cbx.Add(new TDataCombo("COMERCIAL", "1"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("DINHEIRO", "0"));
            cbx1.Add(new TDataCombo("CHEQUE", "1"));
            cbx1.Add(new TDataCombo("CARTÃO CRED/DEB", "2"));
            cbx1.Add(new TDataCombo("DEPOSITO BANCARIO", "3"));
            cbx1.Add(new TDataCombo("DUPLICATA", "4"));
            cbx1.Add(new TDataCombo("BOLETO BANCARIO", "5"));
            tp_pagamento.DataSource = cbx1;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
        }

        private bool Endereco()
        {
            if (string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Numero_Dest) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Dest) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Bairro_Dest) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig) ||
                string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Dest) ||
                ((bsMudanca.Current as TRegistro_LanMudanca).Dt_coletastr.Trim().Equals("/  /") && string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Dt_coletastr.SoNumero())) ||
                ((bsMudanca.Current as TRegistro_LanMudanca).Dt_entregastr.Trim().Equals("/  /") && string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Dt_entregastr.SoNumero())))
                return false;
            else
                return true;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio() && pOrigem.validarCampoObrigatorio() && pDestino.validarCampoObrigatorio())
            {
                //Verificar se Origem e destino foram informados
                if (!Endereco())
                {
                    MessageBox.Show("Obrigatório completar Origem e Destino da Mudança!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcDetalhes.SelectTab(1);
                    return;
                }
                //Verificar se Endereço Origem destino são iguais
                if (!(bsMudanca.Current as TRegistro_LanMudanca).St_utilizaguardamoveisbool &&
                    (bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig.Equals((bsMudanca.Current as TRegistro_LanMudanca).Numero_Dest) &&
                    (bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig.Equals((bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Dest) &&
                    (bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig.Equals((bsMudanca.Current as TRegistro_LanMudanca).Bairro_Dest) &&
                    (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig.Equals((bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Dest))
                {
                    MessageBox.Show("Endereço Origem e Destino são iguais!\r\n" +
                                    "Por favor modifique!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcDetalhes.SelectTab(1);
                    return;
                }
                //Verificar se endereco é igual ao endereco do cliente
                if (new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cep",
                        vOperador = "=",
                        vVL_Busca = "'" + CepOrig.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.numero",
                        vOperador = "=",
                        vVL_Busca = "'" + NumeroOrig.Text.Trim() + "'"
                    }
                    }, "1") == null)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(
                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                            {
                                Cd_clifor = CD_Clifor.Text,
                                Cep = CepOrig.Text,
                                Numero = NumeroOrig.Text,
                                Ds_endereco = LogradouroOrig.Text,
                                Bairro = BairroOrig.Text,
                                Cd_cidade = CD_CidadeOrig.Text,
                                Ds_complemento = ComplementoOrig.Text,
                                Proximo = ProximoOrig.Text
                            }, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    //Verificar se endereco é igual ao endereco do cliente
                if (new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cep",
                        vOperador = "=",
                        vVL_Busca = "'" + cepDest.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.numero",
                        vOperador = "=",
                        vVL_Busca = "'" + numeroDest.Text.Trim() + "'"
                    }
                    }, "1") == null)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(
                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                            {
                                Cd_clifor = CD_Clifor.Text,
                                Cep = cepDest.Text,
                                Numero = numeroDest.Text,
                                Ds_endereco = logradouroDest.Text,
                                Bairro = bairroDest.Text,
                                Cd_cidade = cd_cidadeDest.Text,
                                Ds_complemento = complementoDest.Text,
                                Proximo = proximoDest.Text
                            }, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (cbAprovada.Checked)
                    St_aprovada = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void AjustarDadosFin()
        {
            if (bsMudanca.Current != null)
            {
                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).CD_CondPGTO))
                {
                    int parcela = 1;
                    (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMudDel =
                         (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud;
                    (bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca = (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Sum(p => p.Vl_servico);
                    (bsMudanca.Current as TRegistro_LanMudanca).QTD_parcelas = qtd_parc;
                    (bsMudanca.Current as TRegistro_LanMudanca).QTD_diasdesdobro = qtd_diasDesdobro;
                    (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud = CamadaNegocio.Mudanca.TCN_LanMudanca.Calcula_Parcelas(bsMudanca.Current as TRegistro_LanMudanca);
                    (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud.ForEach(p => p.Cd_parcela = parcela++);
                    bsMudanca.ResetCurrentItem();

                    //Habilitar Campos
                    dt_venctoParc.Enabled = bsParcelas.Count > 0;
                    VL_Parcela.Enabled = bsParcelas.Count > 0;
                }
                else
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud.Clear();
                    bsMudanca.ResetCurrentItem();
                }
            }
        }

        private void Habilita_Data_Financeiro()
        {
            if (bsParcelas.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).ST_SolicitarDTVencto.Trim().ToUpper().Equals("S"))
                    dt_venctoParc.Enabled = true;
                else
                    dt_venctoParc.Enabled = false;

            }
        }

        private CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco Busca_Endereco_Clifor(string pCd_clifor)
        {
            if (!string.IsNullOrEmpty(pCd_clifor))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);
                return List_Endereco.Count > 0 ? List_Endereco[0] : null;
            }
            else return null;
        }

        private void InserirItensMud()
        {
            using (TFItensMud fItensMud = new TFItensMud())
            {
                fItensMud.plItensMud = bsItens.List as TList_LanItensMud;
                if (fItensMud.ShowDialog() == DialogResult.OK)
                {
                    if (fItensMud.lItensDel.Count > 0)
                    {
                        fItensMud.lItensDel.ForEach(p =>
                            {
                                (bsMudanca.Current as TRegistro_LanMudanca).lItensMudDel.Add(p);
                                (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.RemoveAll(v => v.Id_item.Equals(p.Id_item));
                            });
                        bsMudanca.ResetBindings(true);
                    }
                    if (fItensMud.lItens.Count > 0)
                    {
                        fItensMud.lItens.ForEach(p =>
                            {
                                (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Add(
                                    new TRegistro_LanItensMud()
                                    {
                                        Id_item = p.Id_item,
                                        Ds_item = p.Ds_item,
                                        Quantidade = p.Quantidade,
                                        Vl_seguro = p.Vl_seguro,
                                        MetragemCub = p.MetragemCub
                                    });
                            });
                        bsMudanca.ResetCurrentItem();
                        tot_mtcubico.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        tot_vlseguro.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    }
                }
            }
        }

        private void AlterarItensMud()
        {
            if (bsItens.Current != null)
            {
                using (TFItensValores fValor = new TFItensValores())
                {
                    fValor.Quantidade = (bsItens.Current as TRegistro_LanItensMud).Quantidade;
                    fValor.Vl_seguro = (bsItens.Current as TRegistro_LanItensMud).Vl_seguro;
                    if (fValor.ShowDialog() == DialogResult.OK)
                        if (fValor.Quantidade > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_LanItensMud).Quantidade = fValor.Quantidade;
                            (bsItens.Current as TRegistro_LanItensMud).Vl_seguro = fValor.Vl_seguro;
                        }
                }

                bsItens.ResetCurrentItem();
                tot_mtcubico.Text = (bsItens.List as List<TRegistro_LanItensMud>).Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_vlseguro.Text = (bsItens.List as List<TRegistro_LanItensMud>).Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void ExcluirItensMud()
        {
            if (bsItens.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lItensMudDel.Add(bsItens.Current as TRegistro_LanItensMud);
                    bsItens.RemoveCurrent();
                    tot_mtcubico.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_vlseguro.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
        }

        private void InserirServicosMud()
        {
            using (TFServicosMud fServico = new TFServicosMud())
            {
                if (fServico.ShowDialog() == DialogResult.OK)
                    if (fServico.lServico.Count > decimal.Zero)
                        fServico.lServico.ForEach(p =>
                            {
                                (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Add(
                                    new TRegistro_LanServicosMud()
                                    {
                                        Id_servico = p.Id_servico,
                                        Ds_servico = p.Ds_servico,
                                        Vl_servico = p.Vl_servico
                                    });
                                bsMudanca.ResetCurrentItem();
                            });
                vl_mudanca.Text = (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Sum(p => p.Vl_servico).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void ExcluirServicosMud()
        {
            if (bsServicos.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lServicosMudDel.Add(bsServicos.Current as TRegistro_LanServicosMud);
                    bsServicos.RemoveCurrent();
                }
            vl_mudanca.Text = (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Sum(p => p.Vl_servico).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void InserirMaterialMud()
        {
            using (TFMaterialMud fMaterial = new TFMaterialMud())
            {
                fMaterial.Cd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                if (fMaterial.ShowDialog() == DialogResult.OK)
                    if (fMaterial.rMaterialMud != null)
                    {
                        (bsMudanca.Current as TRegistro_LanMudanca).lMaterialMud.Add(fMaterial.rMaterialMud);
                        bsMudanca.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirMaterialMud()
        {
            if (bsMaterialMud.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lMaterialMudDel.Add(bsMaterialMud.Current as TRegistro_MaterialMud);
                    bsMaterialMud.RemoveCurrent();
                }
        }

        private void InserirAjudanteMud()
        {
            Componentes.EditDefault cd_ajudante = new Componentes.EditDefault();
            Componentes.EditDefault nm_ajudante = new Componentes.EditDefault();
            cd_ajudante.NM_Campo = "cd_clifor";
            cd_ajudante.NM_CampoBusca = "cd_clifor";
            nm_ajudante.NM_Campo = "nm_clifor";
            nm_ajudante.NM_CampoBusca = "nm_clifor";
            string vColunas = "a.nm_clifor|Item|200;" +
                             "a.cd_clifor|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ajudante, nm_ajudante },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "ST_Funcionarios|=|'S'");
            if (!string.IsNullOrEmpty(cd_ajudante.Text))
            {
                if (!(bsMudanca.Current as TRegistro_LanMudanca).lAjudantesMud.Exists(p=> p.Cd_ajudante.Equals(cd_ajudante.Text)))
                    (bsMudanca.Current as TRegistro_LanMudanca).lAjudantesMud.Add(new TRegistro_AjudantesMud()
                    {
                        Cd_ajudante = cd_ajudante.Text,
                        Nm_ajudante = nm_ajudante.Text
                    });
                bsMudanca.ResetCurrentItem();
            }
        }

        private void ExcluirAjudanteMud()
        {
            if (bsAjudante.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lAjudantesMudDel.Add(bsAjudante.Current as TRegistro_AjudantesMud);
                    bsAjudante.RemoveCurrent();
                }
        }

        private void TFMudanca_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            tabControl1.TabPages.Remove(tpParcelas);
            pDados.set_FormatZero();
            if (rOrcamento == null)
                bb_buscarItens.Visible = false;
            if (rmudanca != null)
            {
                bsMudanca.DataSource = new TList_LanMudanca() { rmudanca };
                tot_mtcubico.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_vlseguro.Text = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                vl_mudanca.Text = (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Sum(p => p.Vl_servico).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
            }
            else
            {
                bsMudanca.AddNew();


                if (rOrcamento != null)
                {
                    //Mostrar Item Web
                    cDs_itemweb.Visible = true;
                    BB_Reprovar.Visible = true;
                    //Preencher Mudança
                    (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa = rOrcamento.Cd_empresa;
                    (bsMudanca.Current as TRegistro_LanMudanca).Nm_empresa = rOrcamento.Nm_empresa;
                    (bsMudanca.Current as TRegistro_LanMudanca).St_utilizaguardamoveisbool = rOrcamento.St_guardamoveisbool;
                    (bsMudanca.Current as TRegistro_LanMudanca).NR_DiasGuardaMoveis = rOrcamento.Nr_diasguardamoveis;
                    //Buscar CD.Cidade Origem
                    object cd_cidadeOrig = new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "b.UF",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rOrcamento.Uf_origem.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.ds_cidade",
                                        vOperador = "like",
                                        vVL_Busca = "'%" + rOrcamento.Cidade_origem.Trim() + "%'"
                                    }
                                }, "a.cd_cidade");
                    if (cd_cidadeOrig != null)
                        (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig = cd_cidadeOrig.ToString();
                    (bsMudanca.Current as TRegistro_LanMudanca).CEP_Orig = rOrcamento.Cep_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Orig = rOrcamento.Cidade_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).UfOrig = rOrcamento.Uf_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig = rOrcamento.Endereco_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig = rOrcamento.Numero_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig = rOrcamento.Bairro_origem;
                    (bsMudanca.Current as TRegistro_LanMudanca).Complemento_Orig = rOrcamento.Complemento_origem;
                    //Buscar CD.Cidade Destino
                    object cd_cidadeDest = new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "b.UF",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rOrcamento.Uf_destino.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.ds_cidade",
                                        vOperador = "like",
                                        vVL_Busca = "'%" + rOrcamento.Cidade_destino.Trim() + "%'"
                                    }
                                }, "a.cd_cidade");
                    if (cd_cidadeDest != null)
                        (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Dest = cd_cidadeDest.ToString();
                    (bsMudanca.Current as TRegistro_LanMudanca).CEP_Dest = rOrcamento.Cep_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Dest = rOrcamento.Cidade_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).UfDest = rOrcamento.Uf_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Dest = rOrcamento.Endereco_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).Numero_Dest = rOrcamento.Numero_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).Bairro_Dest = rOrcamento.Bairro_destino;
                    (bsMudanca.Current as TRegistro_LanMudanca).Complemento_Dest = rOrcamento.Complemento_destino;

                    (bsMudanca.Current as TRegistro_LanMudanca).Dt_coleta = rOrcamento.Dt_coleta;
                    (bsMudanca.Current as TRegistro_LanMudanca).St_elevadorcoletabool = rOrcamento.Elevador_coletabool;
                    (bsMudanca.Current as TRegistro_LanMudanca).St_escadacoletabool = rOrcamento.Escada_coletabool;
                    (bsMudanca.Current as TRegistro_LanMudanca).Dt_entrega = rOrcamento.Dt_entrega;
                    (bsMudanca.Current as TRegistro_LanMudanca).St_elevadorentregabool = rOrcamento.Elevador_entregabool;
                    (bsMudanca.Current as TRegistro_LanMudanca).St_escadaentregabool = rOrcamento.Escada_entregabool;
                    (bsMudanca.Current as TRegistro_LanMudanca).Ds_observacao =
                        rOrcamento.Obsseguro + "\r\n" + rOrcamento.Obsencaixotamento;
                    //Buscar Cliente
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor =
                           new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                 new TpBusca[]
                                 {
                                     new TpBusca()
                                     {
                                         vNM_Campo = string.Empty,
                                         vOperador = string.Empty,
                                         vVL_Busca = "a.cd_clifor = '" + rOrcamento.cd_clifor.Trim() + "' or " +
                                                     (!string.IsNullOrEmpty(rOrcamento.NR_CPF) ? "a.nr_cpf" : "a.nr_cgc") + 
                                                     "='" + (!string.IsNullOrEmpty(rOrcamento.NR_CPF) ? rOrcamento.NR_CPF.Trim() : rOrcamento.NR_CNPJ.Trim()) + "'"
                                     }
                                 }, 1, string.Empty);
                    if (lClifor.Count > 0)
                    {
                        CD_Clifor.Text = lClifor[0].Cd_clifor;
                        NM_Clifor.Text = lClifor[0].Nm_clifor;
                        //Buscar Endereco
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(lClifor[0].Cd_clifor);
                        if (rEnd != null)
                        {
                            CD_Endereco.Text = rEnd.Cd_endereco.Trim();
                            DS_Endereco.Text = rEnd.Ds_endereco.Trim();
                            DS_Cidade.Text = rEnd.DS_Cidade.Trim();
                            UF.Text = rEnd.UF.Trim();
                        }
                    }
                    else
                    {
                        using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                        {
                            if (rOrcamento != null && string.IsNullOrEmpty(CD_Clifor.Text))
                            {
                                fClifor.pTp_pessoa = !string.IsNullOrEmpty(rOrcamento.NR_CNPJ) ? "J" : "F";
                                fClifor.pNm_clifor = rOrcamento.Nm_cliente;
                                fClifor.pNR_CNPJ = rOrcamento.NR_CNPJ;
                                fClifor.pNR_CPF = rOrcamento.NR_CPF;
                                fClifor.pFone_comercial = rOrcamento.Fone_comercial;
                                fClifor.pFone_residencial = rOrcamento.Fone_residencial;
                                fClifor.pCelular = rOrcamento.Celular;
                                fClifor.pEmail = rOrcamento.Email;
                                //Pergunta
                                DialogResult dialog = InputBox("Pergunta", "Deseja cadastrar qual endereço do Orçamento do Cliente?");
                                fClifor.pDs_endereco = dialog.Equals(DialogResult.OK) ? rOrcamento.Endereco_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Endereco_destino : string.Empty;
                                fClifor.pNumero = dialog.Equals(DialogResult.OK) ? rOrcamento.Numero_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Numero_destino : string.Empty;
                                fClifor.pBairro = dialog.Equals(DialogResult.OK) ? rOrcamento.Bairro_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Bairro_destino : string.Empty;
                                fClifor.pCd_cidade = dialog.Equals(DialogResult.OK) ? (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig :
                                    dialog.Equals(DialogResult.Yes) ? (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Dest : string.Empty;
                                fClifor.pCidade = dialog.Equals(DialogResult.OK) ? rOrcamento.Cidade_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Cidade_destino : string.Empty;
                                fClifor.pUF = dialog.Equals(DialogResult.OK) ? rOrcamento.Uf_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Uf_destino : string.Empty;
                                fClifor.pCep = dialog.Equals(DialogResult.OK) ? rOrcamento.Cep_origem :
                                    dialog.Equals(DialogResult.Yes) ? rOrcamento.Cep_destino : string.Empty;

                            }
                            if (fClifor.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                    MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                    NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                                    CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                                    DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                                    CD_Clifor.Focus();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    //Preencher Itens
                    rOrcamento.lItens.ForEach(p =>
                        {
                            TRegistro_LanItensMud rItens = new TRegistro_LanItensMud();
                            //Verificar se existe Item amarrado ao itemWeb
                            TList_CadItens lItens =
                                new TCD_CadItens().Select(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_itemweb",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_itemWeb.Trim() + "'"
                                    }
                                }, 1, string.Empty);
                            if (lItens.Count > 0)
                            {
                                rItens.Id_item = lItens[0].Id_item;
                                rItens.Ds_item = lItens[0].Ds_item;
                            }
                            rItens.Cd_itemweb = p.Cd_itemWeb;
                            rItens.Id_itemstr = p.Cd_itemWeb;
                            rItens.Ds_itemweb = p.Ds_itemWeb;
                            rItens.Id_item = p.Id_item;
                            rItens.Ds_item = p.Ds_item;
                            rItens.Quantidade = p.Quantidade;
                            rItens.MetragemCub = p.TotalMTCubico / p.Quantidade;
                            rItens.Vl_seguro = p.Vl_TotSeguro / p.Quantidade;
                            (bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Add(rItens);
                        });


                    //Preencher servico
                    rOrcamento.lSer.ForEach(p =>
                    {
                        TRegistro_LanServicosMud rItens = new TRegistro_LanServicosMud();

                        rItens.Cd_empresa = p.Cd_empresa;
                        rItens.Ds_servico = p.Ds_servico;
                        rItens.Id_servico = p.Id_servico;
                        rItens.Vl_servico = p.Vl_servico;
                        (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.Add(rItens);
                    });

                    bsMudanca.ResetCurrentItem();
                }
                else
                {
                    if (litens != null)
                        if (litens.Count > 0)
                            (bsMudanca.Current as TRegistro_LanMudanca).lItensMud = litens;
                    //Buscar Empresa padrao do usuario
                    object obj = new CamadaDados.Diversos.TCD_CadUsuario_Empresa().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.login",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Parametros.pubLogin.Trim() + "'"
                                        }
                                    }, "a.cd_empresa");
                    if (obj != null)
                    {
                        cd_empresa.Text = obj.ToString();
                        cd_empresa_Leave(this, new EventArgs());
                    }


                }
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar vendedor Padrao
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.loginvendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Parametros.pubLogin.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                                                    "where a.CD_Clifor = x.CD_Vendedor " +
                                                    "and x.CD_Empresa = '" + cd_empresa.Text.Trim() + "')"
                                    }
                                }, "a.cd_clifor");
                if (obj != null)
                    cd_vendedor.Text = obj.ToString();                
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar vendedor Padrao
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.loginvendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Parametros.pubLogin.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                                                    "where a.CD_Clifor = x.CD_Vendedor " +
                                                    "and x.CD_Empresa = '" + cd_empresa.Text.Trim() + "')"
                                    }
                                }, "a.cd_clifor");
                if (obj != null)
                    cd_vendedor.Text = obj.ToString();
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(CD_Clifor.Text);
            if (rEnd != null)
            {
                CD_Endereco.Text = rEnd.Cd_endereco.Trim();
                DS_Endereco.Text = rEnd.Ds_endereco.Trim();
                DS_Cidade.Text = rEnd.DS_Cidade.Trim();
                UF.Text = rEnd.UF.Trim();
                if (MessageBox.Show("Deseja usar o endereço do cliente como Origem da Mudança?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).CEP_Orig = rEnd.Cep.Trim().SoNumero();
                    (bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig = rEnd.Ds_endereco.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig = rEnd.Numero.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig = rEnd.Bairro.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Complemento_Orig = rEnd.Ds_complemento.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Proximo_Orig = rEnd.Proximo.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig = rEnd.Cd_cidade.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Orig = rEnd.DS_Cidade.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).UfOrig = rEnd.UF.Trim();
                }
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(CD_Clifor.Text);
            if (rEnd != null)
            {
                CD_Endereco.Text = rEnd.Cd_endereco.Trim();
                DS_Endereco.Text = rEnd.Ds_endereco.Trim();
                DS_Cidade.Text = rEnd.DS_Cidade.Trim();
                UF.Text = rEnd.UF.Trim();
                if (MessageBox.Show("Deseja usar o endereço do cliente como Origem da Mudança?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).CEP_Orig = rEnd.Cep.Trim().SoNumero();
                    (bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig = rEnd.Ds_endereco.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig = rEnd.Numero.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig = rEnd.Bairro.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Complemento_Orig = rEnd.Ds_complemento.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).Proximo_Orig = rEnd.Proximo.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig = rEnd.Cd_cidade.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Orig = rEnd.DS_Cidade.Trim();
                    (bsMudanca.Current as TRegistro_LanMudanca).UfOrig = rEnd.UF.Trim();
                }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                   new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80;" +
                                  "a.ds_cidade|Cidade|200;" +
                                  "a.UF|UF|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                 new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                             "a.id_veiculo|Id. Veiculo|80;" +
                             "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                           "isnull(a.st_motorista, 'N')|=|'S';" +
                           "isnull(a.ST_AtivoMot, 'N')|=|'S'";
          DataRow linha =  UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

          if (linha != null && string.IsNullOrEmpty(id_veiculo.Text))
          {
              id_veiculo.Text = linha["ID_Veiculo"].ToString();
              id_veiculo_Leave(this, new EventArgs());
              tp_registro.Focus();
          }
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                           "isnull(a.ST_AtivoMot, 'N')|=|'S'";
          DataRowView linha =  UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, nm_motorista }, vParam);

          if (linha != null && string.IsNullOrEmpty(id_veiculo.Text))
          {
              id_veiculo.Text = linha["ID_Veiculo"].ToString();
              id_veiculo_Leave(this, new EventArgs());
              tp_registro.Focus();
          }
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CondPgto|=|'" + cd_condpgto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{cd_condpgto, ds_condpagto},
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());

            if (linha != null)
            {
                qtd_diasDesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                qtd_parc = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                (bsMudanca.Current as TRegistro_LanMudanca).ST_SolicitarDTVencto = linha["ST_SolicitarDTVencto"].ToString();
            }
            AjustarDadosFin();
            bsParcelas_PositionChanged(this, new EventArgs());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                             "a.CD_CondPgto|Cód. CondPgto|100;" +
                             "d.CD_Juro|Cód. Juro|100;" +
                             "d.DS_Juro|Descrição Juro|350";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpagto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
            cd_condpgto_Leave(this, e);
        }

        private void CD_CidadeOrig_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_CidadeOrig.Text + "'",
                    new Componentes.EditDefault[] { CD_CidadeOrig, ds_cidadeOrig, ufOrig }, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void BB_CidadeOrig_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_CidadeOrig, ds_cidadeOrig, ufOrig }, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_cidadeDest_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + cd_cidadeDest.Text + "'",
                   new Componentes.EditDefault[] { cd_cidadeDest, ds_cidadeDest, ufDest }, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidadeDest_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { cd_cidadeDest, ds_cidadeDest, ufDest }, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFMudanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            if (e.KeyCode.Equals(Keys.F5))
                DialogResult = DialogResult.No;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (tabControl1.SelectedTab.Equals(tpItens) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItensMud();
            else if (tabControl1.SelectedTab.Equals(tpItens) && e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItensMud();
            else if (tabControl1.SelectedTab.Equals(tpItens) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItensMud();
            else if (tabControl1.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirServicosMud();
            else if (tabControl1.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirServicosMud();
            else if (tabControl1.SelectedTab.Equals(tpMaterial) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirMaterialMud();
            else if (tabControl1.SelectedTab.Equals(tpMaterial) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirMaterialMud();
            else if (tabControl1.SelectedTab.Equals(tpAjudantes) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirAjudanteMud();
            else if (tabControl1.SelectedTab.Equals(tpAjudantes) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirAjudanteMud();
        }

        private void CepOrig_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CepOrig.Text.SoNumero()))
                && (bsMudanca.Current != null))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(CepOrig.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            LogradouroOrig.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            CD_CidadeOrig.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            BairroOrig.Text = valida.bairro;
                        CD_CidadeOrig_Leave(this, new EventArgs());
                        NumeroOrig.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void cepDest_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cepDest.Text.SoNumero()))
                && (bsMudanca.Current != null))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(cepDest.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            logradouroDest.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            cd_cidadeDest.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            bairroDest.Text = valida.bairro;
                        cd_cidadeDest_Leave(this, new EventArgs());
                        numeroDest.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void bb_inserirItens_Click(object sender, EventArgs e)
        {
            InserirItensMud();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarItensMud();
        }

        private void bb_excluirItens_Click(object sender, EventArgs e)
        {
            ExcluirItensMud();
        }

        private void bb_inserirServicosMud_Click(object sender, EventArgs e)
        {
            InserirServicosMud();
        }

        private void bb_excluirServicosMud_Click(object sender, EventArgs e)
        {
            ExcluirServicosMud();
        }

        private void bb_inserirMarerialMud_Click(object sender, EventArgs e)
        {
            InserirMaterialMud();
        }

        private void bb_excluirMaterialMud_Click(object sender, EventArgs e)
        {
            ExcluirMaterialMud();
        }

        private void bb_inserirAjudanteMud_Click(object sender, EventArgs e)
        {
            InserirAjudanteMud();
        }

        private void bb_excluirAjudanteMud_Click(object sender, EventArgs e)
        {
            ExcluirAjudanteMud();
        }

        private void bb_cadClifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (rOrcamento != null && string.IsNullOrEmpty(CD_Clifor.Text))
                {
                    fClifor.pTp_pessoa = !string.IsNullOrEmpty(rOrcamento.NR_CNPJ) ? "J" : "F";
                    fClifor.pNm_clifor = rOrcamento.Nm_cliente;
                    fClifor.pNR_CNPJ = rOrcamento.NR_CNPJ;
                    fClifor.pNR_CPF = rOrcamento.NR_CPF;
                    fClifor.pFone_comercial = rOrcamento.Fone_comercial;
                    fClifor.pFone_residencial = rOrcamento.Fone_residencial;
                    fClifor.pCelular = rOrcamento.Celular;
                    fClifor.pEmail = rOrcamento.Email;
                    //Pergunta
                    DialogResult dialog = InputBox("Pergunta", "Deseja cadastrar qual endereço do Orçamento do Cliente?");
                    fClifor.pDs_endereco = dialog.Equals(DialogResult.OK) ? rOrcamento.Endereco_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Endereco_destino : string.Empty;
                    fClifor.pNumero = dialog.Equals(DialogResult.OK) ? rOrcamento.Numero_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Numero_destino : string.Empty;
                    fClifor.pBairro = dialog.Equals(DialogResult.OK) ? rOrcamento.Bairro_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Bairro_destino : string.Empty;
                    fClifor.pCd_cidade = dialog.Equals(DialogResult.OK) ? (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Orig :
                        dialog.Equals(DialogResult.Yes) ? (bsMudanca.Current as TRegistro_LanMudanca).CD_Cidade_Dest : string.Empty;
                    fClifor.pCidade = dialog.Equals(DialogResult.OK) ? rOrcamento.Cidade_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Cidade_destino : string.Empty;
                    fClifor.pUF = dialog.Equals(DialogResult.OK) ? rOrcamento.Uf_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Uf_destino : string.Empty;
                    fClifor.pCep = dialog.Equals(DialogResult.OK) ? rOrcamento.Cep_origem : 
                        dialog.Equals(DialogResult.Yes) ? rOrcamento.Cep_destino : string.Empty;
                       
                }
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        CD_Clifor.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dt_venctoParc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dt_venctoParc_Leave(this, new EventArgs());
        }

        private void dt_venctoParc_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                TimeSpan ts =
                    (Convert.ToDateTime(dt_venctoParc.Text).Subtract(Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"))));
                (bsParcelas.Current as TRegistro_ParcelasMud).DiaVencto = ts.Days;
                CamadaNegocio.Mudanca.TCN_LanMudanca.RecalcDiaVencto(bsParcelas.List as TList_ParcelasMud,
                                                                           qtd_diasDesdobro,
                                                                           bsParcelas.Position);

                bsParcelas.ResetBindings(true);
                VL_Parcela.Focus();
            }
        }

        private void VL_Parcela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                VL_Parcela_Leave(this, new EventArgs());
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.Current as TRegistro_ParcelasMud).Vl_parcela = VL_Parcela.Value;
                CamadaNegocio.Mudanca.TCN_LanMudanca.RecalculaParc(bsParcelas.List as TList_ParcelasMud,
                                                                                (bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca,
                                                                                bsParcelas.Position);
                bsParcelas.ResetBindings(true);
            }
        }

        private void QTD_DiasDesdobro_Leave(object sender, EventArgs e)
        {
            AjustarDadosFin();
        }

        private void bsParcelas_PositionChanged(object sender, EventArgs e)
        {
            Habilita_Data_Financeiro();
            VL_Parcela.Enabled = bsParcelas.Position != (bsParcelas.Count - 1);
        }

        private void NumeroOrig_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LogradouroOrig.Text))
                LogradouroOrig.Focus();
            else
                ComplementoOrig.Focus();
        }

        private void numeroDest_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(logradouroDest.Text))
                logradouroDest.Focus();
            else
                complementoDest.Focus();
        }

        private void bb_buscarItens_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                Componentes.EditDefault id_item = new Componentes.EditDefault();
                id_item.NM_Campo = "id_item";
                id_item.NM_CampoBusca = "id_item";
                string vColunas = "a.id_item|ID.Item|20;" +
                                  "a.ds_item|Item|100";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas,
                       new Componentes.EditDefault[] { id_item }, new TCD_CadItens(), "a.st_sintetico|<>|'S'");

                 if (linha != null)
                 {
                     (bsItens.Current as TRegistro_LanItensMud).Id_itemstr = id_item.Text;
                     (bsItens.Current as TRegistro_LanItensMud).Ds_item = linha["ds_item"].ToString();
                     TRegistro_CadItens rItens = new TRegistro_CadItens();
                     rItens.Id_itemstr = id_item.Text;
                     rItens.Ds_item = linha["ds_item"].ToString();
                     rItens.Id_itempaistr = linha["ID_ItemPai"].ToString();
                     rItens.MetragemCub = Convert.ToDecimal(linha["MetragemCub"].ToString());
                     rItens.St_sintetico = linha["ST_Sintetico"].ToString();
                     rItens.Classificacao = linha["classificacao"].ToString();
                     rItens.Cd_itemweb = (bsItens.Current as TRegistro_LanItensMud).Cd_itemweb;
                     CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Gravar(rItens, null);
                     bsItens.ResetCurrentItem();
                 }
            }
        }

        private void ST_UtilizaGuardaMoveis_CheckedChanged(object sender, EventArgs e)
        {
            NR_DiasGuardaMoveis.Enabled = ST_UtilizaGuardaMoveis.Checked;
        }

        private void bb_remetente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_remetente, nm_remetente }, string.Empty);
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(cd_remetente.Text);
            if (rEnd != null)
            {
                cd_endremetente.Text = rEnd.Cd_endereco.Trim();
                ds_endremente.Text = rEnd.Ds_endereco.Trim();
                ds_cidaderemetente.Text = rEnd.DS_Cidade.Trim();
                uf_remetente.Text = rEnd.UF.Trim();
            }
        }

        private void cd_remetente_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_remetente, nm_remetente }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(cd_remetente.Text);
            if (rEnd != null)
            {
                cd_endremetente.Text = rEnd.Cd_endereco.Trim();
                ds_endremente.Text = rEnd.Ds_endereco.Trim();
                ds_cidaderemetente.Text = rEnd.DS_Cidade.Trim();
                uf_remetente.Text = rEnd.UF.Trim();
            }
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario, nm_destinatario }, string.Empty);
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(cd_destinatario.Text);
            if (rEnd != null)
            {
                cd_enddestinatario.Text = rEnd.Cd_endereco.Trim();
                ds_enddestinatario.Text = rEnd.Ds_endereco.Trim();
                ds_cidadedestinatario.Text = rEnd.DS_Cidade.Trim();
                uf_destinatario.Text = rEnd.UF.Trim();
            }
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_destinatario, nm_destinatario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = Busca_Endereco_Clifor(cd_destinatario.Text);
            if (rEnd != null)
            {
                cd_enddestinatario.Text = rEnd.Cd_endereco.Trim();
                ds_enddestinatario.Text = rEnd.Ds_endereco.Trim();
                ds_cidadedestinatario.Text = rEnd.DS_Cidade.Trim();
                uf_destinatario.Text = rEnd.UF.Trim();
            }
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcDetalhes.SelectedTab.Equals(tpOrigDest))
                if (string.IsNullOrEmpty(dt_coleta.Text.SoNumero()))
                    dt_coleta.Text = dt_viagem.Text;
        }

        private void bbAddEndColeta_Click(object sender, EventArgs e)
        {
            if (pOrigem.validarCampoObrigatorio())
                //Verificar se endereco é igual ao endereco do cliente
                if(new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cep",
                            vOperador = "=",
                            vVL_Busca = "'" + CepOrig.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.numero",
                            vOperador = "=",
                            vVL_Busca = "'" + NumeroOrig.Text.Trim() + "'"
                        }
                    }, "1") == null)
                    if (MessageBox.Show("Incluir endereço de coleta no cadastro do cliente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(
                                new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                                {
                                    Cd_clifor = CD_Clifor.Text,
                                    Cep = CepOrig.Text,
                                    Numero = NumeroOrig.Text,
                                    Ds_endereco = LogradouroOrig.Text,
                                    Bairro = BairroOrig.Text,
                                    Cd_cidade = CD_CidadeOrig.Text,
                                    Ds_complemento = ComplementoOrig.Text,
                                    Proximo = ProximoOrig.Text
                                }, null);
                            MessageBox.Show("Endereço gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbAddEndEntrega_Click(object sender, EventArgs e)
        {
            if (pDestino.validarCampoObrigatorio())
                //Verificar se endereco é igual ao endereco do cliente
                if (new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cep",
                            vOperador = "=",
                            vVL_Busca = "'" + cepDest.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.numero",
                            vOperador = "=",
                            vVL_Busca = "'" + numeroDest.Text.Trim() + "'"
                        }
                    }, "1") == null)
                    if (MessageBox.Show("Incluir endereço de entrega no cadastro do cliente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(
                                new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                                {
                                    Cd_clifor = CD_Clifor.Text,
                                    Cep = cepDest.Text,
                                    Numero = numeroDest.Text,
                                    Ds_endereco = logradouroDest.Text,
                                    Bairro = bairroDest.Text,
                                    Cd_cidade = cd_cidadeDest.Text,
                                    Ds_complemento = complementoDest.Text,
                                    Proximo = proximoDest.Text
                                }, null);
                            MessageBox.Show("Endereço gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbEndColeta_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80;" +
                                  "a.ds_cidade|Cidade|200;" +
                                  "a.UF|UF|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
            if (linha != null)
            {
                CepOrig.Text = linha["cep"].ToString();
                NumeroOrig.Text = linha["numero"].ToString();
                LogradouroOrig.Text = linha["ds_endereco"].ToString();
                BairroOrig.Text = linha["bairro"].ToString();
                CD_CidadeOrig.Text = linha["cd_cidade"].ToString();
                ds_cidadeOrig.Text = linha["ds_cidade"].ToString();
                ufOrig.Text = linha["uf"].ToString();
                ComplementoOrig.Text = linha["ds_complemento"].ToString();
                ProximoOrig.Text = linha["proximo"].ToString();
            }
        }

        private void bbEndEntrega_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80;" +
                                  "a.ds_cidade|Cidade|200;" +
                                  "a.UF|UF|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
            if (linha != null)
            {
                cepDest.Text = linha["cep"].ToString();
                numeroDest.Text = linha["numero"].ToString();
                logradouroDest.Text = linha["ds_endereco"].ToString();
                bairroDest.Text = linha["bairro"].ToString();
                cd_cidadeDest.Text = linha["cd_cidade"].ToString();
                ds_cidadeDest.Text = linha["ds_cidade"].ToString();
                ufDest.Text = linha["uf"].ToString();
                complementoDest.Text = linha["ds_complemento"].ToString();
                proximoDest.Text = linha["proximo"].ToString();
            }
        }

        private void bbAddRemetente_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_remetente.Text = fClifor.rClifor.Cd_clifor;
                        nm_remetente.Text = fClifor.rClifor.Nm_clifor;
                        cd_endremetente.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endremente.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        ds_cidaderemetente.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        uf_remetente.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAddDestinatario_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_destinatario.Text = fClifor.rClifor.Cd_clifor;
                        nm_destinatario.Text = fClifor.rClifor.Nm_clifor;
                        cd_enddestinatario.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_enddestinatario.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        ds_cidadedestinatario.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        uf_destinatario.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbEndDestinatario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80;" +
                                  "a.ds_cidade|Cidade|200;" +
                                  "a.UF|UF|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, ds_cidadedestinatario, uf_destinatario },
                 new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'");
        }

        private void bbEndRemetente_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80;" +
                                  "a.ds_cidade|Cidade|200;" +
                                  "a.UF|UF|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endremetente, ds_endremente, ds_cidaderemetente, uf_remetente },
                 new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'");
        }

        private void cd_endremetente_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + cd_endremetente.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endremetente, ds_endremente, ds_cidaderemetente , uf_remetente },
                   new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cd_enddestinatario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + cd_enddestinatario.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, ds_cidadedestinatario, uf_destinatario },
                   new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + cd_empresa.Text.Trim() + "')";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                               new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + cd_empresa.Text.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                                 new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void vl_mudanca_TextChanged(object sender, EventArgs e)
        {
            AjustarDadosFin();
        }

        private void dt_embalagem_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_embalagem.Text))
                dt_coleta.Text = dt_embalagem.Text;
        }

        private void dt_coleta_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_coleta.Text))
                dt_embalagem.Text = dt_coleta.Text;
        }

        public static DialogResult InputBox(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            Button bb_origem = new Button();
            Button bb_destino = new Button();
            Button bb_nenhum = new Button();

            form.Text = title;
            label.Text = promptText;

            bb_origem.Text = "ORIGEM";
            bb_destino.Text = "DESTINO";
            bb_nenhum.Text = "NENHUM";
            bb_origem.DialogResult = DialogResult.OK;
            bb_destino.DialogResult = DialogResult.Yes;
            bb_nenhum.DialogResult = DialogResult.Cancel;


            label.SetBounds(9, 20, 372, 13);
            bb_origem.SetBounds(50, 72, 75, 23);
            bb_destino.SetBounds(150, 72, 75, 23);
            bb_nenhum.SetBounds(250, 72, 75, 23);

            label.AutoSize = true;
            bb_origem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bb_destino.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bb_nenhum.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(380, 107);
            form.Controls.AddRange(new Control[] { label, bb_origem, bb_destino, bb_nenhum });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CancelButton = bb_origem;
            form.CancelButton = bb_destino;
            form.CancelButton = bb_nenhum;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void BB_Reprovar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_motorista.Text))
            {
                MessageBox.Show("Obrigatório informar motorista para selecionar viagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(id_veiculo.Text))
            {
                MessageBox.Show("Obrigatório informar veículo para selecionar viagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string vColunas = "a.id_viagem|Id. Viagem|60;" +
                              "a.ds_viagem|Descrição Viagem|150";
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";a.cd_motorista|=|'" + cd_motorista.Text.Trim() + "';isnull(a.st_viagem, 'E')|in|('P', 'E')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem },
                new CamadaDados.Frota.TCD_Viagem(), vParam);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_motorista.Text))
            {
                MessageBox.Show("Obrigatório informar motorista para selecionar viagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(id_veiculo.Text))
            {
                MessageBox.Show("Obrigatório informar veículo para selecionar viagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string vParam = "a.id_viagem|=|" + id_viagem.Text + ";" +
                            "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "a.cd_motorista|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'E')|in|('P', 'E')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem }, new CamadaDados.Frota.TCD_Viagem());
        }
    }
}
