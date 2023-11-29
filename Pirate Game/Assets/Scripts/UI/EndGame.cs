using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _endPanel;

    public void Reset()
    {
        _endPanel.SetActive(false);
    }

    public void EnableEndPanel()
    {
        if (_endPanel.activeInHierarchy)
            _endPanel.SetActive(false);
        else
            _endPanel.SetActive(true);
    }
}
