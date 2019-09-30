using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hace que el script se ejecute en el modo edición
// Ayuda a crear el mapa con las condiciones establecidas
[ExecuteInEditMode]
// Hace que cuando se pinche en el objeto se seleccione entero
// Y no una de sus partes o caras
[SelectionBase]
// Requiere el componente del waypoint
//[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	// Waypoint
	Waypoint waypoint;

	// Si oculta la etiqueta
	[SerializeField] bool hideLabel = true;

	void Awake()
	{
		waypoint = GetComponent<Waypoint>();
	}

	void Update()
	{
		SnapToGrid();
		UpdateLabel();
	}

	// Actualiza la posición
	private void SnapToGrid()
	{
		// Posición real
		transform.position = new Vector3(waypoint.GridPos.x * waypoint.GridSize, 0f, waypoint.GridPos.y * waypoint.GridSize);
	}

	// Actualiza la etiqueta
	private void UpdateLabel()
	{
		// Obitiene el primer componente TextMesh en la jerarquía
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		// Actualiza el texto
		string label = waypoint.GridPos.x + "," + waypoint.GridPos.y;
		if (hideLabel)
		{
			textMesh.text = "";
		}
		else
		{
			textMesh.text = label;
		}
		// Actualiza el nombre del objeto
		gameObject.name = "Cube " + label;
	}
}
