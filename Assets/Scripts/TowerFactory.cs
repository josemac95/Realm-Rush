using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
	// Prefab de la torre
	[SerializeField] Tower towerPrefab = null;
	// Máximo número de torres
	[SerializeField] int towerLimit = 3;

	// Cola de torres
	Queue<Tower> towers = new Queue<Tower>();

	// Añade nuevas torres
	public void AddTower(Waypoint waypoint)
	{
		if (towers.Count < towerLimit)
		{
			InstantiateTower(waypoint);
		}
		else
		{
			MoveTower(waypoint);
		}
	}

	// Insancia una nueva torre
	private void InstantiateTower(Waypoint waypoint)
	{
		// Crea la torre (en la posición del waypoint)
		var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
		// Cambia el nombre
		newTower.name = "Tower " + (towers.Count + 1);
		// Agrupa las torres
		newTower.transform.parent = transform;
		// Ya no permite poner más torres en esa posición
		waypoint.IsPlaceable = false;
		// Establece la nueva posición
		newTower.Position = waypoint;
		// Añade a la cola
		towers.Enqueue(newTower);
	}

	// Mueve una torre a la posición nueva
	private void MoveTower(Waypoint newWaypoint)
	{
		// Torre que tiene que moverse
		Tower tower = towers.Dequeue();
		// Su waypoint vuelve a estar disponible
		tower.Position.IsPlaceable = true;
		// Ya no permite poner más torres en esa posición
		newWaypoint.IsPlaceable = false;
		// Establece la nueva posición
		tower.Position = newWaypoint;
		tower.transform.position = newWaypoint.transform.position;
		// Añade a la cola
		towers.Enqueue(tower);
	}
}
