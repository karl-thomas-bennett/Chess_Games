using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class Board_Creator : Editor
{
    Board board;

    private void OnSceneGUI()
    {
        board = (Board)target;
        Handles.color = Color.green;
        for(int i = 0; i < board.tiles.Count; i++)
        {
            if(Handles.Button(board.tiles[i].transform.position, Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
            {
                board.SetSelected(i);
            }
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Board board = (Board)target;
        if (GUILayout.Button("Generate Board"))
        {
            board.GenerateTiles();
        }
    }
}
