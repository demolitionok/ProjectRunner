using Zenject;
using UnityEngine;
using UniRx;

public class CameraMovement : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float followSpeed = 0.1f;

    [Inject]
    private void Init(Player player) {
        _target = player.transform;
    }

    void Start()
    {
        Observable
            .EveryLateUpdate()
            .Where(_ => transform.position != _target.position)
            .Subscribe(_ =>
            {
                var newPosition = Vector3.Lerp(transform.position, _target.position, followSpeed);
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            });
    }
}
