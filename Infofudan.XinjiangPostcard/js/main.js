var MAPMODE=0;

$(document).ready(function(){
	var myChart=echarts.init(document.getElementById('map'));
	
	myChart.setOption(option);
});

var effect = {
    show: true,
    scaleSize: 1,
    period: 15,             // 运动周期，无单位，值越大越慢
    color: '#fff',
    shadowColor: 'rgba(220,220,220,4)',
    shadowBlur : 1
};

option = {
    backgroundColor: '#000',
    color: ['gold','aqua','lime'],
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
        min : 0,
        max : 100,
        calculable : true,
        color: ['#ff3333', 'orange', 'yellow','lime','aqua'],
        textStyle:{
            color:'#fff'
        }
    },
    series : [
        {
            name: '全国',
            type: 'map',
            roam: true,
            hoverable: false,
            mapType: 'china',
            itemStyle:{
                normal:{
                    borderColor:'rgba(100,149,237,1)',
                    borderWidth:0.5,
                    areaStyle:{
                        color: '#000'
                    }
                }
            },
            data:[],
            markLine : {
                smooth:true,
                symbol: ['none', 'circle'],  
                symbolSize : 1,
                itemStyle : {
                    normal: {
                        color:'#fff',
                        borderWidth:1,
                        borderColor:'rgba(30,144,255,0.5)'
                    }
                },
                data : markLineData
            },
            geoCoord: GEORECORD
        },
        {
            name: '寄出地 Top10',
            type: 'map',
            mapType: 'china',
            data:[],
            markLine : {
                smooth:true,
                effect : {
                    show: true,
                    scaleSize: 1,
                    period: 30,
                    color: '#fff',
                    shadowBlur: 10
                },
                itemStyle : {
                    normal: {
                        borderWidth:1,
                        lineStyle: {
                            type: 'solid',
                            shadowBlur: 10
                        }
                    }
                },
                data : [
                    [{name:'上海',value:95},{name:'北京'} ],
                    [{name:'广州',value:90},{name:'北京'}],
                    [{name:'北京'}, {name:'大连',value:80}],
                    [{name:'北京'}, {name:'南宁',value:70}],
                    [{name:'北京'}, {name:'南昌',value:60}],
                    [{name:'北京'}, {name:'拉萨',value:50}],
                    [{name:'北京'}, {name:'长春',value:40}],
                    [{name:'北京'}, {name:'包头',value:30}],
                    [{name:'北京'}, {name:'重庆',value:20}],
                    [{name:'北京'}, {name:'常州',value:10}]
                ]
            },
            markPoint : {
                symbol:'emptyCircle',
                symbolSize : function (v){
                    return 10 + v/10
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
                data : [
                    {name:'上海',value:95},
                    {name:'广州',value:90},
                    {name:'大连',value:80},
                    {name:'南宁',value:70},
                    {name:'南昌',value:60},
                    {name:'拉萨',value:50},
                    {name:'长春',value:40},
                    {name:'包头',value:30},
                    {name:'重庆',value:20},
                    {name:'常州',value:10}
                ]
            }
        },
    ]
};
                    


