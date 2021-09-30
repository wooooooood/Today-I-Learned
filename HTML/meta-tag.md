- `<meta>` 태그는 해당 문서에 대한 정보인 메타데이터(metadata)를 정의할 때 사용합니다.
```html
<meta name="subject" content="홈페이지 주제" />
<meta name="author" content="작성자" />
<meta name="title" content="탭에 나타나는 제목" />
<meta name="keywords" content="검색,시,필요한,키워드" />
<meta name="description" content="웹 문서의 설명을 나타냅니다" />
```

# Meta tag OG
- https://velog.io/@byeol4001/Meta-Tag-OG%EC%98%A4%ED%94%88%EA%B7%B8%EB%9E%98%ED%94%84-%EC%82%AC%EC%9A%A9%ED%95%98%EA%B8%B0
- OG: Open Graph
- 컨텐츠 정보가 sns에 게시되는 데 최적화
- 이미지의 경우 최소한 600 x 315 픽셀은 되어야 하며, 1200 x 630 픽셀 크기를 권장
```html
<meta property="og:type" content="website">
<meta property="og:url" content="https://example.com/page.html">
<meta property="og:title" content="Content Title">
<meta property="og:image" content="https://링크전송시.나타나는.이미지.jpg">
<meta property="og:description" content="Description Here">
<meta property="og:site_name" content="Site Name">
<meta property="og:locale" content="en_US">
<--추천-->
<meta property="og:image:width" content="1200">
<meta property="og:image:height" content="630">
```
- 트위터 미리보기
```html
<meta name="twitter:card" content="트위터 카드 타입(요약정보, 사진, 비디오)" /> 
<meta name="twitter:title" content="콘텐츠 제목" /> 
<meta name="twitter:description" content="웹페이지 설명" /> 
<meta name="twitter:image" content="표시되는 이미지 " /> 
```
- 모바일 미리보기
```html
<--iOS-->
<meta property="al:ios:url" content=" ios 앱 URL" />
<meta property="al:ios:app_store_id" content="ios 앱스토어 ID" /> 
<meta property="al:ios:app_name" content="ios 앱 이름" /> 
<--Android-->
<meta property="al:android:url" content="안드로이드 앱 URL" />
<meta property="al:android:app_name" content="안드로이드 앱 이름" />
<meta property="al:android:package" content="안드로이드 패키지 이름" /> 
<meta property="al:web:url" content="안드로이드 앱 URL" />
```
