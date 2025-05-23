using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsomZo : MonoBehaviour
{
   public float zSpeed = 6;
   public float zsmooth = 5;
   public float minSize = 2;
   public float maxSize = 40;
   private float _currentSize;
   private Camera _camera;

   private void Awake()
   {
      _camera = GetComponentInChildren<Camera>();
   }

   private void Update()
   {
      _currentSize = Mathf.Clamp(_currentSize - Input.mouseScrollDelta.y * zSpeed * Time.deltaTime, minSize, maxSize);
      _camera.orthographicSize = Mathf.MoveTowards(_camera.orthographicSize,_currentSize,zSpeed);
   }
}
