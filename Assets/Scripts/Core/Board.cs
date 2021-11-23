using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
    public Tile[] tiles; // top left, top middle, top right, middle left, middle middle, middle right, bottom left, bottom middle, bottom right

    void Start()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].tilePosition = i;
        }
    }

    public bool CanSelectTile(int tilePosition)
    {
        return tiles[tilePosition].GetMarkerType() == MarkerType.None;
    }

    public void SelectTile(int tilePosition, MarkerType markerType)
    {
        tiles[tilePosition].SetMarkerType(markerType);
        if (CheckForWin(markerType))
        {
            GameManager.instance.EndGame(markerType);
        }
        else if (CheckForDraw())
        {
            GameManager.instance.EndGame(MarkerType.None);
        }
        else 
        {
            GameManager.instance.NextTurn();
        }
    }

    public bool CheckForWin(MarkerType markerType)
    {
        if ((tiles[0].GetMarkerType() == markerType && tiles[1].GetMarkerType() == markerType && tiles[2].GetMarkerType() == markerType) || // Top row
            (tiles[3].GetMarkerType() == markerType && tiles[4].GetMarkerType() == markerType && tiles[5].GetMarkerType() == markerType) || // Middle row
            (tiles[6].GetMarkerType() == markerType && tiles[7].GetMarkerType() == markerType && tiles[8].GetMarkerType() == markerType) || // bottom row
            (tiles[0].GetMarkerType() == markerType && tiles[3].GetMarkerType() == markerType && tiles[6].GetMarkerType() == markerType) || // left column
            (tiles[1].GetMarkerType() == markerType && tiles[4].GetMarkerType() == markerType && tiles[7].GetMarkerType() == markerType) || // middle column
            (tiles[2].GetMarkerType() == markerType && tiles[5].GetMarkerType() == markerType && tiles[8].GetMarkerType() == markerType) || // right column
            (tiles[0].GetMarkerType() == markerType && tiles[4].GetMarkerType() == markerType && tiles[8].GetMarkerType() == markerType) || //diagonal 1
            (tiles[2].GetMarkerType() == markerType && tiles[4].GetMarkerType() == markerType && tiles[6].GetMarkerType() == markerType)) // diagonal 2
        {
            return true;
        }
        return false;
    }

    public bool CheckForDraw()
    {
        foreach (Tile tile in tiles)
        {
            if (tile.GetMarkerType() == MarkerType.None)
            {
                return false;
            }
        }
        return true;
    }
}
