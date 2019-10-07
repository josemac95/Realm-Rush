using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
	// Prefab de la torre
	[SerializeField] Tower towerPrefab = null;
	// Contador de torres
	int towerCounter = 1;
	// Máximo número de torres
	int towerLimit = 5;

	// Añade nuevas torres
	public void AddTower(Waypoint waypoint)
	{
		if (towerCounter <= towerLimit)
		{
			InstantiateTower(waypoint);
		}
		else
		{
			//MoveTower(waypoint);
		}
	}

	// Insancia una nueva torre
	private void InstantiateTower(Waypoint waypoint)
	{
		// Crea la torre (en la posición del waypoint)
		var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
		// Cambia el nombre
		newTower.name = "Tower " + towerCounter;
		towerCounter++;
		// Agrupa las torres
		newTower.transform.parent = transform;
		// Ya no permite poner más torres en esa posición
		waypoint.IsPlaceable = false;
	}
}
