using Irc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TwitchIrc))]
public class TwitchMessageGenerator : MessageGenerator
{
    void Start()
    {
        this.twitch = GetComponent<TwitchIrc>();

        this.twitch.OnChannelMessage += this.OnChannelMessage;
        this.twitch.OnConnected += this.OnConnected;
        this.twitch.OnExceptionThrown += this.OnExceptionThrown;
        this.twitch.OnServerMessage += this.OnServerMessage;
        this.twitch.OnUserJoined += this.OnUserJoined;
        this.twitch.OnUserLeft += this.OnUserLeft;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private TwitchIrc twitch = null;

    private void Log(string message)
    {
        Debug.Log(message);
    }

    private void OnConnected()
    {
        Log("Twitch: Connected!");
    }

    private void OnChannelMessage(ChannelMessageEventArgs channelMessageArgs)
    {
        Log("Twitch: Channel message received (" + channelMessageArgs.Channel + "/" + channelMessageArgs.From + "/" + channelMessageArgs.Message + ")");
        Executor.Message message = new Executor.Message();
        message.from = channelMessageArgs.From;
        message.message = channelMessageArgs.Message;
        message.type = Executor.Message.Type.channel;
        this.OnMessageReceived(message);
    }

    private void OnExceptionThrown(Exception exeption)
    {
        Log("Twitch: Exception thrown (" + exeption.Message + ")");
    }

    private void OnServerMessage(string serverMessage)
    {
        Log("Twitch: Server message received (" + serverMessage + ")");
        Executor.Message message = new Executor.Message();
        message.from = "server";
        message.message = serverMessage;
        message.type = Executor.Message.Type.server;
        this.OnMessageReceived(message);
    }

    private void OnUserJoined(UserJoinedEventArgs userJoinedArgs)
    {
        Log("Twitch: User joined (" + userJoinedArgs.Channel + "/" + userJoinedArgs.User + ")");
        Executor.Message message = new Executor.Message();;
        message.from = userJoinedArgs.User;
        message.message = "joined";
        message.type = Executor.Message.Type.server;
        this.OnMessageReceived(message);
    }

    private void OnUserLeft(UserLeftEventArgs userLeftArgs)
    {
        Log("Twitch: User left (" + userLeftArgs.Channel + "/" + userLeftArgs.User + ")");
        Executor.Message message = new Executor.Message();;
        message.from = userLeftArgs.User;
        message.message = "left";
        message.type = Executor.Message.Type.server;
        this.OnMessageReceived(message);;
    }

}
    