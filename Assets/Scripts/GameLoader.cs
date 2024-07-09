using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject _resourceManager;
    [SerializeField] private GameObject _settinsManager;
    [SerializeField] private GameObject _lobbyManager;

    private void Awake()
    {
        if(ResourceManager.instance == null)
        {
            Instantiate(_resourceManager);
        }

        if(SettinsManager.instance == null)
        {
            Instantiate(_settinsManager);
        }

        if (LobbyManager.instance == null)
        {
            Instantiate(_lobbyManager);
        }
    }
}
