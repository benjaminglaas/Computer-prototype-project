using UnityEngine;
using System.Collections;

public class EnemyFollowSpawn : MonoBehaviour {

    public GameObject hazard;
	public Vector3 spawnValues;
    public int hazardCount;
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
            spawnValues.x = 0.0f;
            spawnValues.y = 5.0f;

        }
        else if (PlayerController.orientationPlayer == 1)
        {
            spawnValues.x = -5.0f;
            spawnValues.y = 0.0f;
        }
        else if (PlayerController.orientationPlayer == 2)
        {
            spawnValues.x = 0.0f;
			spawnValues.y = -5.0f;
        }
        else if (PlayerController.orientationPlayer == 3)
        {
            spawnValues.x = 5.0f;
            spawnValues.y = 0.0f;
        }
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(waveWait);
        }
    }
}

