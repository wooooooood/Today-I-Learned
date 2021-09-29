if (navigator.geolocation) {
  navigator.geolocation.getCurrentPosition((position) => {
    console.log(position.coords.latitude);
    console.log(position.coords.longitude);
  }, () => {
    alert("위치 공유가 차단되었습니다. 내 위치를 확인하시려면 위치 접근을 허용해 주세요!");
  });
}
