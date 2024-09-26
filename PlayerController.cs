using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;
// Start is called before the first frame update
    void Start()
    {
        count = 0; 

        rb = GetComponent <Rigidbody>(); 

        SetCountText();

        winTextObject.SetActive(false);

    }


    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y;

    }

    void SetCountText() 
   {
        countText.text =  "Count: " + count.ToString();

        if (count >=10)
        {
            winTextObject.SetActive(true);
        }
   }

    void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);


        rb.AddForce(movement * speed); 
        
   }

    void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "PickUp" tag.
    if (other.gameObject.CompareTag("PickUp")) 
    {
 // Deactivate the collided object (making it disappear).
    other.gameObject.SetActive(false);

    count = count + 1;

    SetCountText();
    }
    }
}
