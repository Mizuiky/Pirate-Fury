using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController
{
  
    private ScoreController _scoreController;
    public ScoreController ScoreController { get { return _scoreController; } }

    public WorldController()
    {
      
        _scoreController = new ScoreController();
        _scoreController.Init();
    }

    public void Reset()
    {
        _scoreController.Reset();
    }
}
