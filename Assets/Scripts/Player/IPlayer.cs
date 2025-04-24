using System;

public interface IPlayer
{
    int Health { get; }
    public event Action TakeDamage;
    
    int Coins { get; }
    public event Action ChangeCoins;
}