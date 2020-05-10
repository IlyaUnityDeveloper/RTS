using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Используется на объектах Warrior и Slave
public class Selectable : MonoBehaviour
{
    public Vector3 centerOfObject; //Центр объекта
	public bool unitIsSelected = false; //Выделен ли объект
	
	void Update()
	{
		centerOfObject = Camera.main.WorldToScreenPoint(transform.position); //Установить центр объекта
	}
	
	void OnGUI()
	{
		//Если юнит выделен, он помечается
		if (unitIsSelected)
		{
			GUI.Label(new Rect(centerOfObject.x-10, Screen.height-centerOfObject.y-10, 20, 20), "v");
		}
	}
}
