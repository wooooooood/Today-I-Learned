## useEffect cheatsheet
//https://daveceddia.com/useeffect-vs-uselayouteffect/


### once
- similar to `componentDidMount`
- pass empty array
```jsx
useEffect(() => {
 // put 'run once' code here
}, [])
```


### after every render
- similar to `componentDidUpdate`
- no second argument
```jsx
useEffect(() => {
 // put 'every update' code here
})
```

### on unmount
- similar to `componentWillUmount`
- return the cleanup function
```jsx
useEffect(() => {
 return () => {
 // put unmount code here
 }
})
```

### on state change
- similar to `componentDidUpdate`
- include all state vars to watch
```jsx
function YourComponent() {
 const [state, setState] = useState()
 useEffect(() => {
 // code to run when state changes
 }, [state])
}
```

### on props change
- similar to `componentDidUpdate`
- include all monitored props
```jsx
function YourComponent({ someProp }) {
 useEffect(() => {
 // code to run when someProp changes
 }, [someProp]);
}
```
