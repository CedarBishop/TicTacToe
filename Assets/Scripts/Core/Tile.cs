using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MarkerType markerType = MarkerType.None;
    public int tilePosition;

    public GameObject noughtSprite;
    public GameObject crossSprite;

    public Sprite idleSprite;
    public Sprite hoveredSprite;
    public Sprite pressedSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                spriteRenderer.sprite = pressedSprite;
                break;
            case MarkerType.Crosses:
                crossSprite.SetActive(true);
                spriteRenderer.sprite = pressedSprite;
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

    //private void Update()
    //{
    //    if (markerType == MarkerType.None)
    //    {
    //        Vector3 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Collider2D collider = Physics2D.OverlapPoint(inputPosition);
    //        spriteRenderer.sprite = collider != null && collider.gameObject == gameObject ? hoveredSprite : idleSprite;
    //    }
    //}
}
