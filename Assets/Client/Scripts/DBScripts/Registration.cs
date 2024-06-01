using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public string _DataBaseName;

    private DBConnection insertNew = new DBConnection();

    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;

    [SerializeField] private TMP_Text _LoggingResult;

    private string[] _namesList = new string[2] { "Name", "Password" };
    private string[] _accountData = new string[2];


    public void Register()
    {
        string SQLQuery = "Select Name, Password from User where Name = '" +
        _loginInput.text.Trim() + "' AND Password = '" + _passwordInput.text.Trim() + "';";
        _accountData = insertNew.DisplayRequestArray(_DataBaseName, SQLQuery, _namesList);

        if (_loginInput.text.Trim() == _accountData[0])
        {
            _LoggingResult.text = "Такой аккаунт уже зарегестрирован";
            _LoggingResult.color = Color.red;
        }
        else
        {
            string SQLQuery2 = "Insert into User (Name, Record, Password) values ('" +
            _loginInput.text.Trim() +
            "', 0, '" + _passwordInput.text.Trim() + "');";
            insertNew.InsertInto(_DataBaseName, SQLQuery2);
            _LoggingResult.text = "Успешная регистрация";
            _LoggingResult.color = Color.green;
        }

        
    }
}
