# Prettier setup in Window VSCode

### 1. 설치

![](https://s3.us-west-2.amazonaws.com/secure.notion-static.com/42a11dd9-3339-41dd-aade-478f1cdc2cb0/Untitled.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210531%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210531T094134Z&X-Amz-Expires=86400&X-Amz-Signature=b19b277a90a89342de87f16731d33c6e5c5792bf5db8c31b9af2a6aedb601e9b&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%22Untitled.png%22)

### 2. `Ctrl+Shift+P` 로 Configuration file 생성하거나 직접 생성

![](https://s3.us-west-2.amazonaws.com/secure.notion-static.com/cb420b87-9e87-4e9b-9ee6-43870ed5d4a3/Untitled.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210531%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210531T094226Z&X-Amz-Expires=86400&X-Amz-Signature=6a5f7eaad41e9c11c7789dd6a408d66d4184187e45bfc3b5b2b2067fa4778311&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%22Untitled.png%22)

- .prettierrc.js
```js
module.exports = {
  trailingComma: 'all',
  tabWidth: 2,
  semi: true,
  singleQuote: true,
};
```

### 3. Settings `Ctrl + ,`

저장할 때마다 자동으로 포맷팅 설정

![](https://s3.us-west-2.amazonaws.com/secure.notion-static.com/19a40d90-5a09-426c-80f3-9c5e7347010b/Untitled.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210531%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210531T094235Z&X-Amz-Expires=86400&X-Amz-Signature=c074ae2e5088be0b4dce99cdc7bd0243e847acdf52a3d642f3420dd10f5787f2&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%22Untitled.png%22)

Default formatter로 Prettier을 설정

![](https://s3.us-west-2.amazonaws.com/secure.notion-static.com/58925eb2-a9b9-4129-9a24-78907aba04f7/Untitled.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210531%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210531T094245Z&X-Amz-Expires=86400&X-Amz-Signature=521b365c52a62790fc9de2e71ff3d692e6d4c0893d6520e94de8105b8fcc1548&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%22Untitled.png%22)
