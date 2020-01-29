using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHolder : MonoBehaviour
{
    [SerializeField] private MarksTracker _tracker;

    public void OnTargetFound()
    {
        _tracker.Targets.Add(gameObject);
        _tracker.OnTargetFound();
    }

    public void OnTargetLost()
    {
        _tracker.Targets.Remove(gameObject);
        _tracker.OnTargetLost();
    }
}