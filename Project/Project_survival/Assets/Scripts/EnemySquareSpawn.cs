using UnityEngine;
using System.Collections;

public class EnemySquareSpawn : MonoBehaviour {

    public GameObject hazard1;
    public GameObject hazard2;
    public Vector3 spawnValues1;
    public Vector3 spawnValues2;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (PlayerController.orientationPlayer == 0)
        {
            spawnValues1.x = 3.4F;
            spawnValues1.y = 3.4F;

            spawnValues2.x = -3.4F;
            spawnValues2.y = 3.4F;

        }
        else if (PlayerController.orientationPlayer == 1)
        {
            spawnValues1.x = -3.4F;
            spawnValues1.y = 3.4F;

            spawnValues2.x = -3.4F;
            spawnValues2.y = -3.4F;
        }
        else if (PlayerController.orientationPlayer == 2)
        {
            spawnValues1.x = -3.4F;
            spawnValues1.y = -3.4F;

            spawnValues2.x = 3.4F;
            spawnValues2.y = -3.4F;
        }
        else if (PlayerController.orientationPlayer == 3)
        {
            spawnValues1.x = 3.4F;
            spawnValues1.y = -3.4F;

            spawnValues2.x = 3.4F;
            spawnValues2.y = 3.4F;
        }
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition1 = new Vector3(spawnValues1.x, spawnValues1.y, spawnValues1.z);
                Vector3 spawnPosition2 = new Vector3(spawnValues2.x, spawnValues2.y, spawnValues2.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard1, spawnPosition1, spawnRotation);
                Instantiate(hazard2, spawnPosition2, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
