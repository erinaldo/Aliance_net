using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FormBusca;
using System.Windows.Forms;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using Querys;
using Querys.Diversos;
using Querys.Financeiro;
using Querys.Faturamento;
using Querys.Fiscal;
using Querys.Graos;
using Querys.Estoque;


namespace Faturamento
{
    public partial class FLan_ContratoGraos : Form
    {
        public FLan_ContratoGraos()
        {
            InitializeComponent();
        }

        private void CD_CliforEntrega_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Clifor|=|'" + CD_CliforEntrega.Text + "'"
                , new Componentes.EditDefault[] { CD_CliforEntrega, NM_CliforEntrega }, new TDatClifor());
           
        }

        private void BB_CliforEntrega_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_Clifor|Nome Clifor|300;a.CD_clifor|Codigo Clifor|90"
                            , new Componentes.EditDefault[] { CD_CliforEntrega, NM_CliforEntrega }, new TDatClifor(), null);            

        }

        private void CD_EnderecoEntrega_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Clifor|=|'" + CD_CliforEntrega.Text + "';a.CD_Endereco|=|'" + CD_EnderecoEntrega.Text + "'"
            , new Componentes.EditDefault[] { CD_EnderecoEntrega, DS_EnderecoEntrega }, new TDatEndereco());

        }

        private void BB_EnderecoEntrega_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.CD_Endereco|Código Endereço|90;a.DS_Endereco|Endereço|300;b.DS_Cidade|Cidade|150;c.DS_UF|Estado|150"
                            , new Componentes.EditDefault[] { CD_EnderecoEntrega, DS_EnderecoEntrega }, new TDatEndereco(),
                            "a.CD_clifor|=|'" + CD_CliforEntrega.Text + "'"); 

        }

        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_TabelaDesconto|=|'" + CD_TabelaDesconto.Text + "'"
                , new Componentes.EditDefault[] { CD_TabelaDesconto, NM_TabelaDesconto }, new TDatTabelaDesconto());

        }

        private void BB_TabelaDesconto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_TabelaDesconto|Tabela Classificação|300;CD_TabelaDesconto|Cd. TabDesconto|80"
                            , new Componentes.EditDefault[] { CD_TabelaDesconto, NM_TabelaDesconto }, new TDatTabelaDesconto(),
                            null); 

        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("AnoSafra|=|'" + AnoSafra.Text + "'"
                , new Componentes.EditDefault[] { AnoSafra, DS_AnoSafra }, new TDatSafra());

        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Safra|Ano Safra|300;anosafra|Cd. AnoSafra|80"
                            , new Componentes.EditDefault[] { AnoSafra, DS_AnoSafra }, new TDatSafra(),
                            null); 

        }

        private void FLan_ContratoGraos_Load(object sender, EventArgs e)
        {
            ArrayList CBox4 = new ArrayList();
            CBox4.Add(new Utils.TDataCombo("ORIGEM", "O"));
            CBox4.Add(new Utils.TDataCombo("DESTINO", "D"));
            Tp_Natureza.DataSource = CBox4;
            Tp_Natureza.DisplayMember = "Display";
            Tp_Natureza.ValueMember = "Value";

        }
    }
}
