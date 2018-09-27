(function(a){"function"===typeof define&&define.amd?define(["jquery","./grid.base","./grid.common"],a):"object"===typeof exports?a(require("jquery")):a(jQuery)})(function(a){var p=a.jgrid;a.fn.jqFilter=function(h){if("string"===typeof h){var r=a.fn.jqFilter[h];if(!r)throw"jqFilter - No such method: "+h;var D=a.makeArray(arguments).slice(1);return r.apply(this,D)}var c=a.extend(!0,{filter:null,columns:[],onChange:null,afterRedraw:null,error:!1,errmsg:"",errorcheck:!0,showQuery:!0,sopt:null,ops:[],
operands:null,numopts:"eq ne lt le gt ge nu nn in ni".split(" "),stropts:"eq ne bw bn ew en cn nc nu nn in ni".split(" "),strarr:["text","string","blob"],groupOps:[{op:"AND",text:"AND"},{op:"OR",text:"OR"}],groupButton:!0,ruleButtons:!0,direction:"ltr"},p.filter,h||{});return this.each(function(){if(!this.filter){this.p=c;if(null===c.filter||void 0===c.filter)c.filter={groupOp:c.groupOps[0].op,rules:[],groups:[]};var h,r=c.columns.length,e,G=/msie/i.test(navigator.userAgent)&&!window.opera,x=a.isFunction,
H=null!=p.defaults&&x(p.defaults.fatalError)?p.defaults.fatalError:alert,u=function(){return a("#"+p.jqID(c.id))[0]||null},q=function(d,c){return a(u()).jqGrid("getGuiStyles",d,c||"")},B=function(d){return a(u()).jqGrid("getGridRes","search."+d)},I=function(a){var d=u(),b=d.p.iColByName[a];if(void 0!==b)return{cm:d.p.colModel[b],iCol:b};b=d.p.iPropByName[a];return void 0!==b?{cm:d.p.colModel[b],iCol:b,isAddProp:!0}:{cm:null,iCol:-1}},E=q("states.error"),D=q("dialog.content");c.initFilter=a.extend(!0,
{},c.filter);if(r){for(h=0;h<r;h++)e=c.columns[h],e.stype?e.inputtype=e.stype:e.inputtype||(e.inputtype="text"),e.sorttype?e.searchtype=e.sorttype:e.searchtype||(e.searchtype="string"),void 0===e.hidden&&(e.hidden=!1),e.label||(e.label=e.name),e.cmName=e.name,e.index&&(e.name=e.index),e.hasOwnProperty("searchoptions")||(e.searchoptions={}),e.hasOwnProperty("searchrules")||(e.searchrules={});c.showQuery&&a(this).append("<table class='queryresult "+D+"' style='display:block;max-width:440px;border:0px none;' dir='"+
c.direction+"'><tbody><tr><td class='query'></td></tr></tbody></table>");var J=function(a,m){var b=[!0,""],d=u();if(x(m.searchrules))b=m.searchrules.call(d,a,m);else if(p&&p.checkValues)try{b=p.checkValues.call(d,a,-1,m.searchrules,m.label)}catch(t){}b&&b.length&&!1===b[0]&&(c.error=!b[0],c.errmsg=b[1])};this.onchange=function(){c.error=!1;c.errmsg="";return x(c.onChange)?c.onChange.call(u(),c,this):!1};this.reDraw=function(){a("table.group:first",this).remove();var d=this.createTableForGroup(c.filter,
null);a(this).append(d);x(c.afterRedraw)&&c.afterRedraw.call(u(),c,this)};this.createTableForGroup=function(d,m){var b=this,g,t=a("<table class='"+q("searchDialog.operationGroup","group")+"' style='border:0px none;'><tbody></tbody></table>"),f="left";"rtl"===c.direction&&(f="right",t.attr("dir","rtl"));null===m&&t.append("<tr class='error' style='display:none;'><th colspan='5' class='"+E+"' align='"+f+"'></th></tr>");var k=a("<tr></tr>");t.append(k);f=a("<th colspan='5' align='"+f+"'></th>");k.append(f);
if(!0===c.ruleButtons){var F=a("<select class='"+q("searchDialog.operationSelect","opsel")+"'></select>");f.append(F);var k="",e;for(g=0;g<c.groupOps.length;g++)e=d.groupOp===b.p.groupOps[g].op?" selected='selected'":"",k+="<option value='"+b.p.groupOps[g].op+"'"+e+">"+b.p.groupOps[g].text+"</option>";F.append(k).on("change",function(){d.groupOp=a(F).val();b.onchange()})}k="<span></span>";c.groupButton&&(k=a("<input type='button' value='+ {}' title='"+B("addGroupTitle")+"' class='"+q("searchDialog.addGroupButton",
"add-group")+"'/>"),k.on("click",function(){void 0===d.groups&&(d.groups=[]);d.groups.push({groupOp:c.groupOps[0].op,rules:[],groups:[]});b.reDraw();b.onchange();return!1}));f.append(k);if(!0===c.ruleButtons){var k=a("<input type='button' value='+' title='"+B("addRuleTitle")+"' class='"+q("searchDialog.addRuleButton","add-rule ui-add")+"'/>"),h;k.on("click",function(){var c,f,k;void 0===d.rules&&(d.rules=[]);for(g=0;g<b.p.columns.length;g++)if(c=void 0===b.p.columns[g].search?!0:b.p.columns[g].search,
f=!0===b.p.columns[g].hidden,(k=!0===b.p.columns[g].searchoptions.searchhidden)&&c||c&&!f){h=b.p.columns[g];break}c=h.searchoptions.sopt?h.searchoptions.sopt:b.p.sopt?b.p.sopt:-1!==a.inArray(h.searchtype,b.p.strarr)?b.p.stropts:b.p.numopts;d.rules.push({field:h.name,op:c[0],data:""});b.reDraw();return!1});f.append(k)}null!==m&&(k=a("<input type='button' value='-' title='"+B("deleteGroupTitle")+"' class='"+q("searchDialog.deleteGroupButton","delete-group")+"'/>"),f.append(k),k.on("click",function(){for(g=
0;g<m.groups.length;g++)if(m.groups[g]===d){m.groups.splice(g,1);break}b.reDraw();b.onchange();return!1}));if(void 0!==d.groups)for(g=0;g<d.groups.length;g++)f=a("<tr></tr>"),t.append(f),k=a("<td class='first'></td>"),f.append(k),k=a("<td colspan='4'></td>"),k.append(this.createTableForGroup(d.groups[g],d)),f.append(k);void 0===d.groupOp&&(d.groupOp=b.p.groupOps[0].op);if(void 0!==d.rules)for(g=0;g<d.rules.length;g++)t.append(this.createTableRowForRule(d.rules[g],d));return t};this.createTableRowForRule=
function(d,m){var b=this,g=u(),h=a("<tr></tr>"),f,k,e,n="",v;h.append("<td class='first'></td>");var l=a("<td class='columns'></td>");h.append(l);var r=a("<select class='"+q("searchDialog.label","selectLabel")+"'></select>"),y,w=[];l.append(r);r.on("change",function(){d.field=a(r).val();var c=a(this).parents("tr:first"),f,e;for(e=0;e<b.p.columns.length;e++)if(b.p.columns[e].name===d.field){f=b.p.columns[e];break}if(f){e=a.extend({},f.editoptions||{});delete e.readonly;delete e.disabled;var h=a.extend({},
e||{},f.searchoptions||{},I(f.cmName),{id:p.randId(),name:f.name,mode:"search"});h.column=f;G&&"text"===f.inputtype&&!h.size&&(h.size=10);var m=p.createEl.call(g,f.inputtype,h,"",!0,b.p.ajaxSelectOptions||{},!0);a(m).addClass(q("searchDialog.elem","input-elm"));k=h.sopt?h.sopt:b.p.sopt?b.p.sopt:-1!==a.inArray(f.searchtype,b.p.strarr)?b.p.stropts:b.p.numopts;f="";var t=0,l,n;w=[];a.each(b.p.ops,function(){w.push(this.oper)});b.p.cops&&a.each(b.p.cops,function(b){w.push(b)});for(e=0;e<k.length;e++)n=
k[e],y=a.inArray(k[e],w),-1!==y&&(l=b.p.ops[y],l=void 0!==l?l.text:b.p.cops[n].text,0===t&&(d.op=n),f+="<option value='"+n+"'>"+l+"</option>",t++);a(".selectopts",c).empty().append(f);a(".selectopts",c)[0].selectedIndex=0;p.msie&&9>p.msiever()&&(e=parseInt(a("select.selectopts",c)[0].offsetWidth,10)+1,a(".selectopts",c).width(e),a(".selectopts",c).css("width","auto"));a(".data",c).empty().append(m);p.bindEv.call(g,m,h);a(".input-elm",c).on("change",function(c){c=c.target;d.data="SPAN"===c.nodeName.toUpperCase()&&
h&&x(h.custom_value)?h.custom_value.call(g,a(c).children(".customelement:first"),"get"):c.value;a(c).is("input[type=checkbox]")&&!a(c).is(":checked")&&(d.data=a(c).data("offval"));b.onchange()});setTimeout(function(){d.data=a(m).val();b.onchange()},0)}});var l=0,z,A;for(f=0;f<b.p.columns.length;f++)if(v=void 0===b.p.columns[f].search?!0:b.p.columns[f].search,z=!0===b.p.columns[f].hidden,(A=!0===b.p.columns[f].searchoptions.searchhidden)&&v||v&&!z)v="",d.field===b.p.columns[f].name&&(v=" selected='selected'",
l=f),n+="<option value='"+b.p.columns[f].name+"'"+v+">"+b.p.columns[f].label+"</option>";r.append(n);n=a("<td class='operators'></td>");h.append(n);e=c.columns[l];G&&"text"===e.inputtype&&!e.searchoptions.size&&(e.searchoptions.size=10);l=a.extend({},e.editoptions||{});delete l.readonly;delete l.disabled;l=a.extend({},l,e.searchoptions||{},I(e.cmName),{id:p.randId(),name:e.name});l.column=e;l=p.createEl.call(g,e.inputtype,l,d.data,!0,b.p.ajaxSelectOptions||{},!0);if("nu"===d.op||"nn"===d.op||0<=a.inArray(d.op,
g.p.customUnaryOperations))a(l).attr("readonly","true"),a(l).attr("disabled","true");var C=a("<select class='"+q("searchDialog.operator","selectopts")+"'></select>");n.append(C);C.on("change",function(){d.op=a(C).val();var c=a(this).parents("tr:first"),c=a(".input-elm",c)[0];"nu"===d.op||"nn"===d.op||0<=a.inArray(d.op,g.p.customUnaryOperations)?(d.data="","SELECT"!==c.tagName.toUpperCase()&&(c.value=""),c.setAttribute("readonly","true"),c.setAttribute("disabled","true")):("SELECT"===c.tagName.toUpperCase()&&
(d.data=c.value),c.removeAttribute("readonly"),c.removeAttribute("disabled"));b.onchange()});k=e.searchoptions.sopt?e.searchoptions.sopt:b.p.sopt?b.p.sopt:-1!==a.inArray(e.searchtype,b.p.strarr)?b.p.stropts:b.p.numopts;n="";a.each(b.p.ops,function(){w.push(this.oper)});b.p.cops&&a.each(b.p.cops,function(b){w.push(b)});for(f=0;f<k.length;f++)A=k[f],y=a.inArray(k[f],w),-1!==y&&(z=b.p.ops[y],v=d.op===A?" selected='selected'":"",n+="<option value='"+A+"'"+v+">"+(void 0!==z?z.text:b.p.cops[A].text)+"</option>");
C.append(n);n=a("<td class='data'></td>");h.append(n);n.append(l);p.bindEv.call(g,l,e.searchoptions);a(l).addClass(q("searchDialog.elem","input-elm")).on("change",function(){d.data="custom"===e.inputtype?e.searchoptions.custom_value.call(g,a(this).children(".customelement:first"),"get"):a(this).val();a(this).is("input[type=checkbox]")&&!a(this).is(":checked")&&(d.data=a(this).data("offval"));b.onchange()});n=a("<td></td>");h.append(n);!0===c.ruleButtons&&(l=a("<input type='button' value='-' title='"+
B("deleteRuleTitle")+"' class='"+q("searchDialog.deleteRuleButton","delete-rule ui-del")+"'/>"),n.append(l),l.on("click",function(){for(f=0;f<m.rules.length;f++)if(m.rules[f]===d){m.rules.splice(f,1);break}b.reDraw();b.onchange();return!1}));return h};this.getStringForGroup=function(a){var c="(",b;if(void 0!==a.groups)for(b=0;b<a.groups.length;b++){1<c.length&&(c+=" "+a.groupOp+" ");try{c+=this.getStringForGroup(a.groups[b])}catch(g){H(g)}}if(void 0!==a.rules)try{for(b=0;b<a.rules.length;b++)1<c.length&&
(c+=" "+a.groupOp+" "),c+=this.getStringForRule(a.rules[b])}catch(g){H(g)}c+=")";return"()"===c?"":c};this.getStringForRule=function(d){var e="",b="",g,h,f=d.data,k;for(g=0;g<c.ops.length;g++)if(c.ops[g].oper===d.op){e=c.operands.hasOwnProperty(d.op)?c.operands[d.op]:"";b=c.ops[g].oper;break}if(""===b&&null!=c.cops)for(k in c.cops)if(c.cops.hasOwnProperty(k)&&(b=k,e=c.cops[k].operand,x(c.cops[k].buildQueryValue)))return c.cops[k].buildQueryValue.call(c,{cmName:d.field,searchValue:f,operand:e});for(g=
0;g<c.columns.length;g++)if(c.columns[g].name===d.field){h=c.columns[g];break}if(null==h)return"";if("bw"===b||"bn"===b)f+="%";if("ew"===b||"en"===b)f="%"+f;if("cn"===b||"nc"===b)f="%"+f+"%";if("in"===b||"ni"===b)f=" ("+f+")";c.errorcheck&&J(d.data,h);return-1!==a.inArray(h.searchtype,["int","integer","float","number","currency"])||"nn"===b||"nu"===b||0<=a.inArray(b,u().p.customUnaryOperations)?d.field+" "+e+" "+f:d.field+" "+e+' "'+f+'"'};this.resetFilter=function(){c.filter=a.extend(!0,{},c.initFilter);
this.reDraw();this.onchange()};this.hideError=function(){a("th."+E,this).html("");a("tr.error",this).hide()};this.showError=function(){a("th."+E,this).html(c.errmsg);a("tr.error",this).show()};this.toUserFriendlyString=function(){return this.getStringForGroup(c.filter)};this.toString=function(){function a(b){var c="(",d;if(void 0!==b.groups)for(d=0;d<b.groups.length;d++)1<c.length&&(c="OR"===b.groupOp?c+" || ":c+" && "),c+=a(b.groups[d]);if(void 0!==b.rules)for(d=0;d<b.rules.length;d++){1<c.length&&
(c="OR"===b.groupOp?c+" || ":c+" && ");var f=void 0,h,m=b.rules[d];if(e.p.errorcheck){for(h=0;h<e.p.columns.length;h++)if(e.p.columns[h].name===m.field){f=e.p.columns[h];break}f&&J(m.data,f)}c+=m.op+"(item."+m.field+",'"+m.data+"')"}c+=")";return"()"===c?"":c}var e=this;return a(c.filter)};this.reDraw();if(c.showQuery)this.onchange();this.filter=!0}}})};a.extend(a.fn.jqFilter,{toSQLString:function(){var a="";this.each(function(){a=this.toUserFriendlyString()});return a},filterData:function(){var a;
this.each(function(){a=this.p.filter});return a},getParameter:function(a){return void 0!==a&&this.p.hasOwnProperty(a)?this.p[a]:this.p},resetFilter:function(){return this.each(function(){this.resetFilter()})},addFilter:function(h){"string"===typeof h&&(h=a.parseJSON(h));this.each(function(){this.p.filter=h;this.reDraw();this.onchange()})}})});
//# sourceMappingURL=grid.filter.map