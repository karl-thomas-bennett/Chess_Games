﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override List<Move> GetMoves()
    {
        List<Move> moves = new List<Move>();
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(0, 1)));   //Up
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(1, 1)));   //Up right
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(1, 0)));   //Right
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(1, -1)));  //Down right
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(-1, 0)));  //Down
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(-1, -1))); //Down left
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(-1, 0)));  //Left
        moves.AddRange(GetMovesInDirectionBlocked(tile, new Vector2(-1, 1)));  //Up Left
        return moves;
    }
}
