using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCamPan : MonoBehaviour
{
   public float Speed = 6f;
   private Camera cam;
   public Vector2 panLimitX;
   public Vector2 panLimitZ;

   private void Awake()
   {
      cam = GetComponentInChildren<Camera>();
   }

   private void Update()
   {
      //pass the paramters
      Vector2 panPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

      transform.position += new Vector3(panPosition.x, panPosition.y, 0) * (Speed * Time.deltaTime);
      
      //takes nre postion and clamps
      transform.position = new Vector3(
         Mathf.Clamp(transform.position.x, panLimitX.x, panLimitX.y),
         Mathf.Clamp(transform.position.y, panLimitZ.x, panLimitZ.y),
         transform.position.z);
   }
}


