/// <summary>
/// Kick ball.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class KickBall : Action
	{ 
		private Agent mAgent;
		private Ball Ball;

		private Vector3 ballLocation;
		private Vector3 agentLocation;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			Ball = mAgent.GetBall().GetComponent<Ball> ();
		}

		public override TaskStatus OnUpdate()
		{
			ballLocation = mAgent.GetBallLocation ();
			agentLocation = mAgent.transform.position;
			if (Mathf.Abs (agentLocation.x - ballLocation.x) < Define.CanKickBallDistance && Mathf.Abs (agentLocation.z - ballLocation.z) < Define.CanKickBallDistance)
			{
				mAgent.transform.LookAt (Define.RightDoorPosition);
				Ball.AddForce (ballLocation,Define.RightDoorPosition);  
				return TaskStatus.Success;  
			} 
			else 
			{ 
				mAgent.SetDestination (ballLocation); 
				return TaskStatus.Running;    
			}  
		}


	}
}   
