using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override List<Move> GetMoves()
    {
        List<Move> moves = new List<Move>();
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(0, 1)));   //Up
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(1, 0)));   //Right
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(0, -1)));  //Down
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(-1, 0)));  //Left
        return moves;
    }
}
