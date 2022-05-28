using UnityEngine;

public class PlayerPicker : MonoBehaviour, IPicker
{
    /* private bool PickWeapon(Weapon weapon) { */
    /*     return true; */
    /* } */
    public bool Pick(GameObject obj) {
        /* Weapon weapon; */
        /* if (obj.TryGetComponent<Weapon>(out weapon)){ */
        /*     return PickWeapon(weapon); */
        /* } */
        return true;
    }
}
