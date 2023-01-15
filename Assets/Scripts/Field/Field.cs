using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    const float chipSize = 0.32f;

    [SerializeField]
    private ChipIdSO chipIdSO;
    private int[,] fieldMap;
    [SerializeField]
    private Vector2 chipStartPos;
    [SerializeField]
    private GameObject mapChipPrefab;
    public int mapLength;
    public int mapHeight;
    // Start is called before the first frame update
    void Start()
    {
        fieldMap = new int[mapLength,mapHeight];
        for(int i = 0; i < mapLength; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                Vector2 offset = new Vector2(i * chipSize, -j * chipSize);
                var go = Instantiate(mapChipPrefab, chipStartPos + offset, new Quaternion());

                if (go.GetComponent<SpriteRenderer>() == null)
                {
                    go.AddComponent<SpriteRenderer>();
                }
                int middle = mapHeight / 2;
                if (mapHeight % 2 == 1)
                {
                    middle++;
                }
                if (j == middle)
                {
                    go.GetComponent<SpriteRenderer>().sprite = chipIdSO.chipImg[fieldMap[i, j]];
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
