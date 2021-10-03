using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public string team;
    public Tile tile;
    public int id;

    public abstract List<Move> GetMoves();
}
