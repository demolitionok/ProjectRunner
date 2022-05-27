using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 0.1f;

    void Start()
    {
        Observable
            .EveryLateUpdate()
            .Where(_ => transform.position != target.position)
            .Subscribe(_ =>
            {
                var newPosition = Vector3.Lerp(transform.position, target.position, followSpeed);
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            });
    }
}
