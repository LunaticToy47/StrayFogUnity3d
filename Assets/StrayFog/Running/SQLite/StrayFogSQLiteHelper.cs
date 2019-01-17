using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
/// <summary>
/// SQLite帮助类
/// </summary>
public partial class StrayFogSQLiteHelper
{
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string connectionString { get { return mDbConnection.ConnectionString; } }
    /// <summary>
    /// 数据库连接定义
    /// </summary>
    private SqliteConnection mDbConnection;
    /// <summary>
    /// Reader队列
    /// </summary>
    Queue<SqliteDataReader> mQueueSqliteDataReader = new Queue<SqliteDataReader>();
    /// <summary>
    /// 构造函数    
    /// </summary>
    /// <param name="_connectionString">数据库连接字符串</param>
    public StrayFogSQLiteHelper(string _connectionString)
    {
        try
        {
            //构造数据库连接
            mDbConnection = new SqliteConnection(_connectionString);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// 关闭数据库连接
    /// </summary>
    public void Close()
    {
        while (mQueueSqliteDataReader.Count > 0)
        {
            SqliteDataReader reader = mQueueSqliteDataReader.Dequeue();
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
                reader = null;
            }
        }
        
        if (mDbConnection != null && mDbConnection.State != System.Data.ConnectionState.Closed)
        {
            mDbConnection.Close();
            mDbConnection.Dispose();
        }
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    #region ExecuteQuery
    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <returns>数据集</returns>
    public SqliteDataReader ExecuteQuery(string _queryString)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        SqliteDataReader reader = cmd.ExecuteReader();
        cmd.Dispose();
        cmd = null;
        mQueueSqliteDataReader.Enqueue(reader);
        return reader;
    }

    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <param name="_parameters">参数组</param>
    /// <returns>数据集</returns>
    public SqliteDataReader ExecuteQuery(string _queryString, params SqliteParameter[] _parameters)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        cmd.Parameters.AddRange(_parameters);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        SqliteDataReader reader = cmd.ExecuteReader();
        cmd.Dispose();
        cmd = null;
        mQueueSqliteDataReader.Enqueue(reader);
        return reader;
    }
    #endregion

