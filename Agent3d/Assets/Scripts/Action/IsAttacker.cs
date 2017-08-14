using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsAttacker : Conditional
	{ 
		private Agent agent;
		private bool bAttack;

		public override void OnStart ()
		{
			agent = GetComponent<Agent> ();
		}

		public override TaskStatus OnUpdate()
		{
			bAttack = agent.GetAgentType () == AgentType.Attack;
			if (bAttack) {
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  

			}
		}


	}
}   

