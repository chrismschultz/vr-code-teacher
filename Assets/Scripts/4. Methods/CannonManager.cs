using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class CannonManager : MonoBehaviour
{
    [Range(0,80)]
    public float rotation;

    public VRTK_BaseControllable angleInput;
    public VRTK_BaseControllable fireButton;

    public GameObject cannonBall;

    public Transform firePoint;

    public float force;

    public void Start()
    {
        angleInput.ValueChanged += ValueChanged;
        fireButton.MaxLimitReached += FireButton_MaxLimitReached;
    }

    private void FireButton_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        FireCannon();
    }

    public virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        rotation = (float)e.value;
    }


    public void FireCannon()
    {
        GameObject bullet = Instantiate(cannonBall, firePoint.position, Quaternion.identity) as GameObject;
        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(firePoint.forward * force);
    }


    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotation);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireCannon();
        }
    }
}
