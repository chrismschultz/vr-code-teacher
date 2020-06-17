using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class ButtonSpawnerManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float obstacleCheckRadius = 3f;
    public int maxSpawnAttemptsPerObstacle = 30;
    public int totalSpawned;

    public ButtonListener increaseButton;
    public ButtonListener decreaseButton;

    public List<GameObject> spawnedObjects = new List<GameObject>();
    private Vector3 offset;
    private GameObject Obstacle;

    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCube();
        SpawnCube();
        SpawnCube();

        increaseButton.controllable.MaxLimitReached += IncreasedPressed;
        decreaseButton.controllable.MaxLimitReached += DecreasePressed;
    }

    public virtual void IncreasedPressed(object sender, ControllableEventArgs e)
    {
        SpawnCube();
    }

    public virtual void DecreasePressed(object sender, ControllableEventArgs e)
    {
        DestroyCube();
    }

    // Update is called once per frame
    void Update()
    {
        totalSpawned = spawnedObjects.Count;

        GetComponentInParent<ifListenCount>().condition.leftVal = totalSpawned;


    }

    public void DestroyCube()
    {
        if(spawnedObjects.Count-1 > 0)
        {
            
            Destroy(spawnedObjects[spawnedObjects.Count - 1]);
            spawnedObjects.RemoveAt(spawnedObjects.Count - 1);
        }
        
    }

    public void SpawnCube()
    {
        offset = transform.position;
        totalSpawned = 0;

        //Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
        Obstacle = prefabToSpawn;

        // Create a position variable
        Vector3 position = Vector3.zero;

        // whether or not we can spawn in this position
        bool validPosition = false;

        // How many times we've attempted to spawn this obstacle
        int spawnAttempts = 0;

        // While we don't have a valid position 
        //  and we haven't tried spawning this obstable too many times
        while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
        {
            // Increase our spawn attempts
            spawnAttempts++;

            Vector3 randPos = new Vector3(0, Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

            position = offset + randPos;

            // Pick a random position

            // This position is valid until proven invalid
            validPosition = true;

            // Collect all colliders within our Obstacle Check Radius
            // Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

            Collider[] colliders = Physics.OverlapSphere(position + Obstacle.transform.position, obstacleCheckRadius);


            // Go through each collider collected
            foreach (Collider col in colliders)
            {
                //Debug.Log("Hit collider");
                // If this collider is tagged "Obstacle"
                //if (col.tag == "Cube")
                //{
                // Then this position is not a valid spawn position
                validPosition = false;
                //}
            }
        }

        // If we exited the loop with a valid position
        if (validPosition)
        {
            // Spawn the obstacle here
            GameObject spawnedObject = Instantiate(Obstacle, position + Obstacle.transform.position, Quaternion.identity);
            spawnedObject.transform.parent = this.transform;

            spawnedObjects.Add(spawnedObject);

            totalSpawned++;
        }
    }



}
