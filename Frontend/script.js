$("")

function send(message)
{
    $(".message-clair").html(message);
    $.get("https://localhost:7018/crypter", {message: message}, function(data) {
        $("#chiffre").html(data.code);
    })
}

$("send-button").click(function() {
    send($("#message").val());        
    
})

$("#encryption-type").change(function() {
    var type = $("#encryption-type").val();
    if(type == "cesar") {
        $("#key").show();
    } else {
        $("#key").hide();
    }
})