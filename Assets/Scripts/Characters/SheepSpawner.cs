using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] GameEvent OnSheepSpawn;
    [SerializeField] GameObject sheepPrefab;
    [SerializeField] MovementDirection movementDirection;
    [SerializeField] int numberOfSheepToSpawn;
    [SerializeField] float timeBetweenSheep;
    int sheepCount;
    bool spawningSheepRunning;

    [Header("Audio Clip")]
    [SerializeField] AudioClip[] spawnSounds;

    // Start is called before the first frame update
    void Start()
    {
        sheepCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !spawningSheepRunning)
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
        OnSheepSpawn?.Raise();
        GetComponent<AudioSource>().PlayOneShot(spawnSounds[Random.Range(0, spawnSounds.Length)]);
        yield return new WaitForSeconds(timeToWait);
        sheepCount++;
        SpawnSheep();
    }
}
