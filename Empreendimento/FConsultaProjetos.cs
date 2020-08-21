using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using CamadaDados.Estoque.Cadastros;
using Utils;
namespace Empreendimento
{
    public partial class TFConsultaProjetos : Form
    {
        private int position = 0;
        public string vId_orcamento { get; set; }
        public string vId_Clifor { get; set; }
        private CamadaDados.Empreendimento.TList_Orcamento lorc;
        public CamadaDados.Empreendimento.TList_Orcamento lOrc
        {
            get
            {
                return bsOrcamento.DataSource as CamadaDados.Empreendimento.TList_Orcamento;
            }
            set { lorc = value; }
        }

        public TFConsultaProjetos()
        {
            InitializeComponent();
        }

        private void TFConsultaProjetos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            // nr_orcamento.Text = vId_orcamento;
            afterBusca();
        }
        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }
        private void afterBusca()
        {
            bsOrcamento.DataSource = TCN_Orcamento.Buscar(cd_empresa.Text, nr_orcamento.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();


        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        
        }

        private void dataGridDefault2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridDefault2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsProjeto.Current as TRegistro_OrcProjeto).st_importar = !(bsProjeto.Current as TRegistro_OrcProjeto).st_importar;
                if (bsProjeto.Current != null)
                {

                    (bsProjeto.Current as TRegistro_OrcProjeto).lFicha =
                        TCN_FichaTec.Buscar((bsProjeto.Current as TRegistro_OrcProjeto).Cd_empresa,
                                            (bsProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                            (bsProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                            (bsProjeto.Current as TRegistro_OrcProjeto).Id_projetostr,
                                            (bsProjeto.Current as TRegistro_OrcProjeto).Id_registrostr,
                                            "",
                                            null);

                    (bsProjeto.Current as TRegistro_OrcProjeto).lFicha.ForEach(p => { p.st_agregar = true; p.quantidade_agregar = p.Quantidade; });
                    bsProjeto.ResetCurrentItem();

                }
            }
        }

        private void bb_importar_Click(object sender, EventArgs e)
        {
            if(bsProjeto.Current != null)
                //(bsComposto.List as TList_FichaTecProduto).ForEach(p => 
                //{
                //    TRegistro_FichaItens item = new TRegistro_FichaItens();
                //    item.Cd_item = Convert.ToDecimal(p.Cd_item);
                //    item.quantidade = p.Quantidade;
                //    item.vl_unitario = p.Vl_custoservico;
                //    item.Nr_versaostr = (bsProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr;
                //    item.Id_projetostr = (bsProjeto.Current as TRegistro_OrcProjeto).Id_projetostr;
                //    item.Id_orcamentostr = (bsProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr;
                //    item.Cd_empresa = (bsProjeto.Current as TRegistro_OrcProjeto).Cd_empresa;
                //});


            this.DialogResult = DialogResult.OK;
        }

        private void TFConsultaProjetos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else
                if (e.KeyCode.Equals(Keys.F6))
                    bb_importar_Click(this, new EventArgs());
        }

        private void bsProjeto_PositionChanged(object sender, EventArgs e)
        {
            if(bsProjeto.Current != null)
            if (bsProjeto.Count <= 0)
            {
                (bsProjeto.Current as TRegistro_OrcProjeto).lFicha =
                            TCN_FichaTec.Buscar((bsProjeto.Current as TRegistro_OrcProjeto).Cd_empresa,
                                                (bsProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                                (bsProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                                (bsProjeto.Current as TRegistro_OrcProjeto).Id_projetostr,
                                                (bsProjeto.Current as TRegistro_OrcProjeto).Id_registrostr,
                                                "",
                                                null);


                (bsProjeto.Current as TRegistro_OrcProjeto).lFicha.ForEach(p => { p.st_agregar = true; p.quantidade_agregar = p.Quantidade; });

                bsProjeto.ResetCurrentItem();
            }
        }

        private void gFicha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

                if (e.ColumnIndex == 0)
                {
                    if (!(bsProjeto.Current as TRegistro_OrcProjeto).st_importar)
                        (bsProjeto.Current as TRegistro_OrcProjeto).st_importar = !(bsProjeto.Current as TRegistro_OrcProjeto).st_importar;

                    (bsFicha.Current as TRegistro_FichaTec).st_agregar =
                        !(bsFicha.Current as TRegistro_FichaTec).st_agregar;
                    if ((bsFicha.Current as TRegistro_FichaTec).st_agregar)
                        using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                        {
                            fQtd.Text = "Quantidade";
                         //   fQtd.Vl_default = (bsFicha.Current as TRegistro_FichaTec).vl;
                            if (fQtd.ShowDialog() == DialogResult.OK)
                                if (fQtd.Quantidade > decimal.Zero)
                                {
                                    (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar =
                                        fQtd.Quantidade;
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
                    else
                        (bsFicha.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                    bsFicha.ResetCurrentItem();
                }
            
        }

        private void bsFicha_PositionChanged(object sender, EventArgs e)
        {
            if (bsFicha.Current != null)
            {
                bsComposto.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsFicha.Current as TRegistro_FichaTec).Cd_produto, string.Empty, null);
                bsComposto.ResetCurrentItem();
            }
        }

        private void bbCorrigirOrc_Click(object sender, EventArgs e)
        {
            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
            {
                fQtd.Text = "Quantidade";
                fQtd.Vl_default = (bsComposto.Current as TRegistro_FichaTecProduto).Quantidade;
                if (fQtd.ShowDialog() == DialogResult.OK)
                    if (fQtd.Quantidade > decimal.Zero)
                    {
                        (bsComposto.Current as TRegistro_FichaTecProduto).Quantidade =
                            fQtd.Quantidade;
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                else
                {
                    (bsComposto.Current as TRegistro_FichaTecProduto).Quantidade = decimal.Zero;
                }
            }
            bsComposto.ResetCurrentItem();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                    if((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count <= 0)
                    //Buscar Atividades
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                        TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos =
                    TCN_RequisitoORc.Buscar(string.Empty, (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, null);


            (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                    {
                        p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa,
                                                    p.Id_orcamentostr,
                                                    (p).Nr_versaostr,
                                                    p.Id_projetostr,
                                                    p.Id_registrostr,
                                                    "",
                                                    null);

                       


                        p.lFicha.ForEach(o => {
                            o.quantidade_agregar = o.Quantidade; });
                    });

                    if ((bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Count <= 0)
                    //Buscar Despesas
                    (bsOrcamento.Current as TRegistro_Orcamento).lDespesas =
                        TCN_Despesas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                            string.Empty,
                                            string.Empty,
                                            null);
                    if((bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.Count <= 0)
                    //Buscar mao obra
                    (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(
                                            (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                            string.Empty,
                                            null);
                    if((bsOrcamento.Current as TRegistro_Orcamento).lOEncargo.Count <= 0)
                    //Buscar encargos
                    (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(
                                            string.Empty,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                            (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                            null);
                    bsOrcamento.ResetCurrentItem();
                    bsProjeto_PositionChanged(this, new EventArgs());
                    bsProjeto.ResetCurrentItem();
                
            }
        }

        private void dataGridDefault10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                (bsOrcamento.List as List<TRegistro_Orcamento>).ForEach(p =>
                {
                    p.st_aprovar = false;   
                    p.lDespesas.ForEach(d => d.st_importar = false);
                    p.lMaoObra.ForEach(m => m.st_importar = false);
                    p.lOEncargo.ForEach(en => en.st_importar = false);
                    p.lOrcProjeto.ForEach(o => o.st_importar = false);
                });
                bsOrcamento.ResetBindings(true);
                (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar = !(bsOrcamento.Current as TRegistro_Orcamento).st_aprovar;

                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p => {
                    p.st_importar = (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar;
                    p.lFicha.ForEach(o => 
                    { o.st_agregar = (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar; });

                });
                
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.ForEach(p =>
                    p.st_importar = (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar);
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo.ForEach(p =>
                    p.st_importar = (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar);
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.ForEach(p =>
                    p.st_importar = (bsOrcamento.Current as TRegistro_Orcamento).st_aprovar);
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void dataGridDefault5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                (bsProjeto.Current as TRegistro_OrcProjeto).st_importar = !(bsProjeto.Current as TRegistro_OrcProjeto).st_importar;
                (bsProjeto.Current as TRegistro_OrcProjeto).lFicha.ForEach(p =>
                {
                    p.st_agregar = (bsProjeto.Current as TRegistro_OrcProjeto).st_importar;
                });
                bsProjeto.ResetCurrentItem();
            }
        }

        private void dataGridDefault4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                (bsFicha.Current as TRegistro_FichaTec).st_agregar = !(bsFicha.Current as TRegistro_FichaTec).st_agregar;
            }
        }

        private void dataGridDefault6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                (bsDespesas.Current as TRegistro_Despesas).st_importar = !(bsDespesas.Current as TRegistro_Despesas).st_importar;
            }
        }

        private void dataGridDefault7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsMaObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).st_importar =
                    !(bsMaObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).st_importar;
            }
        }

        private void dataGridDefault8_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                (bsEncargo.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_OrcamentoEncargo).st_importar =
                    !(bsEncargo.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_OrcamentoEncargo).st_importar;
            }
        }
    }
}
