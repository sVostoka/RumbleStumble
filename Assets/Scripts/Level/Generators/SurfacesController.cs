using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

public class SurfacesController : MonoBehaviour
{
    private List<NavMeshSurface> navMeshes = new();

    private void Start()
    {
        navMeshes = FindObjectsByType<NavMeshSurface>(FindObjectsSortMode.None).ToList();
        navMeshes = navMeshes.OrderByDescending(element => element.name).ToList();
    }

    public IEnumerator UpdateMesh()
    {
        foreach (var surface in navMeshes)
        {
            AsyncOperation async = surface.UpdateNavMesh(surface.navMeshData);

            yield return new WaitUntil(() => async.isDone);

            //Debug.Log(surface.name + " " + async.progress + " " + async.isDone + " isDone");
        }

        //Debug.Log("все isDone");
        yield return new WaitForEndOfFrame();
    }
}