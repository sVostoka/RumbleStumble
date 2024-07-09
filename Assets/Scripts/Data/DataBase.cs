using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System;
using System.Reflection;
using static Enums;
using System.Collections.Generic;

public static class DataBase
{
    private const string FILENAME = "DataBase.db";
    private static string _dbPath;
    private static SqliteConnection _connection;
    private static SqliteCommand _command;

    static DataBase()
    {
        _dbPath = GetDatabasePath();
    }

    private static string GetDatabasePath()
    {
#if UNITY_EDITOR
        return Path.Combine(Application.streamingAssetsPath, FILENAME); ;
#elif UNITY_STANDALONE
            return Path.Combine(Application.streamingAssetsPath, FILENAME);
#endif
    }

    private static void OpenConnection()
    {
        _connection = new SqliteConnection("Data Source=" + _dbPath);
        _command = new SqliteCommand(_connection);
        _connection.Open();
    }

    public static void CloseConnection()
    {
        _connection.Close();
        _command.Dispose();
    }

    public static T GetItem<T>()
    {
        var query = $"SELECT * FROM {typeof(T).FullName} ORDER BY random() LIMIT 1";

        OpenConnection();
        _command.CommandText = query;
        SqliteDataReader answer = _command.ExecuteReader();

        T result = default;

        while(answer.Read())
        {
            var obj = Activator.CreateInstance(typeof(T)) ;

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(PropertyInfo property in properties)
            {
                int numberColumn = answer.GetOrdinal(property.Name);

                if (property.PropertyType == typeof(string)) property.SetValue(obj, answer.GetString(numberColumn));
                if (property.PropertyType == typeof(int)) property.SetValue(obj, answer.GetInt32(numberColumn));
                if (property.PropertyType == typeof(float)) property.SetValue(obj, answer.GetFloat(numberColumn));
                if (property.PropertyType == typeof(Rarity)) 
                    property.SetValue(obj, (Rarity)answer.GetInt32(numberColumn));
            }

            result = (T)obj;
        }

        CloseConnection();

        return result;
    }
}