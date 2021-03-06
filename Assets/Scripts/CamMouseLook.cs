﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{
	public float sensitivity = 3f;
	public float smoothing = 2f;

	Vector2 mouseLook;
	Vector2 smoothV;
	GameObject character;

	// Start is called before the first frame update
	void Start()
    {
		character = this.transform.parent.gameObject;
	}

    // Update is called once per frame
    void Update()
    {
		if (PauseMenu.isPaused == false)
		{
			var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

			md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
			smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
			smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
			mouseLook += smoothV;
			//-85, 62
			mouseLook.y = Mathf.Clamp(mouseLook.y, -85f, 62f);

			transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
			character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
		}
	}
}
