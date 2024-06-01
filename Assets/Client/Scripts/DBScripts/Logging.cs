using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logging : MonoBehaviour
{
    public string _DataBaseName;

    private DBConnection insertNew = new DBConnection();

    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;

    [SerializeField] private string _menuSceneName;

    [SerializeField] private TMP_Text _LoggingResult;

    private string[] _namesList = new string[3] {"Name", "Record", "Password"};
    private string[] _accountData = new string[3];


    public void Log()
    {
        string SQLQuery = "Select Name, Record, Password from User where Name = '" +
        _loginInput.text.Trim() + "' AND Password = '" + _passwordInput.text.Trim() + "';";
        _accountData = insertNew.DisplayRequestArray(_DataBaseName, SQLQuery, _namesList);

        if (_loginInput.text.Trim() == _accountData[0] && _passwordInput.text.Trim() == _accountData[2])
        {
            PlayerPrefs.SetString("CurrentUserLogin", _accountData[0]);
            PlayerPrefs.SetInt("CurrentUserRecord", int.Parse(_accountData[1]));
            PlayerPrefs.SetString("CurrentUserPassword", _accountData[2]);

            SceneManager.LoadScene(_menuSceneName);

        }
        else
        {
            _LoggingResult.text = "Некправ ильный логин или пароль";
            _LoggingResult.color = Color.red;
        }
    }
}
