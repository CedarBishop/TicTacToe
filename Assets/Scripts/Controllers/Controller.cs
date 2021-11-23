using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerType {Player, AI }
public enum MarkerType { Noughts, Crosses, None}

public class Controller : MonoBehaviour
{
    public MarkerType markerType { get; set; }
    public int controllerNumber;
    protected bool isTurn = false;

    public virtual void StartTurn()
    {
        isTurn = true;
    }

    protected bool CanSelectTile(int tilePosition)
    {
        return GameManager.instance.GetBoard().CanSelectTile(tilePosition);
    }

    protected void SelectTile(int tilePosition)
    {
        GameManager.instance.GetBoard().SelectTile(tilePosition, markerType);
        isTurn = false;
    }

    public virtual string GetControllerName()
    {
        return "";
    }
}
