//第一个查询的ajax提交表单
$(function () {
    $("#btn1").click(function () {
        // alert("aaaa");
        $.ajax({
            url: "/UserManager/GetSearch",
            type: "post",
            data: $('#form1').serialize(),
            dataType: "json",
            success: function (response) {
                // $("#Id").text(response.Id);
                // $("#Name").text(response.Name);
                // $("#Age").text(response.Age);
                $("#b1").empty();
                $("#b1").html(response);
            },


        });
        return false;
    });
});

$(function(){
    $("#btn2").click(function(){

        $.ajax({
            url:"/UserManager/GetSearch2",
            type:"post",
            data:$("#form2").serialize(),
            dataType:"json",
            success:function(response){
             $("#b1").empty();
             $("#b1").html(response);
            },
            error:function(){
                 //$("#b1").empty();
            }
        });
        return false;
    });
});