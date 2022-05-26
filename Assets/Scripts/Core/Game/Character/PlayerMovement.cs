using UnityEngine;
using UniRx;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();

        Observable
            .EveryFixedUpdate()
            .Subscribe(_ =>
            {
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
            }).AddTo(this);
    }
}
