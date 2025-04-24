using Cinemachine;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _spawnPlayerPoint;
    [SerializeField] private GameObject _playerPrefab;

    public Player Player { get; private set; }

    public void Run()
    {
        PlayerSpawn();
    }
    
    private void PlayerSpawn()
    {
        Player = Instantiate(_playerPrefab, _spawnPlayerPoint.position, Quaternion.identity, transform).GetComponent<Player>();
        FindObjectOfType<CinemachineVirtualCamera>().Follow = Player.transform;
        Player.TakeDamage += OnTakeDamagePlayer;
        Player.Finish += OnFinishPlayer;
    }

    private void OnTakeDamagePlayer()
    {
        if (Player.Health <= 0)
        {
            Game.Instance.ChangeState(GameState.DEFEAT);
            Destroy(gameObject);
        }
        else
        {
            var t = Player.transform;
            t.position = _spawnPlayerPoint.position;
            t.rotation = Quaternion.identity;
        }
    }
    
    private void OnFinishPlayer()
    {
        Game.Instance.ChangeState(GameState.VICTORY);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Player.TakeDamage -= OnTakeDamagePlayer;
        Player.Finish -= OnFinishPlayer;
    }
}
