using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetManager : MonoBehaviour
{
    public float speed; 

    public Vector3 playerLoc;
    public GameObject targetPrefab;

    private List<GameObject> targets;

    public List<Vector3> spawnPoints;

    public targetInfo[] childInfo;

    public int targetCounter;

    private int spawnIndex;
    private int infoIndex;

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();

        playerLoc = transform.GetChild(0).GetComponent<Transform>().position;

        for(int i = 1; i <=3; i ++)
        {
            spawnPoints.Add(transform.GetChild(i).transform.position);
        }

        spawnIndex = 0;
        infoIndex = 0;

        //SpawnTargets();
        //SpawnTargets();
        //SpawnTargets();

    }

    public void StartWave()
    {
        SpawnTargets();
        SpawnTargets();
        SpawnTargets();
    }

    public void SpawnTargets(int spawnIndex, int targetIndex)
    {
        GameObject prefab = Instantiate(targetPrefab, spawnPoints[spawnIndex], Quaternion.identity);
        prefab.GetComponentInChildren<BulletTarget>().SetTargetInfo(childInfo[targetIndex].ID, childInfo[targetIndex].variable);
        targets.Add(prefab);
    }


    public void SpawnTargets()
    {
        Debug.Log("SPAWNING WITH INDICES: " + spawnIndex + " " + infoIndex + " WITH INFO: " + childInfo[infoIndex].ID + " " + childInfo[infoIndex].variable);
        GameObject prefab = Instantiate(targetPrefab, spawnPoints[spawnIndex], Quaternion.identity);


        prefab.GetComponentInChildren<BulletTarget>().SetTargetInfo(childInfo[infoIndex].ID, childInfo[infoIndex].variable);
        targets.Add(prefab);

        infoIndex++;
        spawnIndex++;

        Debug.Log("Indexes : " + infoIndex + " " + spawnIndex);

        infoIndex = infoIndex % childInfo.Length;
        spawnIndex = spawnIndex % spawnPoints.Count;

    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < spawnPoints.Count - 1; i ++)
        {
            Gizmos.DrawSphere(spawnPoints[i], .25f);
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach(GameObject target in targets)
        {
            if(target == null)
            {
                targets.Remove(target);
                break;
            }
            else
            {
                target.transform.position = Vector3.MoveTowards(target.transform.position, playerLoc, speed * Time.deltaTime);
                target.transform.LookAt(playerLoc);
            }
            
            
        }
    }

    [System.Serializable]
    public class targetInfo
    {
        public int ID;
        public string variable;
    }

}
