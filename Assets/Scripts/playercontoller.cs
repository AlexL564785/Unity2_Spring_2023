using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontoller : MonoBehaviour
{
    Vector2 movedir;
    
    Rigidbody rb;
    float h, v;
    Vector3 inputvector;
    [Header("Movement Header")]
    [Tooltip("speed adjusts the speed of the player")]
    public float speed = 10;
    [Tooltip("jump heigth adjusts the force applied to the player jump")]
    [Range(0,20)]
    public float jumpheight = 10;
    public LayerMask groundlayer;
   public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        h = Dampenvalue(h, movedir.x);
        v = Dampenvalue(v, movedir.y);

        inputvector = new Vector3(h * speed, rb.velocity.y, v * speed);

        transform.LookAt(transform.position + new Vector3(inputvector.x,0,inputvector.z));

        rb.velocity = inputvector;

        anim.SetFloat("Move",movedir.magnitude);


        Debug.DrawRay(transform.position, transform.forward * 7, Color.red);

    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());

        movedir = ctx.ReadValue<Vector2>();

    }

    public void Jump()
    {
        if(GroundCheck())
        {
        rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
       


    }





    float Dampenvalue(float readvalue, float movedir)
    {
        readvalue = Mathf.MoveTowards(readvalue, movedir, Time.deltaTime * 2);
        return readvalue = Mathf.Clamp(readvalue, -1,1);

    }

    bool GroundCheck()
    {
        float dist = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray,dist, groundlayer);
    }

    private void OnDrawGizmos()
    {
        float dist = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Debug.DrawRay(transform.position, Vector3.down * dist, Color.magenta);
    }

}
