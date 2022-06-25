using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        
    }

    public void Restart() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
}
