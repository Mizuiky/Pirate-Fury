using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlller : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        Debug.Log("Load Scene");
        SceneManager.LoadScene(scene);
    }
}
