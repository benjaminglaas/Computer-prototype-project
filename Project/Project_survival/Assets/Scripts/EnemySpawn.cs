using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject hazard;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	[HideInInspector] public Vector3 spawnPosition;
	Vector3 spawnValues;

	void Start ()
    {
		spawnValues.x = 6.0f;
		spawnValues.y = 6.0f;
        StartCoroutine (SpawnWaves ());
    }

	void Update()
	{
		spawnValues.x = 6.0f;
		spawnValues.y = 6.0f;

		if (PlayerController.orientationPlayer == 0)
		{
			spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		}
		else if (PlayerController.orientationPlayer == 1)
		{
			spawnPosition = new Vector3(-spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
		}
		else if (PlayerController.orientationPlayer == 2)
		{
			spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -spawnValues.y, spawnValues.z);
		}
		else if (PlayerController.orientationPlayer == 3)
		{
			spawnPosition = new Vector3(spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
		}
	}

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
