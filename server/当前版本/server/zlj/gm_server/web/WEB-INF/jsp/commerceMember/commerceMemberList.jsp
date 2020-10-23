<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<title>Insert title here</title>
<script type="text/javascript">
$().ready(function(){
  var type="${searchType}";
  if(type=="userId"){
	$("#searchType").val("userId");
	$("#man_nav_1").attr("class","bg_image");
    $("#man_nav_2").attr("class","bg_image_onclick");
    $("#man_nav_3").attr("class","bg_image");
   }
  if(type=="roleId"){
		$("#searchType").val("roleId");
		$("#man_nav_1").attr("class","bg_image_onclick");
		$("#man_nav_2").attr("class","bg_image");
	    $("#man_nav_3").attr("class","bg_image");
	   }
});
function list_sub_nav(Id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+Id).attr("class")=="bg_image"){
	   $("#"+Id).attr("class","bg_image_onclick");
   }
   showInnerText(Id);
}

function showInnerText(Id){
    var switchId = parseInt(Id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   $("#searchType").val("roleId");
		   break;
	    case 2:
		   $("#searchType").val("userId");
		   break;
	    case 3:
		   $("#searchType").val("userName");
		    break; 
	}
}
function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	window.location.href="commerceMemberController.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort;;
   }
  function jumpTo(){
   var pno=$("#pno").val();
   if(is_int(pno)==false){
		alert('<%= lang.readGm(GMLangConstants.INTERVAL_NOT_NEG)%>');
		$("#pno").focus();
		return false;
	}
   goTo(pno);
   }
function kickOut(id){
	var con = confirm("<%=lang.readGm(GMLangConstants.CONFRIM)%>?");
	if(con){
		$.post("commerceMemberController.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="commerceMemberController.do?action=init";
			}else{
			  alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}

		});
	}
}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.ROLE_MANAGE) %>
</div>
<div id="nav">
<ul>
    <li id="man_nav_3"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.COMMERCE_MEMBER_NAME)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.COMMERCE_MEMBER_NAME)%></li>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ROLE_ID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.COMMERCE_MEMBER_GUILDID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.COMMERCE_MEMBER_GUILDID)%></li>   
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.ROLE_LEVEL)%>:<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span><%=lang.readGm(GMLangConstants.COMMERCE_MEMBER_CURCONTRIB)%>:<input id='startIndexSort' type='text' value="${startIndexSort}" style="width: 50px;"/>&mdash;&mdash;<input id='endIndexSort' type='text' value="${endIndexSort}" style="width: 50px;margin:0px;"/></span>
</span>&nbsp;&nbsp;
 <input id="searchType" type="hidden" value="userName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='commerceMemberController.do?action=init'">
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0"
	border="0" width="100%">
  <tbody><tr>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.SECROTARENALEVEL_ROLEID)%></th>  
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_GUILDID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_NAME)%></th>
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_LEVEL)%></th>
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_COMMERCEPRO)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_CURCONTRIB)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_STATE)%></th>
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_LASTONLINETIME)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_LASTCONTRIBTIME)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_TODYCONTRIB)%></th>

  </tr>
  <c:forEach items="${commerceMemberList}" var="commerceMember">
      <tr>
        <td><a href="role.do?action=init&searchType=roleId&searchValue=${commerceMember.roleId}" class="link">&nbsp;${commerceMember.roleId}</td> 
        <td><a 	href="commerceController.do?action=init&searchType=userId&searchValue=${commerceMember.guildId}"class="link">&nbsp;${commerceMember.guildId}</td>
        <td>&nbsp;${commerceMember.name}</a></td>
        
        <td>&nbsp;${commerceMember.level} </a></td>
        <td>&nbsp;<c:if test="${commerceMember.commercePro eq 0}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_RANKNONE)%></c:if>
                  <c:if test="${commerceMember.commercePro eq 1}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_RANKMEMBER)%></c:if>
                  <c:if test="${commerceMember.commercePro eq 2}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_RANKVICECHAIRMAN)%></c:if>
                  <c:if test="${commerceMember.commercePro eq 3}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_RANKPRESIDENT)%></c:if>
        </td>
         <td>&nbsp;${commerceMember.curContrib}</td>
        <td>&nbsp;<c:if test="${commerceMember.state eq 0}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_STATENONE)%></c:if>
                  <c:if test="${commerceMember.state eq 1}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_STATENORMAL)%></c:if>
                  <c:if test="${commerceMember.state eq 2}"><%= lang.readGm(GMLangConstants.COMMERCE_MEMBER_STATEWITAPPLAY)%></c:if>
        </td>
        
        <td>&nbsp;${commerceMember.lastOnlineTime}</td>
        <td>&nbsp;${commerceMember.lastContribTime}</td>
        <td>&nbsp;${commerceMember.todayContrib}</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="12" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>