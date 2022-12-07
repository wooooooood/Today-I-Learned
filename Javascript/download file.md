### 버튼 눌러서 파일 다운로드하기
- [ref](https://www.geeksforgeeks.org/how-to-download-pdf-file-in-reactjs/)
```js
fetch('path_to_SamplePDF.pdf').then(response => {
  response.blob().then(blob => {
    // Creating new object of PDF file
    const fileURL = window.URL.createObjectURL(blob);
    // Setting various property values
    let alink = document.createElement('a');
    alink.href = fileURL;
    alink.download = 'SamplePDF.pdf';
    alink.click();
  })
})
```
