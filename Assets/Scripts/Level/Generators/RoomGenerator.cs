using System;
using UnityEngine;
using static Enums;

public class RoomGenerator : MonoBehaviour
{
    System.Random rnd = new();

    [SerializeField] private float _minXSizeRoom = 30.0f;
    [SerializeField] private float _maxXSizeRoom = 40.0f;

    [SerializeField] private float _minZSizeRoom = 45.0f;
    [SerializeField] private float _maxZSizeRoom = 60.0f;

    PoolBase<GameObject> _leftWallPool;
    PoolBase<GameObject> _rightWallPool;
    PoolBase<GameObject> _backWallPool;
    PoolBase<GameObject> _frontWallPool;

    PoolBase<GameObject> _leftDoorWallPool;
    PoolBase<GameObject> _rightDoorWallPool;

    private GameObject _leftWall;
    private GameObject _rightWall;
    private GameObject _backWall;
    private GameObject _frontWall;

    private GameObject _doorUnion;

    private GameObject _doorNextRoom;
    private GameObject _leftDoorWall;
    private GameObject _rightDoorWall;

    private Vector3 _leftWallSize;
    private Vector3 _rightWallSize;
    private Vector3 _backWallSize;
    private Vector3 _frontWallSize;

    private void Awake()
    {
        GetObjectlWalls();
        SetWallsPool();
    }

    public (float, float, float, float) Generate()
    {
        ClearCloneWalls();

        ShiftWalls();
        FillWalls();

        return GetBorderRoomForSpawn();
    }

    private void GetObjectlWalls()
    {
        _leftWall = GameObject.Find(Constants.RoomGenerator.LEFTWALL);
        _rightWall = GameObject.Find(Constants.RoomGenerator.RIGHTWALL);
        _backWall = GameObject.Find(Constants.RoomGenerator.BACKWALL);
        _frontWall = GameObject.Find(Constants.RoomGenerator.FRONTWALL);

        _doorUnion = GameObject.Find(Constants.RoomGenerator.DOORUNION);

        _doorNextRoom = GameObject.Find(Constants.RoomGenerator.DOORNEXTROOM);
        _leftDoorWall = GameObject.Find(Constants.RoomGenerator.LEFTDOORWALL);
        _rightDoorWall = GameObject.Find(Constants.RoomGenerator.RIGHTDOORWALL);

        _leftWallSize = _leftWall.GetComponentInChildren<Collider>().bounds.size;
        _rightWallSize = _rightWall.GetComponentInChildren<Collider>().bounds.size;
        _backWallSize = _backWall.GetComponentInChildren<Collider>().bounds.size;
        _frontWallSize = _frontWall.GetComponentInChildren<Collider>().bounds.size;
    }

