using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Move> GetMoves()
    {
        List<Move> moves = new List<Move>();
        if (team.Equals("White"))
        {
            for(int i = -1; i <= 1; i++)
            {
                if(i != 0)
                    AddMove(moves, board.GetRelativeTile(tile, new Vector2(i, 1)));
            }
        }
        if (team.Equals("Black"))
        {
            for (int i = -1; i <= 1; i++)
            {
                if (i != 0)
                    AddMove(moves, board.GetRelativeTile(tile, new Vector2(i, -1)));
            }
        }
        return moves;
    }

    public override List<Move> GetValidMoves()
    {
        List<Move> moves = GetMoves();
        moves.RemoveAll(move => move.to.piece == null || move.to.piece.team.Equals(team));
        Tile inFront = board.GetRelativeTile(tile, new Vector2(0, team.Equals("White") ? 1 : -1));
        if (inFront.piece == null)
        {
            AddMove(moves, inFront);
            if (board.game.history.FindIndex(move => move.fromPiece.id == id) == -1)
            {
                inFront = board.GetRelativeTile(inFront, new Vector2(0, team.Equals("White") ? 1 : -1));
                AddMove(moves, inFront);
            }
        }
        return moves;
    }
}
