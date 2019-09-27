﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	// Tamaño de la cuadrícula
	const int _gridSize = 10;

	public int GridSize
	{
		get
		{
			return _gridSize;
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

	// Está explorado
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

	// Establece el color de la parte de arriba del cubo
	public void SetTopColor(Color color)
	{
		var top = transform.Find("Top");
		top.GetComponent<MeshRenderer>().material.color = color;
	}
}
