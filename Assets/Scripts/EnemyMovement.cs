using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] float amountOfMovement = 0.1f;

	void Start()
	{
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		StartCoroutine(FollowPath(pathfinder.Path));
	}

	// Sigue el camino
	private IEnumerator FollowPath(List<Waypoint> path)
	{
		foreach (Waypoint waypoint in path)
		{
			// Espera a que termine la corrutina
			yield return StartCoroutine(MoveTowardsWaypoint(waypoint));
			// Espera en el waypoint
			yield return new WaitForSeconds(1f);
		}
	}

	// Movimiento hacia un waypoint suave
	// Se especifica la cantidad de movimiento por frame
	private IEnumerator MoveTowardsWaypoint(Waypoint waypoint)
	{
		// Mientras no haya llegado a la posición
		while (transform.position != waypoint.transform.position)
		{
			// Nueva posición dada la cantidad de movimiento hacia el objetivo
			Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoint.transform.position, amountOfMovement);
			transform.position = newPosition;
			// Espera al siguiente frame
			yield return null;
		}
	}
}
