using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Utils;
using CamadaDados.Balanca.Cadastros;

namespace CamadaNegocio.Balanca.Cadastros
{
    public class TCN_CadTransp_X_Veiculo
    {
        public static TList_CadTransp_X_Veiculo Busca( string vCD_Transp,
                                                string vNr_Veiculo,
                                                string vPlaca,
                                                string vCD_TpVeiculo,
                                                string vDS_TpVeiculo,
                                                string vNM_Clifor)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vCD_Transp.Trim() != "") && (vCD_Transp.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Transp";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Transp + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vNr_Veiculo.Trim() != "") && (vNr_Veiculo.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Veiculo";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_Veiculo + "'";
                filtro[filtro.Length - 1].vOperador = "Like";
            }

            if (vPlaca.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Placa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vPlaca + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }


           

            if ((vCD_TpVeiculo.Trim() != "") && (vCD_TpVeiculo.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_TpVeiculo";
                filtro[filtro.Length - 1].vVL_Busca = vCD_TpVeiculo;
                filtro[filtro.Length - 1].vOperador = "=";
            }


            if (vDS_TpVeiculo.Trim() != "") 
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.DS_TpVeiculo";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDS_TpVeiculo + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vNM_Clifor.Trim() != "") 
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.NM_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNM_Clifor + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }


            TCD_CadTransp_X_Veiculo id = new TCD_CadTransp_X_Veiculo();
            return id.Select(filtro, 0, "");

        }


        public static string GravaTransp_X_Veiculo(TRegistro_CadTransp_X_Veiculo val)
        {
            TCD_CadTransp_X_Veiculo id = new TCD_CadTransp_X_Veiculo();
            return id.Grava(val);

        }
        
        public static string DeletaTransp_X_Veiculo(TRegistro_CadTransp_X_Veiculo val)
        {
            TCD_CadTransp_X_Veiculo id = new TCD_CadTransp_X_Veiculo();
            return id.Deleta(val); 
        }

    }
}
