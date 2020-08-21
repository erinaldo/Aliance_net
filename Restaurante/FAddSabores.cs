using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;

namespace Restaurante
{
    public partial class TFAddSabores : Form
    {
        private decimal? qtd_selected { get; set; } = decimal.Zero;
        public decimal? qtd_agregar { get; set; } = null;
        public CamadaDados.Restaurante.TList_SaboresItens lSabores { get; set; } = new CamadaDados.Restaurante.TList_SaboresItens();
        private TList_CFG lcfg = new TList_CFG();
        public string vCd_Grupo { get; set; } = string.Empty;

        public TFAddSabores()
        {
            InitializeComponent();
        }

        private void FAddSabores_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            bsSabores.DataSource = CamadaNegocio.Restaurante.Cadastro.TCN_Sabores.Buscar(string.Empty, string.Empty,vCd_Grupo, null).OrderBy(p => p.DS_Sabor);
            bsSabores.ResetCurrentItem();
            qtd_selected = qtd_agregar.Value;
            lbl_total.Text = "Selecione: " + qtd_agregar + " Sabores";
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void afterGravar()
        { 
                lSabores.Clear();
                (bsSabores.List as IEnumerable<TRegistro_Sabores>).ToList().ForEach(p =>
                {
                    if (p.st_agregar)
                        lSabores.Add(new CamadaDados.Restaurante.TRegistro_SaboresItens()
                        {
                            DS_Sabor = p.DS_Sabor,
                            ID_Sabor = p.ID_Sabor
                        });
                });
                if(lSabores.Count <= 0) 
                    MessageBox.Show("Não existe Sabores selecionados!", "Mensagem", MessageBoxButtons.OK
                           , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                else if (lSabores.Count <= qtd_agregar)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Ops, possui muitos sabores, só pode selecionar " + qtd_agregar + " Sabores!", "Mensagem", MessageBoxButtons.OK
                           , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            

        }
        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGravar();
        }

        private void FAddSabores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                afterGravar();
            }
            else if (e.KeyCode.Equals(Keys.F6) || e.KeyCode.Equals(Keys.Escape))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void gAssistente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                 
                if ((bsSabores.Current as TRegistro_Sabores).st_agregar )
                    qtd_selected++;
                //else if(decimal.Zero < qtd_selected)
                //    qtd_selected--;

                if (decimal.Zero < qtd_selected )
                {
                    if (!(bsSabores.Current as TRegistro_Sabores).st_agregar)
                        qtd_selected--;
                    (bsSabores.Current as TRegistro_Sabores).st_agregar =
                        !(bsSabores.Current as TRegistro_Sabores).st_agregar;
                    bsSabores.ResetCurrentItem();
                }
                else
                {
                    MessageBox.Show("Ops, possui muitos sabores, só pode selecionar " + qtd_agregar + " Sabores!", "Mensagem", MessageBoxButtons.OK
                           , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }

                lbl_total.Text = "Selecione: " + qtd_selected + " Sabores";
            }
        }
    }
}
