using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class AllTerrainHeight : MonoBehaviour
{
    
    private int terrainWidth = 500;
    private int terrainLength = 500;
    private float minHeight;
    private float minX;
    private float minZ;
    
    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;
        Debug.Log(terrain.terrainData.size);
        minHeight = 0;
        //Vector3 position = this.transform.position;     //現在の位置を取得
        using (StreamWriter sw = new StreamWriter(@"C:\Users\yukin\Downloads\test_TerrainHeight.txt", false, Encoding.GetEncoding("Shift_JIS")))
        {
            for(int i = -500; i < terrainLength ; i++){
                for(int j = -500; j < terrainWidth; j++){
                    float h = terrain.terrainData.GetInterpolatedHeight(i / terrain.terrainData.size.x, j / terrain.terrainData.size.z);
                    if(minHeight < h){
                        minHeight = h;
                        minX = i;
                        minZ = j;
                    }
                    sw.Write(i / terrain.terrainData.size.x);
                    sw.Write(" ,");
                    sw.Write(j / terrain.terrainData.size.z);
                    sw.Write(" ( ");
                    sw.Write(i);
                    sw.Write(", ");
                    sw.Write(j);
                    sw.Write(") : ");
                    sw.WriteLine(h);
                }
            }
            Debug.Log(minHeight);
            this.gameObject.transform.position = new Vector3(minX, minHeight, minZ);
        }
        //  posisionのx,z座標に対応する、terrainの高さ（y座標）を取得
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}