using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private Image _image;
    private float _fadeSpeed = 1f;
    private Color _color;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
    }

    public void Fade(IEnumerator next)
    {
        StartCoroutine(FadeCorutine());
    }

    public IEnumerator FadeCorutine()
    {
        while (_color.a < 1f)
        {
            _color.a += _fadeSpeed * Time.deltaTime;
            _image.color = _color;
            yield return null;
        }
    }

    public void Brighten()
    {
        StartCoroutine(BrightenCorutine());
    }

    private IEnumerator BrightenCorutine()
    {
        while (_color.a > 0f)
        {
            _color.a -= _fadeSpeed * Time.deltaTime;
            _image.color = _color;
            yield return null;
        }
    }
}