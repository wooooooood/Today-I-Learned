- `container`: 스크롤할 영역을 담은 공간
- `scrollbar-thumb`: 스크롤바
- `scrollbar-track`: 스크롤 외 배경
```css
.container::-webkit-scrollbar {
  width: 10px;
}
.container::-webkit-scrollbar-thumb {
  background-color: black;
  border-radius: 5px;
}
.container::-webkit-scrollbar-track {
  background-color: gray;
  border-radius: 10px;
}
```

+) `styled-component` 쓰면
```jsx
const Style = styled.div`
  &::-webkit-scrollbar {
    width: 10px;
  }
  &::-webkit-scrollbar-thumb {
    background-color: black;
    border-radius: 5px;
  }
  &::-webkit-scrollbar-track {
    background-color: gray;
    border-radius: 10px;
  }
`
```
