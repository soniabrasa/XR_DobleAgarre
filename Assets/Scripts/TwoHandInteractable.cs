using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandInteractable : XRGrabInteractable
{
    public XRSimpleInteractable secondHandInteractable;

    XRBaseInteractor secondHand;

    Quaternion startAttachTransformRotation;

    // Por lo visto hay una variable publica de la clase madre
    // XRBaseInteractor selectingInteractor


    void Start()
    {
        // seconHand interactor OnSelectEntered
        secondHandInteractable.selectEntered.AddListener(OnSecondHandSelectEnter);

        // secondHand interactor OnSelectExited
        secondHandInteractable.selectExited.AddListener(OnSecondHandSelectExit);
    }

    // void Update() { }

    // Fases de actualización
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        // La fase Dinamic actualiza en cada frame (como Update)
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (secondHand != null && selectingInteractor != null)
            {
                selectingInteractor.attachTransform.LookAt(secondHand.attachTransform.position, selectingInteractor.transform.up);

                //selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondHand.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
            }
        }
    }

    // Métodos OnSelectEnter/Exit de controlador secundario
    void OnSecondHandSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name}.TwoHandIteractable.OnSecondHandSelectEnter");
        secondHand = (XRBaseInteractor)args.interactorObject;
    }

    void OnSecondHandSelectExit(SelectExitEventArgs args)
    {
        Debug.Log($"{gameObject.name}.TwoHandIteractable.OnSecondHandSelectExit");
        secondHand = null;

        // Pasar la rotación local original al Attach del interactor principal

        if (selectingInteractor)
        {
            selectingInteractor.attachTransform.localRotation = startAttachTransformRotation;

            Debug.Log($"{gameObject.name}.TwoHandIteractable.OnSecondSelectExit {attachTransform.localRotation.eulerAngles}");
        }
    }

    // Métodos OVERRIDE OnSelectEnter/Exit de controlador principal
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        XRBaseInteractor interactor = (XRBaseInteractor)args.interactorObject;

        startAttachTransformRotation = interactor.attachTransform.localRotation;

        Debug.Log($"{gameObject.name}.TwoHandIteractable.OnSelectEntered {startAttachTransformRotation.eulerAngles}");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        secondHand = null;
        //selectingInteractor.attachTransform.localRotation = startAttachTransformRotation;

        Debug.Log($"{gameObject.name}.TwoHandIteractable.OnSelectExited");
    }
}
