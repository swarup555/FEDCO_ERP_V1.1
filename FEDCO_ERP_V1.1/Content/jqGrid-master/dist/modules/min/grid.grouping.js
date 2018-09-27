var $jscomp={scope:{},findInternal:function(d,v,k){d instanceof String&&(d=String(d));for(var b=d.length,e=0;e<b;e++){var g=d[e];if(v.call(k,g,e,d))return{i:e,v:g}}return{i:-1,v:void 0}}};$jscomp.defineProperty="function"==typeof Object.defineProperties?Object.defineProperty:function(d,v,k){if(k.get||k.set)throw new TypeError("ES3 does not support getters and setters.");d!=Array.prototype&&d!=Object.prototype&&(d[v]=k.value)};
$jscomp.getGlobal=function(d){return"undefined"!=typeof window&&window===d?d:"undefined"!=typeof global&&null!=global?global:d};$jscomp.global=$jscomp.getGlobal(this);$jscomp.polyfill=function(d,v,k,b){if(v){k=$jscomp.global;d=d.split(".");for(b=0;b<d.length-1;b++){var e=d[b];e in k||(k[e]={});k=k[e]}d=d[d.length-1];b=k[d];v=v(b);v!=b&&null!=v&&$jscomp.defineProperty(k,d,{configurable:!0,writable:!0,value:v})}};
$jscomp.polyfill("Array.prototype.find",function(d){return d?d:function(d,k){return $jscomp.findInternal(this,d,k).v}},"es6-impl","es3");
(function(d){"function"===typeof define&&define.amd?define(["jquery","./grid.base"],d):"object"===typeof exports?d(require("jquery")):d(jQuery)})(function(d){var v=d.jgrid,k=d.fn.jqGrid;v.extend({groupingSetup:function(){return this.each(function(){var b,e;e=this.p;var g=e.colModel,a=e.groupingView,c,h,l=function(){return""};if(null===a||"object"!==typeof a&&!d.isFunction(a))e.grouping=!1;else if(a.groupField.length){void 0===a.visibiltyOnNextGrouping&&(a.visibiltyOnNextGrouping=[]);a.lastvalues=
[];a._locgr||(a.groups=[]);a.counters=[];for(b=0;b<a.groupField.length;b++)a.groupOrder[b]||(a.groupOrder[b]="asc"),a.groupText[b]||(a.groupText[b]="{0}"),"boolean"!==typeof a.groupColumnShow[b]&&(a.groupColumnShow[b]=!0),"boolean"!==typeof a.groupSummary[b]&&(a.groupSummary[b]=!1),a.groupSummaryPos[b]||(a.groupSummaryPos[b]="footer"),c=g[e.iColByName[a.groupField[b]]],!0===a.groupColumnShow[b]?(a.visibiltyOnNextGrouping[b]=!0,null!=c&&!0===c.hidden&&k.showCol.call(d(this),a.groupField[b])):(a.visibiltyOnNextGrouping[b]=
d("#"+v.jqID(e.id+"_"+a.groupField[b])).is(":visible"),null!=c&&!0!==c.hidden&&k.hideCol.call(d(this),a.groupField[b]));a.summary=[];a.hideFirstGroupCol&&(a.formatDisplayField[0]=function(a){return a});b=0;for(e=g.length;b<e;b++)c=g[b],a.hideFirstGroupCol&&!c.hidden&&a.groupField[0]===c.name&&(c.formatter=l),c.summaryType&&(h={nm:c.name,st:c.summaryType,v:"",sr:c.summaryRound,srt:c.summaryRoundType||"round"},c.summaryDivider&&(h.sd=c.summaryDivider,h.vd=""),a.summary.push(h))}else e.grouping=!1})},
groupingPrepare:function(b,e){this.each(function(){var g=this,a=g.p,c=a.groupingView,h=c.groups,l=c.counters,r=c.lastvalues,n=c.isInTheSameGroup,v=c.groupField.length,p,t,w,x,u,D,z,y,f=!1,m=k.groupingCalculations.handler,B=function(){var a,c,f;for(a=0;a<u.summary.length;a++)c=u.summary[a],f=d.isArray(c.st)?c.st[x.idx]:c.st,d.isFunction(f)?c.v=f.call(g,c.v,c.nm,b,x):(c.v=m.call(d(g),f,c.v,c.nm,c.sr,c.srt,b),"avg"===f.toLowerCase()&&c.sd&&(c.vd=m.call(d(g),f,c.vd,c.sd,c.sr,c.srt,b)));return u.summary},
G=function(b,f){if(null==b&&c.useDefaultValuesOnGrouping){var e=void 0!==a.iColByName[f]?a.colModel[a.iColByName[f]]:a.additionalProperties[a.iPropByName[f]];null!=e&&null!=e.formatter&&(null!=e.formatoptions&&void 0!==e.formatoptions.defaultValue?b=e.formatoptions.defaultValue:"string"===typeof e.formatter&&(e=d(g).jqGrid("getGridRes","formatter."+e.formatter+".defaultValue"),void 0!==e&&(b=e)))}return b};for(p=0;p<v;p++)if(D=c.groupField[p],z=G(b[D],D),t=c.displayField[p],y=null==t?null:G(b[t],
t),null==y&&(y=z),void 0!==z){w=[];for(t=0;t<=p;t++)w.push(b[c.groupField[t]]);x={idx:p,dataIndex:D,value:z,displayValue:y,startRow:e,cnt:1,keys:w,summary:[]};u={cnt:1,pos:h.length,summary:d.extend(!0,[],c.summary)};0===e?(h.push(x),r[p]=z,l[p]=u):"object"===typeof z||(d.isArray(n)&&d.isFunction(n[p])?n[p].call(g,r[p],z,p,c):r[p]===z)?f?(h.push(x),r[p]=z,l[p]=u):(u=l[p],u.cnt+=1,h[u.pos].cnt=u.cnt):(h.push(x),r[p]=z,f=!0,l[p]=u);h[u.pos].summary=B();for(t=u.pos-1;0<=t;t--)if(h[t].idx<h[u.pos].idx){h[u.pos].parentGroupIndex=
t;h[u.pos].parentGroup=h[t];break}}});return this},getGroupHeaderIndex:function(b,e){var g=this[0].p,a=e?d(e).closest("tr.jqgroup"):d("#"+v.jqID(b)),c=parseInt(a.data("jqgrouplevel"),10),g=g.id+"ghead_"+c+"_";return isNaN(c)||!a.hasClass("jqgroup")||b.length<=g.length?-1:parseInt(b.substring(g.length),10)},groupingToggle:function(b,e){this.each(function(){var g=this.p,a=g.groupingView,c=a.minusicon,h=a.plusicon,l=e?d(e).closest("tr.jqgroup"):d("#"+v.jqID(b)),r,n,k=!0,p=!1,t=[],w=function(a){var c,
d=a.length;for(c=0;c<d;c++)t.push(a[c])},x=parseInt(l.data("jqgrouplevel"),10);g.frozenColumns&&0<l.length&&(n=l[0].rowIndex,l=d(this.rows[n]),l=l.add(this.grid.fbRows[n]));r=l.find(">td>span.tree-wrap");v.hasAllClasses(r,c)?(r.removeClass(c).addClass(h),p=!0):r.removeClass(h).addClass(c);for(l=l.next();l.length;l=l.next())if(l.hasClass("jqfoot"))if(r=parseInt(l.data("jqfootlevel"),10),p){if(r=parseInt(l.data("jqfootlevel"),10),(!a.showSummaryOnHide&&r===x||r>x)&&w(l),r<x)break}else{if((r===x||a.showSummaryOnHide&&
r===x+1)&&w(l),r<=x)break}else if(l.hasClass("jqgroup"))if(r=parseInt(l.data("jqgrouplevel"),10),p){if(r<=x)break;w(l)}else{if(r<=x)break;r===x+1&&(l.find(">td>span.tree-wrap").removeClass(c).addClass(h),w(l));k=!1}else(p||k)&&w(l);d(t).css("display",p?"none":"");g.frozenColumns&&d(this).triggerHandler("jqGridResetFrozenHeights",[{header:{resizeDiv:!1,resizedRows:{iRowStart:-1,iRowEnd:-1}},resizeFooter:!1,body:{resizeDiv:!0,resizedRows:{iRowStart:n,iRowEnd:l.length?l[0].rowIndex-1:-1}}}]);this.fixScrollOffsetAndhBoxPadding();
d(this).triggerHandler("jqGridGroupingClickGroup",[b,p]);d.isFunction(g.onClickGroup)&&g.onClickGroup.call(this,b,p)});return!1},groupingRender:function(b,e){function g(a,b,e,g,l){var f=t[a],m,p="",k,q,r,u=0,y,B,z,G=!0;if(0!==b&&0!==t[a].idx)for(m=a;0<=m;m--)if(t[m].idx===t[a].idx-b){f=t[m];break}a=f.cnt;for(y=void 0===l?g:0;y<x;y++){b="&#160;";m=w[y];for(k=0;k<f.summary.length;k++)if(q=f.summary[k],B=d.isArray(q.st)?q.st[e.idx]:q.st,z=d.isArray(m.summaryTpl)?m.summaryTpl[e.idx]:m.summaryTpl||"{0}",
q.nm===m.name){"string"===typeof B&&"avg"===B.toLowerCase()&&(q.sd&&q.vd?q.v/=q.vd:q.v&&0<a&&(q.v/=a));try{q.groupCount=f.cnt,q.groupIndex=f.dataIndex,q.groupValue=f.value,r=c.formatter("",q.v,y,q)}catch(K){r=q.v}b=v.format(z,r);m.summaryFormat&&(b=m.summaryFormat.call(c,e,b,r,m,q));break}q=k=!1;void 0!==l&&G&&!m.hidden&&(b=l,G=!1,1<g&&(k=!0,u=g-1),q=m.align,m.align="rtl"===h.direction?"right":"left",n.iconColumnName=m.name);0<u&&!m.hidden&&"&#160;"===b?(q&&(m.align=q),u--):(p+="<td role='gridcell' "+
c.formatCol(y,1,"")+(k?"colspan='"+g+"'":"")+">"+b+"</td>",q&&(m.align=q))}return p}var a="",c=this[0],h=c.p,l=0,r=[],n=h.groupingView,H=d.makeArray(n.groupSummary),p=n.groupField.length,t=n.groups,w=h.colModel,x=w.length,u=h.page,D=k.getGuiStyles.call(c,"gridRow","jqgroup ui-row-"+h.direction),z=k.getGuiStyles.call(c,"gridRow","jqfoot ui-row-"+h.direction);d.each(w,function(a,b){var c;for(c=0;c<p;c++)if(n.groupField[c]===b.name){r[c]=a;break}});H.reverse();d.each(t,function(k,f){var m,B=h.id+"ghead_"+
f.idx,y=B+"_"+k,E=d.isFunction(n.groupCollapse)?n.groupCollapse.call(c,{group:f,rowid:y}):n.groupCollapse,F,A;A=0;var C,q;C=p-1===f.idx;var I=null!=f.parentGroup?f.parentGroup.collapsed:!1;q="<span style='cursor:pointer;margin-"+("rtl"===h.direction?"right:":"left:")+12*f.idx+"px;' class='"+n.commonIconClass+" "+(E?n.plusicon:n.minusicon)+" tree-wrap' onclick=\"jQuery('#"+v.jqID(h.id).replace("\\","\\\\")+"').jqGrid('groupingToggle','"+y+"', this);return false;\"></span>";if(n._locgr&&!(f.startRow+
f.cnt>(u-1)*e&&f.startRow<u*e))return!0;I&&(E=!0);void 0!==E&&(f.collapsed=E);l++;try{d.isArray(n.formatDisplayField)&&d.isFunction(n.formatDisplayField[f.idx])?(f.displayValue=n.formatDisplayField[f.idx].call(c,f.displayValue,f.value,w[r[f.idx]],f.idx,n),m=f.displayValue):m=c.formatter(y,f.displayValue,r[f.idx],f.value)}catch(J){m=f.displayValue}a+="<tr id='"+y+"' data-jqgrouplevel='"+f.idx+"' "+(E&&I?"style='display:none;' ":"")+"role='row' class='"+D+" "+B+"'>";B=d.isFunction(n.groupText[f.idx])?
n.groupText[f.idx].call(c,m,f.cnt,f.summary):v.template(n.groupText[f.idx],m,f.cnt,f.summary);"string"!==typeof B&&"number"!==typeof B&&(B=m);"header"===n.groupSummaryPos[f.idx]?(m=1,"cb"!==w[0].name&&"cb"!==w[1].name||m++,"subgrid"!==w[0].name&&"subgrid"!==w[1].name||m++,a+=g(k,0,f,m,q+"<span class='cell-wrapper'>"+B+"</span>")):a+="<td role='gridcell' style='padding-left:"+12*f.idx+"px;' colspan='"+x+"'>"+q+B+"</td>";a+="</tr>";if(C){C=t[k+1];m=f.startRow;q=void 0!==C?C.startRow:t[k].startRow+t[k].cnt;
n._locgr&&(A=(u-1)*e,A>f.startRow&&(m=A));for(;m<q&&b[m-A];m++)a+=b[m-A].join("");if("header"!==n.groupSummaryPos[f.idx]){if(void 0!==C){for(F=0;F<n.groupField.length&&C.dataIndex!==n.groupField[F];F++);l=n.groupField.length-F}for(A=0;A<l;A++)H[A]&&(a+="<tr data-jqfootlevel='"+(f.idx-A)+(E&&(0<f.idx-A||!n.showSummaryOnHide)?"' style='display:none;'":"'")+" role='row' class='"+z+"'>",a+=g(k,A,t[f.idx-A],0),a+="</tr>");l=F}}});this.off("jqGridShowHideCol.groupingRender").on("jqGridShowHideCol.groupingRender",
function(){var a=h.iColByName[n.iconColumnName],b,e,g;if(0<=d.inArray("header",n.groupSummaryPos)){for(b=0;b<w.length;b++)if(!w[b].hidden){g=b;break}if(void 0!==g&&a!==g){for(b=0;b<c.rows.length;b++)e=c.rows[b],d(e).hasClass("jqgroup")&&(d(e.cells[g]).html(e.cells[a].innerHTML),d(e.cells[a]).html("&nbsp;"));n.iconColumnName=w[g].name}}});return a},groupingGroupBy:function(b,e){return this.each(function(){var g=this.p,a=g.groupingView,c,h;"string"===typeof b&&(b=[b]);g.grouping=!0;a._locgr=!1;void 0===
a.visibiltyOnNextGrouping&&(a.visibiltyOnNextGrouping=[]);for(c=0;c<a.groupField.length;c++)h=g.colModel[g.iColByName[a.groupField[c]]],!a.groupColumnShow[c]&&a.visibiltyOnNextGrouping[c]&&null!=h&&!0===h.hidden&&k.showCol.call(d(this),a.groupField[c]);for(c=0;c<b.length;c++)a.visibiltyOnNextGrouping[c]=d(g.idSel+"_"+v.jqID(b[c])).is(":visible");g.groupingView=d.extend(g.groupingView,e||{});a.groupField=b;d(this).trigger("reloadGrid")})},groupingRemove:function(b){return this.each(function(){var e=
this.p,g=this.tBodies[0],a=e.groupingView;void 0===b&&(b=!0);e.grouping=!1;if(!0===b){for(e=0;e<a.groupField.length;e++)!a.groupColumnShow[e]&&a.visibiltyOnNextGrouping[e]&&k.showCol.call(d(this),a.groupField);d("tr.jqgroup, tr.jqfoot",g).remove();d("tr.jqgrow",g).filter(":hidden").show()}else d(this).trigger("reloadGrid")})},groupingCalculations:{handler:function(b,d,g,a,c,h){var e={sum:function(){return parseFloat(d||0)+parseFloat(h[g]||0)},min:function(){return""===d?parseFloat(h[g]||0):Math.min(parseFloat(d),
parseFloat(h[g]||0))},max:function(){return""===d?parseFloat(h[g]||0):Math.max(parseFloat(d),parseFloat(h[g]||0))},count:function(){""===d&&(d=0);return h.hasOwnProperty(g)?d+1:0},avg:function(){return e.sum()}};if(!e[b])throw"jqGrid Grouping No such method: "+b;b=e[b]();null!=a&&("fixed"===c?b=b.toFixed(a):(a=Math.pow(10,a),b=Math.round(b*a)/a));return b}}})});
//# sourceMappingURL=grid.grouping.map