    private void SetWallsPool()
    {
        _leftWallPool = new(delegate { return Preload(_leftWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);
        _rightWallPool = new(delegate { return Preload(_rightWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);
        _backWallPool = new(delegate { return Preload(_backWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);
        _frontWallPool = new(delegate { return Preload(_frontWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);

        _leftDoorWallPool = new(delegate { return Preload(_leftDoorWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);
        _rightDoorWallPool = new(delegate { return Preload(_rightDoorWall); }, GetAction, ReturnAction, Constants.RoomGenerator.PRELOADCOUNT);
    }

    private void ClearCloneWalls()
    {
        _leftWallPool.ReturnAll();
        _rightWallPool.ReturnAll();
        _backWallPool.ReturnAll();
        _frontWallPool.ReturnAll();

        _leftDoorWallPool.ReturnAll();
        _rightDoorWallPool.ReturnAll();
    }

    private void ShiftWalls()
    {
        Vector3 positionRightWall = new(
            _leftWall.transform.localPosition.x - CalculateFloatValue(_minXSizeRoom, _maxXSizeRoom),
            _leftWall.transform.localPosition.y,
            _leftWall.transform.localPosition.z
            );

        Vector3 positionFrontWall = new(
            _backWall.transform.localPosition.x,
            _backWall.transform.localPosition.y,
            _backWall.transform.localPosition.z - CalculateFloatValue(_minZSizeRoom, _maxZSizeRoom)
            );

        _rightWall.transform.localPosition = positionRightWall;
        _frontWall.transform.localPosition = positionFrontWall;
    }

    private void FillWalls()
    {
        var (distanceHorizontal, distanceVertical) = GetDistance();

        SpawnWall(_backWall, _backWallPool, _frontWall, _frontWallPool, distanceHorizontal, Axis.Horizontal, Side.Right);
        SpawnWall(_leftWall, _leftWallPool, _rightWall, _rightWallPool, distanceVertical, Axis.Vertical, Side.Top);
        ShiftDoor(distanceHorizontal);
        FillDoorWalls();
    }

    private void SpawnWall(GameObject left, PoolBase<GameObject> leftPool, 
                           GameObject right, PoolBase<GameObject> rightPool,
                           float distance, Axis axis, Side side)
    {
        SpawnFillWall(left, leftPool, distance, axis, side);
        SpawnFillWall(right, rightPool, distance, axis, side);
    }

    private void ShiftDoor(float distanceHorizontal)
    {
        _doorUnion.transform.position = new(
            _leftWall.transform.position.x - _leftWallSize.x / 2 - distanceHorizontal / 2,
            _doorUnion.transform.position.y,
            _frontWall.transform.position.z + Constants.RoomGenerator.DISTANCEDOOR
            );
    }

    private void FillDoorWalls()
    {
        float sizeDoor = _doorNextRoom.GetComponent<Collider>().bounds.size.x;
        float distanceRightWall = Math.Abs(_doorNextRoom.transform.position.x + sizeDoor / 2 - _rightWall.transform.position.x);
        float distanceLeftWall = Math.Abs(_doorNextRoom.transform.position.x - sizeDoor / 2 - _leftWall.transform.position.x);

        SpawnFillWall(_rightDoorWall, _rightDoorWallPool, distanceRightWall, Axis.Horizontal, Side.Right);
        SpawnFillWall(_leftDoorWall, _leftDoorWallPool, distanceLeftWall, Axis.Horizontal, Side.Left);
    }

    private void SpawnFillWall(GameObject parentWall, PoolBase<GameObject> pool, float distance, Axis axis, Side side)
    {
        Vector3 parentWallSize = parentWall.GetComponentInChildren<Collider>().bounds.size;

        float sizeWall = axis == Axis.Horizontal ? parentWallSize.x : parentWallSize.z;       
        int countWall = (int)Math.Ceiling(distance / sizeWall);

        int sideSign = side == Side.Left || side == Side.Bottom ? -1 : 1;

        for (int i = 1; i < countWall; i++)
        {
            Vector3 position = axis == Axis.Horizontal ?
                new(parentWall.transform.position.x - (sizeWall - Constants.RoomGenerator.OFFSETWALL) * i * sideSign,
                    parentWall.transform.position.y,
                    parentWall.transform.position.z) :
                new(parentWall.transform.position.x,
                    parentWall.transform.position.y,
                    parentWall.transform.position.z - (sizeWall - Constants.RoomGenerator.OFFSETWALL) * i * sideSign);

            GameObject wall = pool.GetElement();
            wall.transform.position = position;
        }
    }

    private float CalculateFloatValue(float left, float right)
    {
        return (float)(rnd.NextDouble() * (right - left) + left);
    }

    private (float, float) GetDistance()
    {
        float distanceHorizontal = Math.Abs(_leftWall.transform.position.x) + Math.Abs(_rightWall.transform.position.x) - (_leftWallSize.x / 2 + _rightWallSize.x / 2);
        float distanceVertical = Math.Abs(_backWall.transform.position.z) + Math.Abs(_frontWall.transform.position.z) - (_backWallSize.z / 2 + _frontWallSize.z / 2);

        return (distanceHorizontal, distanceVertical);
    }

    private (float, float, float, float) GetBorderRoomForSpawn()
    {
        float minX = _rightWall.transform.position.x + _rightWallSize.x / 2;
        float maxX = _leftWall.transform.position.x - _leftWallSize.x / 2;

        float minZ = _doorUnion.transform.position.z + 15;
        float maxZ = _backWall.transform.position.z - 35;

        return (minX, maxX, minZ, maxZ);
    }

    public GameObject Preload(GameObject gameObject) => Instantiate(gameObject, this.gameObject.transform);

    public void GetAction(GameObject gameObject) => gameObject.SetActive(true);

    public void ReturnAction(GameObject gameObject) => gameObject.SetActive(false);
}
