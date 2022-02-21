export function IsImage(fileName: string) {
  //filename이 유효하다고 가정
  return fileName.match(/.(jpg|jpeg|png|gif)$/i);
}
