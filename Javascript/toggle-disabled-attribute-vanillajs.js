function toggle(flag){
  if(flag) {
    document.getElementById('targetElement').setAttribute("disabled", "true");
  } else {
    document.getElementById('targetElement').removeAttribute("disabled");
  }
}
