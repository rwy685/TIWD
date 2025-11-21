# 📖 목차
1. [프로젝트 소개](https://github.com/rwy685/TIWD/edit/Develop/README.md#%E2%80%8D-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%EC%86%8C%EA%B0%9C)
2. [주요기능](https://github.com/rwy685/TIWD/edit/Develop/README.md#-%EC%A3%BC%EC%9A%94%EA%B8%B0%EB%8A%A5)
3. [개발기간](https://github.com/rwy685/TIWD/edit/Develop/README.md#%EF%B8%8F-%EA%B0%9C%EB%B0%9C%EA%B8%B0%EA%B0%84)
4. [사용한 무료 에셋](https://github.com/rwy685/TIWD/edit/Develop/README.md#asset-from-unity)
5. [프로젝트 파일 구조](#프로젝트-파일-구조)


# 👨‍🏫 프로젝트 소개
- 프로젝트 명 : **TIWD** (<ins>**T**</ins>ommorow <ins>**I**</ins> <ins>**W**</ins>Ill <ins>**D**</ins>ie)
- 프로젝트 설명 : 사막에서 생존하며 적에게 살아남기
- 프로젝트 시작 계기 : 유니티 숙련과제 발제 중 3D 서바이벌 장르를 보고 제작하게 됨
- 프로젝트 구성 인원 : 유원영, 정재우, 류광섭, 조아라, 박재아


# 💜 주요기능

- `GameManager` : 게임의 전반적인 구동을 담당

- `AudioManager` : 음악의 출력을 담당

- `CraftManager` : `Item` 을 조합해 새로운 `Item` 을 제작하는 부분을 담당

- `SpawnManager` : `Player` 및 `Item` 의 자동 생성을 담당

- `UIManager` : UI의 출력을 담당 ( `Inventory UI` / `NPCDialog` / `Condition UI` )

- `InputSystemManager` : `PlayerController` / `BuildModeController` 의 입력값을 관리

- `ItemData` / `BuildData` / `BuildCatalog` 에서 오브젝트들의 정보를 표시하는 Data형식의 파일 생성을 담당

- `Interaction` : 오브젝트들과의 상호작용을 담당

- `Inventory` : 습득한 아이템 저장 및 버리기 등 전반적인 인벤토리 기능 담당





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


* 모델링

  KayKit_Skeletons_1.1_FREE

  Just Survive

  Tiny Teacup Studio


* UI

  Cryo's Mini GUI

  fantasy_pixelart_ui

  Retro Pixel Ribbons, Banners and Frames 2


* AssetPackage

  Dotween



### 🚀 배포 (Deploy)
- **빌드 환경:** Unity 2022.3.62f2
- **배포 방식:** 
- **결과물:** 


## 프로젝트 파일 구조

📦Assets<br>
 ┣ 📂01_Scenes<br>
 ┃ ┣ 📂MainScene<br>
 ┃ ┃ ┣ 📜NavMesh.asset<br>
 ┃ ┃ ┗ 📜NavMesh.asset.meta<br>
 ┃ ┣ 📂TitleScene<br>
 ┃ ┃ ┣ 📜NavMesh.asset<br>
 ┃ ┃ ┗ 📜NavMesh.asset.meta<br>
 ┣ 📂02_Scripts<br>
 ┃ ┣ 📂BuildSequance<br>
 ┃ ┃ ┣ 📂Buildings<br>
 ┃ ┃ ┃ ┣ 📜Campfire.cs<br>
 ┃ ┃ ┃ ┣ 📜Campfire.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Fence.cs<br>
 ┃ ┃ ┃ ┣ 📜Fence.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Rock.cs<br>
 ┃ ┃ ┃ ┣ 📜Rock.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Tent.cs<br>
 ┃ ┃ ┃ ┗ 📜Tent.cs.meta<br>
 ┃ ┃ ┣ 📜BuildCatalogButton.cs<br>
 ┃ ┃ ┣ 📜BuildCatalogButton.cs.meta<br>
 ┃ ┃ ┣ 📜BuildCatalogPanel.cs<br>
 ┃ ┃ ┣ 📜BuildCatalogPanel.cs.meta<br>
 ┃ ┃ ┣ 📜BuildCatalogUI.cs<br>
 ┃ ┃ ┣ 📜BuildCatalogUI.cs.meta<br>
 ┃ ┃ ┣ 📜BuildCompleteObject.cs<br>
 ┃ ┃ ┣ 📜BuildCompleteObject.cs.meta<br>
 ┃ ┃ ┣ 📜Buildings.meta<br>
 ┃ ┃ ┣ 📜BuildModeController.cs<br>
 ┃ ┃ ┣ 📜BuildModeController.cs.meta<br>
 ┃ ┃ ┣ 📜BuildModeTestSelector.cs<br>
 ┃ ┃ ┣ 📜BuildModeTestSelector.cs.meta<br>
 ┃ ┃ ┣ 📜BuildModeUI.cs<br>
 ┃ ┃ ┣ 📜BuildModeUI.cs.meta<br>
 ┃ ┃ ┣ 📜BuildPlacementSystem.cs<br>
 ┃ ┃ ┣ 📜BuildPlacementSystem.cs.meta<br>
 ┃ ┃ ┣ 📜BuildPreviewController.cs<br>
 ┃ ┃ ┣ 📜BuildPreviewController.cs.meta<br>
 ┃ ┃ ┣ 📜BuildResourceHandler.cs<br>
 ┃ ┃ ┗ 📜BuildResourceHandler.cs.meta<br>
 ┃ ┣ 📂Entities<br>
 ┃ ┃ ┣ 📂Enemy<br>
 ┃ ┃ ┃ ┣ 📜Enemy.cs<br>
 ┃ ┃ ┃ ┗ 📜Enemy.cs.meta<br>
 ┃ ┃ ┣ 📂NPC<br>
 ┃ ┃ ┃ ┣ 📜NPCController.cs<br>
 ┃ ┃ ┃ ┗ 📜NPCController.cs.meta<br>
 ┃ ┃ ┣ 📂Player<br>
 ┃ ┃ ┃ ┣ 📜Conditions.cs<br>
 ┃ ┃ ┃ ┣ 📜Conditions.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Equipment.cs<br>
 ┃ ┃ ┃ ┣ 📜Equipment.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Interaction.cs<br>
 ┃ ┃ ┃ ┣ 📜Interaction.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜Player.cs<br>
 ┃ ┃ ┃ ┣ 📜Player.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜PlayerCamera.cs<br>
 ┃ ┃ ┃ ┣ 📜PlayerCamera.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜PlayerCondition.cs<br>
 ┃ ┃ ┃ ┣ 📜PlayerCondition.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜PlayerController.cs<br>
 ┃ ┃ ┃ ┣ 📜PlayerController.cs.meta<br>
 ┃ ┃ ┃ ┣ 📜UIConditions.cs<br>
 ┃ ┃ ┃ ┗ 📜UIConditions.cs.meta<br>
 ┃ ┃ ┣ 📜Enemy.meta<br>
 ┃ ┃ ┣ 📜NPC.meta<br>
 ┃ ┃ ┗ 📜Player.meta<br>
 ┃ ┣ 📂Item<br>
 ┃ ┃ ┣ 📜EquipItem.cs<br>
 ┃ ┃ ┣ 📜EquipItem.cs.meta<br>
 ┃ ┃ ┣ 📜GatherableObject.cs<br>
 ┃ ┃ ┣ 📜GatherableObject.cs.meta<br>
 ┃ ┃ ┣ 📜Inventory.cs<br>
 ┃ ┃ ┣ 📜Inventory.cs.meta<br>
 ┃ ┃ ┣ 📜ItemObject.cs<br>
 ┃ ┃ ┣ 📜ItemObject.cs.meta<br>
 ┃ ┃ ┣ 📜ItemSlot.cs<br>
 ┃ ┃ ┣ 📜ItemSlot.cs.meta<br>
 ┃ ┃ ┣ 📜SupplyCrate.cs<br>
 ┃ ┃ ┗ 📜SupplyCrate.cs.meta<br>
 ┃ ┣ 📂Managers<br>
 ┃ ┃ ┣ 📜AudioManager.cs<br>
 ┃ ┃ ┣ 📜AudioManager.cs.meta<br>
 ┃ ┃ ┣ 📜BuildModeManager.cs<br>
 ┃ ┃ ┣ 📜BuildModeManager.cs.meta<br>
 ┃ ┃ ┣ 📜CharacterManager.cs<br>
 ┃ ┃ ┣ 📜CharacterManager.cs.meta<br>
 ┃ ┃ ┣ 📜CraftManager.cs<br>
 ┃ ┃ ┣ 📜CraftManager.cs.meta<br>
 ┃ ┃ ┣ 📜GameManager.cs<br>
 ┃ ┃ ┣ 📜GameManager.cs.meta<br>
 ┃ ┃ ┣ 📜InputSystemManager.cs<br>
 ┃ ┃ ┣ 📜InputSystemManager.cs.meta<br>
 ┃ ┃ ┣ 📜SpawnManager.cs<br>
 ┃ ┃ ┣ 📜SpawnManager.cs.meta<br>
 ┃ ┃ ┣ 📜TitleManager.cs<br>
 ┃ ┃ ┣ 📜TitleManager.cs.meta<br>
 ┃ ┃ ┣ 📜UIManager.cs<br>
 ┃ ┃ ┗ 📜UIManager.cs.meta<br>
 ┃ ┣ 📂Spawners<br>
 ┃ ┃ ┣ 📜EnemySpawner.cs<br>
 ┃ ┃ ┣ 📜EnemySpawner.cs.meta<br>
 ┃ ┃ ┣ 📜ItemSpawner.cs<br>
 ┃ ┃ ┗ 📜ItemSpawner.cs.meta<br>
 ┃ ┣ 📂UI<br>
 ┃ ┃ ┣ 📜CraftingPanel.cs<br>
 ┃ ┃ ┣ 📜CraftingPanel.cs.meta<br>
 ┃ ┃ ┣ 📜InventoryPanelUI.cs<br>
 ┃ ┃ ┣ 📜InventoryPanelUI.cs.meta<br>
 ┃ ┃ ┣ 📜InventoryUI.cs<br>
 ┃ ┃ ┣ 📜InventoryUI.cs.meta<br>
 ┃ ┃ ┣ 📜SlotClickHandler.cs<br>
 ┃ ┃ ┗ 📜SlotClickHandler.cs.meta<br>
 ┃ ┣ 📜BuildSequance.meta<br>
 ┃ ┣ 📜DayNightCycle.cs<br>
 ┃ ┣ 📜DayNightCycle.cs.meta<br>
 ┃ ┣ 📜Entities.meta<br>
 ┃ ┣ 📜Enum.cs<br>
 ┃ ┣ 📜Enum.cs.meta<br>
 ┃ ┣ 📜Interface.cs<br>
 ┃ ┣ 📜Interface.cs.meta<br>
 ┃ ┣ 📜Item.meta<br>
 ┃ ┣ 📜Managers.meta<br>
 ┃ ┣ 📜Spawners.meta<br>
 ┃ ┗ 📜UI.meta<br>
 ┣ 📂03_Prefabs<br>
 ┃ ┣ 📂Buildings<br>
 ┃ ┃ ┣ 📂completePrefab<br>
 ┃ ┃ ┃ ┣ 📜CampFire.prefab<br>
 ┃ ┃ ┃ ┣ 📜CampFire.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Fence.prefab<br>
 ┃ ┃ ┃ ┣ 📜Fence.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Rock.prefab<br>
 ┃ ┃ ┃ ┣ 📜Rock.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Tent.prefab<br>
 ┃ ┃ ┃ ┗ 📜Tent.prefab.meta<br>
 ┃ ┃ ┣ 📂previewPrefab<br>
 ┃ ┃ ┃ ┣ 📜preview_Campfire.prefab<br>
 ┃ ┃ ┃ ┣ 📜preview_Campfire.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜preview_Fence.prefab<br>
 ┃ ┃ ┃ ┣ 📜preview_Fence.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜preview_Rock.prefab<br>
 ┃ ┃ ┃ ┣ 📜preview_Rock.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜preview_Tent.prefab<br>
 ┃ ┃ ┃ ┗ 📜preview_Tent.prefab.meta<br>
 ┃ ┃ ┣ 📜Button_BuildData.prefab<br>
 ┃ ┃ ┣ 📜Button_BuildData.prefab.meta<br>
 ┃ ┃ ┣ 📜completePrefab.meta<br>
 ┃ ┃ ┗ 📜previewPrefab.meta<br>
 ┃ ┣ 📂Enemy<br>
 ┃ ┃ ┣ 📜Skeleton_Mage.prefab<br>
 ┃ ┃ ┣ 📜Skeleton_Mage.prefab.meta<br>
 ┃ ┃ ┣ 📜Skeleton_Minion.prefab<br>
 ┃ ┃ ┗ 📜Skeleton_Minion.prefab.meta<br>
 ┃ ┣ 📂Item<br>
 ┃ ┃ ┣ 📂@originalFBX<br>
 ┃ ┃ ┣ 📂Consumable<br>
 ┃ ┃ ┃ ┣ 📜Apple.prefab<br>
 ┃ ┃ ┃ ┣ 📜Apple.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜FirstAid.prefab<br>
 ┃ ┃ ┃ ┣ 📜FirstAid.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Meat.prefab<br>
 ┃ ┃ ┃ ┣ 📜Meat.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜PlasticBottle.prefab<br>
 ┃ ┃ ┃ ┗ 📜PlasticBottle.prefab.meta<br>
 ┃ ┃ ┣ 📂Equipable<br>
 ┃ ┃ ┃ ┣ 📂EquipPrefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_BaseballBat_Nails.prefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_BaseballBat_Nails.prefab.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Machete.prefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Machete.prefab.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Stone Axe.prefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Stone Axe.prefab.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Torch.prefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Torch.prefab.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Axe.prefab<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Axe.prefab.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜E_Wooden Club.prefab<br>
 ┃ ┃ ┃ ┃ ┗ 📜E_Wooden Club.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜BaseballBat_Nails.prefab<br>
 ┃ ┃ ┃ ┣ 📜BaseballBat_Nails.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜EquipPrefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Machete.prefab<br>
 ┃ ┃ ┃ ┣ 📜Machete.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Stone Axe.prefab<br>
 ┃ ┃ ┃ ┣ 📜Stone Axe.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Torch.prefab<br>
 ┃ ┃ ┃ ┣ 📜Torch.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Wooden Axe.prefab<br>
 ┃ ┃ ┃ ┣ 📜Wooden Axe.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Wooden Club.prefab<br>
 ┃ ┃ ┃ ┗ 📜Wooden Club.prefab.meta<br>
 ┃ ┃ ┣ 📂GatherableObject<br>
 ┃ ┃ ┃ ┣ 📂Crate<br>
 ┃ ┃ ┃ ┃ ┣ 📜Crate texture.png<br>
 ┃ ┃ ┃ ┃ ┣ 📜Crate texture.png.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜crate.fbx<br>
 ┃ ┃ ┃ ┃ ┣ 📜crate.fbx.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜crateMat.mat<br>
 ┃ ┃ ┃ ┃ ┣ 📜crateMat.mat.meta<br>
 ┃ ┃ ┃ ┃ ┣ 📜SupplyCrate.prefab<br>
 ┃ ┃ ┃ ┃ ┗ 📜SupplyCrate.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Crate.meta<br>
 ┃ ┃ ┃ ┣ 📜Rock002.prefab<br>
 ┃ ┃ ┃ ┣ 📜Rock002.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Tree_01.prefab<br>
 ┃ ┃ ┃ ┗ 📜Tree_01.prefab.meta<br>
 ┃ ┃ ┣ 📂Resource<br>
 ┃ ┃ ┃ ┣ 📜Branch.prefab<br>
 ┃ ┃ ┃ ┣ 📜Branch.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Flint.prefab<br>
 ┃ ┃ ┃ ┣ 📜Flint.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Stick.prefab<br>
 ┃ ┃ ┃ ┣ 📜Stick.prefab.meta<br>
 ┃ ┃ ┃ ┣ 📜Stone.prefab<br>
 ┃ ┃ ┃ ┗ 📜Stone.prefab.meta<br>
 ┃ ┃ ┣ 📜@originalFBX.meta<br>
 ┃ ┃ ┣ 📜Consumable.meta<br>
 ┃ ┃ ┣ 📜Equipable.meta<br>
 ┃ ┃ ┣ 📜GatherableObject.meta<br>
 ┃ ┃ ┗ 📜Resource.meta<br>
 ┃ ┣ 📂Manager<br>
 ┃ ┃ ┣ 📜AudioManager.prefab<br>
 ┃ ┃ ┣ 📜AudioManager.prefab.meta<br>
 ┃ ┃ ┣ 📜CraftManager.prefab<br>
 ┃ ┃ ┣ 📜CraftManager.prefab.meta<br>
 ┃ ┃ ┣ 📜GameManager.prefab<br>
 ┃ ┃ ┗ 📜GameManager.prefab.meta<br>
 ┃ ┣ 📂Spawner<br>
 ┃ ┃ ┣ 📜EnemySpawner.prefab<br>
 ┃ ┃ ┣ 📜EnemySpawner.prefab.meta<br>
 ┃ ┃ ┣ 📜ItemSpawner.prefab<br>
 ┃ ┃ ┗ 📜ItemSpawner.prefab.meta<br>
 ┃ ┣ 📂UI<br>
 ┃ ┃ ┣ 📜ConditionalPanel.prefab<br>
 ┃ ┃ ┣ 📜ConditionalPanel.prefab.meta<br>
 ┃ ┃ ┣ 📜InventoryCraftingWindow.prefab<br>
 ┃ ┃ ┣ 📜InventoryCraftingWindow.prefab.meta<br>
 ┃ ┃ ┣ 📜NPCDialoguePanel.prefab<br>
 ┃ ┃ ┣ 📜NPCDialoguePanel.prefab.meta<br>
 ┃ ┃ ┣ 📜RecipeButton.prefab<br>
 ┃ ┃ ┣ 📜RecipeButton.prefab.meta<br>
 ┃ ┃ ┣ 📜Slot.prefab<br>
 ┃ ┃ ┗ 📜Slot.prefab.meta<br>
 ┃ ┣ 📜Buildings.meta<br>
 ┃ ┣ 📜DayAndNight.prefab<br>
 ┃ ┣ 📜DayAndNight.prefab.meta<br>
 ┃ ┣ 📜Enemy.meta<br>
 ┃ ┣ 📜Item.meta<br>
 ┃ ┣ 📜Manager.meta<br>
 ┃ ┣ 📜Player.prefab<br>
 ┃ ┣ 📜Player.prefab.meta<br>
 ┃ ┣ 📜Spawner.meta<br>
 ┃ ┗ 📜UI.meta<br>
 ┣ 📂04_Animations<br>
 ┃ ┣ 📂Enemy<br>
 ┃ ┃ ┣ 📜Skeleton_Mage.controller<br>
 ┃ ┃ ┣ 📜Skeleton_Mage.controller.meta<br>
 ┃ ┃ ┣ 📜Skeleton_Minion.controller<br>
 ┃ ┃ ┗ 📜Skeleton_Minion.controller.meta<br>
 ┃ ┣ 📂Equip<br>
 ┃ ┃ ┣ 📂BaseballBat<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜BaseballBat.controller<br>
 ┃ ┃ ┃ ┣ 📜BaseballBat.controller.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┗ 📜Idle.anim.meta<br>
 ┃ ┃ ┣ 📂Machete<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Machete.controller<br>
 ┃ ┃ ┃ ┗ 📜Machete.controller.meta<br>
 ┃ ┃ ┣ 📂StoneAxe<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜StoneAxe.controller<br>
 ┃ ┃ ┃ ┗ 📜StoneAxe.controller.meta<br>
 ┃ ┃ ┣ 📂Torch<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Torch.controller<br>
 ┃ ┃ ┃ ┗ 📜Torch.controller.meta<br>
 ┃ ┃ ┣ 📂WoodenAxe<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜WoodenAxe.controller<br>
 ┃ ┃ ┃ ┗ 📜WoodenAxe.controller.meta<br>
 ┃ ┃ ┣ 📂WoodenClub<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim<br>
 ┃ ┃ ┃ ┣ 📜Attack.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim<br>
 ┃ ┃ ┃ ┣ 📜Idle.anim.meta<br>
 ┃ ┃ ┃ ┣ 📜WoodenClub.controller<br>
 ┃ ┃ ┃ ┗ 📜WoodenClub.controller.meta<br>
 ┃ ┃ ┣ 📜BaseballBat.meta<br>
 ┃ ┃ ┣ 📜Machete.meta<br>
 ┃ ┃ ┣ 📜StoneAxe.meta<br>
 ┃ ┃ ┣ 📜Torch.meta<br>
 ┃ ┃ ┣ 📜WoodenAxe.meta<br>
 ┃ ┃ ┗ 📜WoodenClub.meta<br>
 ┃ ┣ 📂NPC<br>
 ┃ ┃ ┣ 📜NPC_Controller.controller<br>
 ┃ ┃ ┗ 📜NPC_Controller.controller.meta<br>
 ┃ ┣ 📜Enemy.meta<br>
 ┃ ┣ 📜Equip.meta<br>
 ┃ ┗ 📜NPC.meta<br>
 ┣ 📂05_Data<br>
 ┃ ┣ 📂BuildData<br>
 ┃ ┃ ┣ 📂BuildCatalog<br>
 ┃ ┃ ┃ ┣ 📜BuildCatalog.asset<br>
 ┃ ┃ ┃ ┣ 📜BuildCatalog.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜BuildCatalog.cs<br>
 ┃ ┃ ┃ ┗ 📜BuildCatalog.cs.meta<br>
 ┃ ┃ ┣ 📜BuildCatalog.meta<br>
 ┃ ┃ ┣ 📜BuildData.cs<br>
 ┃ ┃ ┣ 📜BuildData.cs.meta<br>
 ┃ ┃ ┣ 📜BuildData_CampFire.asset<br>
 ┃ ┃ ┣ 📜BuildData_CampFire.asset.meta<br>
 ┃ ┃ ┣ 📜BuildData_Fence.asset<br>
 ┃ ┃ ┣ 📜BuildData_Fence.asset.meta<br>
 ┃ ┃ ┣ 📜BuildData_Rock.asset<br>
 ┃ ┃ ┣ 📜BuildData_Rock.asset.meta<br>
 ┃ ┃ ┣ 📜BuildData_Tent.asset<br>
 ┃ ┃ ┗ 📜BuildData_Tent.asset.meta<br>
 ┃ ┣ 📂CraftData<br>
 ┃ ┃ ┣ 📜CraftData.cs<br>
 ┃ ┃ ┣ 📜CraftData.cs.meta<br>
 ┃ ┃ ┣ 📜Craft_StoneAxe.asset<br>
 ┃ ┃ ┣ 📜Craft_StoneAxe.asset.meta<br>
 ┃ ┃ ┣ 📜Craft_Torch.asset<br>
 ┃ ┃ ┣ 📜Craft_Torch.asset.meta<br>
 ┃ ┃ ┣ 📜Craft_WoodenAxe.asset<br>
 ┃ ┃ ┗ 📜Craft_WoodenAxe.asset.meta<br>
 ┃ ┣ 📂DropData<br>
 ┃ ┃ ┣ 📂GatherableObject<br>
 ┃ ┃ ┃ ┣ 📜Drop_Branch.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Branch.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Flint.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Flint.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Stick.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Stick.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Stone.asset<br>
 ┃ ┃ ┃ ┗ 📜Drop_Stone.asset.meta<br>
 ┃ ┃ ┣ 📂SupplyCrate<br>
 ┃ ┃ ┃ ┣ 📜Drop_Apple.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Apple.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Bat.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Bat.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_FirstAid.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_FirstAid.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Machete.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Machete.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_Meat.asset<br>
 ┃ ┃ ┃ ┣ 📜Drop_Meat.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Drop_PlasticBottle.asset<br>
 ┃ ┃ ┃ ┗ 📜Drop_PlasticBottle.asset.meta<br>
 ┃ ┃ ┣ 📜DropData.cs<br>
 ┃ ┃ ┣ 📜DropData.cs.meta<br>
 ┃ ┃ ┣ 📜GatherableObject.meta<br>
 ┃ ┃ ┗ 📜SupplyCrate.meta<br>
 ┃ ┣ 📂Enemy<br>
 ┃ ┃ ┣ 📂Data<br>
 ┃ ┃ ┃ ┣ 📜SkeletonMage.asset<br>
 ┃ ┃ ┃ ┣ 📜SkeletonMage.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜SkeletonMinion.asset<br>
 ┃ ┃ ┃ ┗ 📜SkeletonMinion.asset.meta<br>
 ┃ ┃ ┣ 📜Data.meta<br>
 ┃ ┃ ┣ 📜EnemyData.cs<br>
 ┃ ┃ ┗ 📜EnemyData.cs.meta<br>
 ┃ ┣ 📂ItemData<br>
 ┃ ┃ ┣ 📂Consumable<br>
 ┃ ┃ ┃ ┣ 📜Consumable_Apple.asset<br>
 ┃ ┃ ┃ ┣ 📜Consumable_Apple.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Consumable_BottledWater.asset<br>
 ┃ ┃ ┃ ┣ 📜Consumable_BottledWater.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Consumable_FirstAid.asset<br>
 ┃ ┃ ┃ ┣ 📜Consumable_FirstAid.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Consumable_Meat.asset<br>
 ┃ ┃ ┃ ┗ 📜Consumable_Meat.asset.meta<br>
 ┃ ┃ ┣ 📂Equipable<br>
 ┃ ┃ ┃ ┣ 📜Tool_StoneAxe.asset<br>
 ┃ ┃ ┃ ┣ 📜Tool_StoneAxe.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Tool_Torch.asset<br>
 ┃ ┃ ┃ ┣ 📜Tool_Torch.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Tool_WoodenAxe.asset<br>
 ┃ ┃ ┃ ┣ 📜Tool_WoodenAxe.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Tool_WoodenClub.asset<br>
 ┃ ┃ ┃ ┣ 📜Tool_WoodenClub.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Weapon_Bat.asset<br>
 ┃ ┃ ┃ ┣ 📜Weapon_Bat.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Weapon_Machete.asset<br>
 ┃ ┃ ┃ ┗ 📜Weapon_Machete.asset.meta<br>
 ┃ ┃ ┣ 📂Resource<br>
 ┃ ┃ ┃ ┣ 📜Resource_Branch.asset<br>
 ┃ ┃ ┃ ┣ 📜Resource_Branch.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Resource_Flint.asset<br>
 ┃ ┃ ┃ ┣ 📜Resource_Flint.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Resource_Stick.asset<br>
 ┃ ┃ ┃ ┣ 📜Resource_Stick.asset.meta<br>
 ┃ ┃ ┃ ┣ 📜Resource_Stone.asset<br>
 ┃ ┃ ┃ ┗ 📜Resource_Stone.asset.meta<br>
 ┃ ┃ ┣ 📜Consumable.meta<br>
 ┃ ┃ ┣ 📜Equipable.meta<br>
 ┃ ┃ ┣ 📜ItemData.cs<br>
 ┃ ┃ ┣ 📜ItemData.cs.meta<br>
 ┃ ┃ ┗ 📜Resource.meta<br>
 ┃ ┣ 📜BuildData.meta<br>
 ┃ ┣ 📜CraftData.meta<br>
 ┃ ┣ 📜DropData.meta<br>
 ┃ ┣ 📜Enemy.meta<br>
 ┃ ┗ 📜ItemData.meta<br>
 ┣ 📜01_Scenes.meta<br>
 ┣ 📜02_Scripts.meta<br>
 ┣ 📜03_Prefabs.meta<br>
 ┣ 📜04_Animations.meta<br>
 ┣ 📜05_Data.meta<br>
 ┣ 📜Plugins.meta<br>
 ┣ 📜Resources.meta<br>
 ┗ 📜TextMesh Pro.meta<br>
