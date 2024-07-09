using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CheckCorrectEnvironment : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public Transform spawnPoint;
    public Transform target;

    public LayerMask IgnorLayer;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public bool Check(float minX, float maxX, float minZ, float maxZ)
    {
        //Debug.Log("строится маршрут");

        NavMeshPath navMeshPath = new();

        RaycastHit hit = new();
        Physics.Raycast(spawnPoint.position, Vector3.down, out hit, 10, ~IgnorLayer);
        Vector3 start = hit.point;

        var distance = minX + (Math.Abs(minX) + Math.Abs(maxX)) / 2;

        Physics.Raycast(new(distance, 5, minZ - 5), Vector3.down, out hit, 10, ~IgnorLayer);
        Vector3 finish = hit.point;

        NavMesh.CalculatePath(start, finish, _navMeshAgent.areaMask, navMeshPath);

        //Instantiate(Resources.Load("Prefabs/Test") as GameObject, start, Quaternion.identity, null);
        //Instantiate(Resources.Load("Prefabs/Test") as GameObject, finish, Quaternion.identity, null);

        Vector3 lastPathPoint = navMeshPath.corners.Last();

        return navMeshPath.status == NavMeshPathStatus.PathComplete || 
            (navMeshPath.status == NavMeshPathStatus.PathPartial && lastPathPoint.x == finish.x && lastPathPoint.z == finish.z);
    }
}
