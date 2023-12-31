using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _endPanel;

    [SerializeField]
    private TextMeshProUGUI _scoreText; 

    public void Reset()
    {
        EnableEndPanel(false);
    }

    public void EnableEndPanel(bool enable)
    {
        _endPanel.SetActive(enable);
    }

    public void PlayAgain()
    {
        EnableEndPanel(true);

        GameManager.Instance.Restart();        
    }

    public void Show()
    {
        _scoreText.text = GameManager.Instance.SaveController.Data.playerPoints.ToString();

        _endPanel.SetActive(true);
    }
}
