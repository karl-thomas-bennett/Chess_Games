using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor;
    //public bool isPossibleMove = false;
    public bool isMouseOver = false;
    public bool selected = false;
    public Piece piece;
    //public Color moveColor = Color.cyan;
    //public Color mouseMoveColor = Color.green;
    //public Color mouseColor = Color.yellow;
    public Board board;
    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<SpriteRenderer>().color;
        gameObject.AddComponent<BoxCollider2D>();
        /*if(piece != null)
        {
            piece.tile = this;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
        
        /*if (isPossibleMove)
        {
            GetComponent<SpriteRenderer>().color = baseColor / 2 + moveColor / 2;
            if (isMouseOver)
            {
                GetComponent<SpriteRenderer>().color = baseColor / 2 + mouseMoveColor / 2;
            }
        }else if (isMouseOver)
        {
            GetComponent<SpriteRenderer>().color = baseColor / 2 + mouseColor / 2;
        }

        //Board will set this to true again if the mouse is still over
        isMouseOver = false;*/
    }
    /*
    public void MoveTo(Tile tile)
    {
        if(tile.piece != null)
        {
            TakePiece(tile.piece);
        }
        tile.piece = piece;
        piece = null;
    }

    public void TakePiece(Piece piece)
    {
        board.pieces.Remove(piece);
        board.taken.Add(piece);
    }*/
}
