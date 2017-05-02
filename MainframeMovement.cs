using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeMovement : MonoBehaviour {

    
    public float mainframeFlightTime;
    public float starterTimeDelay;
    public float speed;
    public Vector3 startLocation;
    public Vector3 endPoint;

    private Rigidbody rb;


	/*void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        StartEnumerator();
	}

    public void StartEnumerator()
    {
        StartCoroutine(MainframeMovementCorou());
    }

    public void EndEnumerator()
    {
        StopCoroutine(MainframeMovementCorou());
    }

    IEnumerator MainframeMovementCorou()
    {
        while (true)
        {
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(starterTimeDelay);
        rb.velocity = new Vector3(0.0f, speed, 0.0f);

            if (gameObject.transform.position.y <= endPoint)
            {
                rb.position = startLocation;
            }
        }
    }*/

    

}
