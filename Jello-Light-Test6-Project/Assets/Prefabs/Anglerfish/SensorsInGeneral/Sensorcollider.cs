using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensorcollider : MonoBehaviour

{
    public Anglerfisch AnglerfischScript;
    private bool IsVisible;
    public bool IsSensor1;
    public Collider2D Hierdarfstdunichtlang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsVisible = AnglerfischScript.VisibilityOnOne; //if true, sensor 1 ins visible, if false sensor 2 is visible
        
        if (IsSensor1 == true)
        {
            if (IsVisible == true)
            {
                Hierdarfstdunichtlang.enabled = false;
            }
            else Hierdarfstdunichtlang.enabled = true;
        }
        else
        {
            if (IsVisible == true)
            {
                Hierdarfstdunichtlang.enabled = true;
            }
            else Hierdarfstdunichtlang.enabled = false;
        }
    }
}
