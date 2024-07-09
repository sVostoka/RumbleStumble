using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    #region - Input -
    private DefaultInput _defaultInput;
    public DefaultInput DefaultInput { get => _defaultInput; }
    #endregion

    #region - Setting Scene -
    [SerializeField] private float _gravity = -40f;
    public float Gravity { get => _gravity; }

    #endregion

    [SerializeField] private HeroController _heroController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private WeaponController _weaponController;

    private void Awake()
    {
        instance = this;
        CharacterInitialize();
    }

    private void Start()
    {


    }

    private void Update()
    {

    }

    private void CharacterInitialize()
    {
        _defaultInput = new DefaultInput();

        _heroController.Initialize(_defaultInput);
        _cameraController.Initialize(_defaultInput);
        _weaponController.Initialise(_defaultInput, _heroController, _cameraController);

        _defaultInput.Enable();
    }
}
