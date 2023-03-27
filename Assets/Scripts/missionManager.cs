using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionManager : MonoBehaviour
{
    public static bool missionInProgress { get; set; }

    public static bool classTime { get; set; }
    public static int ClassNumber { get; set; }
   // ClassNumber = 1;
    public string currentMission { get; set; }
    private void Awake()
    {
        ClassNumber = 0;
        classTime = true;

    }

}
