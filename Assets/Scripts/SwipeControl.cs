// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SwipeControl : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public SwipeControl swipeControls;
//     public Transform player;
//     private Vector3 desiredPosition;
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(swipeControls.SwipeLeft)
//             desiredPosition += Vector3.left;
//         if(swipeControls.SwipeLeft)
//             desiredPosition += Vector3.right;
//         if(swipeControls.SwipeUp)
//             desiredPosition += Vector3.forward;
//         if(swipeControls.SwipeDown)
//             desiredPosition += Vector3.back;

//         player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f*Time.deltaTime);
//     }
// }
