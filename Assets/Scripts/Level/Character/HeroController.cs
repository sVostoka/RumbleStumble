using System;
using System.Configuration;
using UnityEngine;
using static Constants;

public class HeroController : MonoBehaviour
{
    private bool _isInitialized = false;

    #region - References -
    [Header ("References")]
    [SerializeField] private Transform _feetTransform;
    [SerializeField] private LayerMask _heroMask;
    #endregion

    #region - Spawn -
    [SerializeField] private Transform _spawnPoint;
    public Transform SpawnPoint { get => _spawnPoint; }

    #endregion

    #region - Move -
    private CharacterController _characterController;
    private Vector2 _inputMovement;

    [Header ("Walk / Sprint")]
    [SerializeField] private float _heroWalkSpeed = 10.0f;
    [SerializeField] private float _heroSprintSpeed = 20.0f;
    private bool _isSprinting;
    public bool IsSprinting { get => _isSprinting; }

    private bool _isStay;
    public bool IsStay { get => _isStay; }

    private float _speed;
    public float Speed 
    { 
        get => _speed; 
        private set
        {
            _speed = value;
            AnimationSpeed = _characterController.velocity.magnitude / value;
        }
    }

    [Header ("Jump")]
    [SerializeField] private float jumpHeight = 3.0f;
    private Vector3 _jumpingVelocity;
    #endregion

    #region - Stance -
    [Header ("Stance")]
    [SerializeField] private HeroStance _heroStandStance;
    public HeroStance HeroStandStance { get => _heroStandStance; }

    [SerializeField] private HeroStance _heroCrouchStance;
    public HeroStance HeroCrouchStance { get => _heroCrouchStance; }

    private Enums.HeroStance _heroStance;
    public Enums.HeroStance HeroStance { get => _heroStance; }
    #endregion

    #region - Animation -
    private float _animationSpeed;
    public float AnimationSpeed { 
        get => _animationSpeed; 
        private set
        {
            _animationSpeed = value;

            if(_animationSpeed > 1)
            {
                _animationSpeed = 1;
            }

            if(_animationSpeed == 0) _animationSpeed = 1;
        }
    }
    #endregion

    #region - Value -
    private float _health = 100;
    public float Health { 
        get => _health; 
        private set 
        {
            _health = value;

            if(_health <= 0)
            {
                Conductor.ShowScene(Enums.Scenes.Campaign);
            }
        } 
    }
    #endregion

    public void Initialize(DefaultInput defaultInput)
    {
        _characterController = GetComponent<CharacterController>();

        defaultInput.Character.Movement.performed += obj => _inputMovement = obj.ReadValue<Vector2>();
        defaultInput.Character.Jump.performed += obj => Jump();
        defaultInput.Character.Crouch.started += obj => Crouch();
        defaultInput.Character.Crouch.canceled += obj => Crouch();
        defaultInput.Character.Sprint.started += obj => Sprint();
        defaultInput.Character.Sprint.canceled += obj => Sprint();

        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized)
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {
        if(_characterController.velocity.magnitude == 0)
        {
            _isStay = true;
            _isSprinting = false;
        }
        else
        {
            _isStay = false;
        }

        Speed = _isSprinting ? _heroSprintSpeed : _heroWalkSpeed;

        float verticalSpeed = Speed * _inputMovement.y * Time.deltaTime;
        float horizontalSpeed = Speed * _inputMovement.x * Time.deltaTime;

        Vector3 newMovementSpeed = new(horizontalSpeed, 0, verticalSpeed);
        newMovementSpeed = transform.TransformDirection(newMovementSpeed);

        if (_characterController.isGrounded && _jumpingVelocity.y < 0)
        {
            _jumpingVelocity.y = -2f;
        }

        _jumpingVelocity.y += GameSceneManager.instance.Gravity * Time.deltaTime;
        newMovementSpeed += _jumpingVelocity * Time.deltaTime;

        _characterController.Move(newMovementSpeed);
    }

    private void Jump()
    {
        if (_characterController.isGrounded && _heroStance == Enums.HeroStance.Stand)
        {
            _jumpingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * GameSceneManager.instance.Gravity);
        }
    }

    private void Crouch()
    {
        if (_heroStance == Enums.HeroStance.Crouch)
        {
            _heroStance = Enums.HeroStance.Stand;

            _heroStandStance.stanceCollider.enabled = true;
            _heroCrouchStance.stanceCollider.enabled = false;
        }
        else
        {
            _heroStance = Enums.HeroStance.Crouch;

            _heroStandStance.stanceCollider.enabled = false;
            _heroCrouchStance.stanceCollider.enabled = true;
        }
    }

    private void Sprint()
    {
        if (!_isStay)
        {
            _isSprinting = !_isSprinting;
        }
    }

    public void MoveToSpawnPoint()
    {
        _characterController.transform.position = _spawnPoint.position;
    }

    public void MoveToEnemy(Vector3 target)
    {
        _characterController.transform.position = target;
    }

    public void StopControll()
    {
        _characterController.enabled = false;
    }

    public void ResumeControll()
    {
        _characterController.enabled = true;
    }

    public void Damage(int damage)
    {
        Health -= damage;
    }
}

[Serializable]
public class HeroStance
{
    public float cameraHeight;
    public CapsuleCollider stanceCollider;
}
