using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class FLanFuncionario : Form
    {
        private CamadaDados.Empreendimento.TRegistro_Funcionarios cCargo;
        public CamadaDados.Empreendimento.TRegistro_Funcionarios rCargo
        {
            get
            {
                if (bsFuncionario.Current != null)
                    return bsFuncionario.Current as CamadaDados.Empreendimento.TRegistro_Funcionarios;
                else return null;
            }
            set { cCargo = value; }
        }

        public FLanFuncionario()
        {
            InitializeComponent();
        }

        private void FLanFuncionario_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();
            if (cCargo == null)
                bsFuncionario.AddNew();
            else
            {
                bsFuncionario.DataSource = new CamadaDados.Empreendimento.TList_Funcionarios() { cCargo };
            }
        }

        private void idcargo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cargo|=|'" + idcargo.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { idcargo, dscargo },
                new CamadaDados.Diversos.TCD_CargoFuncionario());
            if (linha != null)
                vl_base.Value = !string.IsNullOrEmpty(linha["vl_basesalario"].ToString())
                    ? Convert.ToDecimal(linha["vl_basesalario"].ToString()) : decimal.Zero;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_cargo|Cd. cargo|80;" + 
                            "a.ds_cargo|cargo|200;" +      
                            "a.vl_basesalario|vl_base|80"; 
          DataRowView linha =  FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
                                            new Componentes.EditDefault[] { idcargo, dscargo },
                                            new CamadaDados.Diversos.TCD_CargoFuncionario(),
                                            string.Empty);
          if (linha != null)
              vl_base.Value = !string.IsNullOrEmpty(linha["vl_basesalario"].ToString())
                  ? Convert.ToDecimal(linha["vl_basesalario"].ToString()) : decimal.Zero;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void qtd_Leave(object sender, EventArgs e)
        {
            if (vl_base.Value > decimal.Zero)
                (bsFuncionario.Current as CamadaDados.Empreendimento.TRegistro_Funcionarios).Vl_subtotal = Math.Round(decimal.Multiply(decimal.Multiply(qtd.Value, vl_base.Value), Horas.Value), 2, MidpointRounding.AwayFromZero);
        }

        private void edbase_Leave(object sender, EventArgs e)
        {
            if (vl_base.Value > decimal.Zero)
                (bsFuncionario.Current as CamadaDados.Empreendimento.TRegistro_Funcionarios).Vl_subtotal = Math.Round(decimal.Multiply(decimal.Multiply(qtd.Value, vl_base.Value), Horas.Value), 2, MidpointRounding.AwayFromZero);
        }

        private void eddias_Leave(object sender, EventArgs e)
        {
            if (Horas.Value > decimal.Zero)
                (bsFuncionario.Current as CamadaDados.Empreendimento.TRegistro_Funcionarios).Vl_subtotal = Math.Round(decimal.Multiply(decimal.Multiply(qtd.Value, vl_base.Value), Horas.Value), 2, MidpointRounding.AwayFromZero);
        }

    }
}
