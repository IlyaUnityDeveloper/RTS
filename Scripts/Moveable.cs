using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Используется на объектах Warrior и Slave
[RequireComponent(typeof(Selectable))]
public class Moveable : MonoBehaviour
{
	[SerializeField]
	private Selectable selectable;
	[SerializeField]
	private NavMeshAgent agent;
	
	void Start()
	{
		selectable = GetComponent<Selectable>(); //Получение данных о выделении данного юнита
		agent = GetComponent<NavMeshAgent>();
	}
	
    void Update()
    {
        //Послать объект идти в... при нажатии ПКМ
		if ((Input.GetMouseButtonDown(1)) && (selectable.unitIsSelected))
        {
            SetDestinationToMousePosition();
        }
    }
	
	void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
