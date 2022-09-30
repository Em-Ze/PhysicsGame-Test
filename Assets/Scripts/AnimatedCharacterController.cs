using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacterController : MonoBehaviour
{
    [SerializeField] private Transform CharacterTransform;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private CapsuleCollider HoveringCollider;
    [SerializeField] private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        appendObjects();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = gravitationalPull();
        
    }

    //----------------------------------------------------------

    void appendObjects()
    {
        CharacterTransform = GetComponent<Transform>();
        RB = GetComponent<Rigidbody>();
        HoveringCollider = GetComponent<CapsuleCollider>();
    }

    bool gravitationalPull()
    {
        //float gravityForce = 9.81f;
        float pillHoverHeight = 1f;
        RaycastHit hit;
        bool isGrounded = false;

        bool confirmHit = Physics.Raycast(getBottomCenterOfColider(HoveringCollider), HoveringCollider.transform.TransformDirection(Vector3.down),out hit, pillHoverHeight * 1.5f);
        
        Debug.DrawRay(getBottomCenterOfColider(HoveringCollider), HoveringCollider.transform.TransformDirection(Vector3.down) * pillHoverHeight * 1.5f, Color.red); 
        
        


        return isGrounded;
    }

    Vector3 getBottomCenterOfColider(Collider collider)
    {

        Vector3 bottomPosition = collider.bounds.center ;
        return bottomPosition;
    }

    void movement()
    {
        if(Input.GetButton("w"))
        {

        }
    }
}
