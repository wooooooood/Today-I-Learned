[화학식](https://ko.wikipedia.org/wiki/%EC%9D%B4%EC%82%B0%ED%99%94_%ED%83%84%EC%86%8C)같은걸 작성할때 CO2가 아닌 CO+작은2를 작성해야 하는 경우가 생겼다.

이때 작게 표시되는 내용 = [아래 첨자](https://en.wikipedia.org/wiki/Subscript_and_superscript)를 영어로는 `subscript`라고 하며, 반대로 위 첨자는 `superscript`라고 한다.

[이 글](https://stackoverflow.com/questions/13683245/applying-superscipt-subscript-tag-using-javascript-jquery)을 보니 `<sub>` 태그로도 subscript를 표현할 수 있는것같았으나, 내 경우에는 `<option>` 태그 내에서 subscript를 표현해야 했고,

**`<option>`태그는 하위 돔을 가질 수 없다**

삽질 끝에 `"CO\u2082"`와 같이 입력했다. 유니코드는 [여기](https://www.fileformat.info/info/unicode/char/search.htm)에서 검색할 수 있다.


