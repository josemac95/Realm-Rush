using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	// Tamaño de la cuadrícula (propiedad)
	const int _gridSize = 10;

	public int GridSize
	{
		get
		{
			return _gridSize;
		}
	}

	// Posición ajustada en la cuadrícula (propiedad)
	public Vector2Int GridPos
	{
		get
		{
			return new Vector2Int(
				Mathf.RoundToInt(transform.position.x / GridSize),
				Mathf.RoundToInt(transform.position.z / GridSize)
			);
		}
	}

	// Está explorado (propiedad)
	bool _isExplored = false;

	public bool IsExplored
	{
		get
		{
			return _isExplored;
		}
		set
		{
			_isExplored = value;
		}
	}

	// Waypoint desde donde se ha explorado
	Waypoint _exploredFrom = null;

	public Waypoint ExploredFrom
	{
		get
		{
			return _exploredFrom;
		}
		set
		{
			_exploredFrom = value;
		}
	}

	// Se puede construir encima (propiedad)
	bool _isPlaceable = true;

	public bool IsPlaceable
	{
		get
		{
			return _isPlaceable;
		}
		set
		{
			_isPlaceable = value;
		}
	}

	// Establece el color de la parte de arriba del cubo
	// Utilizado en el modo test (Lab scene)
	public void SetTopColor(Color color)
	{
		// Busca en los hijos del objeto
		var top = transform.Find("Top");
		if (top != null)
		{
			top.GetComponent<MeshRenderer>().material.color = color;
		}
	}

	// Fábrica de torres
	TowerFactory towerFactory;

	void Start()
	{
		towerFactory = FindObjectOfType<TowerFactory>();
	}

	// Detecta si el ratón está encima
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && _isPlaceable)
		{
			towerFactory.AddTower(this);
		}
	}
}
