# Scroll table body `tbody` only
> https://stackoverflow.com/questions/23989463/how-to-set-tbody-height-with-overflow-scroll/23989771

- `tbody`의 height를 고정시켜야 한다
- `width` 100% 주지 않으면 `tbody`가 찌그러져서 나온다

```css
tbody {
  display:block;
  height:100px;
  overflow:auto;
}
thead, tbody tr {
  display:table;
  width:100%;
  table-layout:fixed;
}
```
