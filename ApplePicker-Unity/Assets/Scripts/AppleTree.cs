/*
 * Created by: Haley Kelly
 * Date Created: 1/31/2022
 *
 * Last Edited by: N/A
 * Last Edited: 1/31/2022
 *
 * Description: Controls movement of the AppleTree.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    // Variables
    [Header("Set in Inspector")]
    public float speed = 1f; // tree speed
    public float leftAndRightEdge = 10f; // distance where the tree turns around
    public GameObject applePrefab; // prefab for instantiating apples
    public float secondsBetweenApplesDropped = 1f; // time between apple drops
    public float chanceToChangeDirection = 0.1f; // chance that the tree will change directions


    // Start is called before the first frame update
    void Start()
    {
      // Dropping apples every second
      Invoke ( "DropApple", 2f);

    }
    void DropApple(){
      GameObject apple = Instantiate<GameObject>( applePrefab );
      apple.transform.position = transform.position;
      Invoke("DropApple", secondsBetweenApplesDropped);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; // records the current position
        pos.x += speed * Time.deltaTime; // adds speed to x position
        transform.position = pos; // apply the position value

        // Change Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // set speed to positive
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // set speed to negative value
        }

    }

    // FixedUpdate is called on fixed intervals (50 times per second)
    private void FixedUpdate()
    {
        // Test chance of direction change
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; // change direction
        }
    }
}
