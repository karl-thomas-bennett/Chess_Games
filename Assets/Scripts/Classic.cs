using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classic : Game
{
    King blackKing;
    King whiteKing;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < board.tiles.Count; i++)
        {
            Piece piece = board.tiles[i].piece;
            if (piece.GetType() == typeof(King))
            {
                if (piece.team.Equals("White"))
                {
                    whiteKing = (King)piece;
                }
                if (piece.team.Equals("Black"))
                {
                    blackKing = (King)piece;
                }
            }
        }
        turn = "White";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override List<Tile> GetValidMoves(List<Tile> moves)
    {
        List<Tile> valid = new List<Tile>(moves);
        List<Tile> temp = new List<Tile>(valid);
        foreach(Tile t in temp)
        {
            if (t.piece.team.Equals(turn))
            {
                valid.Remove(t);
            }
        }
        temp = new List<Tile>(valid);
        foreach(Tile t in temp)
        {
            //make move
            foreach (Piece p in board.pieces)
            {
                if (p.team.Equals("Black"))
                {
                    //check if piece can take king
                }
            }
            //unmake move
        }
        
        return valid;
    }
}
