using System.Collections.Generic;
using UnityEngine;

public class MarksTracker : MonoBehaviour
{
    [SerializeField] private GameObject _wall;

    public List<GameObject> Targets;

    private void Start()
    {
        Targets = new List<GameObject>();
    }

    public void OnTargetFound()
    {
        if (Targets.Count > 1)
        {
            float distance = float.MaxValue;
            int[] positions = FindNearestTargets(ref distance);
            
            GameObject wall = Instantiate(_wall);
            wall.GetComponent<WallRenderer>().Parent1 = Targets[positions[0]];
            wall.GetComponent<WallRenderer>().Parent2 = Targets[positions[1]];
        }
    }

    private int[] FindNearestTargets(ref float distance)
    {
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < Targets.Count - 1; i++)
            for (int j = i + 1; j < Targets.Count; j++)
            {
                float currentDistance = GetDistance(Targets[i].transform.position, Targets[j].transform.position);

                if (distance > currentDistance && currentDistance > 0)
                {
                    distance = currentDistance;
                    index1 = i;
                    index2 = j;
                }
            }

        return new int[] { index1, index2 };
    }

    private Vector3 FindPosition(Vector3 positioin1, Vector3 positioin2)
    {
        float x = (positioin1.x + positioin2.x) / 2;
        float y = (positioin1.y + positioin2.y) / 2;
        float z = (positioin1.z + positioin2.z) / 2;

        return new Vector3(x, y, z);
    }

    private float GetDistance(Vector3 target1, Vector3 target2)
    {
        return Mathf.Sqrt(
            Mathf.Pow(target1.x - target2.x, 2) + 
            Mathf.Pow(target1.y - target2.y, 2) + 
            Mathf.Pow(target1.z - target2.z, 2));
    }

    public void OnTargetLost()
    {
        
    }
}
