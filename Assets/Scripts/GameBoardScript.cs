using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardScript : MonoBehaviour
{
    public int[,] gameBoard;
    public int selectedRow;
    public int selectedCol;
    public int selectedVal;
    public int currentPlayer;
    

    // Start is called before the first frame update
    private void Start()
    {
        //gameBoard = new int[8, 8];
        gameBoard = new int[8, 8] { 
            { 0, 1, 0, 1, 0, 1, 0, 1 }, 
            { 1, 0, 1, 0, 1, 0, 1, 0 }, 
            { 0, 1, 0, 1, 0, 1, 0, 1 },
            { 3, 0, 3, 0, 3, 0, 3, 0 },
            { 0, 3, 0, 3, 0, 3, 0, 3 },
            { 2, 0, 2, 0, 2, 0, 2, 0 },
            { 0, 2, 0, 2, 0, 2, 0, 2 },
            { 2, 0, 2, 0, 2, 0, 2, 0 } };
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void MakeKing()
    {

    }


}
