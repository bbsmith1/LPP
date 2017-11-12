using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// adjust values
/// 11/11/17: git test after making bbsmith1 new user id
/// 11/12/17: git test after publishing to LPP on GitHub
/// </summary>
public class AdjustScript : MonoBehaviour {

    public int Value = 1;
    private List<int> topList;
    private void Start()
    {
        //topList = new List<int>();
        //int t = 100;
        //for (int i = 0; i < 4; i++)
        //{
        //    topList.Add(t);
        //    t += 80;
        //}
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200,60), "Health up"))
        {
            GameControl.theStaticControl.Health += Value;
        }
        if (GUI.Button(new Rect(10, 70, 200,60), "Health down"))
        {
            GameControl.theStaticControl.Health -= Value;
        }
        if (GUI.Button(new Rect(10, 130, 200,60), "experience up"))
        {
            GameControl.theStaticControl.Experience += Value;
        }
        if (GUI.Button(new Rect(10, 190, 200,60), "experience down"))
        {
            GameControl.theStaticControl.Experience -= Value;
        }
        //       if (GUI.Button(new Rect(10, 260, 200,60), "Save"))
        //       {
        //           GameControl.control.Save();
        //       }
        //       if (GUI.Button(new Rect(10, 300, 200,60), "Load"))
        //       {
        //           GameControl.control.Load();

    }
}

