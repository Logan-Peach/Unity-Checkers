using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePieceScript : MonoBehaviour
{
    [SerializeField] private GameBoardScript boardScript;
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private Image whitePiece;
    [SerializeField] private Image whitePieceKing;
    [SerializeField] private Image redPiece;
    [SerializeField] private Image redPieceKing;
    [SerializeField] private Image emptySpace;
    private int pieceColor;
    private Image img;
    private bool isKing;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        isKing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected()
    {
        if (pieceColor == boardScript.currentPlayer)
        {
            boardScript.selectedRowP = row;
            boardScript.selectedColP = col;
            boardScript.selectedValP = pieceColor;
            boardScript.isKing = this.isKing;
        }

        else if (boardScript.selectedValP != 0 && pieceColor != boardScript.currentPlayer && boardScript.IsValidTurn(row, col))
        {
            boardScript.selectedRowOpp = row;
            boardScript.selectedColOpp = col;
            boardScript.selectedValOpp = pieceColor;
            boardScript.TakeTurn();
        }
    }
}
