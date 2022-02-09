/*
 * Created by: Haley Kelly
 * Date Created: 1/31/2022
 *
 * Last Edited by: N/A
 * Last Edited: 2/7/2022
 *
 * Description:
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;


    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("score"); // score game object
        scoreGT = scoreGO.GetComponent<Text>(); // text component of score game object
        scoreGT.text = "0"; // set text component

    }

    // Update is called once per frame
    void Update()
    {
      // Get the current screen position of the mouse from Input
      Vector3 mousePos2D = Input.mousePosition;
      // The camera's z position sets how far to push the mouse into 3D
      mousePos2D.z = -Camera.main.transform.position.z;
      // Convert the point from 2D screen space into 3D game world space
      Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
      // Move the x position of this basket to the x position of the Mouse;
      Vector3 pos = this.transform.position;
      pos.x = mousePos3D.x;
      this.transform.position = pos;
    }

    void OnCollisionEnter( Collision coll){
      GameObject collidedWith = coll.gameObject;
      if (collidedWith.tag == "Apple"){
        Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if ( score > HighScore.score ){
              HighScore.score = score;
            }
      }
    }
}
