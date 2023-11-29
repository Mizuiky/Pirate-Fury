using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private HUD _hud;

    [SerializeField]
    private EndGame _endGamePanel;

    public void Init()
    {
        GameManager.Instance.WorldController.ScoreController.OnUpdateScore += OnUpdateScore;

        _hud.Init(GameManager.Instance.SaveController.Data.maxClockTime);

    }

    public void Reset()
    {
        _hud.Reset();
        _endGamePanel.Reset();
    }

    private void OnUpdateScore(int points)
    {
        _hud.UpdateScore(points);
    }

    public void OpenEndPanel()
    {

    }
}
