using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private Text winnerText;

    void Start()
    {
        if (WinnerScript.winner == 1)
        {
            winnerText.text = "White Wins";
        }
        if (WinnerScript.winner == 2)
        {
            winnerText.text = "Red Wins";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
