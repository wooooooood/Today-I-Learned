디폴트로 제공되는 못생긴 파일 첨부를 커스텀하게 바꾸고 싶을때.

### HTML
- https://helloinyong.tistory.com/275
```html
<!DOCTYPE html>
<html>
<head>
	<title>Parcel Sandbox</title>
	<meta charset="UTF-8" />
	<style>
	.input-file-button{
		padding: 6px 25px;
		background-color:#FF6600;
		border-radius: 4px;
		color: white;
		cursor: pointer;
	}
	</style>
</head>

<body>
	<label class="input-file-button" for="input-file">업로드</label>
	<input type="file" id="input-file" style="display:none"/>
</body>
</html>
```

### React+TS+Tailwind
- 파일 업로드하고, 업로드한 파일 이름을 박스안에 보여준다
- 기존 html의 `for`은 react에서 `labelFor`
```tsx
const InputFileBox = () => {
  const [uploadName, setUpLoadName] = useState("파일을 선택하세요..");
  const onInputFileChange = ({ target }) => setUpLoadName(target.files[0].name);
  
  return (
    <Wrapper>
      <input id="upload-name" value={uploadName} disabled />
      <label htmlFor="upload-hidden" id="upload-file">
        파일 선택
      </label>
      <input
        type="file"
        id="upload-hidden"
        className="hidden"
        onChange={onInputFileChange}
        accept="docx"
      />
    </Wrapper>
  );
};

const Wrapper = styled.div`
  #upload-file {
    display: inline-block;
    padding: 0.5em 0.75em;
    color: #ffffff;
    background-color: gray;
    cursor: pointer;
    border-radius: 0.25em;
  }
  #upload-name {
    display: inline-block;
    padding: 0.5em 0.75em;
    color: black;
    background-color: white;
    border-radius: 0.25em;
    appearance: none;
    border: none;
  }
`;
```
