# Binding Dictionary as Listview item
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
