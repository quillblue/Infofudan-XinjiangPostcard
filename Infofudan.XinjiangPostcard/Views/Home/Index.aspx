<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8">
    <title>一张明信片计划 数读复旦</title>
    <link rel="stylesheet" type="text/css" href="/css/reset.css">
    <link rel="stylesheet" type="text/css" href="/css/home.css">
</head>
<body>
    <div>
        <div class="container">
            <div class="left">
                <div id="map" class="leftContent"></div>
                <div id="cardWall" class="leftContent cardWall" style="display:none" >
                    <ul id="cardList">
                    </ul>
                </div>
            </div>
            <div class="right">
                <div class="title">
                    一张明信片计划
                </div>
                <div class="count">
                    <p>截至2014年12月31日，已收到各地的明信片共</p>
                    <p class="total"><span class="totalNum">0</span>张</p>

                </div>
                <div class="sidebar">
                    <div class="sideMenu">
                        <a id="mapChange" class="sideBtn sideBtnLeft" href="#">切换地图视角</a>
                        <a id="cardDisplaySwitch" class="sideBtn sideBtnRight" href="#">显示来信摘录</a>
                        <div class="clear"></div>
                    </div>
                    <div class="sideTitle">
                        <div class="sideTitleTab">作者按</div>
                        <div class="clear"></div>
                    </div>
                    <div class="sideContentContainer">

                        <div id="intro" class="sideContent">
                            <p>2014年10月8日，“复旦支教在新疆”微信公共平台发起了“一张明信片计划”。10月21日，第一张明信片从上海来到拜城；当周周末，收到的明信片总数达到了299张。</p>

                            <p>对于新疆的孩子们，这些明信片成了一扇窗口，这是他们接触外面世界最简单但最直接有效的方式。而对于我们，这些明信片汇成了一股暖流，因为这片每个人的一点善意所汇聚成的满天星辰是那样的绚烂。</p>

                            <p>现在，我们将收到的明信片以电子地图的形式呈现，让更多人感受到善意的存在。</p>
                        </div>
                        
                    </div>
                    <div class="author">
                            <p>数据来自于复旦大学研究生支教团</p>
                            <p>复旦学生网&《复旦青年》联合制作</p>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
        <script type="text/javascript" src="js/echarts-all.js"></script>
        <script type="text/javascript" src="js/data.js"></script>
        <script type="text/javascript" src="js/main.js"></script>
        <script type="text/javascript">
            
            
        </script>
    </div>
</body>
</html>
