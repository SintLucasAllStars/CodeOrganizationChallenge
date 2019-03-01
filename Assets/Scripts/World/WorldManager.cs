using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{
    public float DayLength;
    public GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFoodAtRandomPoint();
    }


    void SpawnFoodAtRandomPoint()
    {
        float maxDistance = 20;
        Vector3 randomPosition = Random.insideUnitSphere * maxDistance;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPosition, out hit, maxDistance, 1);
        Instantiate(foodPrefab, hit.position, Quaternion.identity);
        StartCoroutine(FoodSpawnDelay());
    }


    IEnumerator FoodSpawnDelay()
    {
        yield return new WaitForSeconds(10);
        SpawnFoodAtRandomPoint();
    }
}
