# 3D_Standard

## 6주차 정리

<details>
<summary> 퀴즈 및 생각해보기 </summary>
 
## Q1


1) (X)

앵커 : UI 객체가 고정될 위치 지정 - 부모 기준으로 위치와 크기 조정

피벗 : UI 객체 기준점 - UI 자체의 회전이나 크기 조정

2) (X)

화면상의 위치는 앵커에 의해 결정된다.

3) (O) -> 1)의 피벗 설명 보기


## 생각해보기

1) 

특정 영역에 꽉 차는 구성이라면 Anchor의 min x, y 값이 0이고 max x,y값이 1이다.<br> 
특정 크기로 등장하는 UI의 경우 그 영역에 맞춰서 조정해야 한다.

2)

돌아다니는 몬스터의 HP바의 경우 WorldSpace


고정된 플레이어의 HP바는 overlay


### WolrdSpace 


씬에 있는 다른 오브젝트처럼 동작.


캔버스의 크기는 사각 트랜스폼을 사용하여 수동으로 설정할 수 있으며


UI 요소는 3D 배치에 기반하여 씬의 다른 오브젝트의 앞 또는 뒤에 렌더링


### ScreenSpace - Overlay 



UI 요소가 화면에서 씬의 위에 렌더링


스크린의 크기가 조절되거나 해상도가 변경되면


캔버스는 여기에 맞춰 자동으로 크기를 변경<br>


블로그에 정리 한 적 있음


https://rootdev.tistory.com/40


## Q2. 

1) (O)

코루틴은 비동기

2) (O)

yield return new WaitForSeconds(1); 은 1초 대기


3) (X)

IEnumerator 반환


## 생각해 보기 

1) 
코루틴을 캐싱한 후 null이 아니라면(이전 코루틴이 실행 중) 
StopCoroutin을 통해 중단하고 새로운 코루틴을 시작시킨다.


2) 
게임 오브젝트에 종속되고 있으므로 
게임 오브젝트 파괴(혹은 비활성화) 시 코루틴이 멈춤 - 지난 심화 개인과제에서 겪음

해결한 방법으로 싱글톤을 활용하여 코루틴을 관리하는 매니저를 만들어서 처리했음. 


## Q3 

1) (O)


2) (O)


3) (O)


4) (X)
단일 상속만 가능 - 다중상속을 원한다면 인터페이스 활용


## 생각해 보기
- 코드 중복에 따른 비효율성이 증가할 수 있다.
- 다른 곳에서 참조할 때 헷갈릴 가능성 존재 = 실수할 가능성 증가

</details>


