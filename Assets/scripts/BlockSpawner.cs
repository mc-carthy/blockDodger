using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    [SerializeField]
	private Transform [] spawnPoints;
    [SerializeField]
    private GameObject blockPrefab;

    private void Start ()
    {
        SpawnWave ();
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

}
