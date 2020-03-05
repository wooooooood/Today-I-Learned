# Block, Inline
### Block
- div, h, p..
- Default: width 100%, height 0
- 사용 가능한 최대 너비 사용, 크기 지정 가능
- 수직으로 쌓인다 
- margin, padding 상하좌우 사용 가능
- 용도: Layout

<br />

### Inline
- img, span..
- Default: width 0, height 0
- 필요한 만큼의 너비만 사용, 크기 지정 불가
- 수평으로 쌓인다
```html
<span>test</span><span>test</span>    <!--결과: testtest-->

<span>test</span>                     <!--결과: test test-->
<span>test</span>
```
- margin, padding 좌우 사용 가능
- 용도: Text

```css
span {
  display: block; <!-- inline 요소의 block화 -->
}

div {
  display: inline; <!-- block 요소의 inline화 -->
}
```

<br />

###
- *width, height의 Default 값은 **auto**이고 block/inline의 속성에 따라 위와 같이 설정되는 것*
- *Block, Inline 요소의 속성 = CSS **display**의 default 값*

<br />

> fastcampus frontend course 04-01 ~ 04-03
