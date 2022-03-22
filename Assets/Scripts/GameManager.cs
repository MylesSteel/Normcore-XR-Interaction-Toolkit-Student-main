using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;
using System;

public class GameManager : MonoBehaviour
{
    public RealtimeAvatarManager _avatarManager;
    public Realtime _realtime;
    public GameObject _ball;
    public Transform _spawnPoint;
    public RoomStart roomStart;
    public ActionBasedContinuousMoveProvider conMove;
    void Awake()
    {
        _avatarManager.avatarCreated += AvatarCreated;
    }
    public void StartGame()
    {
        conMove.enabled = true;
        if (_realtime.clientID == 0)
        {
            SpawnBalls();
        }
    }

    private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        if (_avatarManager.avatars.Count ==2)
        {
            roomStart.StartCountdown();
            
        }
    }
    void SpawnBalls()
    {
        var options = new Realtime.InstantiateOptions
        {
            ownedByClient = false,
            preventOwnershipTakeover = false,
            useInstance = _realtime
        };
        GameObject tempObject = Realtime.Instantiate(_ball.name, _spawnPoint.position, Quaternion.identity, options);
    }
}
