using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override List<Move> GetMoves()
    {
        List<Move> moves = new List<Move>();
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(1, 2)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(2, 1)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(2, -1)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(1, -2)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(-1, -2)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(-2, -1)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(-2, 1)));
        AddMove(moves, board.GetRelativeTile(tile, new Vector2(-1, 2)));
        return moves;
    }
}
