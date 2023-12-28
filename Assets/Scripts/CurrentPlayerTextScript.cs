using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerTextScript : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameBoardScript boardScript;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (boardScript.currentPlayer == 1)
        {
            text.text = "Current Player: White";
            text.color = Color.white;
        }
        else if (boardScript.currentPlayer == 2) 
        {
            text.text = "Current Player: Red";
            text.color = Color.red;
        }
        if (boardScript.winner != 0)
        {
            if (boardScript.winner == 1)
            {
                text.text = "White Wins";
                text.color = Color.white;
            }
            else if (boardScript.winner == 2)
            {
                text.text = "Red Wins";
                text.color = Color.red;
            }
        }
    }
}
