using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BubbleBobble
{
    public class BubbleTeleportTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("Bubble"))
            {
                Transform bubblePos = collider.gameObject.transform;
                bubblePos.position = new Vector2(bubblePos.position.x, transform.position.y);
            }
        }
    }
}
