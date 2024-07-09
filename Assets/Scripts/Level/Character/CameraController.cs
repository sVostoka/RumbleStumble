using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    System.Random rnd = new();

    private bool _isInitialized = false;

    #region - References -
    [Header ("References")]
    [SerializeField] private Transform _cameraHolder;

    private HeroController _heroController;
    #endregion

    #region - Input -
    private Vector2 _inputView;
    public Vector2 InputView { get => _inputView; }
    #endregion

    #region - View -
    [Header ("View Clamp")]
    [SerializeField] private float _viewClampYMin = -65;
    [SerializeField] private float _viewClampYMax = 65;

    private Vector3 _newCameraRotation;
    private Vector3 _newCharacterRotation;

    private float _cameraHeight;
    private float _cameraHeightVelocity;

    [Header ("Stance")]
    [SerializeField] private float _stanceSmoothing;
    #endregion

    public void Initialize(DefaultInput defaultInput)
    {
        _heroController = GetComponent<HeroController>();

        defaultInput.Character.View.performed += obj => _inputView = obj.ReadValue<Vector2>();

        _newCameraRotation = _cameraHolder.localRotation.eulerAngles;
        _newCharacterRotation = transform.localRotation.eulerAngles;

        _cameraHeight = _cameraHolder.localPosition.y;

        _isInitialized = true;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (_isInitialized)
        {
            CalculateView();
            CalculateCameraHeight();
        }
    }

    private void CalculateView()
    {
        _newCharacterRotation.y += SettinsManager.instance.General.Sensitivity * 350 * _inputView.x * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(_newCharacterRotation);

        _newCameraRotation.x += SettinsManager.instance.General.Sensitivity * 350 *
            (SettinsManager.instance.General.InvertY == 1 ? _inputView.y : -_inputView.y) * Time.deltaTime;
        _newCameraRotation.x = Math.Clamp(_newCameraRotation.x, _viewClampYMin, _viewClampYMax);

        _cameraHolder.localRotation = Quaternion.Euler(_newCameraRotation);
    }

    public void CalculateCameraHeight()
    {
        float stanceHeight = _heroController.HeroStandStance.cameraHeight;

        if (_heroController.HeroStance == Enums.HeroStance.Crouch)
        {
            stanceHeight = _heroController.HeroCrouchStance.cameraHeight;
        }

        _cameraHeight = Mathf.SmoothDamp(_cameraHolder.localPosition.y, stanceHeight, ref _cameraHeightVelocity, _stanceSmoothing);
        _cameraHolder.localPosition = new Vector3(_cameraHolder.localPosition.x, _cameraHeight, _cameraHolder.localPosition.z);
    }
}