using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTarget : MonoBehaviour
{
    public CannonTargetManager manager;

    public void OnTriggerEnter(Collider other)
    {
        manager.IncreaseIndex();
        Debug.Log(other.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<CannonTargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
