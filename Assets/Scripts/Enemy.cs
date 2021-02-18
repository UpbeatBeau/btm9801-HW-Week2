using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float forceAmount = 5;  //public var for force amount
    
    Rigidbody2D rb2D; //var for the Rigidbody2D
    public float maxSpeedx = 3f; // var for x speed and direction
    public float maxSpeedy = 3f; // var for y speed and direction
    private Vector2 movementx; // vector for x move
    private Vector2 movementy; // vector for y move
  


    //static variable means the value is the same for all the objects of this class type and the class itself
    public static Enemy instance; //this static var will hold the Singleton

    void Awake()
    {
        if (instance == null)  //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this; //set instance to this object
        }
        else //if the instance is already set to an object
        {
            Destroy(gameObject);  //destroy this new object, so there is only ever one
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  //get the Rigidbody2D  off of this gameObject
       
    }

    private void Update()
    {
        movementy = Vector2.down; // move down
        movementx = Vector2.right; // move to the right
        rb2D.velocity = ((movementx * maxSpeedx) + (movementy * maxSpeedy)); // move the rigidbody using velocity
       
    }
//on a collision to an object
    private void OnCollisionEnter2D(Collision2D other)
    {
        var wall = other.gameObject.tag;
        if (wall == "VerticalWall") // if tag is verticle wall
        {
            maxSpeedx *= -1; // flip x movement
        }

        if (wall == "HorizontalWall") // if tag is horizontal wall
        {
            maxSpeedy *= -1; // flip y movement
        }

    }
}
