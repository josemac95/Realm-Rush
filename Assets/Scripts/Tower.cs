using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	// La parte de la torre que se mueve
	[SerializeField] Transform objectToPan = null;
	// Enemigo al que se apunta
	[SerializeField] Transform targetEnemy = null;

	void Update()
	{
		// Apunta al enemigo
		objectToPan.LookAt(targetEnemy);
	}
}
