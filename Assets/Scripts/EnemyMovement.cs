using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Camino
	[SerializeField] List<Waypoint> path = null;

	void Start()
	{
		StartCoroutine(FollowPath());
	}

	// Sigue el camino
	private IEnumerator FollowPath()
	{
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
		}
	}
}
