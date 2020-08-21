using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFLanCCustoEmpreendimento : Form
    {
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF> lCResultado
        {
            get
            {
                if (bsGrupoCF.Count > 0)
                    return (bsGrupoCF.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF).FindAll(p => p.St_integrar);
                else
                    return null;
            }
        }

        public TFLanCCustoEmpreendimento()
        {
            InitializeComponent();
        }

        private void SetarFlagIntegra()
        {
            if (bsGrupoCF.Current != null)
            {
                if ((bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).St_integrar)
                {
                    (bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).St_integrar = false;
                    if ((bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).St_sinteticobool)
                    {
                        string cd_grupo = (bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).Cd_grupocf;
                        (bsGrupoCF.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF).ForEach(p =>
                        {
                            if (p.Cd_grupocf_pai.Trim().StartsWith(cd_grupo.Trim()))
                                p.St_integrar = false;
                        });
                    }
                }
                else
                {
                    (bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).St_integrar = true;
                    if ((bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).St_sinteticobool)
                    {
                        string cd_grupo = (bsGrupoCF.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadGrupoCF).Cd_grupocf;
                        (bsGrupoCF.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF).ForEach(p =>
                            {
                                if (p.Cd_grupocf_pai.Trim().StartsWith(cd_grupo.Trim()))
                                    p.St_integrar = true;
                            });
                    }
                }
                bsGrupoCF.ResetBindings(false);
            }
        }

        private void TFLanCCustoEmpreendimento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCCusto);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar centro de resultados
            bsGrupoCF.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadGrupoCF.Buscar(string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            0,
                                                                                            string.Empty,
                                                                                            null);
        }

        private void gCCusto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.SetarFlagIntegra();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanCCustoEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanCCustoEmpreendimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCCusto);
        }
    }
}
