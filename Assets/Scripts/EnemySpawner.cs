using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para la UI

public class EnemySpawner : MonoBehaviour
{
	// Tiempo en segundos entre cada spawn
	[SerializeField] float timeBetweenSpawns = 2f;
	// Prefab del enemigo
	[SerializeField] Enemy enemyPrefab = null;

	// Padre de los efectos de partículas del enemigo
	[SerializeField] Transform FXParent = null;

	// Número de enemigos
	int counter = 0;

	// Texto de los enemigos
	[SerializeField] Text enemiesText = null;

	void Start()
	{
		enemiesText.text = counter.ToString();
		StartCoroutine(SpawnEnemies());
	}

	// Spawnea los enemigos
	private IEnumerator SpawnEnemies()
	{
		while (true)
		{
			// Crea el enemigo (en la posición del spawner - padre)
			var newEnemy = Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
			newEnemy.FXParent = FXParent;
			// Lo agrupa con el padre
			newEnemy.transform.parent = transform;
			// Cambia el nombre
			newEnemy.name = "Enemy " + (counter + 1);
			counter++;
			// Actualiza la interfaz (es la puntuación)
			enemiesText.text = counter.ToString();
			// Espera al siguiente spawn
			yield return new WaitForSeconds(timeBetweenSpawns);
		}
	}
}
