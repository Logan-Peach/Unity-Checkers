using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardScript : MonoBehaviour
{
    public int[,] gameBoard;
    public int selectedRowP;
    public int selectedColP;
    public int selectedValP = 0;
    public bool isKing;

    public int selectedRowOpp;
    public int selectedColOpp;
    public int selectedValOpp = 0;

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

    public void TakeTurn()
    {
        if (selectedValP == currentPlayer)
        {

        }
    }

    public bool IsValidTurn(int row, int col)
    {
        for (int rowMove = -1; rowMove < 2; rowMove += 2)
        {
            for (int colMove = -1; colMove < 2; colMove += 2)
            {
                if (rowMove == -1 && (selectedValP == 2 || isKing == true))
                {
                    if (gameBoard[selectedRowP+rowMove, selectedValP+colMove] == 3)
                    {

                    }
                }

                else if (rowMove == 1 && (selectedValP == 1 || isKing == true))
                {

                }
            }
        }
        return false;
    }


}
