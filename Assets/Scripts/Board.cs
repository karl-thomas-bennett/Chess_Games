﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tiles;
    private Tile selected = null;
    public int size;
    public float scale = 10;
    public Tile tile;
    public Color selectedTileColour = new Color(1, 1, 0);
    public Color lightTileColour = new Color(0.6552599f, 0.8879172f, 0.8962264f);
    public Color darkTileColour = new Color(0.1702118f, 0.4405672f, 0.7075472f);
    public Color highlightTileColour = new Color(0.6f, 1, 0.686f);
    private Color colourOfSelectedTile;
    private float weight = 0.8f;
    //public List<Piece> pieces;
    //public List<Piece> taken;
    //public Game game;
    // Start is called before the first frame update
    void Start()
    {
        /*selected = null;
        for(int i = 0; i < tiles.Count; i++)
        {
            if(tiles[i].piece != null)
            {
                pieces.Add(tiles[i].piece);
            }
        }
        for(int i = 0; i < pieces.Count; i++)
        {
            pieces[i].id = i;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.current.transform.forward);
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
        }*/
    }

    

    public void GenerateTiles()
    {
        tiles.Clear();
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
        
        
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Tile t = Instantiate(tile, transform.position + new Vector3(x*scale, y*scale, 0), transform.rotation, transform);
                t.transform.localScale = new Vector3(scale, scale, 1);
                if((x + y) % 2 == 1)
                {
                    t.GetComponent<SpriteRenderer>().color = lightTileColour;
                }
                else
                {
                    t.GetComponent<SpriteRenderer>().color = darkTileColour;
                }
                t.board = this;
                tiles.Add(t);
            }
        }
    }

    public void SetSelected(int i)
    {
        if(selected != null)
        {
            selected.GetComponent<SpriteRenderer>().color = colourOfSelectedTile;
        }
        selected = tiles[i];
        colourOfSelectedTile = selected.GetComponent<SpriteRenderer>().color;
        selected.GetComponent<SpriteRenderer>().color = new Color(
            selectedTileColour.r * weight + colourOfSelectedTile.r * (1 - weight),
            selectedTileColour.g * weight + colourOfSelectedTile.g * (1 - weight),
            selectedTileColour.b * weight + colourOfSelectedTile.b * (1 - weight)
        );
    }
}
