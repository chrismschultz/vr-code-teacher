using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform;
    }

    public void createPrefab()
    {
        //Spawns a single prefab object in a given location
        Instantiate(prefab, spawnLocation.position, Quaternion.Euler(90, 0, 0));
    }

    //So a sphere shows up in the editor but not in game
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .05f);
    }

    public void createPrefab(GameObject newPrefab)
    {
        Instantiate(newPrefab, spawnLocation.position, Quaternion.identity);
    }

}
