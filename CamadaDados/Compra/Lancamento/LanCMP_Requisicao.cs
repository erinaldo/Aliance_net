using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Querys;
using Utils;
using System.Data.SqlClient;
using CamadaDados.Compra.Lancamento;
using CamadaDados.Almoxarifado;

namespace CamadaDados.Compra.Lancamento
{
    public class TRegistro_Requisicao
    {
        public decimal? Id_requisicao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private DateTime? dt_requisicao;
        public DateTime? Dt_requisicao
        {
            get { return dt_requisicao; }
            set
            {
                dt_requisicao = value;
                dt_requisicaostr = value.Value.ToString("dd/MM/yyyy");
            }
        }
        private string dt_requisicaostr;
        public string Dt_requisicaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_requisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_requisicaostr = value;
                try
                {
                    dt_requisicao = Convert.ToDateTime(value);
                }
                catch
                { dt_requisicao = null; }
            }
        }
    }
}
