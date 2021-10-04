## CRA

```
yarn create react-app 프로젝트이름
yarn create react-app my-app --template redux
npx create-react-app 프로젝트이름 --template typescript
yarn create react-app 프로젝트이름 --template redux-typescript
```

## CSS

```
yarn add styled-components
yarn add tailwindcss
npx sb init

//if needed
yarn add @types/styled-components -D
```

## Other packages

```
yarn add react-icons axios
```

## Prettier

.prettierrc.js

```
module.exports = {
  trailingComma: 'all',
  tabWidth: 2,
  semi: true,
  singleQuote: true,
};
```

4. Webpack

```
yarn add webpack webpack-cli webpack-dev-server -D
yarn add clean-webpack-plugin css-loader html-webpack-plugin mini-css-extract-plugin style-loader -D
yarn add ts-loader -D
```

webpack.config.js

```js
const webpack = require("webpack");
const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyPlugin = require("copy-webpack-plugin");
const apiMocker = require("connect-api-mocker");
const mode = process.env.NODE_ENV || "development";
module.exports = () => {
  return {
    mode,
    entry: {
      main: "./src/index.tsx",
    },
    output: {
      filename: "[name].js",
      path: path.resolve("./dist"),
      assetModuleFilename: "images/[hash][ext][query]",
    },
    plugins: [
      new webpack.DefinePlugin({}),
      new CopyPlugin({
        patterns: [
          {
            from: "./node_modules/axios/dist/axios.min.js",
            to: "./axios.min.js",
          },
        ],
      }),
      new HtmlWebpackPlugin({
        template: "./public/index.html",
        filename: "index.html",
        minify:
          mode === "production"
            ? {
                collapseWhitespace: true, // 빈칸 제거
                removeComments: true, // 주석 제거
              }
            : false,
      }),
      ...(mode === "production"
        ? [new MiniCssExtractPlugin({ filename: `[name].css` })]
        : []),
    ],
    optimization: {
      minimizer: mode === "production" ? [new OptimizeCSSAssetsPlugin()] : [], //css 빈칸 제거 압축
    },
    module: {
      rules: [
        {
          test: /\.css$/,
          use: [
            mode === "production"
              ? MiniCssExtractPlugin.loader // 프로덕션 환경
              : "style-loader", // 개발 환경
            "css-loader",
          ],
        },
        {
          test: /\.tsx?$/,
          loader: "ts-loader",
        },
        {
          test: /\.(png|jpg)$/,
          type: "asset/resource",
        },
        {
          test: /\.(svg)$/,
          type: "asset/inline",
        },
      ],
    },
    externals: {
      axios: "axios",
    },
    devServer: {
      host: "localhost",
      port: 8080,
      open: true,
      historyApiFallback: true,
      onBeforeSetupMiddleware: (devServer) => {
        devServer.app.use(apiMocker("/api", "mocks/api"));
      },
      proxy: {
        "/api": "http://localhost:8081", // 프록시
      },
    },
    resolve: {
      extensions: [".ts", ".tsx", ".js", ".jsx", ".css", ".scss", ".json"],
      alias: {
        "@stories": path.resolve(__dirname, "./src/stories"),
      },
    },
  };
};
```

tsconfig.json if TS

```
{
  "compilerOptions": {
    "target": "es5",
    "allowJs": true,
    "skipLibCheck": true,
    "esModuleInterop": true,
    "allowSyntheticDefaultImports": true,
    "forceConsistentCasingInFileNames": true,
    "noFallthroughCasesInSwitch": true,
    "module": "esnext",
    "moduleResolution": "node",
    "resolveJsonModule": true,
    "isolatedModules": true,
    "noEmit": false, //https://stackoverflow.com/questions/55002137/typescript-noemit-use-case
    "jsx": "react-jsx",
    "paths": {
      "@stories/*": ["./src/stories/*"],
    }
  },
  "include": ["src"]
}
```

package.json

```json
"start": "webpack serve --progress",
"build": "NODE_ENV=production webpack --progress",
```
