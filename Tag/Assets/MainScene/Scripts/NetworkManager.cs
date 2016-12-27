﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	private HostData[] hostList;
	private const string typeName = "TagVariationGameTesting";
	private const string gameName = "TestRoom";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void StartServer(){
		Network.InitializeServer(2,25000,!Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName,gameName);
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
	}

	void OnGUI(){
		if (!Network.isClient && !Network.isServer){
			if (GUI.Button(new Rect(100,100,250,100),"Start Server")){
				StartServer();
			}
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts")){
            RefreshHostList();
        }
 
	        if (hostList != null)
    	    	{
        	    for (int i = 0; i < hostList.Length; i++)
            {
                if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                    JoinServer(hostList[i]);
            }
        }
		}
	}


private void RefreshHostList()
{
    MasterServer.RequestHostList(typeName);
}
 
void OnMasterServerEvent(MasterServerEvent msEvent)
{
    if (msEvent == MasterServerEvent.HostListReceived)
        hostList = MasterServer.PollHostList();
}

private void JoinServer(HostData hostData)
{
    Network.Connect(hostData);
}
 
void OnConnectedToServer()
{
    Debug.Log("Server Joined");
}

}
