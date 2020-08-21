using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Mudanca
{
    public partial class TFGuardaVolume : Form
    {
        private CamadaDados.Mudanca.TRegistro_GuardaVolume rguardavol;
        public CamadaDados.Mudanca.TRegistro_GuardaVolume rGuardaVol
        {
            get
            {
                if (bsGuardaVolume.Current != null)
                    return bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume;
                else
                    return null;
            }
            set { rguardavol = value; }
        }
        public TFGuardaVolume()
        {
            InitializeComponent();
        }

        private void Busca_Endereco_Clifor()
        {
            if (CD_Clifor.Text != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(CD_Endereco.Text))
                    {
                        CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                    }
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirItensGuardaVol()
        {
            using (TFItensGuardaVol fItensGuarda = new TFItensGuardaVol())
            {
                if (fItensGuarda.ShowDialog() == DialogResult.OK)
                    if (fItensGuarda.lItens.Count > 0)
                    {
                        fItensGuarda.lItens.ForEach(p =>
                        {
                            (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.Add(
                                new CamadaDados.Mudanca.TRegistro_ItensGuardaVolume()
                                {
                                    Id_item = p.Id_item,
                                    Ds_item = p.Ds_item,
                                    Quantidade = p.Quantidade,
                                    Ds_observacao = p.Ds_observacao
                                });
                        });
                        bsGuardaVolume.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirItensGuardaVol()
        {
            if (bsItensGuardaVolume.Current != null)
            {
                if ((bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).QTD_RETIRADA > 0)
                {
                    MessageBox.Show("Não é possivel excluir itens com QTD.Retirada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolumeDel.Add(bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume);
                    bsItensGuardaVolume.RemoveCurrent();
                }
            }
        }

        private void TFGuardaVolume_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rguardavol != null)
            {
                bsGuardaVolume.DataSource = new CamadaDados.Mudanca.TList_GuardaVolume() { rguardavol };
                cd_empresa.Enabled = false;
            }
            else
                bsGuardaVolume.AddNew();
        }

        private void bb_inserirItens_Click(object sender, EventArgs e)
        {
            this.InserirItensGuardaVol();
        }

        private void bb_excluirItens_Click(object sender, EventArgs e)
        {
            this.ExcluirItensGuardaVol();
        }

        private void TFGuardaVolume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItensGuardaVol();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItensGuardaVol();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                  new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {

            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            this.Busca_Endereco_Clifor();
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco },
                   new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                 "a.cd_endereco|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco },
                 new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
        }

        private void Id_mudanca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_mudanca|=|'" + Id_mudanca.Text.Trim() + "';" +
                            "a.st_registro|<>|'3';" +
                            "|not exists|(select 1 from tb_mud_guardavolume x " +
                            "               where x.cd_empresa = a.cd_empresa " +
                            "               and x.id_mudanca = a.id_mudanca)";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_mudanca, DS_CIDADE_ORIG, DS_CIDADE_DEST, ds_veiculo, placa, nm_motorista },
                   new CamadaDados.Mudanca.TCD_LanMudanca());
            //Buscar Itens Mudança
            if (!string.IsNullOrEmpty(Id_mudanca.Text))
            {
                CamadaNegocio.Mudanca.TCN_LanItensMud.Buscar(cd_empresa.Text, Id_mudanca.Text, string.Empty, null).ForEach(p =>
                    (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.Add(
                    new CamadaDados.Mudanca.TRegistro_ItensGuardaVolume()
                    {
                        Id_item = p.Id_item,
                        Dt_locacao = dt_registro.Data,
                        Quantidade = p.Quantidade,
                        St_registro = "A"
                    }));
                bsGuardaVolume.ResetCurrentItem();
            }
        }

        private void bb_mudanca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CIDADE_ORIG|Origem|200;" +
                                "a.DS_CIDADE_DEST|Destino|200;" +
                                 "a.id_mudanca|Codigo|80;" +
                                 "a.ds_veiculo|Veiculo|80;" +
                                 "a.placa|Placa|50;" +
                                 "a.nm_motorista|Motorista|150";
            string vParam = "a.st_registro|<>|'3';" +
                            "|not exists|(select 1 from tb_mud_guardavolume x " +
                            "               where x.cd_empresa = a.cd_empresa " +
                            "               and x.id_mudanca = a.id_mudanca)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_mudanca, DS_CIDADE_ORIG, DS_CIDADE_DEST, ds_veiculo, placa, nm_motorista },
                 new CamadaDados.Mudanca.TCD_LanMudanca(), vParam);
            //Buscar Itens Mudança
            if (!string.IsNullOrEmpty(Id_mudanca.Text))
            {
                CamadaNegocio.Mudanca.TCN_LanItensMud.Buscar(cd_empresa.Text, Id_mudanca.Text, string.Empty, null).ForEach(p =>
                    (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.Add(
                    new CamadaDados.Mudanca.TRegistro_ItensGuardaVolume()
                    {
                        Id_item = p.Id_item,
                        Dt_locacao = dt_registro.Data,
                        Quantidade = p.Quantidade,
                        St_registro = "A"
                    }));
                bsGuardaVolume.ResetCurrentItem();
            }
        }

        private void bb_cadClifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        CD_Clifor.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dt_registro_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Id_mudanca.Text))
            {
                (bsGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_GuardaVolume).lItensGuardaVolume.ForEach(p => p.Dt_locacao = dt_registro.Data);
                bsGuardaVolume.ResetCurrentItem();
            }
        }
    }
}
