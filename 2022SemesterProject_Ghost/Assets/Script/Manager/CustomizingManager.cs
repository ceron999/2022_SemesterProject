using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizingManager : MonoBehaviour
{   
    [SerializeField]
    GameObject customizingPrefab;

    GameObject prefab_obj;
    List<GameObject> eyeList = new List<GameObject>();
    List<GameObject> mouthList = new List<GameObject>();
    List<GameObject> itemList = new List<GameObject>();

    List<GameObject> soulBackGroundList = new List<GameObject>();
    List<GameObject> soulFaceEyeList = new List<GameObject>();
    List<GameObject> soulFaceMouthList = new List<GameObject>();
    List<GameObject> soulFaceItemList = new List<GameObject>();
    public static int eyeIndex=0;
    public static int mouthIndex=0;
    public static int itemIndex=0;  
    public SaveDataClass saveData; 
    public JsonManager jsonManager;

    void Awake(){
        // 프리팹 인스턴스화하기
        prefab_obj = Resources.Load("Prefabs/CustomizingPrefab") as GameObject;
        customizingPrefab = MonoBehaviour.Instantiate(prefab_obj, GameObject.Find("Canvas").transform);
        customizingPrefab.name = "customizingPrefab";
        Vector2 pos = new Vector2(720, 2000);
        customizingPrefab.transform.position = pos;
        
        string tempstr="";
        string tempstr2="";
        GameObject tempObj;
        GameObject tempObj2;
        for(int i=0; i<2; i++){ //resources/ CharacterImage/ Character1 Or Character2
            tempstr2 = "";
            tempstr2 = "SoulBackGround"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulBackGroundList.Add(tempObj2);
            soulBackGroundList[i].SetActive(false);
        }
        for(int i=0; i<6; i++){ 
            tempstr = ""; // Eye0~5
            tempstr = "Eye"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            eyeList.Add(tempObj);
            eyeList[i].SetActive(false);

            tempstr = ""; // Mouth0~5
            tempstr = "Mouth"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            mouthList.Add(tempObj);
            mouthList[i].SetActive(false);

            tempstr2 = ""; // SoulFaceEye0~5 (Prefab)
            tempstr2 = "SoulFaceEye"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceEyeList.Add(tempObj2);
            soulFaceEyeList[i].SetActive(false);           

            tempstr2 = ""; // SoulFaceMouth0~5 (Prefab)
            tempstr2 = "SoulFaceMouth"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceMouthList.Add(tempObj2);
            soulFaceMouthList[i].SetActive(false);
        }
        for(int i=0; i<7; i++){
            tempstr = ""; // item0~6
            tempstr = "Item"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            itemList.Add(tempObj);
            itemList[i].SetActive(false);

            tempstr2 = ""; // SoulFaceitem0~6 (Prefab)
            tempstr2 = "SoulFaceItem"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceItemList.Add(tempObj2);
            soulFaceItemList[i].SetActive(false);
        }    
    }

    void Start(){ // 첫번째 눈, 입, 아이템 보이게 설정
        eyeList[0].SetActive(true);
        mouthList[0].SetActive(true);
        itemList[0].SetActive(true);
        
        soulFaceEyeList[0].SetActive(true);
        soulFaceMouthList[0].SetActive(true);
        soulFaceItemList[0].SetActive(true);

        //곡선이 많다 = Character1 / 직선이 많다 = Character2
        jsonManager = new JsonManager();
        saveData = jsonManager.LoadSaveData();
        if(saveData.soulShape == "곡선이 많다."){
            soulBackGroundList[0].SetActive(true); // Character1
        }
        else{
            soulBackGroundList[1].SetActive(true); // Character2
        }
    }

    public void ClickEyeLeftBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotLeftBtn);
        eyeList[eyeIndex].SetActive(false);
        soulFaceEyeList[eyeIndex].SetActive(false); // 현재 이미지 감추기
        if(eyeIndex==0){
            eyeIndex=5;
        }
        else{
            eyeIndex--;
        }
        eyeList[eyeIndex].SetActive(true);
        soulFaceEyeList[eyeIndex].SetActive(true); // 이전 이미지 보이기
    }

    public void ClickEyeRightBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotRightBtn);
        eyeList[eyeIndex].SetActive(false); 
        soulFaceEyeList[eyeIndex].SetActive(false);// 현재 이미지 감추기
        if(eyeIndex==5){
            eyeIndex=0;
        }
        else{
            eyeIndex++;
        }
        eyeList[eyeIndex].SetActive(true);
        soulFaceEyeList[eyeIndex].SetActive(true); // 다음 이미지 보이기
    }

    public void ClickMouthLeftBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotLeftBtn);
        mouthList[mouthIndex].SetActive(false); 
        soulFaceMouthList[mouthIndex].SetActive(false);
        if(mouthIndex==0){
            mouthIndex=5;
        }
        else{
            mouthIndex--;
        }
        mouthList[mouthIndex].SetActive(true);
        soulFaceMouthList[mouthIndex].SetActive(true);
    }

    public void ClickMouthRightBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotRightBtn);
        mouthList[mouthIndex].SetActive(false);
        soulFaceMouthList[mouthIndex].SetActive(false);
        if(mouthIndex==5){
            mouthIndex=0;
        }
        else{
            mouthIndex++;
        }
        mouthList[mouthIndex].SetActive(true);
        soulFaceMouthList[mouthIndex].SetActive(true);
    }

    public void ClickItemLeftBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotLeftBtn);
        itemList[itemIndex].SetActive(false); 
        soulFaceItemList[itemIndex].SetActive(false); 
        if(itemIndex==0){
            itemIndex=5;
        }
        else{
            itemIndex--;
        }
        itemList[itemIndex].SetActive(true);
        soulFaceItemList[itemIndex].SetActive(true); 
    }

    public void ClickItemRightBtn(){
        SoundManager.instance.PlaySoundEffect(SoundEffect.SlotRightBtn);
        itemList[itemIndex].SetActive(false);
        soulFaceItemList[itemIndex].SetActive(false); 
        if(itemIndex==5){
            itemIndex=0;
        }
        else{
            itemIndex++;
        }
        itemList[itemIndex].SetActive(true);
        soulFaceItemList[itemIndex].SetActive(true); 
    }
}
