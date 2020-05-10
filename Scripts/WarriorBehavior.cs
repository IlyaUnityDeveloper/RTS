using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Используется на объекте Warrior
public class WarriorBehavior : MonoBehaviour
{
    [SerializeField]
	private GetAllObjects getAllObjects;
	
	void Start()
	{
		getAllObjects = Camera.main.GetComponent<GetAllObjects>(); //Получение всех профессий
	}
	
	void Update()
	{
		//Если юнит подошел близко к врагу, он начинает на него нападать
		foreach (GameObject i in getAllObjects.enemies)
		{
			if (Vector3.Distance(transform.position, i.transform.position)<2)
			{
				i.GetComponent<Stats>().TakeDamage();
			}
		}
	}
}
