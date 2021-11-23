using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState { Main, Game, End}
public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public MainMenu mainMenu;
    public GameMenu gameMenu;
    public EndMenu endMenu;


    private UIState currentUIState;
    public UIState CurrentUIState
    {
        get { return currentUIState; }
        set 
        {
            UIState oldUIState = currentUIState;
            currentUIState = value;
            OnUIStateChanged(oldUIState, currentUIState);
        }
    }

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
        CurrentUIState = UIState.Main;
    }

    private void OnUIStateChanged(UIState oldState, UIState newState)
    {
        mainMenu.gameObject.SetActive(false);
        gameMenu.gameObject.SetActive(false);
        endMenu.gameObject.SetActive(false);

        switch (newState)
        {
            case UIState.Main:
                mainMenu.gameObject.SetActive(true);
                break;
            case UIState.Game:
                gameMenu.gameObject.SetActive(true);
                break;
            case UIState.End:
                gameMenu.gameObject.SetActive(true);
                endMenu.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
