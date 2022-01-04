https://stackoverflow.com/questions/37269736/react-router-how-to-constrain-params-in-route-matching

```js
const NumberRoute = () => <div>Number Route</div>;
<Router>
  <Switch>
    <Route exact path="/foo/:id(\d+)" component={NumberRoute}/>
  </Switch>
</Router>
```
