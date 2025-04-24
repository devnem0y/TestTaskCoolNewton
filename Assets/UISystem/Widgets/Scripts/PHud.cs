using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class PHud : Widget<IPlayer>
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _lblCoins;

    public override void Init(IPlayer model)
    {
        base.Init(model);
        
        _sliderHealth.maxValue = Model.Health;
        Model.TakeDamage += OnPlayerTakeDamage;

        _lblCoins.text = $"{Model.Coins}";
        Model.ChangeCoins += OnPlayerChangeCoins;
    }

    private void OnPlayerTakeDamage()
    {
        _sliderHealth.value = Model.Health;
    }
    
    private void OnPlayerChangeCoins()
    {
        _lblCoins.text = $"{Model.Coins}";
    }

    private void OnDestroy()
    {
        Model.TakeDamage -= OnPlayerTakeDamage;
        Model.ChangeCoins -= OnPlayerChangeCoins;
    }
}
