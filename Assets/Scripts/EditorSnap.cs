using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
	// Posición ajustada
	Vector3 snapPos;

	// Tamaño de la cuadrícula de 1 a 20
	[Range(1f, 20f)]
	[SerializeField] float gridSize = 10f;

	void Update()
	{
		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPos.y = 0f;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = snapPos;
	}
}
