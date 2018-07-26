using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public Transform[] PatrolPoints;
    public float MovementSpeed;
    public float MinDistanceToPoint;
    public float PauseDuration;
    public float DampingTurn;
    public bool RandomPatrol;
    public Vector3 MovementVariable;
    private int destinationPoint = 0;
    private float curTime;
    
	// Use this for initialization
	void Start () {

	}
	
    void GotoNextPoint()
    {
        if (PatrolPoints.Length == 0)
            return;

        if (RandomPatrol)
            destinationPoint = Random.Range(0, PatrolPoints.Length - 1);
        else
            destinationPoint = (destinationPoint + 1) % PatrolPoints.Length;
        
    }



	// Update is called once per frame
	void Update ()
    {
        Vector3 target = PatrolPoints[destinationPoint].position;
        //transform.LookAt(target);
        
        //target.y = transform.position.y;

        Vector3 moveDir = target - transform.position;

        if (moveDir.magnitude < MinDistanceToPoint)
        {
            if (curTime == 0)
                curTime = Time.time;
            if ((Time.time - curTime) >= PauseDuration)
            {
                GotoNextPoint();
                curTime = 0;
            }
        }
        else
        {
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * DampingTurn);

            transform.Translate(moveDir.normalized * MovementSpeed * Time.deltaTime);
            MovementVariable = (moveDir.normalized * MovementSpeed * Time.deltaTime);
        }


    }
}
