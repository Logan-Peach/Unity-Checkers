using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public static bool learningMode = true;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DisableLearning()
    {
        learningMode = false;
    }

    public void EnableLearning()
    {
        learningMode = true;
    }
}

