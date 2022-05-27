using UnityEngine;
using UniRx;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Vector2 inputDir;
    
    
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        inputDir = new Vector2(0, 0);

        Observable
            .EveryFixedUpdate()
            .Subscribe(_ =>
            {
                inputDir.x = Input.GetAxis("Horizontal");
                inputDir.y = Input.GetAxis("Vertical");
                rb.MovePosition(rb.position + inputDir.normalized * speed * Time.deltaTime);
            }).AddTo(this);
    }
}
