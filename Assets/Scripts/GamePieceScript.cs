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

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected()
    {
        if (pieceColor == boardScript.currentPlayer)
        {
            boardScript.selectedRow = row;
            boardScript.selectedCol = col;
            boardScript.selectedVal = pieceColor;
        }

        if (boardScript.selectedVal == boardScript.currentPlayer)
        {

        }
    }
}
