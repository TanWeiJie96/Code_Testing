using UnityEngine;
using System.Collections;

public class lerpingTest: MonoBehaviour {

	//public Transform startMarker;
	//public Transform endMarker;

	public Vector3 initScale = new Vector3(1.0f, 1.0f, 1.0f);
	public Vector3 scaleUpTo = new Vector3(1.5f, 1.5f, 1.5f);

	public float speed = 1.0f;

	public float startTime;
	public float journeyLength;

	void Start()
	{
		startTime = Time.time;
		initScale = gameObject.transform.localScale;
		journeyLength = Vector3.Distance(initScale, scaleUpTo);
	}

	void Update()
	{
		float distanceCovered = (Time.time - startTime) * speed;
		float fracJourney = distanceCovered / journeyLength;
		//	gameObject.transform.localScale = Vector3.Lerp (initScale, scaleUpTo, fracJourney);

		if (Input.GetKeyDown(KeyCode.A))
		{
			gameObject.transform.localScale = Vector3.Lerp (initScale, scaleUpTo, fracJourney);
			Debug.Log ("Pressed 'A'");
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			gameObject.transform.localScale = Vector3.Lerp (scaleUpTo, initScale, fracJourney);
			Debug.Log ("Pressed 'A'");
		}
	}

}
