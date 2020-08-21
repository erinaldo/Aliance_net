using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CamadaDados.Restaurante.Integracao.Torneiras;
using System.Data.SQLite;

namespace ServiceRest
{

    public class TCD_TapTransactions
    {
        public TCD_TapTransactions() { }

        private string SqlCodeBusca(string NrCartao, int vTop, string vNM_Campo, string order)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.card_id, a.card_type, a.tst_start, a.tst_stop, ");
                sql.AppendLine("a.plu, a.money_amount, a.volume_amount, a.volume_amount_dp, a.servings, a.external_id, a.integrado, ");
                sql.AppendLine("b.card_number, c.cd_produto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from taptransactions a ");
            sql.AppendLine("inner join card_numbers_id b ");
            sql.AppendLine("on a.card_id = b.card_id ");
            sql.AppendLine("inner join torneira c ");
            sql.AppendLine("on a.plu = c.plu ");

            sql.AppendLine("where a.integrado is null ");
            sql.AppendLine("and a.volume_amount > 0 ");
            sql.AppendLine("and cast(b.card_number as integer) = " + NrCartao);

            if (!string.IsNullOrEmpty(order))
                sql.AppendLine("order by " + order);

            return sql.ToString();
        }

        public List<TRegistro_TapTransactions> Buscar(string DataSource, string NrCartao, Int32 vTop, string vNM_Campo, string order)
        {
            List<TRegistro_TapTransactions> _TapTransactions = new List<TRegistro_TapTransactions>();
            SQLiteConnection sQLite = new SQLiteConnection(@"Data Source =" + DataSource);
            SQLiteCommand qLiteCommand = new SQLiteCommand();
            qLiteCommand.CommandType = CommandType.Text;
            qLiteCommand.CommandText = SqlCodeBusca(NrCartao, vTop, vNM_Campo, order);
            qLiteCommand.Connection = sQLite;
            try
            {
                sQLite.Open();
                SQLiteDataReader reader = qLiteCommand.ExecuteReader();

                while (reader.Read())
                {
                    TRegistro_TapTransactions _TapTransaction = new TRegistro_TapTransactions();
                    if (!reader.IsDBNull(reader.GetOrdinal("card_id")))
                        _TapTransaction.cardId = reader.GetDecimal(reader.GetOrdinal("card_id"));

                    if (!reader.IsDBNull(reader.GetOrdinal("card_type")))
                        _TapTransaction.cardType = reader.GetDecimal(reader.GetOrdinal("card_type"));

                    if (!reader.IsDBNull(reader.GetOrdinal("tst_start")))
                        _TapTransaction.tstStart = reader.GetDecimal(reader.GetOrdinal("tst_start"));

                    if (!reader.IsDBNull(reader.GetOrdinal("tst_stop")))
                        _TapTransaction.tstStop = reader.GetDecimal(reader.GetOrdinal("tst_stop"));

                    if (!reader.IsDBNull(reader.GetOrdinal("plu")))
                        _TapTransaction.plu = reader.GetDecimal(reader.GetOrdinal("plu"));

                    if (!reader.IsDBNull(reader.GetOrdinal("money_amount")))
                        _TapTransaction.moneyAmount = reader.GetDecimal(reader.GetOrdinal("money_amount"));

                    if (!reader.IsDBNull(reader.GetOrdinal("volume_amount")))
                        _TapTransaction.volumeAmount = reader.GetDecimal(reader.GetOrdinal("volume_amount"));

                    if (!reader.IsDBNull(reader.GetOrdinal("volume_amount_dp")))
                        _TapTransaction.volumeAmountDp = reader.GetDecimal(reader.GetOrdinal("volume_amount_dp"));

                    if (!reader.IsDBNull(reader.GetOrdinal("servings")))
                        _TapTransaction.servings = reader.GetDecimal(reader.GetOrdinal("servings"));

                    if (!reader.IsDBNull(reader.GetOrdinal("external_id")))
                        _TapTransaction.externalId = reader.GetString(reader.GetOrdinal("external_id"));

                    if (!reader.IsDBNull(reader.GetOrdinal("integrado")))
                        _TapTransaction.Integrado = reader.GetString(reader.GetOrdinal("integrado"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        _TapTransaction.cdProduto = reader.GetString(reader.GetOrdinal("CD_Produto"));

                    _TapTransactions.Add(_TapTransaction);
                }

                return _TapTransactions;
            }
            catch(Exception ex)
            { throw new Exception(ex.Message); }
            finally
            {
                if (sQLite.State == ConnectionState.Open)
                    sQLite.Close();
            }
        }

        public string Update(TRegistro_TapTransactions _TapTransactions, string DataSource)
        {
            SQLiteConnection sQLite = new SQLiteConnection(@"Data Source =" + DataSource);
            StringBuilder update = new StringBuilder();
            SQLiteCommand qLiteCommand = new SQLiteCommand();
            update.AppendLine("update taptransactions ");
            update.AppendLine("set integrado = :integrado ");
            update.AppendLine("where card_id = :card_id ");
            update.AppendLine("and tst_start = :tst_start");
            update.AppendLine("and plu = :plu");

            qLiteCommand.Parameters.Add("integrado", DbType.String).Value = "'S'";
            qLiteCommand.Parameters.Add("card_id", DbType.Int64).Value = _TapTransactions.cardId;
            qLiteCommand.Parameters.Add("tst_start", DbType.Int64).Value = _TapTransactions.tstStart;
            qLiteCommand.Parameters.Add("plu", DbType.Int64).Value = _TapTransactions.plu;

            qLiteCommand.CommandType = CommandType.Text;
            qLiteCommand.CommandText = update.ToString();
            qLiteCommand.Connection = sQLite;
            try
            {
                sQLite.Open();
                qLiteCommand.ExecuteNonQuery();
                return string.Empty;
            }
            catch (Exception ex) { return ex.ToString(); }
            finally
            {
                if (sQLite.State == ConnectionState.Open)
                    sQLite.Close();
            }
        }
    }
}
