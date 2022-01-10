using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public string team;
    public Tile tile;
    public int id;
    protected Board board;

    private void Start()
    {
        board = FindObjectOfType<Board>();
    }

    public abstract List<Move> GetMoves();
    public virtual List<Tile> GetControlled()
    {
        List<Tile> tiles = new List<Tile>();
        foreach (Move move in GetMoves())
        {
            tiles.Add(move.to);
        }
        return tiles;
    }
    public virtual List<Move> GetValidMoves()
    {
        List<Move> moves = GetMoves();
        moves.RemoveAll(move => move.to.piece != null && move.to.piece.team.Equals(team));
        return moves;
    }
    protected List<Move> GetMovesInDirection(Tile t, Vector2 direction)
    {
        List<Move> moves = new List<Move>();
        while (true)
        {
            t = board.GetRelativeTile(t, direction);
            if (t == null)
            {
                break;
            }
            moves.Add(new Move(tile, t));
        }
        return moves;
    }

    protected List<Move> GetMovesInDirectionBlocked(Tile t, Vector2 direction, Piece p = null)
    {
        if(p == null)
        {
            p = t.piece;
        }
        List<Move> moves = new List<Move>();
        while (true)
        {
            t = board.GetRelativeTile(t, direction);
            if (t == null)
            {
                break;
            }
            moves.Add(new Move(tile, t));
            if (t.piece != null)
            {
                break;
            }
        }
        return moves;
    }
    protected void AddMove(List<Move> moves, Tile move)
    {
        if (move != null)
        {
            moves.Add(new Move(tile, move));
        }
    }
}
