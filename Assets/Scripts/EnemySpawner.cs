﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	// Tiempo en segundos entre cada spawn
	[SerializeField] float timeBetweenSpawns = 2f;
	// Prefab del enemigo
	[SerializeField] Enemy enemyPrefab = null;

	// Padre de los efectos de partículas del enemigo
	[SerializeField] Transform FXParent = null;

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
			// Crea el enemigo (en la posición del spawner - padre)
			var newEnemy = Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
			newEnemy.FXParent = FXParent;
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
