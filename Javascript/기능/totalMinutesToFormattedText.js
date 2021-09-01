function totalMinutesToFormattedText(totalMinutes) {
  var hours =
    Math.floor(totalMinutes / 60) === 0
      ? ""
      : `${Math.floor(totalMinutes / 60)}시간`;
  var minutes = totalMinutes % 60 === 0 ? "" : `${totalMinutes % 60}분`;

  return hours ? `${hours} ${minutes}` : minutes;
}
