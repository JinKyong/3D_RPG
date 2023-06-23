# 말머리
1. 가독성을 최우선으로 삼는다.
2. 정말 합당한 이유가 있지 않는 한, 통합개발환경(IDE)의 자동 서식을 따른다. (비주얼 스튜디오의 "Ctrl + K + D" 기능)
---

# I. 메인 코딩 표준
<details>
  <summary>펼치기</summary>

  1. 클래스와 구조체의 이름은 파스칼 표기법을 따른다.
  ``` C++
  class CardManager;
  struct CardData;
  ```


  2. 지역 변수 그리고 함수의 매개 변수의 이름은 카멜 표기법을 따른다.
  ``` C#
  public void SomeMethod(int someParameter)
  {
      int someNumber;
      int id;
  }
  ```


  3. 메서드 이름은 기본적으로 동사(명령형)+명사(목적어)의 형태로 짓는다.
  ``` C#
  public int GetAge()
  {
      // 함수 구현부...
  }
  ```


  4. 단, 단순히 부울(boolean) 상태를 반환하는 메서드의 동사 부분은 최대한 Is, Can, Has, Should를 사용하되 그러는 것이 부자연스러울 경우에는 상태를 나타내는 다른 3인칭 단수형 동사를 사용한다.
  ``` C#
  public bool IsActvie(Card card);
  public bool HasChild(Card card);
  public bool CanUse(Card card);
  public bool ShouldDelete(Card card);
  public bool Exists(Card card);
  ```


  5. 제시된 예를 제외하곤 모든 메서드의 이름은 파스칼 표기법을 따른다.
  ``` C#
  public uint GetAge()
  {
      // 함수 구현부...
  }
  ```


  6. public 메서드가 아닌 경우 카멜 표기법을 따른다.
  ``` C#
  private uint getAge()
  {
      // 함수 구현부...
  }
  ```


  7. 상수의 이름은 모두 대문자로 하되 밑줄로 각 단어를 분리한다.
  ``` C#
  const int SOME_CONSTANT = 1;
  ```


  8. 상수로 사용하는 개체형 변수에는 static readonly를 사용한다.
  ``` C#
  public static readonly MyConstClass MY_CONST_OBJECT = new MyConstClass();
  ```


  9. static readonly 변수는 모두 대문자로 하되 밑줄로 각 단어를 분리한다.
  10. 초기화 후 값이 변하지 않는 변수는 readonly로 선언한다.
  ``` C#
  public class Account
  {
      private readonly string mPassword;

      public Account(string password)
      {
          mPassword = password;
      }
  }
  ```


  11. 네임스페이스의 이름은 파스칼 표기법을 따른다.
  ``` C#
  namespace System.Graphics
  ```


  12. 부울(boolean) 변수는 앞에 b를 붙인다.
  ``` C#
  bool bFired;                // 지역변수
  ```


  13. 부울 프로퍼티는 앞에 Is, Has, Can, Should 중에 하나를 붙인다.
  ``` C#
  public bool IsFired { get; private set; }
  public bool HasChild { get; private set; }
  public bool CanModal { get; private set; }
  public bool ShouldRedirect { get; private set; }
  ```


  14. 인터페이스를 선언할 때는 앞에 I를 붙인다.
  ``` C#
  interface ISomeInterface;
  ```


  15. 열거형을 선언할 때는 앞에 E를 붙인다
  ``` C#
  public enum EDirection
  {
      North,
      South
  }
  ```


  16. 구조체를 선언할 때는 앞에 S를 붙인다. 단, readonly struct일 때는 그렇지 아니한다
  ``` C#
  public struct SUserID;
  ```


  17. 값을 반환하는 함수의 이름은 무엇을 반환하는지 알 수 있게 짓는다.
  ``` C#
  public uint GetAge();
  ```


  18. 단순히 반복문에 사용되는 변수가 아닌 경우엔 i, e 같은 변수명 대신 index, employee 처럼 변수에 저장되는 데이터를 한 눈에 알아볼 수 있는 변수명을 사용한다.
  19. 뒤에 추가적인 단어가 오지 않는 경우 줄임말은 모두 대문자로 표기한다.
  ``` C#
  public int OrderID { get; private set; }
  public int HttpCode { get; private set; }
  ```


  20. getter와 setter 대신 프로퍼티를 사용한다.

  > 틀린 방식:
  ``` C#
  public class Employee
  {
      private string mName;
      public string GetName();
      public string SetName(string name);
  }
  ```

  > 올바른 방식:
  ``` C#
  public class Employee
  {
      public string Name { get; set; }
  }
  ```


  21. 지역 변수를 선언할 때는 그 지역 변수를 사용하는 코드와 동일한 줄에 선언하는 것을 원칙으로 한다.
  22. double이 반드시 필요한 경우가 아닌 이상 부동 소수점 값에 f를 붙여준다
  ``` C#
  float f = 0.5F;
  ```


  23. switch 문에 언제나 default: 케이스를 넣는다.
  ``` C#
  switch (number)
  {
      case 0:
          ... 
          break;
      default:
          break;
  }
  ```


  24. switch 문에서 default: 케이스가 절대 실행될 일이 없는 경우, default: 안에 Debug.Fail() 또는 Debug.Assert(false) 란 코드를 추가한다.
  ``` C#
  switch (type)
  {
      case 1:
          ... 
          break;
      default:
          Debug.Fail("unknown type");
          break;
  }
  ```


  25. 재귀 함수는 이름 뒤에 Recursive를 붙인다.
  ``` C#
  public void FibonacciRecursive();
  ```


  26. 매개변수 자료형이 범용적인 경우, 함수 오버로딩을 피한다.
  > 틀린 방식:
  ``` C#
  public Anim GetAnim(int index);
  public Anim GetAnim(string name);
  ```

  > 올바른 방식:
  ``` C#
  public Anim GetAnimByIndex(int index);
  public Anim GetAnimByName(string name);
  ```
  
  
  27. 여러 파일이 하나의 클래스를 이룰 때(즉, partial 클래스), 파일 이름은 클래스 이름으로 시작하고, 그 뒤에 마침표와 세부 항목 이름을 붙인다.
  ``` C#
  public partial class Human;
  ```
  ``` C#
  Human.Head.cs
  Human.Body.cs
  Human.Arm.cs
  ```
  
  
  28. 비트 플래그 열거형은 이름 뒤에 Flags를 붙인다.
  ``` C#
  [Flags]
  public enum EVisibilityFlags
  {
    None = 0,
    Character = 1 << 0,
    Terrain = 1 << 1,
    Building = 1 << 2,
  }
  ```
  
  
  29. 디폴트 매개 변수 대신 함수 오버로딩을 선호한다.
  30. 디폴트 매개 변수를 사용하는 경우, null이나 false, 0 같이 비트 패턴이 0인 값을 사용한다.
  
  </details>
  
  
  
  # II. 소스 코드 포맷팅
<details>
  <summary>펼치기</summary>

  1. 중괄호( { )를 열 때는 언제나 새로운 줄에 연다.
  2. 중괄호 안( { } )에 코드가 한 줄만 있더라도 반드시 중괄호를 사용한다.
  ``` C#
  if (bSomething)
  {
    return;
  }
  ```
  
  
  3. 한 줄에 변수 하나만 선언한다.
  > 틀린 방식:
  ``` C#
  int counter = 0, index = 0;
  ```
  
  > 올바른 방식:
  ``` C#
  int counter = 0;
  int index = 0;
  ```
  
  
  4. 한 개의 명령문(;)이 길어지면 줄바꿈 
  
  </details>
