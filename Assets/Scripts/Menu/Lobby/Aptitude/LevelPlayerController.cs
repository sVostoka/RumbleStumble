using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelValue;
    [SerializeField] private Slider _expValue;

    private void Awake()
    {
        _levelValue.text = ResourceManager.instance.Level.Value.ToString();
        _expValue.value = ResourceManager.instance.Level.Experience;
    }
}