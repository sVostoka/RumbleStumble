using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] private Image _label;
    [SerializeField] private Button _forwardButton;
    [SerializeField] private Button _backButton;

    private int _last;

    private Dictionary<int, Sprite> _labels;
    public Dictionary<int, Sprite> Labels 
    {
        get { return _labels; }
        set
        {
            _labels = value;
            _last = value.Count - 1;
        }
    }
    public int Index { get; set; }

    private void Start()
    {
        _label.sprite = Labels[Index];

        _forwardButton.onClick.AddListener(ClickForwardButton);
        _backButton.onClick.AddListener(ClickBackButton);
    }

    private void ClickForwardButton()
    {
        Index++;

        if (Index > _last) Index = 0;

        ShowChange();
    }

    private void ClickBackButton()
    {
        Index--;

        if (Index < 0) Index = _last;
        
        ShowChange();
    }

    private void ShowChange()
    {
        _label.sprite = _labels[Index];
    }

}
