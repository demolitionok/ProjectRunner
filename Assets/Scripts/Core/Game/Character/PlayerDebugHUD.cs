using UnityEngine;
using UniRx;
using TMPro;

public class PlayerDebugHUD : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private TextMeshProUGUI pos;
    [SerializeField] private TextMeshProUGUI vel;

    void Start()
    {
        player
            .ObserveEveryValueChanged(transform => transform.position)
            .Subscribe(position => pos.text = position.ToString()).AddTo(this);
        playerRb
            .ObserveEveryValueChanged(rb => rb.velocity)
            .Subscribe(velocity => vel.text = velocity.ToString()).AddTo(this);
    }
}
