$(document).ready(function(){
$(function() {
	$("#put_help").click(function() {
		$(".tab2").hide();
		$(".tab1").toggle("slow");
	})
})
	function prizes() {
		layer.prompt(function (val) {
			layer.msg('得到了' + val);
		});
	}

$(function() {
	$("#get_help").click(function() {
		$(".tab2").toggle("slow");
		$(".tab1").hide();
	})
})

})