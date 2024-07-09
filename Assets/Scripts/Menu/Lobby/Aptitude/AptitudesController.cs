using TMPro;
using UnityEngine;

public class AptitudesController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private TextMeshProUGUI _speedValue;
    [SerializeField] private TextMeshProUGUI _bounceValue;
    [SerializeField] private TextMeshProUGUI _stabilityValue;
    [SerializeField] private TextMeshProUGUI _powerValue;
    [SerializeField] private TextMeshProUGUI _treatmentValue;
    [SerializeField] private TextMeshProUGUI _blockValue;
    [SerializeField] private TextMeshProUGUI _rechargeSpeedValue;
    [SerializeField] private TextMeshProUGUI _leadershipValue;
    [SerializeField] private TextMeshProUGUI _gloryValue;
    [SerializeField] private TextMeshProUGUI _incomeValue;
    [SerializeField] private TextMeshProUGUI _lossValue;

    private void Awake()
    {
        _healthValue.text = ResourceManager.instance.Aptitude.Health.Level.ToString();
        _speedValue.text = ResourceManager.instance.Aptitude.Speed.Level.ToString();
        _bounceValue.text = ResourceManager.instance.Aptitude.Bounce.Level.ToString();
        _stabilityValue.text = ResourceManager.instance.Aptitude.Stability.Level.ToString();
        _powerValue.text = ResourceManager.instance.Aptitude.Power.Level.ToString();
        _treatmentValue.text = ResourceManager.instance.Aptitude.Treatment.Level.ToString();
        _blockValue.text = ResourceManager.instance.Aptitude.Block.Level.ToString();
        _rechargeSpeedValue.text = ResourceManager.instance.Aptitude.RechargeSpeed.Level.ToString();
        _leadershipValue.text = ResourceManager.instance.Aptitude.Leadership.Level.ToString();
        _gloryValue.text = ResourceManager.instance.Aptitude.Glory.Level.ToString();
        _incomeValue.text = ResourceManager.instance.Aptitude.Income.Level.ToString();
        _lossValue.text = ResourceManager.instance.Aptitude.Loss.Level.ToString();
    }
}