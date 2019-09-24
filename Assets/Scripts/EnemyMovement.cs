using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Camino
	[SerializeField] List<Waypoint> path;

	void Start()
	{
		StartCoroutine(FollowPath());
		print("Back to Start");
	}

	// Sigue el camino
	private IEnumerator FollowPath()
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in path)
		{
			print("Visiting " + waypoint.name);
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
		}
		print("Ending patrol");
	}
}
