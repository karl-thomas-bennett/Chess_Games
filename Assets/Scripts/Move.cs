using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public Tile from;
    public Tile to;
    public int fromId;
    public int toId;
    public bool endsTurn;

    public Move(Tile from, Tile to, bool endsTurn = true)
    {
        this.from = from;
        this.to = to;
        //fromId = from.piece.id;
        //toId = to.piece.id
        this.endsTurn = endsTurn;
    }

    public bool MakeMove()
    {
        return false;
    }

    public bool UndoMove()
    {
        return false;
    }

}
