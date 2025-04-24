using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class PController : Widget<IController>
{
    [SerializeField] private UHButtonHandler _btnLeft;
    [SerializeField] private UHButtonHandler _btnRight;
    [SerializeField] private Button _btnJump;

    public override void Init(IController model)
    {
        base.Init(model);
        _btnLeft.Click += Model.SetDirection;
        _btnRight.Click += Model.SetDirection;
        _btnJump.onClick.AddListener(Model.SetJump);
    }

    private void OnDestroy()
    {
        _btnLeft.Click -= Model.SetDirection;
        _btnRight.Click -= Model.SetDirection;
    }
}
