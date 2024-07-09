using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Material _material;

    private Terrain _terrain;
    private Texture2D _texture;
    private Color32[] _colors;

    private int _width;
    private int _height;

    private float _perimeter;

    private void Awake()
    {
        _terrain = GetComponent<Terrain>();
        _height = Constants.TerrainGenerator.HEIGHT;
        _width = Constants.TerrainGenerator.WIDTH;
    }

    public void Generate()
    {
        _perimeter = (_width + _height) * 2;

        float[,] heightsMap = new float[_width, _width];

        _texture = new Texture2D(_width, _width);
        _colors = new Color32[_width * _width];

        DrawPlasma(_width, _width);

        _texture.SetPixels32(_colors);
        _texture.Apply();

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                heightsMap[i, j] = _texture.GetPixel(i, j).grayscale * Constants.TerrainGenerator.ROUGHNESS;
            }
        }

        ChangeTerrain(_terrain, _width, heightsMap);
    }

    private void ChangeTerrain(Terrain terrain, int resolution, float[,] heights)
    {
        terrain.terrainData.size = new Vector3(_width, _width, _height);
        terrain.terrainData.heightmapResolution = resolution;
        terrain.terrainData.SetHeights(0, 0, heights);
        terrain.materialTemplate = _material;
    }

    private void DrawPlasma(float width, float height)
    {
        float leftUp, rightUp, leftDown, rightDown;

        leftUp = Random.value;
        rightUp = Random.value;
        leftDown = Random.value;
        rightDown = Random.value;

        Divide(0.0f, 0.0f, width, height, leftUp, rightUp, leftDown, rightDown);
    }

    private float Displace(float num)
    {
        float max = num / _perimeter * Constants.TerrainGenerator.GRAINCOEFF;
        return Random.Range(-0.5f, 0.5f) * max;
    }

    private void Divide(float x, float y, float width, float height, float leftUp, float rightUp, float leftDown, float rightDown)
    {

        float newWidth = width / 2.0f;
        float newHeight = height / 2.0f;

        if (width < 1.0f && height < 1.0f)
        {
            float c = (leftUp + rightUp + leftDown + rightDown) / 4.0f;
            _colors[(int)x + (int)y * _width] = new Color(c, c, c);
        }

        else
        {
            float middle = (leftUp + rightUp + leftDown + rightDown) / 4.0f + Displace((newWidth + newHeight) * 2);
            float edge1 = (leftUp + rightUp) / 2.0f;
            float edge2 = (rightUp + leftDown) / 2.0f;
            float edge3 = (leftDown + rightDown) / 2.0f;
            float edge4 = (rightDown + leftUp) / 2.0f;

            if (middle <= 0)
            {
                middle = 0;
            }
            else if (middle > 1.0f)
            {
                middle = 1.0f;
            }

            Divide(x, y, newWidth, newHeight, leftUp, edge1, middle, edge4);
            Divide(x + newWidth, y, newWidth, newHeight, edge1, rightUp, edge2, middle);
            Divide(x + newWidth, y + newHeight, newWidth, newHeight, middle, edge2, leftDown, edge3);
            Divide(x, y + newHeight, newWidth, newHeight, edge4, middle, edge3, rightDown);
        }
    }
}