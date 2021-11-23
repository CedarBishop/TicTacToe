using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartPVPGameButton()
    {
        GameManager.instance.StartNewGame(ControllerType.Player, ControllerType.Player);
    }

    public void StartPVEGameButton()
    {
        GameManager.instance.StartNewGame(ControllerType.Player, ControllerType.AI);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
