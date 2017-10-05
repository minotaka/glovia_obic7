using glovia_obic7.Resources;
using System;
using System.Data;
using System.Data.SQLite;

namespace glovia_obic7.Infrastructure
{
    class SqliteContext : BaseLogger, IDisposable
    {
        protected SQLiteConnection connection = null;
        protected SQLiteCommand command = null;
        protected SQLiteTransaction transaction = null;

        public SqliteContext(string connectionString)
        {
            Connect(connectionString);
        }

        #region 接続/切断
        protected bool Connect(string connectionString)
        {
            try
            {
                if ((connection = new SQLiteConnection(connectionString)) == null)
                {
                    throw new SQLiteException(SqliteResource.ConnectionFail);
                }
                if ((command = this.connection.CreateCommand()) == null)
                {
                    throw new SQLiteException(SqliteResource.CreateCommandFail);
                }
                connection.Open();
                SystemLogger.Info(LogMessage.SYS_SQL_CONNECT);
                return true;
            }
            catch
            {
                throw new SQLiteException(SqliteResource.ConnectionException);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
                SystemLogger.Info(LogMessage.SYS_SQL_DISCONNECT);
            }
            catch
            {
                throw new SQLiteException(SqliteResource.DisconnectionException);
            }
        }
        #endregion

        #region SQL実行
        private DbType getDbType(object parameter)
        {
            if (parameter is int)
            {
                return DbType.Int32;
            }
            else if (parameter is string)
            {
                return DbType.String;
            }
            else if (parameter is float || parameter is double)
            {
                return DbType.Double;
            }
            else
            {
                throw new ArgumentException(SqliteResource.DbtypeException);
            }
        }

        private void setParameter(string sql, object[] arg)
        {
            command.CommandText = sql;
            command.Parameters.Clear();
            for (int i = 0; i < arg.Length; i++)
            {
                SQLiteParameter parameter = this.command.CreateParameter();
                parameter.DbType = getDbType(arg[i]);
                parameter.Value = arg[i];
                command.Parameters.Add(parameter);
            }
            this.command.Prepare();
        }

        public void ExecuteCommand(string sql, params object[] arg)
        {
            try
            {
                SystemLogger.Debug(sql);
                setParameter(sql, arg);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new SQLiteException(ex.ToString());
            }
        }

        public int ExecuteInsert(string sql, params object[] arg)
        {
            ExecuteCommand(sql, arg);
            try
            {
                int number;
                command.CommandText = SqliteResource.SqlGetLastInsertRowId;
                SystemLogger.Debug(command.CommandText);
                using (SQLiteDataReader sdr = command.ExecuteReader())
                {
                    number = int.Parse(sdr[0].ToString());
                }
                return number;
            }
            catch (Exception ex)
            {
                throw new SQLiteException(ex.ToString());
            }
        }

        public SQLiteDataReader ExecuteQuery(string sql, params object[] arg)
        {
            try
            {
                SystemLogger.Debug(sql);
                setParameter(sql, arg);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new SQLiteException(ex.ToString());
            }
        }

        public DataTable ExecuteQueryForDataTable(string sql, params object[] arg)
        {
            try
            {
                SystemLogger.Debug(sql);
                var reader = ExecuteQuery(sql, arg);
                var datatable = CreateDataTable(reader);
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return datatable;
            }
            catch (Exception ex)
            {
                throw new SQLiteException(ex.ToString());
            }
        }
        #endregion

        #region 補助
        public DataTable CreateDataTable(SQLiteDataReader reader)
        {
            if (reader == null) { return null; }
            if (reader.IsClosed) { return null; }
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        #endregion

        #region トランザクション
        protected bool IsTransaction()
        {
            return this.transaction != null;
        }

        public bool TransactionStart()
        {
            if (this.IsTransaction())
            {
                return false;
            }
            this.transaction = this.connection.BeginTransaction();
            return true;
        }

        public bool Commit()
        {
            if (!this.IsTransaction())
            {
                return false;
            }

            this.transaction.Commit();
            this.transaction.Dispose();
            this.transaction = null;
            return true;
        }

        public bool Rollback()
        {
            if (!this.IsTransaction())
            {
                return false;
            }
            this.transaction.Rollback();
            this.transaction.Dispose();
            this.transaction = null;
            return true;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Disconnect();
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
