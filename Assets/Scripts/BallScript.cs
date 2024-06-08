using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	// check if ball collides with something
	void OnCollisionEnter2D (Collision2D col)
	{
		// check if it is a can or a floor
		if (col.gameObject.tag.Equals ("Can") || col.gameObject.tag.Equals("Floor")) {
			
			// invoke DestroyBall methid in 3 seconds
			Invoke ("DestroyBall", 3f);

			//destroy ball game object in 3 seconds
			Destroy (gameObject, 3f);
		}
	}

	// call DecreaseNumberOfBalls method from instance of GameControlScript
	void DestroyBall()
	{
		GameControlScript.instance.DecreaseNumberOfBalls ();
	}

}
