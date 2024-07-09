using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class Conductor
{
    private static Stack<Scenes> _sceneStack = new();

    public static void ShowScene(Scenes scene, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        var sceneId = (int)scene;
        SceneManager.LoadScene(sceneId, loadSceneMode);
    }

    public static void AddSceneStack(Scenes scene)
    {
        _sceneStack.Push(scene);
    }
}
