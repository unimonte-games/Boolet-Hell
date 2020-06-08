using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void Play()
    {
        Debug.Log("Teste");
        SceneManager.LoadScene(gameSceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}