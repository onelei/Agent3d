using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace FootBallGame
{
	public enum AgentType
	{
		Attack,
		Defence,
		GoalKeeper,
	}

	public class Agent : MonoBehaviour
	{
		[SerializeField] NavMeshAgent navMeshagent;
		[SerializeField] Transform Ball;
		[SerializeField] TextMesh Text_Num;
		//[SerializeField] Camera camera;

 		private bool bLeft;
		private int num;
		private Vector3 InitPos;
		private AgentType agentType;
 
		public void SetData (bool bLeft, int num, Transform ball)
		{
			this.bLeft = bLeft;
			this.num = num;
			// set agent type;
			if (num == Define.GoalKeeperNumber) {
				this.agentType = AgentType.GoalKeeper;
			} else if (num <= Define.AttackNumber) {
				this.agentType = AgentType.Attack;
			} else {
				this.agentType = AgentType.Defence;
			}

			//this.agentType = AgentType.Attack;
			navMeshagent.speed = 5f;
			this.InitPos = transform.position;
			Ball = ball;
			#if UNITY_EDITOR
			gameObject.name = bLeft ? "PlayerLeft" + this.num : "PlayerRight" + this.num;
			#endif
			Text_Num.text = this.num.ToString ();
		}

		public bool GetTeamDirection ()
		{
			return this.bLeft;
		}

		public void SetDestination (Vector3 target)
		{
			navMeshagent.enabled = true;
			navMeshagent.SetDestination (target);
		}

		public Vector3 GetBallLocation ()
		{
			return Ball.position;
		}

		public GameObject GetBall ()
		{
			return Ball.gameObject;
		}

		public NavMeshAgent GetNavAgent ()
		{
			return this.navMeshagent;
		}

		public int GetNumber ()
		{
			return this.num;
		}

		public AgentType GetAgentType ()
		{
			return this.agentType;
		}

		public bool MoveEnd ()
		{
			return navMeshagent.remainingDistance <= 0.1;
		}

		public void ReStart ()
		{
			transform.position = InitPos;
		}
 
	}
}