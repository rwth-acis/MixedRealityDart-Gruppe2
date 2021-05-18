using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class PrecisionMeasurement : MonoBehaviour, IMixedRealityPointerHandler

{
    //the transform of the center of the target
    [SerializeField] private Transform targetCenterTransform;

    [SerializeField]private GameObject dartPrefab;
    private GameObject currentDart;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // go over every input source
        foreach (var source in CoreServices.InputSystem.DetectedInputSources)
        {
            // Ignore anything that is not a hand because we want articulated hands
            if (source.SourceType == InputSourceType.Hand)
            {
                // find the pointers of the hand
                foreach (IMixedRealityPointer p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }
                    // if the pointer actually gives a result: do something with it
                    if (p.Result != null)
                    {
                        if(currentDart == null){
                            Vector3 pointerEndPosition = p.Result.Details.Point;
                            float distanceToTargetCenter = (pointerEndPosition - targetCenterTransform.position).magnitude;
                            Debug.Log(distanceToTargetCenter);
                            currentDart = Instantiate(dartPrefab, pointerEndPosition, Quaternion.identity);
                            currentDart.transform.parent = this.transform;
                        }
                    }

                }
            }
        }
    }
}
