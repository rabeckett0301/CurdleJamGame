using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] GameObject sheepPrefab;
    [SerializeField] MovementDirection movementDirection;
    [SerializeField] int numberOfSheepToSpawn;
    [SerializeField] float timeBetweenSheep;
    int sheepCount;
    bool spawningSheepRunning;

    // Start is called before the first frame update
    void Start()
    {
        sheepCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !spawningSheepRunning)
        {
            SpawnSheep();
            spawningSheepRunning = true;
        }
    }

    public void SpawnSheep()
    {
        if(sheepCount < numberOfSheepToSpawn)
        {
            StartCoroutine(HandleTimeBetweenSheep(timeBetweenSheep));
        }
    }

    IEnumerator HandleTimeBetweenSheep(float timeToWait)
    {
        GameObject sheep = Instantiate(sheepPrefab, transform.position, Quaternion.identity);
        sheep.GetComponent<SheepMovement>().SetMovementDirection(movementDirection);
        yield return new WaitForSeconds(timeToWait);
        sheepCount++;
        SpawnSheep();
    }
}
