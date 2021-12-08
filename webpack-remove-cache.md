- https://sudalkim.tistory.com/m/11
`webpack.config.js`
```js
output: {
	path: path.join(__dirname, '/src/'),
	filename: '[name].[chunkhash:8].js',
},
```
