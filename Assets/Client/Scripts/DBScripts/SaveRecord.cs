using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveRecord : MonoBehaviour
{
    public string _DataBaseName;

    private DBConnection insertNew = new DBConnection();

    private void Awake()
    {
        UpdateRecord();
    }
    public void UpdateRecord()
    {
        Debug.Log(PlayerPrefs.GetInt("CurrentUserRecord"));
        string SQLQuery = "Update User Set Record = '" + PlayerPrefs.GetInt("CurrentUserRecord").ToString() + "' where Name = '" +
        PlayerPrefs.GetString("CurrentUserLogin") + "';";
        insertNew.InsertInto(_DataBaseName, SQLQuery);
     
    }
}
