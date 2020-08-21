using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Diversos;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadRota : FormCadPadrao.FFormCadPadrao
    {
        public TFCadRota()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    bb_inserirClifor.Enabled = false;
                    bb_excluirClifor.Enabled = false;
                    return TCN_CadRota.Gravar(bsRota.Current as TRegistro_CadRota, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bb_inserirClifor.Enabled = true;
                    bb_excluirClifor.Enabled = true;
                    return string.Empty;
                }
            else
            {
                bb_inserirClifor.Enabled = true;
                bb_excluirClifor.Enabled = true;
                return string.Empty;
            }
        }

        public override int buscarRegistros()
        {
            TList_CadRota lista = TCN_CadRota.Busca(id_rota.Text, ds_rota.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    Lista = lista;
                    bsRota.DataSource = lista;
                    bsRota_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                    bsRota.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_inserirClifor.Enabled = true;
                bb_excluirClifor.Enabled = true;
                ds_rota.Focus();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsRota.AddNew();
            base.afterNovo();
            bb_inserirClifor.Enabled = true;
            bb_excluirClifor.Enabled = true;
            id_rota.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                bb_inserirClifor.Enabled = false;
                bb_excluirClifor.Enabled = false;
                bsRota.RemoveCurrent();
            }
        }

        public override void excluirRegistro()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
                {
                    TCN_CadRota.Excluir(bsRota.Current as TRegistro_CadRota, null);
                    bsRota.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_inserirClifor_Click(object sender, EventArgs e)
        {
            if (bsRota.Current != null)
            {
                //Retirar da busca clientes informados memória ainda não gravados
                string and = string.Empty;
                (bsRota.Current as TRegistro_CadRota).lClifor.ForEach(p =>
                    and += ";a.cd_clifor|<>|'" + p.Cd_clifor.Trim() + "'");
                //Buscar somente clifor que não possui rota
                string vParam = "a.id_rota|is|null" + and;
                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, vParam);
                if (linha != null)
                {
                    (bsRota.Current as TRegistro_CadRota).lClifor.Add(new TRegistro_CadClifor()
                    {
                        Cd_clifor = linha["cd_clifor"].ToString(),
                        Nm_clifor = linha["nm_clifor"].ToString()
                    });
                    bsRota.ResetCurrentItem();
                }
            }
        }

        private void bb_excluirClifor_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                if (MessageBox.Show("Confirma a exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsRota.Current as TRegistro_CadRota).lCliforDel.Add(bsClifor.Current as TRegistro_CadClifor);
                    bsClifor.RemoveCurrent();
                    bsRota.ResetCurrentItem();
                }
            }
        }

        private void bsRota_PositionChanged(object sender, EventArgs e)
        {
            if (bsRota.Current == null ? false : !string.IsNullOrEmpty((bsRota.Current as TRegistro_CadRota).ID_rotaString))
            {
                (bsRota.Current as TRegistro_CadRota).lClifor =
                    new TCD_CadClifor().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_rota",
                                vOperador = "=",
                                vVL_Busca = (bsRota.Current as TRegistro_CadRota).ID_rotaString
                            }
                        }, 0, string.Empty);
                bsRota.ResetCurrentItem();
            }
        }
    }
}
