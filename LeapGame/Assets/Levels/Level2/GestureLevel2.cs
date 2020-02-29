using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System;

public class GestureLevel2 : GestureMain
{
    [Range(0, 3)]
    public float neededPalmValue = 0;
    [Range(0, 20)]
    public int allAmountRepetitions = 15;
    [Range(0, 2)]
    public float minTimeClanching = 1f;

    // Update is called once per frame
    void Update()
    {
        Frame f = m_controller.Frame();
        _hands = f.Hands;

        
        if (isDoingExercise)
        {
            try
            {
                //Close hand
                if (wasClenching && _hands[0].Basis.xBasis.y < neededPalmValue && _hands[1].Basis.xBasis.y < neededPalmValue)
                {
                    counterExcercies++;
                    wasOpenFist = true;
                    wasClenching = false;
                    //mainAudioSource.clip = 
                    Debug.Log("Hands up");
                }
                //Open hand
                else if (!wasClenching && _hands[0].Basis.xBasis.y >= neededPalmValue && _hands[1].Basis.xBasis.y >= neededPalmValue)
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
