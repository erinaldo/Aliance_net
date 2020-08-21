using System;
using CamadaDados.Empreendimento;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class FRequisicaoCompra : Form
    {
        private TRegistro_Orcamento cOrcamento { get; set; } = new TRegistro_Orcamento();
        public TRegistro_Orcamento rOrcamento
        {
            get
            {
                return null;
            }
            set
            {
                cOrcamento = value;
            }
        }
        public TRegistro_OrcProjeto objetoItens
        {
            get
            {
                return bsProjeto.Current as TRegistro_OrcProjeto; ;
            }
        }

        public FRequisicaoCompra()
        {
            InitializeComponent();
        }

        private void FRequisicaoCompra_Load(object sender, EventArgs e)
        {

            bsProjeto.AddNew();
            if(cOrcamento != null)
            {
                cOrcamento.lOrcProjeto.ForEach(o =>
                {
                    o.lFicha.ForEach(p =>
                    {
                        if (!p.St_fatdiretobool)
                            (bsProjeto.Current as TRegistro_OrcProjeto).lFicha.Add(p); 
                    });
                });
            }
            bsProjeto.ResetCurrentItem();
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsFichaTec.Current as TRegistro_FichaTec).st_agregar =
                    !(bsFichaTec.Current as TRegistro_FichaTec).st_agregar;
                if ((bsFichaTec.Current as TRegistro_FichaTec).st_agregar)
                    (bsFichaTec.Current as TRegistro_FichaTec).quantidade_agregar = (bsFichaTec.Current as TRegistro_FichaTec).Quantidade;
                else
                    (bsFichaTec.Current as TRegistro_FichaTec).quantidade_agregar = decimal.Zero;
                bsFichaTec.ResetCurrentItem();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        { 
                (bsProjeto.Current as TRegistro_OrcProjeto).lFicha.ForEach(p =>
                {
                    p.st_agregar = checkBoxDefault1.Checked;
                    if (p.st_agregar)
                        p.quantidade_agregar = p.Quantidade;
                    else
                        p.quantidade_agregar = decimal.Zero;
                });
            bsProjeto.ResetCurrentItem();
        }

        private void FRequisicaoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
