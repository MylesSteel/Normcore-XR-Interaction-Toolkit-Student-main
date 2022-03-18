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
    void Awake()
    {
        _avatarManager.avatarCreated += AvatarCreated;
    }
    public void StartGame()
    {
        
    }

    private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        if (_avatarManager.avatars.Count == 1)
        {
            SpawnBalls();
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
