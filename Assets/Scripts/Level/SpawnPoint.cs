using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        Instantiate(_player, transform.position, Quaternion.identity);
    }
}