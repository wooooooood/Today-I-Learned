`webpack.config.js` 파일에 들어가는 것

### 경로 줄여서 나타내기 : resolve alias
기존 `import '../../src/app/page/'` => `import '@app/page/'`로 줄일 수 있다.
```js
const path = require("path");
module.exports = (env) => {
  return {
    resolve: {
      extensions: [".js", ".jsx", ".ts", ".tsx"],
      alias: {
        "@resources": path.resolve(__dirname, "./src/resources"),
        "@utils": path.resolve(__dirname, "./src/utils"),
        "@pages": path.resolve(__dirname, "../src/pages"),
      },
    },
  };
};
```
