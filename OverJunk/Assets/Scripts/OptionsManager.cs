using UnityEngine;
using UnityEngine.InputSystem;

public class OptionsManager : MonoBehaviour
{
    public OptionsMenu optionsMenu;
    private InputAction escapeAction;

    //private void Awake()
    //{
        // Ensure there is only one instance of OptionsManager
        //OptionsManager[] managers = FindObjectsOfType<OptionsManager>();
        //if (managers.Length > 1)
        //{
            //Destroy(gameObject);
        //}
        //else
        //{
            //DontDestroyOnLoad(gameObject);
        //}
    //}

    private void OnEnable()
    {
        // Enable the escape key action
        escapeAction = new InputAction(binding: "<Keyboard>/escape");
        escapeAction.Enable();
        escapeAction.performed += ctx => ToggleOptionsMenu();
    }

    private void OnDisable()
    {
        // Disable the escape key action
        escapeAction.Disable();
    }

    private void ToggleOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
    }

}