using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
/// <summary>
/// SQLite帮助类
/// </summary>
public class SQLiteHelper
{
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
    public SQLiteHelper(string _connectionString)
    {
        try
        {
            //构造数据库连接
            mDbConnection = new SqliteConnection(_connectionString);
            mDbConnection.Open();
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
    /// 读取整张数据表
    /// </summary>
    /// <param name="_tableName">数据表名称</param>
    /// <returns>全表数据集</returns>
    public SqliteDataReader ReadFullTable(string _tableName)
    {
        string queryString = "SELECT * FROM " + _tableName;
        return ExecuteQuery(queryString);
    }

    /// <summary>
    /// 读取表行数
    /// </summary>
    /// <param name="_tableName">数据表名称</param>
    /// <returns>表行数</returns>
    public Int64 ReadTableCount(string _tableName)
    {
        string queryString = "SELECT COUNT(*) FROM " + _tableName;
        return (Int64)ExecuteScalar(queryString);
    }

    /// <summary>
    /// 读取所有实体名称数量
    /// </summary>
    /// <returns>数量</returns>
    public Int64 ReadEntityNamesCount()
    {
        string queryString = "SELECT COUNT(*) FROM sqlite_master WHERE (type='table' OR type='view')";
        return (Int64)ExecuteScalar(queryString);
    }

    /// <summary>
    /// 读取所有实体名称
    /// </summary>
    /// <returns>实体名称集合</returns>
    public SqliteDataReader ReadEntityNames()
    {
        return ExecuteQuery("SELECT *,(SELECT COUNT(*) FROM View_DeterminantVT WHERE vtName =name) isDetermainant FROM sqlite_master WHERE (type='table' OR type='view')");
    }

    /// <summary>
    /// 获得表Schema信息
    /// </summary>
    /// <param name="_tableName">表名</param>
    /// <returns>表Schema信息</returns>
    public SqliteDataReader ReadTableSchema(string _tableName)
    {
        return ExecuteQuery(string.Format("SELECT * FROM {0} LIMIT 0", _tableName));
    }

    /// <summary>
    /// 获得表Pragma信息
    /// </summary>
    /// <param name="_tableName">表名</param>
    /// <returns>表Pragma信息</returns>
    public SqliteDataReader ReadTablePragma(string _tableName)
    {
        return ExecuteQuery(string.Format("PRAGMA table_info({0})", _tableName));
    }
}

