using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text label;

    void CheckTopScore(string topScoreKey)
    {
        if (!PlayerPrefs.HasKey(topScoreKey))
        {
            PlayerPrefs.SetInt(topScoreKey, (int)GamePlay.Instance.score);
        }
        if (PlayerPrefs.GetInt(topScoreKey) < GamePlay.Instance.score)
        {
            PlayerPrefs.SetInt(topScoreKey, (int)GamePlay.Instance.score);
        }
        label.text += PlayerPrefs.GetInt(topScoreKey).ToString();

    }
    
    private void Awake()
    {
        CheckTopScore(PlayerPrefsKeys.topScoreKey);
    }
}