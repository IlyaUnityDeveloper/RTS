using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Используется на объекте Slave
public class SlaveBehavior : MonoBehaviour
{
	[SerializeField]
	private GetAllObjects getAllObjects;
	[SerializeField]
	private MainStocks mainStocks;
	
	void Start()
	{
		getAllObjects = Camera.main.GetComponent<GetAllObjects>(); //Получение всех профессий
		mainStocks = Camera.main.GetComponent<MainStocks>(); //Получение информации о ресурсах
	}
	
	void Update()
	{
		//Если юнит достаточно близок к шахте, он начинает добывать золото
		foreach (GameObject i in getAllObjects.mines)
		{
			if (Vector3.Distance(transform.position, i.transform.position)<2)
			{
				mainStocks.IncreaseGold();
			}
		}
	}
}
