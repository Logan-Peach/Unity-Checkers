using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBoardScript : MonoBehaviour
{
    public int[,] gameBoard;
    public int currentPlayer;
    public int selectedRowP;
    public int selectedColP;
    public int selectedValP = 0;
    public int winner = 0;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;

    public bool isKing;
    public bool doubleJump = false;
    public bool doubleJumpCheck = false;

    private void Start()
    {
        gameBoard = new int[8, 8] { 
            { 0, 1, 0, 1, 0, 1, 0, 1 }, 
            { 1, 0, 1, 0, 1, 0, 1, 0 }, 
            { 0, 1, 0, 1, 0, 1, 0, 1 },
            { 3, 0, 3, 0, 3, 0, 3, 0 },
            { 0, 3, 0, 3, 0, 3, 0, 3 },
            { 2, 0, 2, 0, 2, 0, 2, 0 },
            { 0, 2, 0, 2, 0, 2, 0, 2 },
            { 2, 0, 2, 0, 2, 0, 2, 0 } };
        System.Random random = new System.Random();
        currentPlayer = random.Next(1, 3);
        Debug.Log(currentPlayer);
    }

    private void Update()
    {
        if (playerOneScore >= 12)
        {
            winner = 1;
            currentPlayer = 0;
        }
        if (playerTwoScore >= 12)
        {
            winner = 2;
            currentPlayer = 0;
        }
        if (winner != 0)
        {
            WinnerScript.winner = winner;
            Invoke(nameof(LoadNextScene), 1f);
        }
    }

    public void TakeTurn(int row, int col)
    {
        int diffRow = selectedRowP - row;
        int diffCol = selectedColP - col;
        int jumpedPieceRow = 0;
        int jumpedPieceCol = 0;
        bool jumped = false;
        if (Math.Abs(diffRow) == 2 && Math.Abs(diffCol) == 2)
        {
            jumped = true;
            jumpedPieceRow = selectedRowP - (diffRow / 2);
            jumpedPieceCol = selectedColP - (diffCol / 2);
        }
        gameBoard[selectedRowP, selectedColP] = 3;
        gameBoard[row, col] = currentPlayer;
        if (jumped)
        {
            gameBoard[jumpedPieceRow, jumpedPieceCol] = 3;
            if (currentPlayer == 1)
            {
                playerOneScore += 1;
            }
            else if (currentPlayer == 2)
            {
                playerTwoScore += 1;
            }
            //Check to see if the player is capable of making a double jump
            doubleJumpCheck = true;
            if (ValidActions(row, col).Count() > 0)
            {
                selectedRowP = row; 
                selectedColP = col;
                doubleJump = true;
                return;
            }
        }
        //Set all values back to default and prepare for next turn
        doubleJump = false;
        doubleJumpCheck = false;
        selectedColP = 0;
        selectedRowP = 0;
        selectedValP = 0;
        isKing = false;
        if (currentPlayer == 1)
        {
            currentPlayer = 2;
            return;
        }
        else if (currentPlayer == 2)
        {
            currentPlayer = 1;
            return;
        }
    }

    public bool MakeKing()
    {
        if (isKing) { return true; } 
        else { return false; }
    }

    public List<Tuple<int, int>> ValidActions(int rowA, int colA)
    {
        int opponent = 0;
        if (currentPlayer == 1) {  opponent = 2; }
        else if (currentPlayer == 2) {  opponent = 1; }
        List<Tuple<int, int>> validActions = new List<Tuple<int, int>>();
        bool jump = false;
        for (int rowB = -1; rowB < 2; rowB += 2)
        {
            //If illegal move forward or backward for player, skip that part of the loop
            if (rowB == -1 && isKing == false && currentPlayer == 1)
            {
                continue;
            }
            if (rowB == 1 && isKing == false && currentPlayer == 2)
            {
                continue;
            }

            for (int colB = -1; colB < 2; colB += 2)
            {
                //Check for single moves
                if (rowA + rowB < 8 && rowA + rowB > -1 && colA + colB < 8 && colA + colB > -1 && !doubleJumpCheck)
                {
                    if (gameBoard[rowA + rowB, colA + colB] == 3 && !jump)
                    {
                        validActions.Add(Tuple.Create(rowA + rowB, colA + colB));
                    }
                }
                //Check for jumps
                if (rowA + rowB * 2 < 8 && rowA + rowB * 2 > -1 && colA + colB * 2 < 8 && colA + colB * 2 > -1)
                {
                    if (gameBoard[rowA + rowB, colA + colB] == opponent)
                    {
                        if (gameBoard[rowA + rowB * 2, colA + colB * 2] == 3)
                        {
                            if (!jump)
                            {
                                jump = true;
                                validActions.Clear();
                            }
                            validActions.Add(Tuple.Create(rowA + rowB * 2, colA + colB * 2));
                        }
                    }
                }
            }
        }
        return validActions;
    }

    //Use to call invoke for a delay before scene changes
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Kept for potential MiniMax implementation in the future
    public List<Tuple<int, int>> AllValidStates()
    {
        List<Tuple<int, int>> validStates = new List<Tuple<int, int>>();
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (gameBoard[row, col] == currentPlayer)
                {
                    if (ValidActions(row, col).Count > 0)
                    {
                        validStates.Add(Tuple.Create(row, col));
                    }
                }
            }
        }
        return validStates;
    }
}
