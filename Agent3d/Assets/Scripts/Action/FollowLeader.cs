using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using System.Collections.Generic;

namespace FootBallGame
{
	public class FollowLeader : Action
	{ 
		private Agent mAgent;
		private Ball Ball;

		private Vector3 ballLocation;
		private Vector3 agentLocation;

		private List<Agent> agentTeam;
		private Agent leader;
		private bool bLeft;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			Ball = mAgent.GetBall().GetComponent<Ball> ();
			bLeft = mAgent.GetTeamDirection ();
			agentTeam = GameManager.Instance.GetAttackAgentList (bLeft);
		}

		public override TaskStatus OnUpdate()
		{
			ballLocation = mAgent.GetBallLocation ();
			agentLocation = mAgent.transform.position;
			leader =  GameManager.Instance.GetLeader(bLeft);
			for (int i = 0; i < agentTeam.Count; i++) {
				UpdateTargetPosition (i);
			} 
			return TaskStatus.Running;    
		}

		private void UpdateTargetPosition(int index)
		{
			Vector3 fixPosition;
			for (int i = 0; i < agentTeam.Count; i++) {
				if(agentTeam[i].GetNumber()!=leader.GetNumber())
				{
					fixPosition = leader.transform.position;
					if (bLeft) {
						agentTeam [i].SetDestination (new Vector3 (fixPosition.x - i * 2, 0, fixPosition.z));
					} else {
						agentTeam [i].SetDestination (new Vector3 (fixPosition.x + i * 2, 0, fixPosition.z));
					}
				}
			}
		} 
	}
}   
