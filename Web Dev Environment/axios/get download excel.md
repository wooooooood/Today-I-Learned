## `Axios`에서 (엑셀) 파일 다운로드
```js
downCsList(){                
    axios({
        method: 'GET',
        url: 'http://localhost:9099/list/testDownload',                 
        responseType: 'blob' // 가장 중요함
    })    
    .then(response =>{        
        const url = window.URL.createObjectURL(new Blob([response.data], { type: response.headers['content-type'] }));
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', 'test.xlsx');
        document.body.appendChild(link);
        link.click();
    })                                
}
```

### 만약 서버에서 설정한 이름을 쓰고싶다면
- 한글이 포함되어있어서 UTF8로 넘어올땐 `decodeURI(fileName)`를 사용
```js
const url = window.URL.createObjectURL(new Blob([response.data], { type: response.headers["content-type"] }));
const link = document.createElement("a");
const contentDisposition = response.headers["content-disposition"];
let fileName = "download.xlsx";
if (contentDisposition) {
    const [fileNameMatch] = contentDisposition.split(";").filter((str) => str.includes("filename"));
    if (fileNameMatch) [, fileName] = fileNameMatch.split("=");
}

link.href = url;
link.setAttribute("download", decodeURI(fileName));
document.body.appendChild(link);
link.click();
```

ref
- https://soonh.tistory.com/38