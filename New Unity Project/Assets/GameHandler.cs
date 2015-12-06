using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {


    public GameObject LeftZone;
    public GameObject RightZone;
    public GameObject centerFalse;
    private bool isBlocked = false;
    private bool canNext = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
       if(Input.GetMouseButtonDown(0) && isBlocked && canNext)
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward);

            if(hit.collider == centerFalse.GetComponent<Collider>())
            {
                ClickOnFalse();
            }
        }

	}

    public void ClickHandler(string side)
    {
        if(side == "left" || side == "right")
        {
            Debug.Log("Side " + side + " clicked.");
            LeftZone.GetComponent<RaycastMask>().isClickable = false;
            RightZone.GetComponent<RaycastMask>().isClickable = false;
            centerFalse.SetActive(true);
            isBlocked = true;
            StartCoroutine(WaitUntilNext());
        }
    }

    IEnumerator WaitUntilNext()
    {
        canNext = false;
        yield return new WaitForSeconds(1);
        canNext = true;
    }

    public void ClickOnFalse()
    {
        Debug.Log("Next question");
        LeftZone.GetComponent<RaycastMask>().isClickable = true;
        RightZone.GetComponent<RaycastMask>().isClickable = true;
        centerFalse.SetActive(false);
    }
}
