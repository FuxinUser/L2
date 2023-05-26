using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Common;

namespace L2
{
    public class PrimaryKey : Attribute
    {
        public PrimaryKey() { }
    }


    public class DBL25Handler
    {

        private readonly LogHandler _logger = null;

        public DBL25Handler(LogHandler logger)
        {
            _logger = logger;
        }

        public bool InsertOnly<T>(T t, int timeout = 30)
        {
            ToDic(t, out var dicPKey, out var dicEdit);
            return Insert<T>(dicPKey, dicEdit, timeout);            // Execute insert
        }




        #region 底層function
        private void ToDic<T>(T t, out Dictionary<string, object> PK, out Dictionary<string, object> edit)
        {
            PK = new Dictionary<string, object>();
            edit = new Dictionary<string, object>();

            var editKey = t.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(PrimaryKey))); ;
            var pkKey = t.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(PrimaryKey)));

            foreach (var item in editKey)
            {
                edit.Add(item.Name, item.GetValue(t));
            }
            foreach (var item in pkKey)
            {
                PK.Add(item.Name, item.GetValue(t));
            }
        }

        private bool Update<T>(Dictionary<string, object> dicKey, Dictionary<string, object> dicEdit, int timeout = 30)
        {
            string strUpd = "";
            try
            {
                foreach (KeyValuePair<string, object> item in dicEdit)
                {
                    if (item.Value == null)
                    {
                        //strUpd += $"{item.Key} = null,";
                    }
                    else
                    {
                        strUpd += GetUpdateValue(item.Key, item.Value);
                    }

                }
                strUpd = strUpd.Substring(0, strUpd.Length - 1);

                string strSql = string.Format("Update {0} Set {1} ", typeof(T).Name, strUpd);
                string strWhere = GetSqlWhere(dicKey);
                _logger.Debug("Update DB. Sql=" + strSql + strWhere);

                if (strWhere != "")
                {
                    return DataAccess.GetInstance().Excute(strSql + strWhere, PublicSystem.ConnectDBStr);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("InsertOrUpdate. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }
            return false;
        }

        private string GetUpdateValue(string itemKey, object itemValue)
        {
            if (itemValue == null)
            {
                return "null,";
            }
            switch (itemValue.GetType())
            {
                case Type strType when strType == typeof(string): return string.Format("{0}='{1}',", itemKey, ((string)itemValue).Trim());
                case Type dateType when dateType == typeof(DateTime):
                    if (((DateTime)itemValue).Ticks == 0)
                    {
                        return $"{itemKey} = '',";
                    }
                    return string.Format("{0}='{1}',", itemKey, ((DateTime)itemValue).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                default: return string.Format("{0}={1},", itemKey, itemValue);
            }
        }

        private string GetSqlWhere(Dictionary<string, object> dicKey)
        {
            string strWhere = "";

            try
            {
                if (dicKey != null && dicKey.Count > 0)
                {
                    strWhere = "Where ";

                    foreach (KeyValuePair<string, object> item in dicKey)
                    {
                        string condition = (item.Value.GetType().Name == "String") ? "{0}='{1}' And " : "{0}={1} And ";
                        strWhere += string.Format(condition, item.Key, item.Value);
                    }

                    strWhere = strWhere.Substring(0, strWhere.Length - 4);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("GetSqlWhere. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }

            return strWhere;
        }

        private bool Insert<T>(Dictionary<string, object> dicPKey, Dictionary<string, object> dicEdit, int timeout = 30)
        {
            try
            {
                string strSql = GetInsertSql<T>(dicPKey, dicEdit);
                return DataAccess.GetInstance().Excute(strSql, PublicSystem.ConnectL25DBStr);
            }
            catch (Exception ex)
            {
                _logger.Error("InsertOrUpdate. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }
            return false;
        }

        private string GetInsertSql<T>(Dictionary<string, object> Pks, Dictionary<string, object> edits)
        {
            string strFix = "";     // Insert fixed columns
            string strVal = "";     // Insert values

            foreach (KeyValuePair<string, object> item in Pks)
            {
                strFix += string.Format("{0},", item.Key);
                strVal += GetInsertValue(item.Value);
            }
            foreach (KeyValuePair<string, object> item in edits)
            {
                strFix += string.Format("{0},", item.Key);
                strVal += GetInsertValue(item.Value);
            }
            strFix = strFix.Substring(0, strFix.Length - 1);
            strVal = strVal.Substring(0, strVal.Length - 1);

            string strSql = $"Insert into {typeof(T).Name} ({strFix}) Values ({strVal}) ";

            _logger.Debug("Insert DB. Sql=" + strSql);
            return strSql;
        }
        private string GetInsertValue(object itemValue)
        {
            if (itemValue == null)
            {
                return "null,";
            }
            switch (itemValue.GetType())
            {
                case Type strType when strType == typeof(string): return string.Format("'{0}',", ((string)itemValue).Trim());
                case Type dateType when dateType == typeof(DateTime):
                    if (((DateTime)itemValue).Ticks == 0)
                    {
                        return "'',";
                    }
                    return string.Format("'{0}',", ((DateTime)itemValue).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                default: return string.Format("{0},", itemValue);
            }
        }
        #endregion
    }

    public class DBHandler
    {
        private readonly LogHandler _logger = null;

        public DBHandler(LogHandler logger)
        {
            _logger = logger;
        }

        /// <summary>查詢一筆轉成ORM</summary>
        public T QueryFirst<T>(string sqlStr)
        {
            try
            {
                return DataAccess.GetInstance().QueryFirst<T>(sqlStr, PublicSystem.ConnectDBStr);
            }
            catch (Exception e)
            {
                _logger.Error("[Dapper] " + e.Message);
            }
            return default;
        }

        /// <summary>查詢多筆轉成ORM List</summary>
        public List<T> QueryList<T>(string sqlStr)
        {
            try
            {
                return DataAccess.GetInstance().QueryList<T>(sqlStr, PublicSystem.ConnectDBStr);
            }
            catch (Exception e)
            {
                _logger.Error("[Dapper] " + e.Message);
            }
            return null;
        }

        /// <summary>資料表全撈轉成轉成ORM List</summary>
        public List<T> QueryAll<T>(int count = 0)
        {
            try
            {
                string sqlStr;
                if (count > 0) sqlStr = $"Select Top {count} * from {typeof(T).Name}";
                else sqlStr = $"Select * from {typeof(T).Name}";
                return QueryList<T>(sqlStr);
            }
            catch (Exception e)
            {
                _logger.Error("[Dapper] " + e.Message);
            }
            return null;
        }

        /// <summary>執行特定SQL語句</summary>
        public bool Execute(string sqlstr)
        {
            try
            {
                return DataAccess.GetInstance().Excute(sqlstr, PublicSystem.ConnectDBStr);
            }
            catch (Exception e)
            {
                _logger.Error("[Dapper] " + e.Message);
            }
            return false;
        }

        /// <summary>以ORM新增或更新資料表</summary>
        public bool InsertOrUpdate<T>(T t, int timeout = 30) where T : new()
        {
            ToDic(t, out var dicPKey, out var dicEdit);

            // Check if insert or update
            T selT = SelOne<T>(dicPKey);

            if (selT == null)
            {
                return Insert<T>(dicPKey, dicEdit, timeout);            // Execute insert
            }
            else
            {
                return Update<T>(dicPKey, dicEdit, timeout);             // Execute Update
            }
        }

        public bool InsertList<T>(List<T> t, int timeout = 30)
        {
            List<string> sqls = new List<string>();
            foreach (var orm in t)
            {
                ToDic(orm, out var dicPKey, out var dicEdit);

                var sqlstr = GetInsertSql<T>(dicPKey, dicEdit);
                sqls.Add(sqlstr);
            }
            try
            {
                return DataAccess.GetInstance().BulkExcute(sqls, PublicSystem.ConnectDBStr);
            }
            catch (Exception ex)
            {
                _logger.Error("[Dapper] " + ex.Message);
            }
            return false;
        }
        /// <summary>以ORM新增到資料表</summary>
        public bool InsertOnly<T>(T t, int timeout = 30)
        {
            ToDic(t, out var dicPKey, out var dicEdit);
            return Insert<T>(dicPKey, dicEdit, timeout);            // Execute insert
        }

        /// <summary>以ORM更新資料表</summary>
        public bool UpdateOnly<T>(T t, int timeout = 30)
        {
            ToDic(t, out var dicPKey, out var dicEdit);
            return Update<T>(dicPKey, dicEdit, timeout);             // Execute Update
        }

        /// <summary>以ORM刪除全部資料</summary>
        public bool DelAll<T>()
        {
            string strSql = string.Format("Delete {0} ", typeof(T).Name);
            _logger.Debug("DelOne. strSql=" + strSql);

            return DataAccess.GetInstance().Excute(strSql, PublicSystem.ConnectDBStr);
        }

        #region "Other method"
        private bool Insert<T>(Dictionary<string, object> dicPKey, Dictionary<string, object> dicEdit, int timeout = 30)
        {
            try
            {
                //剔除Key serNo欄位               
                dicPKey.Remove("SerNo");

                string strSql = GetInsertSql<T>(dicPKey, dicEdit);
                return DataAccess.GetInstance().Excute(strSql, PublicSystem.ConnectDBStr);
            }
            catch (Exception ex)
            {
                _logger.Error("InsertOrUpdate. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }
            return false;
        }

        private bool Update<T>(Dictionary<string, object> dicKey, Dictionary<string, object> dicEdit, int timeout = 30)
        {
            string strUpd = "";
            try
            {
                foreach (KeyValuePair<string, object> item in dicEdit)
                {
                    if (item.Value == null)
                    {
                        //strUpd += $"{item.Key} = null,";
                    }
                    else
                    {
                        strUpd += GetUpdateValue(item.Key, item.Value);
                    }

                }
                strUpd = strUpd.Substring(0, strUpd.Length - 1);

                string strSql = string.Format("Update {0} Set {1} ", typeof(T).Name, strUpd);
                string strWhere = GetSqlWhere(dicKey);
                _logger.Debug("Update DB. Sql=" + strSql + strWhere);

                if (strWhere != "")
                {
                    return DataAccess.GetInstance().Excute(strSql + strWhere, PublicSystem.ConnectDBStr);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("InsertOrUpdate. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }
            return false;
        }

        private void ToDic<T>(T t, out Dictionary<string, object> PK, out Dictionary<string, object> edit)
        {
            PK = new Dictionary<string, object>();
            edit = new Dictionary<string, object>();

            var editKey = t.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(PrimaryKey)));
            var pkKey = t.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(PrimaryKey)));

            foreach (var item in editKey)
            {
                if (item.PropertyType == typeof(DateTime))
                {
                    edit.Add(item.Name, ((DateTime)item.GetValue(t)).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                }
                else
                {
                    edit.Add(item.Name, item.GetValue(t));
                }
            }
            foreach (var item in pkKey)
            {
                if (item.PropertyType == typeof(DateTime))
                {
                    PK.Add(item.Name, ((DateTime)item.GetValue(t)).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                }
                else
                {
                    PK.Add(item.Name, item.GetValue(t));
                }
            }
        }

        private T SelOne<T>(Dictionary<string, object> dicKey, int timeout = 30) where T : new()
        {
            string strSql = string.Format("Select * From {0} ", typeof(T).Name);
            strSql += GetSqlWhere(dicKey);
            _logger.Debug("SelAll. strSql=" + strSql);
            return QueryFirst<T>(strSql);
        }

        private string GetSqlWhere(Dictionary<string, object> dicKey)
        {
            string strWhere = "";

            try
            {
                if (dicKey != null && dicKey.Count > 0)
                {
                    strWhere = "Where ";

                    foreach (KeyValuePair<string, object> item in dicKey)
                    {
                        string condition = (item.Value.GetType().Name == "String") ? "{0}='{1}' And " : "{0}={1} And ";
                        strWhere += string.Format(condition, item.Key, item.Value);
                    }

                    strWhere = strWhere.Substring(0, strWhere.Length - 4);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("GetSqlWhere. ex=" + ex.ToString());
                _logger.Error(" ex.Message=" + ex.Message);
                _logger.Error(" ex.StackTrace=" + ex.StackTrace);
            }

            return strWhere;
        }

        private string GetInsertValue(object itemValue)
        {
            if (itemValue == null)
            {
                return "null,";
            }
            switch (itemValue.GetType())
            {
                case Type strType when strType == typeof(string): return string.Format("'{0}',", ((string)itemValue).Trim());
                case Type dateType when dateType == typeof(DateTime):
                    if (((DateTime)itemValue).Ticks == 0)
                    {
                        return "'',";
                    }
                    return string.Format("'{0}',", ((DateTime)itemValue).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                default: return string.Format("{0},", itemValue);
            }
        }

        private string GetInsertSql<T>(Dictionary<string, object> Pks, Dictionary<string, object> edits)
        {
            string strFix = "";     // Insert fixed columns
            string strVal = "";     // Insert values

            foreach (KeyValuePair<string, object> item in Pks)
            {
                strFix += string.Format("{0},", item.Key);
                strVal += GetInsertValue(item.Value);
            }
            foreach (KeyValuePair<string, object> item in edits)
            {
                strFix += string.Format("{0},", item.Key);
                strVal += GetInsertValue(item.Value);
            }
            strFix = strFix.Substring(0, strFix.Length - 1);
            strVal = strVal.Substring(0, strVal.Length - 1);

            string strSql = $"Insert into {typeof(T).Name} ({strFix}) Values ({strVal}) ";

            _logger.Debug("Insert DB. Sql=" + strSql);
            return strSql;
        }

        private string GetUpdateValue(string itemKey, object itemValue)
        {
            if (itemValue == null)
            {
                return "null,";
            }
            switch (itemValue.GetType())
            {
                case Type strType when strType == typeof(string): return string.Format("{0}='{1}',", itemKey, ((string)itemValue).Trim());
                case Type dateType when dateType == typeof(DateTime):
                    if (((DateTime)itemValue).Ticks == 0)
                    {
                        return $"{itemKey} = '',";
                    }
                    return string.Format("{0}='{1}',", itemKey, ((DateTime)itemValue).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                default: return string.Format("{0}={1},", itemKey, itemValue);
            }
        }

        #endregion
    }
}
