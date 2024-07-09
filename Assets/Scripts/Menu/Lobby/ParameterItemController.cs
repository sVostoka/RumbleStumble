using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterItemController : MonoBehaviour
{
    [SerializeField] private Image _label;

    public Image Label
    {
        get => _label;
        set => _label = value;
    }

    [SerializeField] private TextMeshProUGUI _value;

    public TextMeshProUGUI Value
    {
        get => _value;
        set => _value = value;
    }
}