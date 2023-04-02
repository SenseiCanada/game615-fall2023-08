using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class UnitScript : MonoBehaviour
{

    public Renderer bodyRend;
    public Color hoverColor;
    public Color defaultColor;
    public Color selectedColor;

    //public NavMeshAgent nma;
    //public Animator unitUIAnimator;

    public bool selected = false;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRend.material.color;

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();
        gm.selectedUnit = null;

        //nma= gmObj.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            //Debug.Log("On Target");
            bodyRend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            
            bodyRend.material.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if (gm.selectedUnit != null)
        {
            gm.selectedUnit.selected = false;
            gm.selectedUnit.bodyRend.material.color = gm.selectedUnit.defaultColor;
        }

        selected = true;
        bodyRend.material.color = selectedColor;

        if (gm.selectedUnit == null) 
        {
           gm.unitUIAnimator.SetTrigger("fadeIn");
        }

        gm.selectedUnit = this;
    }
}
