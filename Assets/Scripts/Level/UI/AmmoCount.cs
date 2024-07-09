using TMPro;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoLeft;
    [SerializeField] private TextMeshProUGUI _ammoCount;

    [SerializeField] private WeaponController _weaponController;

    private void Update()
    {
        _ammoCount.text = _weaponController.AmmoCount.ToString();
        _ammoLeft.text = _weaponController.AmmoLeft.ToString();
    }
}
