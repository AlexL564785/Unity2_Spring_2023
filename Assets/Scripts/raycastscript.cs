using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastscript : MonoBehaviour
{
     public bool opendoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward,out hit, 7f))
        {
            Debug.Log(hit.collider.gameObject.name);
           // hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;

            if(hit.collider.CompareTag("door") && opendoor)
            {
                hit.collider.gameObject.GetComponent<doorscript>().DoorOpen = true;
            }
        }
    }
}
