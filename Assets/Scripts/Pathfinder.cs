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

	// Centro actual de la búsqueda
	Waypoint searchCenter = null;

	// Direcciones de movimiento
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Si el algoritmo de búsqueda debe parar
	bool stop = false;

	// Camino (propiedad)
	List<Waypoint> _path = new List<Waypoint>();

	public List<Waypoint> Path
	{
		get
		{
			if (_path.Count == 0)
			{
				CalculatePath();
			}
			return _path;
		}
	}

	// Calcula el camino
	private void CalculatePath()
	{
		LoadBlocks();
		BreadthFirstSearch();
		CreatePath(endWaypoint);
		ColorPath();
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

	// Encuentra el camino (búsqueda primero en anchura)
	private void BreadthFirstSearch()
	{
		queue.Enqueue(startWaypoint);
		// Bucle de búsqueda
		while (!stop && queue.Count > 0)
		{
			// Centro de la búsqueda
			searchCenter = queue.Dequeue();
			// Comprobación de parada
			Stop();
			// Explora los vecinos
			ExploreNeighbours();
			// Explorado
			searchCenter.IsExplored = true;
		}
	}

	// Condiciones de parada
	private void Stop()
	{
		if (searchCenter == endWaypoint)
		{
			stop = true;
		}
	}

	// Explora los vecinos
	private void ExploreNeighbours()
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
			// Añade a la cola
			queue.Enqueue(neighbour);
			// Indica el origen de exploración
			neighbour.ExploredFrom = searchCenter;
		}
	}

	// Obtiene el camino
	private void CreatePath(Waypoint waypoint)
	{
		// Añade el waypoint
		_path.Add(waypoint);
		waypoint.IsPlaceable = false;
		// Si es el inicio
		if (waypoint == startWaypoint)
		{
			// Da la vuelta a la lista
			_path.Reverse();
			return;
		}
		// Llamada recursiva
		CreatePath(waypoint.ExploredFrom);
	}

	// Cambia el color del camino
	private void ColorPath()
	{
		foreach (Waypoint waypoint in _path)
		{
			waypoint.SetTopColor(Color.blue);
		}
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.red);
	}
}
