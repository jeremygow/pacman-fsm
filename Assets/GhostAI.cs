using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	public StateMachine<GhostAI> FSM { get; set; }

	public void Start() {
		FSM = new StateMachine<GhostAI>(this);
		FSM.Current = new ScatterState();
	}
	
	public void Update() {
		FSM.update();
	}
	
	public void reverseDirection() {  }
	public void moveToHomeCorner() {  }
	public bool isAttackWave() { return true; }
	public bool seePoweredPacMan() { return true; }                                         
}

public interface State<A> {
	void enter(A agent);
	void execute(A agent);
	void exit(A agent);
}

public class StateMachine<A> {
	
	public A Agent { get; set; } 
	public State<A> Current { get; set; } 
	
	public StateMachine(A a) { Agent = a; }
	
	public void changeState(State<A> next) {
		Current.exit(Agent);
		Current = next;
		Current.enter(Agent);
	}
	
	public void update() {
		Current.execute(Agent);
	}
}                                         


public class ScatterState : State<GhostAI> {
	
	public void enter(GhostAI ghost) {
		ghost.reverseDirection();
	}
	
	public void execute(GhostAI ghost) {
		
		ghost.moveToHomeCorner();
		
		if (ghost.isAttackWave()) {
			//ghost.FSM.changeState(new AttackState());
			
		} else if (ghost.seePoweredPacMan()) {
			//ghost.FSM.changeState(new ScaredState());
		}
	}	
	
	public void exit(GhostAI ghost) {}
}


