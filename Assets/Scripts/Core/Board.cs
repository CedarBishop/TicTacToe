using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
    public Tile[] tiles; // top left, top middle, top right, middle left, middle middle, middle right, bottom left, bottom middle, bottom right
    public Vector3Int[] setsToWin; 

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
        SoundManager.instance.PlaySFX("PlaceMarker");
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
        foreach (Vector3Int set in setsToWin)
        {
            if (tiles[set.x].GetMarkerType() == markerType && tiles[set.y].GetMarkerType() == markerType && tiles[set.z].GetMarkerType() == markerType)
            {
                return true;
            }
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

    public int CalculateBestMove(MarkerType markerType)
    {
        if (tiles[4].GetMarkerType() == MarkerType.None)
        {
            return 4;
        }
        foreach (Vector3Int set in setsToWin)
        {
            if (tiles[set.x].GetMarkerType() == markerType && tiles[set.y].GetMarkerType() == markerType && tiles[set.z].GetMarkerType() == MarkerType.None)
            {
                return set.z;
            }
            if (tiles[set.x].GetMarkerType() == markerType && tiles[set.y].GetMarkerType() == MarkerType.None && tiles[set.z].GetMarkerType() == markerType)
            {
                return set.y;
            }
            if (tiles[set.x].GetMarkerType() == MarkerType.None && tiles[set.y].GetMarkerType() == markerType && tiles[set.z].GetMarkerType() == markerType)
            {
                return set.x;
            }
        }
        MarkerType oppositeMarkerType = markerType == MarkerType.Crosses ? MarkerType.Noughts : MarkerType.Crosses;
        foreach (Vector3Int set in setsToWin)
        {
            if (tiles[set.x].GetMarkerType() == oppositeMarkerType && tiles[set.y].GetMarkerType() == oppositeMarkerType && tiles[set.z].GetMarkerType() == MarkerType.None)
            {
                return set.z;
            }
            if (tiles[set.x].GetMarkerType() == oppositeMarkerType && tiles[set.y].GetMarkerType() == MarkerType.None && tiles[set.z].GetMarkerType() == oppositeMarkerType)
            {
                return set.y;
            }
            if (tiles[set.x].GetMarkerType() == MarkerType.None && tiles[set.y].GetMarkerType() == oppositeMarkerType && tiles[set.z].GetMarkerType() == oppositeMarkerType)
            {
                return set.x;
            }
        }

        int randTileNumber = -1;
        do
        {
            randTileNumber = Random.Range(0, 9);
        } while (!CanSelectTile(randTileNumber));
        return randTileNumber;
    }
}

