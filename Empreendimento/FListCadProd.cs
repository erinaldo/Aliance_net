using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;


namespace Empreendimento
{
    public partial class FListCadProd : Form
    {
        public FListCadProd()
        {
            InitializeComponent();
        }

        private TList_FichaTec cLItens = new TList_FichaTec();
        public TList_FichaTec rLItens
        {
            get
            {
                return bsFichaTec.DataSource as TList_FichaTec;
            }
            set
            {
                cLItens = value;
            }
        }


        private void FListCadProd_Load(object sender, EventArgs e)
        {
            if (cLItens.Count > 0)
            {
                bsFichaTec.DataSource = cLItens;
            }
        }

        private void dataGridDefault1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cadastraproduto()
        {
            if(bsFichaTec.Current != null)
            {
                using(Estoque.Cadastros.TFProduto p = new Estoque.Cadastros.TFProduto())
                {
                    CamadaDados.Estoque.Cadastros.TRegistro_CadProduto produto = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                    p.vDS_produto = (bsFichaTec.Current as TRegistro_FichaTec).Ds_produto;

                    if(p.ShowDialog() == DialogResult.OK)
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(p.rProd,null);
                        (bsFichaTec.Current as TRegistro_FichaTec).Cd_produto = p.rProd.CD_Produto;
                        if (p.rProd.lPrecoItem.Count > 0)
                        {
                            (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario = p.rProd.lPrecoItem[0].VL_PrecoVenda;
                            (bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal = p.rProd.lPrecoItem[0].VL_PrecoVenda *
                                (bsFichaTec.Current as TRegistro_FichaTec).Quantidade; 
                        }
                    }
                    bsFichaTec.ResetCurrentItem();
                }


            }
        }

        private void dataGridDefault1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cadastraproduto();
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            cadastraproduto();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FListCadProd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else
            if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;

        }
    }
}
