using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ControlLayout
{
    public string JumpButton;
    public string RotationButtons;
    public string MovementButtons;
}

[System.Serializable]
public struct CharacterInfo
{
    public float JumpSpeed;
    public float MovementSpeed;
    public float RotationSpeed;
    public int Lives;
}

public class PlayerControls : MonoBehaviour {

    public ControlLayout controls;
    public CharacterInfo character;

    public GameObject Checkpoint;
    public Rigidbody rb;
    public float DeathYCoordinate;

    bool Jumping = false;
    bool OnIce = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void Move()
    {
        if(Input.GetButtonDown(controls.JumpButton) && !Jumping)
        {
            rb.AddForce(transform.up * character.JumpSpeed * Time.deltaTime);
            Debug.Log("Jumping");
            Jumping = true;
        }

        float rotation = Input.GetAxis(controls.RotationButtons);
        float movement = Input.GetAxis(controls.MovementButtons);
        rb.AddForce(transform.forward * movement * character.MovementSpeed * Time.deltaTime);
        //transform.Translate(0,0,movement * character.MovementSpeed * Time.deltaTime);
        transform.Rotate(0, rotation * character.RotationSpeed * Time.deltaTime, 0);

        //if(OnIce)
        //{
        //    rb.velocity = rb.velocity + rb.velocity.normalized * 100 * Time.deltaTime;
        //    Debug.Log(rb.velocity.ToString());
        //    Debug.Log("On Ice");

        //}

        if (transform.position.y <= DeathYCoordinate)
        {
            //kill player
            PlayerDeath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                Jumping = false;
                Debug.Log("Normal Floor");
                OnIce = false;

                break;
            case "IceFloor":
                Jumping = false;
                OnIce = true;
                Debug.Log("Ice Floor");

                break;
            case "Hazard":
                Jumping = false;
                break;
            case "Pickup":
                Jumping = false;
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Checkpoint":
                Checkpoint = other.gameObject;
                break;
            case "Hazard":
                break;
            case "Pickup":
                break;
        }
    }

    private void PlayerDeath()
    {
        if(character.Lives > 0)
        {
            // RESPAWN
            transform.position = Checkpoint.transform.position;
            character.Lives--;
        }
        else
        {
            // GAME OVER
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        Move();

	}
}
