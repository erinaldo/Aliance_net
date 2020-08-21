using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using CamadaDados.Empreendimento.Cadastro;
using FormBusca;
using CamadaDados.Estoque.Cadastros;

namespace Empreendimento
{
    public partial class FItensRemessa : Form
    {
        public string vCd_Local { get; set; }
        public string vDs_Local { get; set; }
        public string vTp_Fat { get; set; }
        public string vID_Orcamento { get; set; }
        public string vNr_Versao { get; set; }
        public string vCD_Empresa { get; set; }
        public string vId_registro { get; set; }
        public string vSt_fatdireto { get; set; }
        public bool vAfterBusca { get; set; }
        int index = 0;
        public TList_FichaTec lFicha
        {
            get
            {
                if (bsFicha.Current != null)
                    return bsFicha.DataSource as TList_FichaTec;
                else return null;
            }
            set { }
        }

        private TRegistro_Orcamento rorcamento;
        public TRegistro_Orcamento rOrcamento
        {
            get
            {
                if (bsOrcamento.Current != null)
                    return bsOrcamento.Current as TRegistro_Orcamento;
                else return null;
            }
            set { rorcamento = value; }
        }

        private TRegistro_CadFatDireto rfatDir;
        public TRegistro_CadFatDireto rFatDir
        {
            set { rfatDir = value; }
        }

        public FItensRemessa()
        {
            InitializeComponent();
        }

        private void FItensRemessa_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (rorcamento != null)
                bsOrcamento.DataSource = new TList_Orcamento() { rorcamento };
            else
                bsOrcamento.AddNew();

            bsCFGEmpreendimento.DataSource = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);

