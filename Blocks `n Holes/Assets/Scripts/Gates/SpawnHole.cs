using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHole : MonoBehaviour
{

    [SerializeField] private List<GameObject> holeList;
    [SerializeField] private List<Transform> spawnPointList;

    private void Start()
    {
        SetSpawnPoints();
    }

    private void SetSpawnPoints()
    {
        spawnPointList.Clear();
        Transform[] spawnPoints = GetComponentsInChildren<Transform>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i] != transform)
            {
                spawnPointList.Add(spawnPoints[i]);
            }
        }
    }

    public void SpawnHoles(int amountOfHoles)
    {
        for (int i = 0; i < amountOfHoles; i++)
        {
            int randomSpawnPoint = Random.Range(0, spawnPointList.Count);
            int randomHole = Random.Range(0, holeList.Count);

            GameObject spawnedHole = Instantiate(holeList[randomHole]);
            spawnedHole.transform.SetParent(spawnPointList[randomSpawnPoint]);
            spawnedHole.transform.position = spawnPointList[randomSpawnPoint].position;
            spawnPointList.RemoveAt(randomSpawnPoint);
        }
    }

    public void ResetHoles()
    {
        for (int i = 0; i < GetComponentsInChildren<Hole>().Length; i++)
        {
            Destroy(GetComponentsInChildren<Hole>()[i]);
        }
        SetSpawnPoints();
    }

}
