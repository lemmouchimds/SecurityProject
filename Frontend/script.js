$(".Decalage").hide();
$(".DecalageSolution").hide();
$(".Affine").hide();
$(".Caesar").hide();

$(".Decalage2").hide();
$(".DecalageSolution2").hide();
$(".Affine2").hide();
$(".Caesar2").hide();

function send(message)
{
    let type = $(".encryption-type").val();
    if(type == "Mirroir")
    {
        $.get("http://localhost:5003/mirroir", {message: message}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Caesar")
    {
        let key = $("#shift").val();
        console.log(key);
        $.get("http://localhost:5003/caesar", {message: message, shift: key}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Affine")
    {
        let a = $("#number1").val();
        let b = $("#number2").val();
        console.log(a, b);
        $.get("http://localhost:5003/affine", {message: message, a: a, b: b}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Decalage")
    {
        let key = $("#position").val() == "gauche" ? true : false;
        console.log(key);
        $.get("http://localhost:5003/decalage", {message: message, gauche: key}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
}
function send2(message)
{
    let type = $(".encryption-type2").val();
    if(type == "Mirroir2")
    {
        $.get("http://localhost:5003/mirroir", {message: message}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Caesar2")
    {
        let key = $("#shift2").val();
        console.log(key);
        $.get("http://localhost:5003/caesar", {message: message, shift: key}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Affine2")
    {
        let a = $("#number21").val();
        let b = $("#number22").val();
        console.log(a, b);
        $.get("http://localhost:5003/affine", {message: message, a: a, b: b}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
    else if(type == "Decalage2")
    {
        let key = $("#position2").val() == "gauche2" ? true : false;
        console.log(key);
        $.get("http://localhost:5003/decalage", {message: message, gauche: key}, function(data) {
            $("#chiffre").html(data.code);
        })
    }
}

$(".send-button").click(function() {
    send($(".message-clair").val());
})

$(".send-button2").click(function() {
    send2($(".message-clair2").val());
})


$(".encryption-type").change(function() {
    let type = $(".encryption-type").val();
    if(type == "Decalage")
    {
        $(".Decalage").show();
        $(".DecalageSolution").show();
        $(".Affine").hide();
        $(".Caesar").hide();
    }
    else if(type == "Affine")
    {
        $(".Decalage").hide();
        $(".DecalageSolution").hide();
        $(".Affine").show();
        $(".Caesar").hide();
    }
    else if(type == "Caesar")
    {
        $(".Decalage").hide();
        $(".DecalageSolution").hide();
        $(".Affine").hide();
        $(".Caesar").show();
    }
    else
    {
        $(".Decalage").hide();
        $(".DecalageSolution").hide();
        $(".Affine").hide();
        $(".Caesar").hide();
    }
})
$(".encryption-type2").change(function() {
    let type = $(".encryption-type2").val();
    if(type == "Decalage2")
    {
        $(".Decalage2").show();
        $(".DecalageSolution2").show();
        $(".Affine2").hide();
        $(".Caesar2").hide();
    }
    else if(type == "Affine2")
    {
        $(".Decalage2").hide();
        $(".DecalageSolution2").hide();
        $(".Affine2").show();
        $(".Caesar2").hide();
    }
    else if(type == "Caesar2")
    {
        $(".Decalage2").hide();
        $(".DecalageSolution2").hide();
        $(".Affine2").hide();
        $(".Caesar2").show();
    }
    else
    {
        $(".Decalage2").hide();
        $(".DecalageSolution2").hide();
        $(".Affine2").hide();
        $(".Caesar2").hide();
    }
})
