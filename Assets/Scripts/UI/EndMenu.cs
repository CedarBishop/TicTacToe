using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void RestartGameButton()
    {
        GameManager.instance.StartAnotherGame();
    }

    public void MainMenuButton()
    {
        GameManager.instance.ReturnToMenu();
    }
}
