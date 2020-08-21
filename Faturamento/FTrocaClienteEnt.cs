using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFTrocaClienteEnt : Form
    {
        private string pcd_cliforent;
        public string pCd_cliforEnt
        {
            get{ return Cd_cliforent.Text; }
            set { pcd_cliforent = value; }
        }
        private string pnm_cliforent;
        public string pNm_cliforEnt
        {
            get { return nm_cliforEnt.Text; }
            set { pnm_cliforent = value; }
        }
        private string pcd_enderecoent;
        public string pCd_enderecoent
        {
            get { return Cd_enderecoent.Text; }
            set { pcd_enderecoent = value; }
        }
        private string plogradouroent;
        public string pLogradouroent
        {
            get { return logradouroent.Text; }
            set { plogradouroent = value; }
        }
        private string pcomplementoent;
        public string pComplementoent
        {
            get { return complementoent.Text; }
            set { pcomplementoent = value; }
        }
        private string pnumeroent;
        public string pNumeroent
        {
            get { return numeroent.Text; }
            set { pnumeroent = value; }
        }
        private string pbairroent;
        public string pBairroent
        {
            get { return bairroent.Text; }
            set { pbairroent = value; }
        }
        private string pcd_cidadeent;
        public string pCd_cidadeent
        {
            get { return cd_cidadent.Text; }
            set { pcd_cidadeent = value; }
        }
        private string pds_cidadeent;
        public string pDs_cidadeent
        {
            get { return ds_cidadeent.Text; }
            set { pds_cidadeent = value; }
        }
        private string puf_ent;
        public string pUf_ent
        {
            get { return uf_ent.Text; }
            set { puf_ent = value; }
        }
        private string pcd_ufent;
        public string pCd_ufent
        {
            get { return Cd_ufent.Text; }
            set { pcd_ufent = value; }
        }
        private string pcondFiscalent;
        public string pCondFiscalent
        {
            get { return Cd_CondFiscal_Clifor.Text; }
            set { pcondFiscalent = value; }
        }
        private string ptp_pessoaent;
        public string pTp_pessoaent
        {
            get { return Tp_pessoaent.Text; }
            set { ptp_pessoaent = value; }
        }

        public TFTrocaClienteEnt()
        {
            InitializeComponent();
        }

        private void Busca_Endereco_Clifor()
        {
            if (Cd_cliforent.Text != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_cliforent.Text,
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

                if (List_Endereco.Count > 0)
                {
                    Cd_enderecoent.Text = List_Endereco[0].Cd_endereco.Trim();
                    logradouroent.Text = List_Endereco[0].Ds_endereco.Trim();
                    numeroent.Text = List_Endereco[0].Numero;
                    complementoent.Text = List_Endereco[0].Ds_complemento;
                    bairroent.Text = List_Endereco[0].Bairro;
                    cd_cidadent.Text = List_Endereco[0].Cd_cidade;
                    ds_cidadeent.Text = List_Endereco[0].DS_Cidade.Trim();
                    uf_ent.Text = List_Endereco[0].UF.Trim();
                    Cd_ufent.Text = List_Endereco[0].Cd_uf;
                }
            }
        }

        private void afterGrava()
        {
            if (pEntrega.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void Cd_cliforent_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + Cd_cliforent.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt, Tp_pessoaent, Cd_CondFiscal_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            Busca_Endereco_Clifor();
        }

        private void bb_cliforEnt_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt, Tp_pessoaent, Cd_CondFiscal_Clifor }, string.Empty);
            Busca_Endereco_Clifor();
        }

        private void Cd_enderecoent_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + Cd_enderecoent.Text + "';a.cd_clifor|=|'" + Cd_cliforent.Text + "'"
                                                        , new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent, Cd_ufent },
                                                          new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent, Cd_ufent },
                    "a.cd_clifor|=|'" + Cd_cliforent.Text + "'");
        }

        private void cd_cidadent_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadent.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|60;" +
                              "b.uf|UF|30";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFTrocaClienteEnt_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pEntrega.set_FormatZero();
            Cd_cliforent.Text = pcd_cliforent;
            nm_cliforEnt.Text = pnm_cliforent;
            Cd_CondFiscal_Clifor.Text = pcondFiscalent;
            Tp_pessoaent.Text = ptp_pessoaent;
            Cd_enderecoent.Text = pcd_enderecoent;
            logradouroent.Text = plogradouroent;
            numeroent.Text = pnumeroent;
            complementoent.Text = pcomplementoent;
            bairroent.Text = pbairroent;
            cd_cidadent.Text = pcd_cidadeent;
            ds_cidadeent.Text = pds_cidadeent;
            uf_ent.Text = puf_ent;
            Cd_ufent.Text = pcd_ufent;
        }
    }
}
