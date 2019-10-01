using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	// Tiempo en segundos entre cada spawn
	[SerializeField] float timeBetweenSpawns = 2f;
	// Prefab del enemigo
	[SerializeField] Enemy enemyPrefab = null;

	void Start()
	{
		StartCoroutine(SpawnEnemies());
	}

	// Spawnea los enemigos
	private IEnumerator SpawnEnemies()
	{
		int i = 1;
		while (true)
		{
			// Crea el enemigo (en la posición del padre)
			GameObject newEnemy = Instantiate(enemyPrefab.gameObject, transform.position, Quaternion.identity);
			// Lo agrupa con el padre
			newEnemy.transform.parent = transform;
			// Cambia el nombre
			newEnemy.name = "Enemy " + i;
			i++;
			// Espera al siguiente spawn
			yield return new WaitForSeconds(timeBetweenSpawns);
		}
	}
}
