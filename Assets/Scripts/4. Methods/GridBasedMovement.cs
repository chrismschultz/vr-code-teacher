using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public float moveScale = .5f;

    public LayerMask whatStopsMovement;

    public int objectiveCounter;

    // Start is called before the first frame update
    void Start()
    {
        objectiveCounter = 0;
        movePoint.parent = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Objective")
        {
            objectiveCounter++;
            Destroy(other.gameObject);
        }
    }



    public void MoveRight()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 0f, 1) * moveScale, .2f, whatStopsMovement).Length == 0)
            {
                movePoint.position += new Vector3(0f, 0f, 1) * moveScale;
            }
        }
    }

    public void MoveLeft()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 0f, -1) * moveScale, .2f, whatStopsMovement).Length == 0)
            {
                movePoint.position += new Vector3(0f, 0f, -1) * moveScale;
            }
        }
    }

    public void MoveUp()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 1, 0f) * moveScale, .2f, whatStopsMovement).Length == 0)
            {
                movePoint.position += new Vector3(0f, 1, 0f) * moveScale;
            }
        }
    }

    public void MoveDown()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, -1, 0f) * moveScale, .2f, whatStopsMovement).Length == 0)
            {
                movePoint.position += new Vector3(0f, -1, 0f) * moveScale;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        /*
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            //Move Right
            if(Input.GetAxisRaw("Horizontal") == 1f)
            {
                if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")) * moveScale, .2f, whatStopsMovement).Length == 0)
                {
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")) * moveScale;
                }
            }
            //Move Left
            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")) * moveScale, .2f, whatStopsMovement).Length == 0)
                {
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")) * moveScale;
                }
            }
            //Move Up
            else if(Input.GetAxisRaw("Vertical") == 1f)
            {

                if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * moveScale, .2f, whatStopsMovement).Length == 0)
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * moveScale;
                }
                
            }
            //Move Down
            else if (Input.GetAxisRaw("Vertical") == -1f)
            {

                if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * moveScale, .2f, whatStopsMovement).Length == 0)
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * moveScale;
                }

            }

        }
        */
    }
}
