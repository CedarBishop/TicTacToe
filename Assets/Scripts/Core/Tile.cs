using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MarkerType markerType = MarkerType.None;
    public int tilePosition;

    public GameObject noughtSprite;
    public GameObject crossSprite;

    private void Start()
    {
        SetMarkerType(MarkerType.None);
    }

    public void SetMarkerType(MarkerType newMarkerType)
    {
        if (markerType != MarkerType.None)
        {
            return;
        }
        markerType = newMarkerType;
        noughtSprite.SetActive(false);
        crossSprite.SetActive(false);
        switch (newMarkerType)
        {
            case MarkerType.Noughts:
                noughtSprite.SetActive(true);
                break;
            case MarkerType.Crosses:
                crossSprite.SetActive(true);
                break;
            case MarkerType.None:
                break;
            default:
                break;
        }
    }

    public MarkerType GetMarkerType()
    {
        return markerType;
    }
}
