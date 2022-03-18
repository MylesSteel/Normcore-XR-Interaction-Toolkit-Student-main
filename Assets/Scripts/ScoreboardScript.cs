using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;
using System;

public class ScoreboardScript : RealtimeComponent<ScoreboardModel>
{
    public RealtimeAvatarManager _avatarManager;
    public Text _scoreboardText;
    public Realtime _realtime;

    private int GetScore(uint playerId)
    {
        return model.players[playerId].score;
    }
    public void SetScore(uint playerId)
    {
        model.players[playerId].score++;
    }
    private void AddPlayer(uint PlayerId)
    {
        PlayerDataModel newModel = new PlayerDataModel();
        newModel.score = 0;
        model.players.Add(PlayerId, newModel);
    }
    private void Awake()
    {
        _avatarManager.avatarCreated += AvatarCreated; 
    }

    private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        AddPlayer((uint)_realtime.clientID);
        SetScoreboardText();
    }

    private void OnEnable()
    {

    }

    void SetScoreboardText()
    {
        string temp = "";
        foreach(var item in model.players)
        {
            uint ID = item.Key + 1;
            temp += "Player " + ID + "; " + GetScore(item.Key) + "/n";
        }
        model.scoreBoardText = temp;
    }
    protected override void OnRealtimeModelReplaced(ScoreboardModel previousModel, ScoreboardModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.scoreBoardTextDidChange -= ScoreboardDidChange; 
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.scoreBoardText = "";

            }
            currentModel.scoreBoardTextDidChange += ScoreboardDidChange;
        }
    }

    private void ScoreboardDidChange(ScoreboardModel model, string value)
    {
        _scoreboardText.text = model.scoreBoardText;
    }
}
