using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Text controllerOneScoreText;
    public Text controllerTwoScoreText;
    public Text controllerOneNameText;
    public Text controllerTwoNameText;
    public GameObject controllerOneTurnHighlight;
    public GameObject controllerTwoTurnHighlight;

    private void OnEnable()
    {
        GameManager.scoreUpdatedEvent += UpdateScoreUI;
        GameManager.newTurnEvent += UpdateTurnUI;
        UpdateScoreUI();
        UpdateTurnUI(GameManager.instance.GetControllerFromMarkerType(GameManager.instance.currentTurn));
    }

    private void OnDisable()
    {
        GameManager.scoreUpdatedEvent -= UpdateScoreUI;
        GameManager.newTurnEvent -= UpdateTurnUI;
    }

    void UpdateScoreUI()
    {
        controllerOneScoreText.text = GameManager.instance.controllerOneScore.ToString();
        controllerTwoScoreText.text = GameManager.instance.controllerTwoScore.ToString();
    }

    void UpdateTurnUI(Controller controller)
    {
        
    }
}
