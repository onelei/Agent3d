using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsDefence : Conditional
	{ 
		private Agent agent;
		private bool bDefence;

		public override void OnStart ()
		{
			agent = GetComponent<Agent> ();
		}

		public override TaskStatus OnUpdate()
		{
			bDefence = agent.GetAgentType () == AgentType.Defence;
			if (bDefence) {
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  

			}
		}


	}
}    
