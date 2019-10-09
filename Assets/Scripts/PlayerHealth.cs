using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	// Vida de la base
	[SerializeField] int health = 2;
	// Puntos de vida que quita por enemigo
	[SerializeField] int healthDecrease = 1;

	// Si entra un enemigo
	void OnTriggerEnter(Collider other)
	{
		// Para evitar doble muerte por colisión simultánea
		if (health > 0)
		{
			ProcessHit();
			// Si está muerto
			if (health == 0)
			{
				GameOver();
			}
		}
	}

	// Procesa el impacto
	private void ProcessHit()
	{
		// Queda menos vida
		health = health - healthDecrease;
	}

	// Fin del juego
	private void GameOver()
	{
		print("FIN");
	}
}
