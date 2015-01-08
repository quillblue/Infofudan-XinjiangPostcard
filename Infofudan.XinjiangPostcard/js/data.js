var SENDER_URL="/GetSenderData/";
var PHOTO_URL="/GetPhotoData/";
var GEORECORD_URL="/GetGeoRecord/";

var senderCity=[new Object(),new Object()];
var topSender=[new Object(),new Object()];
var markedLineData=[new Object(),new Object()];
var markedLineTopData=[new Object(),new Object()];
var markedPointData=[new Object(),new Object()];

function getData(callback){
    $.when(
        $.post(SENDER_URL+"0",function(data){
            senderCity[0]=data;
            topSender[0]=senderCity[0].slice(0,5);
            $.post(SENDER_URL+"1",function(data){
                senderCity[1]=data;
                senderCity[1]=senderCity[0].concat(senderCity[1]);
                topSender[1]=senderCity[1].slice(0,5);
            })
        }),
        $.post(PHOTO_URL+"0",function(data){
            markedPointData[0]=data;
            $.post(PHOTO_URL+"1",function(data){
                markedPointData[1]=data;
                markedPointData[1]=markedPointData[0].concat(markedPointData[1]);
            })
        }),
        $.post(GEORECORD_URL,function(data){
            option.series[0].geoCoord= eval('(' + data + ')');
            markedLineData[0]=eval('(' + markLineToString(senderCity[0]) + ')');
            markedLineData[1]=eval('(' + markLineToString(senderCity[1]) + ')');
            markedLineTopData[0]=eval('(' + markColorLineToString(topSender[0]) + ')');
            markedLineTopData[1]=eval('(' + markColorLineToString(topSender[1]) + ')');
            option.series[0].markLine.data=markedLineData[0];
            option.series[1].markLine.data=markedLineTopData[0];
            option.series[2].markPoint.data=markedPointData[0];
        })
    ).done(function(){callback();})
}

function markLineToString(sender){
    var markLineStr='['
    for(var i=0;i<sender.length;i++){
        markLineStr=markLineStr+'[{name:\''+sender[i].name+'\'},{name:"拜城"}]';
        if(i==sender.length-1){
            markLineStr+=']';
        }
        else{
            markLineStr+=',';
        }
    }
    return markLineStr;
}

function markColorLineToString(sender){
    var markTopLineStr='[';
    for(var i=0;i<sender.length;i++){
        markTopLineStr=markTopLineStr+'[{name:\''+sender[i].name+'\'},{name:"拜城",value:'+sender[i].value+'}]';
        if(i==sender.length-1){
            markTopLineStr+=']';
        }
        else{
            markTopLineStr+=',';
        }
    }
    return markTopLineStr;
}