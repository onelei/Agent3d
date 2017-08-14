/// <summary>
/// Can see ball.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class CanSeeBall : Conditional
	{ 
		private Agent Agent;
		private Ball Ball;

		public override void OnStart ()
		{
			Agent = GetComponent<Agent> ();
			Ball = Agent.GetBall().GetComponent<Ball> ();
		}

		public override TaskStatus OnUpdate()
		{
			if (Condition.CanSeeBall(Agent.transform.position,Ball.transform.position)) {
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  

			}
		}


	}
}  