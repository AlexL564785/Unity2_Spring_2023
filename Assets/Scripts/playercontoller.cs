using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontoller : MonoBehaviour
{
    Vector2 movedir;
    public float speed = 10;
    Rigidbody rb;
    float h, v;
    Vector3 inputvector;
    public float jumpheight = 10;

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

        Debug.DrawRay(transform.position, transform.forward * 7, Color.red);

    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());

        movedir = ctx.ReadValue<Vector2>();

    }

    public void Jump()
    {

        rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);

    }





    float Dampenvalue(float readvalue, float movedir)
    {
        readvalue = Mathf.MoveTowards(readvalue, movedir, Time.deltaTime * 2);
        return readvalue = Mathf.Clamp(readvalue, -1,1);

    }

}
