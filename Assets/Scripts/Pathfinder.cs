using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	// Diccionario
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	// Inicio y fin del camino
	[SerializeField] Waypoint startWaypoint = null;
	[SerializeField] Waypoint endWaypoint = null;

	void Start()
	{
		LoadBlocks();
		ColorStartAndEnd();
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
}
