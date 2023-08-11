using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    private void Start()
    {
        RegisterInstance();
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void LoadSceneAsync(int num)
    {
        SceneManager.LoadSceneAsync(num);
    }
}
