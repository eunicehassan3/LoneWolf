
using UnityEngine;

public class SpawnPack : MonoBehaviour
{
    public GameObject wolfPack;
    public GameObject predator;
    public GameObject prey;

    public int predatorCount; 

    public int preyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetPredatorSpawnPoint();
        GetPreySpawnPoint();

        Vector3 spawnPoint = GetWolfPackSpawnPoint();
        wolfPack.gameObject.transform.position = spawnPoint;

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

        return new Vector3(x, wolfPack.gameObject.transform.position.y, z);
    }


    void GetPredatorSpawnPoint(){
        float x = 0;
        float z = 0;


        for(int i = 0; i < predatorCount; i++){
            x =  Random.Range(-300, 300);
            z = Random.Range(-300, 300);
            Vector3 predatorSpawnPoint = new Vector3(x, predator.gameObject.transform.position.y, z);
            Instantiate(predator, predatorSpawnPoint, predator.gameObject.transform.rotation);
        }
        

    }


    void GetPreySpawnPoint(){
        float x = 0;
        float z = 0;


        for(int i = 0; i < preyCount; i++){
            x =  Random.Range(-300, 300);
            z = Random.Range(-300, 300);
            Vector3 preySpawnPoint = new Vector3(x, prey.gameObject.transform.position.y, z);
            Instantiate(prey, preySpawnPoint, prey.gameObject.transform.rotation);
        }
        

    }
    
}
