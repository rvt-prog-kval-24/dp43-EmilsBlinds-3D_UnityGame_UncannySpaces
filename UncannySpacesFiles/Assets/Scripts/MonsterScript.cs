using UnityEngine;

public class MonsterScript : MonoBehaviour
{
	public Rigidbody monsRigid;

	public Transform monsTrans;

	public Transform playTrans;

	public int monsSpeed;

	private void FixedUpdate()
	{
		monsRigid.velocity = base.transform.forward * monsSpeed * Time.deltaTime;
	}

	private void Update()
	{
		monsTrans.LookAt(playTrans);
	}
}
