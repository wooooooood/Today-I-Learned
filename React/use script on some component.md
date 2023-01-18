### 어떤 컴포넌트를 열었을 때만 script를 쓰고싶을때였다
- [ref](https://stackoverflow.com/a/34425083/4894523)
```jsx
useEffect(() => {
  const script = document.createElement('script');

  script.src = "https://use.typekit.net/foobar.js";
  script.async = true;

  document.body.appendChild(script);

  return () => {
    document.body.removeChild(script);
  }
}, []);
```