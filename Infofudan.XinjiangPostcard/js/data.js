var SENDER_URL="/GetSenderData/";
var PHOTO_URL="/GetPhotoData/";
var GEORECORD_URL="/GetGeoRecord/";
var IMAGE_URL="/Uploads/images/";

var senderCity=[new Object(),new Object()];
var topSender=[new Object(),new Object()];
var markedLineData=[new Object(),new Object()];
var markedLineTopData=[new Object(),new Object()];
var markedPointData=[new Object(),new Object()];
var photoList=['0009','0012','0013','0029','0044','0060','0067','0069','0079','0083','0085','0096','0097','0102','0108','0111','0112','0116','0126','0135','0142','0154','0159','0171','0186','0212','0213','0220','0306','0309','0310','0315','0317','0331','0337','0351','0359','0385','0390','0396','0409','0441','0445','0471','0480','0484','0489','0571','0576','0594','0596','0600','0606','0610','0646','0660','0683','0701'];

//Map Data
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

function switchMapMode(){
    MAPMODE=1-MAPMODE;
    
    if(MAPMODE==1){
        for(var i=0;i<option.series.length;i++){
            option.series[i].mapType='world';
        }
    }
    else{
        for(var i=0;i<option.series.length;i++){
            option.series[i].mapType='china';
        }
    }
    option.series[0].markLine.data=markedLineData[MAPMODE];
    option.series[1].markLine.data=markedLineTopData[MAPMODE];
    option.series[2].markPoint.data=markedPointData[MAPMODE];
    myChart=echarts.init(document.getElementById('map'));
    myChart.setOption(option);
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

//Card Data
function getCardData(){
    for(var i=0;i<photoList.length;i++){
        $('#cardList').append('<li><img src="'+IMAGE_URL+photoList[i]+'正.jpg"></li>');
        $('#cardList').append('<li><img src="'+IMAGE_URL+photoList[i]+'反.jpg"></li>');
    }
    $('#cardList').append('<li><img src="'+IMAGE_URL+'0139.jpg"></li>');
    $('#cardList').append('<li><img src="'+IMAGE_URL+'0207.jpg"></li>');
}

//eChart Option
var effect = {
    show: true,
    scaleSize: 1,
    period: 15,             // 运动周期，无单位，值越大越慢
    color: '#fff',
    shadowColor: 'rgba(220,220,220,4)',
    shadowBlur : 1
};

var option = {
    backgroundColor: '#000',
    color: ['gold','aqua'],
    tooltip : {
        trigger: 'item',
        formatter: '{b}'
    },
    toolbox: {
        show : false,
        orient : 'vertical',
        x: 'right',
        y: 'top',
        feature : {
            saveAsImage : {show: true}
        }
    },
    dataRange: {
        show:false,
        min : 0,
        max : 30,
        calculable : true,
        color: ['aqua','aqua'],
        textStyle:{
            color:'#fff'
        }
    },
    series : [
        {
            name: '基础线',
            type: 'map',
            roam: true,
            hoverable: false,
            mapType: 'china',
            itemStyle:{
                normal:{
                    borderColor:'rgba(100,149,237,1)',
                    borderWidth:0.3,
                    areaStyle:{
                        color: '#000'
                    }
                }
            },
            data:[],
            markLine : {
                smooth:true,
                symbol: ['circle', 'circle'],  
                symbolSize : 1,
                itemStyle : {
                    normal: {
                        color:'#fff',
                        borderWidth:0.6,
                        borderColor:'rgba(30,144,255,0.5)'
                    }
                },
                data:[]
            },
            geoCoord:[] 
        },
        {
            name: '寄出地 Top10',
            type: 'map',
            mapType: 'china',
            data:[],
            markLine : {
                smooth:true,
                symbol: ['none', 'none'],
                effect : {
                    show: true,
                    scaleSize: 1,
                    period: 15,
                    color: '#fff',
                    shadowBlur: 2
                },
                itemStyle : {
                    normal: {
                        borderWidth:0.6,
                        lineStyle: {
                            type: 'solid',
                            shadowBlur: 10
                        }
                    }
                },
                data : []
            },
            markPoint : {
                symbol:'emptyCircle',
                symbolSize : function (v){
                    return 5 + v/300
                },
                effect : {
                    show: true,
                    shadowBlur : 0
                },
                itemStyle:{
                    normal:{
                        label:{show:false}
                    },
                    emphasis: {
                        label:{position:'top'}
                    }
                },
                data :[{name:'拜城',value:1461}]
            }
        },
        {
            name: '风景点',
            type: 'map',
            mapType: 'china',

            data : [],
            markPoint : {
                symbolSize: 2,
                large: true,
                effect : {
                    show: true,
                    period:10
                },
                data : []
            }
        }
    ]
};