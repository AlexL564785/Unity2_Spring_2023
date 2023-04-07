using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    public Transform target;
    public float smoothtime = 0.3f;
    public float yvelocity;
    public bool DoorOpen = false;
    public int coinsinscrene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorOpen)
        {
            float newpos = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yvelocity, smoothtime);
            transform.position = new Vector3(transform.position.x,newpos, transform.position.z);
            
        }
        if (coinsinscrene >= 5)
        {
            DoorOpen = true;
        }
    }
}
