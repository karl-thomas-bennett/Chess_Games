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

    public bool MakeMove()
    {
        return false;
    }

    public bool UndoMove()
    {
        return false;
    }

}
