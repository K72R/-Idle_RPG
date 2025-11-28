# 🪄 Idle RPG Project (Unity 2022.3 LTS)

방치형 RPG(Idle RPG)를 Unity(C#)로 구현한 프로젝트입니다.  
플레이어는 자동으로 몬스터를 탐색하고 공격하며, 스테이지 클리어 시 보상을 획득합니다.  
로비(Lobby)와 방치전투(Idle) 씬을 분리하여 관리하며,  
아이템 / 장비 / 버프 / 상점 / 강화 / 융합 등 다양한 시스템을 포함합니다.

---

## 📌 개발 환경

- **Unity 2022.3.62f2 (LTS)**
- **C#**
- **URP(Optional)**
- TextMeshPro 사용  
- UI 시스템: **uGUI(Canvas)**  
- 데이터 관리: **ScriptableObject 기반 구조**

---

# 📁 프로젝트 구조

Assets/
├── Scripts/
│ ├── ExtraUI/ (HUD, Shop, Upgrade, Scene UI)
│ ├── Inventory/ (인벤토리, 장비 시스템)
│ ├── Map/ (맵 시스템 / 스테이지 스폰)
│ ├── Monster/ (몬스터 AI, 스테이터스)
│ ├── Player/ (플레이어 스탯, AI, 버프)
│ ├── ScriptableObject/ (아이템/몬스터/스테이지 데이터)
│ └── System/ (공통 매니저: Currency, StageTransfer 등)
├── Prefabs/
├── Scenes/
│ ├── LobbyScene.unity
│ ├── IdleScene.unity
│ └── GameSystems.unity (공통 매니저 전용)
└── UI/



---

# 🌍 씬 구조

## 🎮 LobbyScene
- 기본 스테이지 선택 화면
- 인벤토리 / 상점 / 강화 / 융합 UI 포함
- 플레이어는 존재하지 않음
- 스테이지 선택 후 IdleScene으로 이동

구성 요소:
Canvas
├── Panel_Lobby
├── Panel_Inventory
├── Panel_Shop
├── Panel_Upgrade
└── UIManager
StageSelectUI
SceneController
EventSystem



---

## ⚔ IdleScene
- 플레이어 자동 전투(AI)
- 몬스터 스폰 및 스테이지 진행
- 인벤토리 / 상점 / 강화 / 융합 UI 포함

구성 요소:
Player
├── PlayerStats
├── PlayerAI
├── PlayerBuffSystem
├── InventoryManager
├── EquipmentManager
└── HP_Canvas (World Space)

MonsterSpawner
StageManager

Canvas
├── Panel_Idle
├── Panel_Inventory
├── Panel_Shop
├── Panel_Upgrade
└── UIManager

EventSystem



---

# ⚙ 공통 시스템(DontDestroyOnLoad 요소)

GameSystems 씬에서 관리하며 처음 실행 시 로드:

- **CurrencyManager** → 골드/Gem 관리  
- **InventoryManager** → 아이템 목록 관리 (50칸 제한, 포션/버프 스택)  
- **EquipmentManager** → 무기/방어구 장착  
- **UpgradeManager** → 강화/융합 규칙  
- **StageTransfer** → Lobby → Idle 씬 사이에서 StageData 전달  

각 매니저는 Awake()에서 아래 호출:

```csharp
DontDestroyOnLoad(this.gameObject);
📘 ScriptableObject 구조
ItemData

itemName
description
itemType (Potion, Weapon, Armor, BuffItem, Consumable)
icon
grade
enhanceLevel
statValues (HP, ATK, DEF 등)


MonsterData

monsterName
description
maxHp
attackPower
defensePower
moveSpeed
attackSpeed


StageData

stageName
monsterList (MonsterData[])
spawnDelay
rewardTable


RewardTable

fixedGoldReward
itemDropList (확률 기반)


UpgradeConfig

EnhanceRule[]
FusionRule[]

---
🧩 UI 시스템
UIManager
씬마다 다른 패널을 관리:


public GameObject panelLobby;
public GameObject panelIdle;
public GameObject panelInventory;
public GameObject panelShop;
public GameObject panelUpgrade;
public GameObject defaultPanel;

public void Show(GameObject panel);
public void ShowDefault();
InventoryUI
최대 50칸

포션 / 버프 아이템 → 스택 가능

장비는 장착 기능 호출

슬롯 생성:


Instantiate(slotPrefab, slotParent);
IdleHUD
Gem, Gold, ATK, DEF 실시간 표시

ShopUI
코인/Gem 결제 가능

포션/버프/강화서/융합서 판매

Gem → Gold 환전 제공

UpgradeUI
아이템 강화 (확률 기반)

아이템 융합 (등급별 확률 조정)

⚔ 플레이어 시스템
PlayerStats
HP, MP, EXP, ATK, DEF 저장

PlayerHPBar(World Space UI) 연결

PlayerAI
앞을 향해 자동 이동

몬스터 감지 & 공격 (공격속도/공격범위)

Coroutine 기반 쿨타임 관리

PlayerBuffSystem
공격력/방어력/이동속도 버프 적용

지속시간 관리

👹 몬스터 시스템
Monster.cs
MonsterData 참조하여 스탯 적용

Hit/Die 기능 포함

MonsterAI.cs
Player 추적

자동 공격 루프

StageManager와 연동

🌋 스테이지 및 전투 시스템
StageSelectUI (LobbyScene)
StageData 선택

StageTransfer.selectedStage에 저장

StageManager (IdleScene)
StageTransfer.selectedStage 로드

MonsterSpawner 실행

MonsterSpawner

StartCoroutine(SpawnStage(StageData data));
순서로 몬스터 생성 → spawnDelay 적용

---