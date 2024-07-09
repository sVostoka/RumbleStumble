using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class AuthorsMenuController : MonoBehaviour
{
    [SerializeField] private Button _vkButton;
    [SerializeField] private Button _tgButton;
    [SerializeField] private Button _youTubeButton;
    [SerializeField] private Button _disButton;

    private void Awake()
    {
        _vkButton.onClick.AddListener(delegate { SocialButtons(SocialMedia.VK); });
        _tgButton.onClick.AddListener(delegate { SocialButtons(SocialMedia.Telegram); });
        _youTubeButton.onClick.AddListener(delegate { SocialButtons(SocialMedia.YouTube); });
        _disButton.onClick.AddListener(delegate { SocialButtons(SocialMedia.Discord); });
    }

    private Dictionary<SocialMedia, string> _socialMediaLink = new() 
    { 
        {SocialMedia.VK, "https://vk.com/vetturags"},
        {SocialMedia.Telegram, "https://t.me/vetturags"},
        {SocialMedia.YouTube, "https://www.youtube.com/@s_vostoka"},
        {SocialMedia.Discord, "https://discord.com/"},
    };  

    public void BackButton()
    {
        Conductor.ShowScene(Scenes.MainMenu);
    }

    public void SocialButtons(SocialMedia socialMedia)
    {
        Application.OpenURL(_socialMediaLink[socialMedia]);
    }
}
