using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    #region variaveis
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private GameObject warning;
    [SerializeField] private float contador;
    [SerializeField] private float forca;
    private GameObject playerobject;
    private bool AvisoAcabou;
    #endregion

    public void Start()
    {
        StartCoroutine(Aviso());
    }
    public void Update()
    {
        #region resetar o obstaculo
        if (transform.position.x <= -28.68f) 
        {
            AvisoAcabou = false;
            transform.position = new Vector2(23.18f, Random.Range(-13.64f, 0.48f));
            rig.velocity = new Vector2(0, rig.velocity.y);
            warning.active = true;
            StartCoroutine(Aviso());
        }
        #endregion

        #region disparar o obstaculo
        if (AvisoAcabou) 
        {
            rig.velocity = new Vector2(forca, rig.velocity.y);
            warning.active = false;
        }
        #endregion
    }

    #region matar o player
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag == "Player")
        {
            playerobject = collider.gameObject;
            playerobject.active = false;
        }
    }
    #endregion

    #region Contador do aviso
    IEnumerator Aviso()
    {
        yield return new WaitForSeconds(contador);
        AvisoAcabou = true;
    }
    #endregion
}
