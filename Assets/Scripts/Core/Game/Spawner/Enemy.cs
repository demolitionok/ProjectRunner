using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject]
    public void Init()
    {
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }
}
