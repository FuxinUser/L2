using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace Common
{
    internal class DataAccess
    {
        private static readonly object _syncRoot = new object();

        private static DataAccess _instance;

        /// <summary>Get DataAccess entity</summary>
        /// <returns></returns>
        internal static DataAccess GetInstance()
        {
            if (_instance != null) return _instance;

            lock (_syncRoot)
            {
                _instance = new DataAccess();
                return _instance;
            }
        }

        internal List<T> QueryList<T>(string strSql, string strConn, int timeout = 30)
        {
            SqlConnection conn = new SqlConnection(strConn);        // Get connected entity
            List<T> ans = new List<T>();
            try
            {
                using (conn)
                {
                    if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                    {
                        conn.Open();
                    }
                    ans = conn.Query<T>(strSql, commandTimeout: timeout).ToList();
                }
            }
            catch
            {
                throw;
            }
            return ans;
        }

        internal T QueryFirst<T>(string strSql, string strConn, int timeout = 1000)
        {
            SqlConnection conn = new SqlConnection(strConn);        // Get connected entity
            T ans = default;
            try
            {
                using (conn)
                {
                    if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                    {
                        conn.Open();
                    }
                    ans = conn.QueryFirstOrDefault<T>(strSql, commandTimeout: timeout);
                }
            }
            catch
            {
                throw;
            }
            return ans;
        }

        internal bool Excute(string strSql, string strConn)
        {
            SqlConnection conn = new SqlConnection(strConn);        // Get connected entity
            try
            {
                using (conn)
                {
                    if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                    {
                        conn.Open();
                    }
                    conn.Execute(strSql);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        internal bool BulkExcute(List<string> strSqls, string strConn)
        {
            SqlConnection conn = new SqlConnection(strConn);        // Get connected entity
            try
            {
                using (var trans = new TransactionScope())
                {
                    using (conn)
                    {
                        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                        {
                            conn.Open();
                        }
                        foreach (var sql in strSqls)
                        {
                            conn.Execute(sql);
                        }
                    }
                    trans.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}