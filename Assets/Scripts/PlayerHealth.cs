using UnityEngine.Events;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent IsDeadEvent;
    public UnityEvent PickedHeart;

    public void PickedHeartEvent()
    {
        PickedHeart.Invoke();
    }

    public void DeadEvent()
    {
        IsDeadEvent.Invoke();
    }
}
