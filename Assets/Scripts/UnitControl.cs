using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    private Vector3 targetPosition;
    private SpriteRenderer sprite;
    private Collider phys;

    public float UnitSpeed;
    public bool isSelect;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurs = controller.GetComponent<ResControl>();
        resurs.NewUnit(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelect)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                targetPosition.y = 1;
            }

            if (targetPosition.x < transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            animator.SetBool("Walk", true);
        }

        if (!Mathf.Approximately(transform.position.magnitude, targetPosition.magnitude))
        {
            GetComponent<Rigidbody>().position = Vector3.Lerp(transform.position, targetPosition, 1 / (UnitSpeed * (Vector3.Distance(transform.position, targetPosition))));
        }
        else
        {
            animator.SetBool("Walk", false);
        }

    }
}
