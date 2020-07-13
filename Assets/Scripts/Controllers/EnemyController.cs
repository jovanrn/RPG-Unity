using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;	
	NavMeshAgent agent; 
	CharacterCombat combat;
	bool flag = true;
	bool flag2;
	public Transform[] moveSpots;
	int index = 0;
	bool NotEmptyOnBegin;

	GameObject waypoint;
	void Start () {
		//agent.autoBraking = false;
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		combat = GetComponent<CharacterCombat>();
		agent.autoBraking = false;
		GotoNextPoint();
		agent.avoidancePriority = 50;

	    NotEmptyOnBegin = moveSpots[0] == null ? false : true;
		}

	void getWaypoints() {

		waypoint = GameObject.FindGameObjectWithTag("Waypoint");

		for (int i = 0; i < 3; i++)
		{
			moveSpots[i] = waypoint.transform.GetChild(i);
		}
	}

	private void Awake()
	{

		Invoke("getWaypoints",1f);
	}


	void Update () {
		// Distance to the target
		float distance = Vector3.Distance(target.position, transform.position);
		NotEmptyOnBegin = moveSpots[0] == null ? false : true;

		if (distance <= lookRadius)
		{
			flag2 = false;

			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
				CharacterStats targetStats = target.GetComponent<CharacterStats>();
				if (targetStats != null)
				{
					combat.Attack(targetStats);
				}

				FaceTarget();	
			}
		}

		if (!agent.pathPending && agent.remainingDistance <= 2f && NotEmptyOnBegin)
			{
				Debug.Log("else if");

				GotoNextPoint();
			}

	}
	 
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}



	void GotoNextPoint()
	{
		if (NotEmptyOnBegin)
		{
			agent.SetDestination(moveSpots[index].position);
			index = (index + 1) % moveSpots.Length;
		}

	}







}


