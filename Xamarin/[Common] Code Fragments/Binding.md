# Binding
## 1. Binding programatically
**.xaml**에서는 이렇게 썼다.
```xml
<Label x:Name="myLabel" Text="{Binding myLabelText}" />
```
위 코드를 **.xaml.cs**에서는 이렇게 쓴다.
```cs
myLabel.SetBinding(Label.TextProperty, "myLabelText");
```

## 2. Binding Dictionary as Listview item
- 어떤식으로 쓰는지?
```cs
public Dictionary<int, string> myDictionary { get; set; }
```

```xml
<ListView x:Name="MyListView"
          HasUnevenRows="True"
          SelectionMode="None"
          ItemsSource="{Binding myDictionary}"
          ItemTapped="MyListView_ItemTapped">
    <ListView.ItemTemplate>
        <DataTemplate>
            <TextCell Text="{Binding Value}"/>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```
