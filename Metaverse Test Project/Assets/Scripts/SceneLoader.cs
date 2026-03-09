using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This class is used the reload the current scene via the onClick UI event
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Loading Scene");
    }
}


