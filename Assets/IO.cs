using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IO : MonoBehaviour
{
	string f_name = "io_test.dat";

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
			saveData ();

		if (Input.GetKeyDown (KeyCode.S))
			loadData ();

		Debug.Log (Time.time);
	}

	void saveData ()
	{
		Debug.Log ("saving");
		FileStream BinaryFile = new FileStream (f_name, FileMode.Create, FileAccess.ReadWrite);
		BinaryWriter Writer = new BinaryWriter (BinaryFile);
		BinaryFile.Seek (0, SeekOrigin.End);

		int[] a = new int[]{ 10, 11, 12 };

		foreach (int _a in a) {
			Writer.Write (_a);
			Debug.Log (_a);
		}
		Writer.Close ();
	}

	void loadData ()
	{
		Debug.Log ("loading");
		FileStream BinaryFile = new FileStream (f_name, FileMode.Open, FileAccess.Read);
		BinaryReader Reader = new BinaryReader (BinaryFile);
		BinaryFile.Seek (0, SeekOrigin.Begin);

		int data_num = 6;
		int[] a = new int[data_num];

		for (int i = 0; i < data_num; i++) {
			a [i] = Reader.ReadInt32 ();
			Debug.Log (a [i]);
		}
		Reader.Close ();
	}
}