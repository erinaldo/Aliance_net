using System;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using Utils;

namespace Empreendimento
{
    public partial class FFatOrcamento : Form
    {
        private TRegistro_FatOrcamento cFatOrc = new TRegistro_FatOrcamento();
        public TRegistro_FatOrcamento rFatOrc
        {
            get
            {
                return bsFatOrca.Current as TRegistro_FatOrcamento;
            }
            set
            {
                cFatOrc = value;
            }

        }
        private TList_CadCFGEmpreendimento cfg { get; set; } = new TList_CadCFGEmpreendimento();
        private TRegistro_Orcamento cOrc = new TRegistro_Orcamento();
        public TRegistro_Orcamento rOrc
        {
            get
            {
                return bsOrcamento.Current as TRegistro_Orcamento;
            }
            set
            {
                cOrc = value;
            }
        }
        private TRegistro_FichaTec clFicha = new TRegistro_FichaTec();
        public TRegistro_FichaTec rlFicha
        {
            get
            {
                return bsFichaTec.Current as TRegistro_FichaTec;
            }
            set
            {
                clFicha = value;
            }
        }
        public string vCd_Empresa { get; set; } = string.Empty;
        public string vCd_tbpreco { get; set; } = string.Empty;

        public FFatOrcamento()
        {
            InitializeComponent();
        }

        private void FFatOrcamento_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            
            if (cOrc != null)
            {
                bsOrcamento.Add(cOrc);
            }

            if (cFatOrc != null)
            {
                bsFatOrca.Add(cFatOrc);
            }
            else
            {
                bsFatOrca.AddNew();
            }

            dt_emissao.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            cfg = CamadaNegocio.Empreendimento.Cadastro.TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);

            bsCFGPed.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedidoFiscal.Buscar(cfg[0].cfg_servico, string.Empty, string.Empty, decimal.Zero, decimal.Zero, 1, string.Empty, null);
            bsCFGPed.ResetCurrentItem();
            
