using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tiles;
    private Tile selected = null;
    public int size;
    public Tile tile;
    private Color selectedColor;
    public List<Piece> pieces;
    // Start is called before the first frame update
    void Start()
    {
        selected = null;
        for(int i = 0; i < tiles.Count; i++)
        {
            if(tiles[i].piece != null)
            {
                pieces.Add(tiles[i].piece);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.current.transform.forward);
        if(hit.collider != null)
        {
            Tile t = hit.transform.GetComponent<Tile>();
            t.isMouseOver = true;
            if (Input.GetMouseButtonUp(0))
            {
                if(selected != null)
                {
                    selected.selected = false;
                }
                selected = t;
                t.selected = true;


            }
        }
    }

    

    public void GenerateTiles()
    {
        int count = transform.childCount;
        int j = 0;
        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(j).name.StartsWith("Tile")){
                DestroyImmediate(transform.GetChild(j).gameObject);
            }
            else
            {
                j++;
            }
            
        }
        tiles.Clear();
        
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Tile t = Instantiate(tile, transform.position + new Vector3(x, y, 0), transform.rotation, transform);
                t.GetComponent<SpriteRenderer>().color = new Color((x + y) % 2, (x + y) % 2, (x + y) % 2);
                t.board = this;
                tiles.Add(t);
            }
        }
    }

    public void SetSelected(int i)
    {
        selected.GetComponent<SpriteRenderer>().color = selectedColor;
        selected = tiles[i];
        selectedColor = selected.GetComponent<SpriteRenderer>().color;
        selected.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
    }
}
