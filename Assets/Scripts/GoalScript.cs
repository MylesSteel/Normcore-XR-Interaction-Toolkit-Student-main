using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GoalScript : MonoBehaviour
{
    [SerializeField] int playerID;
    [SerializeField] ScoreboardScript scoreboardScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            RealtimeTransform tempTransform = collision.gameObject.GetComponent<RealtimeTransform>();
            if (tempTransform.isOwnedLocallySelf && tempTransform.ownerIDSelf == playerID)
            {
                scoreboardScript.SetScore((uint)tempTransform.ownerIDSelf);
            }
        }
    }
}
