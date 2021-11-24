using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : Controller
{
    [Range(0.0f, 1.0f)]
    public float aiDifficulty;
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
        int bestMove = GameManager.instance.GetBoard().CalculateBestMove(markerType);
        do
        {
            randTileNumber = Random.Range(0, 9);
        } while (!CanSelectTile(randTileNumber));

        SelectTile(Random.Range(0.0f, 1.0f) > aiDifficulty ? randTileNumber : bestMove);
    }
}
