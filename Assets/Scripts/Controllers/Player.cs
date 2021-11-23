using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Controller
{
    void Update()
    {
        if (!isTurn)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(inputPosition);
            if (collider && collider.GetComponent<Tile>())
            {
                if (CanSelectTile(collider.GetComponent<Tile>().tilePosition))
                {
                    SelectTile(collider.GetComponent<Tile>().tilePosition);
                }
            }
        }
    }

    public override void StartTurn()
    {
        base.StartTurn();
    }

    public override string GetControllerName()
    {
        return "Player " + controllerNumber.ToString();
    }
}
