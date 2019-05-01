using UnityEngine;
using UnityEngine.UI;

public class ManyRodCardsInit : MonoBehaviour
{
    public int spinningRods=14;
    public int flyRods=10;
    public int castingRods=20;

    public Sprite[] rodsIcons = new Sprite[10];
    public GameObject[] backgroundColorsPrefabs = new GameObject[3];
    public GameObject[] models = new GameObject[2];
    public string[] names = { "lol", "vk" };

    GameObject spinningRodsObject;
    GameObject flyRodsObject;
    GameObject castingRodsObject;

    void Start()
    {
        spinningRodsObject = GameObject.FindGameObjectWithTag("Spinning");
        flyRodsObject = GameObject.FindGameObjectWithTag("Fly");
        castingRodsObject = GameObject.FindGameObjectWithTag("Casting");
        SpawnSpinningRods();
        SpawnFlyRods();
    }
    
    void SpawnSpinningRods()
    {
       
        RectTransform rt = spinningRodsObject.GetComponent<RectTransform>();

        for (int i=0;i<spinningRods;i++)
        {
            int icon = Random.Range(0, rodsIcons.Length-1);
            int background = Random.Range(0, backgroundColorsPrefabs.Length-1);
            int model = Random.Range(0, models.Length-1);
            int name = Random.Range(0, names.Length-1);

            backgroundColorsPrefabs[background].transform.GetChild(1).GetComponentInChildren<Text>().text = names[name];
            backgroundColorsPrefabs[background].transform.GetChild(2).transform.GetComponentInChildren<Image>().sprite = rodsIcons[icon];
            Instantiate(backgroundColorsPrefabs[background], spinningRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0)
            {
                rt.sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
                transform.parent.GetComponent<RectTransform>().sizeDelta+= new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
            }
            
        }
    }

    void SpawnFlyRods()
    {

        RectTransform rt = flyRodsObject.GetComponent<RectTransform>();

        for (int i = 0; i < spinningRods; i++)
        {
            int icon = Random.Range(0, rodsIcons.Length - 1);
            int background = Random.Range(0, backgroundColorsPrefabs.Length - 1);
            int model = Random.Range(0, models.Length - 1);
            int name = Random.Range(0, names.Length - 1);

            backgroundColorsPrefabs[background].transform.GetChild(1).GetComponentInChildren<Text>().text = names[name];
            backgroundColorsPrefabs[background].transform.GetChild(2).transform.GetComponentInChildren<Image>().sprite = rodsIcons[icon];
            Instantiate(backgroundColorsPrefabs[background], flyRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0)
            {
                rt.sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
                transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
            }
        }
    }
    void Update()
    {
        
    }
}
