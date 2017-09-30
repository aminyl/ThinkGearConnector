using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGraph : MonoBehaviour
{
	public GameObject point;
	public DisplayData displayData;
	int rawValue;

	// Use this for initialization
	void Start ()
	{
		displayData.Initialize ();
		// displayData.controller.UpdateRawdataEvent += OnUpdateUpdateRawdata;
		StartCoroutine(IGeneratePoint());
	}
	
	void UpdateRawValue (int value)
	{
		rawValue = value;
	}

	float GetHeight ()
	{
		return (float)rawValue / 200;
	}

	Vector3 GetPosition ()
	{
		return new Vector3 (0, GetHeight (), 0);
	}

	Vector3 GetVelocity ()
	{
		return new Vector3 (2f, 0f, 0f);
	}

	void OnUpdateUpdateRawdata (int value)
	{
		UpdateRawValue (value);
		GeneratePoint ();
	}

	void GeneratePoint ()
	{
		GameObject p = Instantiate (point);
		p.GetComponent<PointController> ().Initialize (gameObject, GetPosition (), GetVelocity ());
	}

	IEnumerator IGeneratePoint ()
	{
		while (true) {
			UpdateRawValue (displayData.raw);
			GeneratePoint ();
			yield return null;
		}
	}
}