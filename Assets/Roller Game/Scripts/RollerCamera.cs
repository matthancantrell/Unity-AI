using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Range(2, 20)] private float distance;
    [SerializeField, Range(20, 80)] private float pitch;
	[SerializeField, Range(0.1f, 80)] private float sensitivity;

	private float yaw = 0;

	void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
		Quaternion qPitch = Quaternion.AngleAxis(yaw, Vector3.right);
        Quaternion rotation = qYaw * qPitch;

        Vector3 offset = rotation * Vector3.back * distance;

		transform.position = target.position + offset;
       transform.rotation = Quaternion.LookRotation(-offset);
    }
}
