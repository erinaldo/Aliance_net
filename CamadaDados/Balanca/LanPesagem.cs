using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Balanca
{
    interface IPesagem
    {
        string Cd_empresa
        { get; set; }
        string Nm_empresa
        { get; set; }
        decimal? Id_ticket
        { get; set; }
        string Id_ticketstr
        { get; set; }
        string Tp_pesagem
        { get; set; }
        string Nm_tppesagem
        { get; set; }
        string Tp_modo
        { get; set; }
        decimal? Id_ticketorig
        { get; set; }
        string Id_ticketorigstr
        {
            get;
            set;
        }
        string Tp_movimento
        {
            get;
            set;
        }
        string Tipo_movimento
        {
            get;
            set;
        }
        string Placacarreta
        {
            get;
            set;
        }
        string Placacavalo
        {
            get;
            set;
        }
        DateTime? Dt_bruto
        {
            get;
            set;
        }
        string Dt_brutostring
        {
            get;
            set;
        }
        DateTime? Dt_tara
        {
            get;
            set;
        }
        string Dt_tarastring
        {
            get;
            set;
        }
        TimeSpan? Dt_permanenciaveiculo
        {
            get;
        }
        string Dt_permanenciaveiculostr
        {
            get;
        }
        decimal Ps_bruto
        {
            get;
            set;
        }
        decimal Ps_tara
        {
            get;
            set;
        }
        decimal Ps_liquido
        {
            get;
            set;
        }
        decimal Ps_liquidobruto
        {
            get;
        }
        string Ps_liqSacas
        {
            get;
        }
        string Cd_transp
        {
            get;
            set;
        }
        string Login_pstara
        {
            get;
            set;
        }
        string Login_psbruto
        {
            get;
            set;
        }
        string Cd_tpveiculo
        {
            get;
            set;
        }
        string Ds_tpveiculo
        {
            get;
            set;
        }
        string Nm_motorista
        {
            get;
            set;
        }
        string Cpf_cnpj_mot 
        { get; set; }
        string Tp_captura_bruto
        {
            get;
            set;
        }
        string Tipo_captura_bruto
        {
            get;
            set;
        }
        string Tp_captura_tara
        {
            get;
            set;
        }
        string Tipo_captura_tara
        {
            get;
            set;
        }
        decimal Qtd_embalagem
        {
            get;
            set;
        }
        decimal Ps_embalagem
        { get; set; }
        decimal Ps_totalembalagem
        {
            get;
        }
        string Ds_observacao
        {
            get;
            set;
        }
        string St_registro
        {
            get;
            set;
        }
        string Status
        {
            get;
            set;
        }
        string Tp_transbordo
        {
            get;
            set;
        }
        bool Tp_transbordobool
        {
            get;
            set;
        }
        decimal Ps_transbordo
        { get; set; }
        decimal Ps_saldotransbordo
        {
            get;
        }
        bool St_processarTicketRef
        { get; set; }
        string Ds_motivocancelamento
        { get; set; }
        TList_FotosPesagem lFotosPesagem
        { get; set; }
        TList_FotosPesagem lFotosPesagemExcluir
        { get; set; }
    }
}
