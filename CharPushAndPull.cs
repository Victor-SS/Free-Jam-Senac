using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharPushAndPull : MonoBehaviour
{
    public float distancia = 1f;
    public LayerMask Empurravel;
    GameObject Caixa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distancia,Empurravel);
        if (hit.collider != null && hit.collider.gameObject.tag == "Empurravel" && Input.GetKeyDown(KeyCode.E))
        {
            Caixa = hit.collider.gameObject;
            Caixa.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            Caixa.GetComponent<FixedJoint2D>().enabled = true;
            Caixa.GetComponent<Empurrando>().beingPushed = true;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Caixa.GetComponent<FixedJoint2D>().enabled = false;
            Caixa.GetComponent<Empurrando>().beingPushed = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distancia);
    }
}
