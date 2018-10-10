using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraScript {

	public void LookAt(Vector3 TargetPos)
	{
		this.transform.rotation = Quaternion.LookRotation (TargetPos - this.transform.position);
	}

	public void SmoothLookAt(Vector3 TargetPos, float Speed)
	{
		Quaternion targetRotation = Quaternion.LookRotation(TargetPos - this.transform.position);

		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * Time.deltaTime);
	}

	public void SmoothSetAt(Quaternion targetRotation, float Speed)
	{

		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * Time.deltaTime);
	}

	public void MoveToward(Vector3 TargetPos, float Speed)
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPos, Speed * Time.deltaTime);
	}

	public Vector3 Get3DMousePosition ()
	{
		return this.GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition);
	}

	public void SetPosition(Vector3 NewPos)
	{
		this.transform.position = NewPos;
	}

	public void MoveUp(float NewValue)
	{
		this.transform.position = this.transform.position + (new Vector3(0.0f, NewValue * Time.deltaTime, 0.0f));
	}

	public void MoveRight(float NewValue)
	{
		this.transform.position = this.transform.position + (new Vector3(NewValue * Time.deltaTime, 0.0f, 0.0f));
	}


	public void MoveForward(float NewValue)
	{
		this.transform.position = this.transform.position + (new Vector3(0.0f, 0.0f, NewValue * Time.deltaTime));
	}


	public void RotateRight(float NewValue)
	{
		transform.eulerAngles = new Vector3 (
			transform.eulerAngles.x,
			transform.eulerAngles.y + NewValue,
			0.0f
		);
	}

	public void RotateLeft(float NewValue)
	{
		transform.eulerAngles = new Vector3 (
			transform.eulerAngles.x,
			transform.eulerAngles.y - NewValue,
			0.0f
		);
	}

	public void RotateUp(float NewValue)
	{

		if (
			((transform.eulerAngles.x <= 90.0f) && (transform.eulerAngles.x >= 0.0f)) || 
			((transform.eulerAngles.x <= 360.0f) && (transform.eulerAngles.x >= 275.0f))
		)
		{
			transform.eulerAngles = new Vector3 (
				transform.eulerAngles.x - NewValue,
				transform.eulerAngles.y,
				0.0f
			);
		}
	}

	public void RotateDown(float NewValue)
	{

		if (
			((transform.eulerAngles.x <= 360.0f) && (transform.eulerAngles.x >= 270.0f)) || 
			((transform.eulerAngles.x >= 0.0f) && (transform.eulerAngles.x <= 85.0f))
		)
		{
			transform.eulerAngles = new Vector3 (
				transform.eulerAngles.x + NewValue,
				transform.eulerAngles.y,
				0.0f
			);
		}
		if (transform.eulerAngles.x < 0.0f)
			transform.eulerAngles = new Vector3 (
				0.0f,
				transform.eulerAngles.y,
				0.0f
			);
	}

	public Vector3 GetPosition()
	{
		return this.transform.position;
	}

	public float GetRotationX()
	{
		return this.transform.eulerAngles.x;
	}

	public float GetRotationY()
	{
		return this.transform.eulerAngles.y;
	}

	public float GetRotationZ()
	{
		return this.transform.eulerAngles.z;
	}

	public Vector3 GetRotation()
	{
		return this.transform.eulerAngles;
	}

	public void SetRotation(Vector3 Rot)
	{
		this.transform.eulerAngles = Rot;
	}

}
