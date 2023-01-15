using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float turnSpeed=20f;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation =Quaternion.identity;

    private float positionRange = 5f;
    
    protected Joystick joystick;
   

    // Start is called before the first frame update
    void Start()
    {
      m_Animator= GetComponent<Animator>();
      m_Rigidbody= GetComponent<Rigidbody>();
      m_AudioSource=GetComponent<AudioSource>();
      joystick = FindObjectOfType<Joystick>();
    }

    public override void OnNetworkSpawn()
    {
       transform.position = new Vector3(Random.Range(positionRange, -positionRange),0, Random.Range(positionRange, -positionRange));
       transform.rotation = new Quarternion(0, 180, 0 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(!IsOwner) return;

       float horizontal= joystick.Horizontal;
       float vertical= joystick.Vertical;
      // int horizontal = x;
      // int vertical = y;

      // currentDirection = new Vector2(x,y);

       m_Movement.Set(horizontal, 0f, vertical);
       m_Movement.Normalize(); // so that diagonal movement is not any faster than vertical or horizonatal movement owing to pythagoras theorem

       bool hasHorizontalInput= !Mathf.Approximately(horizontal,0f);
       //true if both parameters are approximately equal. hence when horizontal input is near 0
       bool hasVerticalInput= !Mathf.Approximately(vertical,0f);

       bool isWalking= hasHorizontalInput || hasVerticalInput;
       m_Animator.SetBool("IsWalking", isWalking);
       
       if(isWalking)
       {
          if(!m_AudioSource.isPlaying)
          {
            m_AudioSource.Play();
          }
       }
       else
       {
          m_AudioSource.Stop();
       }

       Vector3 desiredforward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
       m_Rotation = Quaternion.LookRotation (desiredforward);
    }

    void OnAnimatorMove()
    {
         m_Rigidbody.MovePosition(m_Rigidbody.position +m_Movement * m_Animator.deltaPosition.magnitude);
         m_Rigidbody.MoveRotation (m_Rotation);
    }

   //  public void MoveLeft()
   //  {
   //     x = -1;
   //  }

   // public void MoveRight()
   //  {
   //     x = 1;
   //  }
   // public void MoveUp()
   //  {
   //     y = 1;
   //  }
   // public void MoveDown()
   // {
   //     y = -1;
   // }
        
}