using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Vida (en número de impactos)
	[SerializeField] int hits = 10;
	// Partículas de colisión
	[SerializeField] ParticleSystem hitFX = null;
	// Partículas de muerte
	[SerializeField] ParticleSystem deathFX = null;

	// Padre para los efectos (propiedad)
	Transform _FXParent = null;

	public Transform FXParent
	{
		get
		{
			return _FXParent;
		}
		set
		{
			_FXParent = value;
		}
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
		// Partículas de colisión (instancia el prefab)
		var fx = Instantiate(hitFX, transform.position, Quaternion.identity);
		fx.Play();
		fx.transform.parent = _FXParent;
		// Queda menos vida
		hits = hits - 1;
	}

	// Mata al enemigo
	private void KillEnemy()
	{
		// Efecto de muerte (instancia el prefab)
		var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.Play();
		fx.transform.parent = _FXParent;
		// Destruye el enemigo
		Destroy(gameObject);
	}
}
