# 2024 1학기 게임 및 혼합현실 프로젝트 Burgeria VR

0508 TODO

1. Counter라는 Empty Object에 카운터 부분 집어넣기 (inspector 관리하기 편하게) <<< 이거 ㄱㄴ?
2. Move_Guest 스크립트 수정 : 지정된 Vector3 좌표보다는 특정 영역을 트리거링으로 처리 - Guest_Stop 1, 2, 3 << 이건 내가 할 것
3. 주문(수행해야 할 레시피)를 표시하는 공간 Counter 윗쪽에 구현하기
4. Counter 수정 : 조리 구역 - 재료 구역 - 전달 구역
5. 스크립트 설정 : 고기 굽기, 칼로 재료 손질하기 <<< 칼 에셋 무료로 된거 다운로드 하기
6. 스크립트 설정 2 : 손님 객체 생성 시 손님 내부에 Field Member로 레시피를 설정하고, <<< 이 레시피를 3번에서 구현할 공간에 표시함
7. 조리 공간에서 햄버거 조립하고 이걸 집어서 Guest_Stop 공간 앞에 잇는 접시에 충돌하면 이를 비교하여 주문 완성 여부를 결정하기
8. 스크립트 설정 3 : 라이프 표시하는 화면 구현하기
9. 또 추가할 만한 거 있나?

0513 TODO

1. 뭉쳐진 재료 구현하기
-Bacon, Ham, Mushroom, Onion, Salad, Shrimp, Cucumber
(동일한 이름으로 Diner 폴더의 Prefab에 있으므로, Prefab을 복붙해서 새 프리팹으로 만든 후 작업)

2. 칼질하면 치즈, 생선이 토막나는 스크립트 생성하기
   https://assetstore.unity.com/packages/3d/props/weapons/free-modern-combat-knife-178655
   칼 에셋은 이걸 이용
 
