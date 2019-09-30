using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	// La parte de la torre que se mueve
	[SerializeField] Transform objectToPan = null;
	// Enemigo al que se apunta
	[SerializeField] Transform targetEnemy = null;
	// Partículas de disparo
	[SerializeField] ParticleSystem bullets = null;
	// Rango de la torre
	[SerializeField] float attackRange = 10f;

	void Update()
	{
		// Si hay enemigo
		if (targetEnemy != null)
		{
			// Dispara al enemigo
			FireAtEnemy();
		}
		else
		{
			// Desactiva las armas
			ActivateGun(false);
		}
	}

	// Dispara al enemigo dentro del rango
	private void FireAtEnemy()
	{
		// Distancia
		float distance = Vector3.Distance(targetEnemy.transform.position, transform.position);
		// Está dentro de rango
		bool isInRange = distance < attackRange;
		// Sigue el movimiento
		FollowEnemy(isInRange);
		// Dispara
		ActivateGun(isInRange);
	}

	// Sigue el movimiento
	private void FollowEnemy(bool follow)
	{
		// Si lo puede seguir
		if (follow)
		{
			// Apunta al enemigo
			objectToPan.LookAt(targetEnemy);
		}
	}

	// Dispara
	private void ActivateGun(bool isActive)
	{
		// Activa o desactiva el módulo de emisión de partículas
		var emissionModule = bullets.emission;
		emissionModule.enabled = isActive;
	}
}
