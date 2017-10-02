using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] GameObject[] steps;

    int currentStep;
    bool buttonDown;

    void Update()
    {
        if (GetAxisDown("Step"))
        {
            Next();
        }
    }

    void Next()
    {
        steps[currentStep].SetActive(false);
        currentStep++;
        currentStep %= steps.Length;
        steps[currentStep].SetActive(true);
    }

    bool GetAxisDown(string axis)
    {
        bool currentlyDown = Input.GetAxis(axis) > 0.4f;
        bool justDown = !buttonDown && currentlyDown;
        buttonDown = currentlyDown;
        return justDown;
    }
}
