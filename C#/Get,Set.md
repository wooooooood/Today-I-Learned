# Get, Set

### 1. 
```cs
private int _property;
public int property
{
  get
  {
    return _property;
  }
  set
  {
    _property = value;
  }
}
```

### 2. 
```cs
public int property { get; set; }
```

### 3. Read only
```cs
public int property
{
  get 
  {
    //some operation..
    return result;
  }
}
```
