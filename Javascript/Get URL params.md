```js
let url = "http://127.0.0.1/search/?sch_keyword=홍길동&type=1"

const sch = location.search;  //?sch_keyword=홍길동&type=1
const params = new URLSearchParams(sch);
const sch_keyword = params.get('sch_keyword');  //홍길동

params.set('sch_keyword', '임꺽정');  //set할수도 있음
```
ref: https://fun25.co.kr/blog/javascript-url-query-parameter-reading-updating-urlsearchparams/?page=4
