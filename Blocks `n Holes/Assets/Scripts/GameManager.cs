using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public Gate gate;

    private int consecutiveHits = 1;
    private int totalScore = 0;

    private void Awake()
    {
        Instance = null;
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != null)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        UiManager.Instance.SetTotalScore(totalScore);
    }

    public void HasHitHole()
    {
        totalScore += 10 * consecutiveHits++;
        UiManager.Instance.SetTotalScore(totalScore);
        gate.UpdateAmountHit();
    }

    public void HasMissedHole()
    {
        consecutiveHits = 1;
    }


}
