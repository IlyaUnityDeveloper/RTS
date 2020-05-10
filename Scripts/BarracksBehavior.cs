using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Используется на объекте Barracks
public class BarracksBehavior : MonoBehaviour
{
    public GameObject warrior;
	public GameObject slave;
	[SerializeField]
	private MainStocks mainStocks;
	
	void Start()
	{
		mainStocks = Camera.main.GetComponent<MainStocks>(); //Получение информации о ресурсах
	}
	
	void OnGUI()
	{		
		//Найм рабочего
		if (GUI.Button(new Rect(10, Screen.height - 60, 300, 20), "Нанять Рабочего (5 золотых)"))
		{
			Hire(slave, 5f);
		}
		
		//Найм воина
		if (GUI.Button(new Rect(10, Screen.height - 30, 300, 20), "Нанять Воина (10 золотых)"))
		{
			Hire(warrior, 10f);
		}
	}
	
	void Hire (GameObject unit, float price)
	{
		if (mainStocks.gold >= price)
		{
			Instantiate(unit, transform.position + new Vector3(0.1f, 0.2f, 0), transform.rotation);
			mainStocks.gold -= price;
		}
	}
}
