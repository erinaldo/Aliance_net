using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota;
using CamadaNegocio.Frota;

namespace Proc_Commoditties
{
    public partial class TFEncMDFe : Form
    {
        public CamadaDados.Frota.Cadastros.TRegistro_CfgMDFe rCfgMdfe
        { get; set; }
        public List<CamadaDados.Frota.TRegistro_MDFe> lMDFe
        { get; set; }

        public TFEncMDFe()
        {
            InitializeComponent();
        }

        private void EncerrarMDFe()
        {
            if (bsMDFe.Current != null)
            {
                //Cancelar CTe
                if (MessageBox.Show("Confirma encerramento MDFe?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    if ((bsMDFe.Current as TRegistro_MDFe).Id_mdfe.HasValue)//MDF-e existe no sistema
                    {
                        CamadaDados.Frota.TList_MDFe_Evento lEvento =
                        CamadaNegocio.Frota.TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                   (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                   "EC",
                                                                   string.Empty,
                                                                   null);
                        if (lEvento.Count.Equals(0))
                        {
                            string vColunas = "a.ds_cidade|Cidade|200;a.uf|UF|30;a.cd_cidade|Código|60;a.cd_uf|Cd. UF|60";
                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
                            if (linha == null)
                            {
                                MessageBox.Show("Obrigótio selecinar cidade de encerramento do MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Buscar evento Encerramento
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                                CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "EC", null);
                            if (lEv.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe evento de ENCERRAMENTO MDFe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Encerrar MDFe Receita
                            TRegistro_MDFe_Evento rEvento = new TRegistro_MDFe_Evento();
                            rEvento.Cd_empresa = (bsMDFe.Current as TRegistro_MDFe).Cd_empresa;
                            rEvento.Id_mdfe = (bsMDFe.Current as TRegistro_MDFe).Id_mdfe;
                            rEvento.Chaveacesso = (bsMDFe.Current as TRegistro_MDFe).Chaveacesso;
                            rEvento.Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                            rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                            rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                            rEvento.Ds_evento = lEv[0].Ds_evento;
                            rEvento.Tp_evento = lEv[0].Tp_evento;
                            rEvento.Cd_cidadeEnc = linha["cd_cidade"].ToString();
                            rEvento.Ds_cidadeEnc = linha["ds_cidade"].ToString();
                            rEvento.Cd_ufEnc = linha["cd_uf"].ToString();
                            rEvento.Uf_enc = linha["uf"].ToString();
                            rEvento.St_registro = "A";
                            CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                            if (MessageBox.Show("Evento de ENCERRAMENTO gravado com sucesso.\r\n" +
                                                "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                            {
                                string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(rEvento, rCfgMdfe);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                                    "Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim() + "\r\n" +
                                                    "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                {
                                    bsMDFe.RemoveCurrent();
                                    MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TCN_MDFe.Encerrar(bsMDFe.Current as TRegistro_MDFe, null);
                                    MessageBox.Show("MDFe encerrado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            lEvento[0].Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                            string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(lEvento[0], rCfgMdfe);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                                "Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim() + "\r\n" +
                                                "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                bsMDFe.RemoveCurrent();
                                MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CamadaNegocio.Frota.TCN_MDFe.Encerrar(bsMDFe.Current as TRegistro_MDFe, null);
                                MessageBox.Show("MDFe encerrado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else //MDF-e não existe no sistema, encerrar somente na receita
                    {
                        string vColunas = "a.ds_cidade|Cidade|200;a.uf|UF|30;a.cd_cidade|Código|60;a.cd_uf|Cd. UF|60";
                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
                        if (linha == null)
                        {
                            MessageBox.Show("Obrigótio selecinar cidade de encerramento do MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Buscar evento Encerramento
                        CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                            CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "EC", null);
                        if (lEv.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe evento de ENCERRAMENTO MDFe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Encerrar MDFe Receita
                        TRegistro_MDFe_Evento rEvento = new TRegistro_MDFe_Evento();
                        rEvento.Cd_empresa = rCfgMdfe.Cd_empresa;
                        rEvento.Chaveacesso = (bsMDFe.Current as TRegistro_MDFe).Chaveacesso;
                        rEvento.Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                        rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                        rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                        rEvento.Ds_evento = lEv[0].Ds_evento;
                        rEvento.Tp_evento = lEv[0].Tp_evento;
                        rEvento.Cd_cidadeEnc = linha["cd_cidade"].ToString();
                        rEvento.Ds_cidadeEnc = linha["ds_cidade"].ToString();
                        rEvento.Cd_ufEnc = linha["cd_uf"].ToString();
                        rEvento.Uf_enc = linha["uf"].ToString();
                        rEvento.St_registro = "A";
                        string msg = MDFe.Evento.TEventoMDFe.EnviarEncerramento(rEvento, rCfgMdfe);
                        if (!string.IsNullOrEmpty(msg))
                            MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                            "Aguarde um tempo e tente novamente.\r\n" +
                                            "Erro: " + msg.Trim() + "\r\n" +
                                            "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            bsMDFe.RemoveCurrent();
                            MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void TFEncMDFe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsMDFe.DataSource = lMDFe;
        }

        private void bbEncerrar_Click(object sender, EventArgs e)
        {
            this.EncerrarMDFe();
        }

        private void TFEncMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.EncerrarMDFe();
        }
    }
}
