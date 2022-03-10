- needed since this is csr.. it uses only one html page

ScrollToTop.jsx
```jsx
import { useEffect } from 'react';
import { useLocation } from 'react-router';

const ScrollToTop = (props) => {
  const location = useLocation();
  useEffect(() => {
    window.scrollTo(0, 0);
  }, [location]);

  return <>{props.children}</>;
};

export default ScrollToTop;
```

Router.jsx
```jsx
<ScrollToTop>
  <Routes>
    {[...routes].map((route, key) => (
      <Route key={key} path={route.path} element={route.component} />
    ))}
  </Routes>
</ScrollToTop>
```
