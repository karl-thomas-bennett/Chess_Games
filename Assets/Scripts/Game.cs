using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    public Board board;
    Tile selected = null;
    public string turn = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PieceMovement(string team)
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.current.transform.forward);
            if(hit.collider != null)
            {
                Tile t = hit.transform.GetComponent<Tile>();
                if (Input.GetMouseButtonUp(0))
                {
                    if (selected != null)
                    {
                        Piece piece = selected.piece;
                        if (GetValidMoves(piece.GetMoves()).Contains(t))
                        {
                            selected.MoveTo(t);
                        }
                        selected.selected = false;
                    }
                    else if(t.piece != null)
                    {
                        selected = t;
                        t.selected = true;
                    }
                    else
                    {
                        selected.selected = false;
                    }
                    
                }
            }
        }
    }

    public abstract List<Tile> GetValidMoves(List<Tile> moves);
}
