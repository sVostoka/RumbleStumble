using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private HeroController _heroController;
    private CameraController _cameraController;

    #region - Spawn -
    [SerializeField] private GameObject _parentSpawn;
    private SceneWeapon _currentWeapon;
    #endregion

    #region - Animation -
    [Header("References")]
    [SerializeField] private Animator _weaponAnimator;

    [Header("Sway")]
    [SerializeField] private float _swayAmount;
    [SerializeField] private float _swaySmoothing;
    [SerializeField] private float _swayResetSmoothing;
    [SerializeField] private float _swayClampX;
    [SerializeField] private float _swayClampY;

    private bool _isInitialised = false;

    private Vector3 _newWeaponRotation;
    private Vector3 _newWeaponRotationVelocity;

    private Vector3 _targetWeaponRotation;
    private Vector3 _targetWeaponRotationVelocity;
    #endregion

    #region - Shooting -
    [Header ("Camera")]
    [SerializeField] private Camera _mainCamera;
    private RaycastHit _raycastHit;
    public LayerMask _ignorLayer;
    private bool _isShooting;
    private bool _readyToShoot;
    private bool _reloading;

    [Header ("Settings")]
    [SerializeField] private int _damage;
    [SerializeField] private float _rangeAtack;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _isAutomatic;
    [SerializeField] private int _ammoCount;
    public int AmmoCount { get => _ammoCount; }

    private int _ammoLeft;
    public int AmmoLeft { get => _ammoLeft; }

    #endregion

    #region - Recoil -
    [Header("Recoil")]
    [SerializeField] private CameraRecoil _cameraRecoil;
    #endregion

    [SerializeField] private GameObject _bulletHolePrefab;
    [SerializeField] private float _bulletHoleLifeSpan;

    private void Start()
    {
        _newWeaponRotation = transform.localRotation.eulerAngles;
    }

    public void Initialise(DefaultInput defaultInput, HeroController heroController, CameraController cameraController)
    {
        _currentWeapon = Instantiate(Resources.Load<SceneWeapon>("Prefabs/Weapons/Weapon 14"), _parentSpawn.transform.position, Quaternion.identity, _parentSpawn.transform);

        defaultInput.Character.Shoot.started += obj => StartShoot();
        defaultInput.Character.Shoot.canceled += obj => EndShoot();

        defaultInput.Character.Reload.performed += obj => Reload();

        _heroController = heroController;
        _cameraController = cameraController;

        _ammoLeft = _ammoCount;
        _readyToShoot = true;

        _isInitialised = true;
    }

    private void Update()
    {
        if (_isInitialised)
        {
            CalculateWeaponRotation();
            SetWeaponAnimations();

            if(_isShooting && _readyToShoot && !_reloading && !_heroController.IsSprinting)
            {
                if (_ammoLeft > 0)
                {
                    PerformShoot();
                }
                else
                {
                    Reload();
                }
            }
        }
    }

    #region - Animation -

    private void CalculateWeaponRotation()
    {
        _weaponAnimator.speed = _heroController.AnimationSpeed;

        _targetWeaponRotation.y += _swayAmount * _cameraController.InputView.x * Time.deltaTime;
        _targetWeaponRotation.x += _swayAmount * _cameraController.InputView.y * Time.deltaTime;

        _targetWeaponRotation.y = Math.Clamp(_targetWeaponRotation.y, -_swayClampY, _swayClampY);
        _targetWeaponRotation.x = Math.Clamp(_targetWeaponRotation.x, _swayClampX, _swayClampX);
        _targetWeaponRotation.z = _targetWeaponRotation.y;

        _targetWeaponRotation = Vector3.SmoothDamp(_targetWeaponRotation, Vector3.zero, ref _targetWeaponRotationVelocity, _swayResetSmoothing);
        _newWeaponRotation = Vector3.SmoothDamp(_newWeaponRotation, _targetWeaponRotation, ref _newWeaponRotationVelocity, _swaySmoothing);

        transform.localRotation = Quaternion.Euler(_newWeaponRotation);
    }

    private void SetWeaponAnimations()
    {
        _weaponAnimator.SetBool("isSprinting", _heroController.IsSprinting);
        _weaponAnimator.SetBool("isStay", _heroController.IsStay);
    }
    #endregion

    #region - Shooting -
    private void StartShoot()
    {
        _isShooting = true;
    }

    private void EndShoot()
    {
        _isShooting = false;
    }

    private void PerformShoot()
    {
        _readyToShoot = false;

        if(Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out _raycastHit, _rangeAtack, _ignorLayer))
        {
            if (_raycastHit.collider.gameObject.GetComponentInParent<EnemyController>())
            {
                EnemyController enemy = _raycastHit.collider.gameObject.GetComponentInParent<EnemyController>();
                enemy.Damage(_damage, _raycastHit);
            }
            else if (_raycastHit.collider.gameObject.GetComponent<Terrain>())
            {
                Debug.Log("Земля");
            }
            else
            {
                //GameObject bulletHole = Instantiate(_bulletHolePrefab, _raycastHit.point + _raycastHit.normal * 0.001f, Quaternion.FromToRotation(Vector3.up, _raycastHit.normal));
                //Destroy(bulletHole, _bulletHoleLifeSpan);
            }
        }

        _currentWeapon.muzzleFlash.Play();

        _cameraRecoil.ShootRecoil();

        _ammoLeft--;

        if(_ammoLeft >= 0 )
        {
            Invoke("ResetShoot", _fireRate);

            if (!_isAutomatic)
            {
                EndShoot();
            }
        }
    }

    private void ResetShoot()
    {
        _readyToShoot = true;
    }

    private void Reload()
    {
        _reloading = true;
        Invoke("ReloadFinish", _reloadTime);
    }

    private void ReloadFinish()
    {
        _ammoLeft = _ammoCount;
        _reloading = false;
    }

    #endregion
}
