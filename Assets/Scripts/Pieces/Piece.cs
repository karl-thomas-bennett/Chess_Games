using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public Tile tile;
    public string team;

    public abstract List<Tile> GetMoves();

    public void HighlightPossibleMoves()
    {
        List<Tile> tiles = GetMoves();
        foreach(Tile t in tiles){
            t.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
    
    public void Return()
    {
        transform.position = tile.transform.position;
    }

}
