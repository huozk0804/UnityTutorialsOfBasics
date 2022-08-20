using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _2BuildingAGraph
{
    public class Graph : MonoBehaviour
    {
        [SerializeField] private Transform pointPrefab;
        [SerializeField, Range(10, 100)] int resolution = 10;

        private Transform[] points;

        void Awake()
        {
            // int i = 0;
            // while (i++ < 10)
            float step = 2f / resolution;
            var position = Vector3.zero;
            var scale = Vector3.one * step;
            points = new Transform[resolution];
            for (int i = 0; i < points.Length; i++)
            {
                // i = i + 1;
                Transform point = points[i] = Instantiate(pointPrefab);
                //point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);
                position.x = (i + 0.5f) * step - 1f;
                // position.y = position.x * position.x * position.x;
                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform, false);
            }

            // point = Instantiate(pointPrefab);
            // point.localPosition = Vector3.right * 2f;
        }

        private void Update()
        {
            float time = Time.time;
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                Vector3 position = point.localPosition;
                position.y = Mathf.Sin(Mathf.PI * (position.x + time));
                point.localPosition = position;
            }
        }
    }
}