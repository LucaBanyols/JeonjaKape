﻿using UnityEngine;
using System.Collections;

public class LightOptimize : MonoBehaviour {

	public float availableDistance;
	private float Distance;
	private Light Lightcomponent;
	private GameObject Player;
	///------------------------------
	void Start(){
		Lightcomponent = gameObject.GetComponent<Light>();


		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			Player = GameObject.FindGameObjectWithTag("Player");
		} else {
			Destroy(GetComponent("LightOptimize"));
		}

	}

	// Update is called once per frame
	void Update () {


		Distance = Vector3.Distance(Player.transform.position, transform.position);


		if (Distance < availableDistance){
			Lightcomponent.enabled = true;    
		}
		if (Distance > availableDistance){
			Lightcomponent.enabled = false;
		}
	}

}