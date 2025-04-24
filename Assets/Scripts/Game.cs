using System;
using UnityEngine;
using UralHedgehog.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    private UIManager _uiManager;
    [SerializeField] private Player _player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _uiManager = new UIManager(FindObjectOfType<UIRoot>());
        ChangeState(GameState.MAIN);
    }

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.MAIN:
                Debug.Log("<color=yellow>Main</color>");
                _uiManager.OpenViewMainMenu();
                break;
            case GameState.PLAY:
                Debug.Log("<color=yellow>Play</color>");
                //_uiManager.OpenViewHud();
                _uiManager.OpenViewController(_player);
                break;
            case GameState.VICTORY:
                Debug.Log("<color=yellow>Victory</color>");
                _uiManager.OpenViewLoseWin();
                break;
            case GameState.DEFEAT:
                Debug.Log("<color=yellow>Defeat</color>");
                _uiManager.OpenViewLoseWin();
                break;
                
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}