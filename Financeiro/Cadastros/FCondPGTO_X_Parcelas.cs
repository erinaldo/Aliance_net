using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCondPGTO_X_Parcelas : Form
    {
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto_X_Parcelas rparcelas;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto_X_Parcelas rParcelas
        {
            get 
            {
                if (BS_CondPgtoXParcelas.Current != null)
                    return BS_CondPgtoXParcelas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto_X_Parcelas;
                else
                    return null;
            }
            set 
            { rparcelas = value; }
        }

        public TFCondPGTO_X_Parcelas()
        {
            rparcelas = null;
            InitializeComponent();
        }

        private void afterGrava()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void afterCancela() 
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        private void afterExclui() 
        {
            if (BS_CondPgtoXParcelas != null) 
            {
                if (MessageBox.Show("Deseja realmente excluir as parcelas?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes) 
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto_X_Parcelas.DeletarTodasParcelas(BS_CondPagamento.Current, null);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Parcelas excluídas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bbCancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void bbGravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
