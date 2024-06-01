using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateLeaderBoard : MonoBehaviour
{
    [SerializeField] private string _dbName;
    [SerializeField] private GameObject _leaderboardPrefab;
    private DBConnection _connection = new DBConnection();
    
    private string[] _fieldsName = new string[2] {"Name", "Record" };
    private List<string[]> _leaderboardData = new List<string[]>();

    private void Start()
    {
        ShowLeaderBoard();
    }
    private void ShowLeaderBoard()
    {

        string SQLQuery = "Select Name, Record from User ORDER BY Record DESC";
        _leaderboardData = _connection.DisplayRequest(_dbName, SQLQuery, _fieldsName);

        for (int i = 0; i < _leaderboardData.Count; i++)
        {
            GameObject prefab = Instantiate(_leaderboardPrefab, gameObject.transform);
            for (int a = 0; a < _leaderboardData[i].Length; a++)
            {
                Debug.Log(_leaderboardData[i][a]);
                prefab.transform.GetChild(a).GetComponent<TMP_Text>().text = _leaderboardData[i][a];
            }
        }

       // _leaderboardPrefab.transform.GetChild(0).GetComponent<TMP_Text>().text = "name";
       // _leaderboardPrefab.transform.GetChild(1).GetComponent<TMP_Text>().text = "score";
    }

}
