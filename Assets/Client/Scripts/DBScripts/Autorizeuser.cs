using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Autorizeuser : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _highScoreText;

    private void Start()
    {
        _nameText.text = PlayerPrefs.GetString("CurrentUserLogin");
        _highScoreText.text = PlayerPrefs.GetInt("CurrentUserRecord").ToString();
    }
}