            if(clFicha != null)
            {
                bsFichaTec.Add(clFicha);
            }
        }
        private void click()
        {

            using (FServico serv = new FServico())
            {
                serv.vSaldo_faturar = (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento ;
                serv.vValorOrc = (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento;
                serv.vSaldo_faturado = (bsOrcamento.Current as TRegistro_Orcamento).total_faturado;
                serv.vCd_cidade = (bsOrcamento.Current as TRegistro_Orcamento).Cd_cidadeemp;
                serv.rFicha = (bsFichaTec.Current as TRegistro_FichaTec);
                serv.rOrc = (bsOrcamento.Current as TRegistro_Orcamento); 
                if (serv.ShowDialog() == DialogResult.OK)
                {
                    (bsFatOrca.Current as TRegistro_FatOrcamento).valor_notafiscal = serv.vValor_Nota;
                    (bsFatOrca.Current as TRegistro_FatOrcamento).Cd_municipioexec = serv.vCd_cidade;
                    (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario = serv.vValor_Nota;
                    (bsFichaTec.Current as TRegistro_FichaTec).Vl_Executado = serv.vVl_Execucao;
                    (bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal = serv.vValor_Nota;
                    (bsFichaTec.Current as TRegistro_FichaTec).Quantidade = 1;
                    bsFichaTec_PositionChanged(this, new EventArgs());
                    tsImpostos.Visible = false;
                }
                bsFichaTec.ResetCurrentItem();
            }


        }
        private void dataGridDefault1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            click();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string mensagem = string.Empty;

            if (MessageBox.Show("Deseja confirmar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if ((bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal <= decimal.Zero)
                {
                    mensagem = "Existe item sem valor!";
                    flag = false;
                }
                if (flag)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FFatOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                toolStripButton1_Click(this, new EventArgs());

            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {

            string cdprod = string.Empty;
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;


            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = string.Empty;
            filtro[1].vVL_Busca = "(e.tp_produto = (select top 1 x.tp_produto from tb_est_tpproduto x where x.st_servico = 'S') )";
            Componentes.EditDefault cd_produto = new Componentes.EditDefault();
            cd_produto.NM_CampoBusca = "a.cd_produto";

            rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                         vCd_Empresa,
                                                         string.Empty,
                                                         vCd_tbpreco,
                                                         new Componentes.EditDefault[] { cd_produto },
                                                         filtro);
            if (MessageBox.Show("O produto selecionado irá sobreescrever os demais. Deseja prosseguir?", "Mensagem",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (rProd != null)
                {
                    TRegistro_FichaTec item = new TRegistro_FichaTec();
                    item.Cd_produto = rProd.CD_Produto;
                    item.Quantidade = 1;
                    item.Ds_produto = rProd.DS_Produto;
                    if(bsFichaTec.Current != null)
                    bsFichaTec.RemoveCurrent();
                    bsFichaTec.Add(item);
                }
            }
        }

        private void bbcorrigirficha_Click(object sender, EventArgs e)
        {
            click();
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bsFichaTec.RemoveCurrent();
            }
        }

        private void bbAddImposto_Click(object sender, EventArgs e)
        {

            if ((bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario != decimal.Zero)
                using (Fiscal.TFLan_Impostos fImp = new Fiscal.TFLan_Impostos())
                {
                    if (fImp.ShowDialog() == DialogResult.OK)
                        if (fImp.rImp != null)
                        {
                            if ((bsFichaTec.Current as TRegistro_FichaTec).lImpostos.Exists(p => p.Cd_imposto.Equals(fImp.rImp.Cd_imposto)))
                                (bsFichaTec.Current as TRegistro_FichaTec).lImpostos.RemoveAll(p => p.Cd_imposto.Equals(fImp.rImp.Cd_imposto));
                            (bsFichaTec.Current as TRegistro_FichaTec).lImpostos.Add(fImp.rImp);
                            bsFichaTec.ResetCurrentItem();
                        }
                }
        }


        private void bbEditImposto_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
            {
                    using (Fiscal.TFLan_Impostos fImp = new Fiscal.TFLan_Impostos())
                    {
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF copia = (CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF)(bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Clone();
                        copia.Imposto = (CamadaDados.Fiscal.TRegistro_CadImposto)(bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Imposto.Clone();
                        fImp.rImp = bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF;
                        if (fImp.ShowDialog() != DialogResult.OK)
                        {
                            int position = bsImpostos.Position;
                            bsImpostos.RemoveCurrent();
                            (bsFichaTec.Current as TRegistro_FichaTec).lImpostos.Insert(position, copia);
                            bsFichaTec.ResetCurrentItem();
                        }
                    } 
            }
        }

        private void bbExcluirImposto_Click(object sender, EventArgs e)
        {
            if (bsImpostos.Current != null)
                if (MessageBox.Show("Confirma exclusão do imposto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsImpostos.RemoveCurrent();
        }

        private void bsFichaTec_PositionChanged(object sender, EventArgs e)
        {

            if (bsImpostos.Count <= 0)
            {
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor clifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor, null);

                object cd_cidade = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_endereco",
                            vOperador = "=",
                            vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco
                        }
                    }, "a.cd_cidade");

                object uf_clifor = new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                    new TpBusca[]{
                new TpBusca()
                {
                    vNM_Campo = "a.cd_cidade",
                    vOperador = "=",
                    vVL_Busca = cd_cidade.ToString()
                }
                    }, "a.cd_uf");

                object uf_empresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa
                    }
                    }, "c.cd_uf");

                CamadaDados.Estoque.Cadastros.TRegistro_CadProduto prod = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo((bsFichaTec.Current as TRegistro_FichaTec).Cd_produto, null);
                string vObsFiscal = string.Empty;

                (bsFichaTec.Current as TRegistro_FichaTec).lImpostos = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                           uf_empresa.ToString(),
                                                                                           uf_clifor.ToString(),
                                                                                           (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Cd_movtostring,
                                                                                           (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Tp_movimento,
                                                                                           clifor.Cd_condfiscal_clifor,
                                                                                           prod.CD_CondFiscal_Produto,
                                                                                           decimal.Zero,
                                                                                           (bsFichaTec.Current as TRegistro_FichaTec).Quantidade,
                                                                                           ref vObsFiscal,
                                                                                           dt_emissao.Data,
                                                                                           (bsFichaTec.Current as TRegistro_FichaTec).Cd_produto,
                                                                                           "P",
                                                                                           (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Nr_serie,
                                                                                           null);

                (bsFichaTec.Current as TRegistro_FichaTec).lImpostos.Concat(
                   CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(clifor.Cd_condfiscal_clifor,
                                                                         prod.CD_CondFiscal_Produto,
                                                                         (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Cd_movtostring,
                                                                         (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Tp_movimento,
                                                                         clifor.Tp_pessoa,
                                                                         (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                         (bsCFGPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedidoFiscal).Cfg_pedido,
                                                                         clifor.Cd_clifor,
                                                                         prod.CD_Unidade,
                                                                         dt_emissao.Data,
                                                                         (bsFichaTec.Current as TRegistro_FichaTec).Quantidade,
                                                                         decimal.Zero,
                                                                         "P",
                                                                         (bsOrcamento.Current as TRegistro_Orcamento).Cd_cidadeemp,
                                                                         null));


            }
            (bsFichaTec.Current as TRegistro_FichaTec).lImpostos.ForEach(p =>
            {
                p.Vl_basecalc = (bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal;
                CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.CalcValorImposto(p, p.Vl_basecalc , false);

            });
            bsFichaTec.ResetCurrentItem();
        }
    }
}
