using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadRegiaoVenda : FormPadrao.FFormPadrao
    {
        public TFCadRegiaoVenda()
        {
            InitializeComponent();
            DTS = BS_RegiaoVenda;
        }

        public override void formatZero()
        {
            pDadosRegiaoVenda.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDadosRegiaoVenda.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadRegiaoVenda.GravaRegiaoVenda(BS_RegiaoVenda.Current as TRegistro_CadRegiaoVenda);
            else
                return "";                             
        }

        public override int buscarRegistros()
        {
            TList_CadRegiaoVenda lista = TCN_CadRegiaoVenda.Busca(ID_Regiao.Text.Trim() != "" ? Convert.ToDecimal(ID_Regiao.Text) : 0,
                                                                  NM_Regiao.Text.Trim());

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_RegiaoVenda.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_RegiaoVenda.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_RegiaoVenda.AddNew();
                base.afterNovo();
                if(!ID_Regiao.Focus())
                    NM_Regiao.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_RegiaoVenda.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!ID_Regiao.Focus())
                    NM_Regiao.Focus();
            } 
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadRegiaoVenda.DeletaRegiaoVenda(BS_RegiaoVenda.Current as TRegistro_CadRegiaoVenda);
                    BS_RegiaoVenda.RemoveCurrent();
                    pDados.LimparRegistro();
           
                }
            }
        }

        private void TFCadRegiaoVenda_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}

