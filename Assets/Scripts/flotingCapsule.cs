using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flotingCapsule : MonoBehaviour
{
    [SerializeField] private Transform CharacterTransform;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private CapsuleCollider HoveringCollider;
    [SerializeField] private bool isGrounded;

    float gForce = 9.81f;
    float hoverHeight = 2f;
    float hoverForce = 3f;
    float hoverDamp = .7f;




    // Start is called before the first frame update
    void Start()
    {
        appendObjects();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = false;
        gravitationalPull();

    }

    //----------------------------------------------------------

    void gravitationalPull()
    {
        RaycastHit hit = rayCastToGround();
        float hoverError;

        if (hit.distance == 0 || hit.distance > hoverHeight) { hoverError = 0; }       //
        else{ hoverError = hoverHeight - hit.distance; }  //if ray touches nothing allow gravity to work
       
        Debug.Log(hoverError );

        //if ()
        //{
        //    RB.MovePosition(RB.transform.position - Vector3.down * hoverError * Time.deltaTime);
        //    RB.velocity = new Vector3(RB.velocity.x, 0, RB.velocity.z);
        //    isGrounded = true;
        //    Debug.Log("stoping");
        //}


        if (hoverError > 0)
        {
            float upwardSpeed = RB.velocity.y;
            float lift = hoverError * hoverForce - upwardSpeed * hoverDamp ;
            RB.AddForce(lift * Vector3.up );            
        }
        else 
        {
            RB.AddForce(Vector3.down * gForce );
        }

    }

    RaycastHit rayCastToGround()
    {
        RaycastHit hit;

        Physics.Raycast(HoveringCollider.transform.position, CharacterTransform.transform.TransformDirection(Vector3.down), out hit, hoverHeight );
        Debug.DrawRay(HoveringCollider.transform.position, CharacterTransform.transform.TransformDirection(Vector3.down) * hoverHeight , Color.red);

        return hit;
    }

    void appendObjects()
    {
        CharacterTransform = GetComponent<Transform>();
        RB = GetComponent<Rigidbody>();
        HoveringCollider = GetComponent<CapsuleCollider>();
    }

    

}
