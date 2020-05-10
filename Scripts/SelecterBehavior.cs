using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Используется на объекте MainCamera
public class SelecterBehavior : MonoBehaviour
{
    [SerializeField]
	private Vector2 startOfSelectArea; //Позиция курсора при нажатии, начало выделения
	[SerializeField]
	private Vector2 endOfSelectArea; //Позция курсора при удерживании, конец выделения
	public Texture textureOfSelectArea;
	[SerializeField]
	private Vector2 widthOfSelectArea; //Расстояние от начала рамки до конца
	[SerializeField]
	private Rect regionOfSelectArea;
	[SerializeField]
	private GetAllObjects getAllObjects;
	
	void Start()
	{
		getAllObjects = GetComponent<GetAllObjects>();
	}
	
	void Update()
	{
		//Область выделения
		regionOfSelectArea = new Rect(0, 0, 0, 0);
		
		widthOfSelectArea.x = endOfSelectArea.x - startOfSelectArea.x;
		widthOfSelectArea.y = endOfSelectArea.y - startOfSelectArea.y;
		
		//Данные строчки кода необходимы для того, чтобы игрок мог выделять в рамку с любой стороны
		if (widthOfSelectArea.x < 0)
		{
			regionOfSelectArea.x = endOfSelectArea.x;
			regionOfSelectArea.width = -widthOfSelectArea.x;
		}
		
		if (widthOfSelectArea.x > 0)
		{
			regionOfSelectArea.x = startOfSelectArea.x;
			regionOfSelectArea.width = widthOfSelectArea.x;
		}
		
		if (widthOfSelectArea.y < 0)
		{
			regionOfSelectArea.y = endOfSelectArea.y;
			regionOfSelectArea.height = -widthOfSelectArea.y;
		}
		
		if (widthOfSelectArea.y > 0)
		{
			regionOfSelectArea.y = startOfSelectArea.y;
			regionOfSelectArea.height = widthOfSelectArea.y;
		}
		
		//Выделение объектов
		if (Input.GetMouseButton(0))
		{
			endOfSelectArea = Input.mousePosition;
			
			foreach (GameObject i in getAllObjects.selectable)
			{
				i.GetComponent<Selectable>().unitIsSelected = false;
				
				if (regionOfSelectArea.Contains(i.GetComponent<Selectable>().centerOfObject))
				{
					i.GetComponent<Selectable>().unitIsSelected = true;
				}
			}
		}
		
		if (Input.GetMouseButtonDown(0))
		{
			startOfSelectArea = Input.mousePosition;
			regionOfSelectArea = new Rect(0, 0, 0, 0);
		}
		
		//Сброс выделения
		if (Input.GetMouseButtonUp(0))
		{
			startOfSelectArea = Vector2.zero;
			endOfSelectArea = Vector2.zero;
		}
	}
	
	void OnGUI()
	{
		//Отображать рамку
		GUI.DrawTexture(new Rect(startOfSelectArea.x, Screen.height - startOfSelectArea.y, endOfSelectArea.x - startOfSelectArea.x, startOfSelectArea.y - endOfSelectArea.y), textureOfSelectArea);
	}
}
