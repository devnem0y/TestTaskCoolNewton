using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class WLoseWin : Widget<IEmptyWidget>
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Button _btnOk;

    public override void Init(IEmptyWidget model)
    {
        base.Init(model);
        
        _title.text = Game.Instance.State == GameState.VICTORY ? "You win!" : "You lose";
        
        _btnOk.onClick.AddListener(() =>
        {
            Game.Instance.ChangeState(GameState.MAIN);
            Hide();
        });
    }
}
