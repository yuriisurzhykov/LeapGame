using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;
using System;

public abstract class GestureMain : MonoBehaviour
{
    public AudioClip _leftTaskClip;
    public AudioClip _rightTaskClip;
    public AudioClip mistakeClip;
    public AudioSource mainAudioSource;
    public Controller m_controller;

    protected bool wasClenching;
    protected bool wasOpenFist;
    protected bool isDoingExercise;
    protected int counterExcercies;
    protected float neededOpenHandAngle = 1f;

    protected List<Hand> _hands = new List<Hand>();

    public void Start()
    {
        isDoingExercise = true;
        m_controller = new Controller();
    }
}

public class GestrureLevel1 : GestureMain
{
    [Range(0, 3)]
    public float neededGrabAngle = 2.7f;
    [Range(0, 20)]
    public int allAmountRepetitions = 15;
    [Range(0, 2)]
    public float minTimeClanching = 1f;

    private void Update()
    {
        Frame f = m_controller.Frame();
        _hands = f.Hands;
        if (isDoingExercise)
        {
            try
            {
                //Close hand
                if (wasClenching && _hands[0].GrabAngle < neededOpenHandAngle && _hands[1].GrabAngle < neededOpenHandAngle)
                {
                    counterExcercies++;
                    wasOpenFist = true;
                    wasClenching = false;
                    //mainAudioSource.clip = 
                    Debug.Log("Open hands");
                }
                //Open hand
                else if (!wasClenching && _hands[0].GrabAngle >= neededGrabAngle && _hands[1].GrabAngle >= neededGrabAngle)
                {
                    wasClenching = true;
                    wasOpenFist = false;
                    //Debug.Log("Close hands");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // TODO...
            }
            //Exercise did
            if (counterExcercies >= allAmountRepetitions)
            {   
                isDoingExercise = false;
            }
        }
    }

}