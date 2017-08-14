using UnityEngine;
using System.Collections;

public class AutoWalkController : MonoBehaviour {

	[SerializeField] Camera m_Camera;
	[SerializeField] UnityEngine.AI.NavMeshAgent agent;
	private RaycastHit hit = new RaycastHit();

	void Awake(){
		//agent = GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray,out hit,100);
			if(null != hit.transform)
			{
				print(hit.point);
				agent.SetDestination (hit.point);
			}
		}
	}

	//动态设置寻路路径层  
	void OnGUI()  
	{  
		if (GUI.Button(new Rect(0, 0, 100, 50), "走下层"))  
		{  
			agent.walkableMask = 1;  
		}  

		if (GUI.Button(new Rect(0, 100, 100, 50), "走上层"))  
		{  
			agent.walkableMask = 2;  
		}  
	} 
}
