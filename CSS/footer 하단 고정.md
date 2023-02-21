### 1.
content `min-height: calc(100vh - (헤더높이+푸터높이))`

### 2.
- content flex: 1로 푸터 하단 고정
    - html, body {height: 100%}
    - display: flex; flex-flow: column;
    - content => `flex: 1`