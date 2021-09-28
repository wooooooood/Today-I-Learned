1. CRA
- yarn create react-app 프로젝트이름
- yarn create react-app my-app --template redux
- npx create-react-app 프로젝트이름 --template typescript
- yarn create react-app 프로젝트이름 --template redux-typescript

2. CSS
- yarn add styled-components
- yarn add tailwindcss
- npx sb init

3. Prettier
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
- yarn add webpack webpack-cli webpack-dev-server --dev
- yarn add clean-webpack-plugin css-loader file-loader html-webpack-plugin mini-css-extract-plugin style-loader url-loader --dev
webpack.config.js
```
const webpack = require("webpack");
const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
module.exports = (env) => {
  return {
    mode: env === "development" ? "development" : "production",
    entry: {
      main: "./src/index.tsx",
    },
    output: {
      filename: "[name].js",
      path: path.resolve("./build"),
    },
    plugins: [
      new HtmlWebpackPlugin({
        template: "./public/index.html",
        filename: "index.html",
        favicon: "./public/favicon.ico",
      }),
    ],
    module: {
      rules: [
        {
          test: /\.css$/,
          use: ["style-loader", "css-loader"],
        },
        {
          test: /\.tsx?$/,
          loader: "ts-loader",
        },
        {
          test: /\.(png|jpg)$/,
          loader: "file-loader",
          options: {
            publicPath: "./build/",
            name: "[name].[ext]?[hash]",
          },
        },
        {
          test: /\.svg$/,
          use: {
            loader: "url-loader",
            options: {
              publicPath: "./build/",
              name: "[name].[ext]?[hash]",
              limit: 5000, // 5kb 미만 파일만 data url로 처리
            },
          },
        },
      ],
    },
    devServer: {
      host: "localhost",
      port: 8080,
      https: true,
      overlay: true,
      stats: "errors-only",
      open: true,
      historyApiFallback: true,
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
    "noEmit": false,
    "jsx": "react-jsx",
    "paths": {
      "@stories/*": ["./src/stories/*"],
    }
  },
  "include": ["src"]
}
```
