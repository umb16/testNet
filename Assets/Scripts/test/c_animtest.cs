using UnityEngine;
using System.Collections;

public class c_animtest : MonoBehaviour
{
	/*int opponentIndex;
	private static float[] oldHp = new float[2];
	public Animator[] anim;
	public static int testTurns = 0;
	private static int[] command = new int[]{0,0};
	public Transform[] playerTransform;
	static int attackState = Animator.StringToHash ("Base Layer.attack");
	static int dmgState = Animator.StringToHash ("Base Layer.dmg");
	static int dieState = Animator.StringToHash ("Base Layer.die");
	static int diehardState = Animator.StringToHash ("Base Layer.diehard");
	static int resistState = Animator.StringToHash ("Base Layer.resist");
	static int idleState = Animator.StringToHash ("Base Layer.idle");
	static int idle0State = Animator.StringToHash ("Base Layer.idle");
	bool damageOnce = false;
	AnimatorStateInfo baseState;
	// Use this for initialization
	void Start ()
	{
		oldHp [0] = client.thisClass.clientPlayer.hp;
		oldHp [1] = client.thisClass.opponentPlayer.hp;
	}
	
	public static void setCommand ()
	{
		testTurns = client.thisClass.order;
		if (client.thisClass.clientPlayer.hp < 1)
			command [1] = Constants.kill;
		else if (oldHp [1] == client.thisClass.clientPlayer.hp)
			command [1] = Constants.block;
		else
			command [1] = Constants.bit;
		if (client.thisClass.opponentPlayer.hp < 1)
			command [0] = Constants.kill;
		else if (oldHp [1] == client.thisClass.opponentPlayer.hp)
			command [0] = Constants.block;
		else
			command [0] = Constants.bit;
		oldHp [0] = client.thisClass.clientPlayer.hp;
		oldHp [1] = client.thisClass.opponentPlayer.hp;
	}
	
	void delay ()
	{
		testTurns = Mathf.Abs (testTurns - 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i=0; i<anim.Length; i++) {
			opponentIndex = Mathf.Abs (i - 1);
			baseState = anim [i].GetCurrentAnimatorStateInfo (0);
			if (command [i] > 0 && i == testTurns) {
				Invoke ("delay", 2);
				anim [i].SetInteger ("animIndex", 1);
				if (command [i] > 2) {
					anim [opponentIndex].SetInteger ("animIndex", 3);
					command [i] = 0;
				}
			}
			if (baseState.nameHash == idleState || baseState.nameHash == idle0State) {
				damageOnce = false;
				playerTransform [i].position = new Vector3 (playerTransform [i].position.x, 0, playerTransform [i].position.z);
			}
			if (baseState.nameHash == attackState) {
				
				
				if (anim [i].GetFloat ("bit") > 0.1f && !damageOnce) {
					damageOnce = true;
					if (command [i] == Constants.bit)
						anim [opponentIndex].SetInteger ("animIndex", 4);
					if (command [i] == Constants.kill) {
						if (i == 0)
							client.loginstatus = Constants.win;
						else
							client.loginstatus = Constants.loose;
						anim [opponentIndex].SetInteger ("animIndex", 2);
					}
					command [i] = 0;
				}
				if (!anim [i].IsInTransition (0)) {
					
					anim [i].SetInteger ("animIndex", 0);
					//playerTransform[i].position=new Vector3(playerTransform[i].position.x,0,playerTransform[i].position.z);
				}
			} else if (baseState.nameHash == dmgState) {
				if (!anim [i].IsInTransition (0))
					anim [i].SetInteger ("animIndex", 0);
			} else if (baseState.nameHash == resistState) {
				if (!anim [i].IsInTransition (0))
					anim [i].SetInteger ("animIndex", 0);
			}
		}
	}*/
}
