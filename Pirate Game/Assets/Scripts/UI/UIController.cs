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
        _hud.Init();

        GameManager.Instance.WorldController.ScoreController.OnUpdateScore += OnUpdateScore;
        GameManager.Instance.WorldController.Clock.OnTimeUpdate += OnUpdateTimer;
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

    private void OnUpdateTimer(string time)
    {
        _hud.UpdateTimer(time);
    }

    public void OpenEndPanel()
    {

    }
}
