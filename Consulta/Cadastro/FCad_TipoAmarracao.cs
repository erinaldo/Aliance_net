using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Diversos;
using System.Collections;



namespace Consulta.Cadastro
{
    public partial class TFCad_TipoAmarracao : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TipoAmarracao()
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
     
        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                
                Bs_amaracao.AddNew();
                base.afterNovo();
                //Sigla_amarracao.Enabled = true;
                //NM_amarracao.Enabled = true;

                id_amarracao.Focus();


                TCD_CadParamSys qtbParam = new TCD_CadParamSys();


                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Campo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'ID_TIPO_AMARRACAO'";

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
                    id_amarracao.Enabled = false;
                    id_amarracao.ST_PrimaryKey = false;
                    id_amarracao.ST_NotNull = false;
                    NM_amarracao.Focus();
                }
                else {
                    id_amarracao.Enabled = true;
                    id_amarracao.ST_PrimaryKey = true;
                    id_amarracao.ST_NotNull = true;
                }
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                Bs_amaracao.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                Sigla_amarracao.Focus();
                id_amarracao.Enabled = false;
                Sigla_amarracao.Enabled = true;
                NM_amarracao.Enabled = true;
            }
        }

        public override void excluirRegistro()
        {
            if (Bs_amaracao.DataSource != null)
            {
                try
                {
                    if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    {
                        if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            TCN_Cad_TipoAmarracao.DeletarTipo_Amarracao(Bs_amaracao.Current as TRegistro_Cad_TipoAmarracao,null);
                            Bs_amaracao.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Não existem itens cadastrados", "Mensagem");
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                
                return TCN_Cad_TipoAmarracao.GravarTipo_Amarracao(Bs_amaracao.Current as TRegistro_Cad_TipoAmarracao, null);
            }
            else
            {
                return "";
            }
            
        }

        public override int buscarRegistros()
        {
            TList_Cad_TipoAmarracao lista = TCN_Cad_TipoAmarracao.Buscar(id_amarracao.Text, NM_amarracao.Text, Sigla_amarracao.Text,"",0,null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_amaracao.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_amaracao.Clear();
                return lista.Count;
            }
            else return 0;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TFCad_TipoAmarracao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

         
         
    }
}
