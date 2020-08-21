using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Diversos;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;

namespace Empreendimento
{
    public partial class TFOrcamento : Form
    {
        private CamadaDados.Empreendimento.TRegistro_Orcamento rorcamento;
        public CamadaDados.Empreendimento.TRegistro_Orcamento rOrcamento
        {
            get
            {
                if (bsOrcamento.Current != null)
                    return bsOrcamento.Current as CamadaDados.Empreendimento.TRegistro_Orcamento;
                else return null;
            }
            set { rorcamento = value; }
        }

        public TFOrcamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {


            string[] str = editData1.Text.Trim().Split('/');
            for (int i = 0; i < str.Length; i++)
            {
                if (string.IsNullOrEmpty(str[i].Trim()))
                {
                    MessageBox.Show("Informe a previsão proposta", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editData1.Focus();
                    return;
                }
            }

            if (Convert.ToDateTime(editData1.Text) < DateTime.Now)
            {
                MessageBox.Show("Data previsão proposta invalida", "Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editData1.Focus();
                return;
            }

            if (!dt_prevfin.Text.Equals("  /  /") && !dt_previni.Text.Equals("  /  /"))
                if (Convert.ToDateTime(dt_previni.Text) > Convert.ToDateTime(dt_prevfin.Text))
                {
                    MessageBox.Show("Data da previsão deve ser maior que a data inicial!", "mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    dt_prevfin.Focus();
                    return;
                }

            TList_CadCFGEmpreendimento lcfg = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);
            if (lcfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe pré-cadastrado configuração de empreendimento, não será possível finalizar o processo de orçamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((bsOrcamento.Current as TRegistro_Orcamento).lRequisitos.Count < lcfg[0].QT_MINREQUISITO)
            {
                MessageBox.Show("Deve informar mais requisitos pois o mínimo é " + lcfg[0].QT_MINREQUISITO, "Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFOrcamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            if (rorcamento != null)
            {
                bsOrcamento.DataSource = new CamadaDados.Empreendimento.TList_Orcamento() { rorcamento };
                cbEmpresa.Enabled = false;
                rgCustos.Enabled = !rorcamento.St_registro.Trim().ToUpper().Equals("N");
                if (bsOrcamento.Current != null)
                {
                    bsOrcamento_PositionChanged(this, new EventArgs());
                    bsOrcamento.ResetCurrentItem();
                }
            }
            else
            {
                bsOrcamento.AddNew();
                cbEmpresa.SelectedIndex = 0;
            }
            //dt_previni.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {

            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            if (linha != null)
            {
                cnpj_cpf.Text = linha["tp_pessoa"].ToString().Trim().ToUpper().Equals("J") ? linha["nr_cgc"].ToString() : linha["nr_cpf"].ToString();
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[]{
                                                                                    new TpBusca(){
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador= "=",
                                                                                        vVL_Busca = cd_clifor.Text
                                                                                    }}, 1, string.Empty);
                CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lcont =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor().Select(new TpBusca[]{
                                                                                    new TpBusca(){
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador= "=",
                                                                                        vVL_Busca = cd_clifor.Text
                                                                                    }}, 1, string.Empty);
                if (lcont.Count > 0)
                {
                    cd_contato.Text = lcont[0].Id_Contato_St;
                    fone_contato.Text = lcont[0].Fone;
                    email_contato.Text = lcont[0].Email;
                }

                if (lEnd.Count > 0)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                    ds_enderecoemp.Text = lEnd[0].Ds_endereco;
                    numeroemp.Text = lEnd[0].Numero;
                    bairroemp.Text = lEnd[0].Bairro;
                    (bsOrcamento.Current as TRegistro_Orcamento).Foneemp = lEnd[0].Fone;
                    cd_cidadeemp.Text = lEnd[0].Cd_cidade;
                    ds_cidadeemp.Text = lEnd[0].DS_Cidade;
                    uf_emp.Text = lEnd[0].UF;
                    ds_empreendimento.Focus();
                }
                bsOrcamento.ResetCurrentItem();
            }
            else cnpj_cpf.Clear();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (linha != null)
            {
                cnpj_cpf.Text = linha["tp_pessoa"].ToString().Trim().ToUpper().Equals("J") ? linha["nr_cgc"].ToString() : linha["nr_cpf"].ToString();
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[]{
                                                                                    new TpBusca(){
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador= "=",
                                                                                        vVL_Busca = cd_clifor.Text
                                                                                    }}, 1, string.Empty);

                CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lcont =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor().Select(new TpBusca[]{
                                                                                    new TpBusca(){
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador= "=",
                                                                                        vVL_Busca = cd_clifor.Text
                                                                                    }}, 1, string.Empty);
                if (lcont.Count > 0)
                {
                    cd_contato.Text = lcont[0].Id_Contato_St;
                    fone_contato.Text = lcont[0].Fone;
                    email_contato.Text = lcont[0].Email;
                }
                if (lEnd.Count > 0)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                    ds_enderecoemp.Text = lEnd[0].Ds_endereco;
                    numeroemp.Text = lEnd[0].Numero;
                    bairroemp.Text = lEnd[0].Bairro;
                    foneemp.Text = lEnd[0].Fone;
                    cd_cidadeemp.Text = lEnd[0].Cd_cidade;
                    ds_cidadeemp.Text = lEnd[0].DS_Cidade;
                    uf_emp.Text = lEnd[0].UF;
                    ds_empreendimento.Focus();
                }
            }
            else cnpj_cpf.Clear();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|150;a.cd_endereco|Código|50",
                new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(),
                "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                                              "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_cidade|Cidade|200;a.cd_cidade|Código|50;a.uf|UF|30",
                                             new Componentes.EditDefault[] { cd_cidadeemp, ds_cidadeemp, uf_emp },
                                             new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);

        }

