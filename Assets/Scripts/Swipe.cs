using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Start is called before the first frame update
    public int minSwipeRecognition = 500;
    private Vector2 swipePosLastFrame;
    private Vector2 swipePosCurrentFrame;
    public Vector2 currentSwipe;
    //private Vector3 travelDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         if(Input.GetMouseButton(0))
        {
            swipePosCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if(swipePosLastFrame != Vector2.zero)
            {
                currentSwipe = swipePosCurrentFrame - swipePosLastFrame;

                if(currentSwipe.sqrMagnitude < minSwipeRecognition)
                    return;

                //Get the Direction, not the distance
                currentSwipe.Normalize();

                //Give Direction to travel
                // if(currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                // {
                //     SetDestination(currentSwipe.y > 0? Vector3.forward : Vector3.back);
                // }
                // if(currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                // {
                //     SetDestination(currentSwipe.x >0? Vector3.right : Vector3.left);
                // }
            }

            swipePosLastFrame = swipePosCurrentFrame;
        }

        if(Input.GetMouseButtonUp(0))
        {
            swipePosLastFrame = Vector2.zero;
            currentSwipe = Vector2.zero;
        }
    }

}
