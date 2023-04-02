using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public UnitScript selectedUnit;
    public Animator unitUIAnimator;
    public GameObject missileObj;
    //CharacterController cc;


    // Start is called before the first frame update
    void Start()
    {
       // cc = selectedUnit.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0)) 
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       

         if (Physics.Raycast(ray) == false)
            {
                if (selectedUnit != null)
                {
                    selectedUnit.selected = false;
                    selectedUnit.bodyRend.material.color = selectedUnit.defaultColor;

                    selectedUnit = null;

                    unitUIAnimator.SetTrigger("fadeOut");
                }
                

            }
        } 
    }

    public void FireButtonClicked()
    {
        GameObject missile = Instantiate(missileObj, selectedUnit.transform.position, selectedUnit.transform.rotation);
        Rigidbody rb = missile.GetComponent<Rigidbody>();
        rb.AddForce(selectedUnit.transform.forward * 1000 * Time.deltaTime);

        Destroy(missile, 2f);
    }
}
