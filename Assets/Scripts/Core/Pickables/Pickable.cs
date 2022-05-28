using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Pickable : MonoBehaviour
{
    public void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(collision =>
            {
                IPicker picker;
                if (collision.TryGetComponent<IPicker>(out picker))
                {
                    Debug.Log($"{this} collided with {nameof(IPicker)}:{picker}");
                    if (picker.Pick(gameObject))
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.Log($"Collided object is not {nameof(IPicker)}");
                }
            }).AddTo(this);
    }
}
