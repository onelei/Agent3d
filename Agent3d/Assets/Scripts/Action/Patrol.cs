using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace FootBallGame
{
	public class Patrol : Action
	{
		/// <summary>
		/// The m agent.
		/// </summary>
		private Agent agent;
		private NavMeshAgent navMeshAgent;
		/// <summary>
		/// The init position.
		/// </summary>
		private Vector3 InitPos;
		/// <summary>
		/// The patrol position.
		/// </summary>
		private Vector3 PatrolPos1;
		private Vector3 PatrolPos2;
		private Vector3 PatrolPos3;
		private Vector3 PatrolPos4;
		private List<Vector3> PatrolPositions = new List<Vector3>();
		/// <summary>
		/// The patrol position.
		/// </summary>
		private Vector3 PatrolPos;
		private Vector3 agentPosition;
		/// <summary>
		/// The patrol range.
		/// </summary>
		private int range;
		private bool randomPatrol;

		public override void OnStart ()
		{
			agent = GetComponent<Agent> ();
			navMeshAgent = agent.GetNavAgent ();
			InitPos = agent.transform.position;
			PatrolPos1 = new Vector3 (InitPos.x+Define.Patrol_Circle,InitPos.y,InitPos.z+Define.Patrol_Circle);
			PatrolPos2 = new Vector3 (InitPos.x+Define.Patrol_Circle,InitPos.y,InitPos.z-Define.Patrol_Circle);
			PatrolPos3 = new Vector3 (InitPos.x-Define.Patrol_Circle,InitPos.y,InitPos.z-Define.Patrol_Circle);
			PatrolPos4 = new Vector3 (InitPos.x-Define.Patrol_Circle,InitPos.y,InitPos.z+Define.Patrol_Circle); 
			PatrolPositions.Add (PatrolPos1);
			PatrolPositions.Add (PatrolPos2);
			PatrolPositions.Add (PatrolPos3);
			PatrolPositions.Add (PatrolPos4);  

			// initially move towards the closest waypoint
			float distance = Mathf.Infinity;
			float localDistance;
			for (int i = 0; i < PatrolPositions.Count; ++i) {
				if ((localDistance = Vector3.Magnitude(agent.transform.position - PatrolPositions[i])) < distance) {
					distance = localDistance;
					range = i;
				}
			}
			PatrolPos = PatrolPositions[range]; 
			navMeshAgent.enabled = true;
			navMeshAgent.SetDestination(PatrolPos);

		} 

		// Patrol around the different waypoints specified in the waypoint array. Always return a task status of running. 
		public override TaskStatus OnUpdate()
		{
			//if (!navMeshAgent.pathPending) {
			agentPosition = agent.transform.position;
				//thisPosition.y = navMeshAgent.destination.y; // ignore y
				//if (Vector3.SqrMagnitude(thisPosition - navMeshAgent.destination) < 1f) {
			if (Mathf.Abs (agentPosition.x - PatrolPos.x) <1 && Mathf.Abs (agentPosition.z - PatrolPos.z) < 1) {
					range = (range + 1) % PatrolPositions.Count; 
					PatrolPos = PatrolPositions [range];  
					//agent.SetDestination (PatrolPos);
			}
			navMeshAgent.SetDestination (PatrolPos); 
			//}  
			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			// Disable the nav mesh
			//navMeshAgent.enabled = false;
		}
  
		// Reset the public variables
		public override void OnReset()
		{ 
			
		} 
	}
}

