using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard != null && keyboard.spaceKey.wasPressedThisFrame)
        {
            weapon.TryFire();
        }
    }
}