            if (rfatDir != null)
            {
                bsFicha.DataSource = (rfatDir.lFicha);
            }
            if (bsOrcamento.Count > 0)
                afterBusca();

        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsFicha.Current as TRegistro_FichaTec).st_agregar)
                {
                    (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                    (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                }
                else
                {
                    (bsFicha.Current as TRegistro_FichaTec).st_agregar = true;

                    //todo validar se ficha selecionada não possui produto
                    // para gerar remessa obrigatório ter produto relacionado
                    if (string.IsNullOrEmpty((bsFicha.Current as TRegistro_FichaTec).Cd_produto))
                    {
                        TRegistro_CadProduto rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Nm_empresa,
                                                                               null,
                                                                               null,
                                                                               null);
                        if (rProd != null)
                        {
                            (bsFicha.Current as TRegistro_FichaTec).Cd_produto = rProd.CD_Produto;
                            quantidadeAgregar();
                        }
                        else
                        {
                            using (Estoque.Cadastros.TFProduto p = new Estoque.Cadastros.TFProduto())
                            {
                                TRegistro_CadProduto produto = new TRegistro_CadProduto();
                                p.vDS_produto = (bsFicha.Current as TRegistro_FichaTec).Ds_produto;

                                if (p.ShowDialog() == DialogResult.OK)
                                {
                                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(p.rProd, null);
                                    (bsFicha.Current as TRegistro_FichaTec).Cd_produto = p.rProd.CD_Produto;
                                    if (p.rProd.lPrecoItem.Count > 0)
                                    {
                                        (bsFicha.Current as TRegistro_FichaTec).Vl_unitario = p.rProd.lPrecoItem[0].VL_PrecoVenda;
                                        (bsFicha.Current as TRegistro_FichaTec).Vl_subtotal = p.rProd.lPrecoItem[0].VL_PrecoVenda *
                                            (bsFicha.Current as TRegistro_FichaTec).Quantidade;
                                    }
                                    else
                                    {
                                        quantidadeAgregar();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        quantidadeAgregar();
                    }

                }
                bsFicha.ResetCurrentItem();
            }
        }

        private void quantidadeAgregar()
        {
            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
            {
                fQtd.Text = "Quantidade";
                if (fQtd.ShowDialog() == DialogResult.OK)
                    if (fQtd.Quantidade > decimal.Zero)
                    {
                        if (fQtd.Quantidade <= (bsFicha.Current as TRegistro_FichaTec).Sd_faturar)
                        {
                            (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar =
                                fQtd.Quantidade;
                            (bsFicha.Current as TRegistro_FichaTec).Vl_subtotal = decimal.Multiply((bsFicha.Current as TRegistro_FichaTec).quantidade_agregar, (bsFicha.Current as TRegistro_FichaTec).Vl_unitario);

                        }
                        else
                        {
                            MessageBox.Show("Quantidade informada é maior que a QTD.Item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                        return;
                    }
                else
                {
                    (bsFicha.Current as TRegistro_FichaTec).st_agregar = false;
                    (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                }
            }
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(vCd_Local))
            {
                vDs_Local = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().BuscarEscalar(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_local",
                        vOperador = "=",
                        vVL_Busca = vCd_Local
                    }
                }, "a.ds_local").ToString();

            }

            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vID_Orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vID_Orcamento;
            }
            if (!string.IsNullOrEmpty(vNr_Versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Versao;
            }
            if (!string.IsNullOrEmpty(vId_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_registro;
            }

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = " isnull(a.quantidade - a.qtd_faturada,0) ";
            filtro[filtro.Length - 1].vOperador = ">";
            filtro[filtro.Length - 1].vVL_Busca = "0";
            if (!string.IsNullOrEmpty(vSt_fatdireto))
            {
                if (vSt_fatdireto.Equals("S"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_fatdireto,'N') ";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_fatdireto + "'";
                }
                else if (vSt_fatdireto.Equals("N"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_fatdireto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'S'";
                }
            }
            bsFicha.DataSource = new TCD_FichaTec(null).Select(filtro, 0, string.Empty);
            if (rfatDir != null)
                rfatDir.lFicha.ForEach(p =>
                {
                    (bsFicha.List as TList_FichaTec).ForEach(o =>
                    {
                        if (p.Id_projetostr.Equals(o.Id_projetostr) && p.Id_fichastr.Equals(p.Id_fichastr))
                        {
                            o.quantidade_agregar = p.quantidade_agregar;
                            o.st_agregar = p.st_agregar;
                        }
                    });
                });

            bsFicha.ResetCurrentItem();

        }
        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(vCd_Local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       vCd_Local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }
        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            bool flag = false, semvalor = false;
            try
            {
                if (bsOrcamento.Current == null)
                {
                    MessageBox.Show("Selecione um projeto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }else if ((bsFicha.List as List<TRegistro_FichaTec>).Where(p => p.st_agregar).ToList().FindAll(c => string.IsNullOrEmpty(c.Cd_produto)).Count > 0)
                {
                    MessageBox.Show("Obrigatório informar código de produto para gerar a remessa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                (bsFicha.List as List<TRegistro_FichaTec>).Where(p => p.st_agregar && p.quantidade_agregar > decimal.Zero).ToList().ForEach(p =>
                {
                    flag = true;
                    if (vTp_Fat.Equals("Normal"))
                    {
                        decimal saldo = BuscarSaldoLocal(vCD_Empresa, p.Cd_produto);
                        if (saldo.Equals(decimal.Zero))
                        {
                            MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                "Produto.........: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                "Local Arm.......: " + vCd_Local.Trim() + "-" + vDs_Local + "\r\n" +
                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                semvalor = true;
                        }
                    }
                });

                if (!semvalor)
                    if (flag)
                    {
                        if (vTp_Fat.Equals("Normal"))
                        {
                            List<TRegistro_FichaTec> lficha = new List<TRegistro_FichaTec>();
                            (bsFicha.List as List<TRegistro_FichaTec>).Where(p => p.st_agregar && p.quantidade_agregar > decimal.Zero).ToList()
                                .ForEach(x => lficha.Add(x));
                            bsCFGEmpreendimento.DataSource = TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);
                            bsCFGEmpreendimento.ResetCurrentItem();

                            TList_CadCFGEmpreendimento lcfg = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);

                            if (lcfg[0].tp_precoitem.Trim().Equals("0"))
                                lficha.ForEach(p =>
                                {
                                    p.Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, null);
                                    if (p.Vl_unitario <= decimal.Zero)
                                        throw new Exception("Produto " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + " esta com valor medio negativo no estoque.");
                                });


                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.ProcessaEmpreendimento.ProcessarEmpreendimento("N", (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                                         rorcamento,
                                                                                                                         lficha);
                            TCN_Orcamento.ProcessarNFEmpreendimento(rNf, bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento, bsOrcamento.Current as TRegistro_Orcamento, null);


                            if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && rNf.Cd_modelo.Trim().Equals("55"))
                                if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    //Verificar se é nota de produto ou mista
                                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                                    new TpBusca[]
                                                                {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.nr_serie",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNf.Nr_serie + "'"
                                                            }
                                                                }, "a.tp_serie");
                                    if (obj != null)
                                        if (obj.ToString().Trim().ToUpper().Equals("P") ||
                                            obj.ToString().Trim().ToUpper().Equals("M"))
                                        {
                                            try
                                            {
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                                    null);
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                        else if (obj.ToString().Trim().ToUpper().Equals("S"))
                                        {
                                            try
                                            {
                                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfs =
                                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                     rNf.Nr_lanctofiscalstr,
                                                                                                                     null);
                                                NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                                MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                }
                        }
                        DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Para confirmar deve selecionar algum item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FItensRemessa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            if (e.KeyCode.Equals(Keys.F5))
                BB_Excluir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.Down))
                BuscarIndexContaCtb();
        }

        private void BuscarIndexContaCtb()
        {
            try
            {
                if (bsFicha.Current != null)
                {
                    var linha = dataGridDefault3.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["dataGridViewTextBoxColumn10"].Value.ToString().Contains(ds_conta.Text)).ToList();
                    if (linha != null)
                    {
                        if (index + 1 < linha.Count)
                            index++;
                        else
                            index = 0;
                        var p = linha[index];
                        dataGridDefault3.Rows[p.Index].Selected = true;
                        bsFicha.Position = p.Index;
                        lbSequencia.Text = (index + 1).ToString() + " de " + linha.Count;
                    }
                }
            }
            catch { }
        }

        private void ds_conta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow linha = dataGridDefault3.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["dataGridViewTextBoxColumn10"].Value.ToString().Contains(ds_conta.Text)).First();
                if (linha != null)
                {
                    dataGridDefault3.Rows[linha.Index].Selected = true;
                    bsFicha.Position = linha.Index;
                    decimal result = dataGridDefault3.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["dataGridViewTextBoxColumn10"].Value.ToString().Contains(ds_conta.Text)).Count();
                    if (result == 0)
                    {
                        lbResultados.Text = "NENHUM RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result == 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result > 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADOS ENCONTRADOS";
                        index = 0;
                    }
                    lbSequencia.Text = (index + 1).ToString() + " de " + result.ToString();
                }
            }
            catch
            { }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            using (TFFichaTec fFicha = new TFFichaTec())
            {
                fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                fFicha.pCd_tabelapreco = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Cd_tabelapreco;
                fFicha.vId_Orc = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                fFicha.vNr_Ver = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                fFicha.vSt_Proj = true;
                if (fFicha.ShowDialog() == DialogResult.OK)
                    if (fFicha.rFicha != null)
                    {
                        fFicha.rFicha.St_addremessa = "S";
                        fFicha.rFicha.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        fFicha.rFicha.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                        fFicha.rFicha.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                        fFicha.rFicha.Id_registrostr = fFicha.pId_registro;
                        fFicha.rFicha.Id_ficha = null;
                        fFicha.rFicha.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;

                        TCN_FichaTec.Gravar(fFicha.rFicha, null);
                        bsFicha.Add(fFicha.rFicha);
                    }
            }
        }
    }
}
