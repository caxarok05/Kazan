using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;

public class DBConnection : MonoBehaviour
{

    public void InsertInto(string DataBaseName, string SQLQuery)
    {
        string dbName = SetDataBaseClass.SetDataBase(DataBaseName + ".db");

        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = SQLQuery;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public string DisplayRequest(string DataBaseName, string SQLQuery)
    {
        string dbName = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        string fields = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = SQLQuery;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            fields = reader[0].ToString();
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
        return fields;
    }
    public List<string[]> DisplayRequest(string DataBaseName, string SQLQuery, string[] fieldsNames)
    {
        string dbName = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        List<string[]> fields = new List<string[]>();
        
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = SQLQuery;
                using(IDataReader  reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] cellResult = new string[fieldsNames.Length];
                        for (int i = 0; i < fieldsNames.Length; i++)
                        {
                           cellResult[i] = reader[fieldsNames[i]].ToString();
                        }
                        fields.Add(cellResult);
                    }
                    reader.Close();
                }
            }
            connection.Close();

        }
        return fields;
    }

    public string[] DisplayRequestArray(string DataBaseName, string SQLQuery, string[] fieldsNames)
    {
        string dbName = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        string[] result = new string[fieldsNames.Length];

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = SQLQuery;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        for (int i = 0; i < fieldsNames.Length; i++)
                        {
                            result[i] = reader[fieldsNames[i]].ToString();
                        }

                    }
                    reader.Close();
                }
            }

            connection.Close();

        }
        return result;
    }
}
