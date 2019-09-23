using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hace que el script se ejecute en el modo edición
// Ayuda a crear el mapa con las condiciones establecidas
[ExecuteInEditMode]
// Hace que cuando se pinche en el objeto se seleccione entero
// Y no una de sus partes o caras
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
	// Posición ajustada
	Vector3 snapPos;

	// Tamaño de la cuadrícula de 1 a 20
	[Range(1f, 20f)]
	[SerializeField] float gridSize = 10f;

	// Texto
	TextMesh textMesh;

	void Start()
	{
		// Obitiene el primer componente TextMesh en la jerarquía
		textMesh = GetComponentInChildren<TextMesh>();
	}

	void Update()
	{
		// Actualiza la posición
		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPos.y = 0f;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = snapPos;
		// Actualiza el texto
		textMesh.text = (snapPos.x / gridSize) + "," + (snapPos.z / gridSize);
	}
}
