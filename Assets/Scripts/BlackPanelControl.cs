using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPanelControl : MonoBehaviour
{
    private GameObject blackPanel;
    private Animator animator;

    private void Start()
    {
        blackPanel = GameObject.Find("Black");
        animator = blackPanel.GetComponent<Animator>();

        RaiseBlackPanel();
    }

    public void RaiseBlackPanel()
    {
        animator.SetTrigger("Black Up");
    }

    public void LowerBlackPanel()
    {
        animator.SetTrigger("Black Down");
    }
}
