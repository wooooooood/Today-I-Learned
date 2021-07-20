### Loop over properties of a class
```cs
var prop = MyClass.GetType().GetProperties(); 
foreach (var props in prop)
{
  var variable = props.GetMethod;
}
```
- https://stackoverflow.com/questions/4276566/how-can-you-loop-over-the-properties-of-a-class

### Loop over enum values
```cs
foreach(var foo in Enum.GetValues(typeof(MyEnum)))
{
  //do sth..
}
```
