using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Tiempo de espera tras llegar a un waypoint
	[SerializeField] float timeStopped = 0.5f;
	// Cantidad de movimiento por frame
	[SerializeField] float amountOfMovement = 0.5f;
	// Cantidad de rotación por frame
	[SerializeField] float amountOfRotation = 0.05f;


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
			// Rotación hacie el siguiente waypoint
			yield return StartCoroutine(RotateTowardsWaypoint(waypoint));
			// Espera a que termine la corrutina
			// Movimiento hacia el siguiente waypoint
			yield return StartCoroutine(MoveTowardsWaypoint(waypoint));
			// Espera en el waypoint
			yield return new WaitForSeconds(timeStopped);
		}
	}

	// Movimiento hacia un waypoint suave
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

	// Rotación hacia un waypoint suave
	private IEnumerator RotateTowardsWaypoint(Waypoint waypoint)
	{
		// Dirección hacia el objetivo
		Vector3 targetDir = waypoint.transform.position - transform.position;
		// Mientras no esté mirando
		while (targetDir != Vector3.zero && transform.rotation != Quaternion.LookRotation(targetDir))
		{
			// Mira hacia el objetivo
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, amountOfRotation, 0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			// Espera al siguiente frame
			yield return null;
		}
	}
}
