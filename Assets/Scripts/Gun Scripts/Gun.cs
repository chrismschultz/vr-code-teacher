using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject intBullet;
    public GameObject floatBullet;
    public GameObject stringBullet;

    public int bulletIndex;

    public Transform firePoint;
    public float speed;
    public VRTK_ControllerEvents controller;

    private TextMeshPro gunText;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("RightController").GetComponent<VRTK_ControllerEvents>();
        controller.TriggerPressed += Controller_TriggerClicked;
        gunText = transform.GetChild(4).GetComponent<TextMeshPro>();
    }

    public void FireInt()
    {
        GameObject bullet = Instantiate(intBullet, firePoint.position, Quaternion.identity) as GameObject;
        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(firePoint.forward * speed);
    }

    public void FireFloat()
    {
        GameObject bullet = Instantiate(floatBullet, firePoint.position, Quaternion.identity) as GameObject;
        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(firePoint.forward * speed);
    }

    public void FireString()
    {
        GameObject bullet = Instantiate(stringBullet, firePoint.position, Quaternion.identity) as GameObject;
        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(firePoint.forward * speed);
    }

    private void Controller_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        switch (bulletIndex)
        {
            case 0:
                FireInt();
                break;
            case 1:
                FireFloat();
                break;
            case 2:
                FireString();
                break;
        }


    }

    public void bulletText()
    {

        switch (bulletIndex)
        {
            case 0:
                gunText.text = "int";
                break;
            case 1:
                gunText.text = "float";
                break;
            case 2:
                gunText.text = "string";
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {
        bulletText();
    }
}
