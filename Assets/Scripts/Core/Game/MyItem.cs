using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MyItem : MonoBehaviour
{
    public event Action OnPickUp;

    public void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(collision =>
            {
                IPicker picker;
                if (collision.TryGetComponent<IPicker>(out picker))
                {
                    Debug.Log(picker);
                    if (picker.Pick(gameObject))
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.Log("No picker");
                }
            }).AddTo(this);
    }
}
