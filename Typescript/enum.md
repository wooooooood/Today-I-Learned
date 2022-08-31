# use enum description
- [ref](https://stackoverflow.com/a/61062698/4894523)
```ts
export enum Sample {
  I = 1,
  II = 2,
  III = 3
}

export const SampleLabel: { [key in Sample]: string } = {
  [Sample.I]: "ONE",
  [Sample.II]: "TWO",
  [Sample.III]: "THREE",
};
```