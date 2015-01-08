var MAPMODE=0;
var CARDSHOWN=true;
var myChart=new Object();

$(document).ready(function(){
    myChart=echarts.init(document.getElementById('map'));
    myChart.showLoading({
        text: '读取数据中...', 
    });
    getData(function(){
        myChart.hideLoading();
        myChart.setOption(option);
    });
    $('#mapChange').click(function(){
        switchMapMode();
    });
    $('#cardDisplaySwitch').click(function(){
        if(CARDSHOWN){
            $('#map').hide();
            $('#cardWall').show();
            $('#cardDisplaySwitch').html("隐藏来信摘录");
            $('#cardDisplaySwitch').addClass("sideBtnOn");
        }
        else{
            $('#cardWall').hide();
            $('#map').show();
            $('#cardDisplaySwitch').html("显示来信摘录");
            $('#cardDisplaySwitch').removeClass("sideBtnOn");
        }
        CARDSHOWN=!CARDSHOWN;
    })
});

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
        show : true,
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
                data : [{name:"上海中国馆",value:1}]
            }
        }
    ]
};
                    


