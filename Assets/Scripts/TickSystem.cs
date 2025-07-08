using UnityEngine;

public class TickSystem : MonoBehaviour
{
    public static float tickInterval = 0.3f;

    private float _tickerTimer;

    public delegate void TickAction();
    public static event TickAction OnTickAction;

    private void Update()
    {
        _tickerTimer += Time.deltaTime;

        if(_tickerTimer > tickInterval)
        {
            _tickerTimer = 0;
            TickEvent();
        }
    }

    private void TickEvent()
    {
        OnTickAction?.Invoke();
    }
}
