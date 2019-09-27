using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	// Diccionario
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	// Cola
	Queue<Waypoint> queue = new Queue<Waypoint>();

	// Inicio y fin del camino
	[SerializeField] Waypoint startWaypoint = null;
	[SerializeField] Waypoint endWaypoint = null;

	// Direcciones de movimiento
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Si el algoritmo de búsqueda debe parar
	bool stop = false;

	void Start()
	{
		LoadBlocks();
		ColorStartAndEnd();
		Pathfinding();
	}

	// Carga los bloques de la cuadrícula
	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			// Comprobación de solapamiento
			if (grid.ContainsKey(waypoint.GridPos))
			{
				Debug.LogWarning("Skipping overlapping " + waypoint.name);
			}
			else
			{
				// Añade el bloque al diccionario
				grid.Add(waypoint.GridPos, waypoint);
			}
		}
	}

	// Cambia el color del inicio y del fin
	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.red);
	}

	// Encuentra el camino
	private void Pathfinding()
	{
		queue.Enqueue(startWaypoint);
		// Bucle de búsqueda
		while (!stop && queue.Count > 0)
		{
			// Centro de la búsqueda
			var searchCenter = queue.Dequeue();
			// Comprobación de parada
			Stop(searchCenter);
			// Explora los vecinos
			ExploreNeighbours(searchCenter);
			// Explorado
			searchCenter.IsExplored = true;
			// TODO remove print
			print("cola");
			foreach (Waypoint q in queue)
				print(q.name);
		}
	}

	// Condiciones de parada
	private void Stop(Waypoint searchCenter)
	{
		if (searchCenter == endWaypoint)
		{
			stop = true;
		}
	}

	// Explora los vecinos
	private void ExploreNeighbours(Waypoint searchCenter)
	{
		// Si ha parado
		if (stop) return;
		// Si no, busca los vecinos en las direcciones
		foreach (Vector2Int dir in directions)
		{
			Vector2Int explorationPos = searchCenter.GridPos + dir;
			// Si existe el vecino
			if (grid.ContainsKey(explorationPos))
			{
				Waypoint neighbour = grid[explorationPos];
				QueueNeighbour(neighbour);
			}
		}
	}

	// Encola el vecino
	private void QueueNeighbour(Waypoint neighbour)
	{
		// Si no está explorado y no está ya en la cola
		if (!neighbour.IsExplored && !queue.Contains(neighbour))
		{
			neighbour.SetTopColor(Color.blue);
			// Añade a la cola
			queue.Enqueue(neighbour);
		}
	}
}
