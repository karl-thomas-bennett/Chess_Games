using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{

    public override List<Move> GetMoves()
    {
        List<Move> moves = new List<Move>();
        for(int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(!(y == 0 && x == 0))
                {
                    moves.Add(new Move(tile, board.GetRelativeTile(tile, new Vector2(x, y))));
                }
            }
        }
        
        return moves;
    }

    public override List<Move> GetValidMoves()
    {
        List<Move> moves = GetMoves();
        List<Tile> controlled = board.GetControlled(team);
        moves.RemoveAll(move => move.to.piece != null && move.to.piece.team.Equals(team));
        moves.RemoveAll(move => controlled.FindIndex(t => t.transform.Equals(move.to.transform)) != -1);
        if(board.game.history.Find(move => move.fromId == id) == null)
        {
            if(controlled.FindIndex(t => t.transform.Equals(tile.transform)) == -1){
                bool canKingsideCastle = true;
                for(int i = 1; i <= 2; i++)
                {
                    Tile iTile = board.GetRelativeTile(tile, new Vector2(i, 0));
                    if (iTile.piece != null || controlled.FindIndex(t => t.transform.Equals(iTile.transform)) != -1){
                        canKingsideCastle = false;
                    }
                }
                if (canKingsideCastle)
                {
                    Move kingsideCastle = new Move(tile, board.GetRelativeTile(tile, new Vector2(2, 0)))
                    {
                        extraMove = new Move(board.GetRelativeTile(tile, new Vector2(3, 0)), board.GetRelativeTile(tile, new Vector2(1, 0)))
                    };
                    moves.Add(kingsideCastle);
                }
                bool canQueensideCastle = true;
                for (int i = -1; i >= -3; i--)
                {
                    Tile iTile = board.GetRelativeTile(tile, new Vector2(i, 0));
                    if (iTile.piece != null || controlled.FindIndex(t => t.transform.Equals(iTile.transform)) != -1)
                    {
                        canQueensideCastle = false;
                    }
                }
                if (canQueensideCastle)
                {
                    Move queensideCastle = new Move(tile, board.GetRelativeTile(tile, new Vector2(-2, 0)))
                    {
                        extraMove = new Move(board.GetRelativeTile(tile, new Vector2(-4, 0)), board.GetRelativeTile(tile, new Vector2(-1, 0)))
                    };
                    moves.Add(queensideCastle);
                }
            }
        }
        return moves;
    }
}
