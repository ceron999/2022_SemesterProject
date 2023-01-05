using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomizingManager : MonoBehaviour
{   
    [SerializeField]
    GameObject customizingPrefab;
    public List<GameObject> eyeList = new List<GameObject>();
    public List<GameObject> mouthList = new List<GameObject>();
    public List<GameObject> itemList = new List<GameObject>();

    public List<GameObject> soulFaceEyeList = new List<GameObject>();
    public List<GameObject> soulFaceMouthList = new List<GameObject>();
    public List<GameObject> soulFaceItemList = new List<GameObject>();
    int eyeIndex=0;
    int mouthIndex=0;
    int itemIndex=0;    

    void Awake(){
        string tempstr="";
        string tempstr2="";
        GameObject tempObj;
        GameObject tempObj2;
        for(int i=0; i<10; i++){ // 눈 10개
            tempstr = "";
            tempstr = "Eye"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            eyeList.Add(tempObj);
            eyeList[i].SetActive(false);

            tempstr2 = "";
            tempstr2 = "SoulFaceEye"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceEyeList.Add(tempObj2);
            soulFaceEyeList[i].SetActive(false);

            tempstr = "";
            tempstr = "Mouth"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            mouthList.Add(tempObj);
            mouthList[i].SetActive(false);

            tempstr2 = "";
            tempstr2 = "SoulFaceMouth"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceMouthList.Add(tempObj2);
            soulFaceMouthList[i].SetActive(false);
        }
        for(int i=0; i<6; i++){ // item 6개
            tempstr = "";
            tempstr = "Item"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            itemList.Add(tempObj);
            itemList[i].SetActive(false);

            tempstr2 = "";
            tempstr2 = "SoulFaceItem"+i.ToString();
            tempObj2 = GameObject.Find(tempstr2);
            soulFaceItemList.Add(tempObj2);
            soulFaceItemList[i].SetActive(false);
        }
        
        customizingPrefab = GameObject.Find("CustomizingPrefab");
    }

    void Start(){ // 첫번째 눈, 입, 아이템 보이게 설정
        eyeList[0].SetActive(true);
        mouthList[0].SetActive(true);
        itemList[0].SetActive(true);

        soulFaceEyeList[0].SetActive(true);
        soulFaceMouthList[0].SetActive(true);
        soulFaceItemList[0].SetActive(true);
    }

    public void ClickEyeLeftBtn(){
        eyeList[eyeIndex].SetActive(false);
        soulFaceEyeList[eyeIndex].SetActive(false); // 현재 이미지 감추기
        if(eyeIndex==0){
            eyeIndex=9;
        }
        else{
            eyeIndex--;
        }
        eyeList[eyeIndex].SetActive(true);
        soulFaceEyeList[eyeIndex].SetActive(true); // 이전 이미지 보이기
    }

    public void ClickEyeRightBtn(){ 
        eyeList[eyeIndex].SetActive(false); 
        soulFaceEyeList[eyeIndex].SetActive(false);;// 현재 이미지 감추기
        if(eyeIndex==9){
            eyeIndex=0;
        }
        else{
            eyeIndex++;
        }
        eyeList[eyeIndex].SetActive(true);
        soulFaceEyeList[eyeIndex].SetActive(true); // 다음 이미지 보이기
    }

    public void ClickMouthLeftBtn(){
        mouthList[mouthIndex].SetActive(false); 
        soulFaceMouthList[mouthIndex].SetActive(false);
        if(mouthIndex==0){
            mouthIndex=9;
        }
        else{
            mouthIndex--;
        }
        mouthList[mouthIndex].SetActive(true);
        soulFaceMouthList[mouthIndex].SetActive(true);
    }

    public void ClickMouthRightBtn(){
        mouthList[mouthIndex].SetActive(false);
        soulFaceMouthList[mouthIndex].SetActive(false);
        if(mouthIndex==9){
            mouthIndex=0;
        }
        else{
            mouthIndex++;
        }
        mouthList[mouthIndex].SetActive(true);
        soulFaceMouthList[mouthIndex].SetActive(true);
    }

    public void ClickItemLeftBtn(){
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
