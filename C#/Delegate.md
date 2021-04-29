사용 시나리오: A Class 내부에서 모든 Data가 초기화되면 B Class의 DoWork()를 실행시키고 싶다. 걍 이어서 하면 안되나 싶지만 `비동기`라 노답인 상황


- A Class
```cs
public delegate void DataInitializedDelegate();
public class A
{
  public event DataInitializedDelegate DataInitializedEvent;

  internal async Task Initialize()
  {
    //can do sth and then..
    DataInitializedEvent?.Invoke();
  }
}
```

- B Class
```cs
public class B
{
  public A MyAClass = new A();
  public B()
  {
      MyAClass.DataInitializedEvent += new DataInitializedDelegate(DoWork);
  }

  private void DoWork()
  {
      //will execute when data get initialized in class A
  }
}
```
