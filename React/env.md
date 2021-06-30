- https://stackoverflow.com/questions/49579028/adding-an-env-file-to-react-project
- https://create-react-app.dev/docs/adding-custom-environment-variables/

### .env
- CRA 사용한 경우 따로 패키지 설치 필요 X
- root dir에 `.env`라는 이름의 파일 생성
- 반드시 `REACT_APP_`으로 시작하는 Key를 만들어서 상수 저장 (api key 등등)
- react 빌드시 .env를 생성/읽어오기 때문에 .env 내용 수정할때마다 `npm run start` / `yarn start` 다시 해줘야함

실제로 사용할 때:
```html
# public/index.html
<title>%REACT_APP_WEBSITE_NAME%</title>

# etc code
<input type="hidden" defaultValue={process.env.REACT_APP_NOT_SECRET_CODE} />
```
