﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    [SerializeField] SessionData sessionData;
    [SerializeField] PlayerData playerData;
    [SerializeField] SpriteSquish peopleContainer;
    [SerializeField] Text peopleCount;
    [SerializeField] Text timer;
    [SerializeField] Text deathCount;
    [SerializeField] RectTransform waterFill;

    public void OnPeopleChange() {
        peopleCount.text = playerData.people.ToString();
        peopleContainer.gameObject.SetActive(playerData.people > 0);
        if (playerData.people > 0) {
            peopleContainer.SquishThin();
        }
    }

    void Start() {
        playerData.peopleChangeEvent.AddListener(OnPeopleChange);
    }

    void OnDestroy() {
        playerData.peopleChangeEvent.RemoveListener(OnPeopleChange);
    }

    void LateUpdate() {
        waterFill.sizeDelta = new Vector2(64f * playerData.water / PlayerData.WATER_MAX, 8);
        Vector2 camPosition = Camera.main.transform.position;
        peopleContainer.GetComponent<RectTransform>().anchoredPosition = playerData.position - camPosition + new Vector2(20, 40);

        timer.text = Formatter.TimeToString(sessionData.time);
        deathCount.text = sessionData.peopleDied.ToString();
    }
}
