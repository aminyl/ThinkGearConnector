using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
	Vector3 velocity;

	public void Initialize (GameObject parent, Vector3 position, Vector3 velocity)
	{
		transform.parent = parent.transform;
		transform.position = position;
		this.velocity = velocity;
		StartCoroutine (Move ());
	}

	bool checkPosition ()
	{
		return transform.position.x > 9;
	}

	IEnumerator Move ()
	{
		while (true) {
			transform.position += velocity * Time.deltaTime;
			if (checkPosition ())
				break;
			yield return null;
		}
		Destroy (gameObject);
	}
}