using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePieceScript : MonoBehaviour
{
    [SerializeField] private GameBoardScript boardScript;
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private Sprite whitePiece;
    [SerializeField] private Sprite whitePieceKing;
    [SerializeField] private Sprite redPiece;
    [SerializeField] private Sprite redPieceKing;
    [SerializeField] private Sprite emptySpace;
    [SerializeField] private Sprite highlightedSpace;
    private Button button;
    private int pieceColor;
    private Image img;
    private bool isKing;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        button = this.GetComponent<Button>();
        isKing = false;
    }

    // Update is called once per frame
    void Update()
    {
        pieceColor = boardScript.gameBoard[row, col];
        if (pieceColor == 3) { img.sprite = emptySpace; }
        if (pieceColor == 1) { img.sprite = whitePiece; }
        if (pieceColor == 2) {  img.sprite = redPiece; }
        if (pieceColor == 1 && isKing) { img.sprite = whitePieceKing; }
        if (pieceColor == 2 && isKing) { img.sprite = redPieceKing; }
        if (boardScript.gameBoard[row, col] == 3) { isKing = false; }

        if (boardScript.ValidActions(boardScript.selectedRowP, boardScript.selectedColP).Contains(Tuple.Create(row, col)) && StartScript.learningMode)
        {
            img.sprite = highlightedSpace;
        }
    }

    public void Selected()
    {
        if (pieceColor == boardScript.currentPlayer && !boardScript.doubleJump)
        {
            boardScript.selectedRowP = row;
            boardScript.selectedColP = col;
            boardScript.selectedValP = pieceColor;
            boardScript.isKing = this.isKing;;
        }

        else if (boardScript.selectedValP != 0 && pieceColor != boardScript.currentPlayer && boardScript.ValidActions(boardScript.selectedRowP, boardScript.selectedColP).Contains(Tuple.Create(row,col)))
        {
            if (boardScript.currentPlayer == 1 && row == 7)
            {
                isKing = true;
            }
            if (boardScript.currentPlayer == 2 && row == 0)
            {
                isKing = true;
            }
            if (boardScript.MakeKing())
            {
                isKing = true;
            }
            boardScript.TakeTurn(row, col);
        }
    }
}
