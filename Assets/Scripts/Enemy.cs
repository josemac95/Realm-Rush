using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Vida (en número de impactos)
	[SerializeField] int hits = 10;

	void Start()
	{
		// Añade el componente via script
		// Colisiones con partículas
		AddNonTriggerBoxCollider();
	}

	// Añade el collider (No trigger)
	private void AddNonTriggerBoxCollider()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		// Por defecto es así, pero es mejor asegurarse
		// Porque es importante para el funcionamiento
		boxCollider.isTrigger = false;
	}

	// Si choca una partícula con el objeto
	void OnParticleCollision(GameObject other)
	{
		// Para evitar doble muerte por colisión simultánea
		if (hits > 0)
		{
			ProcessHit();
			// Si está muerto
			if (hits == 0)
			{
				KillEnemy();
			}
		}
	}

	// Procesa el impacto
	private void ProcessHit()
	{
		// Queda menos vida
		hits = hits - 1;
	}

	// Mata al enemigo
	private void KillEnemy()
	{
		// Destruye el enemigo
		Destroy(gameObject);
	}
}
