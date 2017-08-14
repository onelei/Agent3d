using UnityEngine;
using UnityEngine.AI;

namespace FootBallGame
{
	public class Ball : MonoBehaviour
	{
		//[SerializeField] Camera Camera_Main;
		//[SerializeField] NavMeshAgent navMeshAgent;
		[SerializeField] Rigidbody body;

		private RaycastHit hit = new RaycastHit(); 
  
		public void AddForce(Vector3 form,Vector3 to)
		{ 
			Vector3 force = (to-form).normalized*Define.FORCE;
			body.AddForce (new Vector3(force.x,0,force.y), ForceMode.Impulse); 
		}
		public void AddForceBig(Vector3 form,Vector3 to)
		{ 
			Vector3 force = (to-form).normalized*Define.BIG_FORCE;
			body.AddForce (new Vector3(force.x,0,force.y), ForceMode.Impulse); 
		}
		public void BeforeKickOff()
		{
			transform.position = new Vector3(0,10000,0);
			body.velocity = Vector3.zero;
		}
		public void ReStart()
		{
			transform.position = Vector3.zero;
			body.velocity = Vector3.zero;
		}

		void Update()
		{
			/*if(Mathf.Abs(transform.position.z)>=Define.GoalBallZ)
			{
				transform.position = new Vector3 (transform.position.z,transform.position.y,0);
			}*/


			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray,out hit,100);
				if(null != hit.transform)
				{
					//print(hit.point);
					//navMeshAgent.SetDestination(new Vector3(hit.point.x,0,hit.point.z));
					transform.position = new Vector3(hit.point.x,0,hit.point.z);
					body.velocity = Vector3.zero;
					body.Sleep ();
				}
			}
		}
	}
}

