using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsGoalKeeper : Conditional
	{ 
		private Agent agent;
		private bool bGoalKeeper;

		public override void OnStart ()
		{
			agent = GetComponent<Agent> ();
		}

		public override TaskStatus OnUpdate()
		{
			bGoalKeeper = agent.GetAgentType () == AgentType.GoalKeeper;
			if (bGoalKeeper) {
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  

			}
		}


	}
}    