    #region ExecuteNonQuery
    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <returns>条数</returns>
    public int ExecuteNonQuery(string _queryString)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        int result = cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        mDbConnection.Close();
        return result;
    }

    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <param name="_parameters">参数组</param>
    /// <returns>条数</returns>
    public int ExecuteNonQuery(string _queryString,params SqliteParameter[] _parameters)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        cmd.Parameters.AddRange(_parameters);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        int result = cmd.ExecuteNonQuery();        
        cmd.Dispose();
        cmd = null;        
        mDbConnection.Close();
        return result;
    }
    #endregion

    #region ExecuteTransaction
    /// <summary>
    /// 执行SQL事务
    /// </summary>
    /// <param name="_queryStrings">SQL命令字符串组</param>
    /// <returns>true:成功,false:失败</returns>
    public bool ExecuteTransaction(params string[] _queryStrings)
    {
        bool result = false;
        if (_queryStrings != null && _queryStrings.Length > 0)
        {
            SqliteCommand cmd = new SqliteCommand(mDbConnection);
            //SqliteCommand cmd = mDbConnection.CreateCommand();
            //cmd.CommandText = _queryString;
            if (mDbConnection.State == System.Data.ConnectionState.Closed)
            {
                mDbConnection.Open();
            }
            SqliteTransaction trans = mDbConnection.BeginTransaction();
            try
            {
                foreach (string sql in _queryStrings)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch(Exception ep)
            {
                trans.Rollback();
                Debug.LogError(ep.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                mDbConnection.Close();
                result = true;
            }
        }
        return result;
    }

    /// <summary>
    /// 执行SQL事务
    /// </summary>
    /// <param name="_queryStringParametersPair">SQL命令字符串参数组</param>
    /// <returns>true:成功,false:失败</returns>
    public bool ExecuteTransaction(Dictionary<string, List<SqliteParameter>> _queryStringParametersPair)
    {        
        bool result = false;
        if (_queryStringParametersPair != null && _queryStringParametersPair.Count > 0)
        {
            SqliteCommand cmd = new SqliteCommand(mDbConnection);
            //SqliteCommand cmd = mDbConnection.CreateCommand();
            //cmd.CommandText = _queryString;
            if (mDbConnection.State == System.Data.ConnectionState.Closed)
            {
                mDbConnection.Open();
            }
            SqliteTransaction trans = mDbConnection.BeginTransaction();
            try
            {
                foreach (KeyValuePair<string, List<SqliteParameter>> key in _queryStringParametersPair)
                {
                    cmd.CommandText = key.Key;
                    cmd.Parameters.AddRange(key.Value.ToArray());
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ep)
            {
                trans.Rollback();
                Debug.LogError(ep.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                mDbConnection.Close();
                result = true;
            }
        }
        return result;
    }
    #endregion

    #region ExecuteScalar
    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <returns>第一行第一列</returns>
    public object ExecuteScalar(string _queryString)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        object result = cmd.ExecuteScalar();
        cmd.Dispose();
        cmd = null;
        mDbConnection.Close();
        return result;
    }

    /// <summary>
    /// 执行SQL命令
    /// </summary>
    /// <param name="_queryString">SQL命令字符串</param>
    /// <param name="_parameters">参数组</param>
    /// <returns>第一行第一列</returns>
    public object ExecuteScalar(string _queryString, params SqliteParameter[] _parameters)
    {
        SqliteCommand cmd = new SqliteCommand(_queryString, mDbConnection);
        cmd.Parameters.AddRange(_parameters);
        //SqliteCommand cmd = mDbConnection.CreateCommand();
        //cmd.CommandText = _queryString;
        if (mDbConnection.State == System.Data.ConnectionState.Closed)
        {
            mDbConnection.Open();
        }
        object result = cmd.ExecuteScalar();
        cmd.Dispose();
        cmd = null;
        mDbConnection.Close();
        return result;
    }
    #endregion

    #region ReadFullTable
    /// <summary>
    /// 读取整张数据表
    /// </summary>
    /// <param name="_tableName">数据表名称</param>
    /// <returns>全表数据集</returns>
    public SqliteDataReader ReadFullTable(string _tableName)
    {
        string queryString = "SELECT * FROM " + _tableName;
        return ExecuteQuery(queryString);
    }
    #endregion    

    #region ReadDeterminantTableNames 读取行列式表名称
    /// <summary>
    /// 读取行列式表名称
    /// </summary>
    /// <returns>行列式表名称</returns>
    public SqliteDataReader ReadDeterminantTableNames()
    {
        return ExecuteQuery("SELECT * FROM View_DeterminantVT");
    }
    #endregion

    #region ReadPragmaTableInfo 获得表信息
    /// <summary>
    /// 获得表信息
    /// </summary>
    /// <param name="_tableName">名称</param>
    /// <returns>表架构</returns>
    public SqliteDataReader ReadPragmaTableInfo(string _tableName)
    {
        return ExecuteQuery(string.Format("PRAGMA table_info({0})", _tableName));
    }
    #endregion

    #region ReadSQLiteViewSchema 读取数据库视图架构
    /// <summary>
    /// 读取数据库视图架构
    /// </summary>
    /// <returns>读取数据库视图架构</returns>
    public SqliteDataReader ReadSQLiteViewSchema()
    {
        return ExecuteQuery("SELECT * FROM sqlite_master WHERE type='view'");
    }
    #endregion    

    #region ReadSQLiteTableSchema 读取数据库表架构
    /// <summary>
    /// 读取数据库表架构
    /// </summary>
    /// <returns>数据库表架构</returns>
    public SqliteDataReader ReadSQLiteTableSchema()
    {
        return ExecuteQuery("SELECT * FROM sqlite_master WHERE type='table'");
    }
    #endregion    
}

