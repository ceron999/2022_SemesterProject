using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizingManager : MonoBehaviour
{
    public List<GameObject> eyeList = new List<GameObject>();
    public List<GameObject> mouthList = new List<GameObject>();
    public List<GameObject> itemList = new List<GameObject>();
    int eyeIndex=0;
    int mouthIndex=0;
    int itemIndex=0;

    void Awake(){
        GameObject tempObj;
        string tempstr;
        for(int i=0; i<10; i++){ // 눈 10개
            tempstr = "";
            tempstr = "Eye"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            eyeList.Add(tempObj);
            eyeList[i].SetActive(false);
        }
        for(int i=0; i<10; i++){ // 입 10개
            tempstr = "";
            tempstr = "Mouth"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            mouthList.Add(tempObj);
            mouthList[i].SetActive(false);
        }
        for(int i=0; i<6; i++){ // item 6개
            tempstr = "";
            tempstr = "Item"+i.ToString();
            tempObj = GameObject.Find(tempstr);
            itemList.Add(tempObj);
            itemList[i].SetActive(false);
        }
    }

    void Start(){ // 첫번째 눈, 입, 아이템 보이게 설정
        eyeList[0].SetActive(true);
        mouthList[0].SetActive(true);
        itemList[0].SetActive(true);
    }

    public void ClickEyeLeftBtn(){
        eyeList[eyeIndex].SetActive(false); // 현재 이미지 감추기
        if(eyeIndex==0){
            eyeIndex=9;
        }
        else{
            eyeIndex--;
        }
        eyeList[eyeIndex].SetActive(true); // 이전 이미지 보이기
    }

    public void ClickEyeRightBtn(){ 
        eyeList[eyeIndex].SetActive(false); // 현재 이미지 감추기
        if(eyeIndex==9){
            eyeIndex=0;
        }
        else{
            eyeIndex++;
        }
        eyeList[eyeIndex].SetActive(true); // 다음 이미지 보이기
    }

    public void ClickMouthLeftBtn(){
        mouthList[mouthIndex].SetActive(false); 
        if(mouthIndex==0){
            mouthIndex=9;
        }
        else{
            mouthIndex--;
        }
        mouthList[mouthIndex].SetActive(true);
    }

    public void ClickMouthRightBtn(){
        mouthList[mouthIndex].SetActive(false);
        if(mouthIndex==9){
            mouthIndex=0;
        }
        else{
            mouthIndex++;
        }
        mouthList[mouthIndex].SetActive(true);
    }

    public void ClickItemLeftBtn(){
        itemList[itemIndex].SetActive(false); 
        if(itemIndex==0){
            itemIndex=5;
        }
        else{
            itemIndex--;
        }
        itemList[itemIndex].SetActive(true);
    }

    public void ClickItemRightBtn(){
        itemList[itemIndex].SetActive(false);
        if(itemIndex==5){
            itemIndex=0;
        }
        else{
            itemIndex++;
        }
        itemList[itemIndex].SetActive(true);
    }
}
