using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{
    [SerializeField] private float _speedOpenDoor = 1f;

    private GameObject _doorUnion;
    private GameObject _doorInNextRoom;

    public bool openDoor = false;
    public bool closeDoor = false;

    private Vector3 _closeDoorPosition;
    private Vector3 _openDoorPosition;

    private void Awake()
    {
        _doorUnion = GameObject.Find(Constants.RoomGenerator.DOORUNION);
        _doorInNextRoom = GameObject.Find(Constants.RoomGenerator.DOORNEXTROOM);
    }

    private void FixedUpdate()
    {
        float deltaTime = Time.fixedDeltaTime;

        CheckOpenDoor(deltaTime);
    }

    public void CalculateTargetPosition()
    {
        _closeDoorPosition = new(
            _doorUnion.transform.position.x,
            _doorUnion.transform.position.y + 10f,
            _doorUnion.transform.position.z
            );
        _openDoorPosition = new(_closeDoorPosition.x, _closeDoorPosition.y + 8, _closeDoorPosition.z);
    }

    private void CheckOpenDoor(float deltaTime)
    {
        if (openDoor == true)
        {
            CalculateTargetPosition();

            OpenDoor(deltaTime);
        }

        if (closeDoor == true)
        {
            CloseDoor();
        }
    }

    private void OpenDoor(float deltaTime)
    {
        if(Vector3.Distance(_doorInNextRoom.transform.position, _openDoorPosition) > 0.01)
        {
            _doorInNextRoom.transform.position = Vector3.MoveTowards(
                _doorInNextRoom.transform.position,
                _openDoorPosition,
                _speedOpenDoor * deltaTime
            );
        }
        else
        {
            openDoor = false;
        }        
    }

    private void CloseDoor()
    {
        if (Vector3.Distance(_doorInNextRoom.transform.position, _closeDoorPosition) > 0.01)
        {
            CalculateTargetPosition();
            _doorInNextRoom.transform.position = _closeDoorPosition;
        }
        else
        {
            closeDoor = false;
        }
    }
}
