var MAPMODE=0;
var TOTALNUM_DIS=0;
var TOTALNUM=1356;
var CARDSHOWN=true;
var myChart=new Object();

$(document).ready(function(){
    //get device height
    if(document.documentElement.clientHeight>600){
        $('#cardWall').css("height",document.documentElement.clientHeight+"px")
    }

    //eChart initing
    myChart=echarts.init(document.getElementById('map'));
    myChart.showLoading({
        text: '加载中...', 
    });
    getData(function(){
        myChart.hideLoading();
        myChart.setOption(option);
    });

    //bind functions
    $('#mapChange').click(function(){
        if(CARDSHOWN){
	    switchMapMode();
	}
    });
    $('#cardDisplaySwitch').click(function(){
        if(CARDSHOWN){
            $('#map').hide();
            $('#cardWall').show();
            $('#cardDisplaySwitch').html("隐藏来信摘录");
            $('#cardDisplaySwitch').addClass("sideBtnOn");
            reArrange();
        }
        else{
            $('#cardWall').hide();
            $('#map').show();
            $('#cardDisplaySwitch').html("显示来信摘录");
            $('#cardDisplaySwitch').removeClass("sideBtnOn");
        }
        CARDSHOWN=!CARDSHOWN;
    })

    var add=setInterval(function(){
        if(TOTALNUM_DIS<TOTALNUM){
            $('.totalNum').html(TOTALNUM_DIS);
           TOTALNUM_DIS++;

        }
        else{
           clearInterval(add); 
        }
    },5);

    getCardData();
    window.onload = function() {reArrange();};
    window.onresize = function() {
        reArrange();
        if(document.documentElement.clientHeight>600){
	    $('#map').css("height",document.documentElement.clientHeight+"px");
            $('#cardWall').css("height",document.documentElement.clientHeight+"px");
        }
    };
});

//card display function
function reArrange(){
    var margin = 10;
    var li=$("li");
    var li_W = li[0].offsetWidth+margin;
    var h=[];//记录区块高度的数组
    var n = 860/li_W|0;
    for(var i = 0;i < li.length;i++) {
        li_H = li[i].offsetHeight==0?120:li[i].offsetHeight;
        if(i < n) {
            h[i]=li_H;
            li.eq(i).css("top",0);
            li.eq(i).css("left",i * li_W);
            }
        else{
            min_H =Math.min.apply(null,h) ;
            minKey = getarraykey(h, min_H);
            h[minKey] += li_H+margin ;
            li.eq(i).css("top",min_H+margin);
            li.eq(i).css("left",minKey * li_W); 
        }
    }
}
function getarraykey(s, v) {for(k in s) {if(s[k] == v) {return k;}}}


        


