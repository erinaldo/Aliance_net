using System;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using Utils;
using CamadaDados.Empreendimento;
using Componentes;
using FormBusca;
using System.Data;

namespace Empreendimento
{
    public partial class TFFichaTec : Form
    {
        public string vId_atividade { get; set; } = string.Empty;
        public string vDs_atividade { get; set; } = string.Empty;
        public string vId_Orc { get; set; } = string.Empty;
        public string vNr_Ver { get; set; } = string.Empty;
        public bool vSt_Proj { get; set; } = false;
        public string pCd_tabelapreco { get; set; } = string.Empty;
        public string pId_registro { get; set; } = string.Empty;
        public bool projetista { get; set; } = false;
        private TRegistro_FichaTec rficha;
        public TRegistro_FichaTec rFicha
        {
            get
            {
                if (bsFichaTec.Current != null)
                    return bsFichaTec.Current as TRegistro_FichaTec;
                else return null;
            }
            set { rficha = value; }
        }
        public string tb_preco { get; set; }
        private bool ficha
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pId_Ficha
        { get; set; }
        public string pNr_Versao
        { get; set; }
        public string pId_Orcamento
        { get; set; }
        public string pId_projeto
        { get; set; }
        public bool lista { get; set; } = false;
        private TRegistro_CadProduto rProd = null;
        public TList_FichaTec lFicha { get; set; } = new TList_FichaTec();


        public TFFichaTec()
        {
            InitializeComponent();
            Height = 190;
        }

