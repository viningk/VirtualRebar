﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> boneInfo;
    public UnityEvent onGestureRecognized;
}
public class GestureRecognition : MonoBehaviour
{
    public bool m_recording;
    public string m_hand;
    public float m_threshold = 0.05f;
    public List<Gesture> m_gestures = new List<Gesture>();

    private OVRSkeleton m_skeleton;
    private List<OVRBone> m_bonePoints = new List<OVRBone>();
    private Gesture m_lastGesture;

    // Start is called before the first frame update
    void Start()
    {
        m_skeleton = GetComponentInChildren<OVRSkeleton>();
        m_bonePoints = new List<OVRBone>(m_skeleton.Bones);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_recording)
        {
            Debug.Log("Gesture saved");
            SaveGesture();
        }

        Gesture currentGesture = Recognized();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        //Check if a new gesture has been recognized
        if (hasRecognized && !currentGesture.Equals(m_lastGesture))
        {
            //NEW GESTURE!
            Debug.Log("New Gesture Found : " + currentGesture.name);
            m_lastGesture = currentGesture;
            currentGesture.onGestureRecognized.Invoke();
        }
    }

    void SaveGesture()
    {
        Gesture g = new Gesture();
        g.name = "NewGesture";
        List<Vector3> info = new List<Vector3>();

        foreach (var bone in m_bonePoints)
        {
            info.Add(m_skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.boneInfo = info;
        m_gestures.Add(g);
    }

    Gesture Recognized()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in m_gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < m_bonePoints.Count; i++)
            {
                Vector3 currentData = m_skeleton.transform.InverseTransformPoint(m_bonePoints[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.boneInfo[i]);
                if (distance > m_threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }

        return currentGesture;
    }
}
