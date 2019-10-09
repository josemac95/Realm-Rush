using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para la UI

public class PlayerHealth : MonoBehaviour
{
	// Vida de la base
	[SerializeField] int health = 10;
	// Puntos de vida que quita por enemigo
	[SerializeField] int healthDecrease = 1;

	// Texto de la vida
	[SerializeField] Text healthText = null;

	// Efecto de sonido de llegada del enemigo
	[SerializeField] AudioClip enemySFX = null;

	void Start()
	{
		healthText.text = health.ToString();
	}

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
		// Sonido de llegada del enemigo
		gameObject.GetComponent<AudioSource>().PlayOneShot(enemySFX);
		// Queda menos vida
		health = health - healthDecrease;
		// Actualiza la interfaz
		healthText.text = health.ToString();
	}

	// Fin del juego
	private void GameOver()
	{
		print("FIN");
	}
}
