<<<<<<< HEAD:Assets/1_Scripts/Manager/CardManager.cs
﻿using System.Collections;
=======
﻿using System;
using UnityEngine;
using System.Collections;
>>>>>>> card's_desc:Assets/Scripts/CardManager.cs
using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD:Assets/1_Scripts/Manager/CardManager.cs
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{    
	//public GameObject card;
    Transform parent;

	private const float INTERVAL = 1.4f;
	private const float START_POSITION_X = -2;
    private const float START_POSITION_Y = -4f;
    private const string CLOSE_CARDS = "CloseCards";

	private Sprite[] resources;
    private int[] indices;

    private static string[] MemberNames = { "이장원","김대열","윤지연","최하나" };
    private static string[][] MemberDescs = {
        new string[] { "고양이❤️", "STPB" ,"보디빌딩"},
        new string[] { "고양이❤️", "STPB","요리" },
        new string[] { "수달❤️", "ISFP" ,"그림"},
        new string[] { "강아지❤️", "ISFP","독서" }
        //❤️
=======
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    public GameObject card;

    private const float Interval = 1.4f;
    private const float StartPositionX = -2;
    private const float StartPositionY = -4f;
    private const string MethodCloseCards = "CloseCards";
    private const string MethodDestroyCards = "DestroyCards";

    private Sprite[] _resources;
    private int[] _indices;

    private static readonly string[] MemberNames = { "이장원", "김대열", "윤지연", "최하나" };

    private static readonly string[][] MemberDescs =
    {
        new string[] { "ENFP️", "게임", "지지말자!" },
        new string[] { "ENTP", "보디빌딩", "힘내자!" },
        new string[] { "INFJ", "게임", "취업하자!" },
        new string[] { "INFJ️", "낮잠자기", "운전하기" },
>>>>>>> card's_desc:Assets/Scripts/CardManager.cs
    };

    private string _selectedMember;

    private Card _memberCard;
    private Card _firstCard;
    private Card _secondCard;

    private bool _isAnimationStarted;

<<<<<<< HEAD:Assets/1_Scripts/Manager/CardManager.cs
    public void SetParent()
	{
        parent = GameObject.Find("Cards").transform;
	}

	public void InitCard()
	{
=======
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        InitCard();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InitCard()
    {
>>>>>>> card's_desc:Assets/Scripts/CardManager.cs
        //load resources
        _resources = Resources.LoadAll<Sprite>(Card.CARD_PATH);

        //TODO : 설명카드 배열작업 
<<<<<<< HEAD:Assets/1_Scripts/Manager/CardManager.cs
        for(int i = 0; i < MemberNames.Length; i++)
        {
            Vector3 position = new Vector3(START_POSITION_X + i *INTERVAL, 2f,0f);
            var descCard = Instantiate(Resources.Load<GameObject>("Prefabs/card"), position, Quaternion.identity);
            //descCard.transform.SetParent(parent);
            string[] desc = MemberDescs[i];
            Card descCardBehavior = descCard.GetComponent<Card>();
            descCardBehavior.SetDesc();
=======
        for (var i = 0; i < MemberNames.Length; i++)
        {
            var position = new Vector3(StartPositionX + i * Interval, 2f, 0f);
            var descCard = Instantiate(card, position, Quaternion.identity);
            var descCardBehavior = descCard.GetComponent<Card>();
>>>>>>> card's_desc:Assets/Scripts/CardManager.cs
            //desc
            descCardBehavior.SetCardType(CardType.Desc);
            descCardBehavior.SetMember(MemberNames[i]);
            descCardBehavior.SetDescriptions(MemberDescs[i]);
        }

        //shuffle indices
        var listOfIndex = new List<int>();
        for (var i = 0; i < _resources.Length; i++)
        {
            //카드는 2장이므로 2번 더함
            listOfIndex.Add(i);
            listOfIndex.Add(i);
        }

        _indices = listOfIndex.OrderBy(_ => Random.Range(-1f, 1f)).ToArray();

        for (var i = 0; i < 16; i++)
        {
            var col = i % 4;
            var row = i / 4;

<<<<<<< HEAD:Assets/1_Scripts/Manager/CardManager.cs
        for (var i = 0; i < 16; i++) {
			var col = i % 4;
			var row = i / 4;
			
            var position = new Vector3(START_POSITION_X + col * INTERVAL, START_POSITION_Y + row * INTERVAL , 0f);
            var cardGameObj = Instantiate(Resources.Load<GameObject>("Prefabs/card"), position, Quaternion.identity);
            //cardGameObj.transform.SetParent(parent);
            Debug.Log($"resource is {resources[indices[i]]}");
            cardGameObj.transform.Find(Card.FRONT).GetComponent<SpriteRenderer>().sprite = resources[indices[i]];
=======
            var position = new Vector3(StartPositionX + col * Interval, StartPositionY + row * Interval, 0f);
            var cardGameObj = Instantiate(card, position, Quaternion.identity);
            Debug.Log($"resource is {_resources[_indices[i]]}");
>>>>>>> card's_desc:Assets/Scripts/CardManager.cs
            
            //resource 
            cardGameObj.transform.Find(Card.FRONT).GetComponent<SpriteRenderer>().sprite = _resources[_indices[i]];
            var cardData = cardGameObj.GetComponent<Card>();

            //멤버명 할당과 이미지 타입 할당.
            cardData.member = MemberNames[_indices[i] / 2];
            cardData.imgType = _indices[i] % 2 == 0 ? $"{cardData.member}A" : $"{cardData.member}B";
        }
    }

    public void SelectMemberCard(Card memberCard)
    {
        if (_memberCard == null)
        {
            _memberCard = memberCard;
        }
        else if (_memberCard == memberCard)
        {
            _memberCard.SetBorderInactive();
            _memberCard = null;
        }
        else
        {
            _memberCard.SetBorderInactive();
            _memberCard = memberCard;
        }
    }

    public void UnSelectMemberCard()
    {
        _memberCard.SetBorderInactive();
        _memberCard = null;
    }

    public bool IsSelectedMemberSameAs(Card memberCard)
    {
        return _memberCard == memberCard;
    }

    public void SelectCard(Card memberCard)
    {
        if (_firstCard == null)
        {
            _firstCard = memberCard;
            memberCard.AnimateOpen();
        }
        else if (_secondCard == null)
        {
            _isAnimationStarted = true;
            _secondCard = memberCard;
            _secondCard.AnimateOpen();

            // Invoke(MethodCloseCards, 1f);

            //만약 같으면 카드 파괴
            var result = Managers.Match.CheckMatch(_memberCard, _firstCard, _secondCard);

            switch (result)
            {
                case 0: // intentionally skip
                case 1:
                    Debug.Log("matchSuccess");
                    _firstCard.Fadeout();
                    _secondCard.Fadeout();
                    Invoke(MethodDestroyCards, 0.5f);
                    Debug.Log("그림 맞음");
                    break;
                case 2:
                    Debug.Log("멤버와 다름");
                    Invoke(MethodCloseCards, 0.5f);
                    break;
                case 3:
                    Debug.Log("싹 다 다름");
                    Invoke(MethodCloseCards, 0.5f);
                    break;

                default: throw new InvalidDataException("결과값은 반드시 0,1,2,3 중 하나여야만 한다.");
            }
        } //else do nothing
    }

    private void CloseCards()
    {
        _firstCard.AnimateClose();
        _secondCard.AnimateClose();
        _firstCard = null;
        _secondCard = null;
        _memberCard.SetBorderInactive();
        _memberCard = null;
        _isAnimationStarted = false;
    }

    private void DestroyCards()
    {
        Destroy(_firstCard.gameObject);
        Destroy(_secondCard.gameObject);
        _firstCard = null;
        _secondCard = null;
        _memberCard.SetBorderInactive();
        _memberCard = null;
        _isAnimationStarted = false;
    }

    public bool IsAnimationStarted()
    {
        return _isAnimationStarted;
    }

    public bool IsMemberCardSelected()
    {
        return _memberCard != null;
    }
}