using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityEngine.SceneManagement;

public class RecordingManager : MonoBehaviour
{
    public List<Primitive> leftPrimitives = new List<Primitive>();
    public List<Primitive> rightPrimitives = new List<Primitive>();

    [SerializeField]
    private RiggedHand leftRigged;
    [SerializeField]
    private RiggedHand rightRigged;

    
    private List<Transform> leftJoint;
    private List<Transform> rightJoint;

    private bool isRecordingStart;
    private bool recordingWas;


    // Start is called before the first frame update
    void Start()
    {
        recordingWas = false;
        leftJoint = leftRigged.JointList;
        rightJoint = rightRigged.JointList;
        for (int i = 0; i < leftJoint.Count; i++)
            leftPrimitives.Add(new Primitive());
        for (int i = 0; i < rightJoint.Count; i++)
            rightPrimitives.Add(new Primitive());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRecordingStart = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            recordingWas = true;
            isRecordingStart = false;
            WriteGesture();
        }

        if (isRecordingStart)
        {
            for(int i = 0; i < leftJoint.Count && i < rightJoint.Count; i++)
            {
                leftPrimitives[i].WriteTransform(leftJoint[i]);
                rightPrimitives[i].WriteTransform(rightJoint[i]);
            }
        }
    }

    public void WriteGesture()
    {
        Gesture handGesture = new Gesture();
        handGesture.AddRange(leftPrimitives.ToArray(), rightPrimitives.ToArray());
        JsonGestureWriter gestureWriter = new JsonGestureWriter(Application.dataPath + "\\Gestures");
        gestureWriter.Write(handGesture, SceneManager.GetActiveScene().name);

        foreach (var primitive in leftPrimitives)
        {
            primitive.Clear();
        }
        foreach (var primitive in rightPrimitives)
        {
            primitive.Clear();
        }
    }
}
