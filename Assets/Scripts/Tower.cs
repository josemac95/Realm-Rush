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
		// Selecciona el enemigo más cercano
		FindEnemy();
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

	// Encuentra el enemigo más cercano
	private void FindEnemy()
	{
		// Colección de enemigos
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		// Si no hay enemigos
		if (enemies.Length == 0)
		{
			targetEnemy = null;
		}
		else
		{
			// Asume que el primero es el mejor
			Transform closestEnemy = enemies[0].transform;
			float minDistance = Vector3.Distance(closestEnemy.position, transform.position);
			// Para cada uno
			foreach (Enemy enemy in enemies)
			{
				(closestEnemy, minDistance) = GetClosestEnemy(minDistance, closestEnemy, enemy.transform);
			}
			// Actualiza el enemigo objetivo
			targetEnemy = closestEnemy;
		}
	}

	// Devuelve la tupla enemigo más cercano y su distancia
	private (Transform, float) GetClosestEnemy(float minDistance, Transform closestEnemy, Transform newEnemy)
	{
		// Distancia actual
		float distance = Vector3.Distance(newEnemy.position, transform.position);
		if (distance < minDistance)
		{
			// Nuevo enemigo más cercano
			return (newEnemy, distance);
		}
		return (closestEnemy, minDistance);
	}

	// Dispara al enemigo dentro del rango
	private void FireAtEnemy()
	{
		// Distancia
		float distance = Vector3.Distance(targetEnemy.position, transform.position);
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