        private void cd_cidadeemp_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_cidade|=|'" + cd_cidadeemp.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { cd_cidadeemp, ds_cidadeemp, uf_emp },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void foneemp_TextChanged(object sender, EventArgs e)
        {
            if (foneemp.Text.SoNumero().Length.Equals(10))
            {
                foneemp.Text = "(" + foneemp.Text.SoNumero().Substring(0, 2) + ")" + foneemp.Text.SoNumero().Substring(2, 4) + "-" + foneemp.Text.SoNumero().Substring(6, 4);
                foneemp.SelectionStart = foneemp.Text.Length;
            }
            else if (foneemp.Text.SoNumero().Length.Equals(11))
                if (foneemp.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    foneemp.Text = "(" + foneemp.Text.SoNumero().Substring(0, 3) + ")" + foneemp.Text.SoNumero().Substring(3, 4) + "-" + foneemp.Text.SoNumero().Substring(7, 4);
                    foneemp.SelectionStart = foneemp.Text.Length;
                }
                else
                {
                    foneemp.Text = "(" + foneemp.Text.SoNumero().Substring(0, 2) + ")" + foneemp.Text.SoNumero().Substring(2, 5) + "-" + foneemp.Text.SoNumero().Substring(7, 4);
                    foneemp.SelectionStart = foneemp.Text.Length;
                }
            else if (foneemp.Text.SoNumero().Length.Equals(12))
            {
                foneemp.Text = "(" + foneemp.Text.SoNumero().Substring(0, 3) + ")" + foneemp.Text.SoNumero().Substring(3, 5) + "-" + foneemp.Text.SoNumero().Substring(8, 4);
                foneemp.SelectionStart = foneemp.Text.Length;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cd_vendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                        nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                        cnpj_cpf.Text = fClifor.rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? fClifor.rClifor.Nr_cgc : fClifor.rClifor.Nr_cpf;
                        if (fClifor.rClifor.lEndereco.Count > 0)
                        {
                            cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                            ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                            ds_enderecoemp.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                            numeroemp.Text = fClifor.rClifor.lEndereco[0].Numero;
                            bairroemp.Text = fClifor.rClifor.lEndereco[0].Bairro;
                            foneemp.Text = fClifor.rClifor.lEndereco[0].Fone;
                            cd_cidadeemp.Text = fClifor.rClifor.lEndereco[0].Cd_cidade;
                            ds_cidadeemp.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                            uf_emp.Text = fClifor.rClifor.lEndereco[0].UF;
                        }
                        if (fClifor.rClifor.lContato.Count > 0)
                        {
                            cd_contato.Text = fClifor.rClifor.lContato[0].Id_Contato_St;
                            nm_contato.Text = fClifor.rClifor.lContato[0].Nm_Contato;
                            fone_contato.Text = fClifor.rClifor.lContato[0].Fone;
                            email_contato.Text = fClifor.rClifor.lContato[0].Email;
                        }
                    }
            }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rorcamento == null && cbEmpresa.SelectedValue != null)
            {
                //Buscar Configuração Empreendimento
                TList_CadCFGEmpreendimento lCfg = TCN_CadCFGEmpreendimento.Busca(cbEmpresa.SelectedValue.ToString(),
                                                                                 string.Empty,
                                                                                 null);
                if (lCfg.Count > 0)
                {
                    //pc_irpj.Value = lCfg[0].Pc_IRPJ;
                    //pc_csll.Value = lCfg[0].Pc_CSLL;
                    //pc_pis.Value = lCfg[0].Pc_PIS;
                    //pc_cofins.Value = lCfg[0].Pc_Cofins;
                    //pc_margemcont.Value = lCfg[0].Pc_margemcont; 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.nm_contato|Contato|150;a.email|Email|150;a.fone|Fone|80;a.id_contato|Código|50",
                new Componentes.EditDefault[] { cd_contato, nm_contato, fone_contato, email_contato },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor(),
                "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_contato_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_contato, nm_contato, fone_contato, email_contato },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor());
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            using (TFOrcProjeto fOrc = new TFOrcProjeto())
            {
                TRegistro_OrcProjeto copia = (TRegistro_OrcProjeto)(bsAtividade.Current as TRegistro_OrcProjeto).Clone();
                fOrc.rOrc = bsAtividade.Current as TRegistro_OrcProjeto;
                if (fOrc.ShowDialog() != DialogResult.OK)
                {
                    int position = bsAtividade.Position;
                    bsAtividade.RemoveCurrent();
                    bsAtividade.Insert(position, copia);
                    bsOrcamento.ResetCurrentItem();
                }
            }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {

        }

        private void bbAddProjeto_Click_1(object sender, EventArgs e)
        {
            using (Cadastro.FAtividades atv = new Cadastro.FAtividades())
            {
                CamadaDados.Empreendimento.Cadastro.TList_CadAtividade lista = new CamadaDados.Empreendimento.Cadastro.TList_CadAtividade();
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {

                    TRegistro_CadAtividade a = new TRegistro_CadAtividade();
                    a.Ds_atividade = p.Ds_projeto;
                    lista.Add(a);
                });
                atv.rLAtividade = lista;
                if (atv.ShowDialog() == DialogResult.OK)
                {
                    if (atv.rLAtividade.Count > 0)
                        atv.rLAtividade.ForEach(p =>
                        {
                            if (p.st_agregar)
                            {
                                TRegistro_OrcProjeto orc = new TRegistro_OrcProjeto();
                                orc.Id_projetostr = p.Id_atividadestr;
                                orc.Ds_projeto = p.Ds_atividade;
                                //p.lRequisitos.ForEach(o =>
                                //{
                                //    if (o.st_agregar)
                                //    {
                                //        TRegistro_Requisitos req = new TRegistro_Requisitos();
                                //        req.id_atividade = o.id_atividade;
                                //        req.ds_requisito = o.ds_requisito;
                                //        req.id_requisito = o.id_requisito;
                                //        orc.lRequisitos.Add(req);
                                //    }
                                //});
                                bsAtividade.Add(orc);
                            }
                        });

                }


            }
        }

        private void bbExcluirProjeto_Click_1(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
                if (MessageBox.Show("Confirma exclusão da atividade selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsAtividade.Current as TRegistro_OrcProjeto).Id_projeto.HasValue)
                        (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjetoDel.Add(bsAtividade.Current as TRegistro_OrcProjeto);
                    bsAtividade.RemoveCurrent();
                }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (Cadastro.FRequisitos a = new Cadastro.FRequisitos())
            {
                TList_CadRequisitos lreq = new TList_CadRequisitos();
                (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos.ForEach(p =>
                {
                    TRegistro_CadRequisitos item = new TRegistro_CadRequisitos();
                    item.ds_requisito = p.ds_requisito;
                    item.id_requisito = p.id_requisito.ToString();
                    lreq.Add(item);
                });
                a.rLRequisito = lreq;
                if (a.ShowDialog() == DialogResult.OK)
                {
                    lreq = a.rLRequisito;
                    lreq.ForEach(p =>
                    {
                        if (p.st_agregar)
                        {
                            TRegistro_RequisitoOrc item = new TRegistro_RequisitoOrc();
                            item.id_requisito = Convert.ToDecimal(p.id_requisito);
                            item.ds_requisito = p.ds_requisito;
                            (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos.Add(item);
                        }
                    });
                    bsOrcamento.ResetCurrentItem();
                }

                //       a.rLRequisito = (bs)

            }
        }

        private void dataGridDefault4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridDefault4_DoubleClick(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja remover?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lDelRequisitos.Add(bsRequisito.Current as TRegistro_RequisitoOrc);
                bsRequisito.RemoveCurrent();
            }
        }

        private void dataGridDefault4_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (TFTarefas fTarefa = new TFTarefas())
            {
                if (fTarefa.ShowDialog() == DialogResult.OK)
                    (bsRequisito.Current as TRegistro_RequisitoOrc).obs = fTarefa.pDs_tarefa;
                bsRequisito.ResetCurrentItem();
            }
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {

                TpBusca[] filtro = new TpBusca[0];
                if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                }
                if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                }
                //if (filtro.Length > 0)
                //{
                //    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto = TCN_OrcProjeto.Buscar(
                //        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                //        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                //        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                //        string.Empty, string.Empty, null);
                //    (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos = TCN_RequisitoORc.Buscar(string.Empty,
                //        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                //        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                //        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, null);
                //}
                //else
                //{
                //    TList_CadRequisitos lcadreq = CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Buscar(string.Empty, string.Empty, null);
                //    lcadreq.ForEach(p =>
                //    {
                //        TRegistro_RequisitoOrc item = new TRegistro_RequisitoOrc();
                //        item.ds_requisito = p.ds_requisito;
                //        item.id_requisito = Convert.ToDecimal(p.id_requisito);
                //        (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos.Add(item);
                //    });
                //    TList_CadAtividade lativ = CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Buscar(string.Empty, string.Empty, null);
                //    lativ.ForEach(p =>
                //    {
                //        TRegistro_OrcProjeto item = new TRegistro_OrcProjeto();
                //        item.Id_projeto = p.Id_atividade;
                //        item.Ds_projeto = p.Ds_atividade;
                //        (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Add(item);
                //    });



                //}
            }
        }
    }
}

