using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tiles;
    public int selected = 0;
    public int size;
    public Tile tile;
    private Color selectedColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                tiles.Add(t);
            }
        }
    }

    public void SetSelected(int i)
    {
        tiles[selected].GetComponent<SpriteRenderer>().color = selectedColor;
        selected = i;
        selectedColor = tiles[selected].GetComponent<SpriteRenderer>().color;
        tiles[selected].GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);

    }
}
