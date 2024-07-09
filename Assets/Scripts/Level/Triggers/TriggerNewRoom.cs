using UnityEngine;

public class TriggerNewRoom : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;

    private LevelGenerator _levelGenerator;

    private TriggerOpenDoor _triggerTemp;

    private void Awake()
    {
        _levelGenerator = FindObjectOfType<LevelGenerator>();
        _triggerTemp = FindObjectOfType<TriggerOpenDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HeroController>() != null)
        {
            _triggerTemp.closeDoor = true;
            _triggerTemp.openDoor = false;

            Regenerate();
        }
    }

    void Regenerate()
    {
        _levelGenerator.GenerateLevel();
    }
}
