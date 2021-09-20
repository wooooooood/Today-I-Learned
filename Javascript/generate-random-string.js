function generateRandomString(maxLen, minLen) {
  const length = Math.floor(Math.random() * (maxLen - minLen + 1)) + minLen; //최댓값도 포함, 최솟값도 포함
  const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  const charactersLength = characters.length;
  
  let result = '';
  for ( let i = 0; i < length; i++ ) {
    result += characters.charAt(Math.floor(Math.random() * charactersLength));
  }
  
  return result;
}

//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Math/random
//https://stackoverflow.com/a/1349426
