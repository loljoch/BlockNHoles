using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI scorePoints;

    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(this);
        }
    }

    public void SetTotalScore(int score)
    {
        totalScore.SetText("Score: " + score);
    }

    public void SetScorePoints()
    {

    }


}
