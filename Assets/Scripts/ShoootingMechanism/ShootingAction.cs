using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    public UnityEvent action;

    public void Shoot()
    {
        action?.Invoke();
    }
}
