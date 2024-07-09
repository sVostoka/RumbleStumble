using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Enums;

public class PropController : MonoBehaviour
{
    System.Random rnd = new();

    [SerializeField] private TypeSizeProps _typeSize;
    public TypeSizeProps TypeSize 
    {
        get => _typeSize;
        set => _typeSize = value;
    }

    public void Spawn(List<PropForTile> props)
    {
        double prob = rnd.NextDouble();

        if (prob < Constants.PropController.PROBABILITYSPAWNPROP)
        {
            PropForTile prop = props[rnd.Next(0, props.Count)];

            GameObject gameObject = prop.pool.GetElement();
            gameObject.transform.position = transform.position;
            gameObject.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
        }
    }
}