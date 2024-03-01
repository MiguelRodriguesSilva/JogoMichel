using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
        #region variaveis
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float forca;
    public Inputs controller;
    #endregion
    private void Update()
    {
        #region voltar para a tela
        if (transform.position.y >= 13f) 
        {
            transform.position = new Vector2(transform.position.x, -11f);
        }

        if (transform.position.y <= -13f)
        {
            transform.position = new Vector2(transform.position.x, 11f);
        }
        #endregion

        #region pular teclado
        if (Input.GetAxis("Vertical") > 0 && Input.GetButtonDown("Vertical"))
        {
            rig.velocity = new Vector2(rig.velocity.x, forca);
        }
        #endregion

        #region pular controle
        if (controller.inputActions.DualShock4.Pular.WasPerformedThisFrame())
        {
            rig.velocity = new Vector2(rig.velocity.x, forca);
        }
        #endregion
    }
}
