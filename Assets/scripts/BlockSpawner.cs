using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    [SerializeField]
	private Transform [] spawnPoints;
    [SerializeField]
    private GameObject blockPrefab;

    private float timeBetweenWaves = 3f;

    private void Start ()
    {
        StartCoroutine( SpawnWaveRoutine ());
    }

    private void SpawnWave ()
    {
        int randomIndex = Random.Range (0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                GameObject newBlock = Instantiate (blockPrefab, spawnPoints [i].transform.position, Quaternion.identity) as GameObject;
            }
        }
    }

    private IEnumerator SpawnWaveRoutine ()
    {
        SpawnWave ();
        yield return new WaitForSeconds (timeBetweenWaves);
        if (timeBetweenWaves > 1f)
        {
            timeBetweenWaves -= 0.2f;
        }
        StartCoroutine (SpawnWaveRoutine ());
    }

}
