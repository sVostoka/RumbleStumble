using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _hpValue;
    [SerializeField] private HeroController _heroController;

    private void Update()
    {
        _hpValue.value = _heroController.Health;
    }
}
