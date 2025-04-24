using System;
using UnityEngine;
using UralHedgehog.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    
    [SerializeField] private Level _levelPrefab;
    
    public GameState State { get; private set; }
    private UIManager _uiManager;

    private void Awake() { Instance = this; }

    private void Start()
    {
        _uiManager = new UIManager(FindObjectOfType<UIRoot>());
        ChangeState(GameState.MAIN);
    }

    public void ChangeState(GameState state)
    {
        State = state;
        switch (State)
        {
            case GameState.MAIN:
                _uiManager.OpenViewMainMenu();
                break;
            case GameState.PLAY:
                var level = Instantiate(_levelPrefab);
                level.Run();
                _uiManager.OpenViewController(level.Player);
                _uiManager.OpenViewHud(level.Player);
                break;
            case GameState.VICTORY:
            case GameState.DEFEAT:
                _uiManager.CloseViewGameplay();
                _uiManager.OpenViewLoseWin();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Debug.Log($"<color=yellow>{state.ToString()}</color>");
    }
}