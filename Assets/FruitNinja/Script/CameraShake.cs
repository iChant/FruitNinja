﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private bool isshakeCamera = false;
	public float shakeLevel = 5f;
	public float setShakeTime = 1.5f;
	public float shakeFps = 45f;
	private float fps;
	private float shakeTime = 0.0f;
	private float frameTime = 0.0f;
	private float shakeDelta = 0.005f;
	private Camera selfCamera;
	private static CameraShake instance = null;
	void Awake()
	{
		selfCamera = GetComponent<Camera>();
		instance = this;
	}
	// Use this for initialization
	void Start()
	{
		shakeTime = setShakeTime;
		fps = shakeFps;
		frameTime = 0.03f;
		shakeDelta = 0.03f;
		
	}
	// Update is called once per frame
	void Update()
	{
		if (isshakeCamera)
		{
			if (shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0)
				{
					selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
					isshakeCamera = false;
					shakeTime = setShakeTime;
					fps = shakeFps;
					frameTime = 0.03f;
					shakeDelta = 0.03f;
				}
				else
				{
					frameTime += Time.deltaTime;
					if (frameTime > 1.0 / fps)
					{
						frameTime = 0;
						selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * Random.value), shakeDelta * (-1.0f + shakeLevel * Random.value), 1.0f, 1.0f);
					}
				}
			}
		}
	}
	public void shake()
	{
		isshakeCamera = true;
	}
	public static CameraShake Instance{
		get{
			return instance;
		}
	}

}
