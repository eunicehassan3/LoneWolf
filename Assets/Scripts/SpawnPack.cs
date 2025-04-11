
using UnityEngine;

public class SpawnPack : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // int xVal = Random.Range(xMin,0);
        // int zVal = Random.Range(zMin,zMax);

        Vector3 spawnPoint = GetWolfPackSpawnPoint();
        gameObject.transform.position = spawnPoint;
        // Instantiate(gameObject, spawnPoint, gameObject.transform.rotation);
    }
    Vector3 GetWolfPackSpawnPoint()
    {
        float min = 330f;
        float max = 450f;

        float x = 0 ;
        float z = 0;

        
        int side = Random.Range(0, 4);

        float randomCoord = Random.Range(-max, max);
        float fixedCoord = Random.Range(min, max);

        switch (side)
        {
            case 0: // Top
                x = randomCoord;
                z = fixedCoord;
                break;
            case 1: // Bottom
                x = randomCoord;
                z = -fixedCoord;
                break;
            case 2: // Left
                x = -fixedCoord;
                z = randomCoord;
                break;
            case 3: // Right
                x = fixedCoord;
                z = randomCoord;
                break;
        }

        return new Vector3(x, gameObject.transform.position.y, z);
    }
    
}
