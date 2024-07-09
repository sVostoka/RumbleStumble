using UnityEngine;

public static class SpriteConverter
{
    public static Sprite GetSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }
}
