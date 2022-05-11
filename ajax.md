//https://stackoverflow.com/questions/38286812/jquery-ajax-no-error-or-success-fired
- 현상: ASP.NET에 ajax로 요청했는데 요청은 항상 먹히지만 결과 다운로드가 될때도 있었고 안될때도 있었다. 찍어보니 ajax의 success/error 같은 콜백함수에 들어오지를 않았다..
- 해결: stop default form submission
```js
$(document).on("ready", function() {
    $("#contact").on("submit", function(e) {
        e.preventDefault(); //🎉

        $.ajax({
            type: 'POST',
            url: 'email.php',
            data: $(this).serialize(),
            dataType: 'json',
            success: function(response){
                $("#contactButton").text("Thank You");
                $("input").val("");
                $("textarea").val("");
            }, 
            error: function(response){
                alert("Error: Message Not Sent");
            }
        });
    });
});
```
