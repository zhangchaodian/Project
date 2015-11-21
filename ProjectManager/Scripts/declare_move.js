// 项目申报基本dom操作
function declare_dom () {

}
declare_dom.prototype={
	constructor: declare_dom,
	init: function(){
		$("#member_add").click(function(){
			var new_member = "<div class=\"row\" style=\"margin-top: 20px;display: none\" ><div class=\"col-md-4 col-sm-5 col-xs-6\"><input type=\"text\" class=\"form-control\" id=\"lastname\" placeholder=\"负责人\"></div><div class=\"col-md-8 col-sm-7 col-xs-6\"><button type=\"button\" class=\"btn btn-danger member_sub\" style=\"float: right\"><span class=\"glyphicon glyphicon-minus\" aria-hidden=\"true\"></span></button></div></div>";            
            $("#allmember_container").append(new_member);
            $("#allmember_container > div").last().slideDown("fast");
               
		});
// 这里是个知识点，js或者jq 对上面动态加载的节点再进行操作，对父容器再进行监听，然后再实现操作
		$("#allmember_container").on("click",'.member_sub',function () {
			$(this).parent().parent().slideUp("fast",function(){
				$(this).remove();
			});
		});


// 下面按照上面两个成员dom操作  对进度时间规划的任务也类似这样操作
		$("#task_add").click(function(){
			var new_task = "<div class=\"row\" style=\"display: none;margin-top: 15px\"><label for=\"lastname\" class=\"col-sm-2 col-md-2 col-xs-12 control-label\">阶段任务</label><div class=\"col-md-2 col-sm-2 col-xs-3\"><input type=\"text\" class=\"form-control\" id=\"lastname\" placeholder=\"起始时间\"></div><div class=\"col-md-2 col-sm-2 col-xs-3\"><input type=\"text\" class=\"form-control\" id=\"lastname\" placeholder=\"结束时间\"></div><div class=\"col-md-4 col-sm-4 col-xs-4\"><input type=\"text\" class=\"form-control\" id=\"lastname\" placeholder=\"需完成任务\"></div><div class=\"col-md-2 col-sm-2 col-xs-2\"><button type=\"button\" class=\"btn btn-danger task_sub\"style=\"float: right\"><span class=\"glyphicon glyphicon-minus\" aria-hidden=\"true\"></span></button></div></div>";
			$("#all_tasks_container").append(new_task);
			$("#all_tasks_container > div").last().slideDown("fast");
		});
		$("#all_tasks_container").on("click",".task_sub",function(){
			$(this).parent().parent().slideUp("fast",function(){
				$(this).remove();
			});
		});	


// 下面是对三个步骤的表单进行切换操作
        $("#first_next_button").click(function(){
        	$("#form_container_first").fadeOut("normal",function(){
        		$("#form_container_second").slideDown("fast");
        	});
        });
        $("#second_next_button").click(function(){
        	$("#form_container_second").fadeOut("normal",function(){
        		$("#form_container_third").slideDown("fast");
        	});
        });
        $("#second_prev_button").click(function(){
        	$("#form_container_second").fadeOut("normal",function(){
        		$("#form_container_first").slideDown("fast");
        	});
        });
        $("#third_prev_button").click(function(){
        	$("#form_container_third").fadeOut("normal",function(){
        		$("#form_container_second").slideDown("fast");
        	});
        });



	}
}


var declare_dom = new declare_dom();
declare_dom.init();