        private void afterGrava()
        {
            (bsFichaTec.Current as TRegistro_FichaTec).Quantidade = quantidade.Value;
            (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario = vl_unitario.Value;
            (bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal = quantidade.Value * vl_unitario.Value;

            if (pDados.validarCampoObrigatorio())
            {
                if (panelDados3.Enabled && string.IsNullOrWhiteSpace(editDefault1.Text))
                {
                    MessageBox.Show("Obrigatório informar atividade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editDefault1.Focus();
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFFichaTec_Load(object sender, EventArgs e)
        {
            if (projetista)
                panelDados2.Visible = false;

            pDados.set_FormatZero();


            if (vSt_Proj && rficha == null)
            {
                bsFichaTec.AddNew();
                editDefault1.Text = vId_atividade;
                editDefault2.Text = vDs_atividade;
                editDefault1.Focus();
            }
            else if (rficha == null)
            {
                bsFichaTec.AddNew();
                if (!string.IsNullOrEmpty(CD_PRODUTO.Text))
                    quantidade.Focus();
                else
                    ds_produto.Focus();
                editDefault1.Text = vId_atividade;
                editDefault2.Text = vDs_atividade;
                panelDados3.Enabled = false;
            }
            else
            {
                panelDados3.Enabled = false;
                TList_FichaItens lprod = new TList_FichaItens();
                bsFichaTec.DataSource = new TList_FichaTec() { rficha };
                ds_produto.Text = rficha.Ds_produto;
                vl_unitario.Value = rficha.Vl_unitario;
                if (rficha.lfichaItens.Count > 0)
                {
                    rficha.lfichaItens.ForEach(p =>
                        {
                            TRegistro_FichaItens prod = new TRegistro_FichaItens();
                            prod.Cd_itemstr = p.Cd_itemstr.ToString();
                            prod.quantidade = p.quantidade;
                            prod.vl_unitario = p.vl_unitario;
                            prod.vl_subtotal = p.vl_unitario * p.quantidade;
                            object a = new TCD_CadProduto().BuscarEscalar(new TpBusca[]{
                                                                                    new Utils.TpBusca(){
                                                                                        vNM_Campo = "a.cd_produto",
                                                                                        vOperador = "=",
                                                                                        vVL_Busca = p.Cd_itemstr.ToString()
                                                                                    }}, "a.ds_produto");
                            prod.ds_item = a.ToString();

                            lprod.Add(prod);
                        });
                    bsItens.DataSource = lprod;

                }
                //cd_produto_Leave(this, new EventArgs());
                quantidade.Focus();
                TList_FichaTecProduto lFichaptd = new TList_FichaTecProduto();
                //busca itens produto
                if (!string.IsNullOrEmpty(CD_PRODUTO.Text))
                {
                    lFichaptd = CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(CD_PRODUTO.Text, string.Empty, null);
                    if (lFichaptd.Count > 0 && bsItens.Count <= 0)
                    {
                        bsItens.Clear();
                        lFichaptd.ForEach(p =>
                        {
                            TRegistro_FichaItens pro = new TRegistro_FichaItens();
                            pro.Cd_itemstr = p.Cd_item;
                            pro.ds_item = p.Ds_item;
                            pro.quantidade = p.Quantidade;
                            pro.vl_unitario = p.Vl_custoservico;
                            bsItens.Add(p);
                        });
                        bsItens.ResetCurrentItem();
                    }
                }
            }

            if (bsItens.Count > 0)
            {
                Height = 593;
                ficha = true;
            }
            else
            {
                Height = 190;
                ficha = false;
            }
            calculatotal();
        }

        private void TFFichaTec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void calculatotal()
        {

            decimal total = decimal.Zero;
            if (bsItens.Count > 0)
            {
                total = (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario;
                if ((bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario <= decimal.Zero)
                    (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.ForEach(p =>
                            total += p.vl_unitario * p.quantidade);
                vl_unitario.Value = total;
            }
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void vl_subtotal_ValueChanged(object sender, EventArgs e)
        {
            if (ficha)
                calculatotal();
        }
        private void calcular()
        {
            if (quantidade.Value > decimal.Zero)
                vl_unitario.Value = Math.Round(decimal.Divide(vl_subtotal.Value, quantidade.Value), 5, MidpointRounding.AwayFromZero);
            else if (vl_unitario.Value > decimal.Zero)
                quantidade.Value = Math.Round(decimal.Divide(vl_subtotal.Value, vl_unitario.Value), 3, MidpointRounding.AwayFromZero);
        }

        private void bbCorrigirOrc_Click(object sender, EventArgs e)
        {
            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
            {
                fQtd.Text = "Quantidade";
                fQtd.Vl_default = (bsItens.Current as TRegistro_FichaItens).quantidade;
                if (fQtd.ShowDialog() == DialogResult.OK)
                    if (fQtd.Quantidade > decimal.Zero)
                    {
                        (bsItens.Current as TRegistro_FichaItens).quantidade =
                            fQtd.Quantidade;
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                else
                {
                    (bsItens.Current as TRegistro_FichaItens).quantidade = decimal.Zero;
                }
            }
            calculatotal();
            bsItens.ResetCurrentItem();

        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            using (Faturamento.TFItensFichaTecOrc f = new Faturamento.TFItensFichaTecOrc())
            {
                f.CD_Empresa = pCd_empresa;
                f.CD_TabelaPreco = pCd_tabelapreco;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    bsItens.AddNew();
                    (bsItens.Current as TRegistro_FichaItens).Cd_itemstr = f.rFicha.Cd_item;
                    (bsItens.Current as TRegistro_FichaItens).quantidade = f.rFicha.Quantidade;
                    (bsItens.Current as TRegistro_FichaItens).vl_unitario = f.rFicha.Vl_unitario;
                    (bsItens.Current as TRegistro_FichaItens).ds_item = f.rFicha.Ds_item;
                    calculatotal();
                }
            }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TRegistro_FichaItens ficha = new TRegistro_FichaItens();
                    ficha.Cd_item = Convert.ToDecimal((bsItens.Current as TRegistro_FichaItens).Cd_itemstr);
                    ficha.Id_fichastr = pId_Ficha;
                    ficha.Id_orcamentostr = pId_Orcamento;
                    ficha.Id_projetostr = (bsFichaTec.Current as TRegistro_FichaTec).Id_projetostr;
                    ficha.Id_projeto = (bsFichaTec.Current as TRegistro_FichaTec).Id_projeto;
                    ficha.Nr_versaostr = pNr_Versao;
                    ficha.Cd_empresa = pCd_empresa;
                    ficha.quantidade = (bsItens.Current as TRegistro_FichaItens).quantidade;
                    ficha.vl_unitario = (bsItens.Current as TRegistro_FichaItens).vl_unitario;
                    (bsFichaTec.Current as TRegistro_FichaTec).lfichaItensDel.Add(ficha);
                    bsItens.RemoveCurrent();
                }
                calculatotal();
            }
        }
        private void quantidade_Leave(object sender, EventArgs e)
        {
            if (ficha)
                calculatotal();
            else
                if (vl_unitario.Value > decimal.Zero && quantidade.Value > decimal.Zero)
                vl_subtotal.Value = Math.Round(decimal.Multiply(quantidade.Value, vl_unitario.Value), 2, MidpointRounding.AwayFromZero);
            bsFichaTec.ResetCurrentItem();
        }

        private void afterficha()
        {
            bool valor_composto = false;
            string cdprod = string.Empty;
            if (!string.IsNullOrEmpty(CD_PRODUTO.Text))
            {
                object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(new TpBusca[]
                {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador= "=",
                                vVL_Busca = ""+CD_PRODUTO.Text+""
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_TabelaPreco",
                                vOperador = "=",
                                vVL_Busca = ""+pCd_tabelapreco+""
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = ""+pCd_empresa+""
                            }
                }, "a.vl_precovenda");
                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.ToString()))
                        vl_unitario.Value = Convert.ToDecimal(obj.ToString());
                }
                else if (rProd == null ? false : rProd.St_composto)
                    valor_composto = true;
            }
            if (bsFichaTec.Current != null)
            {
                if (rProd != null)
                {
                    if (rProd.St_composto)
                    {
                        (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Clear();
                        if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens != null)
                            (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens = CamadaNegocio.Empreendimento.TCN_FichaItens.Buscar((bsFichaTec.Current as TRegistro_FichaTec).Cd_empresa,
                                                            (bsFichaTec.Current as TRegistro_FichaTec).Id_orcamentostr, (bsFichaTec.Current as TRegistro_FichaTec).Nr_versaostr,
                                                            (bsFichaTec.Current as TRegistro_FichaTec).Id_projetostr, (bsFichaTec.Current as TRegistro_FichaTec).Id_fichastr,
                                                            string.Empty, null);

                        //busca itens produto
                        TList_FichaTecProduto lFichaptd = CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(CD_PRODUTO.Text, string.Empty, null);
                        if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Count <= 0)
                            if (lFichaptd.Count > 0)
                            {
                                decimal total = decimal.Zero;
                                bsItens.Clear();
                                lFichaptd.ForEach(p =>
                                {
                                    TRegistro_FichaItens ficha = new TRegistro_FichaItens();
                                    ficha.Cd_itemstr = p.Cd_item;
                                    ficha.ds_item = p.Ds_item;
                                    ficha.quantidade = p.Quantidade;
                                    ficha.vl_subtotal = p.Vl_subtotalservico;
                                    ficha.vl_unitario = p.Vl_custoservico;
                                    (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Add(ficha);
                                    total += p.Vl_subtotalservico;
                                });
                                if (valor_composto)
                                    vl_unitario.Value = total;
                                bsItens.ResetCurrentItem();
                            }
                    }
                    (bsFichaTec.Current as TRegistro_FichaTec).Cd_produto = rProd.CD_Produto;
                    (bsFichaTec.Current as TRegistro_FichaTec).Ds_produto = rProd.DS_Produto;
                    (bsFichaTec.Current as TRegistro_FichaTec).Cd_unidade = rProd.CD_Unidade;
                    (bsFichaTec.Current as TRegistro_FichaTec).Ds_unidade = rProd.DS_Unidade;
                    (bsFichaTec.Current as TRegistro_FichaTec).Sg_unidade = rProd.Sigla_unidade;
                    bsFichaTec.ResetCurrentItem();
                    System.Collections.Hashtable hs = new System.Collections.Hashtable();
                    vl_ultimacompra.Value = rProd.Vl_ultimacompra;
                    vl_unitario.Value = vl_unitario.Value > decimal.Zero ? vl_unitario.Value : rProd.Vl_precovenda;
                }
            }
            if (rProd == null ? false : bsItens.Count > 0 || rProd.St_composto)
            {
                Height = 593;
                ficha = true;
            }
            else
            {
                Height = 190;
                ficha = false;
            }
        }

        private void CD_PRODUTO_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_PRODUTO.Text.SoNumero().Trim()))
            {
                TpBusca[] filtro = new TpBusca[2];
                filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[0].vOperador = "<>";
                filtro[0].vVL_Busca = "'C'";
                filtro[1].vNM_Campo = string.Empty;
                filtro[1].vOperador = string.Empty;
                filtro[1].vVL_Busca = "(a.cd_produto like '%" + CD_PRODUTO.Text.Trim() + "') or " +
                                                        "(a.Codigo_Alternativo = '" + (CD_PRODUTO.TextOld != null ? CD_PRODUTO.TextOld.ToString() : ds_produto.Text.Trim()) + "') or " +
                                                        "(exists(select 1 from tb_est_codbarra x " +
                                                        "           where x.cd_produto = a.cd_produto " +
                                                        "           and x.cd_codbarra = '" + CD_PRODUTO.Text.Trim() + "'))";
                System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
                hs.Add("@CD_EMPRESA", pCd_empresa);
                hs.Add("@CD_TABELAPRECO", pCd_tabelapreco);

                TList_CadProduto lProd = new TCD_CadProduto().Select(filtro, 1, string.Empty, string.Empty, string.Empty, hs);
                if (lProd.Count > 0)
                {
                    rProd = lProd[0];
                    CD_PRODUTO.Text = lProd[0].CD_Produto;
                    ds_produto.Text = lProd[0].DS_Produto;
                    afterficha();
                }
                else
                {
                    MessageBox.Show("Produto não encontrado pelo código informado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bbcorrigirficha_Click(object sender, EventArgs e)
        {
            using (Faturamento.TFItensFichaTecOrc f = new Faturamento.TFItensFichaTecOrc())
            {
                f.CD_Empresa = pCd_empresa;
                f.CD_TabelaPreco = pCd_tabelapreco;
                CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem fichaitens = new CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem();
                if (bsItens.Current != null)
                {
                    fichaitens.Cd_item = (bsItens.Current as TRegistro_FichaItens).Cd_itemstr;
                    fichaitens.Quantidade = (bsItens.Current as TRegistro_FichaItens).quantidade;
                    fichaitens.Vl_unitario = (bsItens.Current as TRegistro_FichaItens).vl_unitario;
                    fichaitens.Ds_item = (bsItens.Current as TRegistro_FichaItens).ds_item;
                    f.rFicha = fichaitens;

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        (bsItens.Current as TRegistro_FichaItens).Cd_itemstr = f.rFicha.Cd_item;
                        (bsItens.Current as TRegistro_FichaItens).quantidade = f.rFicha.Quantidade;
                        (bsItens.Current as TRegistro_FichaItens).vl_unitario = f.rFicha.Vl_unitario;
                        (bsItens.Current as TRegistro_FichaItens).ds_item = f.rFicha.Ds_item;
                        (bsItens.Current as TRegistro_FichaItens).vl_subtotal = f.rFicha.Vl_Subtotal;
                        bsItens.ResetCurrentItem();
                        calculatotal();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                               pCd_empresa,
                                               string.Empty,
                                               pCd_tabelapreco,
                                               new EditDefault[] { CD_PRODUTO, ds_produto },
                                               null);

            afterficha();
        }

        private void vl_unitario_ValueChanged(object sender, EventArgs e)
        {
            vl_subtotal.Value = decimal.Multiply(quantidade.Value, vl_unitario.Value);
        }

        private void quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && vl_unitario.Value > 0)
                afterGrava();
        }

        private void vl_unitario_Leave_1(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
            {
                decimal a = vl_unitario.Value;
                if (ficha)
                    calculatotal();
                else if (quantidade.Value > decimal.Zero && (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario >= decimal.Zero)
                    vl_subtotal.Value = Math.Round(decimal.Multiply((bsFichaTec.Current as TRegistro_FichaTec).Quantidade, (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario), 2, MidpointRounding.AwayFromZero);
                (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario = a;
                bsFichaTec.ResetCurrentItem();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "c.ds_atividade|Nome atividade|200;" +
                              "a.id_atividade|Cd. atividade|80";
            string vParam = "a.id_orcamento|=|'" + vId_Orc + "';" +
                            "a.nr_versao|=|'" + vNr_Ver + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { editDefault1, editDefault2 }, new TCD_OrcProjeto(),
                vParam);
            if (linha != null)
                pId_registro = linha["id_registro"].ToString();
        }

        private void CD_PRODUTO_TextChanged(object sender, EventArgs e)
        {
            ds_produto.Enabled = string.IsNullOrWhiteSpace(CD_PRODUTO.Text);
        }

        private void BB_AdcLista_Click(object sender, EventArgs e)
        {
            EditDefault edit = new EditDefault();
            edit.NM_CampoBusca = "CD_Produto";
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
            string vParamFixo = "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCALISTA(vColunas, edit, new TCD_CadProduto(), vParamFixo);
            string s = edit.Text.Replace("(", "");
            s = s.Replace(")", "");
            s = s.Replace("'", "");
            string[] vs = s.Split(',');
            if (vs.Length > 0 && !string.IsNullOrEmpty(s))
            {
                foreach (string v in vs)
                {
                    TpBusca[] tps = new TpBusca[0];
                    Estruturas.CriarParametro(ref tps, "a.cd_produto", v);

                    //Busca do valor unitario
                    object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador= "=",
                                vVL_Busca = v
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_TabelaPreco",
                                vOperador = "=",
                                vVL_Busca = ""+pCd_tabelapreco+""
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = ""+pCd_empresa+""
                            }
                        }, "a.vl_precovenda");
                    decimal value = decimal.Zero ;
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.ToString()))
                            value = Convert.ToDecimal(obj.ToString());
                    }

                    TRegistro_FichaTec tec = new TRegistro_FichaTec()
                    {
                        Id_projetostr = (bsFichaTec.Current as TRegistro_FichaTec).Id_projetostr,
                        Cd_produto = v.SoNumero(),
                        Ds_produto = new TCD_CadProduto().BuscarEscalar(tps, "a.ds_produto").ToString(),
                        Quantidade = 1,
                        Vl_unitario = value,
                        Vl_subtotal = value
                    };

                    lFicha.Add(tec);
                }

                DialogResult = DialogResult.OK;
            }
        }
    }
}
