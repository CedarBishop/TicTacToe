using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Board boardPrefab;
    public Player playerPrefab;
    public Ai aiPrefab;

    private Board boardInstance;

    public Controller controllerOne { get; set; }
    public Controller controllerTwo { get; set; }

    public MarkerType currentTurn { get; set; }

    public int controllerOneScore;
    public int controllerTwoScore;

    public static event System.Action<Controller> newTurnEvent;
    public static event System.Action scoreUpdatedEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UIManager.instance.CurrentUIState = UIState.Main;
    }


    private void StartGame(ControllerType playerOneControllerType, ControllerType playerTwoControllerType)
    {
        if (controllerOne)
        {
            Destroy(controllerOne.gameObject);
        }
        if (controllerTwo)
        {
            Destroy(controllerTwo.gameObject);
        }

        if (playerOneControllerType == ControllerType.Player)
        {
            controllerOne = Instantiate(playerPrefab);
        }
        else
        {
            controllerOne = Instantiate(aiPrefab);
        }

        if (playerTwoControllerType == ControllerType.Player)
        {
            controllerTwo = Instantiate(playerPrefab);
        }
        else
        {
            controllerTwo = Instantiate(aiPrefab);
        }

        if (boardInstance)
        {
            Destroy(boardInstance.gameObject);
        }
        boardInstance = Instantiate(boardPrefab);
        controllerOne.markerType = MarkerType.Crosses;
        controllerOne.controllerNumber = 1;
        controllerTwo.markerType = MarkerType.Noughts;
        controllerTwo.controllerNumber = 2;
        currentTurn = (Random.Range(0, 2) == 0) ? MarkerType.Crosses : MarkerType.Noughts;
        Controller controller = GetControllerFromMarkerType(currentTurn);
        controller.StartTurn();
        UIManager.instance.CurrentUIState = UIState.Game;
        newTurnEvent?.Invoke(controller);
    }

    public void StartNewGame(ControllerType playerOneControllerType, ControllerType playerTwoControllerType)
    {
        controllerOneScore = 0;
        controllerTwoScore = 0;
        StartGame(playerOneControllerType, playerTwoControllerType);
    }

    public void StartAnotherGame()
    {
        ControllerType controllerOneType = (controllerOne.GetComponent<Player>() != null)? ControllerType.Player : ControllerType.AI;
        ControllerType controllerTwoType = (controllerTwo.GetComponent<Player>() != null)? ControllerType.Player : ControllerType.AI;
        StartGame(controllerOneType, controllerTwoType);
    }

    public void EndGame(MarkerType winningMarker)
    {
        Controller controller = GetControllerFromMarkerType(winningMarker);
        if (controller && controller.controllerNumber == 1)
        {
            controllerOneScore++;
        }
        else if(controller && controller.controllerNumber == 2)
        {
            controllerTwoScore++;
        }
        scoreUpdatedEvent?.Invoke();
        UIManager.instance.CurrentUIState = UIState.End;
        SoundManager.instance.PlaySFX("GameOver");
    }

    public void NextTurn()
    {
        if (currentTurn == MarkerType.Noughts)
        {
            currentTurn = MarkerType.Crosses;
        }
        else if (currentTurn == MarkerType.Crosses)
        {
            currentTurn = MarkerType.Noughts;
        }
        Controller controller = GetControllerFromMarkerType(currentTurn);
        controller?.StartTurn();
        newTurnEvent?.Invoke(controller);
    }

    public Board GetBoard()
    {
        return boardInstance;
    }

    public Controller GetControllerFromMarkerType(MarkerType markerType)
    {
        if (controllerOne && controllerOne.markerType == markerType)
        {
            return controllerOne;
        }
        if (controllerTwo &&  controllerTwo.markerType == markerType)
        {
            return controllerTwo;
        }
        return null;
    }

    public void ReturnToMenu()
    {
        UIManager.instance.CurrentUIState = UIState.Main;
        if (boardInstance)
        {
            Destroy(boardInstance.gameObject);
        }
    }
}
