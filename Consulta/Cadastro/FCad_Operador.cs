using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using Utils;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;


namespace Consulta.Cadastro
{
    public partial class TFCad_Operador : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Operador()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_Operador.GravaOperador(BS_Operador.Current as TRegistro_Cad_Operador);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_Cad_Operador lista = TCN_Cad_Operador.Busca((ID_Operador.Text.Trim() != "") ? Convert.ToDecimal(ID_Operador.Text) : 0,
                                                    NM_Operador.Text.Trim(),
                                                    Sigla_Operador.Text.Trim());

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Operador.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Operador.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_Operador.AddNew();
                base.afterNovo();
                if (!ID_Operador.Focus())
                    ID_Operador.Focus();
            }

            TCD_CadParamSys qtbParam = new TCD_CadParamSys();
            

            TpBusca[] vBusca = new TpBusca[0];
            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Campo";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "'ID_OPERADOR'";

            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Auto";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "1";

            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.Tamanho";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "5";

            TList_CadParamSys busca = qtbParam.Select(vBusca, 0, "");

            if ((busca != null) && (busca.Count > 0))
            {
                ID_Operador.ST_PrimaryKey = false;
                ID_Operador.ST_NotNull = false;

                NM_Operador.Focus();
                ID_Operador.Enabled = false;
            }
            else {
                ID_Operador.ST_PrimaryKey = true;
                ID_Operador.ST_NotNull = true;
                ID_Operador.Enabled = true;
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_Operador.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                ID_Operador.Enabled = false;
                NM_Operador.Focus();
            }
        }

        public override void excluirRegistro()
        {
            if (grid_Operador.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Cad_Operador.DeletaOperador(BS_Operador.Current as TRegistro_Cad_Operador);
                        BS_Operador.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BS_Operador_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void TFCad_Operador_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
