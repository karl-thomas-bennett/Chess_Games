using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public Tile from;
    public Tile to;
    public Piece fromPiece;
    public Piece toPiece;
    public bool endsTurn;
    public Move extraMove = null;

    public Move(Tile from, Tile to, bool endsTurn = true)
    {
        this.from = from;
        this.to = to;
        fromPiece = from.piece;
        toPiece = to.piece;
        this.endsTurn = endsTurn;
    }

    public bool MakeMove(Game game)
    {
        game.history.Add(this);
        from.MoveTo(to);
        if(extraMove != null)
        {
            extraMove.MakeMove(game);
        }
        return true;
    }

    public bool UndoMove(Game game)
    {
        if (extraMove != null)
        {
            extraMove.UndoMove(game);
        }
        game.history.Remove(this);
        from.piece = fromPiece;
        to.piece = toPiece;
        return true;
    }

}
