using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    private float x,y,reverse = -1.0f;
    private Vector3 turn = Vector3.zero;
    private Rigidbody _rb;
    // public Transform camera;
    public Vector3 offset;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // camera.position = transform.position + offset;
        // transform.LookAt(camera.position);
        MoveCharacter();
    }
    
    void FixedUpdate() 
    {
        transform.LookAt(transform.position+turn);
        transform.Translate(x*Time.deltaTime*moveSpeed,0,y*Time.deltaTime*moveSpeed); 
        turn = Vector3.zero;
    }

    private void MoveCharacter()
    {
        
        x = CrossPlatformInputManager.GetAxis("Horizontal");
        y = CrossPlatformInputManager.GetAxis("Vertical");
        turn += new Vector3(x,0,y);
        if(y<0)
             y*=reverse;

        if(CrossPlatformInputManager.GetButtonDown("Brincar"))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


}
