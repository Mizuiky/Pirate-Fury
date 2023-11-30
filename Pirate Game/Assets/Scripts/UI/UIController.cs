using System;
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
        GameManager.Instance.PlayerBoat.Health.OnUpdateLife += UpdateHudLife;

        _hud.Init();

        _endGamePanel.EnableEndPanel(false);

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

    private void UpdateHudLife(float currentLife)
    {
        Debug.Log("Update HUD player life " + currentLife);

        _hud.UpdateLife(currentLife);
    }

    public void StartHUDLife(float maxLife)
    {
        _hud.UpdateLife(maxLife);
    }

    public void OpenEndPanel()
    {
        _endGamePanel.Show();
    }

    private void OnDisable()
    {
        GameManager.Instance.WorldController.ScoreController.OnUpdateScore -= OnUpdateScore;
    }
}
