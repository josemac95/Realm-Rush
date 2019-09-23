using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Camino de bloques
	[SerializeField] List<Block> path;

	void Start()
	{
		PrintWaypoints();
	}

	void Update()
	{

	}

	// Imprime el camino
	private void PrintWaypoints()
	{
		foreach (Block waypoint in path)
		{
			print(waypoint.name);
		}
	}
}
