using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Pool Pool;

    private void Awake()
    {
        if (Instance == null)
            Instance = gameObject.GetComponent<GameManager>();

        else
            Destroy(this);
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if(Pool != null)
            Pool.InitPool();
    }
}
