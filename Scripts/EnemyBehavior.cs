using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Используется на объекте Enemy
public class EnemyBehavior : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent agent;
	public float watchDistance = 5.0f;
	[SerializeField]
	private GetAllObjects getAllObjects;
	
	void Start()
	{
		getAllObjects = Camera.main.GetComponent<GetAllObjects>(); //Получение всех профессий
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update()
	{
		foreach (GameObject i in getAllObjects.ourunit)
		{
			//Преследование воина, если тот подошел слишком близко
			if (Vector3.Distance(transform.position, i.transform.position)<watchDistance)
			{
				agent.SetDestination(i.transform.position);
			}
			
			//Нападение на воина, если тот подошел вплотную
			if (Vector3.Distance(transform.position, i.transform.position)<2)
			{
				i.GetComponent<Stats>().TakeDamage();
			}
		}
	}
}
