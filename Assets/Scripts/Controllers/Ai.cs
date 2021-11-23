using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : Controller
{
    public override void StartTurn()
    {
        base.StartTurn();

        StartCoroutine("CoDecideMove");
    }

    public override string GetControllerName()
    {
        return "AI";
    }

    IEnumerator CoDecideMove()
    {
        yield return new WaitForSeconds(1);

        int randTileNumber = -1;
        do
        {
            randTileNumber = Random.Range(0, 9);
        } while (!CanSelectTile(randTileNumber));

        SelectTile(randTileNumber);
    }
}
