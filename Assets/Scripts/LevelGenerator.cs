using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Texture2D map;
    [SerializeField] ColorToPrefab[] colorMappings;
    [SerializeField] float offset = 5;
    [SerializeField] Material wallMaterial1;
    [SerializeField] Material wallMaterial2;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        print(pixelColor);
        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            print(colorMapping.color);
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;

                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }

    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        ColorTheWalls();
    }

    private void ColorTheWalls()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Wall"))
            {
                foreach(Transform grandchild in child)
                {
                    if (Random.Range(0, 100) % 2 == 0)
                    {
                        grandchild.gameObject.GetComponent<Renderer>().material = wallMaterial1;
                    } 
                    else
                    {
                        grandchild.gameObject.GetComponent<Renderer>().material = wallMaterial2;
                    }
                    
                }
            }
        }
    }
}
