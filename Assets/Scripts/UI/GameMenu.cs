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
    public Color controllerOneTurnHighlight;
    public Color controllerTwoTurnHighlight;

    private void OnEnable()
    {
        GameManager.scoreUpdatedEvent += UpdateScoreUI;
        GameManager.newTurnEvent += UpdateTurnUI;
        UpdateScoreUI();
        UpdateTurnUI(GameManager.instance.GetControllerFromMarkerType(GameManager.instance.currentTurn));
        UpdateNameUI();
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
        controllerOneNameText.color = Color.white;
        controllerTwoNameText.color = Color.white;
        if (controller == GameManager.instance.controllerOne)
        {
            controllerOneNameText.color = controllerOneTurnHighlight;
        }

        if (controller == GameManager.instance.controllerTwo)
        {
            controllerTwoNameText.color = controllerTwoTurnHighlight;
        }
        UpdateNameUI();
    }

    void UpdateNameUI()
    {
        if (!GameManager.instance.controllerOne || !GameManager.instance.controllerTwo)
        {
            return;
        }
        controllerOneNameText.text = GameManager.instance.controllerOne.GetControllerName();
        controllerTwoNameText.text = GameManager.instance.controllerTwo.GetControllerName();
    }
}
