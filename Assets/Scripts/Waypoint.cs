using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	// Tamaño de la cuadrícula
	const int gridSize = 10;

	public int GridSize
	{
		get
		{
			return gridSize;
		}
	}

	// Posición ajustada en la cuadrícula
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

	// Establece el color de la parte de arriba del cubo
	public void SetTopColor(Color color)
	{
		var top = transform.Find("Top");
		top.GetComponent<MeshRenderer>().material.color = color;
	}
}
