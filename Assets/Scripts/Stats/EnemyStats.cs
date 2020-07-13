using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyStats : CharacterStats {

	public GameObject deathEffectPrefab;
	public Vector3 offset=new Vector3(0,5f,0);
	
	public override void Die()
	{
		PlayerManager.kills++;
		
		base.Die();
		GameObject i = (GameObject)Instantiate(deathEffectPrefab, transform.position + offset, Quaternion.identity);
		//i.SetActive(true);
		// Add ragdoll effect / death animation
		//DeathRef.SetActive(true);
		Destroy(gameObject);
		SpawnEnemy.numberOfEnemies--;

	}


}
