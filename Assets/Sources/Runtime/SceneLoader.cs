using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private readonly string _menu = "Main menu";
    private readonly string _game = "Game";

    public void LoadMenu() => SceneManager.LoadSceneAsync(_menu);

    public void LoadGame() => SceneManager.LoadSceneAsync(_game);

    public void Exit() => Application.Quit();

    public void Restart() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
}
