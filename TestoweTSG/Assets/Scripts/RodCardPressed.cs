using UnityEngine;
using UnityEngine.UI;
public class RodCardPressed : MonoBehaviour
{
    public GameObject rod;
    private Button button;
    private bool choosen;
    private Transform context;
    private GameObject selectedText;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonPressed);
        rod.tag = "Rod";
        choosen = false;
        FindGameObjects();
    }
    void FindGameObjects()
    {
        context = GameObject.FindGameObjectWithTag("Context").transform;
        selectedText = gameObject.transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject;
    }
    public void ButtonPressed()
    {
        if (choosen) return;
        ChangeRod();
        selectedText.SetActive(true);
        choosen = true;
    }
    void ChangeRod()
    {
        Transform oldRod = GameObject.FindGameObjectWithTag("Rod").gameObject.transform;
        rod = Instantiate(rod, oldRod.position, oldRod.rotation).gameObject;
        rod.transform.SetParent(context);
        rod.transform.localScale = new Vector3(300, 300, 300);
        rod.name = "RodModel";
        Destroy(oldRod.gameObject);
    }
    public void ChangeChoose()
    {
        choosen = false;
    }
}
