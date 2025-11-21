# 프로젝트 이름 TIWD

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [주요기능](#주요기능)
3. [사용한 무료 에셋](#Asset_From_Unity)
4. [개발기간](#개발기간)
5. [기술스택](#기술스택)
6. [프로젝트 파일 구조](#프로젝트-파일-구조)
7. [Trouble Shooting](#trouble-shooting)


## 👨‍🏫 프로젝트 소개
- 프로젝트 명 : TIWD(Tommorow I WIll Die)
- 프로젝트 설명 : 사막에서 생존하며 적에게 살아남기
- 프로젝트 시작 계기 : 유니티 숙련과제 발제 중 3D 서바이벌 장르를 보고 제작하게 됨
- 프로젝트 구성 인원 : 유원영, 정재우, 류광섭, 조아라, 박재아


## 💜 주요기능

-GameManager 를 통해 게임의 전반적인 구동을 담당

-AudioManager에서 음악의 출력을 담당

-CraftManager에서 Item을 조합해 제작하는 부분을 담당

-SpawnManager를 통해 플레이어의 생성 및 적 생성을 담당

-UIManager에서 UI의 출력을 담당 Inventory UI / NpcDialog / Condition UI

-InputSystemManager를 통해 PlayerController/BuildModeController의 입력값을 관리

-ItemData/BuildData/BuildCatalog 에서 오브젝트들의 정보를 표시하는 Data형식의 파일 생성을 담당

-Interaction 에서 오브젝트들과의 상호작용을 담당

-Inventory에서 습득한 아이템의 저장을 담당.





## ⏲️ 개발기간
- 총 8일   { 2025.11.14(금) ~ 2025.11.21(금) }


### 🖥️ Language
*  C#


### 🔧 Version Control
*  Git + GitHub


### 🧩 IDE
* Visual Studio


### 🧰 Framework
* net9.0


## Asset From Unity


*모델링

KayKit_Skeletons_1.1_FREE

Just Survive

Tiny Teacup Studio


*UI

Cryo's Mini GUI

fantasy_pixelart_ui

Retro Pixel Ribbons, Banners and Frames 2


*AssetPackage

Dotween



### 🚀 배포 (Deploy)
- **빌드 환경:** Unity 2022.3.62f2
- **배포 방식:** 
- **결과물:** 


## 프로젝트 파일 구조

📦Assets
 ┣ 📂01_Scenes
 ┃ ┣ 📂MainScene
 ┃ ┃ ┣ 📜NavMesh.asset
 ┃ ┃ ┗ 📜NavMesh.asset.meta
 ┃ ┣ 📂TitleScene
 ┃ ┃ ┣ 📜NavMesh.asset
 ┃ ┃ ┗ 📜NavMesh.asset.meta
 ┣ 📂02_Scripts
 ┃ ┣ 📂BuildSequance
 ┃ ┃ ┣ 📂Buildings
 ┃ ┃ ┃ ┣ 📜Campfire.cs
 ┃ ┃ ┃ ┣ 📜Campfire.cs.meta
 ┃ ┃ ┃ ┣ 📜Fence.cs
 ┃ ┃ ┃ ┣ 📜Fence.cs.meta
 ┃ ┃ ┃ ┣ 📜Rock.cs
 ┃ ┃ ┃ ┣ 📜Rock.cs.meta
 ┃ ┃ ┃ ┣ 📜Tent.cs
 ┃ ┃ ┃ ┗ 📜Tent.cs.meta
 ┃ ┃ ┣ 📜BuildCatalogButton.cs
 ┃ ┃ ┣ 📜BuildCatalogButton.cs.meta
 ┃ ┃ ┣ 📜BuildCatalogPanel.cs
 ┃ ┃ ┣ 📜BuildCatalogPanel.cs.meta
 ┃ ┃ ┣ 📜BuildCatalogUI.cs
 ┃ ┃ ┣ 📜BuildCatalogUI.cs.meta
 ┃ ┃ ┣ 📜BuildCompleteObject.cs
 ┃ ┃ ┣ 📜BuildCompleteObject.cs.meta
 ┃ ┃ ┣ 📜Buildings.meta
 ┃ ┃ ┣ 📜BuildModeController.cs
 ┃ ┃ ┣ 📜BuildModeController.cs.meta
 ┃ ┃ ┣ 📜BuildModeTestSelector.cs
 ┃ ┃ ┣ 📜BuildModeTestSelector.cs.meta
 ┃ ┃ ┣ 📜BuildModeUI.cs
 ┃ ┃ ┣ 📜BuildModeUI.cs.meta
 ┃ ┃ ┣ 📜BuildPlacementSystem.cs
 ┃ ┃ ┣ 📜BuildPlacementSystem.cs.meta
 ┃ ┃ ┣ 📜BuildPreviewController.cs
 ┃ ┃ ┣ 📜BuildPreviewController.cs.meta
 ┃ ┃ ┣ 📜BuildResourceHandler.cs
 ┃ ┃ ┗ 📜BuildResourceHandler.cs.meta
 ┃ ┣ 📂Entities
 ┃ ┃ ┣ 📂Enemy
 ┃ ┃ ┃ ┣ 📜Enemy.cs
 ┃ ┃ ┃ ┗ 📜Enemy.cs.meta
 ┃ ┃ ┣ 📂NPC
 ┃ ┃ ┃ ┣ 📜NPCController.cs
 ┃ ┃ ┃ ┗ 📜NPCController.cs.meta
 ┃ ┃ ┣ 📂Player
 ┃ ┃ ┃ ┣ 📜Conditions.cs
 ┃ ┃ ┃ ┣ 📜Conditions.cs.meta
 ┃ ┃ ┃ ┣ 📜Equipment.cs
 ┃ ┃ ┃ ┣ 📜Equipment.cs.meta
 ┃ ┃ ┃ ┣ 📜Interaction.cs
 ┃ ┃ ┃ ┣ 📜Interaction.cs.meta
 ┃ ┃ ┃ ┣ 📜Player.cs
 ┃ ┃ ┃ ┣ 📜Player.cs.meta
 ┃ ┃ ┃ ┣ 📜PlayerCamera.cs
 ┃ ┃ ┃ ┣ 📜PlayerCamera.cs.meta
 ┃ ┃ ┃ ┣ 📜PlayerCondition.cs
 ┃ ┃ ┃ ┣ 📜PlayerCondition.cs.meta
 ┃ ┃ ┃ ┣ 📜PlayerController.cs
 ┃ ┃ ┃ ┣ 📜PlayerController.cs.meta
 ┃ ┃ ┃ ┣ 📜UIConditions.cs
 ┃ ┃ ┃ ┗ 📜UIConditions.cs.meta
 ┃ ┃ ┣ 📜Enemy.meta
 ┃ ┃ ┣ 📜NPC.meta
 ┃ ┃ ┗ 📜Player.meta
 ┃ ┣ 📂Item
 ┃ ┃ ┣ 📜EquipItem.cs
 ┃ ┃ ┣ 📜EquipItem.cs.meta
 ┃ ┃ ┣ 📜GatherableObject.cs
 ┃ ┃ ┣ 📜GatherableObject.cs.meta
 ┃ ┃ ┣ 📜Inventory.cs
 ┃ ┃ ┣ 📜Inventory.cs.meta
 ┃ ┃ ┣ 📜ItemObject.cs
 ┃ ┃ ┣ 📜ItemObject.cs.meta
 ┃ ┃ ┣ 📜ItemSlot.cs
 ┃ ┃ ┣ 📜ItemSlot.cs.meta
 ┃ ┃ ┣ 📜SupplyCrate.cs
 ┃ ┃ ┗ 📜SupplyCrate.cs.meta
 ┃ ┣ 📂Managers
 ┃ ┃ ┣ 📜AudioManager.cs
 ┃ ┃ ┣ 📜AudioManager.cs.meta
 ┃ ┃ ┣ 📜BuildModeManager.cs
 ┃ ┃ ┣ 📜BuildModeManager.cs.meta
 ┃ ┃ ┣ 📜CharacterManager.cs
 ┃ ┃ ┣ 📜CharacterManager.cs.meta
 ┃ ┃ ┣ 📜CraftManager.cs
 ┃ ┃ ┣ 📜CraftManager.cs.meta
 ┃ ┃ ┣ 📜GameManager.cs
 ┃ ┃ ┣ 📜GameManager.cs.meta
 ┃ ┃ ┣ 📜InputSystemManager.cs
 ┃ ┃ ┣ 📜InputSystemManager.cs.meta
 ┃ ┃ ┣ 📜SpawnManager.cs
 ┃ ┃ ┣ 📜SpawnManager.cs.meta
 ┃ ┃ ┣ 📜TitleManager.cs
 ┃ ┃ ┣ 📜TitleManager.cs.meta
 ┃ ┃ ┣ 📜UIManager.cs
 ┃ ┃ ┗ 📜UIManager.cs.meta
 ┃ ┣ 📂Spawners
 ┃ ┃ ┣ 📜EnemySpawner.cs
 ┃ ┃ ┣ 📜EnemySpawner.cs.meta
 ┃ ┃ ┣ 📜ItemSpawner.cs
 ┃ ┃ ┗ 📜ItemSpawner.cs.meta
 ┃ ┣ 📂UI
 ┃ ┃ ┣ 📜CraftingPanel.cs
 ┃ ┃ ┣ 📜CraftingPanel.cs.meta
 ┃ ┃ ┣ 📜InventoryPanelUI.cs
 ┃ ┃ ┣ 📜InventoryPanelUI.cs.meta
 ┃ ┃ ┣ 📜InventoryUI.cs
 ┃ ┃ ┣ 📜InventoryUI.cs.meta
 ┃ ┃ ┣ 📜SlotClickHandler.cs
 ┃ ┃ ┗ 📜SlotClickHandler.cs.meta
 ┃ ┣ 📜BuildSequance.meta
 ┃ ┣ 📜DayNightCycle.cs
 ┃ ┣ 📜DayNightCycle.cs.meta
 ┃ ┣ 📜Entities.meta
 ┃ ┣ 📜Enum.cs
 ┃ ┣ 📜Enum.cs.meta
 ┃ ┣ 📜Interface.cs
 ┃ ┣ 📜Interface.cs.meta
 ┃ ┣ 📜Item.meta
 ┃ ┣ 📜Managers.meta
 ┃ ┣ 📜Spawners.meta
 ┃ ┗ 📜UI.meta
 ┣ 📂03_Prefabs
 ┃ ┣ 📂Buildings
 ┃ ┃ ┣ 📂completePrefab
 ┃ ┃ ┃ ┣ 📜CampFire.prefab
 ┃ ┃ ┃ ┣ 📜CampFire.prefab.meta
 ┃ ┃ ┃ ┣ 📜Fence.prefab
 ┃ ┃ ┃ ┣ 📜Fence.prefab.meta
 ┃ ┃ ┃ ┣ 📜Rock.prefab
 ┃ ┃ ┃ ┣ 📜Rock.prefab.meta
 ┃ ┃ ┃ ┣ 📜Tent.prefab
 ┃ ┃ ┃ ┗ 📜Tent.prefab.meta
 ┃ ┃ ┣ 📂previewPrefab
 ┃ ┃ ┃ ┣ 📜preview_Campfire.prefab
 ┃ ┃ ┃ ┣ 📜preview_Campfire.prefab.meta
 ┃ ┃ ┃ ┣ 📜preview_Fence.prefab
 ┃ ┃ ┃ ┣ 📜preview_Fence.prefab.meta
 ┃ ┃ ┃ ┣ 📜preview_Rock.prefab
 ┃ ┃ ┃ ┣ 📜preview_Rock.prefab.meta
 ┃ ┃ ┃ ┣ 📜preview_Tent.prefab
 ┃ ┃ ┃ ┗ 📜preview_Tent.prefab.meta
 ┃ ┃ ┣ 📜Button_BuildData.prefab
 ┃ ┃ ┣ 📜Button_BuildData.prefab.meta
 ┃ ┃ ┣ 📜completePrefab.meta
 ┃ ┃ ┗ 📜previewPrefab.meta
 ┃ ┣ 📂Enemy
 ┃ ┃ ┣ 📜Skeleton_Mage.prefab
 ┃ ┃ ┣ 📜Skeleton_Mage.prefab.meta
 ┃ ┃ ┣ 📜Skeleton_Minion.prefab
 ┃ ┃ ┗ 📜Skeleton_Minion.prefab.meta
 ┃ ┣ 📂Item
 ┃ ┃ ┣ 📂@originalFBX
 ┃ ┃ ┣ 📂Consumable
 ┃ ┃ ┃ ┣ 📜Apple.prefab
 ┃ ┃ ┃ ┣ 📜Apple.prefab.meta
 ┃ ┃ ┃ ┣ 📜FirstAid.prefab
 ┃ ┃ ┃ ┣ 📜FirstAid.prefab.meta
 ┃ ┃ ┃ ┣ 📜Meat.prefab
 ┃ ┃ ┃ ┣ 📜Meat.prefab.meta
 ┃ ┃ ┃ ┣ 📜PlasticBottle.prefab
 ┃ ┃ ┃ ┗ 📜PlasticBottle.prefab.meta
 ┃ ┃ ┣ 📂Equipable
 ┃ ┃ ┃ ┣ 📂EquipPrefab
 ┃ ┃ ┃ ┃ ┣ 📜E_BaseballBat_Nails.prefab
 ┃ ┃ ┃ ┃ ┣ 📜E_BaseballBat_Nails.prefab.meta
 ┃ ┃ ┃ ┃ ┣ 📜E_Machete.prefab
 ┃ ┃ ┃ ┃ ┣ 📜E_Machete.prefab.meta
 ┃ ┃ ┃ ┃ ┣ 📜E_Stone Axe.prefab
 ┃ ┃ ┃ ┃ ┣ 📜E_Stone Axe.prefab.meta
 ┃ ┃ ┃ ┃ ┣ 📜E_Torch.prefab
 ┃ ┃ ┃ ┃ ┣ 📜E_Torch.prefab.meta
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Axe.prefab
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Axe.prefab.meta
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Club.prefab
 ┃ ┃ ┃ ┃ ┗ 📜E_Wooden Club.prefab.meta
 ┃ ┃ ┃ ┣ 📜BaseballBat_Nails.prefab
 ┃ ┃ ┃ ┣ 📜BaseballBat_Nails.prefab.meta
 ┃ ┃ ┃ ┣ 📜EquipPrefab.meta
 ┃ ┃ ┃ ┣ 📜Machete.prefab
 ┃ ┃ ┃ ┣ 📜Machete.prefab.meta
 ┃ ┃ ┃ ┣ 📜Stone Axe.prefab
 ┃ ┃ ┃ ┣ 📜Stone Axe.prefab.meta
 ┃ ┃ ┃ ┣ 📜Torch.prefab
 ┃ ┃ ┃ ┣ 📜Torch.prefab.meta
 ┃ ┃ ┃ ┣ 📜Wooden Axe.prefab
 ┃ ┃ ┃ ┣ 📜Wooden Axe.prefab.meta
 ┃ ┃ ┃ ┣ 📜Wooden Club.prefab
 ┃ ┃ ┃ ┗ 📜Wooden Club.prefab.meta
 ┃ ┃ ┣ 📂GatherableObject
 ┃ ┃ ┃ ┣ 📂Crate
 ┃ ┃ ┃ ┃ ┣ 📜Crate texture.png
 ┃ ┃ ┃ ┃ ┣ 📜Crate texture.png.meta
 ┃ ┃ ┃ ┃ ┣ 📜crate.fbx
 ┃ ┃ ┃ ┃ ┣ 📜crate.fbx.meta
 ┃ ┃ ┃ ┃ ┣ 📜crateMat.mat
 ┃ ┃ ┃ ┃ ┣ 📜crateMat.mat.meta
 ┃ ┃ ┃ ┃ ┣ 📜SupplyCrate.prefab
 ┃ ┃ ┃ ┃ ┗ 📜SupplyCrate.prefab.meta
 ┃ ┃ ┃ ┣ 📜Crate.meta
 ┃ ┃ ┃ ┣ 📜Rock002.prefab
 ┃ ┃ ┃ ┣ 📜Rock002.prefab.meta
 ┃ ┃ ┃ ┣ 📜Tree_01.prefab
 ┃ ┃ ┃ ┗ 📜Tree_01.prefab.meta
 ┃ ┃ ┣ 📂Resource
 ┃ ┃ ┃ ┣ 📜Branch.prefab
 ┃ ┃ ┃ ┣ 📜Branch.prefab.meta
 ┃ ┃ ┃ ┣ 📜Flint.prefab
 ┃ ┃ ┃ ┣ 📜Flint.prefab.meta
 ┃ ┃ ┃ ┣ 📜Stick.prefab
 ┃ ┃ ┃ ┣ 📜Stick.prefab.meta
 ┃ ┃ ┃ ┣ 📜Stone.prefab
 ┃ ┃ ┃ ┗ 📜Stone.prefab.meta
 ┃ ┃ ┣ 📜@originalFBX.meta
 ┃ ┃ ┣ 📜Consumable.meta
 ┃ ┃ ┣ 📜Equipable.meta
 ┃ ┃ ┣ 📜GatherableObject.meta
 ┃ ┃ ┗ 📜Resource.meta
 ┃ ┣ 📂Manager
 ┃ ┃ ┣ 📜AudioManager.prefab
 ┃ ┃ ┣ 📜AudioManager.prefab.meta
 ┃ ┃ ┣ 📜CraftManager.prefab
 ┃ ┃ ┣ 📜CraftManager.prefab.meta
 ┃ ┃ ┣ 📜GameManager.prefab
 ┃ ┃ ┗ 📜GameManager.prefab.meta
 ┃ ┣ 📂Spawner
 ┃ ┃ ┣ 📜EnemySpawner.prefab
 ┃ ┃ ┣ 📜EnemySpawner.prefab.meta
 ┃ ┃ ┣ 📜ItemSpawner.prefab
 ┃ ┃ ┗ 📜ItemSpawner.prefab.meta
 ┃ ┣ 📂UI
 ┃ ┃ ┣ 📜ConditionalPanel.prefab
 ┃ ┃ ┣ 📜ConditionalPanel.prefab.meta
 ┃ ┃ ┣ 📜InventoryCraftingWindow.prefab
 ┃ ┃ ┣ 📜InventoryCraftingWindow.prefab.meta
 ┃ ┃ ┣ 📜NPCDialoguePanel.prefab
 ┃ ┃ ┣ 📜NPCDialoguePanel.prefab.meta
 ┃ ┃ ┣ 📜RecipeButton.prefab
 ┃ ┃ ┣ 📜RecipeButton.prefab.meta
 ┃ ┃ ┣ 📜Slot.prefab
 ┃ ┃ ┗ 📜Slot.prefab.meta
 ┃ ┣ 📜Buildings.meta
 ┃ ┣ 📜DayAndNight.prefab
 ┃ ┣ 📜DayAndNight.prefab.meta
 ┃ ┣ 📜Enemy.meta
 ┃ ┣ 📜Item.meta
 ┃ ┣ 📜Manager.meta
 ┃ ┣ 📜Player.prefab
 ┃ ┣ 📜Player.prefab.meta
 ┃ ┣ 📜Spawner.meta
 ┃ ┗ 📜UI.meta
 ┣ 📂04_Animations
 ┃ ┣ 📂Enemy
 ┃ ┃ ┣ 📜Skeleton_Mage.controller
 ┃ ┃ ┣ 📜Skeleton_Mage.controller.meta
 ┃ ┃ ┣ 📜Skeleton_Minion.controller
 ┃ ┃ ┗ 📜Skeleton_Minion.controller.meta
 ┃ ┣ 📂Equip
 ┃ ┃ ┣ 📂BaseballBat
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜BaseballBat.controller
 ┃ ┃ ┃ ┣ 📜BaseballBat.controller.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┗ 📜Idle.anim.meta
 ┃ ┃ ┣ 📂Machete
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┃ ┣ 📜Machete.controller
 ┃ ┃ ┃ ┗ 📜Machete.controller.meta
 ┃ ┃ ┣ 📂StoneAxe
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┃ ┣ 📜StoneAxe.controller
 ┃ ┃ ┃ ┗ 📜StoneAxe.controller.meta
 ┃ ┃ ┣ 📂Torch
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┃ ┣ 📜Torch.controller
 ┃ ┃ ┃ ┗ 📜Torch.controller.meta
 ┃ ┃ ┣ 📂WoodenAxe
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┃ ┣ 📜WoodenAxe.controller
 ┃ ┃ ┃ ┗ 📜WoodenAxe.controller.meta
 ┃ ┃ ┣ 📂WoodenClub
 ┃ ┃ ┃ ┣ 📜Attack.anim
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta
 ┃ ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┃ ┣ 📜WoodenClub.controller
 ┃ ┃ ┃ ┗ 📜WoodenClub.controller.meta
 ┃ ┃ ┣ 📜BaseballBat.meta
 ┃ ┃ ┣ 📜Machete.meta
 ┃ ┃ ┣ 📜StoneAxe.meta
 ┃ ┃ ┣ 📜Torch.meta
 ┃ ┃ ┣ 📜WoodenAxe.meta
 ┃ ┃ ┗ 📜WoodenClub.meta
 ┃ ┣ 📂NPC
 ┃ ┃ ┣ 📜NPC_Controller.controller
 ┃ ┃ ┗ 📜NPC_Controller.controller.meta
 ┃ ┣ 📜Enemy.meta
 ┃ ┣ 📜Equip.meta
 ┃ ┗ 📜NPC.meta
 ┣ 📂05_Data
 ┃ ┣ 📂BuildData
 ┃ ┃ ┣ 📂BuildCatalog
 ┃ ┃ ┃ ┣ 📜BuildCatalog.asset
 ┃ ┃ ┃ ┣ 📜BuildCatalog.asset.meta
 ┃ ┃ ┃ ┣ 📜BuildCatalog.cs
 ┃ ┃ ┃ ┗ 📜BuildCatalog.cs.meta
 ┃ ┃ ┣ 📜BuildCatalog.meta
 ┃ ┃ ┣ 📜BuildData.cs
 ┃ ┃ ┣ 📜BuildData.cs.meta
 ┃ ┃ ┣ 📜BuildData_CampFire.asset
 ┃ ┃ ┣ 📜BuildData_CampFire.asset.meta
 ┃ ┃ ┣ 📜BuildData_Fence.asset
 ┃ ┃ ┣ 📜BuildData_Fence.asset.meta
 ┃ ┃ ┣ 📜BuildData_Rock.asset
 ┃ ┃ ┣ 📜BuildData_Rock.asset.meta
 ┃ ┃ ┣ 📜BuildData_Tent.asset
 ┃ ┃ ┗ 📜BuildData_Tent.asset.meta
 ┃ ┣ 📂CraftData
 ┃ ┃ ┣ 📜CraftData.cs
 ┃ ┃ ┣ 📜CraftData.cs.meta
 ┃ ┃ ┣ 📜Craft_StoneAxe.asset
 ┃ ┃ ┣ 📜Craft_StoneAxe.asset.meta
 ┃ ┃ ┣ 📜Craft_Torch.asset
 ┃ ┃ ┣ 📜Craft_Torch.asset.meta
 ┃ ┃ ┣ 📜Craft_WoodenAxe.asset
 ┃ ┃ ┗ 📜Craft_WoodenAxe.asset.meta
 ┃ ┣ 📂DropData
 ┃ ┃ ┣ 📂GatherableObject
 ┃ ┃ ┃ ┣ 📜Drop_Branch.asset
 ┃ ┃ ┃ ┣ 📜Drop_Branch.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Flint.asset
 ┃ ┃ ┃ ┣ 📜Drop_Flint.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Stick.asset
 ┃ ┃ ┃ ┣ 📜Drop_Stick.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Stone.asset
 ┃ ┃ ┃ ┗ 📜Drop_Stone.asset.meta
 ┃ ┃ ┣ 📂SupplyCrate
 ┃ ┃ ┃ ┣ 📜Drop_Apple.asset
 ┃ ┃ ┃ ┣ 📜Drop_Apple.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Bat.asset
 ┃ ┃ ┃ ┣ 📜Drop_Bat.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_FirstAid.asset
 ┃ ┃ ┃ ┣ 📜Drop_FirstAid.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Machete.asset
 ┃ ┃ ┃ ┣ 📜Drop_Machete.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_Meat.asset
 ┃ ┃ ┃ ┣ 📜Drop_Meat.asset.meta
 ┃ ┃ ┃ ┣ 📜Drop_PlasticBottle.asset
 ┃ ┃ ┃ ┗ 📜Drop_PlasticBottle.asset.meta
 ┃ ┃ ┣ 📜DropData.cs
 ┃ ┃ ┣ 📜DropData.cs.meta
 ┃ ┃ ┣ 📜GatherableObject.meta
 ┃ ┃ ┗ 📜SupplyCrate.meta
 ┃ ┣ 📂Enemy
 ┃ ┃ ┣ 📂Data
 ┃ ┃ ┃ ┣ 📜SkeletonMage.asset
 ┃ ┃ ┃ ┣ 📜SkeletonMage.asset.meta
 ┃ ┃ ┃ ┣ 📜SkeletonMinion.asset
 ┃ ┃ ┃ ┗ 📜SkeletonMinion.asset.meta
 ┃ ┃ ┣ 📜Data.meta
 ┃ ┃ ┣ 📜EnemyData.cs
 ┃ ┃ ┗ 📜EnemyData.cs.meta
 ┃ ┣ 📂ItemData
 ┃ ┃ ┣ 📂Consumable
 ┃ ┃ ┃ ┣ 📜Consumable_Apple.asset
 ┃ ┃ ┃ ┣ 📜Consumable_Apple.asset.meta
 ┃ ┃ ┃ ┣ 📜Consumable_BottledWater.asset
 ┃ ┃ ┃ ┣ 📜Consumable_BottledWater.asset.meta
 ┃ ┃ ┃ ┣ 📜Consumable_FirstAid.asset
 ┃ ┃ ┃ ┣ 📜Consumable_FirstAid.asset.meta
 ┃ ┃ ┃ ┣ 📜Consumable_Meat.asset
 ┃ ┃ ┃ ┗ 📜Consumable_Meat.asset.meta
 ┃ ┃ ┣ 📂Equipable
 ┃ ┃ ┃ ┣ 📜Tool_StoneAxe.asset
 ┃ ┃ ┃ ┣ 📜Tool_StoneAxe.asset.meta
 ┃ ┃ ┃ ┣ 📜Tool_Torch.asset
 ┃ ┃ ┃ ┣ 📜Tool_Torch.asset.meta
 ┃ ┃ ┃ ┣ 📜Tool_WoodenAxe.asset
 ┃ ┃ ┃ ┣ 📜Tool_WoodenAxe.asset.meta
 ┃ ┃ ┃ ┣ 📜Tool_WoodenClub.asset
 ┃ ┃ ┃ ┣ 📜Tool_WoodenClub.asset.meta
 ┃ ┃ ┃ ┣ 📜Weapon_Bat.asset
 ┃ ┃ ┃ ┣ 📜Weapon_Bat.asset.meta
 ┃ ┃ ┃ ┣ 📜Weapon_Machete.asset
 ┃ ┃ ┃ ┗ 📜Weapon_Machete.asset.meta
 ┃ ┃ ┣ 📂Resource
 ┃ ┃ ┃ ┣ 📜Resource_Branch.asset
 ┃ ┃ ┃ ┣ 📜Resource_Branch.asset.meta
 ┃ ┃ ┃ ┣ 📜Resource_Flint.asset
 ┃ ┃ ┃ ┣ 📜Resource_Flint.asset.meta
 ┃ ┃ ┃ ┣ 📜Resource_Stick.asset
 ┃ ┃ ┃ ┣ 📜Resource_Stick.asset.meta
 ┃ ┃ ┃ ┣ 📜Resource_Stone.asset
 ┃ ┃ ┃ ┗ 📜Resource_Stone.asset.meta
 ┃ ┃ ┣ 📜Consumable.meta
 ┃ ┃ ┣ 📜Equipable.meta
 ┃ ┃ ┣ 📜ItemData.cs
 ┃ ┃ ┣ 📜ItemData.cs.meta
 ┃ ┃ ┗ 📜Resource.meta
 ┃ ┣ 📜BuildData.meta
 ┃ ┣ 📜CraftData.meta
 ┃ ┣ 📜DropData.meta
 ┃ ┣ 📜Enemy.meta
 ┃ ┗ 📜ItemData.meta
 ┣ 📜01_Scenes.meta
 ┣ 📜02_Scripts.meta
 ┣ 📜03_Prefabs.meta
 ┣ 📜04_Animations.meta
 ┣ 📜05_Data.meta
 ┣ 📜Plugins.meta
 ┣ 📜Resources.meta
 ┗ 📜TextMesh Pro.meta