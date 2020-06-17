using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public int cubeID;

    public int ObsToPlace = 10;
    //public GameObject[] Obstacles = new GameObject[0];
    public List<GameObject> Obstacles = new List<GameObject>();

    public List<GameObject> spawnedObjects = new List<GameObject>();

    GameObject Obstacle;

    public float obstacleCheckRadius = 3f;
    public int maxSpawnAttemptsPerObstacle = 10;

    public Vector3 offset;

    public int totalSpawned;


    Vector3 gizmoPos;
    float gizmoRad;

    void OnEnable()
    {
        startComparison();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startComparison();
        }
    }

    public void startComparison()
    {
        offset = transform.position;
        totalSpawned = 0;

        if(spawnedObjects.Count > 0)
        {
            foreach (GameObject spawned in spawnedObjects)
            {
                Destroy(spawned);
            }

            spawnedObjects.Clear();
        }


        SpawnCubes();

        if(spawnedObjects.Count == 0)
        {

            SpawnCubes();
        }

        EnvironmentCompare parentCompare = GetComponentInParent<EnvironmentCompare>();

        if (cubeID == 0)
        {
            parentCompare.val1 = totalSpawned;
        }
        else if (cubeID == 1)
        {
            parentCompare.val2 = totalSpawned;
        }
    }


    public void SpawnCubes()
    {
        int objectPlaceNum = (int)Random.Range(0f, ObsToPlace);
        Debug.Log(objectPlaceNum);

        for (int i = 0; i < objectPlaceNum; i++)
        {
            //Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            Obstacle = Obstacles[0];

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
                    Debug.Log("Hit collider");
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

                gizmoPos = position + Obstacle.transform.position;
                gizmoRad = obstacleCheckRadius;

                spawnedObject.transform.parent = this.transform;

                spawnedObjects.Add(spawnedObject);

                totalSpawned++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gizmoPos, gizmoRad);
    }


}
