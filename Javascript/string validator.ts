export function IsNullOrWhiteSpace(str: string) {
  return str === null || str.match(/^ *$/) !== null;
}
